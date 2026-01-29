using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Customers;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CustomerImportResponse, CustomerImportResponseFromRaw>))]
public sealed record class CustomerImportResponse : JsonModel
{
    /// <summary>
    /// List of newly created customer IDs from the import operation.
    /// </summary>
    public required CustomerImportResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerImportResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CustomerImportResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerImportResponse(CustomerImportResponse customerImportResponse)
        : base(customerImportResponse) { }
#pragma warning restore CS8618

    public CustomerImportResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerImportResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerImportResponseFromRaw.FromRawUnchecked"/>
    public static CustomerImportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerImportResponse(CustomerImportResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class CustomerImportResponseFromRaw : IFromRawJson<CustomerImportResponse>
{
    /// <inheritdoc/>
    public CustomerImportResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerImportResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// List of newly created customer IDs from the import operation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CustomerImportResponseData, CustomerImportResponseDataFromRaw>)
)]
public sealed record class CustomerImportResponseData : JsonModel
{
    /// <summary>
    /// Customer IDs created during import
    /// </summary>
    public required IReadOnlyList<string> NewCustomers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("newCustomers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "newCustomers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NewCustomers;
    }

    public CustomerImportResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerImportResponseData(CustomerImportResponseData customerImportResponseData)
        : base(customerImportResponseData) { }
#pragma warning restore CS8618

    public CustomerImportResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerImportResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerImportResponseDataFromRaw.FromRawUnchecked"/>
    public static CustomerImportResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerImportResponseData(IReadOnlyList<string> newCustomers)
        : this()
    {
        this.NewCustomers = newCustomers;
    }
}

class CustomerImportResponseDataFromRaw : IFromRawJson<CustomerImportResponseData>
{
    /// <inheritdoc/>
    public CustomerImportResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerImportResponseData.FromRawUnchecked(rawData);
}
