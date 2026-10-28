using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Customers.Governance;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Governance;

public class GovernanceListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GovernanceListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        List<GovernanceListResponse> expectedData =
        [
            new()
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
            },
        ];
        Pagination expectedPagination = new() { Next = "next", Prev = "prev" };

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
        var model = new GovernanceListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GovernanceListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GovernanceListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GovernanceListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GovernanceListResponse> expectedData =
        [
            new()
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
            },
        ];
        Pagination expectedPagination = new() { Next = "next", Prev = "prev" };

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
        var model = new GovernanceListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GovernanceListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        GovernanceListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        string expectedNext = "next";
        string expectedPrev = "prev";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

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
        var model = new Pagination { Next = "next", Prev = "prev" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "next";
        string expectedPrev = "prev";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
