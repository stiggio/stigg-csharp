using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;

namespace Stigg.Models.V1.Subscriptions.FutureUpdate;

[JsonConverter(
    typeof(JsonModelConverter<
        FutureUpdateCancelPendingPaymentResponse,
        FutureUpdateCancelPendingPaymentResponseFromRaw
    >)
)]
public sealed record class FutureUpdateCancelPendingPaymentResponse : JsonModel
{
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public FutureUpdateCancelPendingPaymentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FutureUpdateCancelPendingPaymentResponse(
        FutureUpdateCancelPendingPaymentResponse futureUpdateCancelPendingPaymentResponse
    )
        : base(futureUpdateCancelPendingPaymentResponse) { }
#pragma warning restore CS8618

    public FutureUpdateCancelPendingPaymentResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FutureUpdateCancelPendingPaymentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FutureUpdateCancelPendingPaymentResponseFromRaw.FromRawUnchecked"/>
    public static FutureUpdateCancelPendingPaymentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FutureUpdateCancelPendingPaymentResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class FutureUpdateCancelPendingPaymentResponseFromRaw
    : IFromRawJson<FutureUpdateCancelPendingPaymentResponse>
{
    /// <inheritdoc/>
    public FutureUpdateCancelPendingPaymentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FutureUpdateCancelPendingPaymentResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// external id of the canceled future update subscription
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

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Data(string id)
        : this()
    {
        this.ID = id;
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
