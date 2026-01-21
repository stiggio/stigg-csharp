using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1;

namespace Stigg.Tests.Models.V1;

public class V1CreateUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateUsageParams
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],
        };

        List<Usage> expectedUsages =
        [
            new()
            {
                CustomerID = "customerId",
                FeatureID = "featureId",
                Value = -9007199254740991,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceID = "resourceId",
                UpdateBehavior = UpdateBehavior.Delta,
            },
        ];

        Assert.Equal(expectedUsages.Count, parameters.Usages.Count);
        for (int i = 0; i < expectedUsages.Count; i++)
        {
            Assert.Equal(expectedUsages[i], parameters.Usages[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        V1CreateUsageParams parameters = new()
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/usage"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1CreateUsageParams
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],
        };

        V1CreateUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        long expectedValue = -9007199254740991;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedDimensions = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        ApiEnum<string, UpdateBehavior> expectedUpdateBehavior = UpdateBehavior.Delta;

        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Dimensions);
        Assert.Equal(expectedDimensions.Count, model.Dimensions.Count);
        foreach (var item in expectedDimensions)
        {
            Assert.True(model.Dimensions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Dimensions[item.Key]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedUpdateBehavior, model.UpdateBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        long expectedValue = -9007199254740991;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedDimensions = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        ApiEnum<string, UpdateBehavior> expectedUpdateBehavior = UpdateBehavior.Delta;

        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Dimensions);
        Assert.Equal(expectedDimensions.Count, deserialized.Dimensions.Count);
        foreach (var item in expectedDimensions)
        {
            Assert.True(deserialized.Dimensions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Dimensions[item.Key]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedUpdateBehavior, deserialized.UpdateBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            ResourceID = "resourceId",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.UpdateBehavior);
        Assert.False(model.RawData.ContainsKey("updateBehavior"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            ResourceID = "resourceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Dimensions = null,
            UpdateBehavior = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.UpdateBehavior);
        Assert.False(model.RawData.ContainsKey("updateBehavior"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Dimensions = null,
            UpdateBehavior = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            UpdateBehavior = UpdateBehavior.Delta,
        };

        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            UpdateBehavior = UpdateBehavior.Delta,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            UpdateBehavior = UpdateBehavior.Delta,

            ResourceID = null,
        };

        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
            UpdateBehavior = UpdateBehavior.Delta,

            ResourceID = null,
        };

        model.Validate();
    }
}

public class UpdateBehaviorTest : TestBase
{
    [Theory]
    [InlineData(UpdateBehavior.Delta)]
    [InlineData(UpdateBehavior.Set)]
    public void Validation_Works(UpdateBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UpdateBehavior.Delta)]
    [InlineData(UpdateBehavior.Set)]
    public void SerializationRoundtrip_Works(UpdateBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UpdateBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UpdateBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UpdateBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UpdateBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
