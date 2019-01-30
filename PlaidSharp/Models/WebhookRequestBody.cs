namespace PlaidSharp.Models
{
    public class WebhookRequestBody : BaseRequestBody
    {
        public string Webhook { get; set; }

        public WebhookRequestBody(string clientId, string secret, string accessToken) : base(clientId, secret, accessToken)
        {
        }
    }
}
