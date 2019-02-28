namespace PlaidSharp.Demo.Models
{
    public class PlaidIndexViewModel
    {
        public string PlaidPublicKey { get; set; }

        public string PlaidEnv { get; set; }

        /// <summary>
        /// Comma seperated list of products
        /// </summary>
        public string PlaidProducts { get; set; }
    }
}
