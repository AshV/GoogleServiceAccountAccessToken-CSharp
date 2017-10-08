using System.Net.Http;
using static System.Console;

namespace GoogleServiceAccountAccessToken
{
    class TestP12Key
    {
        public static void GetTokenAndCall()
        {
            var token = GoogleServiceAccount.GetAccessTokenFromP12Key(
                "Keys/C-SharpCorner-e0883ada1a3f.p12",
                "an-account@c-sharpcorner-2d7ae.iam.gserviceaccount.com",
                "notasecret",
                "https://www.googleapis.com/auth/userinfo.profile"
                );

            WriteLine(new HttpClient().GetStringAsync($"https://www.googleapis.com/plus/v1/people/110259743757395873050?access_token={token}").Result);
        }
    }
}