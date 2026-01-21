using System;
using Stigg.Models.V1.Subscriptions;

namespace Stigg.Tests.Models.V1.Subscriptions;

public class SubscriptionTransferParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionTransferParams
        {
            ID = "x",
            DestinationResourceID = "destinationResourceId",
        };

        string expectedID = "x";
        string expectedDestinationResourceID = "destinationResourceId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDestinationResourceID, parameters.DestinationResourceID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionTransferParams parameters = new()
        {
            ID = "x",
            DestinationResourceID = "destinationResourceId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/subscriptions/x/transfer"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionTransferParams
        {
            ID = "x",
            DestinationResourceID = "destinationResourceId",
        };

        SubscriptionTransferParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
