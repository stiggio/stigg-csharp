using System;
using System.Collections.Generic;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Models.V1.Events.Addons;

public class AddonUpdateAddonParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonUpdateAddonParams
        {
            ID = "x",
            BillingID = "billingId",
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedID = "x";
        string expectedBillingID = "billingId";
        List<string> expectedDependencies = ["string"];
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.NotNull(parameters.Dependencies);
        Assert.Equal(expectedDependencies.Count, parameters.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], parameters.Dependencies[i]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedMaxQuantity, parameters.MaxQuantity);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddonUpdateAddonParams
        {
            ID = "x",
            BillingID = "billingId",
            Dependencies = ["string"],
            Description = "description",
            MaxQuantity = 0,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AddonUpdateAddonParams
        {
            ID = "x",
            BillingID = "billingId",
            Dependencies = ["string"],
            Description = "description",
            MaxQuantity = 0,

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            Metadata = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddonUpdateAddonParams
        {
            ID = "x",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.Dependencies);
        Assert.False(parameters.RawBodyData.ContainsKey("dependencies"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MaxQuantity);
        Assert.False(parameters.RawBodyData.ContainsKey("maxQuantity"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AddonUpdateAddonParams
        {
            ID = "x",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            BillingID = null,
            Dependencies = null,
            Description = null,
            MaxQuantity = null,
        };

        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.Dependencies);
        Assert.True(parameters.RawBodyData.ContainsKey("dependencies"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MaxQuantity);
        Assert.True(parameters.RawBodyData.ContainsKey("maxQuantity"));
    }

    [Fact]
    public void Url_Works()
    {
        AddonUpdateAddonParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/addons/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonUpdateAddonParams
        {
            ID = "x",
            BillingID = "billingId",
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        AddonUpdateAddonParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
