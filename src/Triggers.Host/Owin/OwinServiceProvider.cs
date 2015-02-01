namespace Triggers.Host.Owin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using global::Owin;
    using Microsoft.Owin.Hosting;
    using Microsoft.Owin.Hosting.Engine;
    using Microsoft.Owin.Hosting.Services;
    using Microsoft.Owin.Hosting.Tracing;
    using Triggers.Host.Middleware;

    public interface IOwinAppFactory
    {
        IDisposable CreateApp(List<string> urls);
    }

    public class OwinAppFactory : IOwinAppFactory
    {
        public OwinAppFactory(IEnumerable<IOwinMiddleware> owinMiddlewares)
        {
            _owinMiddlewares = owinMiddlewares;
        }

        private IEnumerable<IOwinMiddleware> _owinMiddlewares;

        public IDisposable CreateApp(List<string> urls)
        {
            var services = CreateServiceFactory();
            var engine = services.GetService<IHostingEngine>();
            var options = new StartOptions() {
                ServerFactory = "Microsoft.Owin.Host.HttpListener"
            };

            urls.Add("http://+:8080"); // todo:
            urls.ForEach(options.Urls.Add);
            var context = new StartContext(options) {Startup = BuildApp};
            try {
                return engine.Start(context);
            }
            catch (TargetInvocationException ex) {
                if (ex.InnerException == null) {
                    throw;
                }

                if (ex.InnerException is HttpListenerException) {
                    throw new NotImplementedException();
                    //throw new PortInUseException("Port {0} is already in use, please ensure NzbDrone is not already running.", ex, _configFileProvider.Port);
                }

                throw ex.InnerException;
            }
        }

        private void BuildApp(IAppBuilder appBuilder)
        {
            appBuilder.Properties["host.AppName"] = "NzbDrone";

            foreach (var middleWare in _owinMiddlewares.OrderBy(c => c.Order)) {
                // _logger.Debug("Attaching {0} to host", middleWare.GetType().Name);
                middleWare.Attach(appBuilder);
            }
        }

        private IServiceProvider CreateServiceFactory()
        {
            var provider = (ServiceProvider) ServicesFactory.Create();
            provider.Add(typeof (ITraceOutputFactory), typeof (OwinTraceOutputFactory));

            return provider;
        }
    }
}