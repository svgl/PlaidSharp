namespace PlaidSharp.Entities
{
    public class Account
    {
        public string AccountId { get; set; }

        public Balances Balances { get; set; }

        public string Mask { get; set; }

        public string Name { get; set; }

        public string OfficialName { get; set; }

        public string Subtype { get; set; }

        public string Type { get; set; }
    }

    public class Balances
    {
        public double? Available { get; set; }

        public double? Current { get; set; }

        public object Limit { get; set; }

        public string IsoCurrencyCode { get; set; }

        public object UnofficialCurrencyCode { get; set; }
    }
}
