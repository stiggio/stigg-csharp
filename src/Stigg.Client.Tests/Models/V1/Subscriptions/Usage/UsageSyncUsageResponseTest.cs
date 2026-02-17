using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions.Usage;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.Usage;

public class UsageSyncUsageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageSyncUsageResponse { Data = new(true) };

        UsageSyncUsageResponseData expectedData = new(true);

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageSyncUsageResponse { Data = new(true) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageSyncUsageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageSyncUsageResponse { Data = new(true) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageSyncUsageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        UsageSyncUsageResponseData expectedData = new(true);

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageSyncUsageResponse { Data = new(true) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageSyncUsageResponse { Data = new(true) };

        UsageSyncUsageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageSyncUsageResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageSyncUsageResponseData { Triggered = true };

        bool expectedTriggered = true;

        Assert.Equal(expectedTriggered, model.Triggered);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageSyncUsageResponseData { Triggered = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageSyncUsageResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageSyncUsageResponseData { Triggered = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageSyncUsageResponseData>(
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
        var model = new UsageSyncUsageResponseData { Triggered = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageSyncUsageResponseData { Triggered = true };

        UsageSyncUsageResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
