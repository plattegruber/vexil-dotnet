using System.Security.Cryptography.X509Certificates;

namespace Vexil.Plugins.GoogleSheets
{
    public class FeatureFlagProvider : AdHocFeatureFlagProvider
    {
        private static string _spreadsheetId;
        private static string _sheetName;
        private static string _serviceAccountEmail;
        private static X509Certificate2 _certificate;

        public FeatureFlagProvider(
            string spreadsheetId,
            string sheetName,
            string serviceAccountEmail,
            X509Certificate2 certificate)
        {
            _spreadsheetId = spreadsheetId;
            _sheetName = sheetName;
            _serviceAccountEmail = serviceAccountEmail;
            _certificate = certificate;
        }

        public override bool IsEnabled(string featureFlag)
        {
            var credential = CredentialManager.Generate(_serviceAccountEmail, _certificate);
            var values = new SheetReader().ReadAllValues(credential, _spreadsheetId, $"{_sheetName}!A2:B");
            if (values != null)
            {
                foreach (var row in values)
                {
                    if (row[0].ToString().Equals(featureFlag))
                    {
                        if (bool.TryParse(row[1].ToString(), out bool flagValue))
                            return flagValue;
                        break;
                    }
                }
            }
            return false;
        }
    }
}
