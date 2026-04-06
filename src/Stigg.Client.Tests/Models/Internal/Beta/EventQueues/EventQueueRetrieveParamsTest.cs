using System;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventQueueRetrieveParams { QueueName = "x" };

        string expectedQueueName = "x";

        Assert.Equal(expectedQueueName, parameters.QueueName);
    }

    [Fact]
    public void Url_Works()
    {
        EventQueueRetrieveParams parameters = new() { QueueName = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/internal/beta/event-queues/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventQueueRetrieveParams { QueueName = "x" };

        EventQueueRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
