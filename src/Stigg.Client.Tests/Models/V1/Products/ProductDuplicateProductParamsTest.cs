using System;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductDuplicateProductParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductDuplicateProductParams
        {
            ID = "x",
            Description = "description",
            DisplayName = "displayName",
        };

        string expectedID = "x";
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductDuplicateProductParams
        {
            ID = "x",
            Description = "description",
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProductDuplicateProductParams
        {
            ID = "x",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductDuplicateProductParams
        {
            ID = "x",
            DisplayName = "displayName",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProductDuplicateProductParams
        {
            ID = "x",
            DisplayName = "displayName",

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductDuplicateProductParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/products/x/duplicate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductDuplicateProductParams
        {
            ID = "x",
            Description = "description",
            DisplayName = "displayName",
        };

        ProductDuplicateProductParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
