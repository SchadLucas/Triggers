namespace Triggers.Console
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;
    using Microsoft.Owin.Hosting.Tracing;
    using NLog;
    using Triggers.Host;

    public class NlogTextWriter : TextWriter
    {
        public NlogTextWriter(Logger logger)
        {
            _logger = logger;
        }

        private readonly Logger _logger;

        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }

        public override void Write(char[] buffer, int index, int count)
        {
            Write(buffer);
        }

        public override void Write(char[] buffer)
        {
            Write(new string(buffer));
        }

        public override void Write(string value)
        {
            if (value.ToLower().Contains("error") && !(value.ToLower().Contains("sqlite") || value.ToLower().Contains("\"errors\":null"))) {
                _logger.Error(value);
            }
            else {
                _logger.Trace(value);
            }
        }

        public override void Write(char value)
        {
            _logger.Trace(value);
        }
    }

    public class OwinTraceOutputFactory : ITraceOutputFactory
    {
        private readonly Logger _logger = LogManager.GetLogger("Owin");

        public TextWriter Create(string outputFile)
        {
            return new NlogTextWriter(_logger);
        }
    }

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