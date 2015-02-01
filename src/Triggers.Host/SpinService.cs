namespace Triggers.Host
{
    using System.Threading;

    public interface IWaitForExit
    {
        void Spin();
    }

    public class SpinService : IWaitForExit
    {
        public void Spin()
        {
            // todo:
            while (true) {
                Thread.Sleep(1000);
            }
        }
    }
}