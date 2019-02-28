namespace PlaidSharp.Demo.Plaid
{
    public interface IPlaidService
    {
        PlaidClient PlaidClient { get; }

        string AccessToken { get; set; }
    }
}
