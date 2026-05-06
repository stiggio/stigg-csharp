using System;
using System.Collections.Generic;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerCheckEntitlementParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerCheckEntitlementParams
        {
            ID = "x",
            CurrencyID = "x",
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ResourceID = "x",
        };

        string expectedID = "x";
        string expectedCurrencyID = "x";
        string expectedFeatureID = "x";
        long expectedRequestedUsage = 0;
        List<string> expectedRequestedValues = ["string"];
        string expectedResourceID = "x";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedFeatureID, parameters.FeatureID);
        Assert.Equal(expectedRequestedUsage, parameters.RequestedUsage);
        Assert.NotNull(parameters.RequestedValues);
        Assert.Equal(expectedRequestedValues.Count, parameters.RequestedValues.Count);
        for (int i = 0; i < expectedRequestedValues.Count; i++)
        {
            Assert.Equal(expectedRequestedValues[i], parameters.RequestedValues[i]);
        }
        Assert.Equal(expectedResourceID, parameters.ResourceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerCheckEntitlementParams { ID = "x" };

        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.FeatureID);
        Assert.False(parameters.RawQueryData.ContainsKey("featureId"));
        Assert.Null(parameters.RequestedUsage);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedUsage"));
        Assert.Null(parameters.RequestedValues);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedValues"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerCheckEntitlementParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            CurrencyID = null,
            FeatureID = null,
            RequestedUsage = null,
            RequestedValues = null,
            ResourceID = null,
        };

        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.FeatureID);
        Assert.False(parameters.RawQueryData.ContainsKey("featureId"));
        Assert.Null(parameters.RequestedUsage);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedUsage"));
        Assert.Null(parameters.RequestedValues);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedValues"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerCheckEntitlementParams parameters = new()
        {
            ID = "x",
            CurrencyID = "x",
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ResourceID = "x",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/customers/x/entitlements/check?currencyId=x&featureId=x&requestedUsage=0&requestedValues=string&resourceId=x"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerCheckEntitlementParams
        {
            ID = "x",
            CurrencyID = "x",
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ResourceID = "x",
        };

        CustomerCheckEntitlementParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
