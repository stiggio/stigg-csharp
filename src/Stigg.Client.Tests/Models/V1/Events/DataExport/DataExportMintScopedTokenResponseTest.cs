using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.DataExport;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport;

public class DataExportMintScopedTokenResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataExportMintScopedTokenResponse
        {
            Data = new()
            {
                Token = "token",
                ExpiresAt = "expiresAt",
                ProviderMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        Data expectedData = new()
        {
            Token = "token",
            ExpiresAt = "expiresAt",
            ProviderMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataExportMintScopedTokenResponse
        {
            Data = new()
            {
                Token = "token",
                ExpiresAt = "expiresAt",
                ProviderMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataExportMintScopedTokenResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataExportMintScopedTokenResponse
        {
            Data = new()
            {
                Token = "token",
                ExpiresAt = "expiresAt",
                ProviderMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataExportMintScopedTokenResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Token = "token",
            ExpiresAt = "expiresAt",
            ProviderMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataExportMintScopedTokenResponse
        {
            Data = new()
            {
                Token = "token",
                ExpiresAt = "expiresAt",
                ProviderMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataExportMintScopedTokenResponse
        {
            Data = new()
            {
                Token = "token",
                ExpiresAt = "expiresAt",
                ProviderMetadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        DataExportMintScopedTokenResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Token = "token",
            ExpiresAt = "expiresAt",
            ProviderMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedToken = "token";
        string expectedExpiresAt = "expiresAt";
        Dictionary<string, JsonElement> expectedProviderMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedProviderMetadata.Count, model.ProviderMetadata.Count);
        foreach (var item in expectedProviderMetadata)
        {
            Assert.True(model.ProviderMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ProviderMetadata[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Token = "token",
            ExpiresAt = "expiresAt",
            ProviderMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Token = "token",
            ExpiresAt = "expiresAt",
            ProviderMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        string expectedExpiresAt = "expiresAt";
        Dictionary<string, JsonElement> expectedProviderMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedProviderMetadata.Count, deserialized.ProviderMetadata.Count);
        foreach (var item in expectedProviderMetadata)
        {
            Assert.True(deserialized.ProviderMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ProviderMetadata[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Token = "token",
            ExpiresAt = "expiresAt",
            ProviderMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Token = "token",
            ExpiresAt = "expiresAt",
            ProviderMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
