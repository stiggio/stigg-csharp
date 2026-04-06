using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueDeleteResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueDeleteResponseDataRegion.UsEast1,
                Status = EventQueueDeleteResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        EventQueueDeleteResponseData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
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
        var model = new EventQueueDeleteResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueDeleteResponseDataRegion.UsEast1,
                Status = EventQueueDeleteResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueDeleteResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueDeleteResponseDataRegion.UsEast1,
                Status = EventQueueDeleteResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EventQueueDeleteResponseData expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
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
        var model = new EventQueueDeleteResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueDeleteResponseDataRegion.UsEast1,
                Status = EventQueueDeleteResponseDataStatus.Provisioning,
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
        var model = new EventQueueDeleteResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueDeleteResponseDataRegion.UsEast1,
                Status = EventQueueDeleteResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        EventQueueDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventQueueDeleteResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, EventQueueDeleteResponseDataRegion> expectedRegion =
            EventQueueDeleteResponseDataRegion.UsEast1;
        ApiEnum<string, EventQueueDeleteResponseDataStatus> expectedStatus =
            EventQueueDeleteResponseDataStatus.Provisioning;
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
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueDeleteResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueDeleteResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, EventQueueDeleteResponseDataRegion> expectedRegion =
            EventQueueDeleteResponseDataRegion.UsEast1;
        ApiEnum<string, EventQueueDeleteResponseDataStatus> expectedStatus =
            EventQueueDeleteResponseDataStatus.Provisioning;
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
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
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
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
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
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
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
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
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
        var model = new EventQueueDeleteResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueDeleteResponseDataRegion.UsEast1,
            Status = EventQueueDeleteResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        EventQueueDeleteResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventQueueDeleteResponseDataRegionTest : TestBase
{
    [Theory]
    [InlineData(EventQueueDeleteResponseDataRegion.UsEast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.UsEast2)]
    [InlineData(EventQueueDeleteResponseDataRegion.UsWest1)]
    [InlineData(EventQueueDeleteResponseDataRegion.UsWest2)]
    [InlineData(EventQueueDeleteResponseDataRegion.CaCentral1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuWest1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuWest2)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuWest3)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuCentral1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuCentral2)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuNorth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuSouth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuSouth2)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSoutheast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSoutheast2)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSoutheast3)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApNortheast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApNortheast2)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApNortheast3)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSouth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSouth2)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApEast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.SaEast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.AfSouth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.MeSouth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.MeCentral1)]
    [InlineData(EventQueueDeleteResponseDataRegion.IlCentral1)]
    public void Validation_Works(EventQueueDeleteResponseDataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueDeleteResponseDataRegion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueDeleteResponseDataRegion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueDeleteResponseDataRegion.UsEast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.UsEast2)]
    [InlineData(EventQueueDeleteResponseDataRegion.UsWest1)]
    [InlineData(EventQueueDeleteResponseDataRegion.UsWest2)]
    [InlineData(EventQueueDeleteResponseDataRegion.CaCentral1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuWest1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuWest2)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuWest3)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuCentral1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuCentral2)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuNorth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuSouth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.EuSouth2)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSoutheast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSoutheast2)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSoutheast3)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApNortheast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApNortheast2)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApNortheast3)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSouth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApSouth2)]
    [InlineData(EventQueueDeleteResponseDataRegion.ApEast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.SaEast1)]
    [InlineData(EventQueueDeleteResponseDataRegion.AfSouth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.MeSouth1)]
    [InlineData(EventQueueDeleteResponseDataRegion.MeCentral1)]
    [InlineData(EventQueueDeleteResponseDataRegion.IlCentral1)]
    public void SerializationRoundtrip_Works(EventQueueDeleteResponseDataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueDeleteResponseDataRegion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueDeleteResponseDataRegion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueDeleteResponseDataRegion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueDeleteResponseDataRegion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EventQueueDeleteResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(EventQueueDeleteResponseDataStatus.Provisioning)]
    [InlineData(EventQueueDeleteResponseDataStatus.Active)]
    [InlineData(EventQueueDeleteResponseDataStatus.Failed)]
    [InlineData(EventQueueDeleteResponseDataStatus.Deprovisioning)]
    public void Validation_Works(EventQueueDeleteResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueDeleteResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueDeleteResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueDeleteResponseDataStatus.Provisioning)]
    [InlineData(EventQueueDeleteResponseDataStatus.Active)]
    [InlineData(EventQueueDeleteResponseDataStatus.Failed)]
    [InlineData(EventQueueDeleteResponseDataStatus.Deprovisioning)]
    public void SerializationRoundtrip_Works(EventQueueDeleteResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueDeleteResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueDeleteResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueDeleteResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueDeleteResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
