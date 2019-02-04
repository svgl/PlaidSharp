using PlaidSharp.Entities;
using System.Collections.Generic;

namespace PlaidSharp.Transactions
{
    public class TransactionResponse : PlaidResponse
    {
        public List<Account> Accounts { get; set; }

        public List<Transaction> Transactions { get; set; }

        public Item Item { get; set; }

        public int TotalTransactions { get; set; }
    }
}
