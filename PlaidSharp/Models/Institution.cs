using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class Institution
    {
        public List<Credential> Credentials { get; set; }

        public bool HasMfa { get; set; }

        public string InstitutionId { get; set; }

        public List<string> Mfa { get; set; }

        public string Name { get; set; }

        public List<string> Products { get; set; }
    }
}
