﻿using PlaidSharp.Entities;
using System.Collections.Generic;

namespace PlaidSharp.Auth
{
    public class AuthResponse : PlaidResponse
    {
        public List<Account> Accounts { get; set; }

        public AccountNumbers Numbers { get; set; }

        public Item Item { get; set; }

        public struct AccountNumbers
        {
            public List<Ach> ACH { get; set; }

            public List<Eft> EFT { get; set; }

            public struct Ach
            {
                public string Account { get; set; }

                public string AccountId { get; set; }

                public string Routing { get; set; }

                public string WireRouting { get; set; }
            }

            public struct Eft
            {
                public string Account { get; set; }

                public string AccountId { get; set; }

                public string Institution { get; set; }

                public string Branch { get; set; }
            }
        }
    }
}
