using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Addons.Entitlements;

public class EntitlementCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponse
        {
            Data =
            [
                new EntitlementCreateResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        List<EntitlementCreateResponseData> expectedData =
        [
            new EntitlementCreateResponseDataFeature()
            {
                ID = "id",
                Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
                ResetPeriodConfiguration =
                    new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
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
                new EntitlementCreateResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
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
                new EntitlementCreateResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
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
            new EntitlementCreateResponseDataFeature()
            {
                ID = "id",
                Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
                ResetPeriodConfiguration =
                    new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
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
                new EntitlementCreateResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
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
                new EntitlementCreateResponseDataFeature()
                {
                    ID = "id",
                    Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets =
                    [
                        EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall,
                    ],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                    ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
                    ResetPeriodConfiguration =
                        new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                        ),
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
    public void FeatureValidationWorks()
    {
        EntitlementCreateResponseData value = new EntitlementCreateResponseDataFeature()
        {
            ID = "id",
            Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CreditValidationWorks()
    {
        EntitlementCreateResponseData value = new EntitlementCreateResponseDataCredit()
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        EntitlementCreateResponseData value = new EntitlementCreateResponseDataFeature()
        {
            ID = "id",
            Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        EntitlementCreateResponseData value = new EntitlementCreateResponseDataCredit()
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string expectedID = "id";
        ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior> expectedBehavior =
            EntitlementCreateResponseDataFeatureBehavior.Increment;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
        > expectedHiddenFromWidgets =
        [
            EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod> expectedResetPeriod =
            EntitlementCreateResponseDataFeatureResetPeriod.Year;
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration expectedResetPeriodConfiguration =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
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
        var model = new EntitlementCreateResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseDataFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseDataFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior> expectedBehavior =
            EntitlementCreateResponseDataFeatureBehavior.Increment;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
        > expectedHiddenFromWidgets =
        [
            EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod> expectedResetPeriod =
            EntitlementCreateResponseDataFeatureResetPeriod.Year;
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration expectedResetPeriodConfiguration =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
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
        var model = new EntitlementCreateResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseDataFeature
        {
            ID = "id",
            Behavior = EntitlementCreateResponseDataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementCreateResponseDataFeatureResetPeriod.Year,
            ResetPeriodConfiguration =
                new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        EntitlementCreateResponseDataFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataFeatureBehaviorTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataFeatureBehavior.Increment)]
    [InlineData(EntitlementCreateResponseDataFeatureBehavior.Override)]
    public void Validation_Works(EntitlementCreateResponseDataFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataFeatureBehavior.Increment)]
    [InlineData(EntitlementCreateResponseDataFeatureBehavior.Override)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseDataFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataFeatureHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall)]
    [InlineData(EntitlementCreateResponseDataFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementCreateResponseDataFeatureHiddenFromWidget.Checkout)]
    public void Validation_Works(EntitlementCreateResponseDataFeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataFeatureHiddenFromWidget.Paywall)]
    [InlineData(EntitlementCreateResponseDataFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementCreateResponseDataFeatureHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataFeatureHiddenFromWidget rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataFeatureResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Year)]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Month)]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Week)]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Day)]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Hour)]
    public void Validation_Works(EntitlementCreateResponseDataFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Year)]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Month)]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Week)]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Day)]
    [InlineData(EntitlementCreateResponseDataFeatureResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataFeatureResetPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataFeatureResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void YearlyResetPeriodConfigValidationWorks()
    {
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void MonthlyResetPeriodConfigValidationWorks()
    {
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void WeeklyResetPeriodConfigValidationWorks()
    {
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void YearlyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig(
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonthlyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig(
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WeeklyResetPeriodConfigSerializationRoundtripWorks()
    {
        EntitlementCreateResponseDataFeatureResetPeriodConfiguration value =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig(
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataCreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, EntitlementCreateResponseDataCreditBehavior> expectedBehavior =
            EntitlementCreateResponseDataCreditBehavior.Increment;
        ApiEnum<string, EntitlementCreateResponseDataCreditCadence> expectedCadence =
            EntitlementCreateResponseDataCreditCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        bool expectedHasSoftLimit = true;
        List<
            ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDependencyFeatureID = "dependencyFeatureId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBehavior, model.Behavior);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayNameOverride, model.DisplayNameOverride);
        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
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
        Assert.Equal(expectedDependencyFeatureID, model.DependencyFeatureID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseDataCredit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementCreateResponseDataCredit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, EntitlementCreateResponseDataCreditBehavior> expectedBehavior =
            EntitlementCreateResponseDataCreditBehavior.Increment;
        ApiEnum<string, EntitlementCreateResponseDataCreditCadence> expectedCadence =
            EntitlementCreateResponseDataCreditCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        bool expectedHasSoftLimit = true;
        List<
            ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDependencyFeatureID = "dependencyFeatureId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBehavior, deserialized.Behavior);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayNameOverride, deserialized.DisplayNameOverride);
        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
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
        Assert.Equal(expectedDependencyFeatureID, deserialized.DependencyFeatureID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.DependencyFeatureID);
        Assert.False(model.RawData.ContainsKey("dependencyFeatureId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            DependencyFeatureID = null,
        };

        Assert.Null(model.DependencyFeatureID);
        Assert.True(model.RawData.ContainsKey("dependencyFeatureId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            DependencyFeatureID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementCreateResponseDataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = EntitlementCreateResponseDataCreditBehavior.Increment,
            Cadence = EntitlementCreateResponseDataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        EntitlementCreateResponseDataCredit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementCreateResponseDataCreditBehaviorTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataCreditBehavior.Increment)]
    [InlineData(EntitlementCreateResponseDataCreditBehavior.Override)]
    public void Validation_Works(EntitlementCreateResponseDataCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataCreditBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataCreditBehavior.Increment)]
    [InlineData(EntitlementCreateResponseDataCreditBehavior.Override)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseDataCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataCreditBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataCreditCadenceTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataCreditCadence.Month)]
    [InlineData(EntitlementCreateResponseDataCreditCadence.Year)]
    public void Validation_Works(EntitlementCreateResponseDataCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataCreditCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataCreditCadence.Month)]
    [InlineData(EntitlementCreateResponseDataCreditCadence.Year)]
    public void SerializationRoundtrip_Works(EntitlementCreateResponseDataCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataCreditCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementCreateResponseDataCreditHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall)]
    [InlineData(EntitlementCreateResponseDataCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementCreateResponseDataCreditHiddenFromWidget.Checkout)]
    public void Validation_Works(EntitlementCreateResponseDataCreditHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementCreateResponseDataCreditHiddenFromWidget.Paywall)]
    [InlineData(EntitlementCreateResponseDataCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementCreateResponseDataCreditHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(
        EntitlementCreateResponseDataCreditHiddenFromWidget rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementCreateResponseDataCreditHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
