using System.Collections.Generic;

namespace PlaidSharp.Balance
{
    public class BalanceRequest : PlaidAuthorizedRequest
    {
        public BalanceOptions Options { get; set; }

        public BalanceRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "accounts/balance/get";
        }

        public struct BalanceOptions
        {
            public List<string> AccountIds { get; set; }
        }
    }
}
