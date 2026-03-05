using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Usage;

/// <summary>
/// Retrieves historical usage data for a customer's metered feature over time.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UsageHistoryParams : ParamsBase
{
    public required string CustomerID { get; init; }

    public string? FeatureID { get; init; }

    /// <summary>
    /// The start date of the range
    /// </summary>
    public required DateTimeOffset StartDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<DateTimeOffset>("startDate");
        }
        init { this._rawQueryData.Set("startDate", value); }
    }

    /// <summary>
    /// The end date of the range
    /// </summary>
    public DateTimeOffset? EndDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("endDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("endDate", value);
        }
    }

    public string? GroupBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("groupBy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("groupBy", value);
        }
    }

    /// <summary>
    /// When true, includes usage data from the most recent cancelled or expired subscription
    /// </summary>
    public bool? IncludeHistoricalUsage
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("includeHistoricalUsage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("includeHistoricalUsage", value);
        }
    }

    /// <summary>
    /// Resource id
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("resourceId");
        }
        init { this._rawQueryData.Set("resourceId", value); }
    }

    public UsageHistoryParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageHistoryParams(UsageHistoryParams usageHistoryParams)
        : base(usageHistoryParams)
    {
        this.CustomerID = usageHistoryParams.CustomerID;
        this.FeatureID = usageHistoryParams.FeatureID;
    }
#pragma warning restore CS8618

    public UsageHistoryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageHistoryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static UsageHistoryParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CustomerID"] = JsonSerializer.SerializeToElement(this.CustomerID),
                    ["FeatureID"] = JsonSerializer.SerializeToElement(this.FeatureID),
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

    public virtual bool Equals(UsageHistoryParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.CustomerID.Equals(other.CustomerID)
            && (this.FeatureID?.Equals(other.FeatureID) ?? other.FeatureID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/usage/{0}/history/{1}", this.CustomerID, this.FeatureID)
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
