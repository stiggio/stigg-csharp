using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1;

public class EntityTypeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.EntityTypes.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var response = await this.client.V1.EntityTypes.Archive(
            new() { Ids = ["team"] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CheckActiveEntities_Works()
    {
        var response = await this.client.V1.EntityTypes.CheckActiveEntities(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var response = await this.client.V1.EntityTypes.Upsert(
            new()
            {
                Types =
                [
                    new()
                    {
                        ID = "org",
                        AttributionKeys = ["organizationId"],
                        DisplayName = "Organization",
                        Description =
                            "A customer organization — the top of the hierarchy, holding the account-wide budget.",
                    },
                    new()
                    {
                        ID = "team",
                        AttributionKeys = ["teamId"],
                        DisplayName = "Team",
                        Description = "description",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
