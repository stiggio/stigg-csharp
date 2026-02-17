using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Features;

namespace Stigg.Client.Tests.Models.V1.Events.Features;

public class FeatureCreateFeatureResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureCreateFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureCreateFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        FeatureCreateFeatureResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureCreateFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureCreateFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureCreateFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureCreateFeatureResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureCreateFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureCreateFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureCreateFeatureResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FeatureCreateFeatureResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureCreateFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureCreateFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureCreateFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureCreateFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureCreateFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        FeatureCreateFeatureResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureCreateFeatureResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureCreateFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureCreateFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<FeatureCreateFeatureResponseDataEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus> expectedFeatureStatus =
            FeatureCreateFeatureResponseDataFeatureStatus.New;
        ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType> expectedFeatureType =
            FeatureCreateFeatureResponseDataFeatureType.Boolean;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, FeatureCreateFeatureResponseDataMeterType> expectedMeterType =
            FeatureCreateFeatureResponseDataMeterType.None;
        FeatureCreateFeatureResponseDataUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.EnumConfiguration);
        Assert.Equal(expectedEnumConfiguration.Count, model.EnumConfiguration.Count);
        for (int i = 0; i < expectedEnumConfiguration.Count; i++)
        {
            Assert.Equal(expectedEnumConfiguration[i], model.EnumConfiguration[i]);
        }
        Assert.Equal(expectedFeatureStatus, model.FeatureStatus);
        Assert.Equal(expectedFeatureType, model.FeatureType);
        Assert.Equal(expectedFeatureUnits, model.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, model.FeatureUnitsPlural);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMeterType, model.MeterType);
        Assert.Equal(expectedUnitTransformation, model.UnitTransformation);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureCreateFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureCreateFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureCreateFeatureResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureCreateFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureCreateFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureCreateFeatureResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<FeatureCreateFeatureResponseDataEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus> expectedFeatureStatus =
            FeatureCreateFeatureResponseDataFeatureStatus.New;
        ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType> expectedFeatureType =
            FeatureCreateFeatureResponseDataFeatureType.Boolean;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, FeatureCreateFeatureResponseDataMeterType> expectedMeterType =
            FeatureCreateFeatureResponseDataMeterType.None;
        FeatureCreateFeatureResponseDataUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.EnumConfiguration);
        Assert.Equal(expectedEnumConfiguration.Count, deserialized.EnumConfiguration.Count);
        for (int i = 0; i < expectedEnumConfiguration.Count; i++)
        {
            Assert.Equal(expectedEnumConfiguration[i], deserialized.EnumConfiguration[i]);
        }
        Assert.Equal(expectedFeatureStatus, deserialized.FeatureStatus);
        Assert.Equal(expectedFeatureType, deserialized.FeatureType);
        Assert.Equal(expectedFeatureUnits, deserialized.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, deserialized.FeatureUnitsPlural);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedMeterType, deserialized.MeterType);
        Assert.Equal(expectedUnitTransformation, deserialized.UnitTransformation);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureCreateFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureCreateFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureCreateFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureCreateFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureCreateFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureCreateFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        FeatureCreateFeatureResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureCreateFeatureResponseDataEnumConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureCreateFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string expectedDisplayName = "displayName";
        string expectedValue = "value";

        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureCreateFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureCreateFeatureResponseDataEnumConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureCreateFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureCreateFeatureResponseDataEnumConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedDisplayName = "displayName";
        string expectedValue = "value";

        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureCreateFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureCreateFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        FeatureCreateFeatureResponseDataEnumConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureCreateFeatureResponseDataFeatureStatusTest : TestBase
{
    [Theory]
    [InlineData(FeatureCreateFeatureResponseDataFeatureStatus.New)]
    [InlineData(FeatureCreateFeatureResponseDataFeatureStatus.Suspended)]
    [InlineData(FeatureCreateFeatureResponseDataFeatureStatus.Active)]
    public void Validation_Works(FeatureCreateFeatureResponseDataFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureCreateFeatureResponseDataFeatureStatus.New)]
    [InlineData(FeatureCreateFeatureResponseDataFeatureStatus.Suspended)]
    [InlineData(FeatureCreateFeatureResponseDataFeatureStatus.Active)]
    public void SerializationRoundtrip_Works(FeatureCreateFeatureResponseDataFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataFeatureStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureCreateFeatureResponseDataFeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureCreateFeatureResponseDataFeatureType.Boolean)]
    [InlineData(FeatureCreateFeatureResponseDataFeatureType.Number)]
    [InlineData(FeatureCreateFeatureResponseDataFeatureType.Enum)]
    public void Validation_Works(FeatureCreateFeatureResponseDataFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureCreateFeatureResponseDataFeatureType.Boolean)]
    [InlineData(FeatureCreateFeatureResponseDataFeatureType.Number)]
    [InlineData(FeatureCreateFeatureResponseDataFeatureType.Enum)]
    public void SerializationRoundtrip_Works(FeatureCreateFeatureResponseDataFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureCreateFeatureResponseDataMeterTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureCreateFeatureResponseDataMeterType.None)]
    [InlineData(FeatureCreateFeatureResponseDataMeterType.Fluctuating)]
    [InlineData(FeatureCreateFeatureResponseDataMeterType.Incremental)]
    public void Validation_Works(FeatureCreateFeatureResponseDataMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureCreateFeatureResponseDataMeterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataMeterType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureCreateFeatureResponseDataMeterType.None)]
    [InlineData(FeatureCreateFeatureResponseDataMeterType.Fluctuating)]
    [InlineData(FeatureCreateFeatureResponseDataMeterType.Incremental)]
    public void SerializationRoundtrip_Works(FeatureCreateFeatureResponseDataMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureCreateFeatureResponseDataMeterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataMeterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataMeterType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataMeterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureCreateFeatureResponseDataUnitTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureCreateFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
        };

        double expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound> expectedRound =
            FeatureCreateFeatureResponseDataUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, model.Divide);
        Assert.Equal(expectedFeatureUnits, model.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, model.FeatureUnitsPlural);
        Assert.Equal(expectedRound, model.Round);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureCreateFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureCreateFeatureResponseDataUnitTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureCreateFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureCreateFeatureResponseDataUnitTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound> expectedRound =
            FeatureCreateFeatureResponseDataUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, deserialized.Divide);
        Assert.Equal(expectedFeatureUnits, deserialized.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, deserialized.FeatureUnitsPlural);
        Assert.Equal(expectedRound, deserialized.Round);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureCreateFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureCreateFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureCreateFeatureResponseDataUnitTransformationRound.Up,
        };

        FeatureCreateFeatureResponseDataUnitTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureCreateFeatureResponseDataUnitTransformationRoundTest : TestBase
{
    [Theory]
    [InlineData(FeatureCreateFeatureResponseDataUnitTransformationRound.Up)]
    [InlineData(FeatureCreateFeatureResponseDataUnitTransformationRound.Down)]
    public void Validation_Works(FeatureCreateFeatureResponseDataUnitTransformationRound rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureCreateFeatureResponseDataUnitTransformationRound.Up)]
    [InlineData(FeatureCreateFeatureResponseDataUnitTransformationRound.Down)]
    public void SerializationRoundtrip_Works(
        FeatureCreateFeatureResponseDataUnitTransformationRound rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureCreateFeatureResponseDataUnitTransformationRound>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
