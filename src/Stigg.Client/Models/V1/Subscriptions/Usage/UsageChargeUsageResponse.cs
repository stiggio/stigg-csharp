using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Subscriptions.Usage;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UsageChargeUsageResponse, UsageChargeUsageResponseFromRaw>)
)]
public sealed record class UsageChargeUsageResponse : JsonModel
{
    /// <summary>
    /// Result of charging subscription usage including the billing period and charged items.
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

    public UsageChargeUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageChargeUsageResponse(UsageChargeUsageResponse usageChargeUsageResponse)
        : base(usageChargeUsageResponse) { }
#pragma warning restore CS8618

    public UsageChargeUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageChargeUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageChargeUsageResponseFromRaw.FromRawUnchecked"/>
    public static UsageChargeUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageChargeUsageResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class UsageChargeUsageResponseFromRaw : IFromRawJson<UsageChargeUsageResponse>
{
    /// <inheritdoc/>
    public UsageChargeUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageChargeUsageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of charging subscription usage including the billing period and charged items.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The invoice ID in the billing integration
    /// </summary>
    public required string? InvoiceBillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoiceBillingId");
        }
        init { this._rawData.Set("invoiceBillingId", value); }
    }

    /// <summary>
    /// End of the usage billing period
    /// </summary>
    public required DateTimeOffset PeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("periodEnd");
        }
        init { this._rawData.Set("periodEnd", value); }
    }

    /// <summary>
    /// Start of the usage billing period
    /// </summary>
    public required DateTimeOffset PeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("periodStart");
        }
        init { this._rawData.Set("periodStart", value); }
    }

    /// <summary>
    /// The subscription ID for which usage was charged
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscriptionId");
        }
        init { this._rawData.Set("subscriptionId", value); }
    }

    /// <summary>
    /// Usage items that were charged
    /// </summary>
    public required IReadOnlyList<UsageCharged> UsageCharged
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UsageCharged>>("usageCharged");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UsageCharged>>(
                "usageCharged",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InvoiceBillingID;
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
        _ = this.SubscriptionID;
        foreach (var item in this.UsageCharged)
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

/// <summary>
/// A single usage item that was charged.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageCharged, UsageChargedFromRaw>))]
public sealed record class UsageCharged : JsonModel
{
    /// <summary>
    /// The feature ID for which usage was charged
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
    /// The number of units charged
    /// </summary>
    public required double UsageAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("usageAmount");
        }
        init { this._rawData.Set("usageAmount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeatureID;
        _ = this.UsageAmount;
    }

    public UsageCharged() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageCharged(UsageCharged usageCharged)
        : base(usageCharged) { }
#pragma warning restore CS8618

    public UsageCharged(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageCharged(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageChargedFromRaw.FromRawUnchecked"/>
    public static UsageCharged FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageChargedFromRaw : IFromRawJson<UsageCharged>
{
    /// <inheritdoc/>
    public UsageCharged FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UsageCharged.FromRawUnchecked(rawData);
}
