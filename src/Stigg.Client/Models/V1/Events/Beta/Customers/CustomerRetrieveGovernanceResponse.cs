using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.Beta.Customers;

/// <summary>
/// Paginated list of governance tree nodes, each with its usage configuration and
/// current usage.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerRetrieveGovernanceResponse,
        CustomerRetrieveGovernanceResponseFromRaw
    >)
)]
public sealed record class CustomerRetrieveGovernanceResponse : JsonModel
{
    public required IReadOnlyList<Data> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Data>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Pagination.Validate();
    }

    public CustomerRetrieveGovernanceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerRetrieveGovernanceResponse(
        CustomerRetrieveGovernanceResponse customerRetrieveGovernanceResponse
    )
        : base(customerRetrieveGovernanceResponse) { }
#pragma warning restore CS8618

    public CustomerRetrieveGovernanceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerRetrieveGovernanceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerRetrieveGovernanceResponseFromRaw.FromRawUnchecked"/>
    public static CustomerRetrieveGovernanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerRetrieveGovernanceResponseFromRaw : IFromRawJson<CustomerRetrieveGovernanceResponse>
{
    /// <inheritdoc/>
    public CustomerRetrieveGovernanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerRetrieveGovernanceResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A node of the governance hierarchy tree with its usage configuration (limit,
/// cadence, scope) and current usage. Usage is read from a periodically-refreshed
/// read model and may lag the live counter by a short interval; it never gates access.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Usage-reset cadence as an ISO-8601 single-unit duration, e.g. `P1M`, `P30D`,
    /// `PT1M`; `null` when the node has no usage configuration.
    /// </summary>
    public required string? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// Usage consumed in the current cadence period (may lag the live counter by
    /// a short interval).
    /// </summary>
    public required double? CurrentUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("currentUsage");
        }
        init { this._rawData.Set("currentUsage", value); }
    }

    /// <summary>
    /// Human-readable name of the entity, or null when none is set (display the entity
    /// id instead).
    /// </summary>
    public required string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayName");
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <summary>
    /// External id of the entity at this node.
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
    /// External id of the entity type (e.g. `team`, `user`).
    /// </summary>
    public required string EntityTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entityTypeId");
        }
        init { this._rawData.Set("entityTypeId", value); }
    }

    /// <summary>
    /// External id of the parent entity in the tree. `null` means the entity is
    /// either a root or not yet placed in the hierarchy — placement rides on an assignment,
    /// so an entity with no limits set has no parent yet. Both render at the top
    /// level; use it to rebuild the tree.
    /// </summary>
    public required string? ParentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parentId");
        }
        init { this._rawData.Set("parentId", value); }
    }

    /// <summary>
    /// The configuration scope (entity ids). Empty is the node-wide configuration;
    /// a non-empty set is a dimension-scoped sub-configuration.
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
    /// Hard usage limit for this node per cadence period.
    /// </summary>
    public required double? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <summary>
    /// Exclusive end of the cadence period in progress now — when usage resets. `null`
    /// when the node has no usage configuration, or when a stored cadence cannot
    /// be parsed.
    /// </summary>
    public required DateTimeOffset? UsagePeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("usagePeriodEnd");
        }
        init { this._rawData.Set("usagePeriodEnd", value); }
    }

    /// <summary>
    /// Start of the cadence period in progress now, derived from the cadence and
    /// the assignment anchor — it stays correct across a rollover. `null` when the
    /// node has no usage configuration, or when a stored cadence cannot be parsed.
    /// </summary>
    public required DateTimeOffset? UsagePeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("usagePeriodStart");
        }
        init { this._rawData.Set("usagePeriodStart", value); }
    }

    /// <summary>
    /// `currentUsage / usageLimit` (1 when usageLimit is 0 — always at limit). The
    /// cross-capability-safe sort key.
    /// </summary>
    public required double? Utilization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("utilization");
        }
        init { this._rawData.Set("utilization", value); }
    }

    /// <summary>
    /// The metered currency ID (present when the configured capability is a credit currency).
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
    /// The metered feature ID (present when the configured capability is a feature).
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
        _ = this.Cadence;
        _ = this.CurrentUsage;
        _ = this.DisplayName;
        _ = this.EntityID;
        _ = this.EntityTypeID;
        _ = this.ParentID;
        _ = this.ScopeEntityIds;
        _ = this.UsageLimit;
        _ = this.UsagePeriodEnd;
        _ = this.UsagePeriodStart;
        _ = this.Utilization;
        _ = this.CurrencyID;
        _ = this.FeatureID;
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

[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor for fetching the next page of results, or null if no additional pages exist
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Next;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Pagination(string? next)
        : this()
    {
        this.Next = next;
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}
