using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Credits.CustomCurrencies;

namespace Stigg.Client.Tests.Models.V1.Events.Credits.CustomCurrencies;

public class CustomCurrencyListAssociatedEntitiesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Type = "type",
                },
            ],
        };

        List<CustomCurrencyListAssociatedEntitiesResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                Type = "type",
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Type = "type",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomCurrencyListAssociatedEntitiesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Type = "type",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomCurrencyListAssociatedEntitiesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CustomCurrencyListAssociatedEntitiesResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                Type = "type",
            },
        ];

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Type = "type",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Type = "type",
                },
            ],
        };

        CustomCurrencyListAssociatedEntitiesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomCurrencyListAssociatedEntitiesResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponseData
        {
            ID = "id",
            DisplayName = "displayName",
            Type = "type",
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponseData
        {
            ID = "id",
            DisplayName = "displayName",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomCurrencyListAssociatedEntitiesResponseData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponseData
        {
            ID = "id",
            DisplayName = "displayName",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CustomCurrencyListAssociatedEntitiesResponseData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponseData
        {
            ID = "id",
            DisplayName = "displayName",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomCurrencyListAssociatedEntitiesResponseData
        {
            ID = "id",
            DisplayName = "displayName",
            Type = "type",
        };

        CustomCurrencyListAssociatedEntitiesResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
