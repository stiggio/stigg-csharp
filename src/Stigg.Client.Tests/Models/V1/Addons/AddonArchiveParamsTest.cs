using System;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class AddonArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonArchiveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AddonArchiveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/addons/x/archive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonArchiveParams { ID = "x" };

        AddonArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
