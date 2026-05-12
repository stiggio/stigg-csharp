using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1;

public class CreditServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetUsage_Works()
    {
        var response = await this.client.V1.Credits.GetUsage(
            new() { CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListLedger_Works()
    {
        var page = await this.client.V1.Credits.ListLedger(
            new() { CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
