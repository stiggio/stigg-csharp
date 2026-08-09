using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Credits.Consumption;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConsumptionConsumeResponse, ConsumptionConsumeResponseFromRaw>)
)]
public sealed record class ConsumptionConsumeResponse : JsonModel
{
    /// <summary>
    /// Result of a synchronous direct credit consumption
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

    public ConsumptionConsumeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumptionConsumeResponse(ConsumptionConsumeResponse consumptionConsumeResponse)
        : base(consumptionConsumeResponse) { }
#pragma warning restore CS8618

    public ConsumptionConsumeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumptionConsumeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumptionConsumeResponseFromRaw.FromRawUnchecked"/>
    public static ConsumptionConsumeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConsumptionConsumeResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class ConsumptionConsumeResponseFromRaw : IFromRawJson<ConsumptionConsumeResponse>
{
    /// <inheritdoc/>
    public ConsumptionConsumeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumptionConsumeResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of a synchronous direct credit consumption
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The amount of credits consumed
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
    /// The credit currency the credits were consumed from
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
    /// The customer the credits were consumed from
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
    /// The timestamp the consumption was attributed to
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
    /// The optimistic credit balance after consumption (when sync credit consumption
    /// is enabled)
    /// </summary>
    public Credit? Credit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Credit>("credit");
        }
        init { this._rawData.Set("credit", value); }
    }

    /// <summary>
    /// The resource the consumption was attributed to
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resourceId");
        }
        init { this._rawData.Set("resourceId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CurrencyID;
        _ = this.CustomerID;
        _ = this.Timestamp;
        this.Credit?.Validate();
        _ = this.ResourceID;
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
/// The optimistic credit balance after consumption (when sync credit consumption
/// is enabled)
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
