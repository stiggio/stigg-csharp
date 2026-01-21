using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Customers.Promotional;

namespace Stigg.Tests.Models.V1.Customers.Promotional;

public class PromotionalCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PromotionalCreateResponse
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
                    ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                        ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
                ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                    ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
        var model = new PromotionalCreateResponse
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
                    ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                        ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                    ),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PromotionalCreateResponse
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
                    ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                        ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
                    ),
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PromotionalCreateResponse>(
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
                ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                    ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
        var model = new PromotionalCreateResponse
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
                    ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                        ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
            ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
        ResetPeriodConfiguration expectedResetPeriodConfiguration =
            new ResetPeriodConfigurationAccordingTo(
                ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
            ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
            ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
        ResetPeriodConfiguration expectedResetPeriodConfiguration =
            new ResetPeriodConfigurationAccordingTo(
                ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
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
            ResetPeriodConfiguration = new ResetPeriodConfigurationAccordingTo(
                ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
            ),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
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
    public void ResetPeriodConfigurationAccordingToValidationWorks()
    {
        ResetPeriodConfiguration value = new ResetPeriodConfigurationAccordingTo(
            ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void AccordingToModelValidationWorks()
    {
        ResetPeriodConfiguration value = new AccordingToModel(
            AccordingToModelAccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void AccordingTo1ValidationWorks()
    {
        ResetPeriodConfiguration value = new AccordingTo1(
            AccordingTo1AccordingTo.SubscriptionStart
        );
        value.Validate();
    }

    [Fact]
    public void ResetPeriodConfigurationAccordingToSerializationRoundtripWorks()
    {
        ResetPeriodConfiguration value = new ResetPeriodConfigurationAccordingTo(
            ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AccordingToModelSerializationRoundtripWorks()
    {
        ResetPeriodConfiguration value = new AccordingToModel(
            AccordingToModelAccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AccordingTo1SerializationRoundtripWorks()
    {
        ResetPeriodConfiguration value = new AccordingTo1(
            AccordingTo1AccordingTo.SubscriptionStart
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResetPeriodConfiguration>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResetPeriodConfigurationAccordingToTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResetPeriodConfigurationAccordingTo
        {
            AccordingTo = ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo> expectedAccordingTo =
            ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResetPeriodConfigurationAccordingTo
        {
            AccordingTo = ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResetPeriodConfigurationAccordingTo>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResetPeriodConfigurationAccordingTo
        {
            AccordingTo = ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResetPeriodConfigurationAccordingTo>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo> expectedAccordingTo =
            ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResetPeriodConfigurationAccordingTo
        {
            AccordingTo = ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }
}

public class ResetPeriodConfigurationAccordingToAccordingToTest : TestBase
{
    [Theory]
    [InlineData(ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart)]
    public void Validation_Works(ResetPeriodConfigurationAccordingToAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResetPeriodConfigurationAccordingToAccordingTo.SubscriptionStart)]
    public void SerializationRoundtrip_Works(
        ResetPeriodConfigurationAccordingToAccordingTo rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ResetPeriodConfigurationAccordingToAccordingTo>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccordingToModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccordingToModel
        {
            AccordingTo = AccordingToModelAccordingTo.SubscriptionStart,
        };

        ApiEnum<string, AccordingToModelAccordingTo> expectedAccordingTo =
            AccordingToModelAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccordingToModel
        {
            AccordingTo = AccordingToModelAccordingTo.SubscriptionStart,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccordingToModel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccordingToModel
        {
            AccordingTo = AccordingToModelAccordingTo.SubscriptionStart,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccordingToModel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccordingToModelAccordingTo> expectedAccordingTo =
            AccordingToModelAccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccordingToModel
        {
            AccordingTo = AccordingToModelAccordingTo.SubscriptionStart,
        };

        model.Validate();
    }
}

public class AccordingToModelAccordingToTest : TestBase
{
    [Theory]
    [InlineData(AccordingToModelAccordingTo.SubscriptionStart)]
    [InlineData(AccordingToModelAccordingTo.StartOfTheMonth)]
    public void Validation_Works(AccordingToModelAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingToModelAccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingToModelAccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccordingToModelAccordingTo.SubscriptionStart)]
    [InlineData(AccordingToModelAccordingTo.StartOfTheMonth)]
    public void SerializationRoundtrip_Works(AccordingToModelAccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingToModelAccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingToModelAccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingToModelAccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingToModelAccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AccordingTo1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccordingTo1 { AccordingTo = AccordingTo1AccordingTo.SubscriptionStart };

        ApiEnum<string, AccordingTo1AccordingTo> expectedAccordingTo =
            AccordingTo1AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, model.AccordingTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccordingTo1 { AccordingTo = AccordingTo1AccordingTo.SubscriptionStart };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccordingTo1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccordingTo1 { AccordingTo = AccordingTo1AccordingTo.SubscriptionStart };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccordingTo1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccordingTo1AccordingTo> expectedAccordingTo =
            AccordingTo1AccordingTo.SubscriptionStart;

        Assert.Equal(expectedAccordingTo, deserialized.AccordingTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccordingTo1 { AccordingTo = AccordingTo1AccordingTo.SubscriptionStart };

        model.Validate();
    }
}

public class AccordingTo1AccordingToTest : TestBase
{
    [Theory]
    [InlineData(AccordingTo1AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo1AccordingTo.EverySunday)]
    [InlineData(AccordingTo1AccordingTo.EveryMonday)]
    [InlineData(AccordingTo1AccordingTo.EveryTuesday)]
    [InlineData(AccordingTo1AccordingTo.EveryWednesday)]
    [InlineData(AccordingTo1AccordingTo.EveryThursday)]
    [InlineData(AccordingTo1AccordingTo.EveryFriday)]
    [InlineData(AccordingTo1AccordingTo.EverySaturday)]
    public void Validation_Works(AccordingTo1AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo1AccordingTo> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo1AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccordingTo1AccordingTo.SubscriptionStart)]
    [InlineData(AccordingTo1AccordingTo.EverySunday)]
    [InlineData(AccordingTo1AccordingTo.EveryMonday)]
    [InlineData(AccordingTo1AccordingTo.EveryTuesday)]
    [InlineData(AccordingTo1AccordingTo.EveryWednesday)]
    [InlineData(AccordingTo1AccordingTo.EveryThursday)]
    [InlineData(AccordingTo1AccordingTo.EveryFriday)]
    [InlineData(AccordingTo1AccordingTo.EverySaturday)]
    public void SerializationRoundtrip_Works(AccordingTo1AccordingTo rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccordingTo1AccordingTo> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo1AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo1AccordingTo>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccordingTo1AccordingTo>>(
            json,
            ModelBase.SerializerOptions
        );

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
