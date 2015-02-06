namespace Triggers.Host.Middleware
{
    using global::Owin;
    using Nancy.Bootstrapper;
    using Nancy.Owin;

    public class NancyMiddleware : IOwinMiddleware
    {
        public NancyMiddleware(INancyBootstrapper nancyBootstrapper)
        {
            _nancyBootstrapper = nancyBootstrapper;
        }

        private readonly INancyBootstrapper _nancyBootstrapper;

        public ushort Order
        {
            get { return 3; }
        }

        public void Attach(IAppBuilder appBuilder)
        {
            var options = new NancyOptions {
                Bootstrapper = _nancyBootstrapper,
                PerformPassThrough = context => context.Request.Path.StartsWith("/signalr")
            };

            appBuilder.UseNancy(options);
        }
    }
}