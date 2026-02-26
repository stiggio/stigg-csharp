using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class AddonPublishResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        AddonPublishResponseData expectedData = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e");

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPublishResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPublishResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AddonPublishResponseData expectedData = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e");

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonPublishResponse { Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e") };

        AddonPublishResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonPublishResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonPublishResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedTaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedTaskID, model.TaskID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonPublishResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPublishResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonPublishResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPublishResponseData>(
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
        var model = new AddonPublishResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonPublishResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        AddonPublishResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
