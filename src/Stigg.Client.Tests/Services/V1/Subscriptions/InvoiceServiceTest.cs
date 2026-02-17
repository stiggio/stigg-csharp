using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Subscriptions;

public class InvoiceServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task MarkAsPaid_Works()
    {
        var response = await this.client.V1.Subscriptions.Invoice.MarkAsPaid(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
