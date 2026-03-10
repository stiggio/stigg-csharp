using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Models.V1.Events.Addons;

public class AddonPublishAddonResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonPublishAddonResponse
        {
            Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
        };

        AddonPublishAddonResponseData expectedData = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e");

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonPublishAddonResponse
        {
            Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPublishAddonResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonPublishAddonResponse
        {
            Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPublishAddonResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AddonPublishAddonResponseData expectedData = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e");

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonPublishAddonResponse
        {
            Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonPublishAddonResponse
        {
            Data = new("182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"),
        };

        AddonPublishAddonResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonPublishAddonResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonPublishAddonResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedTaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedTaskID, model.TaskID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonPublishAddonResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPublishAddonResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonPublishAddonResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonPublishAddonResponseData>(
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
        var model = new AddonPublishAddonResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonPublishAddonResponseData
        {
            TaskID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        AddonPublishAddonResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
