using System.Threading.Tasks;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Services.V1.Events;

public class AddonServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ArchiveAddon_Works()
    {
        var response = await this.client.V1.Events.Addons.ArchiveAddon(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateAddon_Works()
    {
        var response = await this.client.V1.Events.Addons.CreateAddon(
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                ProductID = "productId",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAddons_Works()
    {
        var page = await this.client.V1.Events.Addons.ListAddons(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task PublishAddon_Works()
    {
        var response = await this.client.V1.Events.Addons.PublishAddon(
            "x",
            new() { MigrationType = MigrationType.NewCustomers },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveAddon_Works()
    {
        var response = await this.client.V1.Events.Addons.RetrieveAddon(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateAddon_Works()
    {
        var response = await this.client.V1.Events.Addons.UpdateAddon(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
