using System;
using Stigg.Client.Models.V1.Subscriptions.Usage;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.Usage;

public class UsageSyncParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageSyncParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        UsageSyncParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/subscriptions/x/usage/sync"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageSyncParams { ID = "x" };

        UsageSyncParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
