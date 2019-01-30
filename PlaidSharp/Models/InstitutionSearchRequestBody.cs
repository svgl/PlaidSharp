using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlaidSharp.Models
{
    public class InstitutionSearchRequestBody : BaseRequestBody
    {
        public string Query { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public List<string> Products { get; set; }

        public string PublicKey { get; set; }

        public InstitutionSearchRequestBody()
        {
        }
    }
}
