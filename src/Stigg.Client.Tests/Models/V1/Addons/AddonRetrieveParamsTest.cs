using System;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class AddonRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonRetrieveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AddonRetrieveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/addons/x"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonRetrieveParams { ID = "x" };

        AddonRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
