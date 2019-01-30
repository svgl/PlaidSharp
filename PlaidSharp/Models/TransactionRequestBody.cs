using System;
using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class TransactionRequestBody : BaseRequestBody
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TransactionOptions Options { get; set; }

        public TransactionRequestBody()
        {

        }

        public TransactionRequestBody(string clientId, string secret, string accessToken) : base(clientId, secret, accessToken)
        {
        }
    }

    public class TransactionOptions
    {
        public List<string> AccountIds { get; set; }

        public int? Count { get; set; }

        public int? Offset { get; set; }
    }
}
