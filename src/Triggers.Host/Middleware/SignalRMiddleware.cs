namespace Triggers.Host.Middleware
{
    using System;
    using global::Owin;
    using Microsoft.AspNet.SignalR;
    using Triggers.Common.Composition;
    using Triggers.SignalR;

    public class SignalRMiddleware : IOwinMiddleware
    {
        public SignalRMiddleware(IContainer container)
        {
            SignalRDependencyResolver.Register(container);

            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromMinutes(3);
        }

        public ushort Order
        {
            get { return 4; }
        }

        public void Attach(IAppBuilder appBuilder)
        {
            appBuilder.MapSignalR();
            //appBuilder.MapConnection("signalr", typeof (TriggersPersistentConnection), new ConnectionConfiguration());
            //appBuilder.MapConnection("signalr", typeof (TriggersPersistentConnection), new ConnectionConfiguration {EnableCrossDomain = true});
        }
    }
}