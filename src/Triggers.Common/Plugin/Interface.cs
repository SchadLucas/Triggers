namespace Triggers.Common.Plugin
{
    public interface IInputPluginModel {}

    public interface IOutputModel {}

    public interface IInputPlugin
    {
        void Start<T>(IInputPluginModel f);
        string Name { get; }
    }

    public interface IOutputPlugin
    {
        void Start<T>(IInputPluginModel f);
        string Name { get; }
    }
}