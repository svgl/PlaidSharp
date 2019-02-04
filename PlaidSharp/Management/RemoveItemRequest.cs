namespace PlaidSharp.Management
{
    public class RemoveItemRequest : PlaidAuthorizedRequest
    {
        public RemoveItemRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "item/remove";
        }
    }
}
