using System;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Models.V1.Events.Addons;

public class AddonRetrieveAddonParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonRetrieveAddonParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AddonRetrieveAddonParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/addons/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonRetrieveAddonParams { ID = "x" };

        AddonRetrieveAddonParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
