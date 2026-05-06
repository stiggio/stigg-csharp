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
                AccessDeniedReason =
                    CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new EntitlementFeature()
                    {
                        AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            ID = "id",
                            DisplayName = "displayName",
                            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
            AccessDeniedReason =
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new EntitlementFeature()
                {
                    AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                        FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
                AccessDeniedReason =
                    CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new EntitlementFeature()
                    {
                        AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            ID = "id",
                            DisplayName = "displayName",
                            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
                AccessDeniedReason =
                    CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new EntitlementFeature()
                    {
                        AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            ID = "id",
                            DisplayName = "displayName",
                            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
            AccessDeniedReason =
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new EntitlementFeature()
                {
                    AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                        FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
                AccessDeniedReason =
                    CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new EntitlementFeature()
                    {
                        AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            ID = "id",
                            DisplayName = "displayName",
                            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
                AccessDeniedReason =
                    CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
                Entitlements =
                [
                    new EntitlementFeature()
                    {
                        AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                        IsGranted = true,
                        CurrentUsage = 0,
                        EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Feature = new()
                        {
                            ID = "id",
                            DisplayName = "displayName",
                            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                        },
                        HasUnlimitedUsage = true,
                        ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
            AccessDeniedReason =
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new EntitlementFeature()
                {
                    AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                        FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = EntitlementFeatureResetPeriod.Year,
                    UsageLimit = 0,
                    UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        ApiEnum<
            string,
            CustomerRetrieveEntitlementsResponseDataAccessDeniedReason
        > expectedAccessDeniedReason =
            CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound;
        List<Entitlement> expectedEntitlements =
        [
            new EntitlementFeature()
            {
                AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Feature = new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                    FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                },
                HasUnlimitedUsage = true,
                ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
            AccessDeniedReason =
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new EntitlementFeature()
                {
                    AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                        FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
            AccessDeniedReason =
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new EntitlementFeature()
                {
                    AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                        FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = EntitlementFeatureResetPeriod.Year,
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

        ApiEnum<
            string,
            CustomerRetrieveEntitlementsResponseDataAccessDeniedReason
        > expectedAccessDeniedReason =
            CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound;
        List<Entitlement> expectedEntitlements =
        [
            new EntitlementFeature()
            {
                AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                IsGranted = true,
                CurrentUsage = 0,
                EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Feature = new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                    FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                },
                HasUnlimitedUsage = true,
                ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
            AccessDeniedReason =
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new EntitlementFeature()
                {
                    AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                        FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
            AccessDeniedReason =
                CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound,
            Entitlements =
            [
                new EntitlementFeature()
                {
                    AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
                    IsGranted = true,
                    CurrentUsage = 0,
                    EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Feature = new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                        FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
                    },
                    HasUnlimitedUsage = true,
                    ResetPeriod = EntitlementFeatureResetPeriod.Year,
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

public class CustomerRetrieveEntitlementsResponseDataAccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound)]
    [InlineData(CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.NoActiveSubscription)]
    [InlineData(CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerIsArchived)]
    public void Validation_Works(
        CustomerRetrieveEntitlementsResponseDataAccessDeniedReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerRetrieveEntitlementsResponseDataAccessDeniedReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerRetrieveEntitlementsResponseDataAccessDeniedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerNotFound)]
    [InlineData(CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.NoActiveSubscription)]
    [InlineData(CustomerRetrieveEntitlementsResponseDataAccessDeniedReason.CustomerIsArchived)]
    public void SerializationRoundtrip_Works(
        CustomerRetrieveEntitlementsResponseDataAccessDeniedReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerRetrieveEntitlementsResponseDataAccessDeniedReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerRetrieveEntitlementsResponseDataAccessDeniedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerRetrieveEntitlementsResponseDataAccessDeniedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerRetrieveEntitlementsResponseDataAccessDeniedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        Entitlement value = new EntitlementFeature()
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
        Entitlement value = new EntitlementCredit()
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        Entitlement value = new EntitlementFeature()
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
        Entitlement value = new EntitlementCredit()
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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

public class EntitlementFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, EntitlementFeatureAccessDeniedReason> expectedAccessDeniedReason =
            EntitlementFeatureAccessDeniedReason.FeatureNotFound;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        EntitlementFeatureFeature expectedFeature = new()
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
        };
        bool expectedHasUnlimitedUsage = true;
        ApiEnum<string, EntitlementFeatureResetPeriod> expectedResetPeriod =
            EntitlementFeatureResetPeriod.Year;
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
        Assert.Equal(expectedFeature, model.Feature);
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, EntitlementFeatureAccessDeniedReason> expectedAccessDeniedReason =
            EntitlementFeatureAccessDeniedReason.FeatureNotFound;
        bool expectedIsGranted = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedEntitlementUpdatedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        EntitlementFeatureFeature expectedFeature = new()
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
        };
        bool expectedHasUnlimitedUsage = true;
        ApiEnum<string, EntitlementFeatureResetPeriod> expectedResetPeriod =
            EntitlementFeatureResetPeriod.Year;
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
        Assert.Equal(expectedFeature, deserialized.Feature);
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
        };

        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.EntitlementUpdatedAt);
        Assert.False(model.RawData.ContainsKey("entitlementUpdatedAt"));
        Assert.Null(model.Feature);
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrentUsage = null,
            EntitlementUpdatedAt = null,
            Feature = null,
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
        Assert.Null(model.Feature);
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,

            // Null should be interpreted as omitted for these properties
            CurrentUsage = null,
            EntitlementUpdatedAt = null,
            Feature = null,
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
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
        var model = new EntitlementFeature
        {
            AccessDeniedReason = EntitlementFeatureAccessDeniedReason.FeatureNotFound,
            IsGranted = true,
            CurrentUsage = 0,
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Feature = new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
                FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
            },
            HasUnlimitedUsage = true,
            ResetPeriod = EntitlementFeatureResetPeriod.Year,
            UsageLimit = 0,
            UsagePeriodAnchor = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        EntitlementFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementFeatureAccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(EntitlementFeatureAccessDeniedReason.FeatureNotFound)]
    [InlineData(EntitlementFeatureAccessDeniedReason.CustomerNotFound)]
    [InlineData(EntitlementFeatureAccessDeniedReason.CustomerIsArchived)]
    [InlineData(EntitlementFeatureAccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(EntitlementFeatureAccessDeniedReason.NoActiveSubscription)]
    [InlineData(EntitlementFeatureAccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(EntitlementFeatureAccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(EntitlementFeatureAccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(EntitlementFeatureAccessDeniedReason.BudgetExceeded)]
    [InlineData(EntitlementFeatureAccessDeniedReason.Unknown)]
    [InlineData(EntitlementFeatureAccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(EntitlementFeatureAccessDeniedReason.Revoked)]
    [InlineData(EntitlementFeatureAccessDeniedReason.InsufficientCredits)]
    [InlineData(EntitlementFeatureAccessDeniedReason.EntitlementNotFound)]
    public void Validation_Works(EntitlementFeatureAccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementFeatureAccessDeniedReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureAccessDeniedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementFeatureAccessDeniedReason.FeatureNotFound)]
    [InlineData(EntitlementFeatureAccessDeniedReason.CustomerNotFound)]
    [InlineData(EntitlementFeatureAccessDeniedReason.CustomerIsArchived)]
    [InlineData(EntitlementFeatureAccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(EntitlementFeatureAccessDeniedReason.NoActiveSubscription)]
    [InlineData(EntitlementFeatureAccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(EntitlementFeatureAccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(EntitlementFeatureAccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(EntitlementFeatureAccessDeniedReason.BudgetExceeded)]
    [InlineData(EntitlementFeatureAccessDeniedReason.Unknown)]
    [InlineData(EntitlementFeatureAccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(EntitlementFeatureAccessDeniedReason.Revoked)]
    [InlineData(EntitlementFeatureAccessDeniedReason.InsufficientCredits)]
    [InlineData(EntitlementFeatureAccessDeniedReason.EntitlementNotFound)]
    public void SerializationRoundtrip_Works(EntitlementFeatureAccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementFeatureAccessDeniedReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureAccessDeniedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureAccessDeniedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureAccessDeniedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementFeatureFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementFeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        ApiEnum<string, EntitlementFeatureFeatureFeatureStatus> expectedFeatureStatus =
            EntitlementFeatureFeatureFeatureStatus.New;
        ApiEnum<string, EntitlementFeatureFeatureFeatureType> expectedFeatureType =
            EntitlementFeatureFeatureFeatureType.Boolean;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedFeatureStatus, model.FeatureStatus);
        Assert.Equal(expectedFeatureType, model.FeatureType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementFeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementFeatureFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementFeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementFeatureFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        ApiEnum<string, EntitlementFeatureFeatureFeatureStatus> expectedFeatureStatus =
            EntitlementFeatureFeatureFeatureStatus.New;
        ApiEnum<string, EntitlementFeatureFeatureFeatureType> expectedFeatureType =
            EntitlementFeatureFeatureFeatureType.Boolean;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedFeatureStatus, deserialized.FeatureStatus);
        Assert.Equal(expectedFeatureType, deserialized.FeatureType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementFeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementFeatureFeature
        {
            ID = "id",
            DisplayName = "displayName",
            FeatureStatus = EntitlementFeatureFeatureFeatureStatus.New,
            FeatureType = EntitlementFeatureFeatureFeatureType.Boolean,
        };

        EntitlementFeatureFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementFeatureFeatureFeatureStatusTest : TestBase
{
    [Theory]
    [InlineData(EntitlementFeatureFeatureFeatureStatus.New)]
    [InlineData(EntitlementFeatureFeatureFeatureStatus.Suspended)]
    [InlineData(EntitlementFeatureFeatureFeatureStatus.Active)]
    public void Validation_Works(EntitlementFeatureFeatureFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementFeatureFeatureFeatureStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureFeatureFeatureStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementFeatureFeatureFeatureStatus.New)]
    [InlineData(EntitlementFeatureFeatureFeatureStatus.Suspended)]
    [InlineData(EntitlementFeatureFeatureFeatureStatus.Active)]
    public void SerializationRoundtrip_Works(EntitlementFeatureFeatureFeatureStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementFeatureFeatureFeatureStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureFeatureFeatureStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureFeatureFeatureStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureFeatureFeatureStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementFeatureFeatureFeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(EntitlementFeatureFeatureFeatureType.Boolean)]
    [InlineData(EntitlementFeatureFeatureFeatureType.Number)]
    [InlineData(EntitlementFeatureFeatureFeatureType.Enum)]
    public void Validation_Works(EntitlementFeatureFeatureFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementFeatureFeatureFeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureFeatureFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementFeatureFeatureFeatureType.Boolean)]
    [InlineData(EntitlementFeatureFeatureFeatureType.Number)]
    [InlineData(EntitlementFeatureFeatureFeatureType.Enum)]
    public void SerializationRoundtrip_Works(EntitlementFeatureFeatureFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementFeatureFeatureFeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureFeatureFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureFeatureFeatureType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureFeatureFeatureType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementFeatureResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(EntitlementFeatureResetPeriod.Year)]
    [InlineData(EntitlementFeatureResetPeriod.Month)]
    [InlineData(EntitlementFeatureResetPeriod.Week)]
    [InlineData(EntitlementFeatureResetPeriod.Day)]
    [InlineData(EntitlementFeatureResetPeriod.Hour)]
    public void Validation_Works(EntitlementFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementFeatureResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementFeatureResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementFeatureResetPeriod.Year)]
    [InlineData(EntitlementFeatureResetPeriod.Month)]
    [InlineData(EntitlementFeatureResetPeriod.Week)]
    [InlineData(EntitlementFeatureResetPeriod.Day)]
    [InlineData(EntitlementFeatureResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(EntitlementFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementFeatureResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementFeatureResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, EntitlementCreditAccessDeniedReason> expectedAccessDeniedReason =
            EntitlementCreditAccessDeniedReason.FeatureNotFound;
        EntitlementCreditCurrency expectedCurrency = new()
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
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCredit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCredit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, EntitlementCreditAccessDeniedReason> expectedAccessDeniedReason =
            EntitlementCreditAccessDeniedReason.FeatureNotFound;
        EntitlementCreditCurrency expectedCurrency = new()
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
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
            EntitlementUpdatedAt = null,
            UsagePeriodEnd = null,
            ValidUntil = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCredit
        {
            AccessDeniedReason = EntitlementCreditAccessDeniedReason.FeatureNotFound,
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
            EntitlementUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ValidUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        EntitlementCredit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreditAccessDeniedReasonTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreditAccessDeniedReason.FeatureNotFound)]
    [InlineData(EntitlementCreditAccessDeniedReason.CustomerNotFound)]
    [InlineData(EntitlementCreditAccessDeniedReason.CustomerIsArchived)]
    [InlineData(EntitlementCreditAccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(EntitlementCreditAccessDeniedReason.NoActiveSubscription)]
    [InlineData(EntitlementCreditAccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(EntitlementCreditAccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(EntitlementCreditAccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(EntitlementCreditAccessDeniedReason.BudgetExceeded)]
    [InlineData(EntitlementCreditAccessDeniedReason.Unknown)]
    [InlineData(EntitlementCreditAccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(EntitlementCreditAccessDeniedReason.Revoked)]
    [InlineData(EntitlementCreditAccessDeniedReason.InsufficientCredits)]
    [InlineData(EntitlementCreditAccessDeniedReason.EntitlementNotFound)]
    public void Validation_Works(EntitlementCreditAccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreditAccessDeniedReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreditAccessDeniedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreditAccessDeniedReason.FeatureNotFound)]
    [InlineData(EntitlementCreditAccessDeniedReason.CustomerNotFound)]
    [InlineData(EntitlementCreditAccessDeniedReason.CustomerIsArchived)]
    [InlineData(EntitlementCreditAccessDeniedReason.CustomerResourceNotFound)]
    [InlineData(EntitlementCreditAccessDeniedReason.NoActiveSubscription)]
    [InlineData(EntitlementCreditAccessDeniedReason.NoFeatureEntitlementInSubscription)]
    [InlineData(EntitlementCreditAccessDeniedReason.RequestedUsageExceedingLimit)]
    [InlineData(EntitlementCreditAccessDeniedReason.RequestedValuesMismatch)]
    [InlineData(EntitlementCreditAccessDeniedReason.BudgetExceeded)]
    [InlineData(EntitlementCreditAccessDeniedReason.Unknown)]
    [InlineData(EntitlementCreditAccessDeniedReason.FeatureTypeMismatch)]
    [InlineData(EntitlementCreditAccessDeniedReason.Revoked)]
    [InlineData(EntitlementCreditAccessDeniedReason.InsufficientCredits)]
    [InlineData(EntitlementCreditAccessDeniedReason.EntitlementNotFound)]
    public void SerializationRoundtrip_Works(EntitlementCreditAccessDeniedReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreditAccessDeniedReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreditAccessDeniedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreditAccessDeniedReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreditAccessDeniedReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreditCurrencyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreditCurrency
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
        var model = new EntitlementCreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreditCurrency>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreditCurrency>(
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
        var model = new EntitlementCreditCurrency
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
        var model = new EntitlementCreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
        };

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
        var model = new EntitlementCreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementCreditCurrency
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
        var model = new EntitlementCreditCurrency
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
        var model = new EntitlementCreditCurrency
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            UnitPlural = "unitPlural",
            UnitSingular = "unitSingular",
        };

        EntitlementCreditCurrency copied = new(model);

        Assert.Equal(model, copied);
    }
}
