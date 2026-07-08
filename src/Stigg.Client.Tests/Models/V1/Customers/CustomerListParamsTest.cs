using System;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerListParams
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Email = "email",
            Limit = 1,
            Name = "name",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        CreatedAt expectedCreatedAt = new()
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedEmail = "email";
        long expectedLimit = 1;
        string expectedName = "name";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedCreatedAt, parameters.CreatedAt);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerListParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("createdAt"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerListParams
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            CreatedAt = null,
            Email = null,
            Limit = null,
            Name = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("createdAt"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerListParams parameters = new()
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            },
            Email = "email",
            Limit = 1,
            Name = "name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/customers?after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&createdAt%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&email=email&limit=1&name=name"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomerListParams parameters = new()
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
        var parameters = new CustomerListParams
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Email = "email",
            Limit = 1,
            Name = "name",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CustomerListParams copied = new(parameters);

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
