using System;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionRetrieveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionRetrieveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/subscriptions/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionRetrieveParams { ID = "x" };

        SubscriptionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
