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
[JsonConverter(typeof(JsonModelConverter<AddonListPageResponse, AddonListPageResponseFromRaw>))]
public sealed record class AddonListPageResponse : JsonModel
{
    public required IReadOnlyList<AddonListResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AddonListResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required AddonListPageResponsePagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AddonListPageResponsePagination>("pagination");
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

    public AddonListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListPageResponse(AddonListPageResponse addonListPageResponse)
        : base(addonListPageResponse) { }
#pragma warning restore CS8618

    public AddonListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListPageResponseFromRaw.FromRawUnchecked"/>
    public static AddonListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListPageResponseFromRaw : IFromRawJson<AddonListPageResponse>
{
    /// <inheritdoc/>
    public AddonListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonListPageResponsePagination,
        AddonListPageResponsePaginationFromRaw
    >)
)]
public sealed record class AddonListPageResponsePagination : JsonModel
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

    public AddonListPageResponsePagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListPageResponsePagination(
        AddonListPageResponsePagination addonListPageResponsePagination
    )
        : base(addonListPageResponsePagination) { }
#pragma warning restore CS8618

    public AddonListPageResponsePagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListPageResponsePagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListPageResponsePaginationFromRaw.FromRawUnchecked"/>
    public static AddonListPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListPageResponsePaginationFromRaw : IFromRawJson<AddonListPageResponsePagination>
{
    /// <inheritdoc/>
    public AddonListPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListPageResponsePagination.FromRawUnchecked(rawData);
}
