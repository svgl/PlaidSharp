using System.Collections.Generic;

namespace PlaidSharp.Institutions
{
    public class AllInstitutionsRequest : PlaidRequest, IHasClientId, IHasSecret
    {
        public string ClientId { get; set; }

        public string Secret { get; set; }

        public int Count { get; set; }

        public int Offset { get; set; }

        public InstitutionsOptions Options { get; set; }

        public AllInstitutionsRequest()
        {
            Endpoint = "institutions/get";
        }

        public struct InstitutionsOptions
        {
            public List<string> Products { get; set; }
        }
    }
}
