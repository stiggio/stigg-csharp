using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.CustomCurrencies;

namespace Stigg.Client.Tests.Models.V1.Credits.CustomCurrencies;

public class CustomCurrencyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomCurrencyCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Symbol = "symbol",
            Units = new() { Plural = "plural", Singular = "singular" },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedSymbol = "symbol";
        Units expectedUnits = new() { Plural = "plural", Singular = "singular" };
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedSymbol, parameters.Symbol);
        Assert.Equal(expectedUnits, parameters.Units);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomCurrencyCreateParams { ID = "id", DisplayName = "displayName" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Symbol);
        Assert.False(parameters.RawBodyData.ContainsKey("symbol"));
        Assert.Null(parameters.Units);
        Assert.False(parameters.RawBodyData.ContainsKey("units"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomCurrencyCreateParams
        {
            ID = "id",
            DisplayName = "displayName",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Metadata = null,
            Symbol = null,
            Units = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Symbol);
        Assert.False(parameters.RawBodyData.ContainsKey("symbol"));
        Assert.Null(parameters.Units);
        Assert.False(parameters.RawBodyData.ContainsKey("units"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomCurrencyCreateParams parameters = new() { ID = "id", DisplayName = "displayName" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://edge.api.stigg.io/api/v1/credits/custom-currencies"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomCurrencyCreateParams parameters = new()
        {
            ID = "id",
            DisplayName = "displayName",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["X-ACCOUNT-ID"], requestMessage.Headers.GetValues("X-ACCOUNT-ID"));
        Assert.Equal(["X-ENVIRONMENT-ID"], requestMessage.Headers.GetValues("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomCurrencyCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Symbol = "symbol",
            Units = new() { Plural = "plural", Singular = "singular" },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CustomCurrencyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UnitsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Units { Plural = "plural", Singular = "singular" };

        string expectedPlural = "plural";
        string expectedSingular = "singular";

        Assert.Equal(expectedPlural, model.Plural);
        Assert.Equal(expectedSingular, model.Singular);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Units { Plural = "plural", Singular = "singular" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Units>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Units { Plural = "plural", Singular = "singular" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Units>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedPlural = "plural";
        string expectedSingular = "singular";

        Assert.Equal(expectedPlural, deserialized.Plural);
        Assert.Equal(expectedSingular, deserialized.Singular);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Units { Plural = "plural", Singular = "singular" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Units { Plural = "plural", Singular = "singular" };

        Units copied = new(model);

        Assert.Equal(model, copied);
    }
}
