using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Vexil;

namespace Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var featureFlagProvider = GetGoogleSheetsFeatureFlagProvider();
            //var featureFlagProvider = GetConfigurationFeatureFlagProvider();
            var featureFlagProvider = GetUnleashFeatureFlagProvider();
            var vexil = new VexilClient(featureFlagProvider);
            var flagName = "testFlag";

            Console.WriteLine("Press any key to exit.");
            Console.WriteLine($"Checking the status of flag: {flagName}");
            Timer timer = new Timer((object state) => { CheckFlag(vexil, flagName); }, "Some state", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            Console.ReadLine();
        }

        private static IFeatureFlagProvider GetGoogleSheetsFeatureFlagProvider()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .Build();
            var serviceAccountEmail = configuration["Vexil:Plugins:GoogleSheets:ServiceAccountEmail"].ToString();
            var certificate = new X509Certificate2("c:\\auth.p12", "notasecret", X509KeyStorageFlags.Exportable);
            var sheetId = configuration["Vexil:Plugins:GoogleSheets:SheetId"].ToString();
            var sheetName = configuration["Vexil:Plugins:GoogleSheets:SheetName"].ToString();

            return new Vexil.Plugins.GoogleSheets.FeatureFlagProvider(sheetId, sheetName, serviceAccountEmail, certificate);
        }

        private static IFeatureFlagProvider GetConfigurationFeatureFlagProvider()
        {
            return new Vexil.Plugins.Configuration.FeatureFlagProvider();
        }
        private static IFeatureFlagProvider GetUnleashFeatureFlagProvider()
        {
            return new Vexil.Plugins.Unleash.UnleashFeatureFlagProvider(new FeatureFlagStore(), new FeatureFlagService());
        }

        private static void CheckFlag(VexilClient vexil, string flagName)
        {
            if (vexil.IsEnabled(flagName))
            {
                Console.WriteLine("Enabled!");
            }
            else
            {
                Console.WriteLine("Disabled...");
            }
        }
    }
}
