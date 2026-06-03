using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1Beta.Customers.Assignments;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Assignments;

public class AssignmentListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AssignmentListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = AssignmentListResponseCadence.Month,
            CapabilityID = "capabilityId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AssignmentListResponseCadence> expectedCadence =
            AssignmentListResponseCadence.Month;
        string expectedCapabilityID = "capabilityId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityId";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedCapabilityID, model.CapabilityID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AssignmentListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = AssignmentListResponseCadence.Month,
            CapabilityID = "capabilityId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssignmentListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AssignmentListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = AssignmentListResponseCadence.Month,
            CapabilityID = "capabilityId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssignmentListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AssignmentListResponseCadence> expectedCadence =
            AssignmentListResponseCadence.Month;
        string expectedCapabilityID = "capabilityId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEntityID = "entityId";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedCapabilityID, deserialized.CapabilityID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AssignmentListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = AssignmentListResponseCadence.Month,
            CapabilityID = "capabilityId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AssignmentListResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Cadence = AssignmentListResponseCadence.Month,
            CapabilityID = "capabilityId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EntityID = "entityId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        AssignmentListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AssignmentListResponseCadenceTest : TestBase
{
    [Theory]
    [InlineData(AssignmentListResponseCadence.Month)]
    public void Validation_Works(AssignmentListResponseCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AssignmentListResponseCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AssignmentListResponseCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AssignmentListResponseCadence.Month)]
    public void SerializationRoundtrip_Works(AssignmentListResponseCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AssignmentListResponseCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AssignmentListResponseCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AssignmentListResponseCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AssignmentListResponseCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
