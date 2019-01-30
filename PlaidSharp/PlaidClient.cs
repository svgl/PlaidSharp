using Newtonsoft.Json;
using PlaidSharp.Exceptions;
using PlaidSharp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaidSharp
{
    public class PlaidClient
    {
        public string ClientId { get; set; }

        public string Secret { get; set; }

        public string PublicKey { get; set; }

        public string Environment { get; set; }

        public string Version { get; set; }

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
        }

        public string ExchangePublicToken(string publicToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Auth> GetAuth(string accessToken)
        {
            var body = new BaseRequestBody(ClientId, Secret, accessToken);
            return await PostAsync<Auth>("auth/get", body.ToJson());
        }

        public async Task<Transactions> GetTransactions(string accessToken, DateTime startDate, DateTime endDate, List<string> accountsIds = null, int? count = null, int? offset = null)
        {
            var body = new TransactionRequestBody(ClientId, Secret, accessToken)
            {
                StartDate = startDate,
                EndDate = endDate,
                Options = new TransactionOptions
                {
                    AccountIds = accountsIds,
                    Count = count,
                    Offset = offset
                }
            };

            return await PostAsync<Transactions>("transactions/get", body.ToJson());
        }

        public async Task<PlaidBalances> GetBalances(string accessToken, List<string> accountIds = null)
        {
            var body = new BalanceRequestBody(ClientId, Secret, accessToken)
            {
                Options = new BalanceOptions
                {
                    AccountsIds = accountIds
                }
            };

            return await PostAsync<PlaidBalances>("accounts/balance/get", body.ToJson());
        }

        public async Task<PlaidItem> GetItem(string accessToken)
        {
            var body = new BaseRequestBody(ClientId, Secret, accessToken);

            return await PostAsync<PlaidItem>("item/get", body.ToJson());
        }

        public async Task<PlaidItem> UpdateWebhook(string accessToken, string webhook)
        {
            var body = new WebhookRequestBody(ClientId, Secret, accessToken)
            {
                Webhook = webhook
            };

            return await PostAsync<PlaidItem>("item/webhook/update", body.ToJson());
        }

        public async Task<AccessToken> RotateAccessToken(string accessToken)
        {
            var body = new BaseRequestBody(ClientId, Secret, accessToken);

            return await PostAsync<AccessToken>("item/access_token/invalidate", body.ToJson());
        }

        public async Task<RemovedItem> RemoveItem(string accessToken)
        {
            var body = new BaseRequestBody(ClientId, Secret, accessToken);

            return await PostAsync<RemovedItem>("item/remove", body.ToJson());
        }

        public async Task<PlaidInstitutions> SearchInstituions(string query, List<string> products)
        {
            var body = new InstitutionSearchRequestBody
            {
                PublicKey = PublicKey,
                Query = query,
                Products = products
            };

            return await PostAsync<PlaidInstitutions>("institutions/search", body.ToJson());
        }

        public async Task<PlaidInstitutions> GetInstitutions(int count, int offset, List<string> products = null)
        {
            var body = new AllInstitutionsRequestBody
            {
                ClientId = ClientId,
                Secret = Secret,
                Count = count,
                Offset = offset,
                Options = new AllInstitutionsOptions
                {
                    Products = products
                }
            };

            return await PostAsync<PlaidInstitutions>("institutions/get", body.ToJson());
        }

        private async Task<T> PostAsync<T>(string endpoint, string json) where T : new()
        {
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = content
            };
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Error>(await response.Content.ReadAsStringAsync());
                throw new PlaidException(error);
            }

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
