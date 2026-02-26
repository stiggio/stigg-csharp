using System;
using Stigg.Client.Models.V1.Addons.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Addons.Entitlements;

public class EntitlementDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementDeleteParams { AddonID = "addonId", ID = "id" };

        string expectedAddonID = "addonId";
        string expectedID = "id";

        Assert.Equal(expectedAddonID, parameters.AddonID);
        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementDeleteParams parameters = new() { AddonID = "addonId", ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/addons/addonId/entitlements/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementDeleteParams { AddonID = "addonId", ID = "id" };

        EntitlementDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
