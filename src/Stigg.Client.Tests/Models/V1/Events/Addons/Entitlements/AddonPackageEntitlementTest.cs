using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Entitlements = Stigg.Client.Models.V1.Events.Addons.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Events.Addons.Entitlements;

public class AddonPackageEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entitlements::AddonPackageEntitlement
        {
            Data = new()
            {
                ID = "id",
                Amount = 0,
                Behavior = Entitlements::DataBehavior.Increment,
                Cadence = Entitlements::DataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = Entitlements::DataResetPeriod.Year,
                ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                    Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                Type = Entitlements::Type.Feature,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        Entitlements::Data expectedData = new()
        {
            ID = "id",
            Amount = 0,
            Behavior = Entitlements::DataBehavior.Increment,
            Cadence = Entitlements::DataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = Entitlements::DataResetPeriod.Year,
            ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            Type = Entitlements::Type.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entitlements::AddonPackageEntitlement
        {
            Data = new()
            {
                ID = "id",
                Amount = 0,
                Behavior = Entitlements::DataBehavior.Increment,
                Cadence = Entitlements::DataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = Entitlements::DataResetPeriod.Year,
                ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                    Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                Type = Entitlements::Type.Feature,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::AddonPackageEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entitlements::AddonPackageEntitlement
        {
            Data = new()
            {
                ID = "id",
                Amount = 0,
                Behavior = Entitlements::DataBehavior.Increment,
                Cadence = Entitlements::DataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = Entitlements::DataResetPeriod.Year,
                ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                    Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                Type = Entitlements::Type.Feature,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::AddonPackageEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Entitlements::Data expectedData = new()
        {
            ID = "id",
            Amount = 0,
            Behavior = Entitlements::DataBehavior.Increment,
            Cadence = Entitlements::DataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = Entitlements::DataResetPeriod.Year,
            ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            Type = Entitlements::Type.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entitlements::AddonPackageEntitlement
        {
            Data = new()
            {
                ID = "id",
                Amount = 0,
                Behavior = Entitlements::DataBehavior.Increment,
                Cadence = Entitlements::DataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = Entitlements::DataResetPeriod.Year,
                ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                    Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                Type = Entitlements::Type.Feature,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entitlements::AddonPackageEntitlement
        {
            Data = new()
            {
                ID = "id",
                Amount = 0,
                Behavior = Entitlements::DataBehavior.Increment,
                Cadence = Entitlements::DataCadence.Month,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomCurrencyID = "customCurrencyId",
                Description = "description",
                DisplayNameOverride = "displayNameOverride",
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
                IsCustom = true,
                IsGranted = true,
                Order = 0,
                ResetPeriod = Entitlements::DataResetPeriod.Year,
                ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                    Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                Type = Entitlements::Type.Feature,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        Entitlements::AddonPackageEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entitlements::Data
        {
            ID = "id",
            Amount = 0,
            Behavior = Entitlements::DataBehavior.Increment,
            Cadence = Entitlements::DataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = Entitlements::DataResetPeriod.Year,
            ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            Type = Entitlements::Type.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, Entitlements::DataBehavior> expectedBehavior =
            Entitlements::DataBehavior.Increment;
        ApiEnum<string, Entitlements::DataCadence> expectedCadence =
            Entitlements::DataCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomCurrencyID = "customCurrencyId";
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<ApiEnum<string, Entitlements::DataHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            Entitlements::DataHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, Entitlements::DataResetPeriod> expectedResetPeriod =
            Entitlements::DataResetPeriod.Year;
        Entitlements::ResetPeriodConfiguration expectedResetPeriodConfiguration =
            new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        ApiEnum<string, Entitlements::Type> expectedType = Entitlements::Type.Feature;
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
        var model = new Entitlements::Data
        {
            ID = "id",
            Amount = 0,
            Behavior = Entitlements::DataBehavior.Increment,
            Cadence = Entitlements::DataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = Entitlements::DataResetPeriod.Year,
            ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            Type = Entitlements::Type.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::Data>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entitlements::Data
        {
            ID = "id",
            Amount = 0,
            Behavior = Entitlements::DataBehavior.Increment,
            Cadence = Entitlements::DataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = Entitlements::DataResetPeriod.Year,
            ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            Type = Entitlements::Type.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::Data>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        ApiEnum<string, Entitlements::DataBehavior> expectedBehavior =
            Entitlements::DataBehavior.Increment;
        ApiEnum<string, Entitlements::DataCadence> expectedCadence =
            Entitlements::DataCadence.Month;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomCurrencyID = "customCurrencyId";
        string expectedDescription = "description";
        string expectedDisplayNameOverride = "displayNameOverride";
        List<string> expectedEnumValues = ["string"];
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        List<ApiEnum<string, Entitlements::DataHiddenFromWidget>> expectedHiddenFromWidgets =
        [
            Entitlements::DataHiddenFromWidget.Paywall,
        ];
        bool expectedIsCustom = true;
        bool expectedIsGranted = true;
        double expectedOrder = 0;
        ApiEnum<string, Entitlements::DataResetPeriod> expectedResetPeriod =
            Entitlements::DataResetPeriod.Year;
        Entitlements::ResetPeriodConfiguration expectedResetPeriodConfiguration =
            new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        ApiEnum<string, Entitlements::Type> expectedType = Entitlements::Type.Feature;
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
        var model = new Entitlements::Data
        {
            ID = "id",
            Amount = 0,
            Behavior = Entitlements::DataBehavior.Increment,
            Cadence = Entitlements::DataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = Entitlements::DataResetPeriod.Year,
            ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            Type = Entitlements::Type.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entitlements::Data
        {
            ID = "id",
            Amount = 0,
            Behavior = Entitlements::DataBehavior.Increment,
            Cadence = Entitlements::DataCadence.Month,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomCurrencyID = "customCurrencyId",
            Description = "description",
            DisplayNameOverride = "displayNameOverride",
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            HiddenFromWidgets = [Entitlements::DataHiddenFromWidget.Paywall],
            IsCustom = true,
            IsGranted = true,
            Order = 0,
            ResetPeriod = Entitlements::DataResetPeriod.Year,
            ResetPeriodConfiguration = new Entitlements::YearlyResetPeriodConfig(
                Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            Type = Entitlements::Type.Feature,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Entitlements::Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataBehaviorTest : TestBase
{
    [Theory]
    [InlineData(Entitlements::DataBehavior.Increment)]
    [InlineData(Entitlements::DataBehavior.Override)]
    public void Validation_Works(Entitlements::DataBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::DataBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entitlements::DataBehavior.Increment)]
    [InlineData(Entitlements::DataBehavior.Override)]
    public void SerializationRoundtrip_Works(Entitlements::DataBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::DataBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataCadenceTest : TestBase
{
    [Theory]
    [InlineData(Entitlements::DataCadence.Month)]
    [InlineData(Entitlements::DataCadence.Year)]
    public void Validation_Works(Entitlements::DataCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::DataCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entitlements::DataCadence.Month)]
    [InlineData(Entitlements::DataCadence.Year)]
    public void SerializationRoundtrip_Works(Entitlements::DataCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::DataCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataCadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataHiddenFromWidgetTest : TestBase
{
    [Theory]
    [InlineData(Entitlements::DataHiddenFromWidget.Paywall)]
    [InlineData(Entitlements::DataHiddenFromWidget.CustomerPortal)]
    [InlineData(Entitlements::DataHiddenFromWidget.Checkout)]
    public void Validation_Works(Entitlements::DataHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::DataHiddenFromWidget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entitlements::DataHiddenFromWidget.Paywall)]
    [InlineData(Entitlements::DataHiddenFromWidget.CustomerPortal)]
    [InlineData(Entitlements::DataHiddenFromWidget.Checkout)]
    public void SerializationRoundtrip_Works(Entitlements::DataHiddenFromWidget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::DataHiddenFromWidget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::DataHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataHiddenFromWidget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::DataHiddenFromWidget>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(Entitlements::DataResetPeriod.Year)]
    [InlineData(Entitlements::DataResetPeriod.Month)]
    [InlineData(Entitlements::DataResetPeriod.Week)]
    [InlineData(Entitlements::DataResetPeriod.Day)]
    [InlineData(Entitlements::DataResetPeriod.Hour)]
    public void Validation_Works(Entitlements::DataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::DataResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entitlements::DataResetPeriod.Year)]
    [InlineData(Entitlements::DataResetPeriod.Month)]
    [InlineData(Entitlements::DataResetPeriod.Week)]
    [InlineData(Entitlements::DataResetPeriod.Day)]
    [InlineData(Entitlements::DataResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(Entitlements::DataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::DataResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::DataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::DataResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::DataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void YearlyResetPeriodConfigValidationWorks()
    {
        Entitlements::ResetPeriodConfiguration value = new Entitlements::YearlyResetPeriodConfig(
            Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void MonthlyResetPeriodConfigValidationWorks()
    {
        Entitlements::ResetPeriodConfiguration value = new Entitlements::MonthlyResetPeriodConfig(
            Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void WeeklyResetPeriodConfigValidationWorks()
    {
        Entitlements::ResetPeriodConfiguration value = new Entitlements::WeeklyResetPeriodConfig(
            Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void YearlyResetPeriodConfigSerializationRoundtripWorks()
    {
        Entitlements::ResetPeriodConfiguration value = new Entitlements::YearlyResetPeriodConfig(
            Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::ResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonthlyResetPeriodConfigSerializationRoundtripWorks()
    {
        Entitlements::ResetPeriodConfiguration value = new Entitlements::MonthlyResetPeriodConfig(
            Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::ResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WeeklyResetPeriodConfigSerializationRoundtripWorks()
    {
        Entitlements::ResetPeriodConfiguration value = new Entitlements::WeeklyResetPeriodConfig(
            Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::ResetPeriodConfiguration>(
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
        var model = new Entitlements::YearlyResetPeriodConfig
        {
            AccordingTo = Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, Entitlements::YearlyResetPeriodConfigAccordingTo> expectedAccordingTo =
            Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entitlements::YearlyResetPeriodConfig
        {
            AccordingTo = Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::YearlyResetPeriodConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entitlements::YearlyResetPeriodConfig
        {
            AccordingTo = Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::YearlyResetPeriodConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Entitlements::YearlyResetPeriodConfigAccordingTo> expectedAccordingTo =
            Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entitlements::YearlyResetPeriodConfig
        {
            AccordingTo = Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entitlements::YearlyResetPeriodConfig
        {
            AccordingTo = Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        Entitlements::YearlyResetPeriodConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class YearlyResetPeriodConfigAccordingToTest : TestBase
{
    [Theory]
    [InlineData(Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart)]
    public void Validation_Works(Entitlements::YearlyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::YearlyResetPeriodConfigAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::YearlyResetPeriodConfigAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entitlements::YearlyResetPeriodConfigAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(
        Entitlements::YearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::YearlyResetPeriodConfigAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::YearlyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::YearlyResetPeriodConfigAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::YearlyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MonthlyResetPeriodConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entitlements::MonthlyResetPeriodConfig
        {
            AccordingTo = Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, Entitlements::MonthlyResetPeriodConfigAccordingTo> expectedAccordingTo =
            Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entitlements::MonthlyResetPeriodConfig
        {
            AccordingTo = Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::MonthlyResetPeriodConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entitlements::MonthlyResetPeriodConfig
        {
            AccordingTo = Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::MonthlyResetPeriodConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Entitlements::MonthlyResetPeriodConfigAccordingTo> expectedAccordingTo =
            Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entitlements::MonthlyResetPeriodConfig
        {
            AccordingTo = Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entitlements::MonthlyResetPeriodConfig
        {
            AccordingTo = Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        Entitlements::MonthlyResetPeriodConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MonthlyResetPeriodConfigAccordingToTest : TestBase
{
    [Theory]
    [InlineData(Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart)]
    [InlineData(Entitlements::MonthlyResetPeriodConfigAccordingTo.StartOfTheMonth)]
    public void Validation_Works(Entitlements::MonthlyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::MonthlyResetPeriodConfigAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::MonthlyResetPeriodConfigAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entitlements::MonthlyResetPeriodConfigAccordingTo.SubscriptionStart)]
    [InlineData(Entitlements::MonthlyResetPeriodConfigAccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(
        Entitlements::MonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::MonthlyResetPeriodConfigAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::MonthlyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::MonthlyResetPeriodConfigAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::MonthlyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WeeklyResetPeriodConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entitlements::WeeklyResetPeriodConfig
        {
            AccordingTo = Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, Entitlements::WeeklyResetPeriodConfigAccordingTo> expectedAccordingTo =
            Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entitlements::WeeklyResetPeriodConfig
        {
            AccordingTo = Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::WeeklyResetPeriodConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entitlements::WeeklyResetPeriodConfig
        {
            AccordingTo = Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entitlements::WeeklyResetPeriodConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Entitlements::WeeklyResetPeriodConfigAccordingTo> expectedAccordingTo =
            Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entitlements::WeeklyResetPeriodConfig
        {
            AccordingTo = Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entitlements::WeeklyResetPeriodConfig
        {
            AccordingTo = Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
        };

        Entitlements::WeeklyResetPeriodConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WeeklyResetPeriodConfigAccordingToTest : TestBase
{
    [Theory]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EverySunday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryMonday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryTuesday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryWednesday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryThursday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryFriday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EverySaturday)]
    public void Validation_Works(Entitlements::WeeklyResetPeriodConfigAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::WeeklyResetPeriodConfigAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::WeeklyResetPeriodConfigAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.SubscriptionStart)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EverySunday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryMonday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryTuesday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryWednesday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryThursday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EveryFriday)]
    [InlineData(Entitlements::WeeklyResetPeriodConfigAccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(
        Entitlements::WeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::WeeklyResetPeriodConfigAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::WeeklyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::WeeklyResetPeriodConfigAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Entitlements::WeeklyResetPeriodConfigAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Entitlements::Type.Feature)]
    [InlineData(Entitlements::Type.Credit)]
    public void Validation_Works(Entitlements::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Entitlements::Type.Feature)]
    [InlineData(Entitlements::Type.Credit)]
    public void SerializationRoundtrip_Works(Entitlements::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Entitlements::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Entitlements::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
