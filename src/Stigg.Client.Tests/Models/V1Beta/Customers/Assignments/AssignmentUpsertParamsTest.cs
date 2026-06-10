using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1Beta.Customers.Assignments;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Assignments;

public class AssignmentUpsertParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AssignmentUpsertParams
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    CurrencyID = "currencyId",
                    FeatureID = "compute-minutes",
                    ParentID = "parentId",
                    ScopeEntityIds = ["NxI"],
                    UsageLimit = 1000,
                },
                new()
                {
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    CurrencyID = "cred-type-tokens",
                    FeatureID = "featureId",
                    ParentID = "workspace-001",
                    ScopeEntityIds = ["user-1"],
                    UsageLimit = 2000,
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        List<Assignment> expectedAssignments =
        [
            new()
            {
                EntityID = "workspace-001",
                Cadence = Cadence.Month,
                CurrencyID = "currencyId",
                FeatureID = "compute-minutes",
                ParentID = "parentId",
                ScopeEntityIds = ["NxI"],
                UsageLimit = 1000,
            },
            new()
            {
                EntityID = "workspace-002",
                Cadence = Cadence.Month,
                CurrencyID = "cred-type-tokens",
                FeatureID = "featureId",
                ParentID = "workspace-001",
                ScopeEntityIds = ["user-1"],
                UsageLimit = 2000,
            },
        ];
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAssignments.Count, parameters.Assignments.Count);
        for (int i = 0; i < expectedAssignments.Count; i++)
        {
            Assert.Equal(expectedAssignments[i], parameters.Assignments[i]);
        }
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AssignmentUpsertParams
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    CurrencyID = "currencyId",
                    FeatureID = "compute-minutes",
                    ParentID = "parentId",
                    ScopeEntityIds = ["NxI"],
                    UsageLimit = 1000,
                },
                new()
                {
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    CurrencyID = "cred-type-tokens",
                    FeatureID = "featureId",
                    ParentID = "workspace-001",
                    ScopeEntityIds = ["user-1"],
                    UsageLimit = 2000,
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
        var parameters = new AssignmentUpsertParams
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    CurrencyID = "currencyId",
                    FeatureID = "compute-minutes",
                    ParentID = "parentId",
                    ScopeEntityIds = ["NxI"],
                    UsageLimit = 1000,
                },
                new()
                {
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    CurrencyID = "cred-type-tokens",
                    FeatureID = "featureId",
                    ParentID = "workspace-001",
                    ScopeEntityIds = ["user-1"],
                    UsageLimit = 2000,
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
        AssignmentUpsertParams parameters = new()
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    CurrencyID = "currencyId",
                    FeatureID = "compute-minutes",
                    ParentID = "parentId",
                    ScopeEntityIds = ["NxI"],
                    UsageLimit = 1000,
                },
                new()
                {
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    CurrencyID = "cred-type-tokens",
                    FeatureID = "featureId",
                    ParentID = "workspace-001",
                    ScopeEntityIds = ["user-1"],
                    UsageLimit = 2000,
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1-beta/customers/id/assignments"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AssignmentUpsertParams parameters = new()
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    CurrencyID = "currencyId",
                    FeatureID = "compute-minutes",
                    ParentID = "parentId",
                    ScopeEntityIds = ["NxI"],
                    UsageLimit = 1000,
                },
                new()
                {
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    CurrencyID = "cred-type-tokens",
                    FeatureID = "featureId",
                    ParentID = "workspace-001",
                    ScopeEntityIds = ["user-1"],
                    UsageLimit = 2000,
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
        var parameters = new AssignmentUpsertParams
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    CurrencyID = "currencyId",
                    FeatureID = "compute-minutes",
                    ParentID = "parentId",
                    ScopeEntityIds = ["NxI"],
                    UsageLimit = 1000,
                },
                new()
                {
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    CurrencyID = "cred-type-tokens",
                    FeatureID = "featureId",
                    ParentID = "workspace-001",
                    ScopeEntityIds = ["user-1"],
                    UsageLimit = 2000,
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        AssignmentUpsertParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AssignmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ParentID = "parentId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,
        };

        string expectedEntityID = "entityId";
        ApiEnum<string, Cadence> expectedCadence = Cadence.Month;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";
        string expectedParentID = "parentId";
        List<string> expectedScopeEntityIds = ["NxI"];
        double expectedUsageLimit = 0;

        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedParentID, model.ParentID);
        Assert.NotNull(model.ScopeEntityIds);
        Assert.Equal(expectedScopeEntityIds.Count, model.ScopeEntityIds.Count);
        for (int i = 0; i < expectedScopeEntityIds.Count; i++)
        {
            Assert.Equal(expectedScopeEntityIds[i], model.ScopeEntityIds[i]);
        }
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ParentID = "parentId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Assignment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ParentID = "parentId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Assignment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEntityID = "entityId";
        ApiEnum<string, Cadence> expectedCadence = Cadence.Month;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";
        string expectedParentID = "parentId";
        List<string> expectedScopeEntityIds = ["NxI"];
        double expectedUsageLimit = 0;

        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedParentID, deserialized.ParentID);
        Assert.NotNull(deserialized.ScopeEntityIds);
        Assert.Equal(expectedScopeEntityIds.Count, deserialized.ScopeEntityIds.Count);
        for (int i = 0; i < expectedScopeEntityIds.Count; i++)
        {
            Assert.Equal(expectedScopeEntityIds[i], deserialized.ScopeEntityIds[i]);
        }
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ParentID = "parentId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Assignment { EntityID = "entityId", ParentID = "parentId" };

        Assert.Null(model.Cadence);
        Assert.False(model.RawData.ContainsKey("cadence"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.ScopeEntityIds);
        Assert.False(model.RawData.ContainsKey("scopeEntityIds"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Assignment { EntityID = "entityId", ParentID = "parentId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            ParentID = "parentId",

            // Null should be interpreted as omitted for these properties
            Cadence = null,
            CurrencyID = null,
            FeatureID = null,
            ScopeEntityIds = null,
            UsageLimit = null,
        };

        Assert.Null(model.Cadence);
        Assert.False(model.RawData.ContainsKey("cadence"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.ScopeEntityIds);
        Assert.False(model.RawData.ContainsKey("scopeEntityIds"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            ParentID = "parentId",

            // Null should be interpreted as omitted for these properties
            Cadence = null,
            CurrencyID = null,
            FeatureID = null,
            ScopeEntityIds = null,
            UsageLimit = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,
        };

        Assert.Null(model.ParentID);
        Assert.False(model.RawData.ContainsKey("parentId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,

            ParentID = null,
        };

        Assert.Null(model.ParentID);
        Assert.True(model.RawData.ContainsKey("parentId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,

            ParentID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Assignment
        {
            EntityID = "entityId",
            Cadence = Cadence.Month,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
            ParentID = "parentId",
            ScopeEntityIds = ["NxI"],
            UsageLimit = 0,
        };

        Assignment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CadenceTest : TestBase
{
    [Theory]
    [InlineData(Cadence.Month)]
    public void Validation_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cadence.Month)]
    public void SerializationRoundtrip_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
