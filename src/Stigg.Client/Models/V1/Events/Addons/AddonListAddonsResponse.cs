using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Events.Addons;

/// <summary>
/// Addon configuration object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AddonListAddonsResponse, AddonListAddonsResponseFromRaw>))]
public sealed record class AddonListAddonsResponse : JsonModel
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
    public required IReadOnlyList<AddonListAddonsResponseEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<AddonListAddonsResponseEntitlement>
            >("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonListAddonsResponseEntitlement>>(
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
    /// The maximum quantity of this addon that can be added to a subscription
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
    public required ApiEnum<string, AddonListAddonsResponsePricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AddonListAddonsResponsePricingType>
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
    public required ApiEnum<string, AddonListAddonsResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AddonListAddonsResponseStatus>>(
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

    public AddonListAddonsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListAddonsResponse(AddonListAddonsResponse addonListAddonsResponse)
        : base(addonListAddonsResponse) { }
#pragma warning restore CS8618

    public AddonListAddonsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListAddonsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListAddonsResponseFromRaw.FromRawUnchecked"/>
    public static AddonListAddonsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListAddonsResponseFromRaw : IFromRawJson<AddonListAddonsResponse>
{
    /// <inheritdoc/>
    public AddonListAddonsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListAddonsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonListAddonsResponseEntitlement,
        AddonListAddonsResponseEntitlementFromRaw
    >)
)]
public sealed record class AddonListAddonsResponseEntitlement : JsonModel
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

    public required ApiEnum<string, AddonListAddonsResponseEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonListAddonsResponseEntitlementType>
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

    public AddonListAddonsResponseEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonListAddonsResponseEntitlement(
        AddonListAddonsResponseEntitlement addonListAddonsResponseEntitlement
    )
        : base(addonListAddonsResponseEntitlement) { }
#pragma warning restore CS8618

    public AddonListAddonsResponseEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonListAddonsResponseEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonListAddonsResponseEntitlementFromRaw.FromRawUnchecked"/>
    public static AddonListAddonsResponseEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonListAddonsResponseEntitlementFromRaw : IFromRawJson<AddonListAddonsResponseEntitlement>
{
    /// <inheritdoc/>
    public AddonListAddonsResponseEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonListAddonsResponseEntitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AddonListAddonsResponseEntitlementTypeConverter))]
public enum AddonListAddonsResponseEntitlementType
{
    Feature,
    Credit,
}

sealed class AddonListAddonsResponseEntitlementTypeConverter
    : JsonConverter<AddonListAddonsResponseEntitlementType>
{
    public override AddonListAddonsResponseEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => AddonListAddonsResponseEntitlementType.Feature,
            "CREDIT" => AddonListAddonsResponseEntitlementType.Credit,
            _ => (AddonListAddonsResponseEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListAddonsResponseEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListAddonsResponseEntitlementType.Feature => "FEATURE",
                AddonListAddonsResponseEntitlementType.Credit => "CREDIT",
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
[JsonConverter(typeof(AddonListAddonsResponsePricingTypeConverter))]
public enum AddonListAddonsResponsePricingType
{
    Free,
    Paid,
    Custom,
}

sealed class AddonListAddonsResponsePricingTypeConverter
    : JsonConverter<AddonListAddonsResponsePricingType>
{
    public override AddonListAddonsResponsePricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => AddonListAddonsResponsePricingType.Free,
            "PAID" => AddonListAddonsResponsePricingType.Paid,
            "CUSTOM" => AddonListAddonsResponsePricingType.Custom,
            _ => (AddonListAddonsResponsePricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListAddonsResponsePricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListAddonsResponsePricingType.Free => "FREE",
                AddonListAddonsResponsePricingType.Paid => "PAID",
                AddonListAddonsResponsePricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(AddonListAddonsResponseStatusConverter))]
public enum AddonListAddonsResponseStatus
{
    Draft,
    Published,
    Archived,
}

sealed class AddonListAddonsResponseStatusConverter : JsonConverter<AddonListAddonsResponseStatus>
{
    public override AddonListAddonsResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => AddonListAddonsResponseStatus.Draft,
            "PUBLISHED" => AddonListAddonsResponseStatus.Published,
            "ARCHIVED" => AddonListAddonsResponseStatus.Archived,
            _ => (AddonListAddonsResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonListAddonsResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonListAddonsResponseStatus.Draft => "DRAFT",
                AddonListAddonsResponseStatus.Published => "PUBLISHED",
                AddonListAddonsResponseStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
