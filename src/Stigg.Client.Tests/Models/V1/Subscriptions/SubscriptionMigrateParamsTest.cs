using System;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionMigrateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionMigrateParams
        {
            ID = "x",
            SubscriptionMigrationTime = SubscriptionMigrationTime.EndOfBillingPeriod,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        ApiEnum<string, SubscriptionMigrationTime> expectedSubscriptionMigrationTime =
            SubscriptionMigrationTime.EndOfBillingPeriod;
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSubscriptionMigrationTime, parameters.SubscriptionMigrationTime);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionMigrateParams { ID = "x" };

        Assert.Null(parameters.SubscriptionMigrationTime);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionMigrationTime"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionMigrateParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            SubscriptionMigrationTime = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.SubscriptionMigrationTime);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionMigrationTime"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionMigrateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://edge.api.stigg.io/api/v1/subscriptions/x/migrate"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SubscriptionMigrateParams parameters = new()
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
        var parameters = new SubscriptionMigrateParams
        {
            ID = "x",
            SubscriptionMigrationTime = SubscriptionMigrationTime.EndOfBillingPeriod,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        SubscriptionMigrateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SubscriptionMigrationTimeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionMigrationTime.EndOfBillingPeriod)]
    [InlineData(SubscriptionMigrationTime.Immediate)]
    public void Validation_Works(SubscriptionMigrationTime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrationTime> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionMigrationTime>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionMigrationTime.EndOfBillingPeriod)]
    [InlineData(SubscriptionMigrationTime.Immediate)]
    public void SerializationRoundtrip_Works(SubscriptionMigrationTime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrationTime> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionMigrationTime>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionMigrationTime>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionMigrationTime>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
