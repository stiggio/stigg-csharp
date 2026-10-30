using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Customers.Entities.Entitlements;

/// <summary>
/// Batched create-or-update of entity entitlements. Existing entity entitlements
/// matched by (entityId, featureId or currencyId, scopeEntityIds) are updated; new
/// ones are created. On update, omitted fields (usageLimit, cadence) are preserved;
/// on create both are required.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntitlementUpsertParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Entity entitlements to upsert (1–100 per request)
    /// </summary>
    public required IReadOnlyList<EntityEntitlement> EntityEntitlements
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<EntityEntitlement>>(
                "entityEntitlements"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<EntityEntitlement>>(
                "entityEntitlements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? XAccountID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ACCOUNT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ACCOUNT-ID", value);
        }
    }

    public string? XEnvironmentID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ENVIRONMENT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ENVIRONMENT-ID", value);
        }
    }

    public EntitlementUpsertParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementUpsertParams(EntitlementUpsertParams entitlementUpsertParams)
        : base(entitlementUpsertParams)
    {
        this.ID = entitlementUpsertParams.ID;

        this._rawBodyData = new(entitlementUpsertParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EntitlementUpsertParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementUpsertParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntitlementUpsertParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EntitlementUpsertParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/customers/{0}/entities/entitlements", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// A single entity entitlement to create or update. Identify the feature or currency
/// with exactly one of `featureId` or `currencyId`. The natural key is the `(entityId,
/// featureId or currencyId, scopeEntityIds)` triple. On create both `usageLimit`
/// and `cadence` are required; on update they may be omitted individually to preserve
/// the existing value.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EntityEntitlement, EntityEntitlementFromRaw>))]
public sealed record class EntityEntitlement : JsonModel
{
    /// <summary>
    /// The entity ID this entity entitlement is attached to
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
    /// Usage-reset cadence (required on create) as an ISO-8601 single-unit duration,
    /// e.g. `P1M`, `P30D`, `PT1M`.
    /// </summary>
    public string? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cadence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cadence", value);
        }
    }

    /// <summary>
    /// Currency ID this entity entitlement grants (credit limits). Mutually exclusive
    /// with `featureId`.
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
    /// Feature ID this entity entitlement grants. Mutually exclusive with `currencyId`.
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

    /// <summary>
    /// Parent entity ID in the hierarchy. Omit to leave the current parent untouched
    /// (a new node defaults to a root); `null` detaches to a root; an ID sets or
    /// changes the parent. Reparenting or detaching an existing node is leaf-only;
    /// place a parent before its children, or in the same batch.
    /// </summary>
    public string? ParentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parentId");
        }
        init { this._rawData.Set("parentId", value); }
    }

    /// <summary>
    /// Dimension-scoped sub-limit: the set of entity IDs this limit applies to (order-insensitive,
    /// unique, at most 5). Omit or leave empty for the node-wide limit.
    /// </summary>
    public IReadOnlyList<string>? ScopeEntityIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("scopeEntityIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "scopeEntityIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Maximum usage allowed within one cadence window (required on create)
    /// </summary>
    public double? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EntityID;
        _ = this.Cadence;
        _ = this.CurrencyID;
        _ = this.FeatureID;
        _ = this.ParentID;
        _ = this.ScopeEntityIds;
        _ = this.UsageLimit;
    }

    public EntityEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityEntitlement(EntityEntitlement entityEntitlement)
        : base(entityEntitlement) { }
#pragma warning restore CS8618

    public EntityEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntityEntitlementFromRaw.FromRawUnchecked"/>
    public static EntityEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EntityEntitlement(string entityID)
        : this()
    {
        this.EntityID = entityID;
    }
}

class EntityEntitlementFromRaw : IFromRawJson<EntityEntitlement>
{
    /// <inheritdoc/>
    public EntityEntitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EntityEntitlement.FromRawUnchecked(rawData);
}
