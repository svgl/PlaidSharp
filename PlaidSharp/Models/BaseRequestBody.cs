using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PlaidSharp.Models
{
    public class BaseRequestBody : IRequestBody
    {
        public string ClientId { get; set; }

        public string Secret { get; set; }

        public string AccessToken { get; set; }

        public BaseRequestBody()
        {

        }

        public BaseRequestBody(string clientId, string secret, string accessToken)
        {
            ClientId = clientId;
            Secret = secret;
            AccessToken = accessToken;
        }

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
