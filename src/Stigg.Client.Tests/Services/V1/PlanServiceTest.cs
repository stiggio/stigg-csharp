using System.Threading.Tasks;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Services.V1;

public class PlanServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var plan = await this.client.V1.Plans.Create(
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
        var plan = await this.client.V1.Plans.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var plan = await this.client.V1.Plans.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Plans.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var plan = await this.client.V1.Plans.Archive(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateDraft_Works()
    {
        var plan = await this.client.V1.Plans.CreateDraft(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        var response = await this.client.V1.Plans.Publish(
            "x",
            new() { MigrationType = MigrationType.NewCustomers },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RemoveDraft_Works()
    {
        var response = await this.client.V1.Plans.RemoveDraft(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
