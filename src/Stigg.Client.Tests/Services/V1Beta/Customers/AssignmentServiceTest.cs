using System.Threading.Tasks;
using Stigg.Client.Models.V1Beta.Customers.Assignments;

namespace Stigg.Client.Tests.Services.V1Beta.Customers;

public class AssignmentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1Beta.Customers.Assignments.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var response = await this.client.V1Beta.Customers.Assignments.Upsert(
            "id",
            new()
            {
                Assignments =
                [
                    new()
                    {
                        EntityID = "workspace-001",
                        Cadence = Cadence.Month,
                        CurrencyID = "currencyId",
                        FeatureID = "compute-minutes",
                        ParentID = "parentId",
                        ScopeEntityIds = ["NxI"],
                        UsageLimit = 1000,
                    },
                    new()
                    {
                        EntityID = "workspace-002",
                        Cadence = Cadence.Month,
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
