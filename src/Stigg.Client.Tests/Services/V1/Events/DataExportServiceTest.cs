using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events;

public class DataExportServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListModels_Works()
    {
        var response = await this.client.V1.Events.DataExport.ListModels(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task MintScopedToken_Works()
    {
        var response = await this.client.V1.Events.DataExport.MintScopedToken(
            new() { ApplicationOrigin = "x" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TriggerSync_Works()
    {
        var response = await this.client.V1.Events.DataExport.TriggerSync(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
