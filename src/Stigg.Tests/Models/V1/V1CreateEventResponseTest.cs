using System.Text.Json;
using Stigg.Core;
using Stigg.Models.V1;

namespace Stigg.Tests.Models.V1;

public class V1CreateEventResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V1CreateEventResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.True(JsonElement.DeepEquals(expectedData, model.Data));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V1CreateEventResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1CreateEventResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V1CreateEventResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V1CreateEventResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V1CreateEventResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V1CreateEventResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        V1CreateEventResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
