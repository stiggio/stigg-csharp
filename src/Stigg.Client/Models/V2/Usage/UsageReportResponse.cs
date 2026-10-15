using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V2.Usage;

/// <summary>
/// Response containing reported usage measurements with current usage values, period
/// information and reset dates, plus the balance of each credit wallet they drew from.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageReportResponse, UsageReportResponseFromRaw>))]
public sealed record class UsageReportResponse : JsonModel
{
    /// <summary>
    /// Reported usage measurements and the credit balances they drew from
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

    public UsageReportResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageReportResponse(UsageReportResponse usageReportResponse)
        : base(usageReportResponse) { }
#pragma warning restore CS8618

    public UsageReportResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageReportResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageReportResponseFromRaw.FromRawUnchecked"/>
    public static UsageReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UsageReportResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class UsageReportResponseFromRaw : IFromRawJson<UsageReportResponse>
{
    /// <inheritdoc/>
    public UsageReportResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UsageReportResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Reported usage measurements and the credit balances they drew from
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Usage measurements, in request order, with current values and period info
    /// </summary>
    public required IReadOnlyList<DataUsage> Usages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DataUsage>>("usages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DataUsage>>(
                "usages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The balance of each credit wallet the request drew from. Omitted when no reported
    /// feature consumes credits, or when credit balances aren't computed synchronously
    /// for the environment; each usage's `credit` is then `null`.
    /// </summary>
    public IReadOnlyList<DataCredit>? Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DataCredit>>("credits");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DataCredit>?>(
                "credits",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The current usage of each governance entitlement this request counted towards.
    /// Absent when governance is not enabled or the usage is unknown. Entitlements
    /// whose usage could not be read, and those of repeated idempotent requests,
    /// are left out
    /// </summary>
    public IReadOnlyList<Entity>? Entities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Entity>>("entities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Entity>?>(
                "entities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Usages)
        {
            item.Validate();
        }
        foreach (var item in this.Credits ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Entities ?? [])
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

    [SetsRequiredMembers]
    public Data(IReadOnlyList<DataUsage> usages)
        : this()
    {
        this.Usages = usages;
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Recorded usage with period info and the credits it deducted
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataUsage, DataUsageFromRaw>))]
public sealed record class DataUsage : JsonModel
{
    /// <summary>
    /// Unique identifier for the entity
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
    /// Timestamp of when the record was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Customer id
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
    /// Feature id
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
    /// Timestamp
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
    /// The usage measurement record
    /// </summary>
    public required long Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// The credits this measurement deducted. `null` when the measurement drew from
    /// no wallet listed in `credits`. The balance of the wallet it drew from is in
    /// the response `credits` list, matched by customer, resource and currency.
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
    /// The current measured usage value
    /// </summary>
    public double? CurrentUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("currentUsage");
        }
        init { this._rawData.Set("currentUsage", value); }
    }

    /// <summary>
    /// The date when the next usage reset will occur
    /// </summary>
    public DateTimeOffset? NextResetDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("nextResetDate");
        }
        init { this._rawData.Set("nextResetDate", value); }
    }

    /// <summary>
    /// The customer resource this usage applies to. Optional — only required if
    /// the customer has multiple resources (for example, one subscription per workspace
    /// or site) and usage needs to be tracked separately per resource; omit it to
    /// report usage at the customer level.
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

    /// <summary>
    /// The end date of the usage period in which this measurement resides (for entitlements
    /// with a reset period)
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

    /// <summary>
    /// The start date of the usage period in which this measurement resides (for
    /// entitlements with a reset period)
    /// </summary>
    public DateTimeOffset? UsagePeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("usagePeriodStart");
        }
        init { this._rawData.Set("usagePeriodStart", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CustomerID;
        _ = this.FeatureID;
        _ = this.Timestamp;
        _ = this.Value;
        this.Credit?.Validate();
        _ = this.CurrentUsage;
        _ = this.NextResetDate;
        _ = this.ResourceID;
        _ = this.UsagePeriodEnd;
        _ = this.UsagePeriodStart;
    }

    public DataUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataUsage(DataUsage dataUsage)
        : base(dataUsage) { }
#pragma warning restore CS8618

    public DataUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataUsageFromRaw.FromRawUnchecked"/>
    public static DataUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataUsageFromRaw : IFromRawJson<DataUsage>
{
    /// <inheritdoc/>
    public DataUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataUsage.FromRawUnchecked(rawData);
}

/// <summary>
/// The credits this measurement deducted. `null` when the measurement drew from no
/// wallet listed in `credits`. The balance of the wallet it drew from is in the response
/// `credits` list, matched by customer, resource and currency.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Credit, CreditFromRaw>))]
public sealed record class Credit : JsonModel
{
    /// <summary>
    /// The credits this single reportUsage call deducted, in credit units — scoped
    /// to this one measurement (0 for idempotency duplicates). Contrast `currentUsage`,
    /// which is the wallet-wide running total shared across all features on this
    /// currency. Use it to reconcile expected per-call deductions.
    /// </summary>
    public required double Consumed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("consumed");
        }
        init { this._rawData.Set("consumed", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Consumed;
        _ = this.CurrencyID;
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
/// Optimistic credit balance of one wallet (customer, resource and currency) after
/// the request, listed once however many measurements drew from it
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataCredit, DataCreditFromRaw>))]
public sealed record class DataCredit : JsonModel
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
    /// Customer id
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
    /// The wallet's resource; `null` for the customer-level wallet
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
        _ = this.CustomerID;
        _ = this.ResourceID;
        _ = this.Timestamp;
        _ = this.UsageLimit;
        _ = this.UsagePeriodEnd;
    }

    public DataCredit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataCredit(DataCredit dataCredit)
        : base(dataCredit) { }
#pragma warning restore CS8618

    public DataCredit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataCredit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataCreditFromRaw.FromRawUnchecked"/>
    public static DataCredit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataCreditFromRaw : IFromRawJson<DataCredit>
{
    /// <inheritdoc/>
    public DataCredit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataCredit.FromRawUnchecked(rawData);
}

/// <summary>
/// The usage counted against one governance entitlement
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Entity, EntityFromRaw>))]
public sealed record class Entity : JsonModel
{
    /// <summary>
    /// The absolute usage counted against the entitlement
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
    /// The customer whose usage counted towards the entitlement
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
    /// The governance entitlement the usage counts towards
    /// </summary>
    public required string EntitlementID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entitlementId");
        }
        init { this._rawData.Set("entitlementId", value); }
    }

    /// <summary>
    /// The governance entity the entitlement belongs to
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entityId");
        }
        init { this._rawData.Set("entityId", value); }
    }

    /// <summary>
    /// The customer resource the usage counted from; `null` for customer-level usage
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
    /// The entities the entitlement is scoped to (empty when it is not scoped)
    /// </summary>
    public required IReadOnlyList<string> ScopeEntityIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("scopeEntityIds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "scopeEntityIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When the entitlement usage was last updated
    /// </summary>
    public required DateTimeOffset UsageUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("usageUpdatedAt");
        }
        init { this._rawData.Set("usageUpdatedAt", value); }
    }

    /// <summary>
    /// The credit currency the entitlement governs (exactly one of featureId and
    /// currencyId is set)
    /// </summary>
    public string? CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currencyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currencyId", value);
        }
    }

    /// <summary>
    /// The feature the entitlement governs (exactly one of featureId and currencyId
    /// is set)
    /// </summary>
    public string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("featureId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrentUsage;
        _ = this.CustomerID;
        _ = this.EntitlementID;
        _ = this.EntityID;
        _ = this.ResourceID;
        _ = this.ScopeEntityIds;
        _ = this.UsageUpdatedAt;
        _ = this.CurrencyID;
        _ = this.FeatureID;
    }

    public Entity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entity(Entity entity)
        : base(entity) { }
#pragma warning restore CS8618

    public Entity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityFromRaw.FromRawUnchecked"/>
    public static Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntityFromRaw : IFromRawJson<Entity>
{
    /// <inheritdoc/>
    public Entity FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entity.FromRawUnchecked(rawData);
}
