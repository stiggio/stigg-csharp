using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Features;

namespace Stigg.Client.Tests.Models.V1.Events.Features;

public class FeatureRetrieveFeatureResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureRetrieveFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        FeatureRetrieveFeatureResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureRetrieveFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureRetrieveFeatureResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureRetrieveFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureRetrieveFeatureResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FeatureRetrieveFeatureResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureRetrieveFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureRetrieveFeatureResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
                FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        FeatureRetrieveFeatureResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureRetrieveFeatureResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureRetrieveFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<FeatureRetrieveFeatureResponseDataEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus> expectedFeatureStatus =
            FeatureRetrieveFeatureResponseDataFeatureStatus.New;
        ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType> expectedFeatureType =
            FeatureRetrieveFeatureResponseDataFeatureType.Boolean;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType> expectedMeterType =
            FeatureRetrieveFeatureResponseDataMeterType.None;
        FeatureRetrieveFeatureResponseDataUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
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
        var model = new FeatureRetrieveFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureRetrieveFeatureResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureRetrieveFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureRetrieveFeatureResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<FeatureRetrieveFeatureResponseDataEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus> expectedFeatureStatus =
            FeatureRetrieveFeatureResponseDataFeatureStatus.New;
        ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType> expectedFeatureType =
            FeatureRetrieveFeatureResponseDataFeatureType.Boolean;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType> expectedMeterType =
            FeatureRetrieveFeatureResponseDataMeterType.None;
        FeatureRetrieveFeatureResponseDataUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
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
        var model = new FeatureRetrieveFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureRetrieveFeatureResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureRetrieveFeatureResponseDataFeatureStatus.New,
            FeatureType = FeatureRetrieveFeatureResponseDataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = FeatureRetrieveFeatureResponseDataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        FeatureRetrieveFeatureResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureRetrieveFeatureResponseDataEnumConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureRetrieveFeatureResponseDataEnumConfiguration
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
        var model = new FeatureRetrieveFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureRetrieveFeatureResponseDataEnumConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureRetrieveFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureRetrieveFeatureResponseDataEnumConfiguration>(
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
        var model = new FeatureRetrieveFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureRetrieveFeatureResponseDataEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        FeatureRetrieveFeatureResponseDataEnumConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureRetrieveFeatureResponseDataFeatureStatusTest : TestBase
{
    [Theory]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureStatus.New)]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureStatus.Suspended)]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureStatus.Active)]
    public void Validation_Works(FeatureRetrieveFeatureResponseDataFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureStatus.New)]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureStatus.Suspended)]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureStatus.Active)]
    public void SerializationRoundtrip_Works(
        FeatureRetrieveFeatureResponseDataFeatureStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureRetrieveFeatureResponseDataFeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureType.Boolean)]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureType.Number)]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureType.Enum)]
    public void Validation_Works(FeatureRetrieveFeatureResponseDataFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureType.Boolean)]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureType.Number)]
    [InlineData(FeatureRetrieveFeatureResponseDataFeatureType.Enum)]
    public void SerializationRoundtrip_Works(FeatureRetrieveFeatureResponseDataFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureRetrieveFeatureResponseDataMeterTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureRetrieveFeatureResponseDataMeterType.None)]
    [InlineData(FeatureRetrieveFeatureResponseDataMeterType.Fluctuating)]
    [InlineData(FeatureRetrieveFeatureResponseDataMeterType.Incremental)]
    public void Validation_Works(FeatureRetrieveFeatureResponseDataMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureRetrieveFeatureResponseDataMeterType.None)]
    [InlineData(FeatureRetrieveFeatureResponseDataMeterType.Fluctuating)]
    [InlineData(FeatureRetrieveFeatureResponseDataMeterType.Incremental)]
    public void SerializationRoundtrip_Works(FeatureRetrieveFeatureResponseDataMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataMeterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureRetrieveFeatureResponseDataUnitTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureRetrieveFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
        };

        double expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound> expectedRound =
            FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, model.Divide);
        Assert.Equal(expectedFeatureUnits, model.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, model.FeatureUnitsPlural);
        Assert.Equal(expectedRound, model.Round);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureRetrieveFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureRetrieveFeatureResponseDataUnitTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureRetrieveFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureRetrieveFeatureResponseDataUnitTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound> expectedRound =
            FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, deserialized.Divide);
        Assert.Equal(expectedFeatureUnits, deserialized.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, deserialized.FeatureUnitsPlural);
        Assert.Equal(expectedRound, deserialized.Round);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureRetrieveFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureRetrieveFeatureResponseDataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up,
        };

        FeatureRetrieveFeatureResponseDataUnitTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureRetrieveFeatureResponseDataUnitTransformationRoundTest : TestBase
{
    [Theory]
    [InlineData(FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up)]
    [InlineData(FeatureRetrieveFeatureResponseDataUnitTransformationRound.Down)]
    public void Validation_Works(FeatureRetrieveFeatureResponseDataUnitTransformationRound rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureRetrieveFeatureResponseDataUnitTransformationRound.Up)]
    [InlineData(FeatureRetrieveFeatureResponseDataUnitTransformationRound.Down)]
    public void SerializationRoundtrip_Works(
        FeatureRetrieveFeatureResponseDataUnitTransformationRound rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureRetrieveFeatureResponseDataUnitTransformationRound>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
