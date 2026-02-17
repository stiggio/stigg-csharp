using System;
using System.Collections.Generic;
using Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Tests.Models.V1.Coupons;

public class CouponUpdateCouponParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CouponUpdateCouponParams
        {
            ID = "x",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        string expectedID = "x";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CouponUpdateCouponParams
        {
            ID = "x",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CouponUpdateCouponParams
        {
            ID = "x",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CouponUpdateCouponParams { ID = "x", Name = "name" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CouponUpdateCouponParams
        {
            ID = "x",
            Name = "name",

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
        CouponUpdateCouponParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/coupons/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CouponUpdateCouponParams
        {
            ID = "x",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        CouponUpdateCouponParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
