using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PlaidSharp.Tests
{
    public class PlaidClientTest
    {
        public PlaidClient SandboxClient;

        private readonly string AccessToken = "accessToken";

        public PlaidClientTest()
        {
            SandboxClient = new PlaidClient("clientId", "secret", "publicKey", Environments.Sandbox, PlaidConsts.ApiVersion);
        }

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
        public async Task Should_Get_Transactions()
        {
            // arrange
            var startDate = DateTime.Now.AddMonths(-2);
            var endDate = DateTime.Now;

            // act
            var trans = await SandboxClient.GetTransactions(AccessToken, startDate, endDate);

            // assert
            trans.Transactions.ShouldNotBeNull();
            trans.Transactions.Count.ShouldBeGreaterThan(0);
            trans.Accounts.ShouldNotBeNull();
            trans.Accounts.Count.ShouldBeGreaterThan(0);
            trans.RequestId.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task Should_Get_Balances()
        {
            // act
            var bals = await SandboxClient.GetBalances(AccessToken);

            // assert
            bals.Accounts.ShouldNotBeNull();
            bals.Accounts.Count.ShouldBeGreaterThan(0);
            bals.Accounts[0].Balances.ShouldNotBeNull();
            bals.Item.ShouldNotBeNull();
            bals.RequestId.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task Should_Get_Item()
        {
            // act
            var item = await SandboxClient.GetItem(AccessToken);

            // assert
            item.Item.ShouldNotBeNull();
            item.Item.ItemId.ShouldNotBeNullOrEmpty();
            item.RequestId.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public async Task Should_Get_All_Institutions()
        {
            // arrange
            var count = 5;
            var offset = 0;
            var products = new List<string> { "auth" };
            // act
            var ins = await SandboxClient.GetInstitutions(count, offset, products);

            // assert
            ins.Institutions.ShouldNotBeNull();
            ins.Institutions.Count.ShouldBeGreaterThan(0);
            ins.Institutions[0].Credentials.ShouldNotBeNull();
            ins.Institutions[0].HasMfa.ShouldNotBeNull();
            ins.Institutions[0].InstitutionId.ShouldNotBeNullOrEmpty();
            ins.Institutions[0].Name.ShouldNotBeNullOrEmpty();
            ins.Institutions[0].CountryCodes[0].ShouldNotBeNullOrEmpty();
            ins.RequestId.ShouldNotBeNullOrEmpty();
        }
    }
}
