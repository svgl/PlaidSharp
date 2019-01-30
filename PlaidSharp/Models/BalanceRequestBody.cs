using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class BalanceRequestBody : BaseRequestBody
    {
        public BalanceOptions Options { get; set; }

        public BalanceRequestBody(string clientId, string secret, string accessToken) : base(clientId, secret, accessToken)
        {
        }
    }

    public class BalanceOptions
    {
        public List<string> AccountsIds { get; set; }
    }
}
