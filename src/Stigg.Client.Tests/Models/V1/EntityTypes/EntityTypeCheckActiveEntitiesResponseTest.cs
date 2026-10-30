using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.EntityTypes;

namespace Stigg.Client.Tests.Models.V1.EntityTypes;

public class EntityTypeCheckActiveEntitiesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponse { Data = new(true) };

        EntityTypeCheckActiveEntitiesResponseData expectedData = new(true);

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponse { Data = new(true) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypeCheckActiveEntitiesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponse { Data = new(true) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypeCheckActiveEntitiesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EntityTypeCheckActiveEntitiesResponseData expectedData = new(true);

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponse { Data = new(true) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponse { Data = new(true) };

        EntityTypeCheckActiveEntitiesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityTypeCheckActiveEntitiesResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponseData { HasActiveEntities = true };

        bool expectedHasActiveEntities = true;

        Assert.Equal(expectedHasActiveEntities, model.HasActiveEntities);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponseData { HasActiveEntities = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypeCheckActiveEntitiesResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponseData { HasActiveEntities = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityTypeCheckActiveEntitiesResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasActiveEntities = true;

        Assert.Equal(expectedHasActiveEntities, deserialized.HasActiveEntities);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponseData { HasActiveEntities = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityTypeCheckActiveEntitiesResponseData { HasActiveEntities = true };

        EntityTypeCheckActiveEntitiesResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
