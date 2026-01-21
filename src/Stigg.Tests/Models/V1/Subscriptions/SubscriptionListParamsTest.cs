using System;
using Stigg.Models.V1.Subscriptions;

namespace Stigg.Tests.Models.V1.Subscriptions;

public class SubscriptionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionListParams
        {
            CustomerID = "customerId",
            EndingBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            StartingAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = "status",
        };

        string expectedCustomerID = "customerId";
        string expectedEndingBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedLimit = 1;
        string expectedStartingAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedStatus = "status";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedEndingBefore, parameters.EndingBefore);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStartingAfter, parameters.StartingAfter);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams { };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customerId"));
        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams
        {
            // Null should be interpreted as omitted for these properties
            CustomerID = null,
            EndingBefore = null,
            Limit = null,
            StartingAfter = null,
            Status = null,
        };

        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customerId"));
        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionListParams parameters = new()
        {
            CustomerID = "customerId",
            EndingBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            StartingAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = "status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.example.com/api/v1/subscriptions?customerId=customerId&endingBefore=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&limit=1&startingAfter=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&status=status"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionListParams
        {
            CustomerID = "customerId",
            EndingBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            StartingAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = "status",
        };

        SubscriptionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
