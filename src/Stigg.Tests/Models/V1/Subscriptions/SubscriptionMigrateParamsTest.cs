using System;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Subscriptions;

namespace Stigg.Tests.Models.V1.Subscriptions;

public class SubscriptionMigrateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionMigrateParams
        {
            ID = "x",
            SubscriptionMigrationTime = SubscriptionMigrationTime.EndOfBillingPeriod,
        };

        string expectedID = "x";
        ApiEnum<string, SubscriptionMigrationTime> expectedSubscriptionMigrationTime =
            SubscriptionMigrationTime.EndOfBillingPeriod;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSubscriptionMigrationTime, parameters.SubscriptionMigrationTime);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionMigrateParams { ID = "x" };

        Assert.Null(parameters.SubscriptionMigrationTime);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionMigrationTime"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionMigrateParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            SubscriptionMigrationTime = null,
        };

        Assert.Null(parameters.SubscriptionMigrationTime);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionMigrationTime"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionMigrateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/subscriptions/x/migrate"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionMigrateParams
        {
            ID = "x",
            SubscriptionMigrationTime = SubscriptionMigrationTime.EndOfBillingPeriod,
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
