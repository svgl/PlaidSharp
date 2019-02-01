namespace PlaidSharp
{
    public class PlaidAuthorizedRequest : PlaidRequest
    {
        public string ClientId { get; set; }

        public string Secret { get; set; }

        public string AccessToken { get; set; }

        public PlaidAuthorizedRequest(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
