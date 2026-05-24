using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1Beta.Customers;

public class EntitlementServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Check_Works()
    {
        var response = await this.client.V1Beta.Customers.Entitlements.Check(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
