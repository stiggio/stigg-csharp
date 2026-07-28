using System;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerListInvoicesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerListInvoicesParams
        {
            ID = "id",
            After = "after",
            Before = "before",
            ContractExternalID = "contractExternalId",
            IssuedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IssuedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 1,
            OrderBy = OrderBy.IssueDate,
            OrderDir = OrderDir.Asc,
            StateIn = "stateIn",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        string expectedAfter = "after";
        string expectedBefore = "before";
        string expectedContractExternalID = "contractExternalId";
        DateTimeOffset expectedIssuedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedIssuedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedLimit = 1;
        ApiEnum<string, OrderBy> expectedOrderBy = OrderBy.IssueDate;
        ApiEnum<string, OrderDir> expectedOrderDir = OrderDir.Asc;
        string expectedStateIn = "stateIn";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedContractExternalID, parameters.ContractExternalID);
        Assert.Equal(expectedIssuedAfter, parameters.IssuedAfter);
        Assert.Equal(expectedIssuedBefore, parameters.IssuedBefore);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedOrderDir, parameters.OrderDir);
        Assert.Equal(expectedStateIn, parameters.StateIn);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerListInvoicesParams { ID = "id" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.ContractExternalID);
        Assert.False(parameters.RawQueryData.ContainsKey("contractExternalId"));
        Assert.Null(parameters.IssuedAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("issuedAfter"));
        Assert.Null(parameters.IssuedBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("issuedBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("orderBy"));
        Assert.Null(parameters.OrderDir);
        Assert.False(parameters.RawQueryData.ContainsKey("orderDir"));
        Assert.Null(parameters.StateIn);
        Assert.False(parameters.RawQueryData.ContainsKey("stateIn"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerListInvoicesParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            ContractExternalID = null,
            IssuedAfter = null,
            IssuedBefore = null,
            Limit = null,
            OrderBy = null,
            OrderDir = null,
            StateIn = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.ContractExternalID);
        Assert.False(parameters.RawQueryData.ContainsKey("contractExternalId"));
        Assert.Null(parameters.IssuedAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("issuedAfter"));
        Assert.Null(parameters.IssuedBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("issuedBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("orderBy"));
        Assert.Null(parameters.OrderDir);
        Assert.False(parameters.RawQueryData.ContainsKey("orderDir"));
        Assert.Null(parameters.StateIn);
        Assert.False(parameters.RawQueryData.ContainsKey("stateIn"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerListInvoicesParams parameters = new()
        {
            ID = "id",
            After = "after",
            Before = "before",
            ContractExternalID = "contractExternalId",
            IssuedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            IssuedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Limit = 1,
            OrderBy = OrderBy.IssueDate,
            OrderDir = OrderDir.Asc,
            StateIn = "stateIn",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/customers/id/invoices?after=after&before=before&contractExternalId=contractExternalId&issuedAfter=2019-12-27T18%3a11%3a19.117%2b00%3a00&issuedBefore=2019-12-27T18%3a11%3a19.117%2b00%3a00&limit=1&orderBy=issueDate&orderDir=ASC&stateIn=stateIn"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomerListInvoicesParams parameters = new()
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
        var parameters = new CustomerListInvoicesParams
        {
            ID = "id",
            After = "after",
            Before = "before",
            ContractExternalID = "contractExternalId",
            IssuedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IssuedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Limit = 1,
            OrderBy = OrderBy.IssueDate,
            OrderDir = OrderDir.Asc,
            StateIn = "stateIn",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CustomerListInvoicesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class OrderByTest : TestBase
{
    [Theory]
    [InlineData(OrderBy.IssueDate)]
    [InlineData(OrderBy.DueDate)]
    [InlineData(OrderBy.Total)]
    public void Validation_Works(OrderBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrderBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrderBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OrderBy.IssueDate)]
    [InlineData(OrderBy.DueDate)]
    [InlineData(OrderBy.Total)]
    public void SerializationRoundtrip_Works(OrderBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrderBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrderBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrderBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrderBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OrderDirTest : TestBase
{
    [Theory]
    [InlineData(OrderDir.Asc)]
    [InlineData(OrderDir.Desc)]
    public void Validation_Works(OrderDir rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrderDir> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrderDir>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OrderDir.Asc)]
    [InlineData(OrderDir.Desc)]
    public void SerializationRoundtrip_Works(OrderDir rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrderDir> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrderDir>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrderDir>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrderDir>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
