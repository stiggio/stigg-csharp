using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Credits.Reservations;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ReservationReleaseResponse, ReservationReleaseResponseFromRaw>)
)]
public sealed record class ReservationReleaseResponse : JsonModel
{
    /// <summary>
    /// Result of releasing a credit reservation
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ReservationReleaseResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReservationReleaseResponse(ReservationReleaseResponse reservationReleaseResponse)
        : base(reservationReleaseResponse) { }
#pragma warning restore CS8618

    public ReservationReleaseResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReservationReleaseResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReservationReleaseResponseFromRaw.FromRawUnchecked"/>
    public static ReservationReleaseResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReservationReleaseResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class ReservationReleaseResponseFromRaw : IFromRawJson<ReservationReleaseResponse>
{
    /// <inheritdoc/>
    public ReservationReleaseResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReservationReleaseResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of releasing a credit reservation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The optimistic credit balance after the release
    /// </summary>
    public required Credit? Credit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Credit>("credit");
        }
        init { this._rawData.Set("credit", value); }
    }

    /// <summary>
    /// The released reservation
    /// </summary>
    public required Reservation Reservation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Reservation>("reservation");
        }
        init { this._rawData.Set("reservation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Credit?.Validate();
        this.Reservation.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// The optimistic credit balance after the release
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Credit, CreditFromRaw>))]
public sealed record class Credit : JsonModel
{
    /// <summary>
    /// The credit currency identifier
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currencyId");
        }
        init { this._rawData.Set("currencyId", value); }
    }

    /// <summary>
    /// The wallet's total consumed credits for this currency (optimistic — includes
    /// not-yet-reconciled usage), shared across every feature that draws on the currency.
    /// This is the running balance, not this call's deduction — see `consumed` for that.
    /// </summary>
    public required double CurrentUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("currentUsage");
        }
        init { this._rawData.Set("currentUsage", value); }
    }

    /// <summary>
    /// The grant-version timestamp of this balance, used by the SDK for last-write-wins reconciliation
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

    /// <summary>
    /// The total credits granted
    /// </summary>
    public required double UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <summary>
    /// End of the current credit grant period (when recurring credits reset), if applicable
    /// </summary>
    public DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("usagePeriodEnd");
        }
        init { this._rawData.Set("usagePeriodEnd", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrencyID;
        _ = this.CurrentUsage;
        _ = this.Timestamp;
        _ = this.UsageLimit;
        _ = this.UsagePeriodEnd;
    }

    public Credit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Credit(Credit credit)
        : base(credit) { }
#pragma warning restore CS8618

    public Credit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Credit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditFromRaw.FromRawUnchecked"/>
    public static Credit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditFromRaw : IFromRawJson<Credit>
{
    /// <inheritdoc/>
    public Credit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Credit.FromRawUnchecked(rawData);
}

/// <summary>
/// The released reservation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Reservation, ReservationFromRaw>))]
public sealed record class Reservation : JsonModel
{
    /// <summary>
    /// The client-provided reservation ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The amount of credits held.
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
    /// The amount consumed at release
    /// </summary>
    public required double? ConsumedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("consumedAmount");
        }
        init { this._rawData.Set("consumedAmount", value); }
    }

    /// <summary>
    /// When the reservation expires. Unreleased credits return to the balance at
    /// this time.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expiresAt");
        }
        init { this._rawData.Set("expiresAt", value); }
    }

    /// <summary>
    /// The status of the reservation.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.ConsumedAmount;
        _ = this.ExpiresAt;
        this.Status.Validate();
    }

    public Reservation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Reservation(Reservation reservation)
        : base(reservation) { }
#pragma warning restore CS8618

    public Reservation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Reservation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReservationFromRaw.FromRawUnchecked"/>
    public static Reservation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReservationFromRaw : IFromRawJson<Reservation>
{
    /// <inheritdoc/>
    public Reservation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Reservation.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the reservation.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Released,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACTIVE" => Status.Active,
            "RELEASED" => Status.Released,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "ACTIVE",
                Status.Released => "RELEASED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
