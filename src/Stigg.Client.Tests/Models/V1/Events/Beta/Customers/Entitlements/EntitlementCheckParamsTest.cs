using System;
using System.Collections.Generic;
using System.Net.Http;
using Stigg.Client.Models.V1.Events.Beta.Customers.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Events.Beta.Customers.Entitlements;

public class EntitlementCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementCheckParams
        {
            ID = "x",
            CurrencyID = "x",
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ResourceID = "x",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        string expectedCurrencyID = "x";
        Dictionary<string, string> expectedDimensions = new() { { "foo", "string" } };
        string expectedFeatureID = "x";
        long expectedRequestedUsage = 0;
        List<string> expectedRequestedValues = ["string"];
        string expectedResourceID = "x";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.NotNull(parameters.Dimensions);
        Assert.Equal(expectedDimensions.Count, parameters.Dimensions.Count);
        foreach (var item in expectedDimensions)
        {
            Assert.True(parameters.Dimensions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Dimensions[item.Key]);
        }
        Assert.Equal(expectedFeatureID, parameters.FeatureID);
        Assert.Equal(expectedRequestedUsage, parameters.RequestedUsage);
        Assert.NotNull(parameters.RequestedValues);
        Assert.Equal(expectedRequestedValues.Count, parameters.RequestedValues.Count);
        for (int i = 0; i < expectedRequestedValues.Count; i++)
        {
            Assert.Equal(expectedRequestedValues[i], parameters.RequestedValues[i]);
        }
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementCheckParams { ID = "x" };

        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawQueryData.ContainsKey("dimensions"));
        Assert.Null(parameters.FeatureID);
        Assert.False(parameters.RawQueryData.ContainsKey("featureId"));
        Assert.Null(parameters.RequestedUsage);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedUsage"));
        Assert.Null(parameters.RequestedValues);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedValues"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntitlementCheckParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            CurrencyID = null,
            Dimensions = null,
            FeatureID = null,
            RequestedUsage = null,
            RequestedValues = null,
            ResourceID = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawQueryData.ContainsKey("dimensions"));
        Assert.Null(parameters.FeatureID);
        Assert.False(parameters.RawQueryData.ContainsKey("featureId"));
        Assert.Null(parameters.RequestedUsage);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedUsage"));
        Assert.Null(parameters.RequestedValues);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedValues"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementCheckParams parameters = new()
        {
            ID = "x",
            CurrencyID = "x",
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ResourceID = "x",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1-beta/customers/x/entitlements/check?currencyId=x&dimensions%5bfoo%5d=string&featureId=x&requestedUsage=0&requestedValues=string&resourceId=x"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EntitlementCheckParams parameters = new()
        {
            ID = "x",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["X-ACCOUNT-ID"], requestMessage.Headers.GetValues("X-ACCOUNT-ID"));
        Assert.Equal(["X-ENVIRONMENT-ID"], requestMessage.Headers.GetValues("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementCheckParams
        {
            ID = "x",
            CurrencyID = "x",
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ResourceID = "x",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        EntitlementCheckParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
