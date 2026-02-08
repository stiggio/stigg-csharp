using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// Response list object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResourcesPageResponse,
        CustomerListResourcesPageResponseFromRaw
    >)
)]
public sealed record class CustomerListResourcesPageResponse : JsonModel
{
    public required IReadOnlyList<CustomerListResourcesResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CustomerListResourcesResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerListResourcesResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required CustomerListResourcesPageResponsePagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerListResourcesPageResponsePagination>(
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

    public CustomerListResourcesPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResourcesPageResponse(
        CustomerListResourcesPageResponse customerListResourcesPageResponse
    )
        : base(customerListResourcesPageResponse) { }
#pragma warning restore CS8618

    public CustomerListResourcesPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResourcesPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResourcesPageResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListResourcesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResourcesPageResponseFromRaw : IFromRawJson<CustomerListResourcesPageResponse>
{
    /// <inheritdoc/>
    public CustomerListResourcesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResourcesPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListResourcesPageResponsePagination,
        CustomerListResourcesPageResponsePaginationFromRaw
    >)
)]
public sealed record class CustomerListResourcesPageResponsePagination : JsonModel
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

    public CustomerListResourcesPageResponsePagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResourcesPageResponsePagination(
        CustomerListResourcesPageResponsePagination customerListResourcesPageResponsePagination
    )
        : base(customerListResourcesPageResponsePagination) { }
#pragma warning restore CS8618

    public CustomerListResourcesPageResponsePagination(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResourcesPageResponsePagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResourcesPageResponsePaginationFromRaw.FromRawUnchecked"/>
    public static CustomerListResourcesPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResourcesPageResponsePaginationFromRaw
    : IFromRawJson<CustomerListResourcesPageResponsePagination>
{
    /// <inheritdoc/>
    public CustomerListResourcesPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResourcesPageResponsePagination.FromRawUnchecked(rawData);
}
