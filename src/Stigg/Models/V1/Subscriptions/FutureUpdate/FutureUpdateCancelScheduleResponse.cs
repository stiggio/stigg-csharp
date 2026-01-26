using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;

namespace Stigg.Models.V1.Subscriptions.FutureUpdate;

[JsonConverter(
    typeof(JsonModelConverter<
        FutureUpdateCancelScheduleResponse,
        FutureUpdateCancelScheduleResponseFromRaw
    >)
)]
public sealed record class FutureUpdateCancelScheduleResponse : JsonModel
{
    public required FutureUpdateCancelScheduleResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FutureUpdateCancelScheduleResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public FutureUpdateCancelScheduleResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FutureUpdateCancelScheduleResponse(
        FutureUpdateCancelScheduleResponse futureUpdateCancelScheduleResponse
    )
        : base(futureUpdateCancelScheduleResponse) { }
#pragma warning restore CS8618

    public FutureUpdateCancelScheduleResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FutureUpdateCancelScheduleResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FutureUpdateCancelScheduleResponseFromRaw.FromRawUnchecked"/>
    public static FutureUpdateCancelScheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FutureUpdateCancelScheduleResponse(FutureUpdateCancelScheduleResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class FutureUpdateCancelScheduleResponseFromRaw : IFromRawJson<FutureUpdateCancelScheduleResponse>
{
    /// <inheritdoc/>
    public FutureUpdateCancelScheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FutureUpdateCancelScheduleResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FutureUpdateCancelScheduleResponseData,
        FutureUpdateCancelScheduleResponseDataFromRaw
    >)
)]
public sealed record class FutureUpdateCancelScheduleResponseData : JsonModel
{
    /// <summary>
    /// Subscription ID
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public FutureUpdateCancelScheduleResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FutureUpdateCancelScheduleResponseData(
        FutureUpdateCancelScheduleResponseData futureUpdateCancelScheduleResponseData
    )
        : base(futureUpdateCancelScheduleResponseData) { }
#pragma warning restore CS8618

    public FutureUpdateCancelScheduleResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FutureUpdateCancelScheduleResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FutureUpdateCancelScheduleResponseDataFromRaw.FromRawUnchecked"/>
    public static FutureUpdateCancelScheduleResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FutureUpdateCancelScheduleResponseData(string id)
        : this()
    {
        this.ID = id;
    }
}

class FutureUpdateCancelScheduleResponseDataFromRaw
    : IFromRawJson<FutureUpdateCancelScheduleResponseData>
{
    /// <inheritdoc/>
    public FutureUpdateCancelScheduleResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FutureUpdateCancelScheduleResponseData.FromRawUnchecked(rawData);
}
