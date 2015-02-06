namespace Triggers.SignalR
{
    using System;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Infrastructure;
    using Triggers.Common.Composition;

    public class SignalRDependencyResolver : DefaultDependencyResolver
    {
        private SignalRDependencyResolver(IContainer container)
        {
            container.RegisterSingleton(typeof (IPerformanceCounterManager), typeof (NoOpPerformanceCounterManager));
            _container = container;
        }

        private readonly IContainer _container;

        public static void Register(IContainer container)
        {
            GlobalHost.DependencyResolver = new SignalRDependencyResolver(container);
        }

        public override object GetService(Type serviceType)
        {
            if (_container.IsTypeRegistered(serviceType)) {
                return _container.Resolve(serviceType);
            }

            return base.GetService(serviceType);
        }
    }
}