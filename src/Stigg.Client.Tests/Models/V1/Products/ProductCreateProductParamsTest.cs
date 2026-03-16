using System;
using System.Collections.Generic;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductCreateProductParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductCreateProductParams
        {
            ID = "id",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedMultipleSubscriptions = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedMultipleSubscriptions, parameters.MultipleSubscriptions);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCreateProductParams
        {
            ID = "id",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.MultipleSubscriptions);
        Assert.False(parameters.RawBodyData.ContainsKey("multipleSubscriptions"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProductCreateProductParams
        {
            ID = "id",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            MultipleSubscriptions = null,
        };

        Assert.Null(parameters.MultipleSubscriptions);
        Assert.False(parameters.RawBodyData.ContainsKey("multipleSubscriptions"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductCreateProductParams
        {
            ID = "id",
            DisplayName = "displayName",
            MultipleSubscriptions = true,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProductCreateProductParams
        {
            ID = "id",
            DisplayName = "displayName",
            MultipleSubscriptions = true,

            Description = null,
            Metadata = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductCreateProductParams parameters = new() { ID = "id", DisplayName = "displayName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/products"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductCreateProductParams
        {
            ID = "id",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
        };

        ProductCreateProductParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
