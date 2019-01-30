using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class Auth
    {
        public List<Account> Accounts { get; set; }

        public Numbers Numbers { get; set; }

        public Item Item { get; set; }

        public string RequestId { get; set; }
    }
}
