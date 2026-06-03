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

namespace Stigg.Client.Models.V1Beta.EntityTypes;

/// <summary>
/// Batched create-or-update of entity types. Existing types matched by id are updated;
/// new ids are created. Idempotent — re-submitting the same payload converges to
/// the same state.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntityTypeUpsertParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Entity types to upsert (1–100 per request)
    /// </summary>
    public required IReadOnlyList<global::Stigg.Client.Models.V1Beta.EntityTypes.Type> Types
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<
                ImmutableArray<global::Stigg.Client.Models.V1Beta.EntityTypes.Type>
            >("types");
        }
        init
        {
            this._rawBodyData.Set<
                ImmutableArray<global::Stigg.Client.Models.V1Beta.EntityTypes.Type>
            >("types", ImmutableArray.ToImmutableArray(value));
        }
    }

    public EntityTypeUpsertParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityTypeUpsertParams(EntityTypeUpsertParams entityTypeUpsertParams)
        : base(entityTypeUpsertParams)
    {
        this._rawBodyData = new(entityTypeUpsertParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EntityTypeUpsertParams(
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
    EntityTypeUpsertParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntityTypeUpsertParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(EntityTypeUpsertParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1-beta/entity-types")
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
/// A single entity type definition.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<global::Stigg.Client.Models.V1Beta.EntityTypes.Type, TypeFromRaw>)
)]
public sealed record class Type : JsonModel
{
    /// <summary>
    /// The unique identifier for the entity
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
    /// Dimension keys used to attribute usage events to instances of this type (e.g.
    /// ["orgId"]). Empty array means no attribution.
    /// </summary>
    public required IReadOnlyList<string> AttributionKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("attributionKeys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "attributionKeys",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The display name for the entity type
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("displayName");
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AttributionKeys;
        _ = this.DisplayName;
    }

    public Type() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Type(global::Stigg.Client.Models.V1Beta.EntityTypes.Type type)
        : base(type) { }
#pragma warning restore CS8618

    public Type(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Type(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TypeFromRaw.FromRawUnchecked"/>
    public static global::Stigg.Client.Models.V1Beta.EntityTypes.Type FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TypeFromRaw : IFromRawJson<global::Stigg.Client.Models.V1Beta.EntityTypes.Type>
{
    /// <inheritdoc/>
    public global::Stigg.Client.Models.V1Beta.EntityTypes.Type FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Stigg.Client.Models.V1Beta.EntityTypes.Type.FromRawUnchecked(rawData);
}
