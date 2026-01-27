using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Core;

namespace Stigg.Models.V1.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListPageResponse, SubscriptionListPageResponseFromRaw>)
)]
public sealed record class SubscriptionListPageResponse : JsonModel
{
    public required IReadOnlyList<SubscriptionListResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SubscriptionListResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination information including cursors for navigation
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

    public SubscriptionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListPageResponse(SubscriptionListPageResponse subscriptionListPageResponse)
        : base(subscriptionListPageResponse) { }
#pragma warning restore CS8618

    public SubscriptionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListPageResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListPageResponseFromRaw : IFromRawJson<SubscriptionListPageResponse>
{
    /// <inheritdoc/>
    public SubscriptionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination information including cursors for navigation
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor to fetch the next page (use with after parameter), null if no more pages
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
    /// Cursor to fetch the previous page (use with before parameter), null if no
    /// previous pages
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
