using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Customers.Promotional;

namespace Stigg.Tests.Models.V1.Customers.Promotional;

public class PromotionalRevokeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalRevokeResponse
        {
            Data = new()
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
                Period = PromotionalRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        PromotionalRevokeResponseData expectedData = new()
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
            Period = PromotionalRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                    PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PromotionalRevokeResponse
        {
            Data = new()
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
                Period = PromotionalRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalRevokeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalRevokeResponse
        {
            Data = new()
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
                Period = PromotionalRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalRevokeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PromotionalRevokeResponseData expectedData = new()
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
            Period = PromotionalRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                    PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PromotionalRevokeResponse
        {
            Data = new()
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
                Period = PromotionalRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        model.Validate();
    }
}

public class PromotionalRevokeResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalRevokeResponseData
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
            Period = PromotionalRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                    PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalRevokeResponseDataStatus.Active,
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
        ApiEnum<string, PromotionalRevokeResponseDataPeriod> expectedPeriod =
            PromotionalRevokeResponseDataPeriod.V1Week;
        ApiEnum<string, PromotionalRevokeResponseDataResetPeriod> expectedResetPeriod =
            PromotionalRevokeResponseDataResetPeriod.Year;
        PromotionalRevokeResponseDataResetPeriodConfiguration expectedResetPeriodConfiguration =
            new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
            );
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PromotionalRevokeResponseDataStatus> expectedStatus =
            PromotionalRevokeResponseDataStatus.Active;
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
        var model = new PromotionalRevokeResponseData
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
            Period = PromotionalRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                    PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalRevokeResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalRevokeResponseData
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
            Period = PromotionalRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                    PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalRevokeResponseData>(
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
        ApiEnum<string, PromotionalRevokeResponseDataPeriod> expectedPeriod =
            PromotionalRevokeResponseDataPeriod.V1Week;
        ApiEnum<string, PromotionalRevokeResponseDataResetPeriod> expectedResetPeriod =
            PromotionalRevokeResponseDataResetPeriod.Year;
        PromotionalRevokeResponseDataResetPeriodConfiguration expectedResetPeriodConfiguration =
            new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
            );
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PromotionalRevokeResponseDataStatus> expectedStatus =
            PromotionalRevokeResponseDataStatus.Active;
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
        var model = new PromotionalRevokeResponseData
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
            Period = PromotionalRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                    PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }
}

public class PromotionalRevokeResponseDataPeriodTest : TestBase
{
    [Theory]
    [InlineData(PromotionalRevokeResponseDataPeriod.V1Week)]
    [InlineData(PromotionalRevokeResponseDataPeriod.V1Month)]
    [InlineData(PromotionalRevokeResponseDataPeriod.V6Month)]
    [InlineData(PromotionalRevokeResponseDataPeriod.V1Year)]
    [InlineData(PromotionalRevokeResponseDataPeriod.Lifetime)]
    [InlineData(PromotionalRevokeResponseDataPeriod.Custom)]
    public void Validation_Works(PromotionalRevokeResponseDataPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalRevokeResponseDataPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalRevokeResponseDataPeriod.V1Week)]
    [InlineData(PromotionalRevokeResponseDataPeriod.V1Month)]
    [InlineData(PromotionalRevokeResponseDataPeriod.V6Month)]
    [InlineData(PromotionalRevokeResponseDataPeriod.V1Year)]
    [InlineData(PromotionalRevokeResponseDataPeriod.Lifetime)]
    [InlineData(PromotionalRevokeResponseDataPeriod.Custom)]
    public void SerializationRoundtrip_Works(PromotionalRevokeResponseDataPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalRevokeResponseDataPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalRevokeResponseDataResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Year)]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Month)]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Week)]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Day)]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Hour)]
    public void Validation_Works(PromotionalRevokeResponseDataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalRevokeResponseDataResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Year)]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Month)]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Week)]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Day)]
    [InlineData(PromotionalRevokeResponseDataResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(PromotionalRevokeResponseDataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalRevokeResponseDataResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalRevokeResponseDataResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToValidationWorks()
    {
        PromotionalRevokeResponseDataResetPeriodConfiguration value =
            new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void AccordingTo2ValidationWorks()
    {
        PromotionalRevokeResponseDataResetPeriodConfiguration value = new AccordingTo2(
            AccordingTo2AccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void AccordingTo3ValidationWorks()
    {
        PromotionalRevokeResponseDataResetPeriodConfiguration value = new AccordingTo3(
            AccordingTo3AccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToSerializationRoundtripWorks()
    {
        PromotionalRevokeResponseDataResetPeriodConfiguration value =
            new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo(
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalRevokeResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AccordingTo2SerializationRoundtripWorks()
    {
        PromotionalRevokeResponseDataResetPeriodConfiguration value = new AccordingTo2(
            AccordingTo2AccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalRevokeResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AccordingTo3SerializationRoundtripWorks()
    {
        PromotionalRevokeResponseDataResetPeriodConfiguration value = new AccordingTo3(
            AccordingTo3AccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalRevokeResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo
        {
            AccordingTo =
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
        };

        ApiEnum<
            string,
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
        > expectedAccordingTo =
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo
        {
            AccordingTo =
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo
        {
            AccordingTo =
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
        > expectedAccordingTo =
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PromotionalRevokeResponseDataResetPeriodConfigurationAccordingTo
        {
            AccordingTo =
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }
}

public class PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
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
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalRevokeResponseDataResetPeriodConfigurationAccordingToAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccordingTo2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccordingTo2 { AccordingTo = AccordingTo2AccordingTo.SubscriptionStart };

        ApiEnum<string, AccordingTo2AccordingTo> expectedAccordingTo =
            AccordingTo2AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccordingTo2 { AccordingTo = AccordingTo2AccordingTo.SubscriptionStart };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccordingTo2>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccordingTo2 { AccordingTo = AccordingTo2AccordingTo.SubscriptionStart };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccordingTo2>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccordingTo2AccordingTo> expectedAccordingTo =
            AccordingTo2AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccordingTo2 { AccordingTo = AccordingTo2AccordingTo.SubscriptionStart };

        model.Validate();
    }
}

public class AccordingTo2AccordingToTest : TestBase
{
    [Theory]
    [InlineData(AccordingTo2AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo2AccordingTo.StartOfTheMonth)]
    public void Validation_Works(AccordingTo2AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo2AccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo2AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccordingTo2AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo2AccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(AccordingTo2AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo2AccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo2AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo2AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo2AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AccordingTo3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccordingTo3 { AccordingTo = AccordingTo3AccordingTo.SubscriptionStart };

        ApiEnum<string, AccordingTo3AccordingTo> expectedAccordingTo =
            AccordingTo3AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccordingTo3 { AccordingTo = AccordingTo3AccordingTo.SubscriptionStart };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccordingTo3>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccordingTo3 { AccordingTo = AccordingTo3AccordingTo.SubscriptionStart };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccordingTo3>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccordingTo3AccordingTo> expectedAccordingTo =
            AccordingTo3AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccordingTo3 { AccordingTo = AccordingTo3AccordingTo.SubscriptionStart };

        model.Validate();
    }
}

public class AccordingTo3AccordingToTest : TestBase
{
    [Theory]
    [InlineData(AccordingTo3AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo3AccordingTo.EverySunday)]
    [InlineData(AccordingTo3AccordingTo.EveryMonday)]
    [InlineData(AccordingTo3AccordingTo.EveryTuesday)]
    [InlineData(AccordingTo3AccordingTo.EveryWednesday)]
    [InlineData(AccordingTo3AccordingTo.EveryThursday)]
    [InlineData(AccordingTo3AccordingTo.EveryFriday)]
    [InlineData(AccordingTo3AccordingTo.EverySaturday)]
    public void Validation_Works(AccordingTo3AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo3AccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo3AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccordingTo3AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo3AccordingTo.EverySunday)]
    [InlineData(AccordingTo3AccordingTo.EveryMonday)]
    [InlineData(AccordingTo3AccordingTo.EveryTuesday)]
    [InlineData(AccordingTo3AccordingTo.EveryWednesday)]
    [InlineData(AccordingTo3AccordingTo.EveryThursday)]
    [InlineData(AccordingTo3AccordingTo.EveryFriday)]
    [InlineData(AccordingTo3AccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(AccordingTo3AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo3AccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo3AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo3AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo3AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalRevokeResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(PromotionalRevokeResponseDataStatus.Active)]
    [InlineData(PromotionalRevokeResponseDataStatus.Expired)]
    [InlineData(PromotionalRevokeResponseDataStatus.Paused)]
    public void Validation_Works(PromotionalRevokeResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalRevokeResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalRevokeResponseDataStatus.Active)]
    [InlineData(PromotionalRevokeResponseDataStatus.Expired)]
    [InlineData(PromotionalRevokeResponseDataStatus.Paused)]
    public void SerializationRoundtrip_Works(PromotionalRevokeResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalRevokeResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalRevokeResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
