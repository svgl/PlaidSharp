using System.Collections.Generic;

namespace PlaidSharp.Entities
{
    public class Item
    {
        public List<string> AvailableProducts { get; set; }

        public List<string> BilledProducts { get; set; }

        public Error.ErrorResponse Error { get; set; }

        public string InstitutionId { get; set; }

        public string ItemId { get; set; }

        public string Webhook { get; set; }
    }
}
