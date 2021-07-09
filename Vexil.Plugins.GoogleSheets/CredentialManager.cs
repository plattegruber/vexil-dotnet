using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using System.Security.Cryptography.X509Certificates;

namespace Vexil.Plugins.GoogleSheets
{
    public static class CredentialManager
    {
        private static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };

        public static ServiceAccountCredential Generate(string serviceAccountEmail, X509Certificate2 certificate)
        {

            //var certificate = new X509Certificate2(@"auth.p12", "notasecret", X509KeyStorageFlags.Exportable);

            return new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = Scopes
               }.FromCertificate(certificate));
        }
    }
}
