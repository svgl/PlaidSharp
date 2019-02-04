namespace PlaidSharp.Income
{
    public class IncomeRequest : PlaidAuthorizedRequest
    {
        public IncomeRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "income/get";
        }
    }
}
