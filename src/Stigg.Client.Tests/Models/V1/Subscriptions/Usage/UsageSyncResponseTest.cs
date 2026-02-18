using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions.Usage;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.Usage;

public class UsageSyncResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageSyncResponse { Data = new(true) };

        UsageSyncResponseData expectedData = new(true);

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageSyncResponse { Data = new(true) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageSyncResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageSyncResponse { Data = new(true) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageSyncResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        UsageSyncResponseData expectedData = new(true);

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageSyncResponse { Data = new(true) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageSyncResponse { Data = new(true) };

        UsageSyncResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageSyncResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageSyncResponseData { Triggered = true };

        bool expectedTriggered = true;

        Assert.Equal(expectedTriggered, model.Triggered);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageSyncResponseData { Triggered = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageSyncResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageSyncResponseData { Triggered = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageSyncResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedTriggered = true;

        Assert.Equal(expectedTriggered, deserialized.Triggered);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageSyncResponseData { Triggered = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageSyncResponseData { Triggered = true };

        UsageSyncResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
