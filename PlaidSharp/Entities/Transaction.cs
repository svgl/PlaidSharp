using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PlaidSharp.Entities
{
    public class Transaction
    {
        public string AccountId { get; set; }

        public decimal Amount { get; set; }

        public string IsoCurrencyCode { get; set; }

        public string UnofficialCurrencyCode { get; set; }

        public List<string> Category { get; set; }

        public string CategoryId { get; set; }

        public DateTime Date { get; set; }

        public TransactionLocation Location { get; set; }

        public string Name { get; set; }

        public TransactionPaymentMeta PaymentMeta { get; set; }

        public bool Pending { get; set; }

        public string PendingTransactionId { get; set; }

        public string AccountOwner { get; set; }

        public string TransactionId { get; set; }

        public string TransactionType { get; set; }

        public struct TransactionLocation
        {
            public string Address { get; set; }

            public string City { get; set; }

            public string Region { get; set; }

            public string PostalCode { get; set; }
            
            public string Country { get; set; }

            [JsonProperty("lat")]
            public double? Latitude { get; set; }

            [JsonProperty("lon")]
            public double? Longitude { get; set; }
        }

        public struct TransactionPaymentMeta
        {
            public string ReferenceNumber { get; set; }

            public string PpdId { get; set; }

            public string PayeeName { get; set; }
        }
    }
}
