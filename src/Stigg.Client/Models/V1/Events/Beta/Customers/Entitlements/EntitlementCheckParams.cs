using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.Beta.Customers.Entitlements;

/// <summary>
/// Experimental — request and response shapes may change without notice. Same semantics
/// as `Check entitlement`, plus an optional `dimensions` query param that resolves
/// to per-entity governance limits surfaced as `chains` on the response.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntitlementCheckParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Currency ID (refId) to check for credit entitlements. Mutually exclusive
    /// with `featureId`.
    /// </summary>
    public string? CurrencyID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("currencyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("currencyId", value);
        }
    }

    /// <summary>
    /// Optional attribution map (e.g. `dimensions[userId]=u1`). When provided, the
    /// response includes a `chains` array with per-entity governance limits.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Dimensions
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<FrozenDictionary<string, string>>(
                "dimensions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<FrozenDictionary<string, string>?>(
                "dimensions",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Feature ID (refId) to check. Mutually exclusive with `currencyId`.
    /// </summary>
    public string? FeatureID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("featureId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("featureId", value);
        }
    }

    /// <summary>
    /// Requested usage amount to evaluate against the entitlement limit (numeric
    /// features only)
    /// </summary>
    public long? RequestedUsage
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("requestedUsage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("requestedUsage", value);
        }
    }

    /// <summary>
    /// Requested values to evaluate against allowed values (enum features only)
    /// </summary>
    public IReadOnlyList<string>? RequestedValues
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("requestedValues");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "requestedValues",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Resource ID to scope the entitlement check to a specific resource
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("resourceId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("resourceId", value);
        }
    }

    public EntitlementCheckParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntitlementCheckParams(EntitlementCheckParams entitlementCheckParams)
        : base(entitlementCheckParams)
    {
        this.ID = entitlementCheckParams.ID;
    }
#pragma warning restore CS8618

    public EntitlementCheckParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntitlementCheckParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntitlementCheckParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EntitlementCheckParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1-beta/customers/{0}/entitlements/check", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
