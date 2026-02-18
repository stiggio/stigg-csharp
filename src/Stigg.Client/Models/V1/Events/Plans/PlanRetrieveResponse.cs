using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Events.Plans;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlanRetrieveResponse, PlanRetrieveResponseFromRaw>))]
public sealed record class PlanRetrieveResponse : JsonModel
{
    /// <summary>
    /// Plan configuration object
    /// </summary>
    public required PlanRetrieveResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PlanRetrieveResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public PlanRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanRetrieveResponse(PlanRetrieveResponse planRetrieveResponse)
        : base(planRetrieveResponse) { }
#pragma warning restore CS8618

    public PlanRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PlanRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlanRetrieveResponse(PlanRetrieveResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class PlanRetrieveResponseFromRaw : IFromRawJson<PlanRetrieveResponse>
{
    /// <inheritdoc/>
    public PlanRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Plan configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PlanRetrieveResponseData, PlanRetrieveResponseDataFromRaw>)
)]
public sealed record class PlanRetrieveResponseData : JsonModel
{
    /// <summary>
    /// The unique identifier for the entity
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
    /// The unique identifier for the entity in the billing provider
    /// </summary>
    public required string? BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingId");
        }
        init { this._rawData.Set("billingId", value); }
    }

    /// <summary>
    /// Timestamp of when the record was created
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// The description of the package
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The display name of the package
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("displayName");
        }
        init { this._rawData.Set("displayName", value); }
    }

    /// <summary>
    /// List of entitlements of the package
    /// </summary>
    public required IReadOnlyList<PlanRetrieveResponseDataEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<PlanRetrieveResponseDataEntitlement>
            >("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanRetrieveResponseDataEntitlement>>(
                "entitlements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates if the package is the latest version
    /// </summary>
    public required bool? IsLatest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isLatest");
        }
        init { this._rawData.Set("isLatest", value); }
    }

    /// <summary>
    /// Metadata associated with the entity
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The ID of the parent plan, if applicable
    /// </summary>
    public required string? ParentPlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parentPlanId");
        }
        init { this._rawData.Set("parentPlanId", value); }
    }

    /// <summary>
    /// The pricing type of the package
    /// </summary>
    public required ApiEnum<string, PlanRetrieveResponseDataPricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PlanRetrieveResponseDataPricingType>
            >("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// The product id of the package
    /// </summary>
    public required string ProductID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("productId");
        }
        init { this._rawData.Set("productId", value); }
    }

    /// <summary>
    /// The status of the package
    /// </summary>
    public required ApiEnum<string, PlanRetrieveResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PlanRetrieveResponseDataStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Timestamp of when the record was last updated
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// The version number of the package
    /// </summary>
    public required long VersionNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("versionNumber");
        }
        init { this._rawData.Set("versionNumber", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BillingID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayName;
        foreach (var item in this.Entitlements)
        {
            item.Validate();
        }
        _ = this.IsLatest;
        _ = this.Metadata;
        _ = this.ParentPlanID;
        this.PricingType?.Validate();
        _ = this.ProductID;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.VersionNumber;
    }

    public PlanRetrieveResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanRetrieveResponseData(PlanRetrieveResponseData planRetrieveResponseData)
        : base(planRetrieveResponseData) { }
#pragma warning restore CS8618

    public PlanRetrieveResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanRetrieveResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static PlanRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanRetrieveResponseDataFromRaw : IFromRawJson<PlanRetrieveResponseData>
{
    /// <inheritdoc/>
    public PlanRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanRetrieveResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanRetrieveResponseDataEntitlement,
        PlanRetrieveResponseDataEntitlementFromRaw
    >)
)]
public sealed record class PlanRetrieveResponseDataEntitlement : JsonModel
{
    /// <summary>
    /// The unique identifier for the entity
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

    public required ApiEnum<string, PlanRetrieveResponseDataEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanRetrieveResponseDataEntitlementType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public PlanRetrieveResponseDataEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanRetrieveResponseDataEntitlement(
        PlanRetrieveResponseDataEntitlement planRetrieveResponseDataEntitlement
    )
        : base(planRetrieveResponseDataEntitlement) { }
#pragma warning restore CS8618

    public PlanRetrieveResponseDataEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanRetrieveResponseDataEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanRetrieveResponseDataEntitlementFromRaw.FromRawUnchecked"/>
    public static PlanRetrieveResponseDataEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanRetrieveResponseDataEntitlementFromRaw : IFromRawJson<PlanRetrieveResponseDataEntitlement>
{
    /// <inheritdoc/>
    public PlanRetrieveResponseDataEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanRetrieveResponseDataEntitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanRetrieveResponseDataEntitlementTypeConverter))]
public enum PlanRetrieveResponseDataEntitlementType
{
    Feature,
    Credit,
}

sealed class PlanRetrieveResponseDataEntitlementTypeConverter
    : JsonConverter<PlanRetrieveResponseDataEntitlementType>
{
    public override PlanRetrieveResponseDataEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => PlanRetrieveResponseDataEntitlementType.Feature,
            "CREDIT" => PlanRetrieveResponseDataEntitlementType.Credit,
            _ => (PlanRetrieveResponseDataEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanRetrieveResponseDataEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanRetrieveResponseDataEntitlementType.Feature => "FEATURE",
                PlanRetrieveResponseDataEntitlementType.Credit => "CREDIT",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pricing type of the package
/// </summary>
[JsonConverter(typeof(PlanRetrieveResponseDataPricingTypeConverter))]
public enum PlanRetrieveResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class PlanRetrieveResponseDataPricingTypeConverter
    : JsonConverter<PlanRetrieveResponseDataPricingType>
{
    public override PlanRetrieveResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => PlanRetrieveResponseDataPricingType.Free,
            "PAID" => PlanRetrieveResponseDataPricingType.Paid,
            "CUSTOM" => PlanRetrieveResponseDataPricingType.Custom,
            _ => (PlanRetrieveResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanRetrieveResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanRetrieveResponseDataPricingType.Free => "FREE",
                PlanRetrieveResponseDataPricingType.Paid => "PAID",
                PlanRetrieveResponseDataPricingType.Custom => "CUSTOM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The status of the package
/// </summary>
[JsonConverter(typeof(PlanRetrieveResponseDataStatusConverter))]
public enum PlanRetrieveResponseDataStatus
{
    Draft,
    Published,
    Archived,
}

sealed class PlanRetrieveResponseDataStatusConverter : JsonConverter<PlanRetrieveResponseDataStatus>
{
    public override PlanRetrieveResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => PlanRetrieveResponseDataStatus.Draft,
            "PUBLISHED" => PlanRetrieveResponseDataStatus.Published,
            "ARCHIVED" => PlanRetrieveResponseDataStatus.Archived,
            _ => (PlanRetrieveResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanRetrieveResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanRetrieveResponseDataStatus.Draft => "DRAFT",
                PlanRetrieveResponseDataStatus.Published => "PUBLISHED",
                PlanRetrieveResponseDataStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
