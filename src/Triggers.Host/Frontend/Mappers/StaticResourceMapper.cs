namespace Triggers.Host.Frontend.Mappers
{
    using System;
    using System.IO;

    public class StaticResourceMapper : StaticResourceMapperBase
    {
        public override string Map(string resourceUrl)
        {
            var path = resourceUrl.Replace("resources", String.Empty);
            path = path.Replace('/', Path.DirectorySeparatorChar);
            path = path.Trim(Path.DirectorySeparatorChar);

            //return Path.Combine(_appFolderInfo.StartUpFolder, "UI", path);
            var startUpFolder = Directory.GetCurrentDirectory();
            return Path.Combine(startUpFolder, "Triggers.UI", path);
        }

        public override bool CanHandle(string resourceUrl)
        {
            return resourceUrl.StartsWith("/resources/");
        }
    }
}