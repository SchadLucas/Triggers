namespace Triggers.Host
{
    using System;

    public class Router
    {
        public Router(ITriggersServiceFactory triggersServiceFactory)
        {
            _triggersServiceFactory = triggersServiceFactory;
        }

        private ITriggersServiceFactory _triggersServiceFactory;

        public void Route(ApplicationMode applicationMode)
        {
            switch (applicationMode) {
            case ApplicationMode.Help:
                throw new NotImplementedException();
            case ApplicationMode.Interactive:
                _triggersServiceFactory.Start();
                break;
            case ApplicationMode.InstallService:
                throw new NotImplementedException();
            case ApplicationMode.UninstallService:
                throw new NotImplementedException();
            case ApplicationMode.Service:
                throw new NotImplementedException();
            }
        }
    }
}