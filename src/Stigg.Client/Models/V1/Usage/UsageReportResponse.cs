using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Usage;

/// <summary>
/// Response containing reported usage measurements with current usage values, period
/// information, and reset dates for each measurement.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageReportResponse, UsageReportResponseFromRaw>))]
public sealed record class UsageReportResponse : JsonModel
{
    /// <summary>
    /// Array of usage measurements with current values and period info
    /// </summary>
    public required IReadOnlyList<UsageReportResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UsageReportResponseData>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UsageReportResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
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
    public UsageReportResponse(IReadOnlyList<UsageReportResponseData> data)
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
/// Recorded usage with period info
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UsageReportResponseData, UsageReportResponseDataFromRaw>))]
public sealed record class UsageReportResponseData : JsonModel
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
    /// Resource id
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
        _ = this.CurrentUsage;
        _ = this.NextResetDate;
        _ = this.ResourceID;
        _ = this.UsagePeriodEnd;
        _ = this.UsagePeriodStart;
    }

    public UsageReportResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageReportResponseData(UsageReportResponseData usageReportResponseData)
        : base(usageReportResponseData) { }
#pragma warning restore CS8618

    public UsageReportResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageReportResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageReportResponseDataFromRaw.FromRawUnchecked"/>
    public static UsageReportResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageReportResponseDataFromRaw : IFromRawJson<UsageReportResponseData>
{
    /// <inheritdoc/>
    public UsageReportResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageReportResponseData.FromRawUnchecked(rawData);
}
