using System;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventQueueDeleteParams { QueueName = "x" };

        string expectedQueueName = "x";

        Assert.Equal(expectedQueueName, parameters.QueueName);
    }

    [Fact]
    public void Url_Works()
    {
        EventQueueDeleteParams parameters = new() { QueueName = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/internal/beta/event-queues/x"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventQueueDeleteParams { QueueName = "x" };

        EventQueueDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
