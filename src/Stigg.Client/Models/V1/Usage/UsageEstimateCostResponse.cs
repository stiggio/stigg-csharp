using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Usage;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UsageEstimateCostResponse, UsageEstimateCostResponseFromRaw>)
)]
public sealed record class UsageEstimateCostResponse : JsonModel
{
    /// <summary>
    /// Estimated credit cost, current balance and balance after
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

    public UsageEstimateCostResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageEstimateCostResponse(UsageEstimateCostResponse usageEstimateCostResponse)
        : base(usageEstimateCostResponse) { }
#pragma warning restore CS8618

    public UsageEstimateCostResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageEstimateCostResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageEstimateCostResponseFromRaw.FromRawUnchecked"/>
    public static UsageEstimateCostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageEstimateCostResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class UsageEstimateCostResponseFromRaw : IFromRawJson<UsageEstimateCostResponse>
{
    /// <inheritdoc/>
    public UsageEstimateCostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageEstimateCostResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Estimated credit cost, current balance and balance after
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Per-currency cost estimates
    /// </summary>
    public required IReadOnlyList<Estimate> Estimates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Estimate>>("estimates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Estimate>>(
                "estimates",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Request-level warnings about the estimation context
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, Warning>> Warnings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, Warning>>>(
                "warnings"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, Warning>>>(
                "warnings",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Estimates)
        {
            item.Validate();
        }
        foreach (var item in this.Warnings)
        {
            item.Validate();
        }
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

[JsonConverter(typeof(JsonModelConverter<Estimate, EstimateFromRaw>))]
public sealed record class Estimate : JsonModel
{
    /// <summary>
    /// The credit balance after subtracting the estimated cost
    /// </summary>
    public required double BalanceAfterEstimate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("balanceAfterEstimate");
        }
        init { this._rawData.Set("balanceAfterEstimate", value); }
    }

    /// <summary>
    /// Estimated cost contribution per feature
    /// </summary>
    public required IReadOnlyList<Breakdown> Breakdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Breakdown>>("breakdown");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Breakdown>>(
                "breakdown",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// The current credit balance, including not-yet-reconciled consumption
    /// </summary>
    public required double CurrentBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("currentBalance");
        }
        init { this._rawData.Set("currentBalance", value); }
    }

    /// <summary>
    /// The estimated credit cost of the reported event or usage
    /// </summary>
    public required double EstimatedCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("estimatedCost");
        }
        init { this._rawData.Set("estimatedCost", value); }
    }

    /// <summary>
    /// Whether the estimated consumption would bring the balance below zero
    /// </summary>
    public required bool WouldOverdraft
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("wouldOverdraft");
        }
        init { this._rawData.Set("wouldOverdraft", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BalanceAfterEstimate;
        foreach (var item in this.Breakdown)
        {
            item.Validate();
        }
        _ = this.CurrencyID;
        _ = this.CurrentBalance;
        _ = this.EstimatedCost;
        _ = this.WouldOverdraft;
    }

    public Estimate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Estimate(Estimate estimate)
        : base(estimate) { }
#pragma warning restore CS8618

    public Estimate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Estimate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EstimateFromRaw.FromRawUnchecked"/>
    public static Estimate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EstimateFromRaw : IFromRawJson<Estimate>
{
    /// <inheritdoc/>
    public Estimate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Estimate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Breakdown, BreakdownFromRaw>))]
public sealed record class Breakdown : JsonModel
{
    /// <summary>
    /// The estimated credit cost contributed by this feature
    /// </summary>
    public required double Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("cost");
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// The feature whose meter contributed this cost
    /// </summary>
    public required string FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// Warning explaining why this cost may be inaccurate, if any
    /// </summary>
    public required ApiEnum<string, WarningCode>? WarningCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WarningCode>>("warningCode");
        }
        init { this._rawData.Set("warningCode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cost;
        _ = this.FeatureID;
        this.WarningCode?.Validate();
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
/// Warning explaining why this cost may be inaccurate, if any
/// </summary>
[JsonConverter(typeof(WarningCodeConverter))]
public enum WarningCode
{
    UnsupportedAggregation,
}

sealed class WarningCodeConverter : JsonConverter<WarningCode>
{
    public override WarningCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UNSUPPORTED_AGGREGATION" => WarningCode.UnsupportedAggregation,
            _ => (WarningCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WarningCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WarningCode.UnsupportedAggregation => "UNSUPPORTED_AGGREGATION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(WarningConverter))]
public enum Warning
{
    ResourceScopedSubscriptionExists,
    FeatureNotFound,
    FeatureNotCreditBased,
}

sealed class WarningConverter : JsonConverter<Warning>
{
    public override Warning Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RESOURCE_SCOPED_SUBSCRIPTION_EXISTS" => Warning.ResourceScopedSubscriptionExists,
            "FEATURE_NOT_FOUND" => Warning.FeatureNotFound,
            "FEATURE_NOT_CREDIT_BASED" => Warning.FeatureNotCreditBased,
            _ => (Warning)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Warning value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Warning.ResourceScopedSubscriptionExists => "RESOURCE_SCOPED_SUBSCRIPTION_EXISTS",
                Warning.FeatureNotFound => "FEATURE_NOT_FOUND",
                Warning.FeatureNotCreditBased => "FEATURE_NOT_CREDIT_BASED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
