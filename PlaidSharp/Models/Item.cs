using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class Item
    {
        public List<string> AvailableProducts { get; set; }

        public List<string> BilledProducts { get; set; }

        public Error Error { get; set; }

        public string InstitutionId { get; set; }

        public string ItemId { get; set; }

        public string Webhook { get; set; }
    }
}
