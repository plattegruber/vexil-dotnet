using System;
using Vexil;

namespace Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var googleSheetId = "1o_ggR0lW2n8OkT2_hK4lzv9BquRk1RcoZ6JLR_SmAP4";
            var googleSheetName = "Feature Flags";
            var featureFlagProvider = new Vexil.GoogleSheets.FeatureFlagProvider(googleSheetId, googleSheetName);
            var vexil = new VexilClient(featureFlagProvider);
            if (vexil.IsEnabled("myFlag"))
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
