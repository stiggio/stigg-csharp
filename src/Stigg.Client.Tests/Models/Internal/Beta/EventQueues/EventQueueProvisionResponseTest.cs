using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueProvisionResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueProvisionResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueProvisionResponseDataRegion.UsEast1,
                Status = EventQueueProvisionResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        EventQueueProvisionResponseData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventQueueProvisionResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueProvisionResponseDataRegion.UsEast1,
                Status = EventQueueProvisionResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueProvisionResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueProvisionResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueProvisionResponseDataRegion.UsEast1,
                Status = EventQueueProvisionResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueProvisionResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EventQueueProvisionResponseData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventQueueProvisionResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueProvisionResponseDataRegion.UsEast1,
                Status = EventQueueProvisionResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventQueueProvisionResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueProvisionResponseDataRegion.UsEast1,
                Status = EventQueueProvisionResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        EventQueueProvisionResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventQueueProvisionResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, EventQueueProvisionResponseDataRegion> expectedRegion =
            EventQueueProvisionResponseDataRegion.UsEast1;
        ApiEnum<string, EventQueueProvisionResponseDataStatus> expectedStatus =
            EventQueueProvisionResponseDataStatus.Provisioning;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueUrl = "queueUrl";
        string expectedRoleArn = "roleArn";
        string expectedSuffix = "suffix";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedQueueName, model.QueueName);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedQueueUrl, model.QueueUrl);
        Assert.Equal(expectedRoleArn, model.RoleArn);
        Assert.Equal(expectedSuffix, model.Suffix);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueProvisionResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueProvisionResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, EventQueueProvisionResponseDataRegion> expectedRegion =
            EventQueueProvisionResponseDataRegion.UsEast1;
        ApiEnum<string, EventQueueProvisionResponseDataStatus> expectedStatus =
            EventQueueProvisionResponseDataStatus.Provisioning;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueUrl = "queueUrl";
        string expectedRoleArn = "roleArn";
        string expectedSuffix = "suffix";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedQueueName, deserialized.QueueName);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedQueueUrl, deserialized.QueueUrl);
        Assert.Equal(expectedRoleArn, deserialized.RoleArn);
        Assert.Equal(expectedSuffix, deserialized.Suffix);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.QueueUrl);
        Assert.False(model.RawData.ContainsKey("queueUrl"));
        Assert.Null(model.RoleArn);
        Assert.False(model.RawData.ContainsKey("roleArn"));
        Assert.Null(model.Suffix);
        Assert.False(model.RawData.ContainsKey("suffix"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            QueueUrl = null,
            RoleArn = null,
            Suffix = null,
        };

        Assert.Null(model.QueueUrl);
        Assert.True(model.RawData.ContainsKey("queueUrl"));
        Assert.Null(model.RoleArn);
        Assert.True(model.RawData.ContainsKey("roleArn"));
        Assert.Null(model.Suffix);
        Assert.True(model.RawData.ContainsKey("suffix"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            QueueUrl = null,
            RoleArn = null,
            Suffix = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventQueueProvisionResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueProvisionResponseDataRegion.UsEast1,
            Status = EventQueueProvisionResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        EventQueueProvisionResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventQueueProvisionResponseDataRegionTest : TestBase
{
    [Theory]
    [InlineData(EventQueueProvisionResponseDataRegion.UsEast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.UsEast2)]
    [InlineData(EventQueueProvisionResponseDataRegion.UsWest1)]
    [InlineData(EventQueueProvisionResponseDataRegion.UsWest2)]
    [InlineData(EventQueueProvisionResponseDataRegion.CaCentral1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuWest1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuWest2)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuWest3)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuCentral1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuCentral2)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuNorth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuSouth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuSouth2)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSoutheast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSoutheast2)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSoutheast3)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApNortheast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApNortheast2)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApNortheast3)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSouth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSouth2)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApEast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.SaEast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.AfSouth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.MeSouth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.MeCentral1)]
    [InlineData(EventQueueProvisionResponseDataRegion.IlCentral1)]
    public void Validation_Works(EventQueueProvisionResponseDataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueProvisionResponseDataRegion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionResponseDataRegion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueProvisionResponseDataRegion.UsEast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.UsEast2)]
    [InlineData(EventQueueProvisionResponseDataRegion.UsWest1)]
    [InlineData(EventQueueProvisionResponseDataRegion.UsWest2)]
    [InlineData(EventQueueProvisionResponseDataRegion.CaCentral1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuWest1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuWest2)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuWest3)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuCentral1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuCentral2)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuNorth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuSouth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.EuSouth2)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSoutheast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSoutheast2)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSoutheast3)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApNortheast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApNortheast2)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApNortheast3)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSouth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApSouth2)]
    [InlineData(EventQueueProvisionResponseDataRegion.ApEast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.SaEast1)]
    [InlineData(EventQueueProvisionResponseDataRegion.AfSouth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.MeSouth1)]
    [InlineData(EventQueueProvisionResponseDataRegion.MeCentral1)]
    [InlineData(EventQueueProvisionResponseDataRegion.IlCentral1)]
    public void SerializationRoundtrip_Works(EventQueueProvisionResponseDataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueProvisionResponseDataRegion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionResponseDataRegion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionResponseDataRegion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionResponseDataRegion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EventQueueProvisionResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(EventQueueProvisionResponseDataStatus.Provisioning)]
    [InlineData(EventQueueProvisionResponseDataStatus.Active)]
    [InlineData(EventQueueProvisionResponseDataStatus.Failed)]
    [InlineData(EventQueueProvisionResponseDataStatus.Deprovisioning)]
    public void Validation_Works(EventQueueProvisionResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueProvisionResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueProvisionResponseDataStatus.Provisioning)]
    [InlineData(EventQueueProvisionResponseDataStatus.Active)]
    [InlineData(EventQueueProvisionResponseDataStatus.Failed)]
    [InlineData(EventQueueProvisionResponseDataStatus.Deprovisioning)]
    public void SerializationRoundtrip_Works(EventQueueProvisionResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueProvisionResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
