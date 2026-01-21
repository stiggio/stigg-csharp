using System;
using Stigg.Models.V1.Customers.Promotional;

namespace Stigg.Tests.Models.V1.Customers.Promotional;

public class PromotionalRevokeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PromotionalRevokeParams
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
        PromotionalRevokeParams parameters = new()
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.example.com/api/v1/customers/customerId/promotional/featureId/featureId"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PromotionalRevokeParams
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
        };

        PromotionalRevokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
