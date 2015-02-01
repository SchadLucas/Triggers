namespace Triggers.Host.Modules
{
    using Nancy;

    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = parameters => { return "nur slash"; };
        }
    }
}