using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events.Addons;

public class DraftServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateAddonDraft_Works()
    {
        var response = await this.client.V1.Events.Addons.Draft.CreateAddonDraft(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RemoveAddonDraft_Works()
    {
        var response = await this.client.V1.Events.Addons.Draft.RemoveAddonDraft(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
