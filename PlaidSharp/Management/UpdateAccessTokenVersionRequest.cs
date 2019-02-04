namespace PlaidSharp.Management
{
    public class UpdateAccessTokenVersionRequest : PlaidRequest, IHasClientId, IHasSecret
    {
        public string ClientId { get; set; }

        public string Secret { get; set; }

        public string AccessTokenV1 { get; set; }

        public UpdateAccessTokenVersionRequest()
        {
            Endpoint = "item/access_token/update_version";
        }
    }
}
