namespace Triggers.Host.Owin
{
    public interface IHostController
    {
        void StartServer();
        void StopServer();
    }
}