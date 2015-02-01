namespace Triggers.Host.Middleware
{
    using System.Threading.Tasks;
    using global::Owin;
    using Microsoft.Owin;
    using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

    public class LowerPathMiddleware : IOwinMiddleware
    {
        public ushort Order
        {
            get { return 2; }
        }

        public void Attach(IAppBuilder appBuilder)
        {
            appBuilder.Use(typeof (LowerRequestPathString));
        }
    }

    public class LowerRequestPathString : OwinMiddleware
    {
        public LowerRequestPathString(OwinMiddleware next) : base(next) {}

        public override async Task Invoke(IOwinContext context)
        {
            context.Environment["owin.RequestPath"] = ((string) context.Environment["owin.RequestPath"]).ToLower();
            await Next.Invoke(context);
        }
    }
}