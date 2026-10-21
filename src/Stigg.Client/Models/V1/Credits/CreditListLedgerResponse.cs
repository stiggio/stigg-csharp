using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Credits;

/// <summary>
/// A credit ledger event representing a change to credit balance
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreditListLedgerResponse, CreditListLedgerResponseFromRaw>)
)]
public sealed record class CreditListLedgerResponse : JsonModel
{
    /// <summary>
    /// The amount of the ledger event. Reservation events carry their net effect
    /// on the balance: a reserve is negative, and so is a release that consumed
    /// more than was held
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// On a released reservation, the credits consumed from each grant
    /// </summary>
    public required IReadOnlyList<Breakdown>? Breakdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Breakdown>>("breakdown");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Breakdown>?>(
                "breakdown",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The credit currency ID
    /// </summary>
    public required string CreditCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditCurrencyId");
        }
        init { this._rawData.Set("creditCurrencyId", value); }
    }

    /// <summary>
    /// The credit grant ID associated with this event
    /// </summary>
    public required string CreditGrantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditGrantId");
        }
        init { this._rawData.Set("creditGrantId", value); }
    }

    /// <summary>
    /// The customer ID this event belongs to
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customerId");
        }
        init { this._rawData.Set("customerId", value); }
    }

    /// <summary>
    /// The unique event identifier
    /// </summary>
    public required string? EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("eventId");
        }
        init { this._rawData.Set("eventId", value); }
    }

    /// <summary>
    /// The type of credit event
    /// </summary>
    public required ApiEnum<string, CreditListLedgerResponseEventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditListLedgerResponseEventType>
            >("eventType");
        }
        init { this._rawData.Set("eventType", value); }
    }

    /// <summary>
    /// The feature ID associated with this event
    /// </summary>
    public required string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// On a released reservation, the held amount returned to the balance before
    /// consumed credits are deducted
    /// </summary>
    public required double? HoldReturnedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("holdReturnedAmount");
        }
        init { this._rawData.Set("holdReturnedAmount", value); }
    }

    /// <summary>
    /// The metadata sent with the credit reservation
    /// </summary>
    public required IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The credit reservation this event belongs to
    /// </summary>
    public required string? ReservationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reservationId");
        }
        init { this._rawData.Set("reservationId", value); }
    }

    /// <summary>
    /// The resource ID this event is scoped to
    /// </summary>
    public required string? ResourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resourceId");
        }
        init { this._rawData.Set("resourceId", value); }
    }

    /// <summary>
    /// The timestamp when the event occurred
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        foreach (var item in this.Breakdown ?? [])
        {
            item.Validate();
        }
        _ = this.CreditCurrencyID;
        _ = this.CreditGrantID;
        _ = this.CustomerID;
        _ = this.EventID;
        this.EventType.Validate();
        _ = this.FeatureID;
        _ = this.HoldReturnedAmount;
        _ = this.Metadata;
        _ = this.ReservationID;
        _ = this.ResourceID;
        _ = this.Timestamp;
    }

    public CreditListLedgerResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditListLedgerResponse(CreditListLedgerResponse creditListLedgerResponse)
        : base(creditListLedgerResponse) { }
#pragma warning restore CS8618

    public CreditListLedgerResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListLedgerResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListLedgerResponseFromRaw.FromRawUnchecked"/>
    public static CreditListLedgerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListLedgerResponseFromRaw : IFromRawJson<CreditListLedgerResponse>
{
    /// <inheritdoc/>
    public CreditListLedgerResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListLedgerResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Breakdown, BreakdownFromRaw>))]
public sealed record class Breakdown : JsonModel
{
    /// <summary>
    /// The amount of the ledger event. Reservation events carry their net effect
    /// on the balance: a reserve is negative, and so is a release that consumed
    /// more than was held
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The credit currency ID
    /// </summary>
    public required string CreditCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditCurrencyId");
        }
        init { this._rawData.Set("creditCurrencyId", value); }
    }

    /// <summary>
    /// The credit grant ID associated with this event
    /// </summary>
    public required string CreditGrantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creditGrantId");
        }
        init { this._rawData.Set("creditGrantId", value); }
    }

    /// <summary>
    /// The customer ID this event belongs to
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customerId");
        }
        init { this._rawData.Set("customerId", value); }
    }

    /// <summary>
    /// The unique event identifier
    /// </summary>
    public required string? EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("eventId");
        }
        init { this._rawData.Set("eventId", value); }
    }

    /// <summary>
    /// The type of credit event
    /// </summary>
    public required ApiEnum<string, EventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventType>>("eventType");
        }
        init { this._rawData.Set("eventType", value); }
    }

    /// <summary>
    /// The feature ID associated with this event
    /// </summary>
    public required string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// The credit reservation this event belongs to
    /// </summary>
    public required string? ReservationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reservationId");
        }
        init { this._rawData.Set("reservationId", value); }
    }

    /// <summary>
    /// The resource ID this event is scoped to
    /// </summary>
    public required string? ResourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resourceId");
        }
        init { this._rawData.Set("resourceId", value); }
    }

    /// <summary>
    /// The timestamp when the event occurred
    /// </summary>
    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CreditCurrencyID;
        _ = this.CreditGrantID;
        _ = this.CustomerID;
        _ = this.EventID;
        this.EventType.Validate();
        _ = this.FeatureID;
        _ = this.ReservationID;
        _ = this.ResourceID;
        _ = this.Timestamp;
    }

    public Breakdown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Breakdown(Breakdown breakdown)
        : base(breakdown) { }
#pragma warning restore CS8618

    public Breakdown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Breakdown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BreakdownFromRaw.FromRawUnchecked"/>
    public static Breakdown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BreakdownFromRaw : IFromRawJson<Breakdown>
{
    /// <inheritdoc/>
    public Breakdown FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Breakdown.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of credit event
/// </summary>
[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
{
    CreditsGranted,
    CreditsExpired,
    CreditsConsumed,
    CreditsVoided,
    CreditsUpdated,
    CreditsConsumptionTransferSource,
    CreditsConsumptionTransferTarget,
    CreditsReserved,
    CreditsReservationReleased,
    CreditsReservationExpired,
}

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREDITS_GRANTED" => EventType.CreditsGranted,
            "CREDITS_EXPIRED" => EventType.CreditsExpired,
            "CREDITS_CONSUMED" => EventType.CreditsConsumed,
            "CREDITS_VOIDED" => EventType.CreditsVoided,
            "CREDITS_UPDATED" => EventType.CreditsUpdated,
            "CREDITS_CONSUMPTION_TRANSFER_SOURCE" => EventType.CreditsConsumptionTransferSource,
            "CREDITS_CONSUMPTION_TRANSFER_TARGET" => EventType.CreditsConsumptionTransferTarget,
            "CREDITS_RESERVED" => EventType.CreditsReserved,
            "CREDITS_RESERVATION_RELEASED" => EventType.CreditsReservationReleased,
            "CREDITS_RESERVATION_EXPIRED" => EventType.CreditsReservationExpired,
            _ => (EventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventType.CreditsGranted => "CREDITS_GRANTED",
                EventType.CreditsExpired => "CREDITS_EXPIRED",
                EventType.CreditsConsumed => "CREDITS_CONSUMED",
                EventType.CreditsVoided => "CREDITS_VOIDED",
                EventType.CreditsUpdated => "CREDITS_UPDATED",
                EventType.CreditsConsumptionTransferSource => "CREDITS_CONSUMPTION_TRANSFER_SOURCE",
                EventType.CreditsConsumptionTransferTarget => "CREDITS_CONSUMPTION_TRANSFER_TARGET",
                EventType.CreditsReserved => "CREDITS_RESERVED",
                EventType.CreditsReservationReleased => "CREDITS_RESERVATION_RELEASED",
                EventType.CreditsReservationExpired => "CREDITS_RESERVATION_EXPIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of credit event
/// </summary>
[JsonConverter(typeof(CreditListLedgerResponseEventTypeConverter))]
public enum CreditListLedgerResponseEventType
{
    CreditsGranted,
    CreditsExpired,
    CreditsConsumed,
    CreditsVoided,
    CreditsUpdated,
    CreditsConsumptionTransferSource,
    CreditsConsumptionTransferTarget,
    CreditsReserved,
    CreditsReservationReleased,
    CreditsReservationExpired,
}

sealed class CreditListLedgerResponseEventTypeConverter
    : JsonConverter<CreditListLedgerResponseEventType>
{
    public override CreditListLedgerResponseEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREDITS_GRANTED" => CreditListLedgerResponseEventType.CreditsGranted,
            "CREDITS_EXPIRED" => CreditListLedgerResponseEventType.CreditsExpired,
            "CREDITS_CONSUMED" => CreditListLedgerResponseEventType.CreditsConsumed,
            "CREDITS_VOIDED" => CreditListLedgerResponseEventType.CreditsVoided,
            "CREDITS_UPDATED" => CreditListLedgerResponseEventType.CreditsUpdated,
            "CREDITS_CONSUMPTION_TRANSFER_SOURCE" =>
                CreditListLedgerResponseEventType.CreditsConsumptionTransferSource,
            "CREDITS_CONSUMPTION_TRANSFER_TARGET" =>
                CreditListLedgerResponseEventType.CreditsConsumptionTransferTarget,
            "CREDITS_RESERVED" => CreditListLedgerResponseEventType.CreditsReserved,
            "CREDITS_RESERVATION_RELEASED" =>
                CreditListLedgerResponseEventType.CreditsReservationReleased,
            "CREDITS_RESERVATION_EXPIRED" =>
                CreditListLedgerResponseEventType.CreditsReservationExpired,
            _ => (CreditListLedgerResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListLedgerResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListLedgerResponseEventType.CreditsGranted => "CREDITS_GRANTED",
                CreditListLedgerResponseEventType.CreditsExpired => "CREDITS_EXPIRED",
                CreditListLedgerResponseEventType.CreditsConsumed => "CREDITS_CONSUMED",
                CreditListLedgerResponseEventType.CreditsVoided => "CREDITS_VOIDED",
                CreditListLedgerResponseEventType.CreditsUpdated => "CREDITS_UPDATED",
                CreditListLedgerResponseEventType.CreditsConsumptionTransferSource =>
                    "CREDITS_CONSUMPTION_TRANSFER_SOURCE",
                CreditListLedgerResponseEventType.CreditsConsumptionTransferTarget =>
                    "CREDITS_CONSUMPTION_TRANSFER_TARGET",
                CreditListLedgerResponseEventType.CreditsReserved => "CREDITS_RESERVED",
                CreditListLedgerResponseEventType.CreditsReservationReleased =>
                    "CREDITS_RESERVATION_RELEASED",
                CreditListLedgerResponseEventType.CreditsReservationExpired =>
                    "CREDITS_RESERVATION_EXPIRED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
