using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Beta.Customers.Entities;

namespace Stigg.Client.Tests.Models.V1.Events.Beta.Customers.Entities;

public class EntityUpsertParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityUpsertParams
        {
            ID = "id",
            Entities =
            [
                new()
                {
                    ID = "user-7f3a0c1d",
                    Metadata = new Dictionary<string, string>()
                    {
                        { "email", "jane@acme.com" },
                        { "role", "admin" },
                    },
                    TypeRefID = "user",
                },
                new()
                {
                    ID = "user-c4d1b2e9",
                    Metadata = new Dictionary<string, string>() { { "email", "john@acme.com" } },
                    TypeRefID = "user",
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        List<Entity> expectedEntities =
        [
            new()
            {
                ID = "user-7f3a0c1d",
                Metadata = new Dictionary<string, string>()
                {
                    { "email", "jane@acme.com" },
                    { "role", "admin" },
                },
                TypeRefID = "user",
            },
            new()
            {
                ID = "user-c4d1b2e9",
                Metadata = new Dictionary<string, string>() { { "email", "john@acme.com" } },
                TypeRefID = "user",
            },
        ];
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEntities.Count, parameters.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], parameters.Entities[i]);
        }
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityUpsertParams
        {
            ID = "id",
            Entities =
            [
                new()
                {
                    ID = "user-7f3a0c1d",
                    Metadata = new Dictionary<string, string>()
                    {
                        { "email", "jane@acme.com" },
                        { "role", "admin" },
                    },
                    TypeRefID = "user",
                },
                new()
                {
                    ID = "user-c4d1b2e9",
                    Metadata = new Dictionary<string, string>() { { "email", "john@acme.com" } },
                    TypeRefID = "user",
                },
            ],
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityUpsertParams
        {
            ID = "id",
            Entities =
            [
                new()
                {
                    ID = "user-7f3a0c1d",
                    Metadata = new Dictionary<string, string>()
                    {
                        { "email", "jane@acme.com" },
                        { "role", "admin" },
                    },
                    TypeRefID = "user",
                },
                new()
                {
                    ID = "user-c4d1b2e9",
                    Metadata = new Dictionary<string, string>() { { "email", "john@acme.com" } },
                    TypeRefID = "user",
                },
            ],

            // Null should be interpreted as omitted for these properties
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityUpsertParams parameters = new()
        {
            ID = "id",
            Entities =
            [
                new()
                {
                    ID = "user-7f3a0c1d",
                    Metadata = new Dictionary<string, string>()
                    {
                        { "email", "jane@acme.com" },
                        { "role", "admin" },
                    },
                    TypeRefID = "user",
                },
                new()
                {
                    ID = "user-c4d1b2e9",
                    Metadata = new Dictionary<string, string>() { { "email", "john@acme.com" } },
                    TypeRefID = "user",
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1-beta/customers/id/entities"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EntityUpsertParams parameters = new()
        {
            ID = "id",
            Entities =
            [
                new()
                {
                    ID = "user-7f3a0c1d",
                    Metadata = new Dictionary<string, string>()
                    {
                        { "email", "jane@acme.com" },
                        { "role", "admin" },
                    },
                    TypeRefID = "user",
                },
                new()
                {
                    ID = "user-c4d1b2e9",
                    Metadata = new Dictionary<string, string>() { { "email", "john@acme.com" } },
                    TypeRefID = "user",
                },
            ],
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
        var parameters = new EntityUpsertParams
        {
            ID = "id",
            Entities =
            [
                new()
                {
                    ID = "user-7f3a0c1d",
                    Metadata = new Dictionary<string, string>()
                    {
                        { "email", "jane@acme.com" },
                        { "role", "admin" },
                    },
                    TypeRefID = "user",
                },
                new()
                {
                    ID = "user-c4d1b2e9",
                    Metadata = new Dictionary<string, string>() { { "email", "john@acme.com" } },
                    TypeRefID = "user",
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        EntityUpsertParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entity
        {
            ID = "id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            TypeRefID = "typeRefId",
        };

        string expectedID = "id";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedTypeRefID = "typeRefId";

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedTypeRefID, model.TypeRefID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entity
        {
            ID = "id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            TypeRefID = "typeRefId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entity
        {
            ID = "id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            TypeRefID = "typeRefId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedTypeRefID = "typeRefId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedTypeRefID, deserialized.TypeRefID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entity
        {
            ID = "id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            TypeRefID = "typeRefId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entity { ID = "id" };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.TypeRefID);
        Assert.False(model.RawData.ContainsKey("typeRefId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entity { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entity
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            TypeRefID = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.TypeRefID);
        Assert.False(model.RawData.ContainsKey("typeRefId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entity
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            TypeRefID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entity
        {
            ID = "id",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            TypeRefID = "typeRefId",
        };

        Entity copied = new(model);

        Assert.Equal(model, copied);
    }
}
