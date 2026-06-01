using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events.Beta.Customers;

public class EntityServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var entity = await this.client.V1.Events.Beta.Customers.Entities.Retrieve(
            "x",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        entity.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Events.Beta.Customers.Entities.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var response = await this.client.V1.Events.Beta.Customers.Entities.Archive(
            "id",
            new() { Ids = ["user-7f3a0c1d", "user-c4d1b2e9"] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Unarchive_Works()
    {
        var response = await this.client.V1.Events.Beta.Customers.Entities.Unarchive(
            "id",
            new() { Ids = ["user-7f3a0c1d", "user-c4d1b2e9"] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var response = await this.client.V1.Events.Beta.Customers.Entities.Upsert(
            "id",
            new()
            {
                Entities =
                [
                    new()
                    {
                        ID = "user-7f3a0c1d",
                        Metadata = new Dictionary<string, string>()
                        {
                            { "email", "jane@acme.com" },
                            { "role", "admin" },
                        },
                        TypeRefID = "user",
                    },
                    new()
                    {
                        ID = "user-c4d1b2e9",
                        Metadata = new Dictionary<string, string>()
                        {
                            { "email", "john@acme.com" },
                        },
                        TypeRefID = "user",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
