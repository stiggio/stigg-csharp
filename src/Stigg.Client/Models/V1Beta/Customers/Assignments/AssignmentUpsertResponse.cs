using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1Beta.Customers.Assignments;

/// <summary>
/// Assignments after upsert.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AssignmentUpsertResponse, AssignmentUpsertResponseFromRaw>)
)]
public sealed record class AssignmentUpsertResponse : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public AssignmentUpsertResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssignmentUpsertResponse(AssignmentUpsertResponse assignmentUpsertResponse)
        : base(assignmentUpsertResponse) { }
#pragma warning restore CS8618

    public AssignmentUpsertResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AssignmentUpsertResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssignmentUpsertResponseFromRaw.FromRawUnchecked"/>
    public static AssignmentUpsertResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AssignmentUpsertResponse(IReadOnlyList<Data> data)
        : this()
    {
        this.Data = data;
    }
}

class AssignmentUpsertResponseFromRaw : IFromRawJson<AssignmentUpsertResponse>
{
    /// <inheritdoc/>
    public AssignmentUpsertResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AssignmentUpsertResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A capability assignment for an entity belonging to a customer. Defines how much
/// of the capability the entity may consume (`usageLimit`) and how often the counter
/// resets (`cadence`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Synthetic UUID identifier — also the cursor anchor for paginated lists
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
    /// Usage-reset cadence as an ISO-8601 single-unit duration, e.g. `P1M`, `P30D`, `PT1M`.
    /// </summary>
    public required string Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cadence");
        }
        init { this._rawData.Set("cadence", value); }
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
    /// The entity ID this assignment is attached to
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
    /// Parent entity ID in the hierarchy, or `null` for a root.
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
    /// Dimension-scoped sub-budget key: the set of entity IDs this budget applies
    /// to. Empty is the node-wide budget that always matches; a non-empty set only
    /// applies when every listed entity is present in the resolved set (order-insensitive).
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
    /// Timestamp of when the record was last updated
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Maximum usage allowed within one cadence window
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
    /// Currency ID this assignment grants (present for credit capabilities).
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
    /// Feature ID this assignment grants (present for feature capabilities).
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
        _ = this.ID;
        _ = this.Cadence;
        _ = this.CreatedAt;
        _ = this.EntityID;
        _ = this.ParentID;
        _ = this.ScopeEntityIds;
        _ = this.UpdatedAt;
        _ = this.UsageLimit;
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
