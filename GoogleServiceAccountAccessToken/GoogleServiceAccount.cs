using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace GoogleServiceAccountAccessToken
{
    public class GoogleServiceAccount
    {
        public static Task<string> GetAccessTokenFromJSONKeyAsync(string keyFilePath, params string[] scopes)
        {
            using (var stream = new FileStream(keyFilePath, FileMode.Open, FileAccess.Read))
            {
                return GoogleCredential
                    .FromStream(stream)
                    .CreateScoped(scopes)
                    .UnderlyingCredential
                    .GetAccessTokenForRequestAsync();
            }
        }

        public static string GetAccessTokenFromJSONKey(string keyFilePath, params string[] scopes)
        {
            return GetAccessTokenFromJSONKeyAsync(keyFilePath, scopes).Result;
        }

        public static string GetAccessTokenFromP12Key(string keyFilePath)
        {

            string[] scopes = new string[] {  "https://www.googleapis.com/auth/firebase.database",
                     "https://www.googleapis.com/auth/userinfo.email" };

            var serviceAccountEmail = "c-sharpcorner-2d7ae@appspot.gserviceaccount.com";  // found https://console.developers.google.com

            //loading the Key file
            var certificate = new X509Certificate2("C-SharpCorner-acc457c856b1.json", "notasecret", X509KeyStorageFlags.Exportable);
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = scopes
            }.FromCertificate(certificate));

            var accessToken = credential.GetAccessTokenForRequestAsync().Result;



            return "";

        }
    }
}