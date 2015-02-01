namespace Triggers.Host
{
    using System.Collections.Generic;
    using System.Linq;
    using global::Owin;
    using Triggers.Host.Middleware;

    public class OwinStartup
    {
        public OwinStartup(IEnumerable<IOwinMiddleware> owinMiddleWares)
        {
            _owinMiddleWares = owinMiddleWares;
        }

        private readonly IEnumerable<IOwinMiddleware> _owinMiddleWares;

        public void Configuration(IAppBuilder appBuilder)
        {
            foreach (var middleware in _owinMiddleWares.OrderBy(m => m.Order)) {
                middleware.Attach(appBuilder);
            }
        }
    }
}