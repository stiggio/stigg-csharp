using System;
using System.Collections.Generic;
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
                Aggregation = new() { Function = Function.Sum, Field = "field" },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = Operation.Equals,
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
        Meter expectedMeter = new()
        {
            Aggregation = new() { Function = Function.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = Operation.Equals,
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
                Aggregation = new() { Function = Function.Sum, Field = "field" },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = Operation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },
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
                Aggregation = new() { Function = Function.Sum, Field = "field" },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = Operation.Equals,
                                Value = "value",
                                Values = ["string"],
                            },
                        ]
                    ),
                ],
            },

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
                Aggregation = new() { Function = Function.Sum, Field = "field" },
                Filters =
                [
                    new(
                        [
                            new()
                            {
                                Field = "field",
                                Operation = Operation.Equals,
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

public class MeterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meter
        {
            Aggregation = new() { Function = Function.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = Operation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        Aggregation expectedAggregation = new() { Function = Function.Sum, Field = "field" };
        List<Filter> expectedFilters =
        [
            new(
                [
                    new()
                    {
                        Field = "field",
                        Operation = Operation.Equals,
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
        var model = new Meter
        {
            Aggregation = new() { Function = Function.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = Operation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meter
        {
            Aggregation = new() { Function = Function.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = Operation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meter>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Aggregation expectedAggregation = new() { Function = Function.Sum, Field = "field" };
        List<Filter> expectedFilters =
        [
            new(
                [
                    new()
                    {
                        Field = "field",
                        Operation = Operation.Equals,
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
        var model = new Meter
        {
            Aggregation = new() { Function = Function.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = Operation.Equals,
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
        var model = new Meter
        {
            Aggregation = new() { Function = Function.Sum, Field = "field" },
            Filters =
            [
                new(
                    [
                        new()
                        {
                            Field = "field",
                            Operation = Operation.Equals,
                            Value = "value",
                            Values = ["string"],
                        },
                    ]
                ),
            ],
        };

        Meter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AggregationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Aggregation { Function = Function.Sum, Field = "field" };

        ApiEnum<string, Function> expectedFunction = Function.Sum;
        string expectedField = "field";

        Assert.Equal(expectedFunction, model.Function);
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Aggregation { Function = Function.Sum, Field = "field" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Aggregation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Aggregation { Function = Function.Sum, Field = "field" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Aggregation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Function> expectedFunction = Function.Sum;
        string expectedField = "field";

        Assert.Equal(expectedFunction, deserialized.Function);
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Aggregation { Function = Function.Sum, Field = "field" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Aggregation { Function = Function.Sum };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Aggregation { Function = Function.Sum };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Aggregation
        {
            Function = Function.Sum,

            // Null should be interpreted as omitted for these properties
            Field = null,
        };

        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Aggregation
        {
            Function = Function.Sum,

            // Null should be interpreted as omitted for these properties
            Field = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Aggregation { Function = Function.Sum, Field = "field" };

        Aggregation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionTest : TestBase
{
    [Theory]
    [InlineData(Function.Sum)]
    [InlineData(Function.Max)]
    [InlineData(Function.Min)]
    [InlineData(Function.Avg)]
    [InlineData(Function.Count)]
    [InlineData(Function.Unique)]
    public void Validation_Works(Function rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Function> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Function>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Function.Sum)]
    [InlineData(Function.Max)]
    [InlineData(Function.Min)]
    [InlineData(Function.Avg)]
    [InlineData(Function.Count)]
    [InlineData(Function.Unique)]
    public void SerializationRoundtrip_Works(Function rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Function> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Function>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Function>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Function>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = Operation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        List<Condition> expectedConditions =
        [
            new()
            {
                Field = "field",
                Operation = Operation.Equals,
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
        var model = new Filter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = Operation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = Operation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Condition> expectedConditions =
        [
            new()
            {
                Field = "field",
                Operation = Operation.Equals,
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
        var model = new Filter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = Operation.Equals,
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
        var model = new Filter
        {
            Conditions =
            [
                new()
                {
                    Field = "field",
                    Operation = Operation.Equals,
                    Value = "value",
                    Values = ["string"],
                },
            ],
        };

        Filter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Condition
        {
            Field = "field",
            Operation = Operation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string expectedField = "field";
        ApiEnum<string, Operation> expectedOperation = Operation.Equals;
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
        var model = new Condition
        {
            Field = "field",
            Operation = Operation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Condition>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Condition
        {
            Field = "field",
            Operation = Operation.Equals,
            Value = "value",
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Condition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedField = "field";
        ApiEnum<string, Operation> expectedOperation = Operation.Equals;
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
        var model = new Condition
        {
            Field = "field",
            Operation = Operation.Equals,
            Value = "value",
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Condition { Field = "field", Operation = Operation.Equals };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Condition { Field = "field", Operation = Operation.Equals };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Condition
        {
            Field = "field",
            Operation = Operation.Equals,

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
        var model = new Condition
        {
            Field = "field",
            Operation = Operation.Equals,

            // Null should be interpreted as omitted for these properties
            Value = null,
            Values = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Condition
        {
            Field = "field",
            Operation = Operation.Equals,
            Value = "value",
            Values = ["string"],
        };

        Condition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OperationTest : TestBase
{
    [Theory]
    [InlineData(Operation.Equals)]
    [InlineData(Operation.NotEquals)]
    [InlineData(Operation.GreaterThan)]
    [InlineData(Operation.GreaterThanOrEqual)]
    [InlineData(Operation.LessThan)]
    [InlineData(Operation.LessThanOrEqual)]
    [InlineData(Operation.IsNull)]
    [InlineData(Operation.IsNotNull)]
    [InlineData(Operation.Contains)]
    [InlineData(Operation.StartsWith)]
    [InlineData(Operation.EndsWith)]
    [InlineData(Operation.In)]
    public void Validation_Works(Operation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operation> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operation.Equals)]
    [InlineData(Operation.NotEquals)]
    [InlineData(Operation.GreaterThan)]
    [InlineData(Operation.GreaterThanOrEqual)]
    [InlineData(Operation.LessThan)]
    [InlineData(Operation.LessThanOrEqual)]
    [InlineData(Operation.IsNull)]
    [InlineData(Operation.IsNotNull)]
    [InlineData(Operation.Contains)]
    [InlineData(Operation.StartsWith)]
    [InlineData(Operation.EndsWith)]
    [InlineData(Operation.In)]
    public void SerializationRoundtrip_Works(Operation rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operation> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operation>>(
            json,
            ModelBase.SerializerOptions
        );

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
