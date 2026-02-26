using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Addons.Entitlements;

public class EntitlementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            AddonID = "addonId",
            Entitlements =
            [
                new()
                {
                    Credit = new()
                    {
                        Amount = 1,
                        Cadence = Cadence.Month,
                        CustomCurrencyID = "customCurrencyId",
                        Behavior = Behavior.Increment,
                        Description = "description",
                        DisplayNameOverride = "displayNameOverride",
                        HiddenFromWidgets = [HiddenFromWidget.Paywall],
                        IsCustom = true,
                        IsGranted = true,
                        Order = 0,
                    },
                    Feature = new()
                    {
                        FeatureID = "featureId",
                        Behavior = FeatureBehavior.Increment,
                        Description = "description",
                        DisplayNameOverride = "displayNameOverride",
                        EnumValues = ["string"],
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                        IsCustom = true,
                        IsGranted = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        Order = 0,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                },
            ],
        };

        string expectedAddonID = "addonId";
        List<Entitlement> expectedEntitlements =
        [
            new()
            {
                Credit = new()
                {
                    Amount = 1,
                    Cadence = Cadence.Month,
                    CustomCurrencyID = "customCurrencyId",
                    Behavior = Behavior.Increment,
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    HiddenFromWidgets = [HiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    Order = 0,
                },
                Feature = new()
                {
                    FeatureID = "featureId",
                    Behavior = FeatureBehavior.Increment,
                    Description = "description",
                    DisplayNameOverride = "displayNameOverride",
                    EnumValues = ["string"],
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                    IsCustom = true,
                    IsGranted = true,
                    MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                    Order = 0,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = 0,
                    WeeklyResetPeriodConfiguration = new(
                        WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            },
        ];

        Assert.Equal(expectedAddonID, parameters.AddonID);
        Assert.Equal(expectedEntitlements.Count, parameters.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], parameters.Entitlements[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementCreateParams parameters = new()
        {
            AddonID = "addonId",
            Entitlements =
            [
                new()
                {
                    Credit = new()
                    {
                        Amount = 1,
                        Cadence = Cadence.Month,
                        CustomCurrencyID = "customCurrencyId",
                        Behavior = Behavior.Increment,
                        Description = "description",
                        DisplayNameOverride = "displayNameOverride",
                        HiddenFromWidgets = [HiddenFromWidget.Paywall],
                        IsCustom = true,
                        IsGranted = true,
                        Order = 0,
                    },
                    Feature = new()
                    {
                        FeatureID = "featureId",
                        Behavior = FeatureBehavior.Increment,
                        Description = "description",
                        DisplayNameOverride = "displayNameOverride",
                        EnumValues = ["string"],
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                        IsCustom = true,
                        IsGranted = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        Order = 0,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/addons/addonId/entitlements"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementCreateParams
        {
            AddonID = "addonId",
            Entitlements =
            [
                new()
                {
                    Credit = new()
                    {
                        Amount = 1,
                        Cadence = Cadence.Month,
                        CustomCurrencyID = "customCurrencyId",
                        Behavior = Behavior.Increment,
                        Description = "description",
                        DisplayNameOverride = "displayNameOverride",
                        HiddenFromWidgets = [HiddenFromWidget.Paywall],
                        IsCustom = true,
                        IsGranted = true,
                        Order = 0,
                    },
                    Feature = new()
                    {
                        FeatureID = "featureId",
                        Behavior = FeatureBehavior.Increment,
                        Description = "description",
                        DisplayNameOverride = "displayNameOverride",
                        EnumValues = ["string"],
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                        IsCustom = true,
                        IsGranted = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        Order = 0,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = 0,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                },
            ],
        };

        EntitlementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entitlement
        {
            Credit = new()
            {
                Amount = 1,
                Cadence = Cadence.Month,
                CustomCurrencyID = "customCurrencyId",
                Behavior = Behavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                HiddenFromWidgets = [HiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
            },
            Feature = new()
            {
                FeatureID = "featureId",
                Behavior = FeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                Order = 0,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        Credit expectedCredit = new()
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
            Behavior = Behavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [HiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };
        Feature expectedFeature = new()
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Assert.Equal(expectedCredit, model.Credit);
        Assert.Equal(expectedFeature, model.Feature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entitlement
        {
            Credit = new()
            {
                Amount = 1,
                Cadence = Cadence.Month,
                CustomCurrencyID = "customCurrencyId",
                Behavior = Behavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                HiddenFromWidgets = [HiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
            },
            Feature = new()
            {
                FeatureID = "featureId",
                Behavior = FeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                Order = 0,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entitlement
        {
            Credit = new()
            {
                Amount = 1,
                Cadence = Cadence.Month,
                CustomCurrencyID = "customCurrencyId",
                Behavior = Behavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                HiddenFromWidgets = [HiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
            },
            Feature = new()
            {
                FeatureID = "featureId",
                Behavior = FeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                Order = 0,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Credit expectedCredit = new()
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
            Behavior = Behavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [HiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };
        Feature expectedFeature = new()
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Assert.Equal(expectedCredit, deserialized.Credit);
        Assert.Equal(expectedFeature, deserialized.Feature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entitlement
        {
            Credit = new()
            {
                Amount = 1,
                Cadence = Cadence.Month,
                CustomCurrencyID = "customCurrencyId",
                Behavior = Behavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                HiddenFromWidgets = [HiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
            },
            Feature = new()
            {
                FeatureID = "featureId",
                Behavior = FeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                Order = 0,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Entitlement { };

        Assert.Null(model.Credit);
        Assert.False(model.RawData.ContainsKey("credit"));
        Assert.Null(model.Feature);
        Assert.False(model.RawData.ContainsKey("feature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Entitlement { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Entitlement
        {
            // Null should be interpreted as omitted for these properties
            Credit = null,
            Feature = null,
        };

        Assert.Null(model.Credit);
        Assert.False(model.RawData.ContainsKey("credit"));
        Assert.Null(model.Feature);
        Assert.False(model.RawData.ContainsKey("feature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Entitlement
        {
            // Null should be interpreted as omitted for these properties
            Credit = null,
            Feature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entitlement
        {
            Credit = new()
            {
                Amount = 1,
                Cadence = Cadence.Month,
                CustomCurrencyID = "customCurrencyId",
                Behavior = Behavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                HiddenFromWidgets = [HiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
            },
            Feature = new()
            {
                FeatureID = "featureId",
                Behavior = FeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                Order = 0,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        Entitlement copied = new(model);

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
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
            Behavior = Behavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [HiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        double expectedAmount = 1;
        ApiEnum<string, Cadence> expectedCadence = Cadence.Month;
        string expectedCustomCurrencyID = "customCurrencyId";
        ApiEnum<string, Behavior> expectedBehavior = Behavior.Increment;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<ApiEnum<string, HiddenFromWidget>> expectedHiddenFromWidgets =
        [
            HiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCustomCurrencyID, model.CustomCurrencyID);
        Assert.Equal(expectedBehavior, model.Behavior);
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
        var model = new Credit
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
            Behavior = Behavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [HiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
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
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
            Behavior = Behavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [HiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedAmount = 1;
        ApiEnum<string, Cadence> expectedCadence = Cadence.Month;
        string expectedCustomCurrencyID = "customCurrencyId";
        ApiEnum<string, Behavior> expectedBehavior = Behavior.Increment;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<ApiEnum<string, HiddenFromWidget>> expectedHiddenFromWidgets =
        [
            HiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCustomCurrencyID, deserialized.CustomCurrencyID);
        Assert.Equal(expectedBehavior, deserialized.Behavior);
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
        var model = new Credit
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
            Behavior = Behavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [HiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Credit
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
        };

        Assert.Null(model.Behavior);
        Assert.False(model.RawData.ContainsKey("behavior"));
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
        var model = new Credit
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Credit
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",

            // Null should be interpreted as omitted for these properties
            Behavior = null,
            Description = null,
            DisplayNameOverride = null,
            HiddenFromWidgets = null,
            IsCustom = null,
            IsGranted = null,
            Order = null,
        };

        Assert.Null(model.Behavior);
        Assert.False(model.RawData.ContainsKey("behavior"));
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
        var model = new Credit
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",

            // Null should be interpreted as omitted for these properties
            Behavior = null,
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
        var model = new Credit
        {
            Amount = 1,
            Cadence = Cadence.Month,
            CustomCurrencyID = "customCurrencyId",
            Behavior = Behavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [HiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        Credit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CadenceTest : TestBase
{
    [Theory]
    [InlineData(Cadence.Month)]
    [InlineData(Cadence.Year)]
    public void Validation_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cadence.Month)]
    [InlineData(Cadence.Year)]
    public void SerializationRoundtrip_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BehaviorTest : TestBase
{
    [Theory]
    [InlineData(Behavior.Increment)]
    [InlineData(Behavior.Override)]
    public void Validation_Works(Behavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Behavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Behavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Behavior.Increment)]
    [InlineData(Behavior.Override)]
    public void SerializationRoundtrip_Works(Behavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Behavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Behavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Behavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Behavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class HiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(HiddenFromWidget.Paywall)]
    [InlineData(HiddenFromWidget.CustomerPortal)]
    [InlineData(HiddenFromWidget.Checkout)]
    public void Validation_Works(HiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, HiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(HiddenFromWidget.Paywall)]
    [InlineData(HiddenFromWidget.CustomerPortal)]
    [InlineData(HiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(HiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, HiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, HiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, HiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, HiddenFromWidget>>(
            json,
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
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string expectedFeatureID = "featureId";
        ApiEnum<string, FeatureBehavior> expectedBehavior = FeatureBehavior.Increment;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<ApiEnum<string, FeatureHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            FeatureHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            AccordingTo.SubscriptionStart
        );
        double expectedOrder = 0;
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        long expectedUsageLimit = 0;
        WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.Equal(expectedFeatureID, model.FeatureID);
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
        var model = new Feature
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
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
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFeatureID = "featureId";
        ApiEnum<string, FeatureBehavior> expectedBehavior = FeatureBehavior.Increment;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<ApiEnum<string, FeatureHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            FeatureHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            AccordingTo.SubscriptionStart
        );
        double expectedOrder = 0;
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        long expectedUsageLimit = 0;
        WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
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
        var model = new Feature
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Feature
        {
            FeatureID = "featureId",
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Feature
        {
            FeatureID = "featureId",
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Feature
        {
            FeatureID = "featureId",
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Feature
        {
            FeatureID = "featureId",
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new Feature
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
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
        var model = new Feature
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Feature
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = ResetPeriod.Year,

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
        var model = new Feature
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = ResetPeriod.Year,

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
        var model = new Feature
        {
            FeatureID = "featureId",
            Behavior = FeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Order = 0,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureBehaviorTest : TestBase
{
    [Theory]
    [InlineData(FeatureBehavior.Increment)]
    [InlineData(FeatureBehavior.Override)]
    public void Validation_Works(FeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureBehavior.Increment)]
    [InlineData(FeatureBehavior.Override)]
    public void SerializationRoundtrip_Works(FeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FeatureHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(FeatureHiddenFromWidget.Paywall)]
    [InlineData(FeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(FeatureHiddenFromWidget.Checkout)]
    public void Validation_Works(FeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FeatureHiddenFromWidget.Paywall)]
    [InlineData(FeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(FeatureHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(FeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FeatureHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FeatureHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FeatureHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MonthlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        ApiEnum<string, AccordingTo> expectedAccordingTo = AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonthlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonthlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccordingTo> expectedAccordingTo = AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonthlyResetPeriodConfiguration
        {
            AccordingTo = AccordingTo.SubscriptionStart,
        };

        MonthlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccordingToTest : TestBase
{
    [Theory]
    [InlineData(AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo.StartOfTheMonth)]
    public void Validation_Works(AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo>>(
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

public class WeeklyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WeeklyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WeeklyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WeeklyResetPeriodConfiguration
        {
            AccordingTo = WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        WeeklyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WeeklyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void Validation_Works(WeeklyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EverySunday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryMonday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryThursday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EveryFriday)]
    [InlineData(WeeklyResetPeriodConfigurationAccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(WeeklyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class YearlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<YearlyResetPeriodConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<YearlyResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> expectedAccordingTo =
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new YearlyResetPeriodConfiguration
        {
            AccordingTo = YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        YearlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class YearlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void Validation_Works(YearlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(YearlyResetPeriodConfigurationAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
