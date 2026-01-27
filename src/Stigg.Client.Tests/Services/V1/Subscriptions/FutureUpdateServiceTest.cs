using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Subscriptions;

public class FutureUpdateServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CancelPendingPayment_Works()
    {
        var response = await this.client.V1.Subscriptions.FutureUpdate.CancelPendingPayment(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CancelSchedule_Works()
    {
        var response = await this.client.V1.Subscriptions.FutureUpdate.CancelSchedule(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
