namespace PlaidSharp.Management
{
    public class InvalidateAccessTokenRequest : PlaidAuthorizedRequest
    {
        public InvalidateAccessTokenRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "item/access_token/invalidate";
        }
    }
}
