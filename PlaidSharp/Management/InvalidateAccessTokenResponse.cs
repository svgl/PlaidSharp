namespace PlaidSharp.Management
{
    public class InvalidateAccessTokenResponse : PlaidResponse
    {
        public string NewAccessToken { get; set; }
    }
}
