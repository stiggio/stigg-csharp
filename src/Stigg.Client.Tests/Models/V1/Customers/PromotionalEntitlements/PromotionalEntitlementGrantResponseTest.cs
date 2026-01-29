using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Tests.Models.V1.Customers.PromotionalEntitlements;

public class PromotionalEntitlementGrantResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalEntitlementGrantResponse
        {
            Data =
            [
                new()
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
                    Period = DataPeriod.V1Week,
                    ResetPeriod = DataResetPeriod.Year,
                    ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                        YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        List<Data> expectedData =
        [
            new()
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
                Period = DataPeriod.V1Week,
                ResetPeriod = DataResetPeriod.Year,
                ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                    YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
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
        var model = new PromotionalEntitlementGrantResponse
        {
            Data =
            [
                new()
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
                    Period = DataPeriod.V1Week,
                    ResetPeriod = DataResetPeriod.Year,
                    ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                        YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlementGrantResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalEntitlementGrantResponse
        {
            Data =
            [
                new()
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
                    Period = DataPeriod.V1Week,
                    ResetPeriod = DataResetPeriod.Year,
                    ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                        YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalEntitlementGrantResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Data> expectedData =
        [
            new()
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
                Period = DataPeriod.V1Week,
                ResetPeriod = DataResetPeriod.Year,
                ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                    YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                ),
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
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
        var model = new PromotionalEntitlementGrantResponse
        {
            Data =
            [
                new()
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
                    Period = DataPeriod.V1Week,
                    ResetPeriod = DataResetPeriod.Year,
                    ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                        YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
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
        var model = new PromotionalEntitlementGrantResponse
        {
            Data =
            [
                new()
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
                    Period = DataPeriod.V1Week,
                    ResetPeriod = DataResetPeriod.Year,
                    ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                        YearlyResetPeriodConfigAccordingTo.SubscriptionStart
                    ),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        PromotionalEntitlementGrantResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
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
            Period = DataPeriod.V1Week,
            ResetPeriod = DataResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
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
        ApiEnum<string, DataPeriod> expectedPeriod = DataPeriod.V1Week;
        ApiEnum<string, DataResetPeriod> expectedResetPeriod = DataResetPeriod.Year;
        ResetPeriodConfiguration expectedResetPeriodConfiguration = new YearlyResetPeriodConfig(
            YearlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.Active;
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
        var model = new Data
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
            Period = DataPeriod.V1Week,
            ResetPeriod = DataResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
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
            Period = DataPeriod.V1Week,
            ResetPeriod = DataResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
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
        ApiEnum<string, DataPeriod> expectedPeriod = DataPeriod.V1Week;
        ApiEnum<string, DataResetPeriod> expectedResetPeriod = DataResetPeriod.Year;
        ResetPeriodConfiguration expectedResetPeriodConfiguration = new YearlyResetPeriodConfig(
            YearlyResetPeriodConfigAccordingTo.SubscriptionStart
        );
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.Active;
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
        var model = new Data
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
            Period = DataPeriod.V1Week,
            ResetPeriod = DataResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
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
            Period = DataPeriod.V1Week,
            ResetPeriod = DataResetPeriod.Year,
            ResetPeriodConfiguration = new YearlyResetPeriodConfig(
                YearlyResetPeriodConfigAccordingTo.SubscriptionStart
            ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataPeriodTest : TestBase
{
    [Theory]
    [InlineData(DataPeriod.V1Week)]
    [InlineData(DataPeriod.V1Month)]
    [InlineData(DataPeriod.V6Month)]
    [InlineData(DataPeriod.V1Year)]
    [InlineData(DataPeriod.Lifetime)]
    [InlineData(DataPeriod.Custom)]
    public void Validation_Works(DataPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataPeriod.V1Week)]
    [InlineData(DataPeriod.V1Month)]
    [InlineData(DataPeriod.V6Month)]
    [InlineData(DataPeriod.V1Year)]
    [InlineData(DataPeriod.Lifetime)]
    [InlineData(DataPeriod.Custom)]
    public void SerializationRoundtrip_Works(DataPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataResetPeriodTest : TestBase
{
    [Theory]
    [InlineData(DataResetPeriod.Year)]
    [InlineData(DataResetPeriod.Month)]
    [InlineData(DataResetPeriod.Week)]
    [InlineData(DataResetPeriod.Day)]
    [InlineData(DataResetPeriod.Hour)]
    public void Validation_Works(DataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataResetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataResetPeriod.Year)]
    [InlineData(DataResetPeriod.Month)]
    [InlineData(DataResetPeriod.Week)]
    [InlineData(DataResetPeriod.Day)]
    [InlineData(DataResetPeriod.Hour)]
    public void SerializationRoundtrip_Works(DataResetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataResetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataResetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataResetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataResetPeriod>>(
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

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Paused)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Paused)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
