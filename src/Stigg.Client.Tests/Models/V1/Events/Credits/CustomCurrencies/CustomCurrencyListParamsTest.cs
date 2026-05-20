using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Credits.CustomCurrencies;

namespace Stigg.Client.Tests.Models.V1.Events.Credits.CustomCurrencies;

public class CustomCurrencyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomCurrencyListParams
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            Status = [Status.Active],
        };

        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedLimit = 1;
        List<ApiEnum<string, Status>> expectedStatus = [Status.Active];

        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomCurrencyListParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomCurrencyListParams
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomCurrencyListParams parameters = new()
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            Status = [Status.Active],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/credits/custom-currencies?after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&limit=1&status=ACTIVE"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomCurrencyListParams
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            Status = [Status.Active],
        };

        CustomCurrencyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Archived)]
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
    [InlineData(Status.Active)]
    [InlineData(Status.Archived)]
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
