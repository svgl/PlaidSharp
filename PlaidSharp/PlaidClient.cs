using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PlaidSharp.Entities;
using PlaidSharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaidSharp
{
    public class PlaidClient
    {
        private string ClientId { get; set; }

        private string Secret { get; set; }

        private string PublicKey { get; set; }

        public string Environment { get; private set; }

        public string Version { get; private set; }

        private readonly HttpClient client;

        public PlaidClient(string clientId, string secret, string publicKey, string environment, string version)
        {
            ClientId = clientId;
            Secret = secret;
            PublicKey = publicKey;
            Environment = environment;
            Version = version;

            client = new HttpClient
            {
                BaseAddress = new Uri(environment)
            };

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Plaid-Version", Version);

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
        }

        public string ExchangePublicToken(string publicToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Auth.AuthResponse> GetAuth(string accessToken)
        {
            var request = new Auth.AuthRequest(accessToken);
            return await PostAsync<Auth.AuthResponse>(request);
        }

        public async Task<Transactions.TransactionResponse> GetTransactions(string accessToken, DateTime startDate, DateTime endDate, List<string> accountsIds = null, int? count = null, int? offset = null)
        {
            var request = new Transactions.TransactionRequest(accessToken)
            {
                StartDate = startDate,
                EndDate = endDate,
                Options = new Transactions.TransactionRequest.TransactionOptions
                {
                    AccountIds = accountsIds,
                    Count = count,
                    Offset = offset
                }
            };

            return await PostAsync<Transactions.TransactionResponse>(request);
        }

        public async Task<Balance.BalanceResponse> GetBalances(string accessToken, List<string> accountIds = null)
        {
            var request = new Balance.BalanceRequest(accessToken)
            {
                Options = new Balance.BalanceRequest.BalanceOptions
                {
                    AccountIds = accountIds
                }
            };

            return await PostAsync<Balance.BalanceResponse>(request);
        }

        public async Task<Management.ItemResponse> GetItem(string accessToken)
        {
            var request = new Management.ItemRequest(accessToken);

            return await PostAsync<Management.ItemResponse>(request);
        }

        public async Task<Management.ItemResponse> UpdateWebhook(string accessToken, string webhook)
        {
            var request = new Management.WebhookUpdateRequest(accessToken)
            {
                Webhook = webhook
            };

            return await PostAsync<Management.ItemResponse>(request);
        }

        public async Task<Management.InvalidateAccessTokenResponse> RotateAccessToken(string accessToken)
        {
            var request = new Management.InvalidateAccessTokenRequest(accessToken);

            return await PostAsync<Management.InvalidateAccessTokenResponse>(request);
        }

        public async Task<Management.RemoveItemResponse> RemoveItem(string accessToken)
        {
            var request = new Management.RemoveItemRequest(accessToken);

            return await PostAsync<Management.RemoveItemResponse>(request);
        }

        public async Task<Institutions.InstitutionResponse> SearchInstituions(string query, List<string> products)
        {
            var request = new Institutions.InstitutionSearchRequest()
            {
                PublicKey = PublicKey,
                Query = query,
                Products = products
            };

            return await PostAsync<Institutions.InstitutionResponse>(request);
        }

        public async Task<Institutions.AllInstitutionsResponse> GetInstitutions(int count, int offset, List<string> products = null)
        {
            var request = new Institutions.AllInstitutionsRequest
            {
                ClientId = ClientId,
                Secret = Secret,
                Count = count,
                Offset = offset,
                Options = new Institutions.AllInstitutionsRequest.InstitutionsOptions
                {
                    Products = products
                }
            };

            return await PostAsync<Institutions.AllInstitutionsResponse>(request);
        }

        public async Task<TResponse> PostAsync<TResponse>(IPlaidRequest request) where TResponse : IPlaidResponse
        {
            AddCredentials(request);
#if DEBUG
            System.Diagnostics.Debug.WriteLine(request.ToJson());
#endif
            var content = new StringContent(request.ToJson(), System.Text.Encoding.UTF8, "application/json");

            var req = new HttpRequestMessage(HttpMethod.Post, request.Endpoint)
            {
                Content = content
            };
            var response = await client.SendAsync(req);

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
#if DEBUG
                System.Diagnostics.Debug.WriteLine(responseContent);
#endif
                var error = JsonConvert.DeserializeObject<Error.ErrorResponse>(responseContent);
                throw new PlaidException(error);
            }

            return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
        }

        private void AddCredentials(IPlaidRequest request)
        {
            if (request is PlaidAuthorizedRequest req)
            {
                if (string.IsNullOrEmpty(req.ClientId))
                    req.ClientId = ClientId;
                if (string.IsNullOrEmpty(req.Secret))
                    req.Secret = Secret;
            }
        }
    }
}
