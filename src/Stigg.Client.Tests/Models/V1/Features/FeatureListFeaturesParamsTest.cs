using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Features;

namespace Stigg.Client.Tests.Models.V1.Features;

public class FeatureListFeaturesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FeatureListFeaturesParams
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FeatureType = [FeatureListFeaturesParamsFeatureType.Boolean],
            Limit = 1,
            MeterType = [FeatureListFeaturesParamsMeterType.None],
            Status = [Status.New],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        CreatedAt expectedCreatedAt = new()
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        List<ApiEnum<string, FeatureListFeaturesParamsFeatureType>> expectedFeatureType =
        [
            FeatureListFeaturesParamsFeatureType.Boolean,
        ];
        long expectedLimit = 1;
        List<ApiEnum<string, FeatureListFeaturesParamsMeterType>> expectedMeterType =
        [
            FeatureListFeaturesParamsMeterType.None,
        ];
        List<ApiEnum<string, Status>> expectedStatus = [Status.New];
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedCreatedAt, parameters.CreatedAt);
        Assert.NotNull(parameters.FeatureType);
        Assert.Equal(expectedFeatureType.Count, parameters.FeatureType.Count);
        for (int i = 0; i < expectedFeatureType.Count; i++)
        {
            Assert.Equal(expectedFeatureType[i], parameters.FeatureType[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.NotNull(parameters.MeterType);
        Assert.Equal(expectedMeterType.Count, parameters.MeterType.Count);
        for (int i = 0; i < expectedMeterType.Count; i++)
        {
            Assert.Equal(expectedMeterType[i], parameters.MeterType[i]);
        }
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FeatureListFeaturesParams { };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawQueryData.ContainsKey("id"));
        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("createdAt"));
        Assert.Null(parameters.FeatureType);
        Assert.False(parameters.RawQueryData.ContainsKey("featureType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MeterType);
        Assert.False(parameters.RawQueryData.ContainsKey("meterType"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FeatureListFeaturesParams
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            After = null,
            Before = null,
            CreatedAt = null,
            FeatureType = null,
            Limit = null,
            MeterType = null,
            Status = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawQueryData.ContainsKey("id"));
        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("createdAt"));
        Assert.Null(parameters.FeatureType);
        Assert.False(parameters.RawQueryData.ContainsKey("featureType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MeterType);
        Assert.False(parameters.RawQueryData.ContainsKey("meterType"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        FeatureListFeaturesParams parameters = new()
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            },
            FeatureType = [FeatureListFeaturesParamsFeatureType.Boolean],
            Limit = 1,
            MeterType = [FeatureListFeaturesParamsMeterType.None],
            Status = [Status.New],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://edge.api.stigg.io/api/v1/features?id=id&after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&createdAt%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&featureType=BOOLEAN&limit=1&meterType=None&status=NEW"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        FeatureListFeaturesParams parameters = new()
        {
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
        var parameters = new FeatureListFeaturesParams
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FeatureType = [FeatureListFeaturesParamsFeatureType.Boolean],
            Limit = 1,
            MeterType = [FeatureListFeaturesParamsMeterType.None],
            Status = [Status.New],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        FeatureListFeaturesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedGt, model.Gt);
        Assert.Equal(expectedGte, model.Gte);
        Assert.Equal(expectedLt, model.Lt);
        Assert.Equal(expectedLte, model.Lte);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedGt, deserialized.Gt);
        Assert.Equal(expectedGte, deserialized.Gte);
        Assert.Equal(expectedLt, deserialized.Lt);
        Assert.Equal(expectedLte, deserialized.Lte);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreatedAt { };

        Assert.Null(model.Gt);
        Assert.False(model.RawData.ContainsKey("gt"));
        Assert.Null(model.Gte);
        Assert.False(model.RawData.ContainsKey("gte"));
        Assert.Null(model.Lt);
        Assert.False(model.RawData.ContainsKey("lt"));
        Assert.Null(model.Lte);
        Assert.False(model.RawData.ContainsKey("lte"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            Gt = null,
            Gte = null,
            Lt = null,
            Lte = null,
        };

        Assert.Null(model.Gt);
        Assert.False(model.RawData.ContainsKey("gt"));
        Assert.Null(model.Gte);
        Assert.False(model.RawData.ContainsKey("gte"));
        Assert.Null(model.Lt);
        Assert.False(model.RawData.ContainsKey("lt"));
        Assert.Null(model.Lte);
        Assert.False(model.RawData.ContainsKey("lte"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            Gt = null,
            Gte = null,
            Lt = null,
            Lte = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureListFeaturesParamsFeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureListFeaturesParamsFeatureType.Boolean)]
    [InlineData(FeatureListFeaturesParamsFeatureType.Number)]
    [InlineData(FeatureListFeaturesParamsFeatureType.Enum)]
    public void Validation_Works(FeatureListFeaturesParamsFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesParamsFeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesParamsFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureListFeaturesParamsFeatureType.Boolean)]
    [InlineData(FeatureListFeaturesParamsFeatureType.Number)]
    [InlineData(FeatureListFeaturesParamsFeatureType.Enum)]
    public void SerializationRoundtrip_Works(FeatureListFeaturesParamsFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesParamsFeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesParamsFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesParamsFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesParamsFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureListFeaturesParamsMeterTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureListFeaturesParamsMeterType.None)]
    [InlineData(FeatureListFeaturesParamsMeterType.Fluctuating)]
    [InlineData(FeatureListFeaturesParamsMeterType.Incremental)]
    public void Validation_Works(FeatureListFeaturesParamsMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesParamsMeterType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureListFeaturesParamsMeterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureListFeaturesParamsMeterType.None)]
    [InlineData(FeatureListFeaturesParamsMeterType.Fluctuating)]
    [InlineData(FeatureListFeaturesParamsMeterType.Incremental)]
    public void SerializationRoundtrip_Works(FeatureListFeaturesParamsMeterType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureListFeaturesParamsMeterType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesParamsMeterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureListFeaturesParamsMeterType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FeatureListFeaturesParamsMeterType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.New)]
    [InlineData(Status.Suspended)]
    [InlineData(Status.Active)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.New)]
    [InlineData(Status.Suspended)]
    [InlineData(Status.Active)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
