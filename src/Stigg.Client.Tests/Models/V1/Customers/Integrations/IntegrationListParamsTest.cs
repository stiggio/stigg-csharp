using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationListParams
        {
            ID = "x",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            VendorIdentifier = [VendorIdentifier.Auth0],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedLimit = 1;
        List<ApiEnum<string, VendorIdentifier>> expectedVendorIdentifier = [VendorIdentifier.Auth0];
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.NotNull(parameters.VendorIdentifier);
        Assert.Equal(expectedVendorIdentifier.Count, parameters.VendorIdentifier.Count);
        for (int i = 0; i < expectedVendorIdentifier.Count; i++)
        {
            Assert.Equal(expectedVendorIdentifier[i], parameters.VendorIdentifier[i]);
        }
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntegrationListParams { ID = "x" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.VendorIdentifier);
        Assert.False(parameters.RawQueryData.ContainsKey("vendorIdentifier"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IntegrationListParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            Limit = null,
            VendorIdentifier = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.VendorIdentifier);
        Assert.False(parameters.RawQueryData.ContainsKey("vendorIdentifier"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationListParams parameters = new()
        {
            ID = "x",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            VendorIdentifier = [VendorIdentifier.Auth0],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/customers/x/integrations?after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&limit=1&vendorIdentifier=AUTH0"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        IntegrationListParams parameters = new()
        {
            ID = "x",
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
        var parameters = new IntegrationListParams
        {
            ID = "x",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            VendorIdentifier = [VendorIdentifier.Auth0],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        IntegrationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class VendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(VendorIdentifier.Auth0)]
    [InlineData(VendorIdentifier.Zuora)]
    [InlineData(VendorIdentifier.Stripe)]
    [InlineData(VendorIdentifier.Hubspot)]
    [InlineData(VendorIdentifier.AwsMarketplace)]
    [InlineData(VendorIdentifier.Snowflake)]
    [InlineData(VendorIdentifier.Salesforce)]
    [InlineData(VendorIdentifier.BigQuery)]
    [InlineData(VendorIdentifier.OpenFga)]
    [InlineData(VendorIdentifier.AppStore)]
    [InlineData(VendorIdentifier.Received)]
    [InlineData(VendorIdentifier.Prequel)]
    public void Validation_Works(VendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VendorIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VendorIdentifier.Auth0)]
    [InlineData(VendorIdentifier.Zuora)]
    [InlineData(VendorIdentifier.Stripe)]
    [InlineData(VendorIdentifier.Hubspot)]
    [InlineData(VendorIdentifier.AwsMarketplace)]
    [InlineData(VendorIdentifier.Snowflake)]
    [InlineData(VendorIdentifier.Salesforce)]
    [InlineData(VendorIdentifier.BigQuery)]
    [InlineData(VendorIdentifier.OpenFga)]
    [InlineData(VendorIdentifier.AppStore)]
    [InlineData(VendorIdentifier.Received)]
    [InlineData(VendorIdentifier.Prequel)]
    public void SerializationRoundtrip_Works(VendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VendorIdentifier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VendorIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VendorIdentifier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
