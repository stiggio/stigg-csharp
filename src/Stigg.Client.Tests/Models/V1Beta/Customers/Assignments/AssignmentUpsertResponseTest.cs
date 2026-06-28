using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Customers.Assignments;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Assignments;

public class AssignmentUpsertResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AssignmentUpsertResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Cadence = "PT869S",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityId",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        List<Data> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cadence = "PT869S",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntityID = "entityId",
                ParentID = "parentId",
                ScopeEntityIds = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                CurrencyID = "currencyId",
                FeatureID = "featureId",
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AssignmentUpsertResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Cadence = "PT869S",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityId",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssignmentUpsertResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AssignmentUpsertResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Cadence = "PT869S",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityId",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssignmentUpsertResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Data> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Cadence = "PT869S",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EntityID = "entityId",
                ParentID = "parentId",
                ScopeEntityIds = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                CurrencyID = "currencyId",
                FeatureID = "featureId",
            },
        ];

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AssignmentUpsertResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Cadence = "PT869S",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityId",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AssignmentUpsertResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Cadence = "PT869S",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EntityID = "entityId",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        AssignmentUpsertResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCadence = "PT869S";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityId";
        string expectedParentID = "parentId";
        List<string> expectedScopeEntityIds = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedParentID, model.ParentID);
        Assert.Equal(expectedScopeEntityIds.Count, model.ScopeEntityIds.Count);
        for (int i = 0; i < expectedScopeEntityIds.Count; i++)
        {
            Assert.Equal(expectedScopeEntityIds[i], model.ScopeEntityIds[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCadence = "PT869S";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityId";
        string expectedParentID = "parentId";
        List<string> expectedScopeEntityIds = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedParentID, deserialized.ParentID);
        Assert.Equal(expectedScopeEntityIds.Count, deserialized.ScopeEntityIds.Count);
        for (int i = 0; i < expectedScopeEntityIds.Count; i++)
        {
            Assert.Equal(expectedScopeEntityIds[i], deserialized.ScopeEntityIds[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrencyID = null,
            FeatureID = null,
        };

        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrencyID = null,
            FeatureID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = "PT869S",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
