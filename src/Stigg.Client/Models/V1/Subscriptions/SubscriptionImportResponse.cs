using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Subscriptions;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SubscriptionImportResponse, SubscriptionImportResponseFromRaw>)
)]
public sealed record class SubscriptionImportResponse : JsonModel
{
    public required SubscriptionImportResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubscriptionImportResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SubscriptionImportResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionImportResponse(SubscriptionImportResponse subscriptionImportResponse)
        : base(subscriptionImportResponse) { }
#pragma warning restore CS8618

    public SubscriptionImportResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionImportResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionImportResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionImportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionImportResponse(SubscriptionImportResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SubscriptionImportResponseFromRaw : IFromRawJson<SubscriptionImportResponse>
{
    /// <inheritdoc/>
    public SubscriptionImportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionImportResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionImportResponseData,
        SubscriptionImportResponseDataFromRaw
    >)
)]
public sealed record class SubscriptionImportResponseData : JsonModel
{
    /// <summary>
    /// Unique identifier for the import task
    /// </summary>
    public required string TaskID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("taskId");
        }
        init { this._rawData.Set("taskId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TaskID;
    }

    public SubscriptionImportResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionImportResponseData(
        SubscriptionImportResponseData subscriptionImportResponseData
    )
        : base(subscriptionImportResponseData) { }
#pragma warning restore CS8618

    public SubscriptionImportResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionImportResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionImportResponseDataFromRaw.FromRawUnchecked"/>
    public static SubscriptionImportResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionImportResponseData(string taskID)
        : this()
    {
        this.TaskID = taskID;
    }
}

class SubscriptionImportResponseDataFromRaw : IFromRawJson<SubscriptionImportResponseData>
{
    /// <inheritdoc/>
    public SubscriptionImportResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionImportResponseData.FromRawUnchecked(rawData);
}
