using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Tests.Models.V1.Customers.PromotionalEntitlements;

public class PromotionalEntitlementListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalEntitlementListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            EnvironmentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FeatureGroupIds = ["string"],
            FeatureID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            Period = PromotionalEntitlementListResponsePeriod.V1Week,
            ResetPeriod = PromotionalEntitlementListResponseResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementListResponseStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedEnumValues = ["string"];
        string expectedEnvironmentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<string> expectedFeatureGroupIds = ["string"];
        string expectedFeatureID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        bool expectedIsVisible = true;
        ApiEnum<string, PromotionalEntitlementListResponsePeriod> expectedPeriod =
            PromotionalEntitlementListResponsePeriod.V1Week;
        ApiEnum<string, PromotionalEntitlementListResponseResetPeriod> expectedResetPeriod =
            PromotionalEntitlementListResponseResetPeriod.Year;
        PromotionalEntitlementListResponseResetPeriodConfiguration expectedResetPeriodConfiguration =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PromotionalEntitlementListResponseStatus> expectedStatus =
            PromotionalEntitlementListResponseStatus.Active;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.NotNull(model.EnumValues);
        Assert.Equal(expectedEnumValues.Count, model.EnumValues.Count);
        for (int i = 0; i < expectedEnumValues.Count; i++)
        {
            Assert.Equal(expectedEnumValues[i], model.EnumValues[i]);
        }
        Assert.Equal(expectedEnvironmentID, model.EnvironmentID);
        Assert.NotNull(model.FeatureGroupIds);
        Assert.Equal(expectedFeatureGroupIds.Count, model.FeatureGroupIds.Count);
        for (int i = 0; i < expectedFeatureGroupIds.Count; i++)
        {
            Assert.Equal(expectedFeatureGroupIds[i], model.FeatureGroupIds[i]);
        }
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedHasUnlimitedUsage, model.HasUnlimitedUsage);
        Assert.Equal(expectedIsVisible, model.IsVisible);
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedResetPeriod, model.ResetPeriod);
        Assert.Equal(expectedResetPeriodConfiguration, model.ResetPeriodConfiguration);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PromotionalEntitlementListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            EnvironmentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FeatureGroupIds = ["string"],
            FeatureID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            Period = PromotionalEntitlementListResponsePeriod.V1Week,
            ResetPeriod = PromotionalEntitlementListResponseResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementListResponseStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlementListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalEntitlementListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            EnvironmentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FeatureGroupIds = ["string"],
            FeatureID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            Period = PromotionalEntitlementListResponsePeriod.V1Week,
            ResetPeriod = PromotionalEntitlementListResponseResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementListResponseStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlementListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedEnumValues = ["string"];
        string expectedEnvironmentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<string> expectedFeatureGroupIds = ["string"];
        string expectedFeatureID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedHasSoftLimit = true;
        bool expectedHasUnlimitedUsage = true;
        bool expectedIsVisible = true;
        ApiEnum<string, PromotionalEntitlementListResponsePeriod> expectedPeriod =
            PromotionalEntitlementListResponsePeriod.V1Week;
        ApiEnum<string, PromotionalEntitlementListResponseResetPeriod> expectedResetPeriod =
            PromotionalEntitlementListResponseResetPeriod.Year;
        PromotionalEntitlementListResponseResetPeriodConfiguration expectedResetPeriodConfiguration =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PromotionalEntitlementListResponseStatus> expectedStatus =
            PromotionalEntitlementListResponseStatus.Active;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.NotNull(deserialized.EnumValues);
        Assert.Equal(expectedEnumValues.Count, deserialized.EnumValues.Count);
        for (int i = 0; i < expectedEnumValues.Count; i++)
        {
            Assert.Equal(expectedEnumValues[i], deserialized.EnumValues[i]);
        }
        Assert.Equal(expectedEnvironmentID, deserialized.EnvironmentID);
        Assert.NotNull(deserialized.FeatureGroupIds);
        Assert.Equal(expectedFeatureGroupIds.Count, deserialized.FeatureGroupIds.Count);
        for (int i = 0; i < expectedFeatureGroupIds.Count; i++)
        {
            Assert.Equal(expectedFeatureGroupIds[i], deserialized.FeatureGroupIds[i]);
        }
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
        Assert.Equal(expectedHasUnlimitedUsage, deserialized.HasUnlimitedUsage);
        Assert.Equal(expectedIsVisible, deserialized.IsVisible);
        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedResetPeriod, deserialized.ResetPeriod);
        Assert.Equal(expectedResetPeriodConfiguration, deserialized.ResetPeriodConfiguration);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PromotionalEntitlementListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            EnvironmentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FeatureGroupIds = ["string"],
            FeatureID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            Period = PromotionalEntitlementListResponsePeriod.V1Week,
            ResetPeriod = PromotionalEntitlementListResponseResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementListResponseStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PromotionalEntitlementListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EnumValues = ["string"],
            EnvironmentID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FeatureGroupIds = ["string"],
            FeatureID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            HasSoftLimit = true,
            HasUnlimitedUsage = true,
            IsVisible = true,
            Period = PromotionalEntitlementListResponsePeriod.V1Week,
            ResetPeriod = PromotionalEntitlementListResponseResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementListResponseStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        PromotionalEntitlementListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementListResponsePeriodTest : TestBase
{
    [Theory]
    [InlineData(PromotionalEntitlementListResponsePeriod.V1Week)]
    [InlineData(PromotionalEntitlementListResponsePeriod.V1Month)]
    [InlineData(PromotionalEntitlementListResponsePeriod.V6Month)]
    [InlineData(PromotionalEntitlementListResponsePeriod.V1Year)]
    [InlineData(PromotionalEntitlementListResponsePeriod.Lifetime)]
    [InlineData(PromotionalEntitlementListResponsePeriod.Custom)]
    public void Validation_Works(PromotionalEntitlementListResponsePeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementListResponsePeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponsePeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalEntitlementListResponsePeriod.V1Week)]
    [InlineData(PromotionalEntitlementListResponsePeriod.V1Month)]
    [InlineData(PromotionalEntitlementListResponsePeriod.V6Month)]
    [InlineData(PromotionalEntitlementListResponsePeriod.V1Year)]
    [InlineData(PromotionalEntitlementListResponsePeriod.Lifetime)]
    [InlineData(PromotionalEntitlementListResponsePeriod.Custom)]
    public void SerializationRoundtrip_Works(PromotionalEntitlementListResponsePeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementListResponsePeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponsePeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponsePeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponsePeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementListResponseResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Year)]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Month)]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Week)]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Day)]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Hour)]
    public void Validation_Works(PromotionalEntitlementListResponseResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementListResponseResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponseResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Year)]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Month)]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Week)]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Day)]
    [InlineData(PromotionalEntitlementListResponseResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(PromotionalEntitlementListResponseResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementListResponseResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponseResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponseResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponseResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementListResponseResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void YearlyResetPeriodConfigValidationWorks()
    {
        PromotionalEntitlementListResponseResetPeriodConfiguration value =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void MonthlyResetPeriodConfigValidationWorks()
    {
        PromotionalEntitlementListResponseResetPeriodConfiguration value =
            new PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig(
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void WeeklyResetPeriodConfigValidationWorks()
    {
        PromotionalEntitlementListResponseResetPeriodConfiguration value =
            new PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig(
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void YearlyResetPeriodConfigSerializationRoundtripWorks()
    {
        PromotionalEntitlementListResponseResetPeriodConfiguration value =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig(
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonthlyResetPeriodConfigSerializationRoundtripWorks()
    {
        PromotionalEntitlementListResponseResetPeriodConfiguration value =
            new PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig(
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WeeklyResetPeriodConfigSerializationRoundtripWorks()
    {
        PromotionalEntitlementListResponseResetPeriodConfiguration value =
            new PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig(
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(PromotionalEntitlementListResponseStatus.Active)]
    [InlineData(PromotionalEntitlementListResponseStatus.Expired)]
    [InlineData(PromotionalEntitlementListResponseStatus.Paused)]
    public void Validation_Works(PromotionalEntitlementListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalEntitlementListResponseStatus.Active)]
    [InlineData(PromotionalEntitlementListResponseStatus.Expired)]
    [InlineData(PromotionalEntitlementListResponseStatus.Paused)]
    public void SerializationRoundtrip_Works(PromotionalEntitlementListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementListResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
