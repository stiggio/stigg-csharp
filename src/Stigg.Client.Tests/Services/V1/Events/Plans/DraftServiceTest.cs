using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events.Plans;

public class DraftServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var plan = await this.client.V1.Events.Plans.Draft.Create(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        var draft = await this.client.V1.Events.Plans.Draft.Remove(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        draft.Validate();
    }
}
