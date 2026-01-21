using System.Threading.Tasks;
using Stigg.Models.V1.Customers.PaymentMethod;

namespace Stigg.Tests.Services.V1.Customers;

public class PaymentMethodServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Attach_Works()
    {
        var customerResponse = await this.client.V1.Customers.PaymentMethod.Attach(
            "x",
            new()
            {
                IntegrationID = "integrationId",
                PaymentMethodID = "paymentMethodId",
                VendorIdentifier = VendorIdentifier.Auth0,
            },
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Detach_Works()
    {
        var customerResponse = await this.client.V1.Customers.PaymentMethod.Detach(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }
}
