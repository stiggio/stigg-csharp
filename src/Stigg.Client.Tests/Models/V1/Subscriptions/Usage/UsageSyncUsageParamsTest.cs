using System;
using Stigg.Client.Models.V1.Subscriptions.Usage;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.Usage;

public class UsageSyncUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageSyncUsageParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        UsageSyncUsageParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/subscriptions/x/usage/sync"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageSyncUsageParams { ID = "x" };

        UsageSyncUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
