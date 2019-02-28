using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PlaidSharp.Tests
{
    public class PlaidClientTest
    {
        public PlaidClient SandboxClient = new PlaidClient("5ac64a68bdc6a40eb40caf75", "d0d1c449f7f3490e9c7fd03738f104", "231f407f65b7a0f6dbadaa200f5732", Environments.Sandbox, "2018-05-22");

        private readonly string AccessToken = "access-sandbox-bb5e8663-c0d2-4d29-8995-79fd8613a2b1";

        [Fact]
        public async Task Should_Get_Auth()
        {
            // act
            var auth = await SandboxClient.GetAuth(AccessToken);

            // assert
            auth.Accounts.ShouldNotBeNull();
            auth.Accounts.Count.ShouldBeGreaterThan(0);
            auth.Item.ShouldNotBeNull();
            auth.Numbers.ShouldNotBeNull();
            auth.RequestId.ShouldNotBeNullOrEmpty();
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
            trans.Transactions.ShouldNotBeNull();
            trans.Transactions.Count.ShouldBeGreaterThan(0);
            trans.Accounts.ShouldNotBeNull();
            trans.Accounts.Count.ShouldBeGreaterThan(0);
            trans.RequestId.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void Should_Get_Balances()
        {
            // act
            var bals = SandboxClient.GetBalances(AccessToken).Result;

            // assert
            bals.Accounts.ShouldNotBeNull();
            bals.Accounts.Count.ShouldBeGreaterThan(0);
            bals.Accounts[0].Balances.ShouldNotBeNull();
            bals.Item.ShouldNotBeNull();
            bals.RequestId.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void Should_Get_Item()
        {
            // act
            var item = SandboxClient.GetItem(AccessToken).Result;

            // assert
            item.Item.ShouldNotBeNull();
            item.Item.ItemId.ShouldNotBeNullOrEmpty();
            item.RequestId.ShouldNotBeNullOrEmpty();
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
            ins.Institutions.ShouldNotBeNull();
            ins.Institutions.Count.ShouldBeGreaterThan(0);
            ins.Institutions[0].Credentials.ShouldNotBeNull();
            ins.Institutions[0].HasMfa.ShouldNotBeNull();
            ins.Institutions[0].InstitutionId.ShouldNotBeNullOrEmpty();
            ins.Institutions[0].Name.ShouldNotBeNullOrEmpty();
            ins.RequestId.ShouldNotBeNullOrEmpty();
        }
    }
}
