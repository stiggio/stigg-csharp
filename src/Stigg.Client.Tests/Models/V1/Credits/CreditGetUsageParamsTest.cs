using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits;

namespace Stigg.Client.Tests.Models.V1.Credits;

public class CreditGetUsageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditGetUsageParams
        {
            CustomerID = "customerId",
            CurrencyID = "currencyId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeRange = TimeRange.LastDay,
        };

        string expectedCustomerID = "customerId";
        string expectedCurrencyID = "currencyId";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, TimeRange> expectedTimeRange = TimeRange.LastDay;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedTimeRange, parameters.TimeRange);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditGetUsageParams { CustomerID = "customerId" };

        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("endDate"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("startDate"));
        Assert.Null(parameters.TimeRange);
        Assert.False(parameters.RawQueryData.ContainsKey("timeRange"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CreditGetUsageParams
        {
            CustomerID = "customerId",

            // Null should be interpreted as omitted for these properties
            CurrencyID = null,
            EndDate = null,
            ResourceID = null,
            StartDate = null,
            TimeRange = null,
        };

        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("endDate"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("startDate"));
        Assert.Null(parameters.TimeRange);
        Assert.False(parameters.RawQueryData.ContainsKey("timeRange"));
    }

    [Fact]
    public void Url_Works()
    {
        CreditGetUsageParams parameters = new()
        {
            CustomerID = "customerId",
            CurrencyID = "currencyId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            TimeRange = TimeRange.LastDay,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/credits/usage?customerId=customerId&currencyId=currencyId&endDate=2019-12-27T18%3a11%3a19.117%2b00%3a00&resourceId=resourceId&startDate=2019-12-27T18%3a11%3a19.117%2b00%3a00&timeRange=LAST_DAY"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditGetUsageParams
        {
            CustomerID = "customerId",
            CurrencyID = "currencyId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TimeRange = TimeRange.LastDay,
        };

        CreditGetUsageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TimeRangeTest : TestBase
{
    [Theory]
    [InlineData(TimeRange.LastDay)]
    [InlineData(TimeRange.LastWeek)]
    [InlineData(TimeRange.LastMonth)]
    [InlineData(TimeRange.LastYear)]
    public void Validation_Works(TimeRange rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TimeRange> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TimeRange>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TimeRange.LastDay)]
    [InlineData(TimeRange.LastWeek)]
    [InlineData(TimeRange.LastMonth)]
    [InlineData(TimeRange.LastYear)]
    public void SerializationRoundtrip_Works(TimeRange rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TimeRange> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TimeRange>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TimeRange>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TimeRange>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
