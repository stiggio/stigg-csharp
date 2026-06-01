using System;
using Stigg.Client.Models.V1.Addons.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Addons.Entitlements;

public class EntitlementListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementListParams { AddonID = "addonId" };

        string expectedAddonID = "addonId";

        Assert.Equal(expectedAddonID, parameters.AddonID);
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementListParams parameters = new() { AddonID = "addonId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/addons/addonId/entitlements"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementListParams { AddonID = "addonId" };

        EntitlementListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
