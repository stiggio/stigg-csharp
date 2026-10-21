using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V2.Usage;

namespace Stigg.Client.Tests.Models.V2.Usage;

public class UsageReportResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageReportResponse
        {
            Data = new()
            {
                Usages =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "customerId",
                        FeatureID = "featureId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                        Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                        CurrentUsage = 0,
                        NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ResourceID = "resourceId",
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Credits =
                [
                    new()
                    {
                        CurrencyID = "currencyId",
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        ResourceID = "resourceId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsageLimit = 0,
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Entities =
                [
                    new()
                    {
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        EntitlementID = "entitlementId",
                        EntityID = "entityId",
                        ResourceID = "resourceId",
                        ScopeEntityIds = ["string"],
                        UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CurrencyID = "currencyId",
                        FeatureID = "featureId",
                    },
                ],
            },
        };

        Data expectedData = new()
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Credits =
            [
                new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Entities =
            [
                new()
                {
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    EntitlementID = "entitlementId",
                    EntityID = "entityId",
                    ResourceID = "resourceId",
                    ScopeEntityIds = ["string"],
                    UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageReportResponse
        {
            Data = new()
            {
                Usages =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "customerId",
                        FeatureID = "featureId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                        Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                        CurrentUsage = 0,
                        NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ResourceID = "resourceId",
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Credits =
                [
                    new()
                    {
                        CurrencyID = "currencyId",
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        ResourceID = "resourceId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsageLimit = 0,
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Entities =
                [
                    new()
                    {
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        EntitlementID = "entitlementId",
                        EntityID = "entityId",
                        ResourceID = "resourceId",
                        ScopeEntityIds = ["string"],
                        UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CurrencyID = "currencyId",
                        FeatureID = "featureId",
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageReportResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageReportResponse
        {
            Data = new()
            {
                Usages =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "customerId",
                        FeatureID = "featureId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                        Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                        CurrentUsage = 0,
                        NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ResourceID = "resourceId",
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Credits =
                [
                    new()
                    {
                        CurrencyID = "currencyId",
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        ResourceID = "resourceId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsageLimit = 0,
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Entities =
                [
                    new()
                    {
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        EntitlementID = "entitlementId",
                        EntityID = "entityId",
                        ResourceID = "resourceId",
                        ScopeEntityIds = ["string"],
                        UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CurrencyID = "currencyId",
                        FeatureID = "featureId",
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageReportResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Credits =
            [
                new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Entities =
            [
                new()
                {
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    EntitlementID = "entitlementId",
                    EntityID = "entityId",
                    ResourceID = "resourceId",
                    ScopeEntityIds = ["string"],
                    UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageReportResponse
        {
            Data = new()
            {
                Usages =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "customerId",
                        FeatureID = "featureId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                        Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                        CurrentUsage = 0,
                        NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ResourceID = "resourceId",
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Credits =
                [
                    new()
                    {
                        CurrencyID = "currencyId",
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        ResourceID = "resourceId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsageLimit = 0,
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Entities =
                [
                    new()
                    {
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        EntitlementID = "entitlementId",
                        EntityID = "entityId",
                        ResourceID = "resourceId",
                        ScopeEntityIds = ["string"],
                        UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CurrencyID = "currencyId",
                        FeatureID = "featureId",
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageReportResponse
        {
            Data = new()
            {
                Usages =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CustomerID = "customerId",
                        FeatureID = "featureId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = 0,
                        Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                        CurrentUsage = 0,
                        NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ResourceID = "resourceId",
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Credits =
                [
                    new()
                    {
                        CurrencyID = "currencyId",
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        ResourceID = "resourceId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsageLimit = 0,
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                Entities =
                [
                    new()
                    {
                        CurrentUsage = 0,
                        CustomerID = "customerId",
                        EntitlementID = "entitlementId",
                        EntityID = "entityId",
                        ResourceID = "resourceId",
                        ScopeEntityIds = ["string"],
                        UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        CurrencyID = "currencyId",
                        FeatureID = "featureId",
                    },
                ],
            },
        };

        UsageReportResponse copied = new(model);

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
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Credits =
            [
                new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Entities =
            [
                new()
                {
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    EntitlementID = "entitlementId",
                    EntityID = "entityId",
                    ResourceID = "resourceId",
                    ScopeEntityIds = ["string"],
                    UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        List<DataUsage> expectedUsages =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                FeatureID = "featureId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Value = 0,
                Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                CurrentUsage = 0,
                NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ResourceID = "resourceId",
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        List<DataCredit> expectedCredits =
        [
            new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                CustomerID = "customerId",
                ResourceID = "resourceId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        List<Entity> expectedEntities =
        [
            new()
            {
                CurrentUsage = 0,
                CustomerID = "customerId",
                EntitlementID = "entitlementId",
                EntityID = "entityId",
                ResourceID = "resourceId",
                ScopeEntityIds = ["string"],
                UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                FeatureID = "featureId",
            },
        ];

        Assert.Equal(expectedUsages.Count, model.Usages.Count);
        for (int i = 0; i < expectedUsages.Count; i++)
        {
            Assert.Equal(expectedUsages[i], model.Usages[i]);
        }
        Assert.NotNull(model.Credits);
        Assert.Equal(expectedCredits.Count, model.Credits.Count);
        for (int i = 0; i < expectedCredits.Count; i++)
        {
            Assert.Equal(expectedCredits[i], model.Credits[i]);
        }
        Assert.NotNull(model.Entities);
        Assert.Equal(expectedEntities.Count, model.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], model.Entities[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Credits =
            [
                new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Entities =
            [
                new()
                {
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    EntitlementID = "entitlementId",
                    EntityID = "entityId",
                    ResourceID = "resourceId",
                    ScopeEntityIds = ["string"],
                    UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
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
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Credits =
            [
                new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Entities =
            [
                new()
                {
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    EntitlementID = "entitlementId",
                    EntityID = "entityId",
                    ResourceID = "resourceId",
                    ScopeEntityIds = ["string"],
                    UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<DataUsage> expectedUsages =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                FeatureID = "featureId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Value = 0,
                Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                CurrentUsage = 0,
                NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ResourceID = "resourceId",
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        List<DataCredit> expectedCredits =
        [
            new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                CustomerID = "customerId",
                ResourceID = "resourceId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        List<Entity> expectedEntities =
        [
            new()
            {
                CurrentUsage = 0,
                CustomerID = "customerId",
                EntitlementID = "entitlementId",
                EntityID = "entityId",
                ResourceID = "resourceId",
                ScopeEntityIds = ["string"],
                UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                FeatureID = "featureId",
            },
        ];

        Assert.Equal(expectedUsages.Count, deserialized.Usages.Count);
        for (int i = 0; i < expectedUsages.Count; i++)
        {
            Assert.Equal(expectedUsages[i], deserialized.Usages[i]);
        }
        Assert.NotNull(deserialized.Credits);
        Assert.Equal(expectedCredits.Count, deserialized.Credits.Count);
        for (int i = 0; i < expectedCredits.Count; i++)
        {
            Assert.Equal(expectedCredits[i], deserialized.Credits[i]);
        }
        Assert.NotNull(deserialized.Entities);
        Assert.Equal(expectedEntities.Count, deserialized.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], deserialized.Entities[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Credits =
            [
                new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Entities =
            [
                new()
                {
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    EntitlementID = "entitlementId",
                    EntityID = "entityId",
                    ResourceID = "resourceId",
                    ScopeEntityIds = ["string"],
                    UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Null(model.Credits);
        Assert.False(model.RawData.ContainsKey("credits"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            // Null should be interpreted as omitted for these properties
            Credits = null,
            Entities = null,
        };

        Assert.Null(model.Credits);
        Assert.False(model.RawData.ContainsKey("credits"));
        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            // Null should be interpreted as omitted for these properties
            Credits = null,
            Entities = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Usages =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = 0,
                    Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Credits =
            [
                new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Entities =
            [
                new()
                {
                    CurrentUsage = 0,
                    CustomerID = "customerId",
                    EntitlementID = "entitlementId",
                    EntityID = "entityId",
                    ResourceID = "resourceId",
                    ScopeEntityIds = ["string"],
                    UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    FeatureID = "featureId",
                },
            ],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
            Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedValue = 0;
        Credit expectedCredit = new() { Consumed = 0, CurrencyID = "currencyId" };
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedNextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedCredit, model.Credit);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedNextResetDate, model.NextResetDate);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, model.UsagePeriodStart);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
            Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataUsage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
            Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedValue = 0;
        Credit expectedCredit = new() { Consumed = 0, CurrencyID = "currencyId" };
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedNextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedCredit, deserialized.Credit);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedNextResetDate, deserialized.NextResetDate);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, deserialized.UsagePeriodStart);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
            Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        Assert.Null(model.Credit);
        Assert.False(model.RawData.ContainsKey("credit"));
        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.NextResetDate);
        Assert.False(model.RawData.ContainsKey("nextResetDate"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.False(model.RawData.ContainsKey("usagePeriodStart"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,

            Credit = null,
            CurrentUsage = null,
            NextResetDate = null,
            ResourceID = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
        };

        Assert.Null(model.Credit);
        Assert.True(model.RawData.ContainsKey("credit"));
        Assert.Null(model.CurrentUsage);
        Assert.True(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.NextResetDate);
        Assert.True(model.RawData.ContainsKey("nextResetDate"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.True(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.True(model.RawData.ContainsKey("usagePeriodStart"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,

            Credit = null,
            CurrentUsage = null,
            NextResetDate = null,
            ResourceID = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataUsage
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = 0,
            Credit = new() { Consumed = 0, CurrencyID = "currencyId" },
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DataUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Credit { Consumed = 0, CurrencyID = "currencyId" };

        double expectedConsumed = 0;
        string expectedCurrencyID = "currencyId";

        Assert.Equal(expectedConsumed, model.Consumed);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Credit { Consumed = 0, CurrencyID = "currencyId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Credit { Consumed = 0, CurrencyID = "currencyId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedConsumed = 0;
        string expectedCurrencyID = "currencyId";

        Assert.Equal(expectedConsumed, deserialized.Consumed);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Credit { Consumed = 0, CurrencyID = "currencyId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Credit { Consumed = 0, CurrencyID = "currencyId" };

        Credit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataCreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCurrencyID = "currencyId";
        double expectedCurrentUsage = 0;
        string expectedCustomerID = "customerId";
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataCredit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataCredit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyID = "currencyId";
        double expectedCurrentUsage = 0;
        string expectedCustomerID = "customerId";
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,

            UsagePeriodEnd = null,
        };

        Assert.Null(model.UsagePeriodEnd);
        Assert.True(model.RawData.ContainsKey("usagePeriodEnd"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,

            UsagePeriodEnd = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataCredit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            CustomerID = "customerId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DataCredit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entity
        {
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        double expectedCurrentUsage = 0;
        string expectedCustomerID = "customerId";
        string expectedEntitlementID = "entitlementId";
        string expectedEntityID = "entityId";
        string expectedResourceID = "resourceId";
        List<string> expectedScopeEntityIds = ["string"];
        DateTimeOffset expectedUsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEntitlementID, model.EntitlementID);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedScopeEntityIds.Count, model.ScopeEntityIds.Count);
        for (int i = 0; i < expectedScopeEntityIds.Count; i++)
        {
            Assert.Equal(expectedScopeEntityIds[i], model.ScopeEntityIds[i]);
        }
        Assert.Equal(expectedUsageUpdatedAt, model.UsageUpdatedAt);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entity
        {
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            FeatureID = "featureId",
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
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entity>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedCurrentUsage = 0;
        string expectedCustomerID = "customerId";
        string expectedEntitlementID = "entitlementId";
        string expectedEntityID = "entityId";
        string expectedResourceID = "resourceId";
        List<string> expectedScopeEntityIds = ["string"];
        DateTimeOffset expectedUsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyID = "currencyId";
        string expectedFeatureID = "featureId";

        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEntitlementID, deserialized.EntitlementID);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedScopeEntityIds.Count, deserialized.ScopeEntityIds.Count);
        for (int i = 0; i < expectedScopeEntityIds.Count; i++)
        {
            Assert.Equal(expectedScopeEntityIds[i], deserialized.ScopeEntityIds[i]);
        }
        Assert.Equal(expectedUsageUpdatedAt, deserialized.UsageUpdatedAt);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entity
        {
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entity
        {
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currencyId"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entity
        {
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entity
        {
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

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
        var model = new Entity
        {
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            CurrencyID = null,
            FeatureID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entity
        {
            CurrentUsage = 0,
            CustomerID = "customerId",
            EntitlementID = "entitlementId",
            EntityID = "entityId",
            ResourceID = "resourceId",
            ScopeEntityIds = ["string"],
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            FeatureID = "featureId",
        };

        Entity copied = new(model);

        Assert.Equal(model, copied);
    }
}
