namespace Triggers.Host
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Nancy.Bootstrapper;
    using Triggers.Common.Composition;

    public class MainAppContainerBuilder : ContainerBuilderBase
    {
        private MainAppContainerBuilder( /*StartupContext args,*/ string[] assemblies)
            : base( /*args,*/ assemblies)
        {
            //AutoRegisterImplementations<NzbDronePersistentConnection>();
            //Container.Register(typeof (IBasicRepository<NamingConfig>), typeof (BasicRepository<NamingConfig>));

            Container.Register<INancyBootstrapper, NancyBootstrapper>();
        }

        public static IContainer BuildContainer( /*StartupContext args*/)
        {
            var assemblies = new List<String> {
                "Triggers.Host",
                "Triggers.Common",
                //"Triggers.Core",
                "Triggers.API",
                "Triggers.SignalR",
            };

            // add plugin assemblies
            var curDir = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(curDir).Where(f => f.ToLower().EndsWith(".dll") && f.Contains("Triggers.Plugin."));
            assemblies.AddRange(files.Select(file => file.Replace(curDir, "").TrimStart('\\').Replace(".dll", "")));

            // todo:
            //if (OsInfo.IsWindows) {
            //    assemblies.Add("NzbDrone.Windows");
            //}

            //else {
            //    assemblies.Add("NzbDrone.Mono");
            //}

            return new MainAppContainerBuilder( /*args,*/ assemblies.ToArray()).Container;
        }
    }
}