using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Vexil;
using Vexil.Plugins.Configuration;
using Vexil.Plugins.Configuration.Configurations;

namespace Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var featureFlagProvider = GetGoogleSheetsFeatureFlagProvider();
            //var featureFlagProvider = GetUnleashFeatureFlagProvider();
            var vexil = new VexilBuilder()
                //.UseFeatureFlagProvider(featureFlagProvider)
                .UseConfigurationProvider(GetVexilContext(), GetConfiguration())
                .Build();
            var flagName = "testFlag";

            Console.WriteLine("Press any key to exit.");
            Console.WriteLine($"Checking the status of flag: {flagName}");
            Timer timer = new Timer((object state) => { CheckFlag(vexil, flagName); }, "Some state", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            Console.ReadLine();
        }

        //private static IFeatureFlagProvider GetGoogleSheetsFeatureFlagProvider()
        //{
        //    var configuration = GetConfiguration()
        //    var serviceAccountEmail = configuration["Vexil:Plugins:GoogleSheets:ServiceAccountEmail"].ToString();
        //    var certificate = new X509Certificate2("c:\\auth.p12", "notasecret", X509KeyStorageFlags.Exportable);
        //    var sheetId = configuration["Vexil:Plugins:GoogleSheets:SheetId"].ToString();
        //    var sheetName = configuration["Vexil:Plugins:GoogleSheets:SheetName"].ToString();

        //    return new Vexil.Plugins.GoogleSheets.FeatureFlagProvider(sheetId, sheetName, serviceAccountEmail, certificate);
        //}

        //private static IFeatureFlagProvider GetUnleashFeatureFlagProvider()
        //{
        //    return new Vexil.Plugins.Unleash.UnleashFeatureFlagProvider(new FeatureFlagStore(), new FeatureFlagService(), GetVexilContext());
        //}

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

        private static IVexilContext GetVexilContext()
            => new VexilContext() { UserId = new Vexil.Aggregate.UserId("123") };

        private static IOptionsSnapshot<IEnumerable<FeatureFlagConfiguration>> GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .Build();
            IEnumerable<FeatureFlagConfiguration> featureFlagConfigurations = new List<FeatureFlagConfiguration>();
            configuration.GetSection("vexil:featureFlags").Bind(featureFlagConfigurations);
            return (IOptionsSnapshot<IEnumerable<FeatureFlagConfiguration>>)Options.Create(featureFlagConfigurations);
        }
    }
}
