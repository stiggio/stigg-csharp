using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.CustomCurrencies;

namespace Stigg.Client.Tests.Models.V1.Credits.CustomCurrencies;

public class CustomCurrencyUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomCurrencyUpdateParams
        {
            CurrencyID = "currencyId",
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Symbol = "symbol",
            Units = new() { Plural = "plural", Singular = "singular" },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedCurrencyID = "currencyId";
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedSymbol = "symbol";
        CustomCurrencyUpdateParamsUnits expectedUnits = new()
        {
            Plural = "plural",
            Singular = "singular",
        };
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
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
        var parameters = new CustomCurrencyUpdateParams
        {
            CurrencyID = "currencyId",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Symbol = "symbol",
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
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
        var parameters = new CustomCurrencyUpdateParams
        {
            CurrencyID = "currencyId",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Symbol = "symbol",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            Units = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Units);
        Assert.False(parameters.RawBodyData.ContainsKey("units"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomCurrencyUpdateParams
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Units = new() { Plural = "plural", Singular = "singular" },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Symbol);
        Assert.False(parameters.RawBodyData.ContainsKey("symbol"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CustomCurrencyUpdateParams
        {
            CurrencyID = "currencyId",
            DisplayName = "displayName",
            Units = new() { Plural = "plural", Singular = "singular" },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            Description = null,
            Metadata = null,
            Symbol = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Symbol);
        Assert.True(parameters.RawBodyData.ContainsKey("symbol"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomCurrencyUpdateParams parameters = new() { CurrencyID = "currencyId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/credits/custom-currencies/currencyId"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomCurrencyUpdateParams parameters = new()
        {
            CurrencyID = "currencyId",
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
        var parameters = new CustomCurrencyUpdateParams
        {
            CurrencyID = "currencyId",
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Symbol = "symbol",
            Units = new() { Plural = "plural", Singular = "singular" },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CustomCurrencyUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CustomCurrencyUpdateParamsUnitsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomCurrencyUpdateParamsUnits
        {
            Plural = "plural",
            Singular = "singular",
        };

        string expectedPlural = "plural";
        string expectedSingular = "singular";

        Assert.Equal(expectedPlural, model.Plural);
        Assert.Equal(expectedSingular, model.Singular);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomCurrencyUpdateParamsUnits
        {
            Plural = "plural",
            Singular = "singular",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomCurrencyUpdateParamsUnits>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomCurrencyUpdateParamsUnits
        {
            Plural = "plural",
            Singular = "singular",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomCurrencyUpdateParamsUnits>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPlural = "plural";
        string expectedSingular = "singular";

        Assert.Equal(expectedPlural, deserialized.Plural);
        Assert.Equal(expectedSingular, deserialized.Singular);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomCurrencyUpdateParamsUnits
        {
            Plural = "plural",
            Singular = "singular",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomCurrencyUpdateParamsUnits
        {
            Plural = "plural",
            Singular = "singular",
        };

        CustomCurrencyUpdateParamsUnits copied = new(model);

        Assert.Equal(model, copied);
    }
}
