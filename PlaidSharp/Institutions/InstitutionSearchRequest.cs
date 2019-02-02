using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlaidSharp.Institutions
{
    /// <summary>
    /// Use <see cref="InstitutionResponse"/> as response.
    /// </summary>
    public class InstitutionSearchRequest : PlaidRequest, IHasPublicKey
    {
        public string Query { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public List<string> Products { get; set; }

        public string PublicKey { get; set; }

        public SearchOptions Options { get; set; }

        public InstitutionSearchRequest()
        {
            Endpoint = "institutions/search";
        }

        public struct SearchOptions
        {

        }
    }
}
