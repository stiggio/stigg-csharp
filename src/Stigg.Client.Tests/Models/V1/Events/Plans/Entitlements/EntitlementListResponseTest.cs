using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Plans.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Events.Plans.Entitlements;

public class EntitlementListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementListResponseDataBehavior.Increment,
                    Cadence = EntitlementListResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementListResponseDataType.Feature,
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
            new()
            {
                ID = "id",
                Amount = 0,
                Behavior = EntitlementListResponseDataBehavior.Increment,
                Cadence = EntitlementListResponseDataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                Type = EntitlementListResponseDataType.Feature,
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
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementListResponseDataBehavior.Increment,
                    Cadence = EntitlementListResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementListResponseDataType.Feature,
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
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementListResponseDataBehavior.Increment,
                    Cadence = EntitlementListResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementListResponseDataType.Feature,
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
            new()
            {
                ID = "id",
                Amount = 0,
                Behavior = EntitlementListResponseDataBehavior.Increment,
                Cadence = EntitlementListResponseDataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                Type = EntitlementListResponseDataType.Feature,
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
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementListResponseDataBehavior.Increment,
                    Cadence = EntitlementListResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementListResponseDataType.Feature,
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
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementListResponseDataBehavior.Increment,
                    Cadence = EntitlementListResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementListResponseDataType.Feature,
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
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataBehavior.Increment,
            Cadence = EntitlementListResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementListResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, EntitlementListResponseDataBehavior> expectedBehavior =
            EntitlementListResponseDataBehavior.Increment;
        ApiEnum<string, EntitlementListResponseDataCadence> expectedCadence =
            EntitlementListResponseDataCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomCurrencyID = "customCurrencyId";
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, EntitlementListResponseDataResetPeriod> expectedResetPeriod =
            EntitlementListResponseDataResetPeriod.Year;
        EntitlementListResponseDataResetPeriodConfiguration expectedResetPeriodConfiguration =
            new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        ApiEnum<string, EntitlementListResponseDataType> expectedType =
            EntitlementListResponseDataType.Feature;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBehavior, model.Behavior);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomCurrencyID, model.CustomCurrencyID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayNameOverride, model.DisplayNameOverride);
        Assert.NotNull(model.EnumValues);
        Assert.Equal(expectedEnumValues.Count, model.EnumValues.Count);
        for (int i = 0; i < expectedEnumValues.Count; i++)
        {
            Assert.Equal(expectedEnumValues[i], model.EnumValues[i]);
        }
        Assert.Equal(expectedFeatureID, model.FeatureID);
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
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataBehavior.Increment,
            Cadence = EntitlementListResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementListResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataBehavior.Increment,
            Cadence = EntitlementListResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementListResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementListResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, EntitlementListResponseDataBehavior> expectedBehavior =
            EntitlementListResponseDataBehavior.Increment;
        ApiEnum<string, EntitlementListResponseDataCadence> expectedCadence =
            EntitlementListResponseDataCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomCurrencyID = "customCurrencyId";
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, EntitlementListResponseDataResetPeriod> expectedResetPeriod =
            EntitlementListResponseDataResetPeriod.Year;
        EntitlementListResponseDataResetPeriodConfiguration expectedResetPeriodConfiguration =
            new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        ApiEnum<string, EntitlementListResponseDataType> expectedType =
            EntitlementListResponseDataType.Feature;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBehavior, deserialized.Behavior);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomCurrencyID, deserialized.CustomCurrencyID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayNameOverride, deserialized.DisplayNameOverride);
        Assert.NotNull(deserialized.EnumValues);
        Assert.Equal(expectedEnumValues.Count, deserialized.EnumValues.Count);
        for (int i = 0; i < expectedEnumValues.Count; i++)
        {
            Assert.Equal(expectedEnumValues[i], deserialized.EnumValues[i]);
        }
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
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
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementListResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataBehavior.Increment,
            Cadence = EntitlementListResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementListResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementListResponseDataBehavior.Increment,
            Cadence = EntitlementListResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementListResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementListResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementListResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        EntitlementListResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataBehaviorTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataBehavior.Increment)]
    [InlineData(EntitlementListResponseDataBehavior.Override)]
    public void Validation_Works(EntitlementListResponseDataBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataBehavior.Increment)]
    [InlineData(EntitlementListResponseDataBehavior.Override)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataCadenceTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataCadence.Month)]
    [InlineData(EntitlementListResponseDataCadence.Year)]
    public void Validation_Works(EntitlementListResponseDataCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementListResponseDataCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataCadence.Month)]
    [InlineData(EntitlementListResponseDataCadence.Year)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementListResponseDataCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataHiddenFromWidget.Paywall)]
    [InlineData(EntitlementListResponseDataHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementListResponseDataHiddenFromWidget.Checkout)]
    public void Validation_Works(EntitlementListResponseDataHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataHiddenFromWidget.Paywall)]
    [InlineData(EntitlementListResponseDataHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementListResponseDataHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataResetPeriod.Year)]
    [InlineData(EntitlementListResponseDataResetPeriod.Month)]
    [InlineData(EntitlementListResponseDataResetPeriod.Week)]
    [InlineData(EntitlementListResponseDataResetPeriod.Day)]
    [InlineData(EntitlementListResponseDataResetPeriod.Hour)]
    public void Validation_Works(EntitlementListResponseDataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataResetPeriod.Year)]
    [InlineData(EntitlementListResponseDataResetPeriod.Month)]
    [InlineData(EntitlementListResponseDataResetPeriod.Week)]
    [InlineData(EntitlementListResponseDataResetPeriod.Day)]
    [InlineData(EntitlementListResponseDataResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void YearlyResetPeriodConfigValidationWorks()
    {
        EntitlementListResponseDataResetPeriodConfiguration value =
            new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void MonthlyResetPeriodConfigValidationWorks()
    {
        EntitlementListResponseDataResetPeriodConfiguration value =
            new EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void WeeklyResetPeriodConfigValidationWorks()
    {
        EntitlementListResponseDataResetPeriodConfiguration value =
            new EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void YearlyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementListResponseDataResetPeriodConfiguration value =
            new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonthlyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementListResponseDataResetPeriodConfiguration value =
            new EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WeeklyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementListResponseDataResetPeriodConfiguration value =
            new EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfig copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementListResponseDataTypeTest : TestBase
{
    [Theory]
    [InlineData(EntitlementListResponseDataType.Feature)]
    [InlineData(EntitlementListResponseDataType.Credit)]
    public void Validation_Works(EntitlementListResponseDataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementListResponseDataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementListResponseDataType.Feature)]
    [InlineData(EntitlementListResponseDataType.Credit)]
    public void SerializationRoundtrip_Works(EntitlementListResponseDataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementListResponseDataType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementListResponseDataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementListResponseDataType>
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
