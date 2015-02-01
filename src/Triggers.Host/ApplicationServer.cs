namespace Triggers.Host
{
    using Triggers.Host.Owin;

    public interface ITriggersServiceFactory
    {
        // ServiceBase Build();
        void Start();
    }

    public class ApplicationServer : /*ServiceBase,*/ ITriggersServiceFactory /*, IHandle<ApplicationShutdownRequested>*/
    {
        public ApplicationServer(IHostController hostController)
        {
            _hostController = hostController;
        }

        private readonly IHostController _hostController;

        public void Start()
        {
            _hostController.StartServer();
        }
    }
}