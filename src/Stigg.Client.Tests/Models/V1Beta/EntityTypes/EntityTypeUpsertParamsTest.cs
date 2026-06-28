using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using EntityTypes = Stigg.Client.Models.V1Beta.EntityTypes;

namespace Stigg.Client.Tests.Models.V1Beta.EntityTypes;

public class EntityTypeUpsertParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityTypes::EntityTypeUpsertParams
        {
            Types =
            [
                new()
                {
                    ID = "org",
                    AttributionKeys = ["organizationId"],
                    DisplayName = "Organization",
                },
                new()
                {
                    ID = "team",
                    AttributionKeys = ["teamId"],
                    DisplayName = "Team",
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        List<EntityTypes::Type> expectedTypes =
        [
            new()
            {
                ID = "org",
                AttributionKeys = ["organizationId"],
                DisplayName = "Organization",
            },
            new()
            {
                ID = "team",
                AttributionKeys = ["teamId"],
                DisplayName = "Team",
            },
        ];
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedTypes.Count, parameters.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], parameters.Types[i]);
        }
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityTypes::EntityTypeUpsertParams
        {
            Types =
            [
                new()
                {
                    ID = "org",
                    AttributionKeys = ["organizationId"],
                    DisplayName = "Organization",
                },
                new()
                {
                    ID = "team",
                    AttributionKeys = ["teamId"],
                    DisplayName = "Team",
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
        var parameters = new EntityTypes::EntityTypeUpsertParams
        {
            Types =
            [
                new()
                {
                    ID = "org",
                    AttributionKeys = ["organizationId"],
                    DisplayName = "Organization",
                },
                new()
                {
                    ID = "team",
                    AttributionKeys = ["teamId"],
                    DisplayName = "Team",
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
        EntityTypes::EntityTypeUpsertParams parameters = new()
        {
            Types =
            [
                new()
                {
                    ID = "org",
                    AttributionKeys = ["organizationId"],
                    DisplayName = "Organization",
                },
                new()
                {
                    ID = "team",
                    AttributionKeys = ["teamId"],
                    DisplayName = "Team",
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://edge.api.stigg.io/api/v1-beta/entity-types"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EntityTypes::EntityTypeUpsertParams parameters = new()
        {
            Types =
            [
                new()
                {
                    ID = "org",
                    AttributionKeys = ["organizationId"],
                    DisplayName = "Organization",
                },
                new()
                {
                    ID = "team",
                    AttributionKeys = ["teamId"],
                    DisplayName = "Team",
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
        var parameters = new EntityTypes::EntityTypeUpsertParams
        {
            Types =
            [
                new()
                {
                    ID = "org",
                    AttributionKeys = ["organizationId"],
                    DisplayName = "Organization",
                },
                new()
                {
                    ID = "team",
                    AttributionKeys = ["teamId"],
                    DisplayName = "Team",
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        EntityTypes::EntityTypeUpsertParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityTypes::Type
        {
            ID = "id",
            AttributionKeys = ["NxI"],
            DisplayName = "x",
        };

        string expectedID = "id";
        List<string> expectedAttributionKeys = ["NxI"];
        string expectedDisplayName = "x";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributionKeys.Count, model.AttributionKeys.Count);
        for (int i = 0; i < expectedAttributionKeys.Count; i++)
        {
            Assert.Equal(expectedAttributionKeys[i], model.AttributionKeys[i]);
        }
        Assert.Equal(expectedDisplayName, model.DisplayName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityTypes::Type
        {
            ID = "id",
            AttributionKeys = ["NxI"],
            DisplayName = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypes::Type>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityTypes::Type
        {
            ID = "id",
            AttributionKeys = ["NxI"],
            DisplayName = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypes::Type>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedAttributionKeys = ["NxI"];
        string expectedDisplayName = "x";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributionKeys.Count, deserialized.AttributionKeys.Count);
        for (int i = 0; i < expectedAttributionKeys.Count; i++)
        {
            Assert.Equal(expectedAttributionKeys[i], deserialized.AttributionKeys[i]);
        }
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityTypes::Type
        {
            ID = "id",
            AttributionKeys = ["NxI"],
            DisplayName = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityTypes::Type
        {
            ID = "id",
            AttributionKeys = ["NxI"],
            DisplayName = "x",
        };

        EntityTypes::Type copied = new(model);

        Assert.Equal(model, copied);
    }
}
