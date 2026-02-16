using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionCancelParams
        {
            ID = "x",
            CancellationAction = CancellationAction.Default,
            CancellationTime = CancellationTime.EndOfBillingPeriod,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prorate = true,
        };

        string expectedID = "x";
        ApiEnum<string, CancellationAction> expectedCancellationAction = CancellationAction.Default;
        ApiEnum<string, CancellationTime> expectedCancellationTime =
            CancellationTime.EndOfBillingPeriod;
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedProrate = true;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCancellationAction, parameters.CancellationAction);
        Assert.Equal(expectedCancellationTime, parameters.CancellationTime);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedProrate, parameters.Prorate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionCancelParams { ID = "x" };

        Assert.Null(parameters.CancellationAction);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellationAction"));
        Assert.Null(parameters.CancellationTime);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellationTime"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endDate"));
        Assert.Null(parameters.Prorate);
        Assert.False(parameters.RawBodyData.ContainsKey("prorate"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionCancelParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            CancellationAction = null,
            CancellationTime = null,
            EndDate = null,
            Prorate = null,
        };

        Assert.Null(parameters.CancellationAction);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellationAction"));
        Assert.Null(parameters.CancellationTime);
        Assert.False(parameters.RawBodyData.ContainsKey("cancellationTime"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("endDate"));
        Assert.Null(parameters.Prorate);
        Assert.False(parameters.RawBodyData.ContainsKey("prorate"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionCancelParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/subscriptions/x/cancel"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionCancelParams
        {
            ID = "x",
            CancellationAction = CancellationAction.Default,
            CancellationTime = CancellationTime.EndOfBillingPeriod,
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Prorate = true,
        };

        SubscriptionCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CancellationActionTest : TestBase
{
    [Theory]
    [InlineData(CancellationAction.Default)]
    [InlineData(CancellationAction.RevokeEntitlements)]
    public void Validation_Works(CancellationAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancellationAction.Default)]
    [InlineData(CancellationAction.RevokeEntitlements)]
    public void SerializationRoundtrip_Works(CancellationAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CancellationTimeTest : TestBase
{
    [Theory]
    [InlineData(CancellationTime.EndOfBillingPeriod)]
    [InlineData(CancellationTime.Immediate)]
    [InlineData(CancellationTime.SpecificDate)]
    public void Validation_Works(CancellationTime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationTime> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationTime>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancellationTime.EndOfBillingPeriod)]
    [InlineData(CancellationTime.Immediate)]
    [InlineData(CancellationTime.SpecificDate)]
    public void SerializationRoundtrip_Works(CancellationTime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancellationTime> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationTime>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancellationTime>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancellationTime>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
