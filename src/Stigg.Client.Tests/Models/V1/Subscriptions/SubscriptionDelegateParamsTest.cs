using System;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionDelegateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionDelegateParams
        {
            ID = "x",
            TargetCustomerID = "targetCustomerId",
        };

        string expectedID = "x";
        string expectedTargetCustomerID = "targetCustomerId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedTargetCustomerID, parameters.TargetCustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionDelegateParams parameters = new()
        {
            ID = "x",
            TargetCustomerID = "targetCustomerId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/subscriptions/x/delegate"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionDelegateParams
        {
            ID = "x",
            TargetCustomerID = "targetCustomerId",
        };

        SubscriptionDelegateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
