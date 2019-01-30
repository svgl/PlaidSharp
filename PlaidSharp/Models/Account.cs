namespace PlaidSharp.Models
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
}
