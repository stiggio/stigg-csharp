using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = DataRegion.UsEast1,
                Status = Status.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        Data expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
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
        var model = new EventQueueResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = DataRegion.UsEast1,
                Status = Status.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = DataRegion.UsEast1,
                Status = Status.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
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
        var model = new EventQueueResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = DataRegion.UsEast1,
                Status = Status.Provisioning,
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
        var model = new EventQueueResponse
        {
            Data = new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = DataRegion.UsEast1,
                Status = Status.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        };

        EventQueueResponse copied = new(model);

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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, DataRegion> expectedRegion = DataRegion.UsEast1;
        ApiEnum<string, Status> expectedStatus = Status.Provisioning;
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
        var model = new Data
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, DataRegion> expectedRegion = DataRegion.UsEast1;
        ApiEnum<string, Status> expectedStatus = Status.Provisioning;
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
        var model = new Data
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
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
        var model = new Data
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
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
        var model = new Data
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
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
        var model = new Data
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
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
        var model = new Data
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = DataRegion.UsEast1,
            Status = Status.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataRegionTest : TestBase
{
    [Theory]
    [InlineData(DataRegion.UsEast1)]
    [InlineData(DataRegion.UsEast2)]
    [InlineData(DataRegion.UsWest1)]
    [InlineData(DataRegion.UsWest2)]
    [InlineData(DataRegion.CaCentral1)]
    [InlineData(DataRegion.EuWest1)]
    [InlineData(DataRegion.EuWest2)]
    [InlineData(DataRegion.EuWest3)]
    [InlineData(DataRegion.EuCentral1)]
    [InlineData(DataRegion.EuCentral2)]
    [InlineData(DataRegion.EuNorth1)]
    [InlineData(DataRegion.EuSouth1)]
    [InlineData(DataRegion.EuSouth2)]
    [InlineData(DataRegion.ApSoutheast1)]
    [InlineData(DataRegion.ApSoutheast2)]
    [InlineData(DataRegion.ApSoutheast3)]
    [InlineData(DataRegion.ApNortheast1)]
    [InlineData(DataRegion.ApNortheast2)]
    [InlineData(DataRegion.ApNortheast3)]
    [InlineData(DataRegion.ApSouth1)]
    [InlineData(DataRegion.ApSouth2)]
    [InlineData(DataRegion.ApEast1)]
    [InlineData(DataRegion.SaEast1)]
    [InlineData(DataRegion.AfSouth1)]
    [InlineData(DataRegion.MeSouth1)]
    [InlineData(DataRegion.MeCentral1)]
    [InlineData(DataRegion.IlCentral1)]
    public void Validation_Works(DataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataRegion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataRegion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataRegion.UsEast1)]
    [InlineData(DataRegion.UsEast2)]
    [InlineData(DataRegion.UsWest1)]
    [InlineData(DataRegion.UsWest2)]
    [InlineData(DataRegion.CaCentral1)]
    [InlineData(DataRegion.EuWest1)]
    [InlineData(DataRegion.EuWest2)]
    [InlineData(DataRegion.EuWest3)]
    [InlineData(DataRegion.EuCentral1)]
    [InlineData(DataRegion.EuCentral2)]
    [InlineData(DataRegion.EuNorth1)]
    [InlineData(DataRegion.EuSouth1)]
    [InlineData(DataRegion.EuSouth2)]
    [InlineData(DataRegion.ApSoutheast1)]
    [InlineData(DataRegion.ApSoutheast2)]
    [InlineData(DataRegion.ApSoutheast3)]
    [InlineData(DataRegion.ApNortheast1)]
    [InlineData(DataRegion.ApNortheast2)]
    [InlineData(DataRegion.ApNortheast3)]
    [InlineData(DataRegion.ApSouth1)]
    [InlineData(DataRegion.ApSouth2)]
    [InlineData(DataRegion.ApEast1)]
    [InlineData(DataRegion.SaEast1)]
    [InlineData(DataRegion.AfSouth1)]
    [InlineData(DataRegion.MeSouth1)]
    [InlineData(DataRegion.MeCentral1)]
    [InlineData(DataRegion.IlCentral1)]
    public void SerializationRoundtrip_Works(DataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataRegion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataRegion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataRegion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataRegion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Provisioning)]
    [InlineData(Status.Active)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Deprovisioning)]
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
    [InlineData(Status.Provisioning)]
    [InlineData(Status.Active)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Deprovisioning)]
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
