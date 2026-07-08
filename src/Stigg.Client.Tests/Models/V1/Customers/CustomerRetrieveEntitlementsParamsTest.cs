using System;
using System.Net.Http;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerRetrieveEntitlementsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerRetrieveEntitlementsParams
        {
            ID = "x",
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        string expectedResourceID = "resourceId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerRetrieveEntitlementsParams { ID = "x" };

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
        var parameters = new CustomerRetrieveEntitlementsParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            ResourceID = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

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
        CustomerRetrieveEntitlementsParams parameters = new()
        {
            ID = "x",
            ResourceID = "resourceId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://edge.api.stigg.io/api/v1/customers/x/entitlements?resourceId=resourceId"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomerRetrieveEntitlementsParams parameters = new()
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
        var parameters = new CustomerRetrieveEntitlementsParams
        {
            ID = "x",
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CustomerRetrieveEntitlementsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
