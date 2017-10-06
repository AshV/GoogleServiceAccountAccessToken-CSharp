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
            var token = GoogleServiceAccount.GetAccessTokenFromJSONKey("", "https://www.googleapis.com/auth/firebase.database", "https://www.googleapis.com/auth/userinfo.email");
        }
    }
}