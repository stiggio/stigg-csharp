using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Usage;

namespace Stigg.Client.Tests.Models.V1.Usage;

public class UsageReportResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageReportResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = -9007199254740991,
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<UsageReportResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                FeatureID = "featureId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Value = -9007199254740991,
                CurrentUsage = 0,
                NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ResourceID = "resourceId",
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new UsageReportResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = -9007199254740991,
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageReportResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageReportResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = -9007199254740991,
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageReportResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<UsageReportResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                FeatureID = "featureId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Value = -9007199254740991,
                CurrentUsage = 0,
                NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ResourceID = "resourceId",
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new UsageReportResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = -9007199254740991,
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageReportResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    FeatureID = "featureId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = -9007199254740991,
                    CurrentUsage = 0,
                    NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ResourceID = "resourceId",
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        UsageReportResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageReportResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedValue = -9007199254740991;
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedNextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedNextResetDate, model.NextResetDate);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, model.UsagePeriodStart);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageReportResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageReportResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        string expectedFeatureID = "featureId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedValue = -9007199254740991;
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedNextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedNextResetDate, deserialized.NextResetDate);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
        Assert.Equal(expectedUsagePeriodStart, deserialized.UsagePeriodStart);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,
        };

        Assert.Null(model.CurrentUsage);
        Assert.False(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.NextResetDate);
        Assert.False(model.RawData.ContainsKey("nextResetDate"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.False(model.RawData.ContainsKey("usagePeriodStart"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,

            CurrentUsage = null,
            NextResetDate = null,
            ResourceID = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
        };

        Assert.Null(model.CurrentUsage);
        Assert.True(model.RawData.ContainsKey("currentUsage"));
        Assert.Null(model.NextResetDate);
        Assert.True(model.RawData.ContainsKey("nextResetDate"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.UsagePeriodEnd);
        Assert.True(model.RawData.ContainsKey("usagePeriodEnd"));
        Assert.Null(model.UsagePeriodStart);
        Assert.True(model.RawData.ContainsKey("usagePeriodStart"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,

            CurrentUsage = null,
            NextResetDate = null,
            ResourceID = null,
            UsagePeriodEnd = null,
            UsagePeriodStart = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageReportResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            FeatureID = "featureId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = -9007199254740991,
            CurrentUsage = 0,
            NextResetDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsagePeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        UsageReportResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
