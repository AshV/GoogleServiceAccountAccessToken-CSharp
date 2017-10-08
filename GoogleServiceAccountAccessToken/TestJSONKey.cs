using System.Net.Http;
using static System.Console;

namespace GoogleServiceAccountAccessToken
{
    class TestJSONKey
    {
        public static void GetTokenAndCall()
        {
            var token = GoogleServiceAccount.GetAccessTokenFromJSONKey(
             "Keys/C-SharpCorner-0338f58d564f.json",
             "https://www.googleapis.com/auth/userinfo.profile");

            WriteLine(new HttpClient().GetStringAsync($"https://www.googleapis.com/plus/v1/people/110259743757395873050?access_token={token}").Result);
        }
    }
}