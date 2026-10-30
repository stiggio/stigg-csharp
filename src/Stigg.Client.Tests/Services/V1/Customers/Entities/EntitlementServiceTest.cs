using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Customers.Entities;

public class EntitlementServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Customers.Entities.Entitlements.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var response = await this.client.V1.Customers.Entities.Entitlements.Upsert(
            "id",
            new()
            {
                EntityEntitlements =
                [
                    new()
                    {
                        EntityID = "workspace-001",
                        Cadence = "P1M",
                        CurrencyID = "currencyId",
                        FeatureID = "compute-minutes",
                        ParentID = "parentId",
                        ScopeEntityIds = ["NxI"],
                        UsageLimit = 1000,
                    },
                    new()
                    {
                        EntityID = "workspace-002",
                        Cadence = "P1M",
                        CurrencyID = "cred-type-tokens",
                        FeatureID = "featureId",
                        ParentID = "workspace-001",
                        ScopeEntityIds = ["user-1"],
                        UsageLimit = 2000,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
