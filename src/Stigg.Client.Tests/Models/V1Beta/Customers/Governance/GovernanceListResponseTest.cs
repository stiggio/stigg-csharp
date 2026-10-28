using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Customers.Governance;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Governance;

public class GovernanceListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
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
        string expectedDisplayName = "displayName";
        string expectedEntityID = "entityId";
        string expectedEntityTypeID = "entityTypeId";
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
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedEntityTypeID, model.EntityTypeID);
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
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
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
        var deserialized = JsonSerializer.Deserialize<GovernanceListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
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
        var deserialized = JsonSerializer.Deserialize<GovernanceListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCadence = "cadence";
        double expectedCurrentUsage = 0;
        string expectedDisplayName = "displayName";
        string expectedEntityID = "entityId";
        string expectedEntityTypeID = "entityTypeId";
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
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedEntityTypeID, deserialized.EntityTypeID);
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
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
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
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
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
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
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
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
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
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
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
        var model = new GovernanceListResponse
        {
            Cadence = "cadence",
            CurrentUsage = 0,
            DisplayName = "displayName",
            EntityID = "entityId",
            EntityTypeID = "entityTypeId",
            ParentID = "parentId",
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Utilization = 0,
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        GovernanceListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
