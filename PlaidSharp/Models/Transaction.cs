using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class Transaction
    {
        public string AccountId { get; set; }

        public double Amount { get; set; }

        public string IsoCurrencyCode { get; set; }

        public string UnofficialCurrencyCode { get; set; }

        public List<string> Category { get; set; }

        public string CategoryId { get; set; }

        public DateTime Date { get; set; }

        public Location Location { get; set; }

        public string Name { get; set; }

        public PaymentMeta PaymentMeta { get; set; }

        public bool Pending { get; set; }

        public string PendingTransactionId { get; set; }

        public string AccountOwner { get; set; }

        public string TransactionId { get; set; }

        public string TransactionType { get; set; }
    }
}
