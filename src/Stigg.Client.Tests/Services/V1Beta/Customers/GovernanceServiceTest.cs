using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1Beta.Customers;

public class GovernanceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1Beta.Customers.Governance.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
