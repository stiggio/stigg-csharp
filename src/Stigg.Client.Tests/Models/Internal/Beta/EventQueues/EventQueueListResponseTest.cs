using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueListResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueName = "queueName",
                    Region = EventQueueListResponseDataRegion.UsEast1,
                    Status = EventQueueListResponseDataStatus.Provisioning,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueUrl = "queueUrl",
                    RoleArn = "roleArn",
                    Suffix = "suffix",
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        List<EventQueueListResponseData> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueListResponseDataRegion.UsEast1,
                Status = EventQueueListResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventQueueListResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueName = "queueName",
                    Region = EventQueueListResponseDataRegion.UsEast1,
                    Status = EventQueueListResponseDataStatus.Provisioning,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueUrl = "queueUrl",
                    RoleArn = "roleArn",
                    Suffix = "suffix",
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueListResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueName = "queueName",
                    Region = EventQueueListResponseDataRegion.UsEast1,
                    Status = EventQueueListResponseDataStatus.Provisioning,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueUrl = "queueUrl",
                    RoleArn = "roleArn",
                    Suffix = "suffix",
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EventQueueListResponseData> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueName = "queueName",
                Region = EventQueueListResponseDataRegion.UsEast1,
                Status = EventQueueListResponseDataStatus.Provisioning,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                QueueUrl = "queueUrl",
                RoleArn = "roleArn",
                Suffix = "suffix",
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventQueueListResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueName = "queueName",
                    Region = EventQueueListResponseDataRegion.UsEast1,
                    Status = EventQueueListResponseDataStatus.Provisioning,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueUrl = "queueUrl",
                    RoleArn = "roleArn",
                    Suffix = "suffix",
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventQueueListResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueName = "queueName",
                    Region = EventQueueListResponseDataRegion.UsEast1,
                    Status = EventQueueListResponseDataStatus.Provisioning,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    QueueUrl = "queueUrl",
                    RoleArn = "roleArn",
                    Suffix = "suffix",
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        EventQueueListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventQueueListResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, EventQueueListResponseDataRegion> expectedRegion =
            EventQueueListResponseDataRegion.UsEast1;
        ApiEnum<string, EventQueueListResponseDataStatus> expectedStatus =
            EventQueueListResponseDataStatus.Provisioning;
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
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueListResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventQueueListResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedQueueName = "queueName";
        ApiEnum<string, EventQueueListResponseDataRegion> expectedRegion =
            EventQueueListResponseDataRegion.UsEast1;
        ApiEnum<string, EventQueueListResponseDataStatus> expectedStatus =
            EventQueueListResponseDataStatus.Provisioning;
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
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
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
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
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
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
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
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
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
        var model = new EventQueueListResponseData
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueName = "queueName",
            Region = EventQueueListResponseDataRegion.UsEast1,
            Status = EventQueueListResponseDataStatus.Provisioning,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            QueueUrl = "queueUrl",
            RoleArn = "roleArn",
            Suffix = "suffix",
        };

        EventQueueListResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventQueueListResponseDataRegionTest : TestBase
{
    [Theory]
    [InlineData(EventQueueListResponseDataRegion.UsEast1)]
    [InlineData(EventQueueListResponseDataRegion.UsEast2)]
    [InlineData(EventQueueListResponseDataRegion.UsWest1)]
    [InlineData(EventQueueListResponseDataRegion.UsWest2)]
    [InlineData(EventQueueListResponseDataRegion.CaCentral1)]
    [InlineData(EventQueueListResponseDataRegion.EuWest1)]
    [InlineData(EventQueueListResponseDataRegion.EuWest2)]
    [InlineData(EventQueueListResponseDataRegion.EuWest3)]
    [InlineData(EventQueueListResponseDataRegion.EuCentral1)]
    [InlineData(EventQueueListResponseDataRegion.EuCentral2)]
    [InlineData(EventQueueListResponseDataRegion.EuNorth1)]
    [InlineData(EventQueueListResponseDataRegion.EuSouth1)]
    [InlineData(EventQueueListResponseDataRegion.EuSouth2)]
    [InlineData(EventQueueListResponseDataRegion.ApSoutheast1)]
    [InlineData(EventQueueListResponseDataRegion.ApSoutheast2)]
    [InlineData(EventQueueListResponseDataRegion.ApSoutheast3)]
    [InlineData(EventQueueListResponseDataRegion.ApNortheast1)]
    [InlineData(EventQueueListResponseDataRegion.ApNortheast2)]
    [InlineData(EventQueueListResponseDataRegion.ApNortheast3)]
    [InlineData(EventQueueListResponseDataRegion.ApSouth1)]
    [InlineData(EventQueueListResponseDataRegion.ApSouth2)]
    [InlineData(EventQueueListResponseDataRegion.ApEast1)]
    [InlineData(EventQueueListResponseDataRegion.SaEast1)]
    [InlineData(EventQueueListResponseDataRegion.AfSouth1)]
    [InlineData(EventQueueListResponseDataRegion.MeSouth1)]
    [InlineData(EventQueueListResponseDataRegion.MeCentral1)]
    [InlineData(EventQueueListResponseDataRegion.IlCentral1)]
    public void Validation_Works(EventQueueListResponseDataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueListResponseDataRegion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueListResponseDataRegion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueListResponseDataRegion.UsEast1)]
    [InlineData(EventQueueListResponseDataRegion.UsEast2)]
    [InlineData(EventQueueListResponseDataRegion.UsWest1)]
    [InlineData(EventQueueListResponseDataRegion.UsWest2)]
    [InlineData(EventQueueListResponseDataRegion.CaCentral1)]
    [InlineData(EventQueueListResponseDataRegion.EuWest1)]
    [InlineData(EventQueueListResponseDataRegion.EuWest2)]
    [InlineData(EventQueueListResponseDataRegion.EuWest3)]
    [InlineData(EventQueueListResponseDataRegion.EuCentral1)]
    [InlineData(EventQueueListResponseDataRegion.EuCentral2)]
    [InlineData(EventQueueListResponseDataRegion.EuNorth1)]
    [InlineData(EventQueueListResponseDataRegion.EuSouth1)]
    [InlineData(EventQueueListResponseDataRegion.EuSouth2)]
    [InlineData(EventQueueListResponseDataRegion.ApSoutheast1)]
    [InlineData(EventQueueListResponseDataRegion.ApSoutheast2)]
    [InlineData(EventQueueListResponseDataRegion.ApSoutheast3)]
    [InlineData(EventQueueListResponseDataRegion.ApNortheast1)]
    [InlineData(EventQueueListResponseDataRegion.ApNortheast2)]
    [InlineData(EventQueueListResponseDataRegion.ApNortheast3)]
    [InlineData(EventQueueListResponseDataRegion.ApSouth1)]
    [InlineData(EventQueueListResponseDataRegion.ApSouth2)]
    [InlineData(EventQueueListResponseDataRegion.ApEast1)]
    [InlineData(EventQueueListResponseDataRegion.SaEast1)]
    [InlineData(EventQueueListResponseDataRegion.AfSouth1)]
    [InlineData(EventQueueListResponseDataRegion.MeSouth1)]
    [InlineData(EventQueueListResponseDataRegion.MeCentral1)]
    [InlineData(EventQueueListResponseDataRegion.IlCentral1)]
    public void SerializationRoundtrip_Works(EventQueueListResponseDataRegion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueListResponseDataRegion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueListResponseDataRegion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueListResponseDataRegion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueListResponseDataRegion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EventQueueListResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(EventQueueListResponseDataStatus.Provisioning)]
    [InlineData(EventQueueListResponseDataStatus.Active)]
    [InlineData(EventQueueListResponseDataStatus.Failed)]
    [InlineData(EventQueueListResponseDataStatus.Deprovisioning)]
    public void Validation_Works(EventQueueListResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueListResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueListResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueListResponseDataStatus.Provisioning)]
    [InlineData(EventQueueListResponseDataStatus.Active)]
    [InlineData(EventQueueListResponseDataStatus.Failed)]
    [InlineData(EventQueueListResponseDataStatus.Deprovisioning)]
    public void SerializationRoundtrip_Works(EventQueueListResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueListResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueListResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueListResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueListResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
