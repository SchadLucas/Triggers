namespace Triggers.Host.Middleware
{
    using global::Owin;

    public class NancyMiddleware : IOwinMiddleware
    {
        public ushort Order
        {
            get { return 3; }
        }

        public void Attach(IAppBuilder appBuilder)
        {
            appBuilder.UseNancy(options => options.PerformPassThrough = context =>
                                                                        context.Request.Path.StartsWith("/signalr"));
        }
    }
}