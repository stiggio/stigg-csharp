using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Tests.Models.V1.Events.Plans;

public class PlanPublishResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        PlanPublishResponseData expectedData = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e");

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPublishResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPublishResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PlanPublishResponseData expectedData = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e");

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        PlanPublishResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanPublishResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanPublishResponseData { TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        string expectedTaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedTaskID, model.TaskID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanPublishResponseData { TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPublishResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanPublishResponseData { TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanPublishResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedTaskID, deserialized.TaskID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanPublishResponseData { TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanPublishResponseData { TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        PlanPublishResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
