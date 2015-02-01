using Owin;

namespace Triggers.Host.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using NLog;
    using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

    public class LoggingMiddleware : IOwinMiddleware
    {
        public ushort Order
        {
            get { return 0; }
        }

        public void Attach(IAppBuilder appBuilder)
        {
            appBuilder.Use(typeof (LogRequestedPath));
        }
    }

    public class LogRequestedPath : OwinMiddleware
    {
        public LogRequestedPath(OwinMiddleware next) : base(next) {}
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public override async Task Invoke(IOwinContext context)
        {
            var e = new OwinEnvironment(context.Environment);
            _logger.Info("Begin Request: {0}", e.Request.Path);
            await Next.Invoke(context);
        }
    }
}