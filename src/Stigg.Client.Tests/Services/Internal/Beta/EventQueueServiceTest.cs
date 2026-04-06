using System.Threading.Tasks;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Services.Internal.Beta;

public class EventQueueServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var eventQueue = await this.client.Internal.Beta.EventQueues.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        eventQueue.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var eventQueue = await this.client.Internal.Beta.EventQueues.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        eventQueue.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var eventQueues = await this.client.Internal.Beta.EventQueues.List(
            new(),
            TestContext.Current.CancellationToken
        );
        eventQueues.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var eventQueue = await this.client.Internal.Beta.EventQueues.Delete(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        eventQueue.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Provision_Works()
    {
        var response = await this.client.Internal.Beta.EventQueues.Provision(
            new() { Region = Region.UsEast1 },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
