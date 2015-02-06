namespace Triggers.Host.Middleware
{
    using System.Threading.Tasks;
    using global::Owin;
    using Microsoft.Owin;
    using NLog;

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
            var e = new OwinContext(context.Environment);

            // todo: Log if path does not exist
            _logger.Info("[{1}] {2} from {0}", e.Request.RemoteIpAddress, e.Request.Method, e.Request.Path);
            await Next.Invoke(context);
        }
    }
}