using System.Threading.Tasks;
using Stigg.Client.Models.V1.Events.Beta.Customers.Assignments;

namespace Stigg.Client.Tests.Services.V1.Events.Beta.Customers;

public class AssignmentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Events.Beta.Customers.Assignments.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var response = await this.client.V1.Events.Beta.Customers.Assignments.Upsert(
            "id",
            new()
            {
                Assignments =
                [
                    new()
                    {
                        CapabilityID = "compute-minutes",
                        EntityID = "workspace-001",
                        Cadence = Cadence.Month,
                        UsageLimit = 1000,
                    },
                    new()
                    {
                        CapabilityID = "compute-minutes",
                        EntityID = "workspace-002",
                        Cadence = Cadence.Month,
                        UsageLimit = 2000,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
