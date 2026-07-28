using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// A cursor-paginated list of a customer's invoices
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListInvoicesPageResponse,
        CustomerListInvoicesPageResponseFromRaw
    >)
)]
public sealed record class CustomerListInvoicesPageResponse : JsonModel
{
    public required IReadOnlyList<CustomerListInvoicesResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CustomerListInvoicesResponse>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerListInvoicesResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required CustomerListInvoicesPageResponsePagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerListInvoicesPageResponsePagination>(
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

    public CustomerListInvoicesPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListInvoicesPageResponse(
        CustomerListInvoicesPageResponse customerListInvoicesPageResponse
    )
        : base(customerListInvoicesPageResponse) { }
#pragma warning restore CS8618

    public CustomerListInvoicesPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListInvoicesPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListInvoicesPageResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListInvoicesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListInvoicesPageResponseFromRaw : IFromRawJson<CustomerListInvoicesPageResponse>
{
    /// <inheritdoc/>
    public CustomerListInvoicesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListInvoicesPageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerListInvoicesPageResponsePagination,
        CustomerListInvoicesPageResponsePaginationFromRaw
    >)
)]
public sealed record class CustomerListInvoicesPageResponsePagination : JsonModel
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

    public CustomerListInvoicesPageResponsePagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListInvoicesPageResponsePagination(
        CustomerListInvoicesPageResponsePagination customerListInvoicesPageResponsePagination
    )
        : base(customerListInvoicesPageResponsePagination) { }
#pragma warning restore CS8618

    public CustomerListInvoicesPageResponsePagination(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListInvoicesPageResponsePagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListInvoicesPageResponsePaginationFromRaw.FromRawUnchecked"/>
    public static CustomerListInvoicesPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListInvoicesPageResponsePaginationFromRaw
    : IFromRawJson<CustomerListInvoicesPageResponsePagination>
{
    /// <inheritdoc/>
    public CustomerListInvoicesPageResponsePagination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListInvoicesPageResponsePagination.FromRawUnchecked(rawData);
}
