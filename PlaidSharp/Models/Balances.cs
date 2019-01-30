namespace PlaidSharp.Models
{
    public class Balances
    {
        public int? Available { get; set; }

        public int? Current { get; set; }

        public object Limit { get; set; }

        public string IsoCurrencyCode { get; set; }

        public object UnofficialCurrencyCode { get; set; }
    }
}
