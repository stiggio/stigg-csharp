using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Events.Credits;

/// <summary>
/// Retrieves credit usage time-series data for a customer, grouped by feature, over
/// a specified time range.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditGetUsageParams : ParamsBase
{
    /// <summary>
    /// Filter by customer ID (required)
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("customerId");
        }
        init { this._rawQueryData.Set("customerId", value); }
    }

    /// <summary>
    /// Filter by currency ID
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
    /// Filter by resource ID
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

    /// <summary>
    /// Time range for usage data (LAST_DAY, LAST_WEEK, LAST_MONTH, LAST_YEAR). Defaults
    /// to LAST_MONTH
    /// </summary>
    public ApiEnum<string, TimeRange>? TimeRange
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TimeRange>>("timeRange");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("timeRange", value);
        }
    }

    public CreditGetUsageParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditGetUsageParams(CreditGetUsageParams creditGetUsageParams)
        : base(creditGetUsageParams) { }
#pragma warning restore CS8618

    public CreditGetUsageParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditGetUsageParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CreditGetUsageParams FromRawUnchecked(
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

    public virtual bool Equals(CreditGetUsageParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/credits/usage")
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
/// Time range for usage data (LAST_DAY, LAST_WEEK, LAST_MONTH, LAST_YEAR). Defaults
/// to LAST_MONTH
/// </summary>
[JsonConverter(typeof(TimeRangeConverter))]
public enum TimeRange
{
    LastDay,
    LastWeek,
    LastMonth,
    LastYear,
}

sealed class TimeRangeConverter : JsonConverter<TimeRange>
{
    public override TimeRange Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LAST_DAY" => TimeRange.LastDay,
            "LAST_WEEK" => TimeRange.LastWeek,
            "LAST_MONTH" => TimeRange.LastMonth,
            "LAST_YEAR" => TimeRange.LastYear,
            _ => (TimeRange)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TimeRange value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TimeRange.LastDay => "LAST_DAY",
                TimeRange.LastWeek => "LAST_WEEK",
                TimeRange.LastMonth => "LAST_MONTH",
                TimeRange.LastYear => "LAST_YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
