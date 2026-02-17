using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Subscriptions;

public class UsageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ChargeUsage_Works()
    {
        var response = await this.client.V1.Subscriptions.Usage.ChargeUsage(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SyncUsage_Works()
    {
        var response = await this.client.V1.Subscriptions.Usage.SyncUsage(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
