using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits;

namespace Stigg.Client.Tests.Models.V1.Credits;

public class CreditListLedgerResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditListLedgerResponse
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        double expectedAmount = 0;
        string expectedCreditCurrencyID = "creditCurrencyId";
        string expectedCreditGrantID = "creditGrantId";
        string expectedCustomerID = "customerId";
        string expectedEventID = "eventId";
        ApiEnum<string, EventType> expectedEventType = EventType.CreditsGranted;
        string expectedFeatureID = "featureId";
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreditCurrencyID, model.CreditCurrencyID);
        Assert.Equal(expectedCreditGrantID, model.CreditGrantID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditListLedgerResponse
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListLedgerResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditListLedgerResponse
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditListLedgerResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedCreditCurrencyID = "creditCurrencyId";
        string expectedCreditGrantID = "creditGrantId";
        string expectedCustomerID = "customerId";
        string expectedEventID = "eventId";
        ApiEnum<string, EventType> expectedEventType = EventType.CreditsGranted;
        string expectedFeatureID = "featureId";
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreditCurrencyID, deserialized.CreditCurrencyID);
        Assert.Equal(expectedCreditGrantID, deserialized.CreditGrantID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditListLedgerResponse
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditListLedgerResponse
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreditListLedgerResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventType.CreditsGranted)]
    [InlineData(EventType.CreditsExpired)]
    [InlineData(EventType.CreditsConsumed)]
    [InlineData(EventType.CreditsVoided)]
    [InlineData(EventType.CreditsUpdated)]
    [InlineData(EventType.CreditsConsumptionTransferSource)]
    [InlineData(EventType.CreditsConsumptionTransferTarget)]
    public void Validation_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventType.CreditsGranted)]
    [InlineData(EventType.CreditsExpired)]
    [InlineData(EventType.CreditsConsumed)]
    [InlineData(EventType.CreditsVoided)]
    [InlineData(EventType.CreditsUpdated)]
    [InlineData(EventType.CreditsConsumptionTransferSource)]
    [InlineData(EventType.CreditsConsumptionTransferTarget)]
    public void SerializationRoundtrip_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
