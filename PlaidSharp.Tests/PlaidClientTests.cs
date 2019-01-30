using System;
using System.Collections.Generic;
using Xunit;

namespace PlaidSharp.Tests
{
    public class PlaidClientTest
    {
        public PlaidClient SandboxClient = new PlaidClient("clientId", "secret", "publicKey", Environments.Sandbox, "2018-05-22");

        private readonly string AccessToken = "accessToken";

        [Fact]
        public void Should_Get_Auth()
        {
            // act
            var auth = SandboxClient.GetAuth(AccessToken).Result;

            // assert
            Assert.True(5 == auth.Accounts.Count);
        }

        [Fact]
        public void Should_Get_Transactions()
        {
            // arrange
            var startDate = DateTime.Now.AddMonths(-2);
            var endDate = DateTime.Now;

            // act
            var trans = SandboxClient.GetTransactions(AccessToken, startDate, endDate).Result;

            // assert
            Assert.True(trans.PlaidTransactions.Count > 0);
        }

        [Fact]
        public void Should_Get_Balances()
        {
            // act
            var bals = SandboxClient.GetBalances(AccessToken).Result;

            // assert
            Assert.True(bals.Accounts.Count > 0);
        }

        [Fact]
        public void Should_Get_Item()
        {
            // act
            var item = SandboxClient.GetItem(AccessToken).Result;

            // assert
            Assert.NotNull(item.Item);
        }

        [Fact]
        public void Should_Get_All_Institutions()
        {
            // arrange
            int count = 5;
            int offset = 0;
            var products = new List<string> { "auth" };
            // act
            var ins = SandboxClient.GetInstitutions(count, offset, products).Result;

            // assert
            Assert.True(ins.Institutions.Count == 5);
        }
    }
}
