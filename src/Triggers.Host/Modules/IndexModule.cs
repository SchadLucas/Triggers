namespace Triggers.Host.Modules
{
    using Nancy;

    public class MainModule : NancyModule
    {
        public MainModule()
        {
            // warum auch immer? können hier keine Abhängikeiten via Cosntructor Injection geladen werden
            // zumindest wird ein leers IPluginRepository geladen - obwohl es nicht leer sein sollte
            // der Container hat die Plugins zu dieser Zeit eigentlich schon geladen
            Get["/"] = _ =>View["index"];
        }
    }
}