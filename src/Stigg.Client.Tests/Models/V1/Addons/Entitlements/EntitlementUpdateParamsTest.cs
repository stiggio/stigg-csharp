using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Addons.Entitlements;

public class EntitlementUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            AddonID = "addonId",
            ID = "id",
            Body = new BodyFeature()
            {
                Behavior = BodyFeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(
                    BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                Order = 0,
                ResetPeriod = BodyFeatureResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        string expectedAddonID = "addonId";
        string expectedID = "id";
        Body expectedBody = new BodyFeature()
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Assert.Equal(expectedAddonID, parameters.AddonID);
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementUpdateParams parameters = new()
        {
            AddonID = "addonId",
            ID = "id",
            Body = new BodyFeature()
            {
                Behavior = BodyFeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(
                    BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                Order = 0,
                ResetPeriod = BodyFeatureResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/addons/addonId/entitlements/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            AddonID = "addonId",
            ID = "id",
            Body = new BodyFeature()
            {
                Behavior = BodyFeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(
                    BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                Order = 0,
                ResetPeriod = BodyFeatureResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        EntitlementUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        Body value = new BodyFeature()
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };
        value.Validate();
    }

    [Fact]
    public void CreditValidationWorks()
    {
        Body value = new BodyCredit()
        {
            Amount = 1,
            Behavior = BodyCreditBehavior.Increment,
            Cadence = BodyCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [BodyCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };
        value.Validate();
    }

    [Fact]
    public void FeatureSerializationRoundtripWorks()
    {
        Body value = new BodyFeature()
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        Body value = new BodyCredit()
        {
            Amount = 1,
            Behavior = BodyCreditBehavior.Increment,
            Cadence = BodyCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [BodyCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BodyFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        ApiEnum<string, BodyFeatureBehavior> expectedBehavior = BodyFeatureBehavior.Increment;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<ApiEnum<string, BodyFeatureHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            BodyFeatureHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        BodyFeatureMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        double expectedOrder = 0;
        ApiEnum<string, BodyFeatureResetPeriod> expectedResetPeriod = BodyFeatureResetPeriod.Year;
        long expectedUsageLimit = 0;
        BodyFeatureWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        BodyFeatureYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBehavior, model.Behavior);
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
        Assert.NotNull(model.HiddenFromWidgets);
        Assert.Equal(expectedHiddenFromWidgets.Count, model.HiddenFromWidgets.Count);
        for (int i = 0; i < expectedHiddenFromWidgets.Count; i++)
        {
            Assert.Equal(expectedHiddenFromWidgets[i], model.HiddenFromWidgets[i]);
        }
        Assert.Equal(expectedIsCustom, model.IsCustom);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.Equal(
            expectedMonthlyResetPeriodConfiguration,
            model.MonthlyResetPeriodConfiguration
        );
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedWeeklyResetPeriodConfiguration, model.WeeklyResetPeriodConfiguration);
        Assert.Equal(expectedYearlyResetPeriodConfiguration, model.YearlyResetPeriodConfiguration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("FEATURE");
        ApiEnum<string, BodyFeatureBehavior> expectedBehavior = BodyFeatureBehavior.Increment;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<ApiEnum<string, BodyFeatureHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            BodyFeatureHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        BodyFeatureMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        double expectedOrder = 0;
        ApiEnum<string, BodyFeatureResetPeriod> expectedResetPeriod = BodyFeatureResetPeriod.Year;
        long expectedUsageLimit = 0;
        BodyFeatureWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        BodyFeatureYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBehavior, deserialized.Behavior);
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
        Assert.NotNull(deserialized.HiddenFromWidgets);
        Assert.Equal(expectedHiddenFromWidgets.Count, deserialized.HiddenFromWidgets.Count);
        for (int i = 0; i < expectedHiddenFromWidgets.Count; i++)
        {
            Assert.Equal(expectedHiddenFromWidgets[i], deserialized.HiddenFromWidgets[i]);
        }
        Assert.Equal(expectedIsCustom, deserialized.IsCustom);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.Equal(
            expectedMonthlyResetPeriodConfiguration,
            deserialized.MonthlyResetPeriodConfiguration
        );
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedResetPeriod, deserialized.ResetPeriod);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(
            expectedWeeklyResetPeriodConfiguration,
            deserialized.WeeklyResetPeriodConfiguration
        );
        Assert.Equal(
            expectedYearlyResetPeriodConfiguration,
            deserialized.YearlyResetPeriodConfiguration
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BodyFeature
        {
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Assert.Null(model.Behavior);
        Assert.False(model.RawData.ContainsKey("behavior"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayNameOverride);
        Assert.False(model.RawData.ContainsKey("displayNameOverride"));
        Assert.Null(model.EnumValues);
        Assert.False(model.RawData.ContainsKey("enumValues"));
        Assert.Null(model.HasSoftLimit);
        Assert.False(model.RawData.ContainsKey("hasSoftLimit"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.HiddenFromWidgets);
        Assert.False(model.RawData.ContainsKey("hiddenFromWidgets"));
        Assert.Null(model.IsCustom);
        Assert.False(model.RawData.ContainsKey("isCustom"));
        Assert.Null(model.IsGranted);
        Assert.False(model.RawData.ContainsKey("isGranted"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BodyFeature
        {
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BodyFeature
        {
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),

            // Null should be interpreted as omitted for these properties
            Behavior = null,
            Description = null,
            DisplayNameOverride = null,
            EnumValues = null,
            HasSoftLimit = null,
            HasUnlimitedUsage = null,
            HiddenFromWidgets = null,
            IsCustom = null,
            IsGranted = null,
            Order = null,
            ResetPeriod = null,
        };

        Assert.Null(model.Behavior);
        Assert.False(model.RawData.ContainsKey("behavior"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayNameOverride);
        Assert.False(model.RawData.ContainsKey("displayNameOverride"));
        Assert.Null(model.EnumValues);
        Assert.False(model.RawData.ContainsKey("enumValues"));
        Assert.Null(model.HasSoftLimit);
        Assert.False(model.RawData.ContainsKey("hasSoftLimit"));
        Assert.Null(model.HasUnlimitedUsage);
        Assert.False(model.RawData.ContainsKey("hasUnlimitedUsage"));
        Assert.Null(model.HiddenFromWidgets);
        Assert.False(model.RawData.ContainsKey("hiddenFromWidgets"));
        Assert.Null(model.IsCustom);
        Assert.False(model.RawData.ContainsKey("isCustom"));
        Assert.Null(model.IsGranted);
        Assert.False(model.RawData.ContainsKey("isGranted"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.ResetPeriod);
        Assert.False(model.RawData.ContainsKey("resetPeriod"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BodyFeature
        {
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),

            // Null should be interpreted as omitted for these properties
            Behavior = null,
            Description = null,
            DisplayNameOverride = null,
            EnumValues = null,
            HasSoftLimit = null,
            HasUnlimitedUsage = null,
            HiddenFromWidgets = null,
            IsCustom = null,
            IsGranted = null,
            Order = null,
            ResetPeriod = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
        };

        Assert.Null(model.MonthlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("monthlyResetPeriodConfiguration"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
        Assert.Null(model.WeeklyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("weeklyResetPeriodConfiguration"));
        Assert.Null(model.YearlyResetPeriodConfiguration);
        Assert.False(model.RawData.ContainsKey("yearlyResetPeriodConfiguration"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,

            MonthlyResetPeriodConfiguration = null,
            UsageLimit = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

        Assert.Null(model.MonthlyResetPeriodConfiguration);
        Assert.True(model.RawData.ContainsKey("monthlyResetPeriodConfiguration"));
        Assert.Null(model.UsageLimit);
        Assert.True(model.RawData.ContainsKey("usageLimit"));
        Assert.Null(model.WeeklyResetPeriodConfiguration);
        Assert.True(model.RawData.ContainsKey("weeklyResetPeriodConfiguration"));
        Assert.Null(model.YearlyResetPeriodConfiguration);
        Assert.True(model.RawData.ContainsKey("yearlyResetPeriodConfiguration"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,

            MonthlyResetPeriodConfiguration = null,
            UsageLimit = null,
            WeeklyResetPeriodConfiguration = null,
            YearlyResetPeriodConfiguration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BodyFeature
        {
            Behavior = BodyFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [BodyFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = BodyFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        BodyFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BodyFeatureBehaviorTest : TestBase
{
    [Theory]
    [InlineData(BodyFeatureBehavior.Increment)]
    [InlineData(BodyFeatureBehavior.Override)]
    public void Validation_Works(BodyFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyFeatureBehavior.Increment)]
    [InlineData(BodyFeatureBehavior.Override)]
    public void SerializationRoundtrip_Works(BodyFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BodyFeatureHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(BodyFeatureHiddenFromWidget.Paywall)]
    [InlineData(BodyFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(BodyFeatureHiddenFromWidget.Checkout)]
    public void Validation_Works(BodyFeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyFeatureHiddenFromWidget.Paywall)]
    [InlineData(BodyFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(BodyFeatureHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(BodyFeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BodyFeatureMonthlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BodyFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyFeatureMonthlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BodyFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyFeatureMonthlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BodyFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BodyFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        BodyFeatureMonthlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BodyFeatureMonthlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth)]
    public void Validation_Works(BodyFeatureMonthlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(BodyFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(
        BodyFeatureMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureMonthlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BodyFeatureResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(BodyFeatureResetPeriod.Year)]
    [InlineData(BodyFeatureResetPeriod.Month)]
    [InlineData(BodyFeatureResetPeriod.Week)]
    [InlineData(BodyFeatureResetPeriod.Day)]
    [InlineData(BodyFeatureResetPeriod.Hour)]
    public void Validation_Works(BodyFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyFeatureResetPeriod.Year)]
    [InlineData(BodyFeatureResetPeriod.Month)]
    [InlineData(BodyFeatureResetPeriod.Week)]
    [InlineData(BodyFeatureResetPeriod.Day)]
    [InlineData(BodyFeatureResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(BodyFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyFeatureResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BodyFeatureWeeklyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BodyFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyFeatureWeeklyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BodyFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyFeatureWeeklyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BodyFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BodyFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        BodyFeatureWeeklyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BodyFeatureWeeklyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void Validation_Works(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(BodyFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(
        BodyFeatureWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureWeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BodyFeatureYearlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BodyFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyFeatureYearlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BodyFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyFeatureYearlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BodyFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BodyFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo = BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        BodyFeatureYearlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BodyFeatureYearlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void Validation_Works(BodyFeatureYearlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(
        BodyFeatureYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BodyFeatureYearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BodyCreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BodyCredit
        {
            Amount = 1,
            Behavior = BodyCreditBehavior.Increment,
            Cadence = BodyCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [BodyCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        double expectedAmount = 1;
        ApiEnum<string, BodyCreditBehavior> expectedBehavior = BodyCreditBehavior.Increment;
        ApiEnum<string, BodyCreditCadence> expectedCadence = BodyCreditCadence.Month;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<ApiEnum<string, BodyCreditHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            BodyCreditHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBehavior, model.Behavior);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayNameOverride, model.DisplayNameOverride);
        Assert.NotNull(model.HiddenFromWidgets);
        Assert.Equal(expectedHiddenFromWidgets.Count, model.HiddenFromWidgets.Count);
        for (int i = 0; i < expectedHiddenFromWidgets.Count; i++)
        {
            Assert.Equal(expectedHiddenFromWidgets[i], model.HiddenFromWidgets[i]);
        }
        Assert.Equal(expectedIsCustom, model.IsCustom);
        Assert.Equal(expectedIsGranted, model.IsGranted);
        Assert.Equal(expectedOrder, model.Order);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BodyCredit
        {
            Amount = 1,
            Behavior = BodyCreditBehavior.Increment,
            Cadence = BodyCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [BodyCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyCredit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BodyCredit
        {
            Amount = 1,
            Behavior = BodyCreditBehavior.Increment,
            Cadence = BodyCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [BodyCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BodyCredit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("CREDIT");
        double expectedAmount = 1;
        ApiEnum<string, BodyCreditBehavior> expectedBehavior = BodyCreditBehavior.Increment;
        ApiEnum<string, BodyCreditCadence> expectedCadence = BodyCreditCadence.Month;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<ApiEnum<string, BodyCreditHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            BodyCreditHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBehavior, deserialized.Behavior);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayNameOverride, deserialized.DisplayNameOverride);
        Assert.NotNull(deserialized.HiddenFromWidgets);
        Assert.Equal(expectedHiddenFromWidgets.Count, deserialized.HiddenFromWidgets.Count);
        for (int i = 0; i < expectedHiddenFromWidgets.Count; i++)
        {
            Assert.Equal(expectedHiddenFromWidgets[i], deserialized.HiddenFromWidgets[i]);
        }
        Assert.Equal(expectedIsCustom, deserialized.IsCustom);
        Assert.Equal(expectedIsGranted, deserialized.IsGranted);
        Assert.Equal(expectedOrder, deserialized.Order);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BodyCredit
        {
            Amount = 1,
            Behavior = BodyCreditBehavior.Increment,
            Cadence = BodyCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [BodyCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BodyCredit { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Behavior);
        Assert.False(model.RawData.ContainsKey("behavior"));
        Assert.Null(model.Cadence);
        Assert.False(model.RawData.ContainsKey("cadence"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayNameOverride);
        Assert.False(model.RawData.ContainsKey("displayNameOverride"));
        Assert.Null(model.HiddenFromWidgets);
        Assert.False(model.RawData.ContainsKey("hiddenFromWidgets"));
        Assert.Null(model.IsCustom);
        Assert.False(model.RawData.ContainsKey("isCustom"));
        Assert.Null(model.IsGranted);
        Assert.False(model.RawData.ContainsKey("isGranted"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BodyCredit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BodyCredit
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Behavior = null,
            Cadence = null,
            Description = null,
            DisplayNameOverride = null,
            HiddenFromWidgets = null,
            IsCustom = null,
            IsGranted = null,
            Order = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.Behavior);
        Assert.False(model.RawData.ContainsKey("behavior"));
        Assert.Null(model.Cadence);
        Assert.False(model.RawData.ContainsKey("cadence"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DisplayNameOverride);
        Assert.False(model.RawData.ContainsKey("displayNameOverride"));
        Assert.Null(model.HiddenFromWidgets);
        Assert.False(model.RawData.ContainsKey("hiddenFromWidgets"));
        Assert.Null(model.IsCustom);
        Assert.False(model.RawData.ContainsKey("isCustom"));
        Assert.Null(model.IsGranted);
        Assert.False(model.RawData.ContainsKey("isGranted"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BodyCredit
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            Behavior = null,
            Cadence = null,
            Description = null,
            DisplayNameOverride = null,
            HiddenFromWidgets = null,
            IsCustom = null,
            IsGranted = null,
            Order = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BodyCredit
        {
            Amount = 1,
            Behavior = BodyCreditBehavior.Increment,
            Cadence = BodyCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [BodyCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        BodyCredit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BodyCreditBehaviorTest : TestBase
{
    [Theory]
    [InlineData(BodyCreditBehavior.Increment)]
    [InlineData(BodyCreditBehavior.Override)]
    public void Validation_Works(BodyCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyCreditBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyCreditBehavior.Increment)]
    [InlineData(BodyCreditBehavior.Override)]
    public void SerializationRoundtrip_Works(BodyCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyCreditBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BodyCreditCadenceTest : TestBase
{
    [Theory]
    [InlineData(BodyCreditCadence.Month)]
    [InlineData(BodyCreditCadence.Year)]
    public void Validation_Works(BodyCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyCreditCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyCreditCadence.Month)]
    [InlineData(BodyCreditCadence.Year)]
    public void SerializationRoundtrip_Works(BodyCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyCreditCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BodyCreditHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(BodyCreditHiddenFromWidget.Paywall)]
    [InlineData(BodyCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(BodyCreditHiddenFromWidget.Checkout)]
    public void Validation_Works(BodyCreditHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyCreditHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BodyCreditHiddenFromWidget.Paywall)]
    [InlineData(BodyCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(BodyCreditHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(BodyCreditHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BodyCreditHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BodyCreditHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
