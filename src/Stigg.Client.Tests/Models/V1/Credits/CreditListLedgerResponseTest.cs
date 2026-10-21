using System;
using System.Collections.Generic;
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
            Breakdown =
            [
                new()
                {
                    Amount = 0,
                    CreditCurrencyID = "creditCurrencyId",
                    CreditGrantID = "creditGrantId",
                    CustomerID = "customerId",
                    EventID = "eventId",
                    EventType = EventType.CreditsGranted,
                    FeatureID = "featureId",
                    ReservationID = "reservationId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = CreditListLedgerResponseEventType.CreditsGranted,
            FeatureID = "featureId",
            HoldReturnedAmount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ReservationID = "reservationId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        double expectedAmount = 0;
        List<Breakdown> expectedBreakdown =
        [
            new()
            {
                Amount = 0,
                CreditCurrencyID = "creditCurrencyId",
                CreditGrantID = "creditGrantId",
                CustomerID = "customerId",
                EventID = "eventId",
                EventType = EventType.CreditsGranted,
                FeatureID = "featureId",
                ReservationID = "reservationId",
                ResourceID = "resourceId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedCreditCurrencyID = "creditCurrencyId";
        string expectedCreditGrantID = "creditGrantId";
        string expectedCustomerID = "customerId";
        string expectedEventID = "eventId";
        ApiEnum<string, CreditListLedgerResponseEventType> expectedEventType =
            CreditListLedgerResponseEventType.CreditsGranted;
        string expectedFeatureID = "featureId";
        double expectedHoldReturnedAmount = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedReservationID = "reservationId";
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.NotNull(model.Breakdown);
        Assert.Equal(expectedBreakdown.Count, model.Breakdown.Count);
        for (int i = 0; i < expectedBreakdown.Count; i++)
        {
            Assert.Equal(expectedBreakdown[i], model.Breakdown[i]);
        }
        Assert.Equal(expectedCreditCurrencyID, model.CreditCurrencyID);
        Assert.Equal(expectedCreditGrantID, model.CreditGrantID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedHoldReturnedAmount, model.HoldReturnedAmount);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedReservationID, model.ReservationID);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditListLedgerResponse
        {
            Amount = 0,
            Breakdown =
            [
                new()
                {
                    Amount = 0,
                    CreditCurrencyID = "creditCurrencyId",
                    CreditGrantID = "creditGrantId",
                    CustomerID = "customerId",
                    EventID = "eventId",
                    EventType = EventType.CreditsGranted,
                    FeatureID = "featureId",
                    ReservationID = "reservationId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = CreditListLedgerResponseEventType.CreditsGranted,
            FeatureID = "featureId",
            HoldReturnedAmount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ReservationID = "reservationId",
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
            Breakdown =
            [
                new()
                {
                    Amount = 0,
                    CreditCurrencyID = "creditCurrencyId",
                    CreditGrantID = "creditGrantId",
                    CustomerID = "customerId",
                    EventID = "eventId",
                    EventType = EventType.CreditsGranted,
                    FeatureID = "featureId",
                    ReservationID = "reservationId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = CreditListLedgerResponseEventType.CreditsGranted,
            FeatureID = "featureId",
            HoldReturnedAmount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ReservationID = "reservationId",
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
        List<Breakdown> expectedBreakdown =
        [
            new()
            {
                Amount = 0,
                CreditCurrencyID = "creditCurrencyId",
                CreditGrantID = "creditGrantId",
                CustomerID = "customerId",
                EventID = "eventId",
                EventType = EventType.CreditsGranted,
                FeatureID = "featureId",
                ReservationID = "reservationId",
                ResourceID = "resourceId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedCreditCurrencyID = "creditCurrencyId";
        string expectedCreditGrantID = "creditGrantId";
        string expectedCustomerID = "customerId";
        string expectedEventID = "eventId";
        ApiEnum<string, CreditListLedgerResponseEventType> expectedEventType =
            CreditListLedgerResponseEventType.CreditsGranted;
        string expectedFeatureID = "featureId";
        double expectedHoldReturnedAmount = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedReservationID = "reservationId";
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.NotNull(deserialized.Breakdown);
        Assert.Equal(expectedBreakdown.Count, deserialized.Breakdown.Count);
        for (int i = 0; i < expectedBreakdown.Count; i++)
        {
            Assert.Equal(expectedBreakdown[i], deserialized.Breakdown[i]);
        }
        Assert.Equal(expectedCreditCurrencyID, deserialized.CreditCurrencyID);
        Assert.Equal(expectedCreditGrantID, deserialized.CreditGrantID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedHoldReturnedAmount, deserialized.HoldReturnedAmount);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedReservationID, deserialized.ReservationID);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditListLedgerResponse
        {
            Amount = 0,
            Breakdown =
            [
                new()
                {
                    Amount = 0,
                    CreditCurrencyID = "creditCurrencyId",
                    CreditGrantID = "creditGrantId",
                    CustomerID = "customerId",
                    EventID = "eventId",
                    EventType = EventType.CreditsGranted,
                    FeatureID = "featureId",
                    ReservationID = "reservationId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = CreditListLedgerResponseEventType.CreditsGranted,
            FeatureID = "featureId",
            HoldReturnedAmount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ReservationID = "reservationId",
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
            Breakdown =
            [
                new()
                {
                    Amount = 0,
                    CreditCurrencyID = "creditCurrencyId",
                    CreditGrantID = "creditGrantId",
                    CustomerID = "customerId",
                    EventID = "eventId",
                    EventType = EventType.CreditsGranted,
                    FeatureID = "featureId",
                    ReservationID = "reservationId",
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = CreditListLedgerResponseEventType.CreditsGranted,
            FeatureID = "featureId",
            HoldReturnedAmount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ReservationID = "reservationId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreditListLedgerResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BreakdownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Breakdown
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ReservationID = "reservationId",
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
        string expectedReservationID = "reservationId";
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreditCurrencyID, model.CreditCurrencyID);
        Assert.Equal(expectedCreditGrantID, model.CreditGrantID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedReservationID, model.ReservationID);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Breakdown
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ReservationID = "reservationId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Breakdown>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Breakdown
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ReservationID = "reservationId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Breakdown>(
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
        string expectedReservationID = "reservationId";
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreditCurrencyID, deserialized.CreditCurrencyID);
        Assert.Equal(expectedCreditGrantID, deserialized.CreditGrantID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedReservationID, deserialized.ReservationID);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Breakdown
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ReservationID = "reservationId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Breakdown
        {
            Amount = 0,
            CreditCurrencyID = "creditCurrencyId",
            CreditGrantID = "creditGrantId",
            CustomerID = "customerId",
            EventID = "eventId",
            EventType = EventType.CreditsGranted,
            FeatureID = "featureId",
            ReservationID = "reservationId",
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Breakdown copied = new(model);

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
    [InlineData(EventType.CreditsReserved)]
    [InlineData(EventType.CreditsReservationReleased)]
    [InlineData(EventType.CreditsReservationExpired)]
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
    [InlineData(EventType.CreditsReserved)]
    [InlineData(EventType.CreditsReservationReleased)]
    [InlineData(EventType.CreditsReservationExpired)]
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

public class CreditListLedgerResponseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(CreditListLedgerResponseEventType.CreditsGranted)]
    [InlineData(CreditListLedgerResponseEventType.CreditsExpired)]
    [InlineData(CreditListLedgerResponseEventType.CreditsConsumed)]
    [InlineData(CreditListLedgerResponseEventType.CreditsVoided)]
    [InlineData(CreditListLedgerResponseEventType.CreditsUpdated)]
    [InlineData(CreditListLedgerResponseEventType.CreditsConsumptionTransferSource)]
    [InlineData(CreditListLedgerResponseEventType.CreditsConsumptionTransferTarget)]
    [InlineData(CreditListLedgerResponseEventType.CreditsReserved)]
    [InlineData(CreditListLedgerResponseEventType.CreditsReservationReleased)]
    [InlineData(CreditListLedgerResponseEventType.CreditsReservationExpired)]
    public void Validation_Works(CreditListLedgerResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListLedgerResponseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditListLedgerResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditListLedgerResponseEventType.CreditsGranted)]
    [InlineData(CreditListLedgerResponseEventType.CreditsExpired)]
    [InlineData(CreditListLedgerResponseEventType.CreditsConsumed)]
    [InlineData(CreditListLedgerResponseEventType.CreditsVoided)]
    [InlineData(CreditListLedgerResponseEventType.CreditsUpdated)]
    [InlineData(CreditListLedgerResponseEventType.CreditsConsumptionTransferSource)]
    [InlineData(CreditListLedgerResponseEventType.CreditsConsumptionTransferTarget)]
    [InlineData(CreditListLedgerResponseEventType.CreditsReserved)]
    [InlineData(CreditListLedgerResponseEventType.CreditsReservationReleased)]
    [InlineData(CreditListLedgerResponseEventType.CreditsReservationExpired)]
    public void SerializationRoundtrip_Works(CreditListLedgerResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditListLedgerResponseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListLedgerResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditListLedgerResponseEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreditListLedgerResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
