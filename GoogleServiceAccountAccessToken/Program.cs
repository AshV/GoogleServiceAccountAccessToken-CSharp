using Google.Apis.Auth.OAuth2;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace GoogleServiceAccountAccessToken
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  var token = GoogleServiceAccount.GetAccessTokenFromJSONKey(
                  "Keys/C-SharpCorner-0338f58d564f.json",
                  "https://www.googleapis.com/auth/userinfo.profile"); */

            var token = GoogleServiceAccount.GetAccessTokenFromP12Key(
                "Keys/C-SharpCorner-e0883ada1a3f.p12",
                "an-account@c-sharpcorner-2d7ae.iam.gserviceaccount.com",
                "notasecret",
                "https://www.googleapis.com/auth/userinfo.profile"
                );

            Console.WriteLine(token);
        }
    }
}