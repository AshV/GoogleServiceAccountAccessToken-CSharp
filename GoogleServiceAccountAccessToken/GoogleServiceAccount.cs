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
        public static Task<string> GetAccessTokenFromJSONKeyAsync(string jsonKeyFilePath, params string[] scopes)
        {
            using (var stream = new FileStream(jsonKeyFilePath, FileMode.Open, FileAccess.Read))
            {
                return GoogleCredential
                    .FromStream(stream)
                    .CreateScoped(scopes)
                    .UnderlyingCredential
                    .GetAccessTokenForRequestAsync();
            }
        }

        public static string GetAccessTokenFromJSONKey(string jsonKeyFilePath, params string[] scopes)
        {
            return GetAccessTokenFromJSONKeyAsync(jsonKeyFilePath, scopes).Result;
        }

        public static Task<string> GetAccessTokenFromP12KeyAsync(string p12KeyFilePath, string serviceAccountEmail, string keyPassword, params string[] scopes)
        {
            return new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    Scopes = scopes
                }.FromCertificate(
                    new X509Certificate2(
                        p12KeyFilePath,
                        keyPassword,
                        X509KeyStorageFlags.Exportable))).GetAccessTokenForRequestAsync();
        }

        public static string GetAccessTokenFromP12Key(string p12KeyFilePath, string serviceAccountEmail, string keyPassword, params string[] scopes)
        {
            return GetAccessTokenFromP12KeyAsync(p12KeyFilePath, serviceAccountEmail, keyPassword, scopes).Result;
        }
    }
}