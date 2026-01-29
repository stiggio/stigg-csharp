using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Tests.Models.V1.Customers.PromotionalEntitlements;

public class PromotionalEntitlementRevokeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalEntitlementRevokeResponse
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
                Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        PromotionalEntitlementRevokeResponseData expectedData = new()
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
            Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PromotionalEntitlementRevokeResponse
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
                Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalEntitlementRevokeResponse
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
                Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PromotionalEntitlementRevokeResponseData expectedData = new()
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
            Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PromotionalEntitlementRevokeResponse
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
                Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PromotionalEntitlementRevokeResponse
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
                Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
                ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
                ResetPeriodConfiguration =
                    new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
            },
        };

        PromotionalEntitlementRevokeResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementRevokeResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalEntitlementRevokeResponseData
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
            Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
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
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod> expectedPeriod =
            PromotionalEntitlementRevokeResponseDataPeriod.V1Week;
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod> expectedResetPeriod =
            PromotionalEntitlementRevokeResponseDataResetPeriod.Year;
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration expectedResetPeriodConfiguration =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus> expectedStatus =
            PromotionalEntitlementRevokeResponseDataStatus.Active;
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
        var model = new PromotionalEntitlementRevokeResponseData
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
            Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalEntitlementRevokeResponseData
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
            Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseData>(
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
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod> expectedPeriod =
            PromotionalEntitlementRevokeResponseDataPeriod.V1Week;
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod> expectedResetPeriod =
            PromotionalEntitlementRevokeResponseDataResetPeriod.Year;
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration expectedResetPeriodConfiguration =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus> expectedStatus =
            PromotionalEntitlementRevokeResponseDataStatus.Active;
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
        var model = new PromotionalEntitlementRevokeResponseData
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
            Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PromotionalEntitlementRevokeResponseData
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
            Period = PromotionalEntitlementRevokeResponseDataPeriod.V1Week,
            ResetPeriod = PromotionalEntitlementRevokeResponseDataResetPeriod.Year,
            ResetPeriodConfiguration =
                new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PromotionalEntitlementRevokeResponseDataStatus.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        PromotionalEntitlementRevokeResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementRevokeResponseDataPeriodTest : TestBase
{
    [Theory]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.V1Week)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.V1Month)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.V6Month)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.V1Year)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.Lifetime)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.Custom)]
    public void Validation_Works(PromotionalEntitlementRevokeResponseDataPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.V1Week)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.V1Month)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.V6Month)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.V1Year)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.Lifetime)]
    [InlineData(PromotionalEntitlementRevokeResponseDataPeriod.Custom)]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementRevokeResponseDataPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementRevokeResponseDataResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Year)]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Month)]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Week)]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Day)]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Hour)]
    public void Validation_Works(PromotionalEntitlementRevokeResponseDataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Year)]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Month)]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Week)]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Day)]
    [InlineData(PromotionalEntitlementRevokeResponseDataResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementRevokeResponseDataResetPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataResetPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationTest : TestBase
{
    [Fact]
    public void YearlyResetPeriodConfigValidationWorks()
    {
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration value =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void MonthlyResetPeriodConfigValidationWorks()
    {
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration value =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void WeeklyResetPeriodConfigValidationWorks()
    {
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration value =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        value.Validate();
    }

    [Fact]
    public void YearlyResetPeriodConfigSerializationRoundtripWorks()
    {
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration value =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig(
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonthlyResetPeriodConfigSerializationRoundtripWorks()
    {
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration value =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig(
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WeeklyResetPeriodConfigSerializationRoundtripWorks()
    {
        PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration value =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig(
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfiguration>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void Validation_Works(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
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
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void Validation_Works(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo.StartOfTheMonth
    )]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
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
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigTest
    : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > expectedAccordingTo =
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig
            {
                AccordingTo =
                    PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart,
            };

        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfig copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingToTest
    : TestBase
{
    [Theory]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void Validation_Works(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.SubscriptionStart
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySunday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryMonday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryTuesday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryWednesday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryThursday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EveryFriday
    )]
    [InlineData(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo.EverySaturday
    )]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
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
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PromotionalEntitlementRevokeResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(PromotionalEntitlementRevokeResponseDataStatus.Active)]
    [InlineData(PromotionalEntitlementRevokeResponseDataStatus.Expired)]
    [InlineData(PromotionalEntitlementRevokeResponseDataStatus.Paused)]
    public void Validation_Works(PromotionalEntitlementRevokeResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PromotionalEntitlementRevokeResponseDataStatus.Active)]
    [InlineData(PromotionalEntitlementRevokeResponseDataStatus.Expired)]
    [InlineData(PromotionalEntitlementRevokeResponseDataStatus.Paused)]
    public void SerializationRoundtrip_Works(
        PromotionalEntitlementRevokeResponseDataStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PromotionalEntitlementRevokeResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
