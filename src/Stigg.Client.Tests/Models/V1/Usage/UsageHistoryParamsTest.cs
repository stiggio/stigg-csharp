using System;
using Stigg.Client.Models.V1.Usage;

namespace Stigg.Client.Tests.Models.V1.Usage;

public class UsageHistoryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageHistoryParams
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = "groupBy",
            ResourceID = "resourceId",
        };

        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedGroupBy = "groupBy";
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedFeatureID, parameters.FeatureID);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedGroupBy, parameters.GroupBy);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageHistoryParams
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
        };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("endDate"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawQueryData.ContainsKey("groupBy"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UsageHistoryParams
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            EndDate = null,
            GroupBy = null,
        };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("endDate"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawQueryData.ContainsKey("groupBy"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageHistoryParams
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = "groupBy",
        };

        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new UsageHistoryParams
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = "groupBy",

            ResourceID = null,
        };

        Assert.Null(parameters.ResourceID);
        Assert.True(parameters.RawQueryData.ContainsKey("resourceId"));
    }

    [Fact]
    public void Url_Works()
    {
        UsageHistoryParams parameters = new()
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = "groupBy",
            ResourceID = "resourceId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.example.com/api/v1/usage/customerId/history/featureId?startDate=2019-12-27T18%3a11%3a19.117%2b00%3a00&endDate=2019-12-27T18%3a11%3a19.117%2b00%3a00&groupBy=groupBy&resourceId=resourceId"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageHistoryParams
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = "groupBy",
            ResourceID = "resourceId",
        };

        UsageHistoryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
