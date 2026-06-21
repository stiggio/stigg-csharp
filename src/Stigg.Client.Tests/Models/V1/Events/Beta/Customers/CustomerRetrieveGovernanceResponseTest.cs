using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Beta.Customers;

namespace Stigg.Client.Tests.Models.V1.Events.Beta.Customers;

public class CustomerRetrieveGovernanceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerRetrieveGovernanceResponse
        {
            Data =
            [
                new()
                {
                    Cadence = "cadence",
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    EntityType = "entityType",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Utilization = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            Pagination = new("next"),
        };

        List<Data> expectedData =
        [
            new()
            {
                Cadence = "cadence",
                CurrentUsage = 0,
                EntityID = "entityId",
                EntityType = "entityType",
                ParentID = "parentId",
                ScopeEntityIds = ["string"],
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Utilization = 0,
                CurrencyID = "currencyId",
                FeatureID = "featureId",
            },
        ];
        Pagination expectedPagination = new("next");

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerRetrieveGovernanceResponse
        {
            Data =
            [
                new()
                {
                    Cadence = "cadence",
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    EntityType = "entityType",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Utilization = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            Pagination = new("next"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerRetrieveGovernanceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerRetrieveGovernanceResponse
        {
            Data =
            [
                new()
                {
                    Cadence = "cadence",
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    EntityType = "entityType",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Utilization = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            Pagination = new("next"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerRetrieveGovernanceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Data> expectedData =
        [
            new()
            {
                Cadence = "cadence",
                CurrentUsage = 0,
                EntityID = "entityId",
                EntityType = "entityType",
                ParentID = "parentId",
                ScopeEntityIds = ["string"],
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Utilization = 0,
                CurrencyID = "currencyId",
                FeatureID = "featureId",
            },
        ];
        Pagination expectedPagination = new("next");

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerRetrieveGovernanceResponse
        {
            Data =
            [
                new()
                {
                    Cadence = "cadence",
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    EntityType = "entityType",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Utilization = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            Pagination = new("next"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerRetrieveGovernanceResponse
        {
            Data =
            [
                new()
                {
                    Cadence = "cadence",
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    EntityType = "entityType",
                    ParentID = "parentId",
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Utilization = 0,
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
            Pagination = new("next"),
        };

        CustomerRetrieveGovernanceResponse copied = new(model);

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
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        string expectedCadence = "cadence";
        double expectedCurrentUsage = 0;
        string expectedEntityID = "entityId";
        string expectedEntityType = "entityType";
        string expectedParentID = "parentId";
        List<string> expectedScopeEntityIds = ["string"];
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUtilization = 0;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedParentID, model.ParentID);
        Assert.Equal(expectedScopeEntityIds.Count, model.ScopeEntityIds.Count);
        for (int i = 0; i < expectedScopeEntityIds.Count; i++)
        {
            Assert.Equal(expectedScopeEntityIds[i], model.ScopeEntityIds[i]);
        }
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, model.UsagePeriodStart);
        Assert.Equal(expectedUtilization, model.Utilization);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,
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
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCadence = "cadence";
        double expectedCurrentUsage = 0;
        string expectedEntityID = "entityId";
        string expectedEntityType = "entityType";
        string expectedParentID = "parentId";
        List<string> expectedScopeEntityIds = ["string"];
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUtilization = 0;
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedParentID, deserialized.ParentID);
        Assert.Equal(expectedScopeEntityIds.Count, deserialized.ScopeEntityIds.Count);
        for (int i = 0; i < expectedScopeEntityIds.Count; i++)
        {
            Assert.Equal(expectedScopeEntityIds[i], deserialized.ScopeEntityIds[i]);
        }
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, deserialized.UsagePeriodStart);
        Assert.Equal(expectedUtilization, deserialized.Utilization);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,
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
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,
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
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,

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
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,

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
            Cadence = "cadence",
            CurrentUsage = 0,
            EntityID = "entityId",
            EntityType = "entityType",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination { Next = "next" };

        string expectedNext = "next";

        Assert.Equal(expectedNext, model.Next);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination { Next = "next" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination { Next = "next" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "next";

        Assert.Equal(expectedNext, deserialized.Next);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination { Next = "next" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination { Next = "next" };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
