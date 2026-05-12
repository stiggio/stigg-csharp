using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Credits;

public class AutoRechargeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetAutoRecharge_Works()
    {
        var response = await this.client.V1.Credits.AutoRecharge.GetAutoRecharge(
            new() { CurrencyID = "currencyId", CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
