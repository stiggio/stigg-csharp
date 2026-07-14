using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events;

namespace Stigg.Client.Tests.Models.V1.Events;

public class EventEstimateCostResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventEstimateCostResponse
        {
            Data = new()
            {
                Estimates =
                [
                    new()
                    {
                        BalanceAfterEstimate = 0,
                        Breakdown =
                        [
                            new()
                            {
                                Cost = 0,
                                FeatureID = "featureId",
                                WarningCode = WarningCode.UnsupportedAggregation,
                            },
                        ],
                        CurrencyID = "currencyId",
                        CurrentBalance = 0,
                        EstimatedCost = 0,
                        WouldOverdraft = true,
                    },
                ],
                Warnings = [Warning.ResourceScopedSubscriptionExists],
            },
        };

        Data expectedData = new()
        {
            Estimates =
            [
                new()
                {
                    BalanceAfterEstimate = 0,
                    Breakdown =
                    [
                        new()
                        {
                            Cost = 0,
                            FeatureID = "featureId",
                            WarningCode = WarningCode.UnsupportedAggregation,
                        },
                    ],
                    CurrencyID = "currencyId",
                    CurrentBalance = 0,
                    EstimatedCost = 0,
                    WouldOverdraft = true,
                },
            ],
            Warnings = [Warning.ResourceScopedSubscriptionExists],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventEstimateCostResponse
        {
            Data = new()
            {
                Estimates =
                [
                    new()
                    {
                        BalanceAfterEstimate = 0,
                        Breakdown =
                        [
                            new()
                            {
                                Cost = 0,
                                FeatureID = "featureId",
                                WarningCode = WarningCode.UnsupportedAggregation,
                            },
                        ],
                        CurrencyID = "currencyId",
                        CurrentBalance = 0,
                        EstimatedCost = 0,
                        WouldOverdraft = true,
                    },
                ],
                Warnings = [Warning.ResourceScopedSubscriptionExists],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventEstimateCostResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventEstimateCostResponse
        {
            Data = new()
            {
                Estimates =
                [
                    new()
                    {
                        BalanceAfterEstimate = 0,
                        Breakdown =
                        [
                            new()
                            {
                                Cost = 0,
                                FeatureID = "featureId",
                                WarningCode = WarningCode.UnsupportedAggregation,
                            },
                        ],
                        CurrencyID = "currencyId",
                        CurrentBalance = 0,
                        EstimatedCost = 0,
                        WouldOverdraft = true,
                    },
                ],
                Warnings = [Warning.ResourceScopedSubscriptionExists],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventEstimateCostResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Estimates =
            [
                new()
                {
                    BalanceAfterEstimate = 0,
                    Breakdown =
                    [
                        new()
                        {
                            Cost = 0,
                            FeatureID = "featureId",
                            WarningCode = WarningCode.UnsupportedAggregation,
                        },
                    ],
                    CurrencyID = "currencyId",
                    CurrentBalance = 0,
                    EstimatedCost = 0,
                    WouldOverdraft = true,
                },
            ],
            Warnings = [Warning.ResourceScopedSubscriptionExists],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventEstimateCostResponse
        {
            Data = new()
            {
                Estimates =
                [
                    new()
                    {
                        BalanceAfterEstimate = 0,
                        Breakdown =
                        [
                            new()
                            {
                                Cost = 0,
                                FeatureID = "featureId",
                                WarningCode = WarningCode.UnsupportedAggregation,
                            },
                        ],
                        CurrencyID = "currencyId",
                        CurrentBalance = 0,
                        EstimatedCost = 0,
                        WouldOverdraft = true,
                    },
                ],
                Warnings = [Warning.ResourceScopedSubscriptionExists],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventEstimateCostResponse
        {
            Data = new()
            {
                Estimates =
                [
                    new()
                    {
                        BalanceAfterEstimate = 0,
                        Breakdown =
                        [
                            new()
                            {
                                Cost = 0,
                                FeatureID = "featureId",
                                WarningCode = WarningCode.UnsupportedAggregation,
                            },
                        ],
                        CurrencyID = "currencyId",
                        CurrentBalance = 0,
                        EstimatedCost = 0,
                        WouldOverdraft = true,
                    },
                ],
                Warnings = [Warning.ResourceScopedSubscriptionExists],
            },
        };

        EventEstimateCostResponse copied = new(model);

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
            Estimates =
            [
                new()
                {
                    BalanceAfterEstimate = 0,
                    Breakdown =
                    [
                        new()
                        {
                            Cost = 0,
                            FeatureID = "featureId",
                            WarningCode = WarningCode.UnsupportedAggregation,
                        },
                    ],
                    CurrencyID = "currencyId",
                    CurrentBalance = 0,
                    EstimatedCost = 0,
                    WouldOverdraft = true,
                },
            ],
            Warnings = [Warning.ResourceScopedSubscriptionExists],
        };

        List<Estimate> expectedEstimates =
        [
            new()
            {
                BalanceAfterEstimate = 0,
                Breakdown =
                [
                    new()
                    {
                        Cost = 0,
                        FeatureID = "featureId",
                        WarningCode = WarningCode.UnsupportedAggregation,
                    },
                ],
                CurrencyID = "currencyId",
                CurrentBalance = 0,
                EstimatedCost = 0,
                WouldOverdraft = true,
            },
        ];
        List<ApiEnum<string, Warning>> expectedWarnings =
        [
            Warning.ResourceScopedSubscriptionExists,
        ];

        Assert.Equal(expectedEstimates.Count, model.Estimates.Count);
        for (int i = 0; i < expectedEstimates.Count; i++)
        {
            Assert.Equal(expectedEstimates[i], model.Estimates[i]);
        }
        Assert.Equal(expectedWarnings.Count, model.Warnings.Count);
        for (int i = 0; i < expectedWarnings.Count; i++)
        {
            Assert.Equal(expectedWarnings[i], model.Warnings[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Estimates =
            [
                new()
                {
                    BalanceAfterEstimate = 0,
                    Breakdown =
                    [
                        new()
                        {
                            Cost = 0,
                            FeatureID = "featureId",
                            WarningCode = WarningCode.UnsupportedAggregation,
                        },
                    ],
                    CurrencyID = "currencyId",
                    CurrentBalance = 0,
                    EstimatedCost = 0,
                    WouldOverdraft = true,
                },
            ],
            Warnings = [Warning.ResourceScopedSubscriptionExists],
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
            Estimates =
            [
                new()
                {
                    BalanceAfterEstimate = 0,
                    Breakdown =
                    [
                        new()
                        {
                            Cost = 0,
                            FeatureID = "featureId",
                            WarningCode = WarningCode.UnsupportedAggregation,
                        },
                    ],
                    CurrencyID = "currencyId",
                    CurrentBalance = 0,
                    EstimatedCost = 0,
                    WouldOverdraft = true,
                },
            ],
            Warnings = [Warning.ResourceScopedSubscriptionExists],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Estimate> expectedEstimates =
        [
            new()
            {
                BalanceAfterEstimate = 0,
                Breakdown =
                [
                    new()
                    {
                        Cost = 0,
                        FeatureID = "featureId",
                        WarningCode = WarningCode.UnsupportedAggregation,
                    },
                ],
                CurrencyID = "currencyId",
                CurrentBalance = 0,
                EstimatedCost = 0,
                WouldOverdraft = true,
            },
        ];
        List<ApiEnum<string, Warning>> expectedWarnings =
        [
            Warning.ResourceScopedSubscriptionExists,
        ];

        Assert.Equal(expectedEstimates.Count, deserialized.Estimates.Count);
        for (int i = 0; i < expectedEstimates.Count; i++)
        {
            Assert.Equal(expectedEstimates[i], deserialized.Estimates[i]);
        }
        Assert.Equal(expectedWarnings.Count, deserialized.Warnings.Count);
        for (int i = 0; i < expectedWarnings.Count; i++)
        {
            Assert.Equal(expectedWarnings[i], deserialized.Warnings[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Estimates =
            [
                new()
                {
                    BalanceAfterEstimate = 0,
                    Breakdown =
                    [
                        new()
                        {
                            Cost = 0,
                            FeatureID = "featureId",
                            WarningCode = WarningCode.UnsupportedAggregation,
                        },
                    ],
                    CurrencyID = "currencyId",
                    CurrentBalance = 0,
                    EstimatedCost = 0,
                    WouldOverdraft = true,
                },
            ],
            Warnings = [Warning.ResourceScopedSubscriptionExists],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Estimates =
            [
                new()
                {
                    BalanceAfterEstimate = 0,
                    Breakdown =
                    [
                        new()
                        {
                            Cost = 0,
                            FeatureID = "featureId",
                            WarningCode = WarningCode.UnsupportedAggregation,
                        },
                    ],
                    CurrencyID = "currencyId",
                    CurrentBalance = 0,
                    EstimatedCost = 0,
                    WouldOverdraft = true,
                },
            ],
            Warnings = [Warning.ResourceScopedSubscriptionExists],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EstimateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Estimate
        {
            BalanceAfterEstimate = 0,
            Breakdown =
            [
                new()
                {
                    Cost = 0,
                    FeatureID = "featureId",
                    WarningCode = WarningCode.UnsupportedAggregation,
                },
            ],
            CurrencyID = "currencyId",
            CurrentBalance = 0,
            EstimatedCost = 0,
            WouldOverdraft = true,
        };

        double expectedBalanceAfterEstimate = 0;
        List<Breakdown> expectedBreakdown =
        [
            new()
            {
                Cost = 0,
                FeatureID = "featureId",
                WarningCode = WarningCode.UnsupportedAggregation,
            },
        ];
        string expectedCurrencyID = "currencyId";
        double expectedCurrentBalance = 0;
        double expectedEstimatedCost = 0;
        bool expectedWouldOverdraft = true;

        Assert.Equal(expectedBalanceAfterEstimate, model.BalanceAfterEstimate);
        Assert.Equal(expectedBreakdown.Count, model.Breakdown.Count);
        for (int i = 0; i < expectedBreakdown.Count; i++)
        {
            Assert.Equal(expectedBreakdown[i], model.Breakdown[i]);
        }
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrentBalance, model.CurrentBalance);
        Assert.Equal(expectedEstimatedCost, model.EstimatedCost);
        Assert.Equal(expectedWouldOverdraft, model.WouldOverdraft);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Estimate
        {
            BalanceAfterEstimate = 0,
            Breakdown =
            [
                new()
                {
                    Cost = 0,
                    FeatureID = "featureId",
                    WarningCode = WarningCode.UnsupportedAggregation,
                },
            ],
            CurrencyID = "currencyId",
            CurrentBalance = 0,
            EstimatedCost = 0,
            WouldOverdraft = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Estimate>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Estimate
        {
            BalanceAfterEstimate = 0,
            Breakdown =
            [
                new()
                {
                    Cost = 0,
                    FeatureID = "featureId",
                    WarningCode = WarningCode.UnsupportedAggregation,
                },
            ],
            CurrencyID = "currencyId",
            CurrentBalance = 0,
            EstimatedCost = 0,
            WouldOverdraft = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Estimate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBalanceAfterEstimate = 0;
        List<Breakdown> expectedBreakdown =
        [
            new()
            {
                Cost = 0,
                FeatureID = "featureId",
                WarningCode = WarningCode.UnsupportedAggregation,
            },
        ];
        string expectedCurrencyID = "currencyId";
        double expectedCurrentBalance = 0;
        double expectedEstimatedCost = 0;
        bool expectedWouldOverdraft = true;

        Assert.Equal(expectedBalanceAfterEstimate, deserialized.BalanceAfterEstimate);
        Assert.Equal(expectedBreakdown.Count, deserialized.Breakdown.Count);
        for (int i = 0; i < expectedBreakdown.Count; i++)
        {
            Assert.Equal(expectedBreakdown[i], deserialized.Breakdown[i]);
        }
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrentBalance, deserialized.CurrentBalance);
        Assert.Equal(expectedEstimatedCost, deserialized.EstimatedCost);
        Assert.Equal(expectedWouldOverdraft, deserialized.WouldOverdraft);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Estimate
        {
            BalanceAfterEstimate = 0,
            Breakdown =
            [
                new()
                {
                    Cost = 0,
                    FeatureID = "featureId",
                    WarningCode = WarningCode.UnsupportedAggregation,
                },
            ],
            CurrencyID = "currencyId",
            CurrentBalance = 0,
            EstimatedCost = 0,
            WouldOverdraft = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Estimate
        {
            BalanceAfterEstimate = 0,
            Breakdown =
            [
                new()
                {
                    Cost = 0,
                    FeatureID = "featureId",
                    WarningCode = WarningCode.UnsupportedAggregation,
                },
            ],
            CurrencyID = "currencyId",
            CurrentBalance = 0,
            EstimatedCost = 0,
            WouldOverdraft = true,
        };

        Estimate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BreakdownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Breakdown
        {
            Cost = 0,
            FeatureID = "featureId",
            WarningCode = WarningCode.UnsupportedAggregation,
        };

        double expectedCost = 0;
        string expectedFeatureID = "featureId";
        ApiEnum<string, WarningCode> expectedWarningCode = WarningCode.UnsupportedAggregation;

        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedWarningCode, model.WarningCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Breakdown
        {
            Cost = 0,
            FeatureID = "featureId",
            WarningCode = WarningCode.UnsupportedAggregation,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Breakdown>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Breakdown
        {
            Cost = 0,
            FeatureID = "featureId",
            WarningCode = WarningCode.UnsupportedAggregation,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Breakdown>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCost = 0;
        string expectedFeatureID = "featureId";
        ApiEnum<string, WarningCode> expectedWarningCode = WarningCode.UnsupportedAggregation;

        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedWarningCode, deserialized.WarningCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Breakdown
        {
            Cost = 0,
            FeatureID = "featureId",
            WarningCode = WarningCode.UnsupportedAggregation,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Breakdown
        {
            Cost = 0,
            FeatureID = "featureId",
            WarningCode = WarningCode.UnsupportedAggregation,
        };

        Breakdown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WarningCodeTest : TestBase
{
    [Theory]
    [InlineData(WarningCode.UnsupportedAggregation)]
    public void Validation_Works(WarningCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WarningCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WarningCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WarningCode.UnsupportedAggregation)]
    public void SerializationRoundtrip_Works(WarningCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WarningCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WarningCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WarningCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WarningCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WarningTest : TestBase
{
    [Theory]
    [InlineData(Warning.ResourceScopedSubscriptionExists)]
    [InlineData(Warning.FeatureNotFound)]
    [InlineData(Warning.FeatureNotCreditBased)]
    public void Validation_Works(Warning rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Warning> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Warning>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Warning.ResourceScopedSubscriptionExists)]
    [InlineData(Warning.FeatureNotFound)]
    [InlineData(Warning.FeatureNotCreditBased)]
    public void SerializationRoundtrip_Works(Warning rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Warning> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Warning>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Warning>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Warning>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
