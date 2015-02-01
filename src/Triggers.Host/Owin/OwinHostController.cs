namespace Triggers.Host.Owin
{
    using System;
    using System.Linq;

    public class OwinHostController : IHostController
    {
        public OwinHostController(IOwinAppFactory owinAppFactory)
        {
            _owinAppFactory = owinAppFactory;
        }

        private readonly IOwinAppFactory _owinAppFactory;
        private IDisposable _owinApp;
        public void StartServer()
        {
            //_owinApp = _owinAppFactory.CreateApp(_urlAclAdapter.Urls);
            var urls = new[] {"http://+:8080"};
            _owinApp = _owinAppFactory.CreateApp(urls.ToList());
        }

        public void StopServer()
        {
            throw new NotImplementedException();
            if (_owinApp == null) return;

            //_logger.Info("Attempting to stop OWIN host");
            //_owinApp.Dispose();
            //_owinApp = null;
            //_logger.Info("Host has stopped");
        }
    }
}