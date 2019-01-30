using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class AllInstitutionsRequestBody : BaseRequestBody
    {
        public int Offset { get; set; }

        public int Count { get; set; }

        public AllInstitutionsOptions Options { get; set; }

        public AllInstitutionsRequestBody()
        {
        }
    }

    public class AllInstitutionsOptions
    {
        public List<string> Products { get; set; }
    }
}
