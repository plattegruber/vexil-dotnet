using System.Security.Cryptography.X509Certificates;

namespace Vexil.Plugins.GoogleSheets
{
    public static class VexilBuilderExtension
    {
        public static VexilBuilder UseGoogleSheets(this VexilBuilder vexilBuilder, string sheetId, string sheetName, string serviceAccountEmail, X509Certificate2 certificate)
        {
            vexilBuilder.ConfiguredFeatureFlagProvider = new FeatureFlagProvider(sheetId, sheetName, serviceAccountEmail, certificate);
            return vexilBuilder;
        }
    }
}
