using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class PlaidInstitutions
    {
        public List<Institution> Institutions { get; set; }

        public int Total { get; set; }

        public string RequestId { get; set; }
    }
}
