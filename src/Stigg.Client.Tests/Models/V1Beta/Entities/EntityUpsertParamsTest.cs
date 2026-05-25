using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Entities;

namespace Stigg.Client.Tests.Models.V1Beta.Entities;

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

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEntities.Count, parameters.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], parameters.Entities[i]);
        }
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
