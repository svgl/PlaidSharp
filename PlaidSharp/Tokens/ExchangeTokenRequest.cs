namespace PlaidSharp.Tokens
{
    public class ExchangeTokenRequest : PlaidRequest, IHasClientId, IHasSecret
    {
        public string ClientId { get; set; }

        public string Secret { get; set; }

        public string PublicToken { get; set; }

        public ExchangeTokenRequest()
        {
            Endpoint = "item/public_token/exchange";
        }
    }
}
