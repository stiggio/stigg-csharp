using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Tests.Models.V1.Customers.PromotionalEntitlements;

public class PromotionalEntitlementGrantParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PromotionalEntitlementGrantParams
        {
            CustomerID = "customerId",
            PromotionalEntitlements =
            [
                new()
                {
                    CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    IsVisible = true,
                    MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                    Period = Period.V1Week,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = -9007199254740991,
                    WeeklyResetPeriodConfiguration = new(
                        WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        string expectedCustomerID = "customerId";
        List<PromotionalEntitlement> expectedPromotionalEntitlements =
        [
            new()
            {
                CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EnumValues = ["string"],
                FeatureID = "featureId",
                HasSoftLimit = true,
                HasUnlimitedUsage = true,
                IsVisible = true,
                MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                Period = Period.V1Week,
                ResetPeriod = ResetPeriod.Year,
                UsageLimit = -9007199254740991,
                WeeklyResetPeriodConfiguration = new(
                    WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
                YearlyResetPeriodConfiguration = new(
                    YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                ),
            },
        ];

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(
            expectedPromotionalEntitlements.Count,
            parameters.PromotionalEntitlements.Count
        );
        for (int i = 0; i < expectedPromotionalEntitlements.Count; i++)
        {
            Assert.Equal(expectedPromotionalEntitlements[i], parameters.PromotionalEntitlements[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        PromotionalEntitlementGrantParams parameters = new()
        {
            CustomerID = "customerId",
            PromotionalEntitlements =
            [
                new()
                {
                    CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    IsVisible = true,
                    MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                    Period = Period.V1Week,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = -9007199254740991,
                    WeeklyResetPeriodConfiguration = new(
                        WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/customers/customerId/promotional"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PromotionalEntitlementGrantParams
        {
            CustomerID = "customerId",
            PromotionalEntitlements =
            [
                new()
                {
                    CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EnumValues = ["string"],
                    FeatureID = "featureId",
                    HasSoftLimit = true,
                    HasUnlimitedUsage = true,
                    IsVisible = true,
                    MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                    Period = Period.V1Week,
                    ResetPeriod = ResetPeriod.Year,
                    UsageLimit = -9007199254740991,
                    WeeklyResetPeriodConfiguration = new(
                        WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                    YearlyResetPeriodConfiguration = new(
                        YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                    ),
                },
            ],
        };

        PromotionalEntitlementGrantParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PromotionalEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalEntitlement
        {
            CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Period = Period.V1Week,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = -9007199254740991,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        DateTimeOffset expectedCustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedEnumValues = ["string"];
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        bool expectedIsVisible = true;
        MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            AccordingTo.SubscriptionStart
        );
        ApiEnum<string, Period> expectedPeriod = Period.V1Week;
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        long expectedUsageLimit = -9007199254740991;
        WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.Equal(expectedCustomEndDate, model.CustomEndDate);
        Assert.NotNull(model.EnumValues);
        Assert.Equal(expectedEnumValues.Count, model.EnumValues.Count);
        for (int i = 0; i < expectedEnumValues.Count; i++)
        {
            Assert.Equal(expectedEnumValues[i], model.EnumValues[i]);
        }
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedHasUnlimitedUsage, model.HasUnlimitedUsage);
        Assert.Equal(expectedIsVisible, model.IsVisible);
        Assert.Equal(
            expectedMonthlyResetPeriodConfiguration,
            model.MonthlyResetPeriodConfiguration
        );
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedWeeklyResetPeriodConfiguration, model.WeeklyResetPeriodConfiguration);
        Assert.Equal(expectedYearlyResetPeriodConfiguration, model.YearlyResetPeriodConfiguration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PromotionalEntitlement
        {
            CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Period = Period.V1Week,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = -9007199254740991,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalEntitlement
        {
            CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Period = Period.V1Week,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = -9007199254740991,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedEnumValues = ["string"];
        string expectedFeatureID = "featureId";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        bool expectedIsVisible = true;
        MonthlyResetPeriodConfiguration expectedMonthlyResetPeriodConfiguration = new(
            AccordingTo.SubscriptionStart
        );
        ApiEnum<string, Period> expectedPeriod = Period.V1Week;
        ApiEnum<string, ResetPeriod> expectedResetPeriod = ResetPeriod.Year;
        long expectedUsageLimit = -9007199254740991;
        WeeklyResetPeriodConfiguration expectedWeeklyResetPeriodConfiguration = new(
            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );
        YearlyResetPeriodConfiguration expectedYearlyResetPeriodConfiguration = new(
            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
        );

        Assert.Equal(expectedCustomEndDate, deserialized.CustomEndDate);
        Assert.NotNull(deserialized.EnumValues);
        Assert.Equal(expectedEnumValues.Count, deserialized.EnumValues.Count);
        for (int i = 0; i < expectedEnumValues.Count; i++)
        {
            Assert.Equal(expectedEnumValues[i], deserialized.EnumValues[i]);
        }
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
        Assert.Equal(expectedHasUnlimitedUsage, deserialized.HasUnlimitedUsage);
        Assert.Equal(expectedIsVisible, deserialized.IsVisible);
        Assert.Equal(
            expectedMonthlyResetPeriodConfiguration,
            deserialized.MonthlyResetPeriodConfiguration
        );
        Assert.Equal(expectedPeriod, deserialized.Period);
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
        var model = new PromotionalEntitlement
        {
            CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Period = Period.V1Week,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = -9007199254740991,
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
    public void CopyConstructor_Works()
    {
        var model = new PromotionalEntitlement
        {
            CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            FeatureID = "featureId",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
            Period = Period.V1Week,
            ResetPeriod = ResetPeriod.Year,
            UsageLimit = -9007199254740991,
            WeeklyResetPeriodConfiguration = new(
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
            YearlyResetPeriodConfiguration = new(
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
            ),
        };

        PromotionalEntitlement copied = new(model);

        Assert.Equal(model, copied);
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

public class PeriodTest : TestBase
{
    [Theory]
    [InlineData(Period.V1Week)]
    [InlineData(Period.V1Month)]
    [InlineData(Period.V6Month)]
    [InlineData(Period.V1Year)]
    [InlineData(Period.Lifetime)]
    [InlineData(Period.Custom)]
    public void Validation_Works(Period rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Period> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Period.V1Week)]
    [InlineData(Period.V1Month)]
    [InlineData(Period.V6Month)]
    [InlineData(Period.V1Year)]
    [InlineData(Period.Lifetime)]
    [InlineData(Period.Custom)]
    public void SerializationRoundtrip_Works(Period rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Period> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
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
