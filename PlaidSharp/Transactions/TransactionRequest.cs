using System;
using System.Collections.Generic;

namespace PlaidSharp.Transactions
{
    public class TransactionRequest : PlaidAuthorizedRequest
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TransactionOptions Options { get; set; }

        public TransactionRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "transactions/get";
        }

        public struct TransactionOptions
        {
            public List<string> AccountIds { get; set; }

            public int? Count { get; set; }

            public int? Offset { get; set; }
        }
    }
}
