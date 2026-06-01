using System;
using Stigg.Client.Models.V1.Subscriptions.Usage;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.Usage;

public class UsageChargeUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageChargeUsageParams
        {
            ID = "x",
            UntilDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "x";
        DateTimeOffset expectedUntilDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedUntilDate, parameters.UntilDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageChargeUsageParams { ID = "x" };

        Assert.Null(parameters.UntilDate);
        Assert.False(parameters.RawBodyData.ContainsKey("untilDate"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UsageChargeUsageParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            UntilDate = null,
        };

        Assert.Null(parameters.UntilDate);
        Assert.False(parameters.RawBodyData.ContainsKey("untilDate"));
    }

    [Fact]
    public void Url_Works()
    {
        UsageChargeUsageParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/subscriptions/x/usage/charge"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageChargeUsageParams
        {
            ID = "x",
            UntilDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        UsageChargeUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
