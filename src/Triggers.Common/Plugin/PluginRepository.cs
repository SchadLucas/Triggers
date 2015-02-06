namespace Triggers.Common.Plugin
{
    using System.Collections.Generic;
    using Triggers.Common.Composition;

    public interface IPluginRepository
    {
        List<IInputPlugin> InputPlugins { get; }
        List<IOutputPlugin> OutputPlugins { get; }
    }

    public class PluginRepository : IPluginRepository
    {
        public PluginRepository(IContainer container)
        {
            InputPlugins = new List<IInputPlugin>();
            OutputPlugins = new List<IOutputPlugin>();

            _container = container;
            InputPlugins.AddRange(_container.ResolveAll<IInputPlugin>());
            OutputPlugins.AddRange(_container.ResolveAll<IOutputPlugin>());
        }

        private IContainer _container;
        public List<IInputPlugin> InputPlugins { get; private set; }
        public List<IOutputPlugin> OutputPlugins { get; private set; }
    }
}