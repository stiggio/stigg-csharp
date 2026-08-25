using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Features;

namespace Stigg.Client.Tests.Models.V1.Features;

public class FeatureListFeaturesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
            FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation =
                                    FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            MeterType = FeatureListFeaturesResponseMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<FeatureListFeaturesResponseEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, FeatureListFeaturesResponseFeatureStatus> expectedFeatureStatus =
            FeatureListFeaturesResponseFeatureStatus.New;
        ApiEnum<string, FeatureListFeaturesResponseFeatureType> expectedFeatureType =
            FeatureListFeaturesResponseFeatureType.Boolean;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        FeatureListFeaturesResponseMeter expectedMeter = new()
        {
            Aggregation = new()
            {
                Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                Field = "field",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation =
                                FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };
        ApiEnum<string, FeatureListFeaturesResponseMeterType> expectedMeterType =
            FeatureListFeaturesResponseMeterType.None;
        FeatureListFeaturesResponseUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
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
        Assert.Equal(expectedMeter, model.Meter);
        Assert.Equal(expectedMeterType, model.MeterType);
        Assert.Equal(expectedUnitTransformation, model.UnitTransformation);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
            FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation =
                                    FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            MeterType = FeatureListFeaturesResponseMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureListFeaturesResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
            FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation =
                                    FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            MeterType = FeatureListFeaturesResponseMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<FeatureListFeaturesResponseEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        ApiEnum<string, FeatureListFeaturesResponseFeatureStatus> expectedFeatureStatus =
            FeatureListFeaturesResponseFeatureStatus.New;
        ApiEnum<string, FeatureListFeaturesResponseFeatureType> expectedFeatureType =
            FeatureListFeaturesResponseFeatureType.Boolean;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        FeatureListFeaturesResponseMeter expectedMeter = new()
        {
            Aggregation = new()
            {
                Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                Field = "field",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation =
                                FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };
        ApiEnum<string, FeatureListFeaturesResponseMeterType> expectedMeterType =
            FeatureListFeaturesResponseMeterType.None;
        FeatureListFeaturesResponseUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
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
        Assert.Equal(expectedMeter, deserialized.Meter);
        Assert.Equal(expectedMeterType, deserialized.MeterType);
        Assert.Equal(expectedUnitTransformation, deserialized.UnitTransformation);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureListFeaturesResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
            FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation =
                                    FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            MeterType = FeatureListFeaturesResponseMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureListFeaturesResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
            FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation =
                                    FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            MeterType = FeatureListFeaturesResponseMeterType.None,
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        FeatureListFeaturesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureListFeaturesResponseEnumConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseEnumConfiguration
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
        var model = new FeatureListFeaturesResponseEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponseEnumConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureListFeaturesResponseEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponseEnumConfiguration>(
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
        var model = new FeatureListFeaturesResponseEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureListFeaturesResponseEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        FeatureListFeaturesResponseEnumConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureListFeaturesResponseFeatureStatusTest : TestBase
{
    [Theory]
    [InlineData(FeatureListFeaturesResponseFeatureStatus.New)]
    [InlineData(FeatureListFeaturesResponseFeatureStatus.Suspended)]
    [InlineData(FeatureListFeaturesResponseFeatureStatus.Active)]
    public void Validation_Works(FeatureListFeaturesResponseFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseFeatureStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseFeatureStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureListFeaturesResponseFeatureStatus.New)]
    [InlineData(FeatureListFeaturesResponseFeatureStatus.Suspended)]
    [InlineData(FeatureListFeaturesResponseFeatureStatus.Active)]
    public void SerializationRoundtrip_Works(FeatureListFeaturesResponseFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseFeatureStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseFeatureStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseFeatureStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseFeatureStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureListFeaturesResponseFeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureListFeaturesResponseFeatureType.Boolean)]
    [InlineData(FeatureListFeaturesResponseFeatureType.Number)]
    [InlineData(FeatureListFeaturesResponseFeatureType.Enum)]
    public void Validation_Works(FeatureListFeaturesResponseFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseFeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureListFeaturesResponseFeatureType.Boolean)]
    [InlineData(FeatureListFeaturesResponseFeatureType.Number)]
    [InlineData(FeatureListFeaturesResponseFeatureType.Enum)]
    public void SerializationRoundtrip_Works(FeatureListFeaturesResponseFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseFeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureListFeaturesResponseMeterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseMeter
        {
            Aggregation = new()
            {
                Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                Field = "field",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation =
                                FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        FeatureListFeaturesResponseMeterAggregation expectedAggregation = new()
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
            Field = "field",
        };
        List<FeatureListFeaturesResponseMeterFilter> expectedFilters =
        [
            new(
                [
                    new()
                    {
                        Field = "field",
                        Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                        Value = "value",
                        Values = ["string"],
                    },
                ]
            ),
        ];

        Assert.Equal(expectedAggregation, model.Aggregation);
        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseMeter
        {
            Aggregation = new()
            {
                Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                Field = "field",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation =
                                FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponseMeter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureListFeaturesResponseMeter
        {
            Aggregation = new()
            {
                Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                Field = "field",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation =
                                FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponseMeter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FeatureListFeaturesResponseMeterAggregation expectedAggregation = new()
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
            Field = "field",
        };
        List<FeatureListFeaturesResponseMeterFilter> expectedFilters =
        [
            new(
                [
                    new()
                    {
                        Field = "field",
                        Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                        Value = "value",
                        Values = ["string"],
                    },
                ]
            ),
        ];

        Assert.Equal(expectedAggregation, deserialized.Aggregation);
        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureListFeaturesResponseMeter
        {
            Aggregation = new()
            {
                Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                Field = "field",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation =
                                FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureListFeaturesResponseMeter
        {
            Aggregation = new()
            {
                Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
                Field = "field",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation =
                                FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        FeatureListFeaturesResponseMeter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureListFeaturesResponseMeterAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
            Field = "field",
        };

        ApiEnum<string, FeatureListFeaturesResponseMeterAggregationFunction> expectedFunction =
            FeatureListFeaturesResponseMeterAggregationFunction.Sum;
        string expectedField = "field";

        Assert.Equal(expectedFunction, model.Function);
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
            Field = "field",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponseMeterAggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
            Field = "field",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponseMeterAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FeatureListFeaturesResponseMeterAggregationFunction> expectedFunction =
            FeatureListFeaturesResponseMeterAggregationFunction.Sum;
        string expectedField = "field";

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
            Field = "field",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,

            Field = null,
        };

        Assert.Null(model.Field);
        Assert.True(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,

            Field = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureListFeaturesResponseMeterAggregation
        {
            Function = FeatureListFeaturesResponseMeterAggregationFunction.Sum,
            Field = "field",
        };

        FeatureListFeaturesResponseMeterAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureListFeaturesResponseMeterAggregationFunctionTest : TestBase
{
    [Theory]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Sum)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Max)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Min)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Avg)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Count)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Unique)]
    public void Validation_Works(FeatureListFeaturesResponseMeterAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseMeterAggregationFunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Sum)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Max)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Min)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Avg)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Count)]
    [InlineData(FeatureListFeaturesResponseMeterAggregationFunction.Unique)]
    public void SerializationRoundtrip_Works(
        FeatureListFeaturesResponseMeterAggregationFunction rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseMeterAggregationFunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureListFeaturesResponseMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        List<FeatureListFeaturesResponseMeterFilterCondition> expectedConditions =
        [
            new()
            {
                Field = "field",
                Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                Value = "value",
                Values = ["string"],
            },
        ];

        Assert.Equal(expectedConditions.Count, model.Conditions.Count);
        for (int i = 0; i < expectedConditions.Count; i++)
        {
            Assert.Equal(expectedConditions[i], model.Conditions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponseMeterFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesResponseMeterFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FeatureListFeaturesResponseMeterFilterCondition> expectedConditions =
        [
            new()
            {
                Field = "field",
                Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                Value = "value",
                Values = ["string"],
            },
        ];

        Assert.Equal(expectedConditions.Count, deserialized.Conditions.Count);
        for (int i = 0; i < expectedConditions.Count; i++)
        {
            Assert.Equal(expectedConditions[i], deserialized.Conditions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        FeatureListFeaturesResponseMeterFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureListFeaturesResponseMeterFilterConditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string expectedField = "field";
        ApiEnum<
            string,
            FeatureListFeaturesResponseMeterFilterConditionOperation
        > expectedOperation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals;
        string expectedValue = "value";
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedOperation, model.Operation);
        Assert.Equal(expectedValue, model.Value);
        Assert.NotNull(model.Values);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureListFeaturesResponseMeterFilterCondition>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureListFeaturesResponseMeterFilterCondition>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        ApiEnum<
            string,
            FeatureListFeaturesResponseMeterFilterConditionOperation
        > expectedOperation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals;
        string expectedValue = "value";
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedOperation, deserialized.Operation);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.NotNull(deserialized.Values);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,

            Value = null,
            Values = null,
        };

        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
        Assert.Null(model.Values);
        Assert.True(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,

            Value = null,
            Values = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureListFeaturesResponseMeterFilterCondition
        {
            Field = "field",
            Operation = FeatureListFeaturesResponseMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        FeatureListFeaturesResponseMeterFilterCondition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureListFeaturesResponseMeterFilterConditionOperationTest : TestBase
{
    [Theory]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.Equals)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.NotEquals)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.GreaterThan)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.GreaterThanOrEqual)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.LessThan)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.LessThanOrEqual)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.IsNull)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.IsNotNull)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.Contains)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.StartsWith)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.EndsWith)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.In)]
    public void Validation_Works(FeatureListFeaturesResponseMeterFilterConditionOperation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseMeterFilterConditionOperation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterFilterConditionOperation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.Equals)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.NotEquals)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.GreaterThan)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.GreaterThanOrEqual)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.LessThan)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.LessThanOrEqual)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.IsNull)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.IsNotNull)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.Contains)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.StartsWith)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.EndsWith)]
    [InlineData(FeatureListFeaturesResponseMeterFilterConditionOperation.In)]
    public void SerializationRoundtrip_Works(
        FeatureListFeaturesResponseMeterFilterConditionOperation rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseMeterFilterConditionOperation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterFilterConditionOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterFilterConditionOperation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterFilterConditionOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureListFeaturesResponseMeterTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureListFeaturesResponseMeterType.None)]
    [InlineData(FeatureListFeaturesResponseMeterType.Fluctuating)]
    [InlineData(FeatureListFeaturesResponseMeterType.Incremental)]
    public void Validation_Works(FeatureListFeaturesResponseMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseMeterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureListFeaturesResponseMeterType.None)]
    [InlineData(FeatureListFeaturesResponseMeterType.Fluctuating)]
    [InlineData(FeatureListFeaturesResponseMeterType.Incremental)]
    public void SerializationRoundtrip_Works(FeatureListFeaturesResponseMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseMeterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseMeterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureListFeaturesResponseUnitTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
        };

        double expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound> expectedRound =
            FeatureListFeaturesResponseUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, model.Divide);
        Assert.Equal(expectedFeatureUnits, model.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, model.FeatureUnitsPlural);
        Assert.Equal(expectedRound, model.Round);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureListFeaturesResponseUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureListFeaturesResponseUnitTransformation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureListFeaturesResponseUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureListFeaturesResponseUnitTransformation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound> expectedRound =
            FeatureListFeaturesResponseUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, deserialized.Divide);
        Assert.Equal(expectedFeatureUnits, deserialized.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, deserialized.FeatureUnitsPlural);
        Assert.Equal(expectedRound, deserialized.Round);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureListFeaturesResponseUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureListFeaturesResponseUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
        };

        FeatureListFeaturesResponseUnitTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureListFeaturesResponseUnitTransformationRoundTest : TestBase
{
    [Theory]
    [InlineData(FeatureListFeaturesResponseUnitTransformationRound.Up)]
    [InlineData(FeatureListFeaturesResponseUnitTransformationRound.Down)]
    public void Validation_Works(FeatureListFeaturesResponseUnitTransformationRound rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureListFeaturesResponseUnitTransformationRound.Up)]
    [InlineData(FeatureListFeaturesResponseUnitTransformationRound.Down)]
    public void SerializationRoundtrip_Works(
        FeatureListFeaturesResponseUnitTransformationRound rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesResponseUnitTransformationRound>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
