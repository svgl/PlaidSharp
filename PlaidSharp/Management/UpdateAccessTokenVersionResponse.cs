namespace PlaidSharp.Management
{
    public class UpdateAccessTokenVersionResponse : PlaidResponse
    {
        public string AccessToken { get; set; }

        public string ItemId { get; set; }
    }
}
