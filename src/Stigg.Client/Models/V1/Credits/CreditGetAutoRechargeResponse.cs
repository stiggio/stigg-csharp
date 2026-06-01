using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Credits;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreditGetAutoRechargeResponse, CreditGetAutoRechargeResponseFromRaw>)
)]
public sealed record class CreditGetAutoRechargeResponse : JsonModel
{
    /// <summary>
    /// Automatic recharge configuration for a customer and currency
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

    public CreditGetAutoRechargeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditGetAutoRechargeResponse(
        CreditGetAutoRechargeResponse creditGetAutoRechargeResponse
    )
        : base(creditGetAutoRechargeResponse) { }
#pragma warning restore CS8618

    public CreditGetAutoRechargeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditGetAutoRechargeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditGetAutoRechargeResponseFromRaw.FromRawUnchecked"/>
    public static CreditGetAutoRechargeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreditGetAutoRechargeResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class CreditGetAutoRechargeResponseFromRaw : IFromRawJson<CreditGetAutoRechargeResponse>
{
    /// <inheritdoc/>
    public CreditGetAutoRechargeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditGetAutoRechargeResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Automatic recharge configuration for a customer and currency
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The unique configuration ID
    /// </summary>
    public required string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Timestamp of when the record was created
    /// </summary>
    public required DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The currency ID for this configuration
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
    /// The customer ID this configuration belongs to
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
    /// Expiration period for auto-recharge grants (1_MONTH or 1_YEAR)
    /// </summary>
    public required ApiEnum<string, GrantExpirationPeriod> GrantExpirationPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GrantExpirationPeriod>>(
                "grantExpirationPeriod"
            );
        }
        init { this._rawData.Set("grantExpirationPeriod", value); }
    }

    /// <summary>
    /// Whether automatic recharge is enabled
    /// </summary>
    public required bool IsEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isEnabled");
        }
        init { this._rawData.Set("isEnabled", value); }
    }

    /// <summary>
    /// Maximum monthly spend limit for automatic recharges
    /// </summary>
    public required double? MaxSpendLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maxSpendLimit");
        }
        init { this._rawData.Set("maxSpendLimit", value); }
    }

    /// <summary>
    /// The target credit balance to recharge to
    /// </summary>
    public required double TargetBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("targetBalance");
        }
        init { this._rawData.Set("targetBalance", value); }
    }

    /// <summary>
    /// The threshold type (CREDIT_AMOUNT or DOLLAR_AMOUNT)
    /// </summary>
    public required ApiEnum<string, ThresholdType> ThresholdType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ThresholdType>>("thresholdType");
        }
        init { this._rawData.Set("thresholdType", value); }
    }

    /// <summary>
    /// The threshold value that triggers a recharge
    /// </summary>
    public required double ThresholdValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("thresholdValue");
        }
        init { this._rawData.Set("thresholdValue", value); }
    }

    /// <summary>
    /// Timestamp of when the record was last updated
    /// </summary>
    public required DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CurrencyID;
        _ = this.CustomerID;
        this.GrantExpirationPeriod.Validate();
        _ = this.IsEnabled;
        _ = this.MaxSpendLimit;
        _ = this.TargetBalance;
        this.ThresholdType.Validate();
        _ = this.ThresholdValue;
        _ = this.UpdatedAt;
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
/// Expiration period for auto-recharge grants (1_MONTH or 1_YEAR)
/// </summary>
[JsonConverter(typeof(GrantExpirationPeriodConverter))]
public enum GrantExpirationPeriod
{
    V1Month,
    V1Year,
}

sealed class GrantExpirationPeriodConverter : JsonConverter<GrantExpirationPeriod>
{
    public override GrantExpirationPeriod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1_MONTH" => GrantExpirationPeriod.V1Month,
            "1_YEAR" => GrantExpirationPeriod.V1Year,
            _ => (GrantExpirationPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GrantExpirationPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GrantExpirationPeriod.V1Month => "1_MONTH",
                GrantExpirationPeriod.V1Year => "1_YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The threshold type (CREDIT_AMOUNT or DOLLAR_AMOUNT)
/// </summary>
[JsonConverter(typeof(ThresholdTypeConverter))]
public enum ThresholdType
{
    CreditAmount,
    DollarAmount,
}

sealed class ThresholdTypeConverter : JsonConverter<ThresholdType>
{
    public override ThresholdType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREDIT_AMOUNT" => ThresholdType.CreditAmount,
            "DOLLAR_AMOUNT" => ThresholdType.DollarAmount,
            _ => (ThresholdType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThresholdType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ThresholdType.CreditAmount => "CREDIT_AMOUNT",
                ThresholdType.DollarAmount => "DOLLAR_AMOUNT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
