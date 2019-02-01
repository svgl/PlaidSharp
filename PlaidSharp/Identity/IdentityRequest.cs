namespace PlaidSharp.Identity
{
    public class IdentityRequest : PlaidAuthorizedRequest
    {
        public IdentityRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "identity/get";
        }
    }
}
