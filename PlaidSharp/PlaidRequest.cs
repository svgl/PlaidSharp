using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PlaidSharp
{
    public class PlaidRequest : IPlaidRequest
    {
        public string Endpoint { get; protected set; }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd",
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });
        }
    }
}
