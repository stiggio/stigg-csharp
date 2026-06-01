using System.Threading.Tasks;
using Stigg.Client.Models.V1.Credits.Grants;

namespace Stigg.Client.Tests.Services.V1.Credits;

public class GrantServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var creditGrantResponse = await this.client.V1.Credits.Grants.Create(
            new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                DisplayName = "displayName",
                GrantType = GrantType.Paid,
            },
            TestContext.Current.CancellationToken
        );
        creditGrantResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Credits.Grants.List(
            new() { CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Void_Works()
    {
        var creditGrantResponse = await this.client.V1.Credits.Grants.Void(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        creditGrantResponse.Validate();
    }
}
