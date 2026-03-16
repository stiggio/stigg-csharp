using System.Threading.Tasks;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Services.V1;

public class AddonServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var addon = await this.client.V1.Addons.Create(
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                ProductID = "productId",
            },
            TestContext.Current.CancellationToken
        );
        addon.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var addon = await this.client.V1.Addons.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        addon.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var addon = await this.client.V1.Addons.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        addon.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Addons.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var addon = await this.client.V1.Addons.Archive(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        addon.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateDraft_Works()
    {
        var addon = await this.client.V1.Addons.CreateDraft(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        addon.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        var response = await this.client.V1.Addons.Publish(
            "x",
            new() { MigrationType = MigrationType.NewCustomers },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RemoveDraft_Works()
    {
        var response = await this.client.V1.Addons.RemoveDraft(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
