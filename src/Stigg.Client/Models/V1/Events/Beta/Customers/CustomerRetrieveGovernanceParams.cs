using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Events.Beta.Customers;

/// <summary>
/// Queries the customer's governance hierarchy tree, returning a cursor-paginated
/// list of nodes with their usage configuration (limit, cadence, scope) and current
/// usage, sortable and filterable by usage. Each node carries `parentId` so the tree
/// can be rebuilt client-side. Usage is read from a periodically-refreshed read model
/// and never gates access.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomerRetrieveGovernanceParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Return items that come after this cursor
    /// </summary>
    public string? After
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("after", value);
        }
    }

    /// <summary>
    /// Currency ids to include, repeated per value (e.g. `?currencyIds=credits`).
    /// Omit both featureIds and currencyIds for tree mode.
    /// </summary>
    public IReadOnlyList<string>? CurrencyIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("currencyIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "currencyIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Case-insensitive substring match on the entity id or its display name (`%`/`_`
    /// matched literally).
    /// </summary>
    public string? EntityIDSearch
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("entityIdSearch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("entityIdSearch", value);
        }
    }

    /// <summary>
    /// Filter to one or more entity types, repeated per value (e.g. `?entityTypeIds=team&amp;entityTypeIds=user`).
    /// </summary>
    public IReadOnlyList<string>? EntityTypeIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("entityTypeIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "entityTypeIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Feature ids to include, repeated per value (e.g. `?featureIds=ai-tokens&amp;featureIds=seats`).
    /// Omit both featureIds and currencyIds for tree mode — every node in the hierarchy
    /// with no usage configuration attached.
    /// </summary>
    public IReadOnlyList<string>? FeatureIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("featureIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "featureIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Maximum number of items to return
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Only nodes with utilization ≥ this value (e.g. 0.8 for ≥80%, 1 for at/over limit).
    /// </summary>
    public double? MinUtilization
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("minUtilization");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("minUtilization", value);
        }
    }

    /// <summary>
    /// Sort direction: `asc` or `desc` (default `desc`).
    /// </summary>
    public ApiEnum<string, Order>? Order
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Order>>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("order", value);
        }
    }

    /// <summary>
    /// Filter by configuration scope: `all` (default), `nodeWide` (`[]` only), or
    /// `scoped` (non-empty only).
    /// </summary>
    public ApiEnum<string, Scope>? Scope
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Scope>>("scope");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("scope", value);
        }
    }

    /// <summary>
    /// Sort key: `utilization` (default, cross-capability-safe), `currentUsage`,
    /// `usageLimit`, `scopeSize`, `id`, or `createdAt`.
    /// </summary>
    public ApiEnum<string, SortBy>? SortBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortBy>>("sortBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sortBy", value);
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

    public CustomerRetrieveGovernanceParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerRetrieveGovernanceParams(
        CustomerRetrieveGovernanceParams customerRetrieveGovernanceParams
    )
        : base(customerRetrieveGovernanceParams)
    {
        this.ID = customerRetrieveGovernanceParams.ID;
    }
#pragma warning restore CS8618

    public CustomerRetrieveGovernanceParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerRetrieveGovernanceParams(
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
    public static CustomerRetrieveGovernanceParams FromRawUnchecked(
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

    public virtual bool Equals(CustomerRetrieveGovernanceParams? other)
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
                + string.Format("/api/v1-beta/customers/{0}/governance", this.ID)
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

/// <summary>
/// Sort direction: `asc` or `desc` (default `desc`).
/// </summary>
[JsonConverter(typeof(OrderConverter))]
public enum Order
{
    Asc,
    Desc,
}

sealed class OrderConverter : JsonConverter<Order>
{
    public override Order Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => Order.Asc,
            "desc" => Order.Desc,
            _ => (Order)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Order value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Order.Asc => "asc",
                Order.Desc => "desc",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter by configuration scope: `all` (default), `nodeWide` (`[]` only), or `scoped`
/// (non-empty only).
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    All,
    NodeWide,
    Scoped,
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => Scope.All,
            "nodeWide" => Scope.NodeWide,
            "scoped" => Scope.Scoped,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.All => "all",
                Scope.NodeWide => "nodeWide",
                Scope.Scoped => "scoped",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort key: `utilization` (default, cross-capability-safe), `currentUsage`, `usageLimit`,
/// `scopeSize`, `id`, or `createdAt`.
/// </summary>
[JsonConverter(typeof(SortByConverter))]
public enum SortBy
{
    Utilization,
    CurrentUsage,
    UsageLimit,
    ScopeSize,
    ID,
    CreatedAt,
}

sealed class SortByConverter : JsonConverter<SortBy>
{
    public override SortBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "utilization" => SortBy.Utilization,
            "currentUsage" => SortBy.CurrentUsage,
            "usageLimit" => SortBy.UsageLimit,
            "scopeSize" => SortBy.ScopeSize,
            "id" => SortBy.ID,
            "createdAt" => SortBy.CreatedAt,
            _ => (SortBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, SortBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortBy.Utilization => "utilization",
                SortBy.CurrentUsage => "currentUsage",
                SortBy.UsageLimit => "usageLimit",
                SortBy.ScopeSize => "scopeSize",
                SortBy.ID => "id",
                SortBy.CreatedAt => "createdAt",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
