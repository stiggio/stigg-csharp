using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events;

namespace Stigg.Client.Tests.Models.V1.Events;

public class EventReportResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventReportResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.True(JsonElement.DeepEquals(expectedData, model.Data));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventReportResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventReportResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventReportResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventReportResponse>(
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
        var model = new EventReportResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventReportResponse
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        EventReportResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
