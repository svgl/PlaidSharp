namespace PlaidSharp.Institutions
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Use <see cref="InstitutionResponse"/> for the reponse
    /// </remarks>
    public class InstitutionByIdRequest : PlaidRequest
    {
        public string InstitutionId { get; set; }

        public string PublicKey { get; set; }

        public InstitutionOptions Options { get; set; }

        public InstitutionByIdRequest()
        {
            Endpoint = "institutions/get_by_id";
        }

        public struct InstitutionOptions
        {

        }
    }
}
