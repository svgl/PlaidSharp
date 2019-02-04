using System.Collections.Generic;

namespace PlaidSharp.Auth
{
    public class AuthRequest : PlaidAuthorizedRequest
    {
        public AuthOptions Options { get; set; }

        public AuthRequest(string accessToken) : base(accessToken)
        {
            Endpoint = "auth/get";
        }

        public struct AuthOptions
        {
            public List<string> AccountIds { get; set; }
        }
    }
}
