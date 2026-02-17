using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Addons.Draft;

namespace Stigg.Client.Tests.Models.V1.Events.Addons.Draft;

public class DraftRemoveAddonDraftResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DraftRemoveAddonDraftResponse { Data = new("id") };

        DraftRemoveAddonDraftResponseData expectedData = new("id");

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DraftRemoveAddonDraftResponse { Data = new("id") };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DraftRemoveAddonDraftResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DraftRemoveAddonDraftResponse { Data = new("id") };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DraftRemoveAddonDraftResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DraftRemoveAddonDraftResponseData expectedData = new("id");

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DraftRemoveAddonDraftResponse { Data = new("id") };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DraftRemoveAddonDraftResponse { Data = new("id") };

        DraftRemoveAddonDraftResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DraftRemoveAddonDraftResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DraftRemoveAddonDraftResponseData { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DraftRemoveAddonDraftResponseData { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DraftRemoveAddonDraftResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DraftRemoveAddonDraftResponseData { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DraftRemoveAddonDraftResponseData>(
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
        var model = new DraftRemoveAddonDraftResponseData { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DraftRemoveAddonDraftResponseData { ID = "id" };

        DraftRemoveAddonDraftResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
