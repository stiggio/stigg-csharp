using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Usage;

namespace Stigg.Client.Tests.Models.V1.Usage;

public class UsageReportParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageReportParams
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    IdempotencyKey = "x",
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        List<UsageReportParamsUsage> expectedUsages =
        [
            new()
            {
                CustomerID = "customerId",
                FeatureID = "featureId",
                Value = -9007199254740991,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                IdempotencyKey = "x",
                ResourceID = "resourceId",
                UpdateBehavior = UpdateBehavior.Delta,
            },
        ];
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedUsages.Count, parameters.Usages.Count);
        for (int i = 0; i < expectedUsages.Count; i++)
        {
            Assert.Equal(expectedUsages[i], parameters.Usages[i]);
        }
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageReportParams
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    IdempotencyKey = "x",
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UsageReportParams
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    IdempotencyKey = "x",
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],

            // Null should be interpreted as omitted for these properties
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        UsageReportParams parameters = new()
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    IdempotencyKey = "x",
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://edge.api.stigg.io/api/v1/usage"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UsageReportParams parameters = new()
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    IdempotencyKey = "x",
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],
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
        var parameters = new UsageReportParams
        {
            Usages =
            [
                new()
                {
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Value = -9007199254740991,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    IdempotencyKey = "x",
                    ResourceID = "resourceId",
                    UpdateBehavior = UpdateBehavior.Delta,
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        UsageReportParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UsageReportParamsUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        long expectedValue = -9007199254740991;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, Dimension> expectedDimensions = new() { { "foo", "string" } };
        string expectedIdempotencyKey = "x";
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
        Assert.Equal(expectedIdempotencyKey, model.IdempotencyKey);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedUpdateBehavior, model.UpdateBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageReportParamsUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageReportParamsUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        long expectedValue = -9007199254740991;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, Dimension> expectedDimensions = new() { { "foo", "string" } };
        string expectedIdempotencyKey = "x";
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
        Assert.Equal(expectedIdempotencyKey, deserialized.IdempotencyKey);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedUpdateBehavior, deserialized.UpdateBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UsageReportParamsUsage
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
        Assert.Null(model.IdempotencyKey);
        Assert.False(model.RawData.ContainsKey("idempotencyKey"));
        Assert.Null(model.UpdateBehavior);
        Assert.False(model.RawData.ContainsKey("updateBehavior"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UsageReportParamsUsage
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
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Dimensions = null,
            IdempotencyKey = null,
            UpdateBehavior = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.IdempotencyKey);
        Assert.False(model.RawData.ContainsKey("idempotencyKey"));
        Assert.Null(model.UpdateBehavior);
        Assert.False(model.RawData.ContainsKey("updateBehavior"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Dimensions = null,
            IdempotencyKey = null,
            UpdateBehavior = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            UpdateBehavior = UpdateBehavior.Delta,

            ResourceID = null,
        };

        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            UpdateBehavior = UpdateBehavior.Delta,

            ResourceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageReportParamsUsage
        {
            CustomerID = "customerId",
            FeatureID = "featureId",
            Value = -9007199254740991,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            IdempotencyKey = "x",
            ResourceID = "resourceId",
            UpdateBehavior = UpdateBehavior.Delta,
        };

        UsageReportParamsUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DimensionTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Dimension value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Dimension value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Dimension value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Dimension value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dimension>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Dimension value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dimension>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Dimension value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dimension>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
