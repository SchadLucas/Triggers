namespace Triggers.API.Frontend.Mappers
{
    using System.IO;

    public class FaviconMapper : StaticResourceMapperBase
    {
        public override string Map(string resourceUrl)
        {
            var path = Path.Combine("Content", "Images", "favicon.ico");
            
            // todo: Folder Environment specific (OS, IsProduction/IsDebug, ..)
            var startupFolder = Directory.GetCurrentDirectory();

            return Path.Combine(startupFolder, "UI", path);
        }

        public override bool CanHandle(string resourceUrl)
        {
            return resourceUrl.Equals("/favicon.ico");
        }
    }
}