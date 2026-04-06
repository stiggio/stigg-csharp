using System.Threading.Tasks;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Services.V1.Customers;

public class IntegrationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var integration = await this.client.V1.Customers.Integrations.Retrieve(
            "integrationId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        integration.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var integration = await this.client.V1.Customers.Integrations.Update(
            "integrationId",
            new() { ID = "id", SyncedEntityID = "syncedEntityId" },
            TestContext.Current.CancellationToken
        );
        integration.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Customers.Integrations.List(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Link_Works()
    {
        var response = await this.client.V1.Customers.Integrations.Link(
            "x",
            new()
            {
                IDValue = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = VendorIdentifier.Auth0,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Unlink_Works()
    {
        var response = await this.client.V1.Customers.Integrations.Unlink(
            "integrationId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
