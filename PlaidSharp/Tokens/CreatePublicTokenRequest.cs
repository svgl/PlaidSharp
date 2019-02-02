namespace PlaidSharp.Tokens
{
    public class CreatePublicTokenRequest : PlaidAuthorizedRequest
    {
        public CreatePublicTokenRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "item/public_token/create";
        }
    }
}
