using System;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationListParams
        {
            ID = "x",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            VendorIdentifier = "vendorIdentifier",
        };

        string expectedID = "x";
        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedLimit = 1;
        string expectedVendorIdentifier = "vendorIdentifier";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedVendorIdentifier, parameters.VendorIdentifier);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntegrationListParams { ID = "x" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.VendorIdentifier);
        Assert.False(parameters.RawQueryData.ContainsKey("vendorIdentifier"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IntegrationListParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            Limit = null,
            VendorIdentifier = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.VendorIdentifier);
        Assert.False(parameters.RawQueryData.ContainsKey("vendorIdentifier"));
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationListParams parameters = new()
        {
            ID = "x",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            VendorIdentifier = "vendorIdentifier",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.stigg.io/api/v1/customers/x/integrations?after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&limit=1&vendorIdentifier=vendorIdentifier"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntegrationListParams
        {
            ID = "x",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            VendorIdentifier = "vendorIdentifier",
        };

        IntegrationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
