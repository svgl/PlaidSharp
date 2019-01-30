using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class Transactions
    {
        public List<Account> Accounts { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> PlaidTransactions { get; set; }

        public Item Item { get; set; }

        public int TotalTransactions { get; set; }

        public string RequestId { get; set; }
    }
}
