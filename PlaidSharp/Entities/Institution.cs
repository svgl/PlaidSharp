using System.Collections.Generic;

namespace PlaidSharp.Entities
{
    public class Institution
    {
        public List<InstitutionCredentials> Credentials { get; set; }

        public bool HasMfa { get; set; }

        public string InstitutionId { get; set; }

        public List<string> Mfa { get; set; }

        public string Name { get; set; }

        public List<string> Products { get; set; }

        public struct InstitutionCredentials
        {
            public string Label { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }
        }
    }
}
