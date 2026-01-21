using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Usage = Stigg.Models.V1.Customers.Usage;

namespace Stigg.Tests.Models.V1.Customers.Usage;

public class UsageRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage::UsageRetrieveResponse
        {
            Data = new()
            {
                Markers =
                [
                    new()
                    {
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Type = Usage::Type.PeriodicReset,
                    },
                ],
                Series =
                [
                    new()
                    {
                        Points =
                        [
                            new()
                            {
                                IsResetPoint = true,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        Tags = [new() { Key = "key", Value = "value" }],
                    },
                ],
            },
        };

        Usage::Data expectedData = new()
        {
            Markers =
            [
                new()
                {
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = Usage::Type.PeriodicReset,
                },
            ],
            Series =
            [
                new()
                {
                    Points =
                    [
                        new()
                        {
                            IsResetPoint = true,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage::UsageRetrieveResponse
        {
            Data = new()
            {
                Markers =
                [
                    new()
                    {
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Type = Usage::Type.PeriodicReset,
                    },
                ],
                Series =
                [
                    new()
                    {
                        Points =
                        [
                            new()
                            {
                                IsResetPoint = true,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        Tags = [new() { Key = "key", Value = "value" }],
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::UsageRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage::UsageRetrieveResponse
        {
            Data = new()
            {
                Markers =
                [
                    new()
                    {
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Type = Usage::Type.PeriodicReset,
                    },
                ],
                Series =
                [
                    new()
                    {
                        Points =
                        [
                            new()
                            {
                                IsResetPoint = true,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        Tags = [new() { Key = "key", Value = "value" }],
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::UsageRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Usage::Data expectedData = new()
        {
            Markers =
            [
                new()
                {
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = Usage::Type.PeriodicReset,
                },
            ],
            Series =
            [
                new()
                {
                    Points =
                    [
                        new()
                        {
                            IsResetPoint = true,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage::UsageRetrieveResponse
        {
            Data = new()
            {
                Markers =
                [
                    new()
                    {
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Type = Usage::Type.PeriodicReset,
                    },
                ],
                Series =
                [
                    new()
                    {
                        Points =
                        [
                            new()
                            {
                                IsResetPoint = true,
                                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                Value = 0,
                            },
                        ],
                        Tags = [new() { Key = "key", Value = "value" }],
                    },
                ],
            },
        };

        model.Validate();
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage::Data
        {
            Markers =
            [
                new()
                {
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = Usage::Type.PeriodicReset,
                },
            ],
            Series =
            [
                new()
                {
                    Points =
                    [
                        new()
                        {
                            IsResetPoint = true,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        List<Usage::Marker> expectedMarkers =
        [
            new()
            {
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Usage::Type.PeriodicReset,
            },
        ];
        List<Usage::Series> expectedSeries =
        [
            new()
            {
                Points =
                [
                    new()
                    {
                        IsResetPoint = true,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                    },
                ],
                Tags = [new() { Key = "key", Value = "value" }],
            },
        ];

        Assert.Equal(expectedMarkers.Count, model.Markers.Count);
        for (int i = 0; i < expectedMarkers.Count; i++)
        {
            Assert.Equal(expectedMarkers[i], model.Markers[i]);
        }
        Assert.Equal(expectedSeries.Count, model.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], model.Series[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage::Data
        {
            Markers =
            [
                new()
                {
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = Usage::Type.PeriodicReset,
                },
            ],
            Series =
            [
                new()
                {
                    Points =
                    [
                        new()
                        {
                            IsResetPoint = true,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Data>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage::Data
        {
            Markers =
            [
                new()
                {
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = Usage::Type.PeriodicReset,
                },
            ],
            Series =
            [
                new()
                {
                    Points =
                    [
                        new()
                        {
                            IsResetPoint = true,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Data>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Usage::Marker> expectedMarkers =
        [
            new()
            {
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Type = Usage::Type.PeriodicReset,
            },
        ];
        List<Usage::Series> expectedSeries =
        [
            new()
            {
                Points =
                [
                    new()
                    {
                        IsResetPoint = true,
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                    },
                ],
                Tags = [new() { Key = "key", Value = "value" }],
            },
        ];

        Assert.Equal(expectedMarkers.Count, deserialized.Markers.Count);
        for (int i = 0; i < expectedMarkers.Count; i++)
        {
            Assert.Equal(expectedMarkers[i], deserialized.Markers[i]);
        }
        Assert.Equal(expectedSeries.Count, deserialized.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], deserialized.Series[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage::Data
        {
            Markers =
            [
                new()
                {
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Type = Usage::Type.PeriodicReset,
                },
            ],
            Series =
            [
                new()
                {
                    Points =
                    [
                        new()
                        {
                            IsResetPoint = true,
                            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Value = 0,
                        },
                    ],
                    Tags = [new() { Key = "key", Value = "value" }],
                },
            ],
        };

        model.Validate();
    }
}

public class MarkerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage::Marker
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Usage::Type.PeriodicReset,
        };

        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Usage::Type> expectedType = Usage::Type.PeriodicReset;

        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage::Marker
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Usage::Type.PeriodicReset,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Marker>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage::Marker
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Usage::Type.PeriodicReset,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Marker>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Usage::Type> expectedType = Usage::Type.PeriodicReset;

        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage::Marker
        {
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = Usage::Type.PeriodicReset,
        };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Usage::Type.PeriodicReset)]
    [InlineData(Usage::Type.SubscriptionChangeReset)]
    public void Validation_Works(Usage::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Usage::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Usage::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Usage::Type.PeriodicReset)]
    [InlineData(Usage::Type.SubscriptionChangeReset)]
    public void SerializationRoundtrip_Works(Usage::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Usage::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Usage::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Usage::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Usage::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SeriesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage::Series
        {
            Points =
            [
                new()
                {
                    IsResetPoint = true,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            Tags = [new() { Key = "key", Value = "value" }],
        };

        List<Usage::Point> expectedPoints =
        [
            new()
            {
                IsResetPoint = true,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Value = 0,
            },
        ];
        List<Usage::Tag> expectedTags = [new() { Key = "key", Value = "value" }];

        Assert.Equal(expectedPoints.Count, model.Points.Count);
        for (int i = 0; i < expectedPoints.Count; i++)
        {
            Assert.Equal(expectedPoints[i], model.Points[i]);
        }
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage::Series
        {
            Points =
            [
                new()
                {
                    IsResetPoint = true,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            Tags = [new() { Key = "key", Value = "value" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Series>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage::Series
        {
            Points =
            [
                new()
                {
                    IsResetPoint = true,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            Tags = [new() { Key = "key", Value = "value" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Series>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Usage::Point> expectedPoints =
        [
            new()
            {
                IsResetPoint = true,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Value = 0,
            },
        ];
        List<Usage::Tag> expectedTags = [new() { Key = "key", Value = "value" }];

        Assert.Equal(expectedPoints.Count, deserialized.Points.Count);
        for (int i = 0; i < expectedPoints.Count; i++)
        {
            Assert.Equal(expectedPoints[i], deserialized.Points[i]);
        }
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage::Series
        {
            Points =
            [
                new()
                {
                    IsResetPoint = true,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                },
            ],
            Tags = [new() { Key = "key", Value = "value" }],
        };

        model.Validate();
    }
}

public class PointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage::Point
        {
            IsResetPoint = true,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        bool expectedIsResetPoint = true;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedValue = 0;

        Assert.Equal(expectedIsResetPoint, model.IsResetPoint);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage::Point
        {
            IsResetPoint = true,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Point>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage::Point
        {
            IsResetPoint = true,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Point>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsResetPoint = true;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedValue = 0;

        Assert.Equal(expectedIsResetPoint, deserialized.IsResetPoint);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage::Point
        {
            IsResetPoint = true,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        model.Validate();
    }
}

public class TagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage::Tag { Key = "key", Value = "value" };

        string expectedKey = "key";
        string expectedValue = "value";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage::Tag { Key = "key", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Tag>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage::Tag { Key = "key", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage::Tag>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKey = "key";
        string expectedValue = "value";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage::Tag { Key = "key", Value = "value" };

        model.Validate();
    }
}
