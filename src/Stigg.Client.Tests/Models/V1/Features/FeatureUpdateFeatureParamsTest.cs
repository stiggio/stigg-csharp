using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Features;

namespace Stigg.Client.Tests.Models.V1.Features;

public class FeatureUpdateFeatureParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FeatureUpdateFeatureParams
        {
            ID = "x",
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                    Field = "x",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "x",
                                Operation =
                                    FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
            },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<FeatureUpdateFeatureParamsEnumConfiguration> expectedEnumConfiguration =
        [
            new() { DisplayName = "displayName", Value = "value" },
        ];
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        FeatureUpdateFeatureParamsMeter expectedMeter = new()
        {
            Aggregation = new()
            {
                Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                Field = "x",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "x",
                            Operation =
                                FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };
        FeatureUpdateFeatureParamsUnitTransformation expectedUnitTransformation = new()
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
        };
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.EnumConfiguration);
        Assert.Equal(expectedEnumConfiguration.Count, parameters.EnumConfiguration.Count);
        for (int i = 0; i < expectedEnumConfiguration.Count; i++)
        {
            Assert.Equal(expectedEnumConfiguration[i], parameters.EnumConfiguration[i]);
        }
        Assert.Equal(expectedFeatureUnits, parameters.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, parameters.FeatureUnitsPlural);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedMeter, parameters.Meter);
        Assert.Equal(expectedUnitTransformation, parameters.UnitTransformation);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FeatureUpdateFeatureParams
        {
            ID = "x",
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
            },
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.EnumConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("enumConfiguration"));
        Assert.Null(parameters.FeatureUnits);
        Assert.False(parameters.RawBodyData.ContainsKey("featureUnits"));
        Assert.Null(parameters.FeatureUnitsPlural);
        Assert.False(parameters.RawBodyData.ContainsKey("featureUnitsPlural"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Meter);
        Assert.False(parameters.RawBodyData.ContainsKey("meter"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FeatureUpdateFeatureParams
        {
            ID = "x",
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
            },

            // Null should be interpreted as omitted for these properties
            Description = null,
            DisplayName = null,
            EnumConfiguration = null,
            FeatureUnits = null,
            FeatureUnitsPlural = null,
            Metadata = null,
            Meter = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.EnumConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("enumConfiguration"));
        Assert.Null(parameters.FeatureUnits);
        Assert.False(parameters.RawBodyData.ContainsKey("featureUnits"));
        Assert.Null(parameters.FeatureUnitsPlural);
        Assert.False(parameters.RawBodyData.ContainsKey("featureUnitsPlural"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Meter);
        Assert.False(parameters.RawBodyData.ContainsKey("meter"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FeatureUpdateFeatureParams
        {
            ID = "x",
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                    Field = "x",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "x",
                                Operation =
                                    FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.UnitTransformation);
        Assert.False(parameters.RawBodyData.ContainsKey("unitTransformation"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FeatureUpdateFeatureParams
        {
            ID = "x",
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                    Field = "x",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "x",
                                Operation =
                                    FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            UnitTransformation = null,
        };

        Assert.Null(parameters.UnitTransformation);
        Assert.True(parameters.RawBodyData.ContainsKey("unitTransformation"));
    }

    [Fact]
    public void Url_Works()
    {
        FeatureUpdateFeatureParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/features/x"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        FeatureUpdateFeatureParams parameters = new()
        {
            ID = "x",
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
        var parameters = new FeatureUpdateFeatureParams
        {
            ID = "x",
            Description = "description",
            DisplayName = "displayName",
            EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Meter = new()
            {
                Aggregation = new()
                {
                    Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                    Field = "x",
                },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "x",
                                Operation =
                                    FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
            UnitTransformation = new()
            {
                Divide = 0,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
            },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        FeatureUpdateFeatureParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FeatureUpdateFeatureParamsEnumConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureUpdateFeatureParamsEnumConfiguration
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
        var model = new FeatureUpdateFeatureParamsEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsEnumConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureUpdateFeatureParamsEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsEnumConfiguration>(
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
        var model = new FeatureUpdateFeatureParamsEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureUpdateFeatureParamsEnumConfiguration
        {
            DisplayName = "displayName",
            Value = "value",
        };

        FeatureUpdateFeatureParamsEnumConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureUpdateFeatureParamsMeterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeter
        {
            Aggregation = new()
            {
                Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                Field = "x",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "x",
                            Operation =
                                FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        FeatureUpdateFeatureParamsMeterAggregation expectedAggregation = new()
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
            Field = "x",
        };
        List<FeatureUpdateFeatureParamsMeterFilter> expectedFilters =
        [
            new(
                [
                    new()
                    {
                        Field = "x",
                        Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
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
        var model = new FeatureUpdateFeatureParamsMeter
        {
            Aggregation = new()
            {
                Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                Field = "x",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "x",
                            Operation =
                                FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsMeter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeter
        {
            Aggregation = new()
            {
                Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                Field = "x",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "x",
                            Operation =
                                FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsMeter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FeatureUpdateFeatureParamsMeterAggregation expectedAggregation = new()
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
            Field = "x",
        };
        List<FeatureUpdateFeatureParamsMeterFilter> expectedFilters =
        [
            new(
                [
                    new()
                    {
                        Field = "x",
                        Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
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
        var model = new FeatureUpdateFeatureParamsMeter
        {
            Aggregation = new()
            {
                Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                Field = "x",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "x",
                            Operation =
                                FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
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
        var model = new FeatureUpdateFeatureParamsMeter
        {
            Aggregation = new()
            {
                Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
                Field = "x",
            },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "x",
                            Operation =
                                FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        FeatureUpdateFeatureParamsMeter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureUpdateFeatureParamsMeterAggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
            Field = "x",
        };

        ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction> expectedFunction =
            FeatureUpdateFeatureParamsMeterAggregationFunction.Sum;
        string expectedField = "x";

        Assert.Equal(expectedFunction, model.Function);
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
            Field = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsMeterAggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
            Field = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsMeterAggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction> expectedFunction =
            FeatureUpdateFeatureParamsMeterAggregationFunction.Sum;
        string expectedField = "x";

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
            Field = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,

            // Null should be interpreted as omitted for these properties
            Field = null,
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,

            // Null should be interpreted as omitted for these properties
            Field = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterAggregation
        {
            Function = FeatureUpdateFeatureParamsMeterAggregationFunction.Sum,
            Field = "x",
        };

        FeatureUpdateFeatureParamsMeterAggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureUpdateFeatureParamsMeterAggregationFunctionTest : TestBase
{
    [Theory]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Sum)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Max)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Min)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Avg)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Count)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Unique)]
    public void Validation_Works(FeatureUpdateFeatureParamsMeterAggregationFunction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Sum)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Max)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Min)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Avg)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Count)]
    [InlineData(FeatureUpdateFeatureParamsMeterAggregationFunction.Unique)]
    public void SerializationRoundtrip_Works(
        FeatureUpdateFeatureParamsMeterAggregationFunction rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsMeterAggregationFunction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureUpdateFeatureParamsMeterFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "x",
                    Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        List<FeatureUpdateFeatureParamsMeterFilterCondition> expectedConditions =
        [
            new()
            {
                Field = "x",
                Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
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
        var model = new FeatureUpdateFeatureParamsMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "x",
                    Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsMeterFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "x",
                    Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsMeterFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FeatureUpdateFeatureParamsMeterFilterCondition> expectedConditions =
        [
            new()
            {
                Field = "x",
                Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
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
        var model = new FeatureUpdateFeatureParamsMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "x",
                    Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
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
        var model = new FeatureUpdateFeatureParamsMeterFilter
        {
            Conditions =
            [
                new()
                {
                    Field = "x",
                    Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        FeatureUpdateFeatureParamsMeterFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureUpdateFeatureParamsMeterFilterConditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string expectedField = "x";
        ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation> expectedOperation =
            FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals;
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
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureUpdateFeatureParamsMeterFilterCondition>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FeatureUpdateFeatureParamsMeterFilterCondition>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedField = "x";
        ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation> expectedOperation =
            FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals;
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
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,

            // Null should be interpreted as omitted for these properties
            Value = null,
            Values = null,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,

            // Null should be interpreted as omitted for these properties
            Value = null,
            Values = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureUpdateFeatureParamsMeterFilterCondition
        {
            Field = "x",
            Operation = FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals,
            Value = "value",
            Values = ["string"],
        };

        FeatureUpdateFeatureParamsMeterFilterCondition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureUpdateFeatureParamsMeterFilterConditionOperationTest : TestBase
{
    [Theory]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.NotEquals)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.GreaterThan)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.GreaterThanOrEqual)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.LessThan)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.LessThanOrEqual)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.IsNull)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.IsNotNull)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.Contains)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.StartsWith)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.EndsWith)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.In)]
    public void Validation_Works(FeatureUpdateFeatureParamsMeterFilterConditionOperation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.Equals)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.NotEquals)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.GreaterThan)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.GreaterThanOrEqual)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.LessThan)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.LessThanOrEqual)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.IsNull)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.IsNotNull)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.Contains)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.StartsWith)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.EndsWith)]
    [InlineData(FeatureUpdateFeatureParamsMeterFilterConditionOperation.In)]
    public void SerializationRoundtrip_Works(
        FeatureUpdateFeatureParamsMeterFilterConditionOperation rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsMeterFilterConditionOperation>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureUpdateFeatureParamsUnitTransformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureUpdateFeatureParamsUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
        };

        long expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound> expectedRound =
            FeatureUpdateFeatureParamsUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, model.Divide);
        Assert.Equal(expectedFeatureUnits, model.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, model.FeatureUnitsPlural);
        Assert.Equal(expectedRound, model.Round);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureUpdateFeatureParamsUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsUnitTransformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureUpdateFeatureParamsUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureUpdateFeatureParamsUnitTransformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDivide = 0;
        string expectedFeatureUnits = "featureUnits";
        string expectedFeatureUnitsPlural = "featureUnitsPlural";
        ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound> expectedRound =
            FeatureUpdateFeatureParamsUnitTransformationRound.Up;

        Assert.Equal(expectedDivide, deserialized.Divide);
        Assert.Equal(expectedFeatureUnits, deserialized.FeatureUnits);
        Assert.Equal(expectedFeatureUnitsPlural, deserialized.FeatureUnitsPlural);
        Assert.Equal(expectedRound, deserialized.Round);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureUpdateFeatureParamsUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FeatureUpdateFeatureParamsUnitTransformation { Divide = 0 };

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
        var model = new FeatureUpdateFeatureParamsUnitTransformation { Divide = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FeatureUpdateFeatureParamsUnitTransformation
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
        var model = new FeatureUpdateFeatureParamsUnitTransformation
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
        var model = new FeatureUpdateFeatureParamsUnitTransformation
        {
            Divide = 0,
            FeatureUnits = "featureUnits",
            FeatureUnitsPlural = "featureUnitsPlural",
            Round = FeatureUpdateFeatureParamsUnitTransformationRound.Up,
        };

        FeatureUpdateFeatureParamsUnitTransformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureUpdateFeatureParamsUnitTransformationRoundTest : TestBase
{
    [Theory]
    [InlineData(FeatureUpdateFeatureParamsUnitTransformationRound.Up)]
    [InlineData(FeatureUpdateFeatureParamsUnitTransformationRound.Down)]
    public void Validation_Works(FeatureUpdateFeatureParamsUnitTransformationRound rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureUpdateFeatureParamsUnitTransformationRound.Up)]
    [InlineData(FeatureUpdateFeatureParamsUnitTransformationRound.Down)]
    public void SerializationRoundtrip_Works(
        FeatureUpdateFeatureParamsUnitTransformationRound rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureUpdateFeatureParamsUnitTransformationRound>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
