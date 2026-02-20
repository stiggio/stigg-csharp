using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Subscriptions;

public class FutureUpdateServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CancelPendingPayment_Works()
    {
        var cancelSubscription =
            await this.client.V1.Subscriptions.FutureUpdate.CancelPendingPayment(
                "x",
                new(),
                TestContext.Current.CancellationToken
            );
        cancelSubscription.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CancelSchedule_Works()
    {
        var cancelSubscription = await this.client.V1.Subscriptions.FutureUpdate.CancelSchedule(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        cancelSubscription.Validate();
    }
}
