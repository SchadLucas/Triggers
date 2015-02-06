namespace Triggers.Plugin.RSS
{
    using System;
    using Triggers.Common.Plugin;

    public class RssInputPluginModel : IInputPluginModel {}

    [PluginType(typeof (IInputPlugin))]
    [PluginModelType(typeof (RssInputPluginModel))]
    public class RssInputPlugin : IInputPlugin
    {
        public void Start<T>(IInputPluginModel f)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return "RSS Input Plugin"; }
        }
    }
}