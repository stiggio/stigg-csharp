using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EventReportResponse, EventReportResponseFromRaw>))]
public sealed record class EventReportResponse : JsonModel
{
    /// <summary>
    /// Empty success response confirming that events were successfully ingested and
    /// queued for processing by Stigg's metering system.
    /// </summary>
    public required JsonElement Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotAbsentElement("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
    }

    public EventReportResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventReportResponse(EventReportResponse eventReportResponse)
        : base(eventReportResponse) { }
#pragma warning restore CS8618

    public EventReportResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventReportResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventReportResponseFromRaw.FromRawUnchecked"/>
    public static EventReportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventReportResponse(JsonElement data)
        : this()
    {
        this.Data = data;
    }
}

class EventReportResponseFromRaw : IFromRawJson<EventReportResponse>
{
    /// <inheritdoc/>
    public EventReportResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EventReportResponse.FromRawUnchecked(rawData);
}
