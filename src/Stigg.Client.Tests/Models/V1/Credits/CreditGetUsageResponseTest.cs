using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits;

namespace Stigg.Client.Tests.Models.V1.Credits;

public class CreditGetUsageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditGetUsageResponse
        {
            Data = new()
            {
                Currency = new()
                {
                    CurrencyID = "currencyId",
                    DisplayName = "displayName",
                    Plural = "plural",
                    Singular = "singular",
                    Symbol = "symbol",
                },
                Series =
                [
                    new()
                    {
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                    },
                ],
            },
        };

        Data expectedData = new()
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Series =
            [
                new()
                {
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                },
            ],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditGetUsageResponse
        {
            Data = new()
            {
                Currency = new()
                {
                    CurrencyID = "currencyId",
                    DisplayName = "displayName",
                    Plural = "plural",
                    Singular = "singular",
                    Symbol = "symbol",
                },
                Series =
                [
                    new()
                    {
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditGetUsageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditGetUsageResponse
        {
            Data = new()
            {
                Currency = new()
                {
                    CurrencyID = "currencyId",
                    DisplayName = "displayName",
                    Plural = "plural",
                    Singular = "singular",
                    Symbol = "symbol",
                },
                Series =
                [
                    new()
                    {
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditGetUsageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Series =
            [
                new()
                {
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                },
            ],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditGetUsageResponse
        {
            Data = new()
            {
                Currency = new()
                {
                    CurrencyID = "currencyId",
                    DisplayName = "displayName",
                    Plural = "plural",
                    Singular = "singular",
                    Symbol = "symbol",
                },
                Series =
                [
                    new()
                    {
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditGetUsageResponse
        {
            Data = new()
            {
                Currency = new()
                {
                    CurrencyID = "currencyId",
                    DisplayName = "displayName",
                    Plural = "plural",
                    Singular = "singular",
                    Symbol = "symbol",
                },
                Series =
                [
                    new()
                    {
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                    },
                ],
            },
        };

        CreditGetUsageResponse copied = new(model);

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
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Series =
            [
                new()
                {
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                },
            ],
        };

        Currency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Plural = "plural",
            Singular = "singular",
            Symbol = "symbol",
        };
        List<Series> expectedSeries =
        [
            new()
            {
                FeatureID = "featureId",
                FeatureName = "featureName",
                Points =
                [
                    new()
                    {
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                    },
                ],
                TotalCredits = 0,
            },
        ];

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedSeries.Count, model.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], model.Series[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Series =
            [
                new()
                {
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                },
            ],
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
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Series =
            [
                new()
                {
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Currency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Plural = "plural",
            Singular = "singular",
            Symbol = "symbol",
        };
        List<Series> expectedSeries =
        [
            new()
            {
                FeatureID = "featureId",
                FeatureName = "featureName",
                Points =
                [
                    new()
                    {
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                    },
                ],
                TotalCredits = 0,
            },
        ];

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedSeries.Count, deserialized.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], deserialized.Series[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Series =
            [
                new()
                {
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Series =
            [
                new()
                {
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                },
            ],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Plural = "plural",
            Singular = "singular",
            Symbol = "symbol",
        };

        string expectedCurrencyID = "currencyId";
        string expectedDisplayName = "displayName";
        string expectedPlural = "plural";
        string expectedSingular = "singular";
        string expectedSymbol = "symbol";

        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedPlural, model.Plural);
        Assert.Equal(expectedSingular, model.Singular);
        Assert.Equal(expectedSymbol, model.Symbol);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Plural = "plural",
            Singular = "singular",
            Symbol = "symbol",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Currency>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Plural = "plural",
            Singular = "singular",
            Symbol = "symbol",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Currency>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyID = "currencyId";
        string expectedDisplayName = "displayName";
        string expectedPlural = "plural";
        string expectedSingular = "singular";
        string expectedSymbol = "symbol";

        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedPlural, deserialized.Plural);
        Assert.Equal(expectedSingular, deserialized.Singular);
        Assert.Equal(expectedSymbol, deserialized.Symbol);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Plural = "plural",
            Singular = "singular",
            Symbol = "symbol",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Plural = "plural",
            Singular = "singular",
            Symbol = "symbol",
        };

        Currency copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SeriesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Series
        {
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new() { Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"), Value = 0 },
            ],
            TotalCredits = 0,
        };

        string expectedFeatureID = "featureId";
        string expectedFeatureName = "featureName";
        List<Point> expectedPoints =
        [
            new() { Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"), Value = 0 },
        ];
        double expectedTotalCredits = 0;

        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedFeatureName, model.FeatureName);
        Assert.Equal(expectedPoints.Count, model.Points.Count);
        for (int i = 0; i < expectedPoints.Count; i++)
        {
            Assert.Equal(expectedPoints[i], model.Points[i]);
        }
        Assert.Equal(expectedTotalCredits, model.TotalCredits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Series
        {
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new() { Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"), Value = 0 },
            ],
            TotalCredits = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Series>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Series
        {
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new() { Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"), Value = 0 },
            ],
            TotalCredits = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Series>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFeatureID = "featureId";
        string expectedFeatureName = "featureName";
        List<Point> expectedPoints =
        [
            new() { Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"), Value = 0 },
        ];
        double expectedTotalCredits = 0;

        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedFeatureName, deserialized.FeatureName);
        Assert.Equal(expectedPoints.Count, deserialized.Points.Count);
        for (int i = 0; i < expectedPoints.Count; i++)
        {
            Assert.Equal(expectedPoints[i], deserialized.Points[i]);
        }
        Assert.Equal(expectedTotalCredits, deserialized.TotalCredits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Series
        {
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new() { Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"), Value = 0 },
            ],
            TotalCredits = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Series
        {
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new() { Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"), Value = 0 },
            ],
            TotalCredits = 0,
        };

        Series copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Point
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedValue = 0;

        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Point
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Point>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Point
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Point>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedValue = 0;

        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Point
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Point
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        Point copied = new(model);

        Assert.Equal(model, copied);
    }
}
