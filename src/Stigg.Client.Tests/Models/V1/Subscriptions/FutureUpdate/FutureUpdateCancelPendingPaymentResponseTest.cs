using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions.FutureUpdate;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.FutureUpdate;

public class FutureUpdateCancelPendingPaymentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FutureUpdateCancelPendingPaymentResponse { Data = new("id") };

        Data expectedData = new("id");

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FutureUpdateCancelPendingPaymentResponse { Data = new("id") };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FutureUpdateCancelPendingPaymentResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FutureUpdateCancelPendingPaymentResponse { Data = new("id") };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FutureUpdateCancelPendingPaymentResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new("id");

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FutureUpdateCancelPendingPaymentResponse { Data = new("id") };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FutureUpdateCancelPendingPaymentResponse { Data = new("id") };

        FutureUpdateCancelPendingPaymentResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data { ID = "id" };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
