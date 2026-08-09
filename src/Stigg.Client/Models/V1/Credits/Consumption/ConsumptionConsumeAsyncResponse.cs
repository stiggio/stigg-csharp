using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Credits.Consumption;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConsumptionConsumeAsyncResponse,
        ConsumptionConsumeAsyncResponseFromRaw
    >)
)]
public sealed record class ConsumptionConsumeAsyncResponse : JsonModel
{
    /// <summary>
    /// Confirmation that the credit consumptions were accepted for processing
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

    public ConsumptionConsumeAsyncResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConsumptionConsumeAsyncResponse(
        ConsumptionConsumeAsyncResponse consumptionConsumeAsyncResponse
    )
        : base(consumptionConsumeAsyncResponse) { }
#pragma warning restore CS8618

    public ConsumptionConsumeAsyncResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumptionConsumeAsyncResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConsumptionConsumeAsyncResponseFromRaw.FromRawUnchecked"/>
    public static ConsumptionConsumeAsyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConsumptionConsumeAsyncResponse(JsonElement data)
        : this()
    {
        this.Data = data;
    }
}

class ConsumptionConsumeAsyncResponseFromRaw : IFromRawJson<ConsumptionConsumeAsyncResponse>
{
    /// <inheritdoc/>
    public ConsumptionConsumeAsyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConsumptionConsumeAsyncResponse.FromRawUnchecked(rawData);
}
