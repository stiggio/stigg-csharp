using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueUpdateResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueUpdateResponseDataRegion.UsEast1,
                Status = EventQueueUpdateResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        EventQueueUpdateResponseData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
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
        var model = new EventQueueUpdateResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueUpdateResponseDataRegion.UsEast1,
                Status = EventQueueUpdateResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueUpdateResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueUpdateResponseDataRegion.UsEast1,
                Status = EventQueueUpdateResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EventQueueUpdateResponseData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
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
        var model = new EventQueueUpdateResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueUpdateResponseDataRegion.UsEast1,
                Status = EventQueueUpdateResponseDataStatus.Provisioning,
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
        var model = new EventQueueUpdateResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueUpdateResponseDataRegion.UsEast1,
                Status = EventQueueUpdateResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        EventQueueUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventQueueUpdateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, EventQueueUpdateResponseDataRegion> expectedRegion =
            EventQueueUpdateResponseDataRegion.UsEast1;
        ApiEnum<string, EventQueueUpdateResponseDataStatus> expectedStatus =
            EventQueueUpdateResponseDataStatus.Provisioning;
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
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueUpdateResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueUpdateResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, EventQueueUpdateResponseDataRegion> expectedRegion =
            EventQueueUpdateResponseDataRegion.UsEast1;
        ApiEnum<string, EventQueueUpdateResponseDataStatus> expectedStatus =
            EventQueueUpdateResponseDataStatus.Provisioning;
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
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
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
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
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
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
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
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
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
        var model = new EventQueueUpdateResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueUpdateResponseDataRegion.UsEast1,
            Status = EventQueueUpdateResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        EventQueueUpdateResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventQueueUpdateResponseDataRegionTest : TestBase
{
    [Theory]
    [InlineData(EventQueueUpdateResponseDataRegion.UsEast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.UsEast2)]
    [InlineData(EventQueueUpdateResponseDataRegion.UsWest1)]
    [InlineData(EventQueueUpdateResponseDataRegion.UsWest2)]
    [InlineData(EventQueueUpdateResponseDataRegion.CaCentral1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuWest1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuWest2)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuWest3)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuCentral1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuCentral2)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuNorth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuSouth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuSouth2)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSoutheast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSoutheast2)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSoutheast3)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApNortheast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApNortheast2)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApNortheast3)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSouth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSouth2)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApEast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.SaEast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.AfSouth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.MeSouth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.MeCentral1)]
    [InlineData(EventQueueUpdateResponseDataRegion.IlCentral1)]
    public void Validation_Works(EventQueueUpdateResponseDataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueUpdateResponseDataRegion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueUpdateResponseDataRegion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueUpdateResponseDataRegion.UsEast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.UsEast2)]
    [InlineData(EventQueueUpdateResponseDataRegion.UsWest1)]
    [InlineData(EventQueueUpdateResponseDataRegion.UsWest2)]
    [InlineData(EventQueueUpdateResponseDataRegion.CaCentral1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuWest1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuWest2)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuWest3)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuCentral1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuCentral2)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuNorth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuSouth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.EuSouth2)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSoutheast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSoutheast2)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSoutheast3)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApNortheast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApNortheast2)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApNortheast3)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSouth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApSouth2)]
    [InlineData(EventQueueUpdateResponseDataRegion.ApEast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.SaEast1)]
    [InlineData(EventQueueUpdateResponseDataRegion.AfSouth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.MeSouth1)]
    [InlineData(EventQueueUpdateResponseDataRegion.MeCentral1)]
    [InlineData(EventQueueUpdateResponseDataRegion.IlCentral1)]
    public void SerializationRoundtrip_Works(EventQueueUpdateResponseDataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueUpdateResponseDataRegion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueUpdateResponseDataRegion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueUpdateResponseDataRegion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueUpdateResponseDataRegion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EventQueueUpdateResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(EventQueueUpdateResponseDataStatus.Provisioning)]
    [InlineData(EventQueueUpdateResponseDataStatus.Active)]
    [InlineData(EventQueueUpdateResponseDataStatus.Failed)]
    [InlineData(EventQueueUpdateResponseDataStatus.Deprovisioning)]
    public void Validation_Works(EventQueueUpdateResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueUpdateResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueUpdateResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueUpdateResponseDataStatus.Provisioning)]
    [InlineData(EventQueueUpdateResponseDataStatus.Active)]
    [InlineData(EventQueueUpdateResponseDataStatus.Failed)]
    [InlineData(EventQueueUpdateResponseDataStatus.Deprovisioning)]
    public void SerializationRoundtrip_Works(EventQueueUpdateResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueUpdateResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueUpdateResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueUpdateResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueUpdateResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
