using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Customers.Entities;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Entities;

public class EntityIdsRequestDtoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityIdsRequestDto { Ids = ["NxI"] };

        List<string> expectedIds = ["NxI"];

        Assert.Equal(expectedIds.Count, model.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], model.Ids[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityIdsRequestDto { Ids = ["NxI"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityIdsRequestDto>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityIdsRequestDto { Ids = ["NxI"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EntityIdsRequestDto>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedIds = ["NxI"];

        Assert.Equal(expectedIds.Count, deserialized.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], deserialized.Ids[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityIdsRequestDto { Ids = ["NxI"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityIdsRequestDto { Ids = ["NxI"] };

        EntityIdsRequestDto copied = new(model);

        Assert.Equal(model, copied);
    }
}
