namespace Triggers.Host.Middleware
{
    using System.Threading.Tasks;
    using global::Owin;
    using Microsoft.Owin;

    internal class HttpResponseHeaderMiddleware : IOwinMiddleware
    {
        public ushort Order
        {
            get { return 0; }
        }

        public void Attach(IAppBuilder appBuilder)
        {
            appBuilder.Use(typeof (AddApplicationVersionHeader));
        }
    }

    public class AddApplicationVersionHeader : OwinMiddleware
    {
        public AddApplicationVersionHeader(OwinMiddleware next)
            : base(next) {}

        public override async Task Invoke(IOwinContext context)
        {
            //context.Response.Headers.Add("X-ApplicationVersion", BuildInfo.Version.ToString());
            // todo: Get VersionNumber from Service
            // todo: Implement Headers? => curl -I [url] => http 500
            context.Response.Headers.Add("X-ApplicationVersion", new[] {"0.0.1"});

            await Next.Invoke(context);
        }
    }
}