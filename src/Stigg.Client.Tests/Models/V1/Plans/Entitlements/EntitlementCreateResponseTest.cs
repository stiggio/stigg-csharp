using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Plans.Entitlements;

public class EntitlementCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementCreateResponseDataBehavior.Increment,
                    Cadence = EntitlementCreateResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementCreateResponseDataType.Feature,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        List<EntitlementCreateResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                Amount = 0,
                Behavior = EntitlementCreateResponseDataBehavior.Increment,
                Cadence = EntitlementCreateResponseDataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                Type = EntitlementCreateResponseDataType.Feature,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementCreateResponseDataBehavior.Increment,
                    Cadence = EntitlementCreateResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementCreateResponseDataType.Feature,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementCreateResponseDataBehavior.Increment,
                    Cadence = EntitlementCreateResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementCreateResponseDataType.Feature,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EntitlementCreateResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                Amount = 0,
                Behavior = EntitlementCreateResponseDataBehavior.Increment,
                Cadence = EntitlementCreateResponseDataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                Type = EntitlementCreateResponseDataType.Feature,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        ];

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementCreateResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementCreateResponseDataBehavior.Increment,
                    Cadence = EntitlementCreateResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementCreateResponseDataType.Feature,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Behavior = EntitlementCreateResponseDataBehavior.Increment,
                    Cadence = EntitlementCreateResponseDataCadence.Month,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomCurrencyID = "customCurrencyId",
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    Type = EntitlementCreateResponseDataType.Feature,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        EntitlementCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementCreateResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, EntitlementCreateResponseDataBehavior> expectedBehavior =
            EntitlementCreateResponseDataBehavior.Increment;
        ApiEnum<string, EntitlementCreateResponseDataCadence> expectedCadence =
            EntitlementCreateResponseDataCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomCurrencyID = "customCurrencyId";
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, EntitlementCreateResponseDataResetPeriod> expectedResetPeriod =
            EntitlementCreateResponseDataResetPeriod.Year;
        EntitlementCreateResponseDataResetPeriodConfiguration expectedResetPeriodConfiguration =
            new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        ApiEnum<string, EntitlementCreateResponseDataType> expectedType =
            EntitlementCreateResponseDataType.Feature;
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
        var model = new EntitlementCreateResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementCreateResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementCreateResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, EntitlementCreateResponseDataBehavior> expectedBehavior =
            EntitlementCreateResponseDataBehavior.Increment;
        ApiEnum<string, EntitlementCreateResponseDataCadence> expectedCadence =
            EntitlementCreateResponseDataCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomCurrencyID = "customCurrencyId";
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, EntitlementCreateResponseDataResetPeriod> expectedResetPeriod =
            EntitlementCreateResponseDataResetPeriod.Year;
        EntitlementCreateResponseDataResetPeriodConfiguration expectedResetPeriodConfiguration =
            new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        ApiEnum<string, EntitlementCreateResponseDataType> expectedType =
            EntitlementCreateResponseDataType.Feature;
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
        var model = new EntitlementCreateResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementCreateResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseData
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            Type = EntitlementCreateResponseDataType.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        EntitlementCreateResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataBehaviorTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataBehavior.Increment)]
    [InlineData(EntitlementCreateResponseDataBehavior.Override)]
    public void Validation_Works(EntitlementCreateResponseDataBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataBehavior.Increment)]
    [InlineData(EntitlementCreateResponseDataBehavior.Override)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseDataBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataCadenceTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataCadence.Month)]
    [InlineData(EntitlementCreateResponseDataCadence.Year)]
    public void Validation_Works(EntitlementCreateResponseDataCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataCadence.Month)]
    [InlineData(EntitlementCreateResponseDataCadence.Year)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseDataCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataHiddenFromWidget.Paywall)]
    [InlineData(EntitlementCreateResponseDataHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementCreateResponseDataHiddenFromWidget.Checkout)]
    public void Validation_Works(EntitlementCreateResponseDataHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataHiddenFromWidget.Paywall)]
    [InlineData(EntitlementCreateResponseDataHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementCreateResponseDataHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseDataHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Year)]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Month)]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Week)]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Day)]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Hour)]
    public void Validation_Works(EntitlementCreateResponseDataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Year)]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Month)]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Week)]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Day)]
    [InlineData(EntitlementCreateResponseDataResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseDataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void YearlyResetPeriodConfigValidationWorks()
    {
        EntitlementCreateResponseDataResetPeriodConfiguration value =
            new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void MonthlyResetPeriodConfigValidationWorks()
    {
        EntitlementCreateResponseDataResetPeriodConfiguration value =
            new EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void WeeklyResetPeriodConfigValidationWorks()
    {
        EntitlementCreateResponseDataResetPeriodConfiguration value =
            new EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void YearlyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementCreateResponseDataResetPeriodConfiguration value =
            new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonthlyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementCreateResponseDataResetPeriodConfiguration value =
            new EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WeeklyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementCreateResponseDataResetPeriodConfiguration value =
            new EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfig copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
        {
            AccordingTo =
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataTypeTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataType.Feature)]
    [InlineData(EntitlementCreateResponseDataType.Credit)]
    public void Validation_Works(EntitlementCreateResponseDataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementCreateResponseDataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataType.Feature)]
    [InlineData(EntitlementCreateResponseDataType.Credit)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseDataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntitlementCreateResponseDataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
