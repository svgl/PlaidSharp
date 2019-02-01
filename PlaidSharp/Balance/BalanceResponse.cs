using PlaidSharp.Entities;
using System.Collections.Generic;

namespace PlaidSharp.Balance
{
    public class BalanceResponse : PlaidResponse
    {
        public List<Account> Accounts { get; set; }

        public Item Item { get; set; }
    }
}
