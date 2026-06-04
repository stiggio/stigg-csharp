using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events.DataExport;

public class DestinationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var destination = await this.client.V1.Events.DataExport.Destinations.Create(
            new() { DestinationID = "x", DestinationType = "x" },
            TestContext.Current.CancellationToken
        );
        destination.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var destination = await this.client.V1.Events.DataExport.Destinations.Delete(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        destination.Validate();
    }
}
