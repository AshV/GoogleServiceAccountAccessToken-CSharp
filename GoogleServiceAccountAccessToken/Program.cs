namespace GoogleServiceAccountAccessToken
{
    class Program
    {
        // Generate your own keys before running 
        static void Main(string[] args)
        {
            // Testing with JSON key
            TestJSONKey.GetTokenAndCall();

            // Testing with P12 key
            TestP12Key.GetTokenAndCall();
        }
    }
}