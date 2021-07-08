using System;
using System.Threading;
using Vexil;

namespace Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var featureFlagProvider = new Vexil.Plugins.Configuration.FeatureFlagProvider();
            var vexil = new VexilClient(featureFlagProvider);
            var flagName = "testFlag";

            Console.WriteLine("Press any key to exit.");
            Console.WriteLine($"Checking the status of flag: {flagName}");
            Timer timer = new Timer((object state) => { CheckFlag(vexil, flagName); }, "Some state", TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            Console.ReadLine();
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
