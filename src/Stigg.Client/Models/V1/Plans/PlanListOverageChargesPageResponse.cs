using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Plans;

/// <summary>
/// Response list object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanListOverageChargesPageResponse,
        PlanListOverageChargesPageResponseFromRaw
    >)
)]
public sealed record class PlanListOverageChargesPageResponse : JsonModel
{
    public required IReadOnlyList<PlanListOverageChargesResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PlanListOverageChargesResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanListOverageChargesResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required PlanListOverageChargesPageResponsePagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PlanListOverageChargesPageResponsePagination>(
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

    public PlanListOverageChargesPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListOverageChargesPageResponse(
        PlanListOverageChargesPageResponse planListOverageChargesPageResponse
    )
        : base(planListOverageChargesPageResponse) { }
#pragma warning restore CS8618

    public PlanListOverageChargesPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListOverageChargesPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListOverageChargesPageResponseFromRaw.FromRawUnchecked"/>
    public static PlanListOverageChargesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListOverageChargesPageResponseFromRaw : IFromRawJson<PlanListOverageChargesPageResponse>
{
    /// <inheritdoc/>
    public PlanListOverageChargesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListOverageChargesPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanListOverageChargesPageResponsePagination,
        PlanListOverageChargesPageResponsePaginationFromRaw
    >)
)]
public sealed record class PlanListOverageChargesPageResponsePagination : JsonModel
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

    public PlanListOverageChargesPageResponsePagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListOverageChargesPageResponsePagination(
        PlanListOverageChargesPageResponsePagination planListOverageChargesPageResponsePagination
    )
        : base(planListOverageChargesPageResponsePagination) { }
#pragma warning restore CS8618

    public PlanListOverageChargesPageResponsePagination(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListOverageChargesPageResponsePagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListOverageChargesPageResponsePaginationFromRaw.FromRawUnchecked"/>
    public static PlanListOverageChargesPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListOverageChargesPageResponsePaginationFromRaw
    : IFromRawJson<PlanListOverageChargesPageResponsePagination>
{
    /// <inheritdoc/>
    public PlanListOverageChargesPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListOverageChargesPageResponsePagination.FromRawUnchecked(rawData);
}
