using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerRetrieveEntitlementsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponse
        {
            Data = new()
            {
                AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new Feature()
                    {
                        AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FeatureValue = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
        };

        CustomerRetrieveEntitlementsResponseData expectedData = new()
        {
            AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new Feature()
                {
                    AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FeatureValue = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponse
        {
            Data = new()
            {
                AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new Feature()
                    {
                        AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FeatureValue = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerRetrieveEntitlementsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponse
        {
            Data = new()
            {
                AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new Feature()
                    {
                        AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FeatureValue = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerRetrieveEntitlementsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerRetrieveEntitlementsResponseData expectedData = new()
        {
            AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new Feature()
                {
                    AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FeatureValue = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponse
        {
            Data = new()
            {
                AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new Feature()
                    {
                        AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FeatureValue = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponse
        {
            Data = new()
            {
                AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new Feature()
                    {
                        AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        FeatureValue = new()
                        {
                            DisplayName = "displayName",
                            FeatureStatus = FeatureStatus.New,
                            FeatureType = FeatureType.Boolean,
                            RefID = "refId",
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
        };

        CustomerRetrieveEntitlementsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerRetrieveEntitlementsResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponseData
        {
            AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new Feature()
                {
                    AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FeatureValue = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        ApiEnum<string, AccessDeniedReason> expectedAccessDeniedReason =
            AccessDeniedReason.CustomerNotFound;
        List<Entitlement> expectedEntitlements =
        [
            new Feature()
            {
                AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FeatureValue = new()
                {
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                    RefID = "refId",
                },
                HasUnlimitedUsage = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedAccessDeniedReason, model.AccessDeniedReason);
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponseData
        {
            AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new Feature()
                {
                    AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FeatureValue = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerRetrieveEntitlementsResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponseData
        {
            AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new Feature()
                {
                    AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FeatureValue = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerRetrieveEntitlementsResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccessDeniedReason> expectedAccessDeniedReason =
            AccessDeniedReason.CustomerNotFound;
        List<Entitlement> expectedEntitlements =
        [
            new Feature()
            {
                AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FeatureValue = new()
                {
                    DisplayName = "displayName",
                    FeatureStatus = FeatureStatus.New,
                    FeatureType = FeatureType.Boolean,
                    RefID = "refId",
                },
                HasUnlimitedUsage = true,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedAccessDeniedReason, deserialized.AccessDeniedReason);
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponseData
        {
            AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new Feature()
                {
                    AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FeatureValue = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerRetrieveEntitlementsResponseData
        {
            AccessDeniedReason = AccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new Feature()
                {
                    AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FeatureValue = new()
                    {
                        DisplayName = "displayName",
                        FeatureStatus = FeatureStatus.New,
                        FeatureType = FeatureType.Boolean,
                        RefID = "refId",
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        CustomerRetrieveEntitlementsResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(AccessDeniedReason.CustomerNotFound)]
    [InlineData(AccessDeniedReason.NoActiveSubscription)]
    [InlineData(AccessDeniedReason.CustomerIsArchived)]
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
    [InlineData(AccessDeniedReason.CustomerNotFound)]
    [InlineData(AccessDeniedReason.NoActiveSubscription)]
    [InlineData(AccessDeniedReason.CustomerIsArchived)]
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

public class EntitlementTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        Entitlement value = new Feature()
        {
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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
        Entitlement value = new Credit()
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        Entitlement value = new Feature()
        {
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        Entitlement value = new Credit()
        {
            AccessDeniedReason = CreditAccessDeniedReason.FeatureNotFound,
            Currency = new()
            {
                CurrencyID = "currencyId",
                DisplayName = "displayName",
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            element,
            ModelBase.SerializerOptions
        );

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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
            },
            HasUnlimitedUsage = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, FeatureAccessDeniedReason> expectedAccessDeniedReason =
            FeatureAccessDeniedReason.FeatureNotFound;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        FeatureFeature expectedFeatureValue = new()
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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

        ApiEnum<string, FeatureAccessDeniedReason> expectedAccessDeniedReason =
            FeatureAccessDeniedReason.FeatureNotFound;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        FeatureFeature expectedFeatureValue = new()
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
        };

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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrentUsage = null,
            EntitlementUpdatedAt = null,
            FeatureValue = null,
            HasUnlimitedUsage = null,
            UsagePeriodAnchor = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
            ValidUntil = null,
        };

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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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
            AccessDeniedReason = FeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FeatureValue = new()
            {
                DisplayName = "displayName",
                FeatureStatus = FeatureStatus.New,
                FeatureType = FeatureType.Boolean,
                RefID = "refId",
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

public class FeatureAccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(FeatureAccessDeniedReason.FeatureNotFound)]
    [InlineData(FeatureAccessDeniedReason.CustomerNotFound)]
    [InlineData(FeatureAccessDeniedReason.CustomerIsArchived)]
    [InlineData(FeatureAccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(FeatureAccessDeniedReason.NoActiveSubscription)]
    [InlineData(FeatureAccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(FeatureAccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(FeatureAccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(FeatureAccessDeniedReason.BudgetExceeded)]
    [InlineData(FeatureAccessDeniedReason.Unknown)]
    [InlineData(FeatureAccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(FeatureAccessDeniedReason.Revoked)]
    [InlineData(FeatureAccessDeniedReason.InsufficientCredits)]
    [InlineData(FeatureAccessDeniedReason.EntitlementNotFound)]
    public void Validation_Works(FeatureAccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureAccessDeniedReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureAccessDeniedReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureAccessDeniedReason.FeatureNotFound)]
    [InlineData(FeatureAccessDeniedReason.CustomerNotFound)]
    [InlineData(FeatureAccessDeniedReason.CustomerIsArchived)]
    [InlineData(FeatureAccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(FeatureAccessDeniedReason.NoActiveSubscription)]
    [InlineData(FeatureAccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(FeatureAccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(FeatureAccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(FeatureAccessDeniedReason.BudgetExceeded)]
    [InlineData(FeatureAccessDeniedReason.Unknown)]
    [InlineData(FeatureAccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(FeatureAccessDeniedReason.Revoked)]
    [InlineData(FeatureAccessDeniedReason.InsufficientCredits)]
    [InlineData(FeatureAccessDeniedReason.EntitlementNotFound)]
    public void SerializationRoundtrip_Works(FeatureAccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureAccessDeniedReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureAccessDeniedReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureAccessDeniedReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureAccessDeniedReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FeatureFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureFeature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        string expectedDisplayName = "displayName";
        ApiEnum<string, FeatureStatus> expectedFeatureStatus = FeatureStatus.New;
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;
        string expectedRefID = "refId";

        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFeatureStatus, model.FeatureStatus);
        Assert.Equal(expectedFeatureType, model.FeatureType);
        Assert.Equal(expectedRefID, model.RefID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureFeature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
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
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDisplayName = "displayName";
        ApiEnum<string, FeatureStatus> expectedFeatureStatus = FeatureStatus.New;
        ApiEnum<string, FeatureType> expectedFeatureType = FeatureType.Boolean;
        string expectedRefID = "refId";

        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFeatureStatus, deserialized.FeatureStatus);
        Assert.Equal(expectedFeatureType, deserialized.FeatureType);
        Assert.Equal(expectedRefID, deserialized.RefID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureFeature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureFeature
        {
            DisplayName = "displayName",
            FeatureStatus = FeatureStatus.New,
            FeatureType = FeatureType.Boolean,
            RefID = "refId",
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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, CreditAccessDeniedReason> expectedAccessDeniedReason =
            CreditAccessDeniedReason.FeatureNotFound;
        CreditCurrency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };
        double expectedCurrentUsage = 0;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, CreditAccessDeniedReason> expectedAccessDeniedReason =
            CreditAccessDeniedReason.FeatureNotFound;
        CreditCurrency expectedCurrency = new()
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };
        double expectedCurrentUsage = 0;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            EntitlementUpdatedAt = null,
            UsagePeriodEnd = null,
            ValidUntil = null,
        };

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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
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
                AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
                Description = "description",
                UnitPlural = "unitPlural",
                UnitSingular = "unitSingular",
            },
            CurrentUsage = 0,
            IsGranted = true,
            UsageLimit = 0,
            UsageUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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

public class CreditCurrencyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string expectedCurrencyID = "currencyId";
        string expectedDisplayName = "displayName";
        JsonElement expectedAdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        string expectedUnitPlural = "unitPlural";
        string expectedUnitSingular = "unitSingular";

        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.NotNull(model.AdditionalMetaData);
        Assert.True(
            JsonElement.DeepEquals(expectedAdditionalMetaData, model.AdditionalMetaData.Value)
        );
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedUnitPlural, model.UnitPlural);
        Assert.Equal(expectedUnitSingular, model.UnitSingular);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditCurrency>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditCurrency>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyID = "currencyId";
        string expectedDisplayName = "displayName";
        JsonElement expectedAdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedDescription = "description";
        string expectedUnitPlural = "unitPlural";
        string expectedUnitSingular = "unitSingular";

        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.NotNull(deserialized.AdditionalMetaData);
        Assert.True(
            JsonElement.DeepEquals(
                expectedAdditionalMetaData,
                deserialized.AdditionalMetaData.Value
            )
        );
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedUnitPlural, deserialized.UnitPlural);
        Assert.Equal(expectedUnitSingular, deserialized.UnitSingular);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        Assert.Null(model.AdditionalMetaData);
        Assert.False(model.RawData.ContainsKey("additionalMetaData"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",

            // Null should be interpreted as omitted for these properties
            AdditionalMetaData = null,
        };

        Assert.Null(model.AdditionalMetaData);
        Assert.False(model.RawData.ContainsKey("additionalMetaData"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",

            // Null should be interpreted as omitted for these properties
            AdditionalMetaData = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.UnitPlural);
        Assert.False(model.RawData.ContainsKey("unitPlural"));
        Assert.Null(model.UnitSingular);
        Assert.False(model.RawData.ContainsKey("unitSingular"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),

            Description = null,
            UnitPlural = null,
            UnitSingular = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.UnitPlural);
        Assert.True(model.RawData.ContainsKey("unitPlural"));
        Assert.Null(model.UnitSingular);
        Assert.True(model.RawData.ContainsKey("unitSingular"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),

            Description = null,
            UnitPlural = null,
            UnitSingular = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            AdditionalMetaData = JsonSerializer.Deserialize<JsonElement>("{}"),
            Description = "description",
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        CreditCurrency copied = new(model);

        Assert.Equal(model, copied);
    }
}
