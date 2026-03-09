using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Plans.Entitlements;

public class EntitlementListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponse
        {
            Data =
            [
                new EntitlementListResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementListResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        List<EntitlementListResponseData> expectedData =
        [
            new EntitlementListResponseDataFeature()
            {
                ID = "id",
                Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
                ResetPeriodConfiguration =
                    new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

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
        var model = new EntitlementListResponse
        {
            Data =
            [
                new EntitlementListResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementListResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponse
        {
            Data =
            [
                new EntitlementListResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementListResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EntitlementListResponseData> expectedData =
        [
            new EntitlementListResponseDataFeature()
            {
                ID = "id",
                Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
                ResetPeriodConfiguration =
                    new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

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
        var model = new EntitlementListResponse
        {
            Data =
            [
                new EntitlementListResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementListResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponse
        {
            Data =
            [
                new EntitlementListResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementListResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        EntitlementListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        EntitlementListResponseData value = new EntitlementListResponseDataFeature()
        {
            ID = "id",
            Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CreditValidationWorks()
    {
        EntitlementListResponseData value = new EntitlementListResponseDataCredit()
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataCreditBehavior.Increment,
            Cadence = EntitlementListResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        EntitlementListResponseData value = new EntitlementListResponseDataFeature()
        {
            ID = "id",
            Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        EntitlementListResponseData value = new EntitlementListResponseDataCredit()
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataCreditBehavior.Increment,
            Cadence = EntitlementListResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string expectedID = "id";
        ApiEnum<string, EntitlementListResponseDataFeatureBehavior> expectedBehavior =
            EntitlementListResponseDataFeatureBehavior.Increment;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod> expectedResetPeriod =
            EntitlementListResponseDataFeatureResetPeriod.Year;
        EntitlementListResponseDataFeatureResetPeriodConfiguration expectedResetPeriodConfiguration =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBehavior, model.Behavior);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayNameOverride, model.DisplayNameOverride);
        Assert.NotNull(model.EnumValues);
        Assert.Equal(expectedEnumValues.Count, model.EnumValues.Count);
        for (int i = 0; i < expectedEnumValues.Count; i++)
        {
            Assert.Equal(expectedEnumValues[i], model.EnumValues[i]);
        }
        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedHasUnlimitedUsage, model.HasUnlimitedUsage);
        Assert.Equal(expectedHiddenFromWidgets.Count, model.HiddenFromWidgets.Count);
        for (int i = 0; i < expectedHiddenFromWidgets.Count; i++)
        {
            Assert.Equal(expectedHiddenFromWidgets[i], model.HiddenFromWidgets[i]);
        }
        Assert.Equal(expectedIsCustom, model.IsCustom);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedResetPeriodConfiguration, model.ResetPeriodConfiguration);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseDataFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseDataFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, EntitlementListResponseDataFeatureBehavior> expectedBehavior =
            EntitlementListResponseDataFeatureBehavior.Increment;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod> expectedResetPeriod =
            EntitlementListResponseDataFeatureResetPeriod.Year;
        EntitlementListResponseDataFeatureResetPeriodConfiguration expectedResetPeriodConfiguration =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBehavior, deserialized.Behavior);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayNameOverride, deserialized.DisplayNameOverride);
        Assert.NotNull(deserialized.EnumValues);
        Assert.Equal(expectedEnumValues.Count, deserialized.EnumValues.Count);
        for (int i = 0; i < expectedEnumValues.Count; i++)
        {
            Assert.Equal(expectedEnumValues[i], deserialized.EnumValues[i]);
        }
        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
        Assert.Equal(expectedHasUnlimitedUsage, deserialized.HasUnlimitedUsage);
        Assert.Equal(expectedHiddenFromWidgets.Count, deserialized.HiddenFromWidgets.Count);
        for (int i = 0; i < expectedHiddenFromWidgets.Count; i++)
        {
            Assert.Equal(expectedHiddenFromWidgets[i], deserialized.HiddenFromWidgets[i]);
        }
        Assert.Equal(expectedIsCustom, deserialized.IsCustom);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedResetPeriod, deserialized.ResetPeriod);
        Assert.Equal(expectedResetPeriodConfiguration, deserialized.ResetPeriodConfiguration);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementListResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementListResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        EntitlementListResponseDataFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataFeatureBehaviorTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataFeatureBehavior.Increment)]
    [InlineData(EntitlementListResponseDataFeatureBehavior.Override)]
    public void Validation_Works(EntitlementListResponseDataFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataFeatureBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataFeatureBehavior.Increment)]
    [InlineData(EntitlementListResponseDataFeatureBehavior.Override)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataFeatureBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataFeatureHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataFeatureHiddenFromWidget.Paywall)]
    [InlineData(EntitlementListResponseDataFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementListResponseDataFeatureHiddenFromWidget.Checkout)]
    public void Validation_Works(EntitlementListResponseDataFeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataFeatureHiddenFromWidget.Paywall)]
    [InlineData(EntitlementListResponseDataFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementListResponseDataFeatureHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(
        EntitlementListResponseDataFeatureHiddenFromWidget rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataFeatureResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Year)]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Month)]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Week)]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Day)]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Hour)]
    public void Validation_Works(EntitlementListResponseDataFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Year)]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Month)]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Week)]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Day)]
    [InlineData(EntitlementListResponseDataFeatureResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataFeatureResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void YearlyResetPeriodConfigValidationWorks()
    {
        EntitlementListResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void MonthlyResetPeriodConfigValidationWorks()
    {
        EntitlementListResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void WeeklyResetPeriodConfigValidationWorks()
    {
        EntitlementListResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void YearlyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementListResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonthlyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementListResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WeeklyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementListResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataCreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataCreditBehavior.Increment,
            Cadence = EntitlementListResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, EntitlementListResponseDataCreditBehavior> expectedBehavior =
            EntitlementListResponseDataCreditBehavior.Increment;
        ApiEnum<string, EntitlementListResponseDataCreditCadence> expectedCadence =
            EntitlementListResponseDataCreditCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<
            ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBehavior, model.Behavior);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayNameOverride, model.DisplayNameOverride);
        Assert.Equal(expectedHiddenFromWidgets.Count, model.HiddenFromWidgets.Count);
        for (int i = 0; i < expectedHiddenFromWidgets.Count; i++)
        {
            Assert.Equal(expectedHiddenFromWidgets[i], model.HiddenFromWidgets[i]);
        }
        Assert.Equal(expectedIsCustom, model.IsCustom);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.Equal(expectedOrder, model.Order);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataCreditBehavior.Increment,
            Cadence = EntitlementListResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseDataCredit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataCreditBehavior.Increment,
            Cadence = EntitlementListResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseDataCredit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, EntitlementListResponseDataCreditBehavior> expectedBehavior =
            EntitlementListResponseDataCreditBehavior.Increment;
        ApiEnum<string, EntitlementListResponseDataCreditCadence> expectedCadence =
            EntitlementListResponseDataCreditCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<
            ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBehavior, deserialized.Behavior);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayNameOverride, deserialized.DisplayNameOverride);
        Assert.Equal(expectedHiddenFromWidgets.Count, deserialized.HiddenFromWidgets.Count);
        for (int i = 0; i < expectedHiddenFromWidgets.Count; i++)
        {
            Assert.Equal(expectedHiddenFromWidgets[i], deserialized.HiddenFromWidgets[i]);
        }
        Assert.Equal(expectedIsCustom, deserialized.IsCustom);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementListResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataCreditBehavior.Increment,
            Cadence = EntitlementListResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataCreditBehavior.Increment,
            Cadence = EntitlementListResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementListResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        EntitlementListResponseDataCredit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataCreditBehaviorTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataCreditBehavior.Increment)]
    [InlineData(EntitlementListResponseDataCreditBehavior.Override)]
    public void Validation_Works(EntitlementListResponseDataCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataCreditBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataCreditBehavior.Increment)]
    [InlineData(EntitlementListResponseDataCreditBehavior.Override)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataCreditBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataCreditCadenceTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataCreditCadence.Month)]
    [InlineData(EntitlementListResponseDataCreditCadence.Year)]
    public void Validation_Works(EntitlementListResponseDataCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataCreditCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataCreditCadence.Month)]
    [InlineData(EntitlementListResponseDataCreditCadence.Year)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataCreditCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataCreditHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataCreditHiddenFromWidget.Paywall)]
    [InlineData(EntitlementListResponseDataCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementListResponseDataCreditHiddenFromWidget.Checkout)]
    public void Validation_Works(EntitlementListResponseDataCreditHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataCreditHiddenFromWidget.Paywall)]
    [InlineData(EntitlementListResponseDataCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementListResponseDataCreditHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(
        EntitlementListResponseDataCreditHiddenFromWidget rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCreditHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

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
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
