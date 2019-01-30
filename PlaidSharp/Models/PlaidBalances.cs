using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class PlaidBalances
    {
        public List<Account> Accounts { get; set; }

        public Item Item { get; set; }

        public string RequestId { get; set; }
    }
}
