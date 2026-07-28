using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// Retrieves a cursor-paginated list of a customer's invoices, fetched live from
/// the connected billing provider. Ordered by issue date ascending by default; override
/// with orderBy (issueDate | dueDate | total) and orderDir (ASC | DESC). Optionally
/// narrowed to one contract, an issue-date range, and/or a set of invoice states.
/// Returns an empty list when no billing provider is connected or the customer is
/// not synced.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomerListInvoicesParams : ParamsBase
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
    /// Return items that come before this cursor
    /// </summary>
    public string? Before
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("before", value);
        }
    }

    /// <summary>
    /// Filter to invoices for this contract only (contract external ID or Received
    /// contract ID). Omit for all contracts.
    /// </summary>
    public string? ContractExternalID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("contractExternalId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("contractExternalId", value);
        }
    }

    /// <summary>
    /// Filter to invoices issued on or after this date, inclusive (ISO 8601)
    /// </summary>
    public System::DateTimeOffset? IssuedAfter
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("issuedAfter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("issuedAfter", value);
        }
    }

    /// <summary>
    /// Filter to invoices issued on or before this date, inclusive (ISO 8601)
    /// </summary>
    public System::DateTimeOffset? IssuedBefore
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("issuedBefore");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("issuedBefore", value);
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
    /// Field to sort by: issueDate (default), dueDate, or total
    /// </summary>
    public ApiEnum<string, OrderBy>? OrderBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, OrderBy>>("orderBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("orderBy", value);
        }
    }

    /// <summary>
    /// Sort direction: ASC (default) or DESC
    /// </summary>
    public ApiEnum<string, OrderDir>? OrderDir
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, OrderDir>>("orderDir");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("orderDir", value);
        }
    }

    /// <summary>
    /// Filter by invoice state. Supports comma-separated values for multiple states
    /// </summary>
    public string? StateIn
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("stateIn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("stateIn", value);
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

    public CustomerListInvoicesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListInvoicesParams(CustomerListInvoicesParams customerListInvoicesParams)
        : base(customerListInvoicesParams)
    {
        this.ID = customerListInvoicesParams.ID;
    }
#pragma warning restore CS8618

    public CustomerListInvoicesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListInvoicesParams(
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
    public static CustomerListInvoicesParams FromRawUnchecked(
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

    public virtual bool Equals(CustomerListInvoicesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/customers/{0}/invoices", this.ID)
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
/// Field to sort by: issueDate (default), dueDate, or total
/// </summary>
[JsonConverter(typeof(OrderByConverter))]
public enum OrderBy
{
    IssueDate,
    DueDate,
    Total,
}

sealed class OrderByConverter : JsonConverter<OrderBy>
{
    public override OrderBy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issueDate" => OrderBy.IssueDate,
            "dueDate" => OrderBy.DueDate,
            "total" => OrderBy.Total,
            _ => (OrderBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, OrderBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OrderBy.IssueDate => "issueDate",
                OrderBy.DueDate => "dueDate",
                OrderBy.Total => "total",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort direction: ASC (default) or DESC
/// </summary>
[JsonConverter(typeof(OrderDirConverter))]
public enum OrderDir
{
    Asc,
    Desc,
}

sealed class OrderDirConverter : JsonConverter<OrderDir>
{
    public override OrderDir Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ASC" => OrderDir.Asc,
            "DESC" => OrderDir.Desc,
            _ => (OrderDir)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, OrderDir value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OrderDir.Asc => "ASC",
                OrderDir.Desc => "DESC",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
