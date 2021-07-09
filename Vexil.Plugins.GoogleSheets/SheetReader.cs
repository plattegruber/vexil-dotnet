using System.Collections.Generic;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;

namespace Vexil.Plugins.GoogleSheets
{
    public class SheetReader
    {
        private readonly string ApplicationName = "vexil";

        public IList<IList<object>> ReadAllValues(ICredential credential, string spreadsheetId, string range)
        {
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service.Spreadsheets.Values
                .Get(spreadsheetId, range)
                .Execute()
                .Values;
        }
    }
}
