namespace PlaidSharp.Tokens
{
    public class ExchangeTokenResponse : PlaidResponse
    {
        public string AccessToken { get; set; }

        public string ItemId { get; set; }
    }
}
