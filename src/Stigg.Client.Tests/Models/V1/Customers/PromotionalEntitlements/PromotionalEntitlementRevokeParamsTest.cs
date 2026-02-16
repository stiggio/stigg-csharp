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
            CustomerID = "customerId",
            FeatureID = "featureId",
        };

        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedFeatureID, parameters.FeatureID);
    }

    [Fact]
    public void Url_Works()
    {
        PromotionalEntitlementRevokeParams parameters = new()
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.stigg.io/api/v1/customers/customerId/promotional/featureId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PromotionalEntitlementRevokeParams
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
        };

        PromotionalEntitlementRevokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
