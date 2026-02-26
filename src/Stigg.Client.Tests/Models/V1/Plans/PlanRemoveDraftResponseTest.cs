using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanRemoveDraftResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanRemoveDraftResponse { Data = new("id") };

        PlanRemoveDraftResponseData expectedData = new("id");

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanRemoveDraftResponse { Data = new("id") };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRemoveDraftResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanRemoveDraftResponse { Data = new("id") };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRemoveDraftResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PlanRemoveDraftResponseData expectedData = new("id");

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanRemoveDraftResponse { Data = new("id") };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanRemoveDraftResponse { Data = new("id") };

        PlanRemoveDraftResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanRemoveDraftResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanRemoveDraftResponseData { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanRemoveDraftResponseData { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRemoveDraftResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanRemoveDraftResponseData { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRemoveDraftResponseData>(
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
        var model = new PlanRemoveDraftResponseData { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanRemoveDraftResponseData { ID = "id" };

        PlanRemoveDraftResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
