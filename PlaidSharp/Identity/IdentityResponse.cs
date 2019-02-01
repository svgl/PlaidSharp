using PlaidSharp.Entities;
using System.Collections.Generic;

namespace PlaidSharp.Identity
{
    public class IdentityResponse : PlaidResponse
    {
        public List<Account> Accounts { get; set; }

        // identity

        public Item Item { get; set; }
    }
}
