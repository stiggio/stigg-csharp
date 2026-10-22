using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Credits;

public class ReservationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Release_Works()
    {
        var response = await this.client.V1.Credits.Reservations.Release(
            "x",
            new()
            {
                ConsumedAmount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
