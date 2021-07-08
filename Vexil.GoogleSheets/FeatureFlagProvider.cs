using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace Vexil.Plugins.GoogleSheets
{
    public class FeatureFlagProvider : IFeatureFlagProvider
    {
        private static string _spreadsheetId;
        private static string _sheetName;
        private static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private static readonly string ApplicationName = "vexil";

        public FeatureFlagProvider(
            string spreadsheetId,
            string sheetName)
        {
            _spreadsheetId = spreadsheetId;
            _sheetName = sheetName;
        }

        public bool IsEnabled(string featureFlag)
        {
            UserCredential credential;

            using (var stream = new FileStream("user.json", FileMode.Open, FileAccess.Read))
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore("credentials.json", true)).Result;

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            var range = $"{_sheetName}!A2:B";
            var values = service.Spreadsheets.Values
                .Get(_spreadsheetId, range)
                .Execute()
                .Values;
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
