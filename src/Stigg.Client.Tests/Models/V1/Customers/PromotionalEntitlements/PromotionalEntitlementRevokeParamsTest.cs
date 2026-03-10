using System;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Tests.Models.V1.Customers.PromotionalEntitlements;

public class PromotionalEntitlementRevokeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PromotionalEntitlementRevokeParams
        {
            ID = "id",
            FeatureID = "featureId",
        };

        string expectedID = "id";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedFeatureID, parameters.FeatureID);
    }

    [Fact]
    public void Url_Works()
    {
        PromotionalEntitlementRevokeParams parameters = new()
        {
            ID = "id",
            FeatureID = "featureId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.stigg.io/api/v1/customers/id/promotional-entitlements/featureId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PromotionalEntitlementRevokeParams
        {
            ID = "id",
            FeatureID = "featureId",
        };

        PromotionalEntitlementRevokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
