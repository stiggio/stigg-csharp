using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// Resource object that belongs to a customer, used to scope subscriptions and entitlements
/// to a specific instance within the customer's account (e.g. a website, project,
/// or workspace) for multi-resource pricing. A resource is identified only by its
/// resourceId — there's no separate display name or metadata field on the resource
/// itself; if you need to attach descriptive data, keep it in your own system keyed
/// by resourceId.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CustomerListResourcesResponse, CustomerListResourcesResponseFromRaw>)
)]
public sealed record class CustomerListResourcesResponse : JsonModel
{
    /// <summary>
    /// Resource slug
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
    /// Timestamp of when the record was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Timestamp of when the record was last updated
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public CustomerListResourcesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerListResourcesResponse(
        CustomerListResourcesResponse customerListResourcesResponse
    )
        : base(customerListResourcesResponse) { }
#pragma warning restore CS8618

    public CustomerListResourcesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerListResourcesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerListResourcesResponseFromRaw.FromRawUnchecked"/>
    public static CustomerListResourcesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerListResourcesResponseFromRaw : IFromRawJson<CustomerListResourcesResponse>
{
    /// <inheritdoc/>
    public CustomerListResourcesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerListResourcesResponse.FromRawUnchecked(rawData);
}
