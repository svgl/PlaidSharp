namespace PlaidSharp.Management
{
    public class ItemRequest : PlaidAuthorizedRequest
    {
        public ItemRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "item/get";
        }
    }
}
