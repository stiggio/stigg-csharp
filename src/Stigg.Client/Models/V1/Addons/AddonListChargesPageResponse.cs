using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Addons;

/// <summary>
/// Response list object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonListChargesPageResponse, AddonListChargesPageResponseFromRaw>)
)]
public sealed record class AddonListChargesPageResponse : JsonModel
{
    public required IReadOnlyList<AddonListChargesResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AddonListChargesResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonListChargesResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required AddonListChargesPageResponsePagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AddonListChargesPageResponsePagination>(
                "pagination"
            );
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Pagination.Validate();
    }

    public AddonListChargesPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListChargesPageResponse(AddonListChargesPageResponse addonListChargesPageResponse)
        : base(addonListChargesPageResponse) { }
#pragma warning restore CS8618

    public AddonListChargesPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListChargesPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListChargesPageResponseFromRaw.FromRawUnchecked"/>
    public static AddonListChargesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListChargesPageResponseFromRaw : IFromRawJson<AddonListChargesPageResponse>
{
    /// <inheritdoc/>
    public AddonListChargesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListChargesPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonListChargesPageResponsePagination,
        AddonListChargesPageResponsePaginationFromRaw
    >)
)]
public sealed record class AddonListChargesPageResponsePagination : JsonModel
{
    /// <summary>
    /// Cursor for fetching the next page of results, or null if no additional pages exist
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// Cursor for fetching the previous page of results, or null if at the beginning
    /// </summary>
    public required string? Prev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev");
        }
        init { this._rawData.Set("prev", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Next;
        _ = this.Prev;
    }

    public AddonListChargesPageResponsePagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListChargesPageResponsePagination(
        AddonListChargesPageResponsePagination addonListChargesPageResponsePagination
    )
        : base(addonListChargesPageResponsePagination) { }
#pragma warning restore CS8618

    public AddonListChargesPageResponsePagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListChargesPageResponsePagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListChargesPageResponsePaginationFromRaw.FromRawUnchecked"/>
    public static AddonListChargesPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListChargesPageResponsePaginationFromRaw
    : IFromRawJson<AddonListChargesPageResponsePagination>
{
    /// <inheritdoc/>
    public AddonListChargesPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListChargesPageResponsePagination.FromRawUnchecked(rawData);
}
