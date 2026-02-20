using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events;

public class PlanServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var plan = await this.client.V1.Events.Plans.Create(
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                ProductID = "productId",
            },
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var plan = await this.client.V1.Events.Plans.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Events.Plans.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
