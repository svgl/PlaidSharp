namespace PlaidSharp.Management
{
    /// <summary>
    /// Response with an Item
    /// </summary>
    /// <remarks>
    /// Use <see cref="ItemResponse"/> as response.
    /// </remarks>
    public class WebhookUpdateRequest : PlaidAuthorizedRequest
    {
        public string Webhook { get; set; }

        public WebhookUpdateRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "item/webhook/update";
        }
    }
}
