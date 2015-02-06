namespace Triggers.Console
{
    using System;
    using System.Net.Sockets;
    using Triggers.Host;

    internal class Program
    {
        private static void Main()
        {
            try {
                //var startupArgs = new StartupContext(args);
                //NzbDroneLogger.Register(startupArgs, false, true);
                Bootstrap.Start( /*startupArgs, new ConsoleAlerts()*/);
            }
            catch (SocketException exception) {
                Console.WriteLine("");
                Console.WriteLine("");
                //Logger.Fatal(exception.Message + ". This can happen if another instance of NzbDrone is already running or another application is using the port assinged to NzbDrone (default: 8989)");
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
                Environment.Exit(1);
            }
            catch (Exception e) {
                Console.WriteLine("");
                Console.WriteLine("");
                //Logger.FatalException("EPIC FAIL!", e);
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
                Environment.Exit(1);
            }

            //Logger.Info("Exiting main.");

            Environment.Exit(0);
        }
    }
}