using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Addons.Entitlements;

public class AddonPackageEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonPackageEntitlement
        {
            Data = new DataFeature()
            {
                ID = "id",
                Behavior = DataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = DataFeatureResetPeriod.Year,
                ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                    YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        Data expectedData = new DataFeature()
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonPackageEntitlement
        {
            Data = new DataFeature()
            {
                ID = "id",
                Behavior = DataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = DataFeatureResetPeriod.Year,
                ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                    YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPackageEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonPackageEntitlement
        {
            Data = new DataFeature()
            {
                ID = "id",
                Behavior = DataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = DataFeatureResetPeriod.Year,
                ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                    YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPackageEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new DataFeature()
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonPackageEntitlement
        {
            Data = new DataFeature()
            {
                ID = "id",
                Behavior = DataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = DataFeatureResetPeriod.Year,
                ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                    YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonPackageEntitlement
        {
            Data = new DataFeature()
            {
                ID = "id",
                Behavior = DataFeatureBehavior.Increment,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = DataFeatureResetPeriod.Year,
                ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                    YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        AddonPackageEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FeatureValidationWorks()
    {
        Data value = new DataFeature()
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CreditValidationWorks()
    {
        Data value = new DataCredit()
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
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
        Data value = new DataFeature()
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreditSerializationRoundtripWorks()
    {
        Data value = new DataCredit()
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataFeature
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string expectedID = "id";
        ApiEnum<string, DataFeatureBehavior> expectedBehavior = DataFeatureBehavior.Increment;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<ApiEnum<string, DataFeatureHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            DataFeatureHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, DataFeatureResetPeriod> expectedResetPeriod = DataFeatureResetPeriod.Year;
        ResetPeriodConfiguration expectedResetPeriodConfiguration = new YearlyResetPeriodConfig(
            YearlyResetPeriodConfigAccordingTo.SubscriptionStart
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
        var model = new DataFeature
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataFeature
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, DataFeatureBehavior> expectedBehavior = DataFeatureBehavior.Increment;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<ApiEnum<string, DataFeatureHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            DataFeatureHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, DataFeatureResetPeriod> expectedResetPeriod = DataFeatureResetPeriod.Year;
        ResetPeriodConfiguration expectedResetPeriodConfiguration = new YearlyResetPeriodConfig(
            YearlyResetPeriodConfigAccordingTo.SubscriptionStart
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
        var model = new DataFeature
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataFeature
        {
            ID = "id",
            Behavior = DataFeatureBehavior.Increment,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [DataFeatureHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = DataFeatureResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        DataFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataFeatureBehaviorTest : TestBase
{
    [Theory]
    [InlineData(DataFeatureBehavior.Increment)]
    [InlineData(DataFeatureBehavior.Override)]
    public void Validation_Works(DataFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataFeatureBehavior.Increment)]
    [InlineData(DataFeatureBehavior.Override)]
    public void SerializationRoundtrip_Works(DataFeatureBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataFeatureHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(DataFeatureHiddenFromWidget.Paywall)]
    [InlineData(DataFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(DataFeatureHiddenFromWidget.Checkout)]
    public void Validation_Works(DataFeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataFeatureHiddenFromWidget.Paywall)]
    [InlineData(DataFeatureHiddenFromWidget.CustomerPortal)]
    [InlineData(DataFeatureHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(DataFeatureHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataFeatureResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(DataFeatureResetPeriod.Year)]
    [InlineData(DataFeatureResetPeriod.Month)]
    [InlineData(DataFeatureResetPeriod.Week)]
    [InlineData(DataFeatureResetPeriod.Day)]
    [InlineData(DataFeatureResetPeriod.Hour)]
    public void Validation_Works(DataFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataFeatureResetPeriod.Year)]
    [InlineData(DataFeatureResetPeriod.Month)]
    [InlineData(DataFeatureResetPeriod.Week)]
    [InlineData(DataFeatureResetPeriod.Day)]
    [InlineData(DataFeatureResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(DataFeatureResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataFeatureResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataFeatureResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void YearlyResetPeriodConfigValidationWorks()
    {
        ResetPeriodConfiguration value = new YearlyResetPeriodConfig(
            YearlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void MonthlyResetPeriodConfigValidationWorks()
    {
        ResetPeriodConfiguration value = new MonthlyResetPeriodConfig(
            MonthlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void WeeklyResetPeriodConfigValidationWorks()
    {
        ResetPeriodConfiguration value = new WeeklyResetPeriodConfig(
            WeeklyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void YearlyResetPeriodConfigSerializationRoundtripWorks()
    {
        ResetPeriodConfiguration value = new YearlyResetPeriodConfig(
            YearlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonthlyResetPeriodConfigSerializationRoundtripWorks()
    {
        ResetPeriodConfiguration value = new MonthlyResetPeriodConfig(
            MonthlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WeeklyResetPeriodConfigSerializationRoundtripWorks()
    {
        ResetPeriodConfiguration value = new WeeklyResetPeriodConfig(
            WeeklyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class YearlyResetPeriodConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new YearlyResetPeriodConfig
        {
            AccordingTo = YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, YearlyResetPeriodConfigAccordingTo> expectedAccordingTo =
            YearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new YearlyResetPeriodConfig
        {
            AccordingTo = YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<YearlyResetPeriodConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new YearlyResetPeriodConfig
        {
            AccordingTo = YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<YearlyResetPeriodConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, YearlyResetPeriodConfigAccordingTo> expectedAccordingTo =
            YearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new YearlyResetPeriodConfig
        {
            AccordingTo = YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new YearlyResetPeriodConfig
        {
            AccordingTo = YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        YearlyResetPeriodConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class YearlyResetPeriodConfigAccordingToTest : TestBase
{
    [Theory]
    [InlineData(YearlyResetPeriodConfigAccordingTo.SubscriptionStart)]
    public void Validation_Works(YearlyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, YearlyResetPeriodConfigAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, YearlyResetPeriodConfigAccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(YearlyResetPeriodConfigAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(YearlyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, YearlyResetPeriodConfigAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, YearlyResetPeriodConfigAccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, YearlyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonthlyResetPeriodConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MonthlyResetPeriodConfig
        {
            AccordingTo = MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, MonthlyResetPeriodConfigAccordingTo> expectedAccordingTo =
            MonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MonthlyResetPeriodConfig
        {
            AccordingTo = MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonthlyResetPeriodConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MonthlyResetPeriodConfig
        {
            AccordingTo = MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MonthlyResetPeriodConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, MonthlyResetPeriodConfigAccordingTo> expectedAccordingTo =
            MonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MonthlyResetPeriodConfig
        {
            AccordingTo = MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MonthlyResetPeriodConfig
        {
            AccordingTo = MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        MonthlyResetPeriodConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonthlyResetPeriodConfigAccordingToTest : TestBase
{
    [Theory]
    [InlineData(MonthlyResetPeriodConfigAccordingTo.SubscriptionStart)]
    [InlineData(MonthlyResetPeriodConfigAccordingTo.StartOfTheMonth)]
    public void Validation_Works(MonthlyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonthlyResetPeriodConfigAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonthlyResetPeriodConfigAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MonthlyResetPeriodConfigAccordingTo.SubscriptionStart)]
    [InlineData(MonthlyResetPeriodConfigAccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(MonthlyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MonthlyResetPeriodConfigAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonthlyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MonthlyResetPeriodConfigAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MonthlyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WeeklyResetPeriodConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WeeklyResetPeriodConfig
        {
            AccordingTo = WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, WeeklyResetPeriodConfigAccordingTo> expectedAccordingTo =
            WeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WeeklyResetPeriodConfig
        {
            AccordingTo = WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WeeklyResetPeriodConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WeeklyResetPeriodConfig
        {
            AccordingTo = WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WeeklyResetPeriodConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, WeeklyResetPeriodConfigAccordingTo> expectedAccordingTo =
            WeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WeeklyResetPeriodConfig
        {
            AccordingTo = WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WeeklyResetPeriodConfig
        {
            AccordingTo = WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        WeeklyResetPeriodConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WeeklyResetPeriodConfigAccordingToTest : TestBase
{
    [Theory]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.SubscriptionStart)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EverySunday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryMonday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryTuesday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryWednesday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryThursday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryFriday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EverySaturday)]
    public void Validation_Works(WeeklyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeeklyResetPeriodConfigAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WeeklyResetPeriodConfigAccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.SubscriptionStart)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EverySunday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryMonday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryTuesday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryWednesday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryThursday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EveryFriday)]
    [InlineData(WeeklyResetPeriodConfigAccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(WeeklyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WeeklyResetPeriodConfigAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WeeklyResetPeriodConfigAccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WeeklyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataCreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, DataCreditBehavior> expectedBehavior = DataCreditBehavior.Increment;
        ApiEnum<string, DataCreditCadence> expectedCadence = DataCreditCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        bool expectedHasSoftLimit = true;
        List<ApiEnum<string, DataCreditHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            DataCreditHiddenFromWidget.Paywall,
        ];
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
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataCredit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataCredit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, DataCreditBehavior> expectedBehavior = DataCreditBehavior.Increment;
        ApiEnum<string, DataCreditCadence> expectedCadence = DataCreditCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        bool expectedHasSoftLimit = true;
        List<ApiEnum<string, DataCreditHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            DataCreditHiddenFromWidget.Paywall,
        ];
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
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
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
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
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
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
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
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
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
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
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
        var model = new DataCredit
        {
            ID = "id",
            Amount = 0,
            Behavior = DataCreditBehavior.Increment,
            Cadence = DataCreditCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            HasSoftLimit = true,
            HiddenFromWidgets = [DataCreditHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DependencyFeatureID = "dependencyFeatureId",
        };

        DataCredit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataCreditBehaviorTest : TestBase
{
    [Theory]
    [InlineData(DataCreditBehavior.Increment)]
    [InlineData(DataCreditBehavior.Override)]
    public void Validation_Works(DataCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataCreditBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataCreditBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataCreditBehavior.Increment)]
    [InlineData(DataCreditBehavior.Override)]
    public void SerializationRoundtrip_Works(DataCreditBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataCreditBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataCreditBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataCreditBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataCreditBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataCreditCadenceTest : TestBase
{
    [Theory]
    [InlineData(DataCreditCadence.Month)]
    [InlineData(DataCreditCadence.Year)]
    public void Validation_Works(DataCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataCreditCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataCreditCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataCreditCadence.Month)]
    [InlineData(DataCreditCadence.Year)]
    public void SerializationRoundtrip_Works(DataCreditCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataCreditCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataCreditCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataCreditCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataCreditCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataCreditHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(DataCreditHiddenFromWidget.Paywall)]
    [InlineData(DataCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(DataCreditHiddenFromWidget.Checkout)]
    public void Validation_Works(DataCreditHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataCreditHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataCreditHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataCreditHiddenFromWidget.Paywall)]
    [InlineData(DataCreditHiddenFromWidget.CustomerPortal)]
    [InlineData(DataCreditHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(DataCreditHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataCreditHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataCreditHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataCreditHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataCreditHiddenFromWidget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
