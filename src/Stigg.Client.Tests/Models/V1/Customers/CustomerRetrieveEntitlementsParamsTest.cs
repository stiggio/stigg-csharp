using System;
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
        };

        string expectedID = "x";
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerRetrieveEntitlementsParams { ID = "x" };

        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerRetrieveEntitlementsParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            ResourceID = null,
        };

        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
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

        Assert.Equal(
            new Uri("https://api.stigg.io/api/v1/customers/x/entitlements?resourceId=resourceId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerRetrieveEntitlementsParams
        {
            ID = "x",
            ResourceID = "resourceId",
        };

        CustomerRetrieveEntitlementsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
