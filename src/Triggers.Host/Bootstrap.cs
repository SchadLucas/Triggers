namespace Triggers.Host
{
    using System;
    using Triggers.Common.Composition;

    public static class Bootstrap
    {
        private static IContainer _container;
        
        //todo:
        public static void Start( /*StartupContext startupContext,*/ Action<IContainer> startCallback = null)
        {
            _container = MainAppContainerBuilder.BuildContainer();
            var appMode = GetApplicationMode( /*startupContext*/);
            _container.Resolve<Router>().Route(appMode);
            if (startCallback != null) {
                startCallback(_container);
            }
            else {
                SpinToExit(appMode);
            }
        }

        private static void SpinToExit(ApplicationMode appMode)
        {
            //todo:
            //if (IsInUtilityMode(applicationModes)) {
            //    return;
            //}

            _container.Resolve<IWaitForExit>().Spin();
        }

        private static ApplicationMode GetApplicationMode()
        {
            // todo: 
            return ApplicationMode.Interactive;
        }
    }
}