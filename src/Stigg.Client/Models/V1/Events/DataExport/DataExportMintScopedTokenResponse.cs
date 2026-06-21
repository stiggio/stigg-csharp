using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.DataExport;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DataExportMintScopedTokenResponse,
        DataExportMintScopedTokenResponseFromRaw
    >)
)]
public sealed record class DataExportMintScopedTokenResponse : JsonModel
{
    /// <summary>
    /// Scoped token + expiry + provider-specific metadata for the FE SDK.
    /// </summary>
    public required DataExportMintScopedTokenResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DataExportMintScopedTokenResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public DataExportMintScopedTokenResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataExportMintScopedTokenResponse(
        DataExportMintScopedTokenResponse dataExportMintScopedTokenResponse
    )
        : base(dataExportMintScopedTokenResponse) { }
#pragma warning restore CS8618

    public DataExportMintScopedTokenResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataExportMintScopedTokenResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataExportMintScopedTokenResponseFromRaw.FromRawUnchecked"/>
    public static DataExportMintScopedTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DataExportMintScopedTokenResponse(DataExportMintScopedTokenResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class DataExportMintScopedTokenResponseFromRaw : IFromRawJson<DataExportMintScopedTokenResponse>
{
    /// <inheritdoc/>
    public DataExportMintScopedTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataExportMintScopedTokenResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Scoped token + expiry + provider-specific metadata for the FE SDK.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DataExportMintScopedTokenResponseData,
        DataExportMintScopedTokenResponseDataFromRaw
    >)
)]
public sealed record class DataExportMintScopedTokenResponseData : JsonModel
{
    /// <summary>
    /// Provider scoped JWT
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// ISO8601 token expiry
    /// </summary>
    public required string ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("expiresAt");
        }
        init { this._rawData.Set("expiresAt", value); }
    }

    /// <summary>
    /// Provider-specific extras the FE embedded SDK needs
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> ProviderMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "providerMetadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "providerMetadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.ExpiresAt;
        _ = this.ProviderMetadata;
    }

    public DataExportMintScopedTokenResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataExportMintScopedTokenResponseData(
        DataExportMintScopedTokenResponseData dataExportMintScopedTokenResponseData
    )
        : base(dataExportMintScopedTokenResponseData) { }
#pragma warning restore CS8618

    public DataExportMintScopedTokenResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataExportMintScopedTokenResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataExportMintScopedTokenResponseDataFromRaw.FromRawUnchecked"/>
    public static DataExportMintScopedTokenResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataExportMintScopedTokenResponseDataFromRaw
    : IFromRawJson<DataExportMintScopedTokenResponseData>
{
    /// <inheritdoc/>
    public DataExportMintScopedTokenResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataExportMintScopedTokenResponseData.FromRawUnchecked(rawData);
}
