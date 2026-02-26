using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Events.Addons;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SetPackagePricingResponse, SetPackagePricingResponseFromRaw>)
)]
public sealed record class SetPackagePricingResponse : JsonModel
{
    /// <summary>
    /// Result of setting package pricing.
    /// </summary>
    public required SetPackagePricingResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SetPackagePricingResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public SetPackagePricingResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingResponse(SetPackagePricingResponse setPackagePricingResponse)
        : base(setPackagePricingResponse) { }
#pragma warning restore CS8618

    public SetPackagePricingResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingResponseFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SetPackagePricingResponse(SetPackagePricingResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class SetPackagePricingResponseFromRaw : IFromRawJson<SetPackagePricingResponse>
{
    /// <inheritdoc/>
    public SetPackagePricingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of setting package pricing.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SetPackagePricingResponseData, SetPackagePricingResponseDataFromRaw>)
)]
public sealed record class SetPackagePricingResponseData : JsonModel
{
    /// <summary>
    /// The package identifier (refId)
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
    /// The pricing type that was set
    /// </summary>
    public required ApiEnum<string, SetPackagePricingResponseDataPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SetPackagePricingResponseDataPricingType>
            >("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.PricingType.Validate();
    }

    public SetPackagePricingResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SetPackagePricingResponseData(
        SetPackagePricingResponseData setPackagePricingResponseData
    )
        : base(setPackagePricingResponseData) { }
#pragma warning restore CS8618

    public SetPackagePricingResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SetPackagePricingResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SetPackagePricingResponseDataFromRaw.FromRawUnchecked"/>
    public static SetPackagePricingResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SetPackagePricingResponseDataFromRaw : IFromRawJson<SetPackagePricingResponseData>
{
    /// <inheritdoc/>
    public SetPackagePricingResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SetPackagePricingResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing type that was set
/// </summary>
[JsonConverter(typeof(SetPackagePricingResponseDataPricingTypeConverter))]
public enum SetPackagePricingResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class SetPackagePricingResponseDataPricingTypeConverter
    : JsonConverter<SetPackagePricingResponseDataPricingType>
{
    public override SetPackagePricingResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => SetPackagePricingResponseDataPricingType.Free,
            "PAID" => SetPackagePricingResponseDataPricingType.Paid,
            "CUSTOM" => SetPackagePricingResponseDataPricingType.Custom,
            _ => (SetPackagePricingResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SetPackagePricingResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SetPackagePricingResponseDataPricingType.Free => "FREE",
                SetPackagePricingResponseDataPricingType.Paid => "PAID",
                SetPackagePricingResponseDataPricingType.Custom => "CUSTOM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
