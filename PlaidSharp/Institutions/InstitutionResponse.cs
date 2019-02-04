using PlaidSharp.Entities;
using System.Collections.Generic;

namespace PlaidSharp.Institutions
{
    public class InstitutionResponse : PlaidResponse
    {
        public List<Institution> Institutions { get; set; }
    }
}
