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
                Meter = new()
                {
                    Aggregation = new()
                    {
                        Function = DataMeterAggregationFunction.Sum,
                        Field = "field",
                    },
                    Filters =
                    [
                        new(
                            [
                                new()
                                {
                                    Field = "field",
                                    Operation = DataMeterFilterConditionOperation.Equals,
                                    Value = "value",
                                    Values = ["string"],
                                },
                            ]
                        ),
                    ],
                },
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
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = DataMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = DataMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
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
                Meter = new()
                {
                    Aggregation = new()
                    {
                        Function = DataMeterAggregationFunction.Sum,
                        Field = "field",
                    },
                    Filters =
                    [
                        new(
                            [
                                new()
                                {
                                    Field = "field",
                                    Operation = DataMeterFilterConditionOperation.Equals,
                                    Value = "value",
                                    Values = ["string"],
                                },
                            ]
                        ),
                    ],
                },
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
                Meter = new()
                {
                    Aggregation = new()
                    {
                        Function = DataMeterAggregationFunction.Sum,
                        Field = "field",
                    },
                    Filters =
                    [
                        new(
                            [
                                new()
                                {
                                    Field = "field",
                                    Operation = DataMeterFilterConditionOperation.Equals,
                                    Value = "value",
                                    Values = ["string"],
                                },
                            ]
                        ),
                    ],
                },
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
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = DataMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = DataMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
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
                Meter = new()
                {
                    Aggregation = new()
                    {
                        Function = DataMeterAggregationFunction.Sum,
                        Field = "field",
                    },
                    Filters =
                    [
                        new(
                            [
                                new()
                                {
                                    Field = "field",
                                    Operation = DataMeterFilterConditionOperation.Equals,
                                    Value = "value",
                                    Values = ["string"],
                                },
                            ]
                        ),
                    ],
                },
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
                Meter = new()
                {
                    Aggregation = new()
                    {
                        Function = DataMeterAggregationFunction.Sum,
                        Field = "field",
                    },
                    Filters =
                    [
                        new(
                            [
                                new()
                                {
                                    Field = "field",
                                    Operation = DataMeterFilterConditionOperation.Equals,
                                    Value = "value",
                                    Values = ["string"],
                                },
                            ]
                        ),
                    ],
                },
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
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = DataMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = DataMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
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
        DataMeter expectedMeter = new()
        {
            Aggregation = new() { Function = DataMeterAggregationFunction.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = DataMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };
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
        Assert.Equal(expectedMeter, model.Meter);
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
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = DataMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = DataMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
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
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = DataMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = DataMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
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
        DataMeter expectedMeter = new()
        {
            Aggregation = new() { Function = DataMeterAggregationFunction.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = DataMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };
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
        Assert.Equal(expectedMeter, deserialized.Meter);
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
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = DataMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = DataMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
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
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = DataMeterAggregationFunction.Sum,
                    Field = "field",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = DataMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
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

public class DataMeterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataMeter
        {
            Aggregation = new() { Function = DataMeterAggregationFunction.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = DataMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        DataMeterAggregation expectedAggregation = new()
        {
            Function = DataMeterAggregationFunction.Sum,
            Field = "field",
        };
        List<DataMeterFilter> expectedFilters =
        [
            new(
                [
                    new()
                    {
                        Field = "field",
                        Operation = DataMeterFilterConditionOperation.Equals,
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
        var model = new DataMeter
        {
            Aggregation = new() { Function = DataMeterAggregationFunction.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = DataMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMeter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataMeter
        {
            Aggregation = new() { Function = DataMeterAggregationFunction.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = DataMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMeter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DataMeterAggregation expectedAggregation = new()
        {
            Function = DataMeterAggregationFunction.Sum,
            Field = "field",
        };
        List<DataMeterFilter> expectedFilters =
        [
            new(
                [
                    new()
                    {
                        Field = "field",
                        Operation = DataMeterFilterConditionOperation.Equals,
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
        var model = new DataMeter
        {
            Aggregation = new() { Function = DataMeterAggregationFunction.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = DataMeterFilterConditionOperation.Equals,
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
        var model = new DataMeter
        {
            Aggregation = new() { Function = DataMeterAggregationFunction.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = DataMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        DataMeter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataMeterAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataMeterAggregation
        {
            Function = DataMeterAggregationFunction.Sum,
            Field = "field",
        };

        ApiEnum<string, DataMeterAggregationFunction> expectedFunction =
            DataMeterAggregationFunction.Sum;
        string expectedField = "field";

        Assert.Equal(expectedFunction, model.Function);
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataMeterAggregation
        {
            Function = DataMeterAggregationFunction.Sum,
            Field = "field",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMeterAggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataMeterAggregation
        {
            Function = DataMeterAggregationFunction.Sum,
            Field = "field",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMeterAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DataMeterAggregationFunction> expectedFunction =
            DataMeterAggregationFunction.Sum;
        string expectedField = "field";

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataMeterAggregation
        {
            Function = DataMeterAggregationFunction.Sum,
            Field = "field",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataMeterAggregation { Function = DataMeterAggregationFunction.Sum };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataMeterAggregation { Function = DataMeterAggregationFunction.Sum };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataMeterAggregation
        {
            Function = DataMeterAggregationFunction.Sum,

            Field = null,
        };

        Assert.Null(model.Field);
        Assert.True(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataMeterAggregation
        {
            Function = DataMeterAggregationFunction.Sum,

            Field = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataMeterAggregation
        {
            Function = DataMeterAggregationFunction.Sum,
            Field = "field",
        };

        DataMeterAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataMeterAggregationFunctionTest : TestBase
{
    [Theory]
    [InlineData(DataMeterAggregationFunction.Sum)]
    [InlineData(DataMeterAggregationFunction.Max)]
    [InlineData(DataMeterAggregationFunction.Min)]
    [InlineData(DataMeterAggregationFunction.Avg)]
    [InlineData(DataMeterAggregationFunction.Count)]
    [InlineData(DataMeterAggregationFunction.Unique)]
    public void Validation_Works(DataMeterAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataMeterAggregationFunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataMeterAggregationFunction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataMeterAggregationFunction.Sum)]
    [InlineData(DataMeterAggregationFunction.Max)]
    [InlineData(DataMeterAggregationFunction.Min)]
    [InlineData(DataMeterAggregationFunction.Avg)]
    [InlineData(DataMeterAggregationFunction.Count)]
    [InlineData(DataMeterAggregationFunction.Unique)]
    public void SerializationRoundtrip_Works(DataMeterAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataMeterAggregationFunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataMeterAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataMeterAggregationFunction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataMeterAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = DataMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        List<DataMeterFilterCondition> expectedConditions =
        [
            new()
            {
                Field = "field",
                Operation = DataMeterFilterConditionOperation.Equals,
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
        var model = new DataMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = DataMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMeterFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = DataMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMeterFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<DataMeterFilterCondition> expectedConditions =
        [
            new()
            {
                Field = "field",
                Operation = DataMeterFilterConditionOperation.Equals,
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
        var model = new DataMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = DataMeterFilterConditionOperation.Equals,
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
        var model = new DataMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = DataMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        DataMeterFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataMeterFilterConditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string expectedField = "field";
        ApiEnum<string, DataMeterFilterConditionOperation> expectedOperation =
            DataMeterFilterConditionOperation.Equals;
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
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMeterFilterCondition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataMeterFilterCondition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        ApiEnum<string, DataMeterFilterConditionOperation> expectedOperation =
            DataMeterFilterConditionOperation.Equals;
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
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,

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
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,

            Value = null,
            Values = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataMeterFilterCondition
        {
            Field = "field",
            Operation = DataMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        DataMeterFilterCondition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataMeterFilterConditionOperationTest : TestBase
{
    [Theory]
    [InlineData(DataMeterFilterConditionOperation.Equals)]
    [InlineData(DataMeterFilterConditionOperation.NotEquals)]
    [InlineData(DataMeterFilterConditionOperation.GreaterThan)]
    [InlineData(DataMeterFilterConditionOperation.GreaterThanOrEqual)]
    [InlineData(DataMeterFilterConditionOperation.LessThan)]
    [InlineData(DataMeterFilterConditionOperation.LessThanOrEqual)]
    [InlineData(DataMeterFilterConditionOperation.IsNull)]
    [InlineData(DataMeterFilterConditionOperation.IsNotNull)]
    [InlineData(DataMeterFilterConditionOperation.Contains)]
    [InlineData(DataMeterFilterConditionOperation.StartsWith)]
    [InlineData(DataMeterFilterConditionOperation.EndsWith)]
    [InlineData(DataMeterFilterConditionOperation.In)]
    public void Validation_Works(DataMeterFilterConditionOperation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataMeterFilterConditionOperation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataMeterFilterConditionOperation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataMeterFilterConditionOperation.Equals)]
    [InlineData(DataMeterFilterConditionOperation.NotEquals)]
    [InlineData(DataMeterFilterConditionOperation.GreaterThan)]
    [InlineData(DataMeterFilterConditionOperation.GreaterThanOrEqual)]
    [InlineData(DataMeterFilterConditionOperation.LessThan)]
    [InlineData(DataMeterFilterConditionOperation.LessThanOrEqual)]
    [InlineData(DataMeterFilterConditionOperation.IsNull)]
    [InlineData(DataMeterFilterConditionOperation.IsNotNull)]
    [InlineData(DataMeterFilterConditionOperation.Contains)]
    [InlineData(DataMeterFilterConditionOperation.StartsWith)]
    [InlineData(DataMeterFilterConditionOperation.EndsWith)]
    [InlineData(DataMeterFilterConditionOperation.In)]
    public void SerializationRoundtrip_Works(DataMeterFilterConditionOperation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataMeterFilterConditionOperation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataMeterFilterConditionOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataMeterFilterConditionOperation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataMeterFilterConditionOperation>
        >(json, ModelBase.SerializerOptions);

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
