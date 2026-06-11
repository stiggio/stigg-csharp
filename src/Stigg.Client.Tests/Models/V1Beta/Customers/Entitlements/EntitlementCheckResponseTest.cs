using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1Beta.Customers.Entitlements;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Entitlements;

public class EntitlementCheckResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCheckResponse
        {
            Data = new Feature()
            {
                AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                Chains =
                [
                    [
                        new()
                        {
                            CurrentUsage = 0,
                            EntityID = "entityId",
                            IsGranted = true,
                            ScopeEntityIds = ["string"],
                            UsageLimit = 0,
                        },
                    ],
                ],
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FeatureValue = new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                },
                HasUnlimitedUsage = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Data expectedData = new Feature()
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCheckResponse
        {
            Data = new Feature()
            {
                AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                Chains =
                [
                    [
                        new()
                        {
                            CurrentUsage = 0,
                            EntityID = "entityId",
                            IsGranted = true,
                            ScopeEntityIds = ["string"],
                            UsageLimit = 0,
                        },
                    ],
                ],
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FeatureValue = new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                },
                HasUnlimitedUsage = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCheckResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCheckResponse
        {
            Data = new Feature()
            {
                AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                Chains =
                [
                    [
                        new()
                        {
                            CurrentUsage = 0,
                            EntityID = "entityId",
                            IsGranted = true,
                            ScopeEntityIds = ["string"],
                            UsageLimit = 0,
                        },
                    ],
                ],
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FeatureValue = new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                },
                HasUnlimitedUsage = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCheckResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new Feature()
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementCheckResponse
        {
            Data = new Feature()
            {
                AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                Chains =
                [
                    [
                        new()
                        {
                            CurrentUsage = 0,
                            EntityID = "entityId",
                            IsGranted = true,
                            ScopeEntityIds = ["string"],
                            UsageLimit = 0,
                        },
                    ],
                ],
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FeatureValue = new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                },
                HasUnlimitedUsage = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCheckResponse
        {
            Data = new Feature()
            {
                AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                Chains =
                [
                    [
                        new()
                        {
                            CurrentUsage = 0,
                            EntityID = "entityId",
                            IsGranted = true,
                            ScopeEntityIds = ["string"],
                            UsageLimit = 0,
                        },
                    ],
                ],
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FeatureValue = new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                },
                HasUnlimitedUsage = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        EntitlementCheckResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        Data value = new Feature()
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void CreditValidationWorks()
    {
        Data value = new Credit()
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        Data value = new Feature()
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        Data value = new Credit()
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, AccessDeniedReason> expectedAccessDeniedReason =
            AccessDeniedReason.FeatureNotFound;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        List<List<BetaChainNode>> expectedChains =
        [
            [
                new()
                {
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    IsGranted = true,
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                },
            ],
        ];
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        FeatureFeature expectedFeatureValue = new()
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
        };
        bool expectedHasUnlimitedUsage = true;
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, model.AccessDeniedReason);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Chains);
        Assert.Equal(expectedChains.Count, model.Chains.Count);
        for (int i = 0; i < expectedChains.Count; i++)
        {
            Assert.Equal(expectedChains[i].Count, model.Chains[i].Count);
            for (int i1 = 0; i1 < expectedChains[i].Count; i1++)
            {
                Assert.Equal(expectedChains[i][i1], model.Chains[i][i1]);
            }
        }
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedEntitlementUpdatedAt, model.EntitlementUpdatedAt);
        Assert.Equal(expectedFeatureValue, model.FeatureValue);
        Assert.Equal(expectedHasUnlimitedUsage, model.HasUnlimitedUsage);
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsagePeriodAnchor, model.UsagePeriodAnchor);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, model.UsagePeriodStart);
        Assert.Equal(expectedValidUntil, model.ValidUntil);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccessDeniedReason> expectedAccessDeniedReason =
            AccessDeniedReason.FeatureNotFound;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        List<List<BetaChainNode>> expectedChains =
        [
            [
                new()
                {
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    IsGranted = true,
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                },
            ],
        ];
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        FeatureFeature expectedFeatureValue = new()
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
        };
        bool expectedHasUnlimitedUsage = true;
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, deserialized.AccessDeniedReason);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Chains);
        Assert.Equal(expectedChains.Count, deserialized.Chains.Count);
        for (int i = 0; i < expectedChains.Count; i++)
        {
            Assert.Equal(expectedChains[i].Count, deserialized.Chains[i].Count);
            for (int i1 = 0; i1 < expectedChains[i].Count; i1++)
            {
                Assert.Equal(expectedChains[i][i1], deserialized.Chains[i][i1]);
            }
        }
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedEntitlementUpdatedAt, deserialized.EntitlementUpdatedAt);
        Assert.Equal(expectedFeatureValue, deserialized.FeatureValue);
        Assert.Equal(expectedHasUnlimitedUsage, deserialized.HasUnlimitedUsage);
        Assert.Equal(expectedResetPeriod, deserialized.ResetPeriod);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsagePeriodAnchor, deserialized.UsagePeriodAnchor);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, deserialized.UsagePeriodStart);
        Assert.Equal(expectedValidUntil, deserialized.ValidUntil);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
        };

        Assert.Null(model.Chains);
        Assert.False(model.RawData.ContainsKey("chains"));
        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.FeatureValue);
        Assert.False(model.RawData.ContainsKey("feature"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.UsagePeriodAnchor);
        Assert.False(model.RawData.ContainsKey("usagePeriodAnchor"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.False(model.RawData.ContainsKey("usagePeriodStart"));
        Assert.Null(model.ValidUntil);
        Assert.False(model.RawData.ContainsKey("validUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            Chains = null,
            CurrentUsage = null,
            EntitlementUpdatedAt = null,
            FeatureValue = null,
            HasUnlimitedUsage = null,
            UsagePeriodAnchor = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
            ValidUntil = null,
        };

        Assert.Null(model.Chains);
        Assert.False(model.RawData.ContainsKey("chains"));
        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.FeatureValue);
        Assert.False(model.RawData.ContainsKey("feature"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.UsagePeriodAnchor);
        Assert.False(model.RawData.ContainsKey("usagePeriodAnchor"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.False(model.RawData.ContainsKey("usagePeriodStart"));
        Assert.Null(model.ValidUntil);
        Assert.False(model.RawData.ContainsKey("validUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            Chains = null,
            CurrentUsage = null,
            EntitlementUpdatedAt = null,
            FeatureValue = null,
            HasUnlimitedUsage = null,
            UsagePeriodAnchor = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
            ValidUntil = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ResetPeriod = null,
            UsageLimit = null,
        };

        Assert.Null(model.ResetPeriod);
        Assert.True(model.RawData.ContainsKey("resetPeriod"));
        Assert.Null(model.UsageLimit);
        Assert.True(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ResetPeriod = null,
            UsageLimit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Feature
        {
            AccessDeniedReason = AccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(AccessDeniedReason.FeatureNotFound)]
    [InlineData(AccessDeniedReason.CustomerNotFound)]
    [InlineData(AccessDeniedReason.CustomerIsArchived)]
    [InlineData(AccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(AccessDeniedReason.NoActiveSubscription)]
    [InlineData(AccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(AccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(AccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(AccessDeniedReason.BudgetExceeded)]
    [InlineData(AccessDeniedReason.Unknown)]
    [InlineData(AccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(AccessDeniedReason.Revoked)]
    [InlineData(AccessDeniedReason.InsufficientCredits)]
    [InlineData(AccessDeniedReason.EntitlementNotFound)]
    public void Validation_Works(AccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccessDeniedReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccessDeniedReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccessDeniedReason.FeatureNotFound)]
    [InlineData(AccessDeniedReason.CustomerNotFound)]
    [InlineData(AccessDeniedReason.CustomerIsArchived)]
    [InlineData(AccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(AccessDeniedReason.NoActiveSubscription)]
    [InlineData(AccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(AccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(AccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(AccessDeniedReason.BudgetExceeded)]
    [InlineData(AccessDeniedReason.Unknown)]
    [InlineData(AccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(AccessDeniedReason.Revoked)]
    [InlineData(AccessDeniedReason.InsufficientCredits)]
    [InlineData(AccessDeniedReason.EntitlementNotFound)]
    public void SerializationRoundtrip_Works(AccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccessDeniedReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccessDeniedReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccessDeniedReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccessDeniedReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaChainNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        double expectedCurrentUsage = 0;
        string expectedEntityID = "entityId";
        bool expectedIsGranted = true;
        List<string> expectedScopeEntityIds = ["string"];
        double expectedUsageLimit = 0;

        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedIsGranted, model.IsGranted);
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
        var model = new BetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaChainNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaChainNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCurrentUsage = 0;
        string expectedEntityID = "entityId";
        bool expectedIsGranted = true;
        List<string> expectedScopeEntityIds = ["string"];
        double expectedUsageLimit = 0;

        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
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
        var model = new BetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        BetaChainNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        ApiEnum<string, FeatureStatus> expectedFeatureStatus = FeatureStatus.New;
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFeatureStatus, model.FeatureStatus);
        Assert.Equal(expectedFeatureType, model.FeatureType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        ApiEnum<string, FeatureStatus> expectedFeatureStatus = FeatureStatus.New;
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFeatureStatus, deserialized.FeatureStatus);
        Assert.Equal(expectedFeatureType, deserialized.FeatureType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
        };

        FeatureFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureStatusTest : TestBase
{
    [Theory]
    [InlineData(FeatureStatus.New)]
    [InlineData(FeatureStatus.Suspended)]
    [InlineData(FeatureStatus.Active)]
    public void Validation_Works(FeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureStatus.New)]
    [InlineData(FeatureStatus.Suspended)]
    [InlineData(FeatureStatus.Active)]
    public void SerializationRoundtrip_Works(FeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(FeatureType.Boolean)]
    [InlineData(FeatureType.Number)]
    [InlineData(FeatureType.Enum)]
    public void Validation_Works(FeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureType.Boolean)]
    [InlineData(FeatureType.Number)]
    [InlineData(FeatureType.Enum)]
    public void SerializationRoundtrip_Works(FeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(ResetPeriod.Year)]
    [InlineData(ResetPeriod.Month)]
    [InlineData(ResetPeriod.Week)]
    [InlineData(ResetPeriod.Day)]
    [InlineData(ResetPeriod.Hour)]
    public void Validation_Works(ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResetPeriod.Year)]
    [InlineData(ResetPeriod.Month)]
    [InlineData(ResetPeriod.Week)]
    [InlineData(ResetPeriod.Day)]
    [InlineData(ResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(ResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Credit
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, CreditAccessDeniedReason> expectedAccessDeniedReason =
            CreditAccessDeniedReason.FeatureNotFound;
        Currency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };
        double expectedCurrentUsage = 0;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<List<CreditBetaChainNode>> expectedChains =
        [
            [
                new()
                {
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    IsGranted = true,
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                },
            ],
        ];
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, model.AccessDeniedReason);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsageUpdatedAt, model.UsageUpdatedAt);
        Assert.NotNull(model.Chains);
        Assert.Equal(expectedChains.Count, model.Chains.Count);
        for (int i = 0; i < expectedChains.Count; i++)
        {
            Assert.Equal(expectedChains[i].Count, model.Chains[i].Count);
            for (int i1 = 0; i1 < expectedChains[i].Count; i1++)
            {
                Assert.Equal(expectedChains[i][i1], model.Chains[i][i1]);
            }
        }
        Assert.Equal(expectedEntitlementUpdatedAt, model.EntitlementUpdatedAt);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
        Assert.Equal(expectedValidUntil, model.ValidUntil);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Credit
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, CreditAccessDeniedReason> expectedAccessDeniedReason =
            CreditAccessDeniedReason.FeatureNotFound;
        Currency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };
        double expectedCurrentUsage = 0;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<List<CreditBetaChainNode>> expectedChains =
        [
            [
                new()
                {
                    CurrentUsage = 0,
                    EntityID = "entityId",
                    IsGranted = true,
                    ScopeEntityIds = ["string"],
                    UsageLimit = 0,
                },
            ],
        ];
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAccessDeniedReason, deserialized.AccessDeniedReason);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsageUpdatedAt, deserialized.UsageUpdatedAt);
        Assert.NotNull(deserialized.Chains);
        Assert.Equal(expectedChains.Count, deserialized.Chains.Count);
        for (int i = 0; i < expectedChains.Count; i++)
        {
            Assert.Equal(expectedChains[i].Count, deserialized.Chains[i].Count);
            for (int i1 = 0; i1 < expectedChains[i].Count; i1++)
            {
                Assert.Equal(expectedChains[i][i1], deserialized.Chains[i][i1]);
            }
        }
        Assert.Equal(expectedEntitlementUpdatedAt, deserialized.EntitlementUpdatedAt);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
        Assert.Equal(expectedValidUntil, deserialized.ValidUntil);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Credit
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Credit
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Chains);
        Assert.False(model.RawData.ContainsKey("chains"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.ValidUntil);
        Assert.False(model.RawData.ContainsKey("validUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Credit
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Credit
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Chains = null,
            EntitlementUpdatedAt = null,
            UsagePeriodEnd = null,
            ValidUntil = null,
        };

        Assert.Null(model.Chains);
        Assert.False(model.RawData.ContainsKey("chains"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.ValidUntil);
        Assert.False(model.RawData.ContainsKey("validUntil"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Credit
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Chains = null,
            EntitlementUpdatedAt = null,
            UsagePeriodEnd = null,
            ValidUntil = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Credit
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                Description = "description",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Chains =
            [
                [
                    new()
                    {
                        CurrentUsage = 0,
                        EntityID = "entityId",
                        IsGranted = true,
                        ScopeEntityIds = ["string"],
                        UsageLimit = 0,
                    },
                ],
            ],
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Credit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditAccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(CreditAccessDeniedReason.FeatureNotFound)]
    [InlineData(CreditAccessDeniedReason.CustomerNotFound)]
    [InlineData(CreditAccessDeniedReason.CustomerIsArchived)]
    [InlineData(CreditAccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(CreditAccessDeniedReason.NoActiveSubscription)]
    [InlineData(CreditAccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(CreditAccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(CreditAccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(CreditAccessDeniedReason.BudgetExceeded)]
    [InlineData(CreditAccessDeniedReason.Unknown)]
    [InlineData(CreditAccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(CreditAccessDeniedReason.Revoked)]
    [InlineData(CreditAccessDeniedReason.InsufficientCredits)]
    [InlineData(CreditAccessDeniedReason.EntitlementNotFound)]
    public void Validation_Works(CreditAccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditAccessDeniedReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditAccessDeniedReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditAccessDeniedReason.FeatureNotFound)]
    [InlineData(CreditAccessDeniedReason.CustomerNotFound)]
    [InlineData(CreditAccessDeniedReason.CustomerIsArchived)]
    [InlineData(CreditAccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(CreditAccessDeniedReason.NoActiveSubscription)]
    [InlineData(CreditAccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(CreditAccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(CreditAccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(CreditAccessDeniedReason.BudgetExceeded)]
    [InlineData(CreditAccessDeniedReason.Unknown)]
    [InlineData(CreditAccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(CreditAccessDeniedReason.Revoked)]
    [InlineData(CreditAccessDeniedReason.InsufficientCredits)]
    [InlineData(CreditAccessDeniedReason.EntitlementNotFound)]
    public void SerializationRoundtrip_Works(CreditAccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditAccessDeniedReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditAccessDeniedReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditAccessDeniedReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditAccessDeniedReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CurrencyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string expectedCurrencyID = "currencyId";
        string expectedDisplayName = "displayName";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedUnitPlural = "unitPlural";
        string expectedUnitSingular = "unitSingular";

        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedUnitPlural, model.UnitPlural);
        Assert.Equal(expectedUnitSingular, model.UnitSingular);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Currency>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Currency>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyID = "currencyId";
        string expectedDisplayName = "displayName";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedUnitPlural = "unitPlural";
        string expectedUnitSingular = "unitSingular";

        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedUnitPlural, deserialized.UnitPlural);
        Assert.Equal(expectedUnitSingular, deserialized.UnitSingular);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Currency { CurrencyID = "currencyId", DisplayName = "displayName" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.UnitPlural);
        Assert.False(model.RawData.ContainsKey("unitPlural"));
        Assert.Null(model.UnitSingular);
        Assert.False(model.RawData.ContainsKey("unitSingular"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Currency { CurrencyID = "currencyId", DisplayName = "displayName" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",

            Description = null,
            Metadata = null,
            UnitPlural = null,
            UnitSingular = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.UnitPlural);
        Assert.True(model.RawData.ContainsKey("unitPlural"));
        Assert.Null(model.UnitSingular);
        Assert.True(model.RawData.ContainsKey("unitSingular"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",

            Description = null,
            Metadata = null,
            UnitPlural = null,
            UnitSingular = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Currency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        Currency copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditBetaChainNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditBetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        double expectedCurrentUsage = 0;
        string expectedEntityID = "entityId";
        bool expectedIsGranted = true;
        List<string> expectedScopeEntityIds = ["string"];
        double expectedUsageLimit = 0;

        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedIsGranted, model.IsGranted);
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
        var model = new CreditBetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBetaChainNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditBetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditBetaChainNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCurrentUsage = 0;
        string expectedEntityID = "entityId";
        bool expectedIsGranted = true;
        List<string> expectedScopeEntityIds = ["string"];
        double expectedUsageLimit = 0;

        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
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
        var model = new CreditBetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditBetaChainNode
        {
            CurrentUsage = 0,
            EntityID = "entityId",
            IsGranted = true,
            ScopeEntityIds = ["string"],
            UsageLimit = 0,
        };

        CreditBetaChainNode copied = new(model);

        Assert.Equal(model, copied);
    }
}
