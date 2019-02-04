using Newtonsoft.Json;

namespace PlaidSharp
{
    public interface IPlaidRequest
    {
        [JsonIgnore]
        string Endpoint { get; }

        string ToJson();
    }
}
