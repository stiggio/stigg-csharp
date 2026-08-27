using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Addons;

/// <summary>
/// Addon configuration object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AddonListResponse, AddonListResponseFromRaw>))]
public sealed record class AddonListResponse : JsonModel
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
    /// List of addons the addon is dependant on
    /// </summary>
    public required IReadOnlyList<string>? Dependencies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("dependencies");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "dependencies",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
    public required IReadOnlyList<AddonListResponseEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AddonListResponseEntitlement>>(
                "entitlements"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonListResponseEntitlement>>(
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
    /// The maximum quantity of this addon that can be added to a subscription. Leave
    /// unset for no upper bound.
    /// </summary>
    public required long? MaxQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxQuantity");
        }
        init { this._rawData.Set("maxQuantity", value); }
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
    /// The pricing type of the package
    /// </summary>
    public required ApiEnum<string, AddonListResponsePricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AddonListResponsePricingType>>(
                "pricingType"
            );
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
    public required ApiEnum<string, AddonListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AddonListResponseStatus>>(
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
        _ = this.Dependencies;
        _ = this.Description;
        _ = this.DisplayName;
        foreach (var item in this.Entitlements)
        {
            item.Validate();
        }
        _ = this.IsLatest;
        _ = this.MaxQuantity;
        _ = this.Metadata;
        this.PricingType?.Validate();
        _ = this.ProductID;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.VersionNumber;
    }

    public AddonListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListResponse(AddonListResponse addonListResponse)
        : base(addonListResponse) { }
#pragma warning restore CS8618

    public AddonListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListResponseFromRaw.FromRawUnchecked"/>
    public static AddonListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListResponseFromRaw : IFromRawJson<AddonListResponse>
{
    /// <inheritdoc/>
    public AddonListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AddonListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonListResponseEntitlement, AddonListResponseEntitlementFromRaw>)
)]
public sealed record class AddonListResponseEntitlement : JsonModel
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

    public required ApiEnum<string, AddonListResponseEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AddonListResponseEntitlementType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public AddonListResponseEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListResponseEntitlement(AddonListResponseEntitlement addonListResponseEntitlement)
        : base(addonListResponseEntitlement) { }
#pragma warning restore CS8618

    public AddonListResponseEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListResponseEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListResponseEntitlementFromRaw.FromRawUnchecked"/>
    public static AddonListResponseEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListResponseEntitlementFromRaw : IFromRawJson<AddonListResponseEntitlement>
{
    /// <inheritdoc/>
    public AddonListResponseEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListResponseEntitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AddonListResponseEntitlementTypeConverter))]
public enum AddonListResponseEntitlementType
{
    Feature,
    Credit,
}

sealed class AddonListResponseEntitlementTypeConverter
    : JsonConverter<AddonListResponseEntitlementType>
{
    public override AddonListResponseEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => AddonListResponseEntitlementType.Feature,
            "CREDIT" => AddonListResponseEntitlementType.Credit,
            _ => (AddonListResponseEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListResponseEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListResponseEntitlementType.Feature => "FEATURE",
                AddonListResponseEntitlementType.Credit => "CREDIT",
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
[JsonConverter(typeof(AddonListResponsePricingTypeConverter))]
public enum AddonListResponsePricingType
{
    Free,
    Paid,
    Custom,
}

sealed class AddonListResponsePricingTypeConverter : JsonConverter<AddonListResponsePricingType>
{
    public override AddonListResponsePricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => AddonListResponsePricingType.Free,
            "PAID" => AddonListResponsePricingType.Paid,
            "CUSTOM" => AddonListResponsePricingType.Custom,
            _ => (AddonListResponsePricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListResponsePricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListResponsePricingType.Free => "FREE",
                AddonListResponsePricingType.Paid => "PAID",
                AddonListResponsePricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(AddonListResponseStatusConverter))]
public enum AddonListResponseStatus
{
    Draft,
    Published,
    Archived,
}

sealed class AddonListResponseStatusConverter : JsonConverter<AddonListResponseStatus>
{
    public override AddonListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => AddonListResponseStatus.Draft,
            "PUBLISHED" => AddonListResponseStatus.Published,
            "ARCHIVED" => AddonListResponseStatus.Archived,
            _ => (AddonListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListResponseStatus.Draft => "DRAFT",
                AddonListResponseStatus.Published => "PUBLISHED",
                AddonListResponseStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
