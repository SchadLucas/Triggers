namespace Triggers.Host
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;
    using Triggers.Host.Middleware;

    internal class NancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override byte[] FavIcon
        {
            get { return null; }
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            // var x = container.Resolve(typeof (IOwinMiddleware));
            // your customization goes here
        }
    }
}