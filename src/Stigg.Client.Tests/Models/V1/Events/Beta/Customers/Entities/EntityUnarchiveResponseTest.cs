using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Beta.Customers.Entities;

namespace Stigg.Client.Tests.Models.V1.Events.Beta.Customers.Entities;

public class EntityUnarchiveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUnarchiveResponse { Data = new(["string"]) };

        EntityUnarchiveResponseData expectedData = new(["string"]);

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityUnarchiveResponse { Data = new(["string"]) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUnarchiveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUnarchiveResponse { Data = new(["string"]) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUnarchiveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EntityUnarchiveResponseData expectedData = new(["string"]);

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityUnarchiveResponse { Data = new(["string"]) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUnarchiveResponse { Data = new(["string"]) };

        EntityUnarchiveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityUnarchiveResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityUnarchiveResponseData { Ids = ["string"] };

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
        var model = new EntityUnarchiveResponseData { Ids = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUnarchiveResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityUnarchiveResponseData { Ids = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityUnarchiveResponseData>(
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
        var model = new EntityUnarchiveResponseData { Ids = ["string"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityUnarchiveResponseData { Ids = ["string"] };

        EntityUnarchiveResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
