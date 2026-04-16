using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Coupons = Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Tests.Models.V1.Coupons;

public class CouponListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Coupons::CouponListParams
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
            Limit = 1,
            Status = "status",
            Type = Coupons::Type.Fixed,
        };

        string expectedID = "id";
        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Coupons::CreatedAt expectedCreatedAt = new()
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        long expectedLimit = 1;
        string expectedStatus = "status";
        ApiEnum<string, Coupons::Type> expectedType = Coupons::Type.Fixed;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedCreatedAt, parameters.CreatedAt);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Coupons::CouponListParams { };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawQueryData.ContainsKey("id"));
        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("createdAt"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Coupons::CouponListParams
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            After = null,
            Before = null,
            CreatedAt = null,
            Limit = null,
            Status = null,
            Type = null,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawQueryData.ContainsKey("id"));
        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("createdAt"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        Coupons::CouponListParams parameters = new()
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
            Limit = 1,
            Status = "status",
            Type = Coupons::Type.Fixed,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/coupons?id=id&after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&createdAt%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&limit=1&status=status&type=FIXED"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Coupons::CouponListParams
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
            Limit = 1,
            Status = "status",
            Type = Coupons::Type.Fixed,
        };

        Coupons::CouponListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Coupons::CreatedAt
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
        var model = new Coupons::CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupons::CreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Coupons::CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupons::CreatedAt>(
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
        var model = new Coupons::CreatedAt
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
        var model = new Coupons::CreatedAt { };

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
        var model = new Coupons::CreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Coupons::CreatedAt
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
        var model = new Coupons::CreatedAt
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
        var model = new Coupons::CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Coupons::CreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Coupons::Type.Fixed)]
    [InlineData(Coupons::Type.Percentage)]
    public void Validation_Works(Coupons::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Coupons::Type.Fixed)]
    [InlineData(Coupons::Type.Percentage)]
    public void SerializationRoundtrip_Works(Coupons::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
