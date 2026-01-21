using System.Text.Json;
using Stigg.Core;
using Stigg.Models.V1.Subscriptions.FutureUpdate;

namespace Stigg.Tests.Models.V1.Subscriptions.FutureUpdate;

public class FutureUpdateCancelScheduleResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FutureUpdateCancelScheduleResponse { Data = new("id") };

        FutureUpdateCancelScheduleResponseData expectedData = new("id");

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FutureUpdateCancelScheduleResponse { Data = new("id") };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FutureUpdateCancelScheduleResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FutureUpdateCancelScheduleResponse { Data = new("id") };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FutureUpdateCancelScheduleResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FutureUpdateCancelScheduleResponseData expectedData = new("id");

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FutureUpdateCancelScheduleResponse { Data = new("id") };

        model.Validate();
    }
}

public class FutureUpdateCancelScheduleResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FutureUpdateCancelScheduleResponseData { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FutureUpdateCancelScheduleResponseData { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FutureUpdateCancelScheduleResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FutureUpdateCancelScheduleResponseData { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FutureUpdateCancelScheduleResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FutureUpdateCancelScheduleResponseData { ID = "id" };

        model.Validate();
    }
}
