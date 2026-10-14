using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.Consumption;

namespace Stigg.Client.Tests.Models.V1.Credits.Consumption;

public class ConsumptionConsumeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                ResourceID = "resourceId",
            },
        };

        Data expectedData = new()
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
            ResourceID = "resourceId",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                ResourceID = "resourceId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumptionConsumeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                ResourceID = "resourceId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumptionConsumeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
            ResourceID = "resourceId",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                ResourceID = "resourceId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
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
                ResourceID = "resourceId",
            },
        };

        ConsumptionConsumeResponse copied = new(model);

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
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
            ResourceID = "resourceId",
        };

        double expectedAmount = 0;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Credit expectedCredit = new()
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
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
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedCredit, model.Credit);
        Assert.NotNull(model.Entities);
        Assert.Equal(expectedEntities.Count, model.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], model.Entities[i]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
            ResourceID = "resourceId",
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
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
            ResourceID = "resourceId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Credit expectedCredit = new()
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
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
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedCredit, deserialized.Credit);
        Assert.NotNull(deserialized.Entities);
        Assert.Equal(expectedEntities.Count, deserialized.Entities.Count);
        for (int i = 0; i < expectedEntities.Count; i++)
        {
            Assert.Equal(expectedEntities[i], deserialized.Entities[i]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
            ResourceID = "resourceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
        };

        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            Entities = null,
        };

        Assert.Null(model.Entities);
        Assert.False(model.RawData.ContainsKey("entities"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            Entities = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

        Assert.Null(model.Credit);
        Assert.False(model.RawData.ContainsKey("credit"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

            Credit = null,
            ResourceID = null,
        };

        Assert.Null(model.Credit);
        Assert.True(model.RawData.ContainsKey("credit"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

            Credit = null,
            ResourceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
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
            ResourceID = "resourceId",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCurrencyID = "currencyId";
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCurrencyID = "currencyId";
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
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
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,

            UsagePeriodEnd = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Credit copied = new(model);

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
