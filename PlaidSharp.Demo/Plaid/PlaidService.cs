using Microsoft.Extensions.Configuration;

namespace PlaidSharp.Demo.Plaid
{
    public class PlaidService : IPlaidService
    {
        public PlaidClient PlaidClient { get; private set; }

        public string AccessToken { get; set; }

        public PlaidService(IConfiguration configuration)
        {
            PlaidClient = new PlaidClient(configuration["Plaid:ClientId"], configuration["Plaid:Secret"], configuration["Plaid:PublicKey"], Environments.Sandbox, "2018-05-22");
        }
    }
}
