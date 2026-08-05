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
                Pagination = new() { Next = "next", Prev = "prev" },
                Series =
                [
                    new()
                    {
                        EventCount = 0,
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                EventCount = 0,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                        Tags = [new() { Key = "key", Value = "value" }],
                    },
                ],
            },
        };

        CreditGetUsageResponseData expectedData = new()
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Pagination = new() { Next = "next", Prev = "prev" },
            Series =
            [
                new()
                {
                    EventCount = 0,
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            EventCount = 0,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                    Tags = [new() { Key = "key", Value = "value" }],
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
                Pagination = new() { Next = "next", Prev = "prev" },
                Series =
                [
                    new()
                    {
                        EventCount = 0,
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                EventCount = 0,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                        Tags = [new() { Key = "key", Value = "value" }],
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
                Pagination = new() { Next = "next", Prev = "prev" },
                Series =
                [
                    new()
                    {
                        EventCount = 0,
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                EventCount = 0,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                        Tags = [new() { Key = "key", Value = "value" }],
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

        CreditGetUsageResponseData expectedData = new()
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Pagination = new() { Next = "next", Prev = "prev" },
            Series =
            [
                new()
                {
                    EventCount = 0,
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            EventCount = 0,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                    Tags = [new() { Key = "key", Value = "value" }],
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
                Pagination = new() { Next = "next", Prev = "prev" },
                Series =
                [
                    new()
                    {
                        EventCount = 0,
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                EventCount = 0,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                        Tags = [new() { Key = "key", Value = "value" }],
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
                Pagination = new() { Next = "next", Prev = "prev" },
                Series =
                [
                    new()
                    {
                        EventCount = 0,
                        FeatureID = "featureId",
                        FeatureName = "featureName",
                        Points =
                        [
                            new()
                            {
                                EventCount = 0,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        TotalCredits = 0,
                        Tags = [new() { Key = "key", Value = "value" }],
                    },
                ],
            },
        };

        CreditGetUsageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditGetUsageResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditGetUsageResponseData
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Pagination = new() { Next = "next", Prev = "prev" },
            Series =
            [
                new()
                {
                    EventCount = 0,
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            EventCount = 0,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                    Tags = [new() { Key = "key", Value = "value" }],
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
        Pagination expectedPagination = new() { Next = "next", Prev = "prev" };
        List<Series> expectedSeries =
        [
            new()
            {
                EventCount = 0,
                FeatureID = "featureId",
                FeatureName = "featureName",
                Points =
                [
                    new()
                    {
                        EventCount = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                    },
                ],
                TotalCredits = 0,
                Tags = [new() { Key = "key", Value = "value" }],
            },
        ];

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedPagination, model.Pagination);
        Assert.Equal(expectedSeries.Count, model.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], model.Series[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditGetUsageResponseData
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Pagination = new() { Next = "next", Prev = "prev" },
            Series =
            [
                new()
                {
                    EventCount = 0,
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            EventCount = 0,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditGetUsageResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditGetUsageResponseData
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Pagination = new() { Next = "next", Prev = "prev" },
            Series =
            [
                new()
                {
                    EventCount = 0,
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            EventCount = 0,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditGetUsageResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Currency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Plural = "plural",
            Singular = "singular",
            Symbol = "symbol",
        };
        Pagination expectedPagination = new() { Next = "next", Prev = "prev" };
        List<Series> expectedSeries =
        [
            new()
            {
                EventCount = 0,
                FeatureID = "featureId",
                FeatureName = "featureName",
                Points =
                [
                    new()
                    {
                        EventCount = 0,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                    },
                ],
                TotalCredits = 0,
                Tags = [new() { Key = "key", Value = "value" }],
            },
        ];

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedPagination, deserialized.Pagination);
        Assert.Equal(expectedSeries.Count, deserialized.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], deserialized.Series[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditGetUsageResponseData
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Pagination = new() { Next = "next", Prev = "prev" },
            Series =
            [
                new()
                {
                    EventCount = 0,
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            EventCount = 0,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditGetUsageResponseData
        {
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Plural = "plural",
                Singular = "singular",
                Symbol = "symbol",
            },
            Pagination = new() { Next = "next", Prev = "prev" },
            Series =
            [
                new()
                {
                    EventCount = 0,
                    FeatureID = "featureId",
                    FeatureName = "featureName",
                    Points =
                    [
                        new()
                        {
                            EventCount = 0,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    TotalCredits = 0,
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        CreditGetUsageResponseData copied = new(model);

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

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        string expectedNext = "next";
        string expectedPrev = "prev";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "next";
        string expectedPrev = "prev";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        Pagination copied = new(model);

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
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,
            Tags = [new() { Key = "key", Value = "value" }],
        };

        double expectedEventCount = 0;
        string expectedFeatureID = "featureId";
        string expectedFeatureName = "featureName";
        List<Point> expectedPoints =
        [
            new()
            {
                EventCount = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Value = 0,
            },
        ];
        double expectedTotalCredits = 0;
        List<Tag> expectedTags = [new() { Key = "key", Value = "value" }];

        Assert.Equal(expectedEventCount, model.EventCount);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedFeatureName, model.FeatureName);
        Assert.Equal(expectedPoints.Count, model.Points.Count);
        for (int i = 0; i < expectedPoints.Count; i++)
        {
            Assert.Equal(expectedPoints[i], model.Points[i]);
        }
        Assert.Equal(expectedTotalCredits, model.TotalCredits);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Series
        {
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,
            Tags = [new() { Key = "key", Value = "value" }],
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
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,
            Tags = [new() { Key = "key", Value = "value" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Series>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedEventCount = 0;
        string expectedFeatureID = "featureId";
        string expectedFeatureName = "featureName";
        List<Point> expectedPoints =
        [
            new()
            {
                EventCount = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Value = 0,
            },
        ];
        double expectedTotalCredits = 0;
        List<Tag> expectedTags = [new() { Key = "key", Value = "value" }];

        Assert.Equal(expectedEventCount, deserialized.EventCount);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedFeatureName, deserialized.FeatureName);
        Assert.Equal(expectedPoints.Count, deserialized.Points.Count);
        for (int i = 0; i < expectedPoints.Count; i++)
        {
            Assert.Equal(expectedPoints[i], deserialized.Points[i]);
        }
        Assert.Equal(expectedTotalCredits, deserialized.TotalCredits);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Series
        {
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,
            Tags = [new() { Key = "key", Value = "value" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Series
        {
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,
        };

        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Series
        {
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Series
        {
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,

            // Null should be interpreted as omitted for these properties
            Tags = null,
        };

        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Series
        {
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,

            // Null should be interpreted as omitted for these properties
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Series
        {
            EventCount = 0,
            FeatureID = "featureId",
            FeatureName = "featureName",
            Points =
            [
                new()
                {
                    EventCount = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            TotalCredits = 0,
            Tags = [new() { Key = "key", Value = "value" }],
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
            EventCount = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        double expectedEventCount = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedValue = 0;

        Assert.Equal(expectedEventCount, model.EventCount);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Point
        {
            EventCount = 0,
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
            EventCount = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Point>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedEventCount = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedValue = 0;

        Assert.Equal(expectedEventCount, deserialized.EventCount);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Point
        {
            EventCount = 0,
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
            EventCount = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        Point copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tag { Key = "key", Value = "value" };

        string expectedKey = "key";
        string expectedValue = "value";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tag { Key = "key", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tag>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tag { Key = "key", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tag>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedKey = "key";
        string expectedValue = "value";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tag { Key = "key", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tag { Key = "key", Value = "value" };

        Tag copied = new(model);

        Assert.Equal(model, copied);
    }
}
