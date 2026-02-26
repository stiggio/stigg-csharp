using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Features;

namespace Stigg.Client.Tests.Models.V1.Features;

public class FeatureCreateFeatureParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FeatureCreateFeatureParams
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureType = FeatureType.Boolean,
            Description = "description",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureStatus.New,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = MeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = Round.Up,
            },
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;
        string expectedDescription = "description";
        List<EnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, FeatureStatus> expectedFeatureStatus = FeatureStatus.New;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, MeterType> expectedMeterType = MeterType.None;
        UnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = Round.Up,
        };

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedFeatureType, parameters.FeatureType);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.EnumConfiguration);
        Assert.Equal(expectedEnumConfiguration.Count, parameters.EnumConfiguration.Count);
        for (int i = 0; i < expectedEnumConfiguration.Count; i++)
        {
            Assert.Equal(expectedEnumConfiguration[i], parameters.EnumConfiguration[i]);
        }
        Assert.Equal(expectedFeatureStatus, parameters.FeatureStatus);
        Assert.Equal(expectedFeatureUnits, parameters.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, parameters.FeatureUnitsPlural);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedMeterType, parameters.MeterType);
        Assert.Equal(expectedUnitTransformation, parameters.UnitTransformation);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FeatureCreateFeatureParams
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureType = FeatureType.Boolean,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = Round.Up,
            },
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnumConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("enumConfiguration"));
        Assert.Null(parameters.FeatureStatus);
        Assert.False(parameters.RawBodyData.ContainsKey("featureStatus"));
        Assert.Null(parameters.FeatureUnits);
        Assert.False(parameters.RawBodyData.ContainsKey("featureUnits"));
        Assert.Null(parameters.FeatureUnitsPlural);
        Assert.False(parameters.RawBodyData.ContainsKey("featureUnitsPlural"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.MeterType);
        Assert.False(parameters.RawBodyData.ContainsKey("meterType"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FeatureCreateFeatureParams
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureType = FeatureType.Boolean,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = Round.Up,
            },

            // Null should be interpreted as omitted for these properties
            Description = null,
            EnumConfiguration = null,
            FeatureStatus = null,
            FeatureUnits = null,
            FeatureUnitsPlural = null,
            Metadata = null,
            MeterType = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EnumConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("enumConfiguration"));
        Assert.Null(parameters.FeatureStatus);
        Assert.False(parameters.RawBodyData.ContainsKey("featureStatus"));
        Assert.Null(parameters.FeatureUnits);
        Assert.False(parameters.RawBodyData.ContainsKey("featureUnits"));
        Assert.Null(parameters.FeatureUnitsPlural);
        Assert.False(parameters.RawBodyData.ContainsKey("featureUnitsPlural"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.MeterType);
        Assert.False(parameters.RawBodyData.ContainsKey("meterType"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FeatureCreateFeatureParams
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureType = FeatureType.Boolean,
            Description = "description",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureStatus.New,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = MeterType.None,
        };

        Assert.Null(parameters.UnitTransformation);
        Assert.False(parameters.RawBodyData.ContainsKey("unitTransformation"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FeatureCreateFeatureParams
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureType = FeatureType.Boolean,
            Description = "description",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureStatus.New,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = MeterType.None,

            UnitTransformation = null,
        };

        Assert.Null(parameters.UnitTransformation);
        Assert.True(parameters.RawBodyData.ContainsKey("unitTransformation"));
    }

    [Fact]
    public void Url_Works()
    {
        FeatureCreateFeatureParams parameters = new()
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureType = FeatureType.Boolean,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/features"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FeatureCreateFeatureParams
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureType = FeatureType.Boolean,
            Description = "description",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureStatus.New,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MeterType = MeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = Round.Up,
            },
        };

        FeatureCreateFeatureParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureType.Boolean)]
    [InlineData(FeatureType.Number)]
    [InlineData(FeatureType.Enum)]
    public void Validation_Works(FeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureType.Boolean)]
    [InlineData(FeatureType.Number)]
    [InlineData(FeatureType.Enum)]
    public void SerializationRoundtrip_Works(FeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EnumConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnumConfiguration { DisplayName = "displayName", Value = "value" };

        string expectedDisplayName = "displayName";
        string expectedValue = "value";

        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnumConfiguration { DisplayName = "displayName", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnumConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EnumConfiguration { DisplayName = "displayName", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnumConfiguration>(
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
        var model = new EnumConfiguration { DisplayName = "displayName", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EnumConfiguration { DisplayName = "displayName", Value = "value" };

        EnumConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureStatusTest : TestBase
{
    [Theory]
    [InlineData(FeatureStatus.New)]
    [InlineData(FeatureStatus.Suspended)]
    [InlineData(FeatureStatus.Active)]
    public void Validation_Works(FeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureStatus.New)]
    [InlineData(FeatureStatus.Suspended)]
    [InlineData(FeatureStatus.Active)]
    public void SerializationRoundtrip_Works(FeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MeterTypeTest : TestBase
{
    [Theory]
    [InlineData(MeterType.None)]
    [InlineData(MeterType.Fluctuating)]
    [InlineData(MeterType.Incremental)]
    public void Validation_Works(MeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MeterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MeterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MeterType.None)]
    [InlineData(MeterType.Fluctuating)]
    [InlineData(MeterType.Incremental)]
    public void SerializationRoundtrip_Works(MeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MeterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MeterType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MeterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MeterType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnitTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = Round.Up,
        };

        long expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, Round> expectedRound = Round.Up;

        Assert.Equal(expectedDivide, model.Divide);
        Assert.Equal(expectedFeatureUnits, model.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, model.FeatureUnitsPlural);
        Assert.Equal(expectedRound, model.Round);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = Round.Up,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnitTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = Round.Up,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnitTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, Round> expectedRound = Round.Up;

        Assert.Equal(expectedDivide, deserialized.Divide);
        Assert.Equal(expectedFeatureUnits, deserialized.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, deserialized.FeatureUnitsPlural);
        Assert.Equal(expectedRound, deserialized.Round);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = Round.Up,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnitTransformation { Divide = 0 };

        Assert.Null(model.FeatureUnits);
        Assert.False(model.RawData.ContainsKey("featureUnits"));
        Assert.Null(model.FeatureUnitsPlural);
        Assert.False(model.RawData.ContainsKey("featureUnitsPlural"));
        Assert.Null(model.Round);
        Assert.False(model.RawData.ContainsKey("round"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnitTransformation { Divide = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnitTransformation
        {
            Divide = 0,

            // Null should be interpreted as omitted for these properties
            FeatureUnits = null,
            FeatureUnitsPlural = null,
            Round = null,
        };

        Assert.Null(model.FeatureUnits);
        Assert.False(model.RawData.ContainsKey("featureUnits"));
        Assert.Null(model.FeatureUnitsPlural);
        Assert.False(model.RawData.ContainsKey("featureUnitsPlural"));
        Assert.Null(model.Round);
        Assert.False(model.RawData.ContainsKey("round"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnitTransformation
        {
            Divide = 0,

            // Null should be interpreted as omitted for these properties
            FeatureUnits = null,
            FeatureUnitsPlural = null,
            Round = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = Round.Up,
        };

        UnitTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoundTest : TestBase
{
    [Theory]
    [InlineData(Round.Up)]
    [InlineData(Round.Down)]
    public void Validation_Works(Round rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Round> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Round>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Round.Up)]
    [InlineData(Round.Down)]
    public void SerializationRoundtrip_Works(Round rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Round> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Round>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Round>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Round>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
