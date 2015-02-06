namespace Triggers.SignalR
{
    using Microsoft.AspNet.SignalR;
    using Triggers.Common.Plugin;

    public class ApiHub : Hub
    {
        public ApiHub(IPluginRepository pluginRepository)
        {
            _pluginRepository = pluginRepository;
        }

        private readonly IPluginRepository _pluginRepository;

        public void SendMsg(string msg)
        {
            // Call the broadcastMessage method to update clients.
            //Clients.All.broadcastMessage(msg);
            //Clients.All.broadcastMessage(new Random().Next(0, 10));

            foreach (var plugin in _pluginRepository.InputPlugins) {
                Clients.All.broadcastMessage(plugin.Name);
            }
        }
    }
}