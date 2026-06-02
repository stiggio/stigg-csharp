using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1Beta;

public class EntityTypeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1Beta.EntityTypes.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var response = await this.client.V1Beta.EntityTypes.Upsert(
            new()
            {
                Types =
                [
                    new()
                    {
                        ID = "org",
                        AttributionKeys = ["organizationId"],
                        DisplayName = "Organization",
                    },
                    new()
                    {
                        ID = "team",
                        AttributionKeys = ["teamId"],
                        DisplayName = "Team",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
