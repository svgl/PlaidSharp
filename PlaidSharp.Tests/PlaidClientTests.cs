using Shouldly;
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
