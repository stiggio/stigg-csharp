using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Features;

namespace Stigg.Client.Tests.Models.V1.Features;

public class FeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Feature
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = DataFeatureStatus.New,
                FeatureType = DataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = DataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = DataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Data expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = DataFeatureStatus.New,
            FeatureType = DataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = DataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = DataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Feature
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = DataFeatureStatus.New,
                FeatureType = DataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = DataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = DataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Feature
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = DataFeatureStatus.New,
                FeatureType = DataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = DataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = DataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = DataFeatureStatus.New,
            FeatureType = DataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = DataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = DataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Feature
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = DataFeatureStatus.New,
                FeatureType = DataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = DataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = DataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Feature
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = DataFeatureStatus.New,
                FeatureType = DataFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = DataMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = DataUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = DataFeatureStatus.New,
            FeatureType = DataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = DataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = DataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<DataEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, DataFeatureStatus> expectedFeatureStatus = DataFeatureStatus.New;
        ApiEnum<string, DataFeatureType> expectedFeatureType = DataFeatureType.Boolean;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, DataMeterType> expectedMeterType = DataMeterType.None;
        DataUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = DataUnitTransformationRound.Up,
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
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = DataFeatureStatus.New,
            FeatureType = DataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = DataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = DataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = DataFeatureStatus.New,
            FeatureType = DataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = DataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = DataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<DataEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, DataFeatureStatus> expectedFeatureStatus = DataFeatureStatus.New;
        ApiEnum<string, DataFeatureType> expectedFeatureType = DataFeatureType.Boolean;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, DataMeterType> expectedMeterType = DataMeterType.None;
        DataUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = DataUnitTransformationRound.Up,
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
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = DataFeatureStatus.New,
            FeatureType = DataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = DataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = DataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = DataFeatureStatus.New,
            FeatureType = DataFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = DataMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = DataUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataEnumConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataEnumConfiguration { DisplayName = "displayName", Value = "value" };

        string expectedDisplayName = "displayName";
        string expectedValue = "value";

        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataEnumConfiguration { DisplayName = "displayName", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataEnumConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataEnumConfiguration { DisplayName = "displayName", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataEnumConfiguration>(
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
        var model = new DataEnumConfiguration { DisplayName = "displayName", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataEnumConfiguration { DisplayName = "displayName", Value = "value" };

        DataEnumConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataFeatureStatusTest : TestBase
{
    [Theory]
    [InlineData(DataFeatureStatus.New)]
    [InlineData(DataFeatureStatus.Suspended)]
    [InlineData(DataFeatureStatus.Active)]
    public void Validation_Works(DataFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataFeatureStatus.New)]
    [InlineData(DataFeatureStatus.Suspended)]
    [InlineData(DataFeatureStatus.Active)]
    public void SerializationRoundtrip_Works(DataFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataFeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(DataFeatureType.Boolean)]
    [InlineData(DataFeatureType.Number)]
    [InlineData(DataFeatureType.Enum)]
    public void Validation_Works(DataFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataFeatureType.Boolean)]
    [InlineData(DataFeatureType.Number)]
    [InlineData(DataFeatureType.Enum)]
    public void SerializationRoundtrip_Works(DataFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataMeterTypeTest : TestBase
{
    [Theory]
    [InlineData(DataMeterType.None)]
    [InlineData(DataMeterType.Fluctuating)]
    [InlineData(DataMeterType.Incremental)]
    public void Validation_Works(DataMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataMeterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataMeterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataMeterType.None)]
    [InlineData(DataMeterType.Fluctuating)]
    [InlineData(DataMeterType.Incremental)]
    public void SerializationRoundtrip_Works(DataMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataMeterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataMeterType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataMeterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataMeterType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataUnitTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = DataUnitTransformationRound.Up,
        };

        double expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, DataUnitTransformationRound> expectedRound = DataUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, model.Divide);
        Assert.Equal(expectedFeatureUnits, model.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, model.FeatureUnitsPlural);
        Assert.Equal(expectedRound, model.Round);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = DataUnitTransformationRound.Up,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataUnitTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = DataUnitTransformationRound.Up,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataUnitTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, DataUnitTransformationRound> expectedRound = DataUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, deserialized.Divide);
        Assert.Equal(expectedFeatureUnits, deserialized.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, deserialized.FeatureUnitsPlural);
        Assert.Equal(expectedRound, deserialized.Round);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = DataUnitTransformationRound.Up,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = DataUnitTransformationRound.Up,
        };

        DataUnitTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataUnitTransformationRoundTest : TestBase
{
    [Theory]
    [InlineData(DataUnitTransformationRound.Up)]
    [InlineData(DataUnitTransformationRound.Down)]
    public void Validation_Works(DataUnitTransformationRound rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataUnitTransformationRound> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataUnitTransformationRound>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataUnitTransformationRound.Up)]
    [InlineData(DataUnitTransformationRound.Down)]
    public void SerializationRoundtrip_Works(DataUnitTransformationRound rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataUnitTransformationRound> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataUnitTransformationRound>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataUnitTransformationRound>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataUnitTransformationRound>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
