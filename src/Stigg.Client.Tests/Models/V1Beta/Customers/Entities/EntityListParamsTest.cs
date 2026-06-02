using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1Beta.Customers.Entities;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Entities;

public class EntityListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityListParams
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IncludeArchived = IncludeArchived.True,
            Limit = 1,
            TypeRefID = "typeRefId",
        };

        string expectedID = "id";
        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, IncludeArchived> expectedIncludeArchived = IncludeArchived.True;
        long expectedLimit = 1;
        string expectedTypeRefID = "typeRefId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedIncludeArchived, parameters.IncludeArchived);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedTypeRefID, parameters.TypeRefID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityListParams { ID = "id" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("includeArchived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.TypeRefID);
        Assert.False(parameters.RawQueryData.ContainsKey("typeRefId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityListParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            IncludeArchived = null,
            Limit = null,
            TypeRefID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.IncludeArchived);
        Assert.False(parameters.RawQueryData.ContainsKey("includeArchived"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.TypeRefID);
        Assert.False(parameters.RawQueryData.ContainsKey("typeRefId"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityListParams parameters = new()
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IncludeArchived = IncludeArchived.True,
            Limit = 1,
            TypeRefID = "typeRefId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1-beta/customers/id/entities?after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&includeArchived=true&limit=1&typeRefId=typeRefId"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityListParams
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IncludeArchived = IncludeArchived.True,
            Limit = 1,
            TypeRefID = "typeRefId",
        };

        EntityListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IncludeArchivedTest : TestBase
{
    [Theory]
    [InlineData(IncludeArchived.True)]
    [InlineData(IncludeArchived.False)]
    public void Validation_Works(IncludeArchived rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IncludeArchived> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IncludeArchived>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IncludeArchived.True)]
    [InlineData(IncludeArchived.False)]
    public void SerializationRoundtrip_Works(IncludeArchived rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IncludeArchived> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IncludeArchived>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IncludeArchived>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IncludeArchived>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
