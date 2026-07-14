using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1Beta.Customers;

namespace Stigg.Client.Tests.Models.V1Beta.Customers;

public class CustomerRetrieveGovernanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerRetrieveGovernanceParams
        {
            ID = "id",
            After = "after",
            CurrencyIds = ["string"],
            EntityIDSearch = "x",
            EntityTypeIds = ["string"],
            FeatureIds = ["string"],
            Limit = 1,
            MinUtilization = 0,
            Order = Order.Asc,
            Scope = Scope.All,
            SortBy = SortBy.Utilization,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        string expectedAfter = "after";
        List<string> expectedCurrencyIds = ["string"];
        string expectedEntityIDSearch = "x";
        List<string> expectedEntityTypeIds = ["string"];
        List<string> expectedFeatureIds = ["string"];
        long expectedLimit = 1;
        double expectedMinUtilization = 0;
        ApiEnum<string, Order> expectedOrder = Order.Asc;
        ApiEnum<string, Scope> expectedScope = Scope.All;
        ApiEnum<string, SortBy> expectedSortBy = SortBy.Utilization;
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.NotNull(parameters.CurrencyIds);
        Assert.Equal(expectedCurrencyIds.Count, parameters.CurrencyIds.Count);
        for (int i = 0; i < expectedCurrencyIds.Count; i++)
        {
            Assert.Equal(expectedCurrencyIds[i], parameters.CurrencyIds[i]);
        }
        Assert.Equal(expectedEntityIDSearch, parameters.EntityIDSearch);
        Assert.NotNull(parameters.EntityTypeIds);
        Assert.Equal(expectedEntityTypeIds.Count, parameters.EntityTypeIds.Count);
        for (int i = 0; i < expectedEntityTypeIds.Count; i++)
        {
            Assert.Equal(expectedEntityTypeIds[i], parameters.EntityTypeIds[i]);
        }
        Assert.NotNull(parameters.FeatureIds);
        Assert.Equal(expectedFeatureIds.Count, parameters.FeatureIds.Count);
        for (int i = 0; i < expectedFeatureIds.Count; i++)
        {
            Assert.Equal(expectedFeatureIds[i], parameters.FeatureIds[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMinUtilization, parameters.MinUtilization);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedScope, parameters.Scope);
        Assert.Equal(expectedSortBy, parameters.SortBy);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerRetrieveGovernanceParams { ID = "id" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.CurrencyIds);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyIds"));
        Assert.Null(parameters.EntityIDSearch);
        Assert.False(parameters.RawQueryData.ContainsKey("entityIdSearch"));
        Assert.Null(parameters.EntityTypeIds);
        Assert.False(parameters.RawQueryData.ContainsKey("entityTypeIds"));
        Assert.Null(parameters.FeatureIds);
        Assert.False(parameters.RawQueryData.ContainsKey("featureIds"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MinUtilization);
        Assert.False(parameters.RawQueryData.ContainsKey("minUtilization"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
        Assert.Null(parameters.SortBy);
        Assert.False(parameters.RawQueryData.ContainsKey("sortBy"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerRetrieveGovernanceParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            After = null,
            CurrencyIds = null,
            EntityIDSearch = null,
            EntityTypeIds = null,
            FeatureIds = null,
            Limit = null,
            MinUtilization = null,
            Order = null,
            Scope = null,
            SortBy = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.CurrencyIds);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyIds"));
        Assert.Null(parameters.EntityIDSearch);
        Assert.False(parameters.RawQueryData.ContainsKey("entityIdSearch"));
        Assert.Null(parameters.EntityTypeIds);
        Assert.False(parameters.RawQueryData.ContainsKey("entityTypeIds"));
        Assert.Null(parameters.FeatureIds);
        Assert.False(parameters.RawQueryData.ContainsKey("featureIds"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.MinUtilization);
        Assert.False(parameters.RawQueryData.ContainsKey("minUtilization"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawQueryData.ContainsKey("order"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
        Assert.Null(parameters.SortBy);
        Assert.False(parameters.RawQueryData.ContainsKey("sortBy"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerRetrieveGovernanceParams parameters = new()
        {
            ID = "id",
            After = "after",
            CurrencyIds = ["string"],
            EntityIDSearch = "x",
            EntityTypeIds = ["string"],
            FeatureIds = ["string"],
            Limit = 1,
            MinUtilization = 0,
            Order = Order.Asc,
            Scope = Scope.All,
            SortBy = SortBy.Utilization,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://edge.api.stigg.io/api/v1-beta/customers/id/governance?after=after&currencyIds=string&entityIdSearch=x&entityTypeIds=string&featureIds=string&limit=1&minUtilization=0&order=asc&scope=all&sortBy=utilization"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomerRetrieveGovernanceParams parameters = new()
        {
            ID = "id",
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
        var parameters = new CustomerRetrieveGovernanceParams
        {
            ID = "id",
            After = "after",
            CurrencyIds = ["string"],
            EntityIDSearch = "x",
            EntityTypeIds = ["string"],
            FeatureIds = ["string"],
            Limit = 1,
            MinUtilization = 0,
            Order = Order.Asc,
            Scope = Scope.All,
            SortBy = SortBy.Utilization,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CustomerRetrieveGovernanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class OrderTest : TestBase
{
    [Theory]
    [InlineData(Order.Asc)]
    [InlineData(Order.Desc)]
    public void Validation_Works(Order rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Order> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Order.Asc)]
    [InlineData(Order.Desc)]
    public void SerializationRoundtrip_Works(Order rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Order> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Order>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ScopeTest : TestBase
{
    [Theory]
    [InlineData(Scope.All)]
    [InlineData(Scope.NodeWide)]
    [InlineData(Scope.Scoped)]
    public void Validation_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Scope.All)]
    [InlineData(Scope.NodeWide)]
    [InlineData(Scope.Scoped)]
    public void SerializationRoundtrip_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SortByTest : TestBase
{
    [Theory]
    [InlineData(SortBy.Utilization)]
    [InlineData(SortBy.CurrentUsage)]
    [InlineData(SortBy.UsageLimit)]
    [InlineData(SortBy.ScopeSize)]
    [InlineData(SortBy.ID)]
    [InlineData(SortBy.CreatedAt)]
    public void Validation_Works(SortBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortBy.Utilization)]
    [InlineData(SortBy.CurrentUsage)]
    [InlineData(SortBy.UsageLimit)]
    [InlineData(SortBy.ScopeSize)]
    [InlineData(SortBy.ID)]
    [InlineData(SortBy.CreatedAt)]
    public void SerializationRoundtrip_Works(SortBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
