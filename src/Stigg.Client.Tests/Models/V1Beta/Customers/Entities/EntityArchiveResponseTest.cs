using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Customers.Entities;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Entities;

public class EntityArchiveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityArchiveResponse { Data = new(["string"]) };

        EntityArchiveResponseData expectedData = new(["string"]);

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityArchiveResponse { Data = new(["string"]) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityArchiveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityArchiveResponse { Data = new(["string"]) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityArchiveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EntityArchiveResponseData expectedData = new(["string"]);

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityArchiveResponse { Data = new(["string"]) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityArchiveResponse { Data = new(["string"]) };

        EntityArchiveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityArchiveResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityArchiveResponseData { Ids = ["string"] };

        List<string> expectedIds = ["string"];

        Assert.Equal(expectedIds.Count, model.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], model.Ids[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityArchiveResponseData { Ids = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityArchiveResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityArchiveResponseData { Ids = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityArchiveResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedIds = ["string"];

        Assert.Equal(expectedIds.Count, deserialized.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], deserialized.Ids[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityArchiveResponseData { Ids = ["string"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityArchiveResponseData { Ids = ["string"] };

        EntityArchiveResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
