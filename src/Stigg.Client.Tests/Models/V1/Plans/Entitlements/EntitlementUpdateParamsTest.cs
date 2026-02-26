using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Plans.Entitlements;

public class EntitlementUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            PlanID = "planId",
            ID = "id",
            Credit = new()
            {
                Amount = 1,
                Behavior = EntitlementUpdateParamsCreditBehavior.Increment,
                Cadence = EntitlementUpdateParamsCreditCadence.Month,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                HiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
            },
            Feature = new()
            {
                Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(
                    EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                Order = 0,
                ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        string expectedPlanID = "planId";
        string expectedID = "id";
        EntitlementUpdateParamsCredit expectedCredit = new()
        {
            Amount = 1,
            Behavior = EntitlementUpdateParamsCreditBehavior.Increment,
            Cadence = EntitlementUpdateParamsCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };
        EntitlementUpdateParamsFeature expectedFeature = new()
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCredit, parameters.Credit);
        Assert.Equal(expectedFeature, parameters.Feature);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntitlementUpdateParams { PlanID = "planId", ID = "id" };

        Assert.Null(parameters.Credit);
        Assert.False(parameters.RawBodyData.ContainsKey("credit"));
        Assert.Null(parameters.Feature);
        Assert.False(parameters.RawBodyData.ContainsKey("feature"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            PlanID = "planId",
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Credit = null,
            Feature = null,
        };

        Assert.Null(parameters.Credit);
        Assert.False(parameters.RawBodyData.ContainsKey("credit"));
        Assert.Null(parameters.Feature);
        Assert.False(parameters.RawBodyData.ContainsKey("feature"));
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementUpdateParams parameters = new() { PlanID = "planId", ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans/planId/entitlements/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementUpdateParams
        {
            PlanID = "planId",
            ID = "id",
            Credit = new()
            {
                Amount = 1,
                Behavior = EntitlementUpdateParamsCreditBehavior.Increment,
                Cadence = EntitlementUpdateParamsCreditCadence.Month,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                HiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
            },
            Feature = new()
            {
                Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                MonthlyResetPeriodConfiguration = new(
                    EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                Order = 0,
                ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
                UsageLimit = 0,
                WeeklyResetPeriodConfiguration = new(
                    EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        };

        EntitlementUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntitlementUpdateParamsCreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsCredit
        {
            Amount = 1,
            Behavior = EntitlementUpdateParamsCreditBehavior.Increment,
            Cadence = EntitlementUpdateParamsCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        double expectedAmount = 1;
        ApiEnum<string, EntitlementUpdateParamsCreditBehavior> expectedBehavior =
            EntitlementUpdateParamsCreditBehavior.Increment;
        ApiEnum<string, EntitlementUpdateParamsCreditCadence> expectedCadence =
            EntitlementUpdateParamsCreditCadence.Month;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<
            ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;

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
        var model = new EntitlementUpdateParamsCredit
        {
            Amount = 1,
            Behavior = EntitlementUpdateParamsCreditBehavior.Increment,
            Cadence = EntitlementUpdateParamsCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsCredit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsCredit
        {
            Amount = 1,
            Behavior = EntitlementUpdateParamsCreditBehavior.Increment,
            Cadence = EntitlementUpdateParamsCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsCredit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 1;
        ApiEnum<string, EntitlementUpdateParamsCreditBehavior> expectedBehavior =
            EntitlementUpdateParamsCreditBehavior.Increment;
        ApiEnum<string, EntitlementUpdateParamsCreditCadence> expectedCadence =
            EntitlementUpdateParamsCreditCadence.Month;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<
            ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;

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
        var model = new EntitlementUpdateParamsCredit
        {
            Amount = 1,
            Behavior = EntitlementUpdateParamsCreditBehavior.Increment,
            Cadence = EntitlementUpdateParamsCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementUpdateParamsCredit { };

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
        var model = new EntitlementUpdateParamsCredit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntitlementUpdateParamsCredit
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
        var model = new EntitlementUpdateParamsCredit
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
        var model = new EntitlementUpdateParamsCredit
        {
            Amount = 1,
            Behavior = EntitlementUpdateParamsCreditBehavior.Increment,
            Cadence = EntitlementUpdateParamsCreditCadence.Month,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HiddenFromWidgets = [EntitlementUpdateParamsCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
        };

        EntitlementUpdateParamsCredit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsCreditBehaviorTest : TestBase
{
    [Theory]
    [InlineData(EntitlementUpdateParamsCreditBehavior.Increment)]
    [InlineData(EntitlementUpdateParamsCreditBehavior.Override)]
    public void Validation_Works(EntitlementUpdateParamsCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsCreditBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementUpdateParamsCreditBehavior.Increment)]
    [InlineData(EntitlementUpdateParamsCreditBehavior.Override)]
    public void SerializationRoundtrip_Works(EntitlementUpdateParamsCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsCreditBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsCreditCadenceTest : TestBase
{
    [Theory]
    [InlineData(EntitlementUpdateParamsCreditCadence.Month)]
    [InlineData(EntitlementUpdateParamsCreditCadence.Year)]
    public void Validation_Works(EntitlementUpdateParamsCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsCreditCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementUpdateParamsCreditCadence.Month)]
    [InlineData(EntitlementUpdateParamsCreditCadence.Year)]
    public void SerializationRoundtrip_Works(EntitlementUpdateParamsCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsCreditCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsCreditHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(EntitlementUpdateParamsCreditHiddenFromWidget.Paywall)]
    [InlineData(EntitlementUpdateParamsCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementUpdateParamsCreditHiddenFromWidget.Checkout)]
    public void Validation_Works(EntitlementUpdateParamsCreditHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementUpdateParamsCreditHiddenFromWidget.Paywall)]
    [InlineData(EntitlementUpdateParamsCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementUpdateParamsCreditHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(EntitlementUpdateParamsCreditHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsCreditHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        ApiEnum<string, EntitlementUpdateParamsFeatureBehavior> expectedBehavior =
            EntitlementUpdateParamsFeatureBehavior.Increment;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        double expectedOrder = 0;
        ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod> expectedResetPeriod =
            EntitlementUpdateParamsFeatureResetPeriod.Year;
        long expectedUsageLimit = 0;
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration =
            new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration =
            new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );

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
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntitlementUpdateParamsFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, EntitlementUpdateParamsFeatureBehavior> expectedBehavior =
            EntitlementUpdateParamsFeatureBehavior.Increment;
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<
            ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>
        > expectedHiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration =
            new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        double expectedOrder = 0;
        ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod> expectedResetPeriod =
            EntitlementUpdateParamsFeatureResetPeriod.Year;
        long expectedUsageLimit = 0;
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration =
            new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration =
            new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            );

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
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EntitlementUpdateParamsFeature
        {
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new EntitlementUpdateParamsFeature
        {
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EntitlementUpdateParamsFeature
        {
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new EntitlementUpdateParamsFeature
        {
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
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
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
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
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,

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
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,

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
        var model = new EntitlementUpdateParamsFeature
        {
            Behavior = EntitlementUpdateParamsFeatureBehavior.Increment,
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            MonthlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            Order = 0,
            ResetPeriod = EntitlementUpdateParamsFeatureResetPeriod.Year,
            UsageLimit = 0,
            WeeklyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        EntitlementUpdateParamsFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsFeatureBehaviorTest : TestBase
{
    [Theory]
    [InlineData(EntitlementUpdateParamsFeatureBehavior.Increment)]
    [InlineData(EntitlementUpdateParamsFeatureBehavior.Override)]
    public void Validation_Works(EntitlementUpdateParamsFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsFeatureBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementUpdateParamsFeatureBehavior.Increment)]
    [InlineData(EntitlementUpdateParamsFeatureBehavior.Override)]
    public void SerializationRoundtrip_Works(EntitlementUpdateParamsFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsFeatureBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsFeatureHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall)]
    [InlineData(EntitlementUpdateParamsFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementUpdateParamsFeatureHiddenFromWidget.Checkout)]
    public void Validation_Works(EntitlementUpdateParamsFeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementUpdateParamsFeatureHiddenFromWidget.Paywall)]
    [InlineData(EntitlementUpdateParamsFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(EntitlementUpdateParamsFeatureHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(
        EntitlementUpdateParamsFeatureHiddenFromWidget rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
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
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsFeatureResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Year)]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Month)]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Week)]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Day)]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Hour)]
    public void Validation_Works(EntitlementUpdateParamsFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Year)]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Month)]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Week)]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Day)]
    [InlineData(EntitlementUpdateParamsFeatureResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(EntitlementUpdateParamsFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySunday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryMonday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryThursday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EveryFriday
    )]
    [InlineData(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
        > expectedAccordingTo =
            EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration
        {
            AccordingTo =
                EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
        };

        EntitlementUpdateParamsFeatureYearlyResetPeriodConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingToTest : TestBase
{
    [Theory]
    [InlineData(
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
