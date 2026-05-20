using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Events.Credits.Grants;

/// <summary>
/// Response list object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GrantListPageResponse, GrantListPageResponseFromRaw>))]
public sealed record class GrantListPageResponse : JsonModel
{
    public required IReadOnlyList<GrantListResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GrantListResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GrantListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
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

    public GrantListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrantListPageResponse(GrantListPageResponse grantListPageResponse)
        : base(grantListPageResponse) { }
#pragma warning restore CS8618

    public GrantListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrantListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrantListPageResponseFromRaw.FromRawUnchecked"/>
    public static GrantListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrantListPageResponseFromRaw : IFromRawJson<GrantListPageResponse>
{
    /// <inheritdoc/>
    public GrantListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GrantListPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
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

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}
