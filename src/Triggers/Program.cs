namespace Triggers
{
    using System;
    using Microsoft.Owin.Hosting;
    using Triggers.Host;

    internal class Program
    {
        private static readonly string serviceName = "TriggersTest";

        private static void Main()
        {
            var url = "http://+:8080";

            using (var app = WebApp.Start<OwinStartup>(url))
            {
                Console.ReadKey();
            }
        }
    }
}