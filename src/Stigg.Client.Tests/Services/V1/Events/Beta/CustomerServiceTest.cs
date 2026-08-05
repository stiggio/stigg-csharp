using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events.Beta;

public class CustomerServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveGovernance_Works()
    {
        var response = await this.client.V1.Events.Beta.Customers.RetrieveGovernance(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
