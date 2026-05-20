using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events;

public class CreditServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetAutoRecharge_Works()
    {
        var response = await this.client.V1.Events.Credits.GetAutoRecharge(
            new() { CurrencyID = "currencyId", CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetUsage_Works()
    {
        var response = await this.client.V1.Events.Credits.GetUsage(
            new() { CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListLedger_Works()
    {
        var page = await this.client.V1.Events.Credits.ListLedger(
            new() { CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
