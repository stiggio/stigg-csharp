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
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonUpdateAddonResponse, AddonUpdateAddonResponseFromRaw>)
)]
public sealed record class AddonUpdateAddonResponse : JsonModel
{
    /// <summary>
    /// Addon configuration object
    /// </summary>
    public required AddonUpdateAddonResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AddonUpdateAddonResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AddonUpdateAddonResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonUpdateAddonResponse(AddonUpdateAddonResponse addonUpdateAddonResponse)
        : base(addonUpdateAddonResponse) { }
#pragma warning restore CS8618

    public AddonUpdateAddonResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonUpdateAddonResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonUpdateAddonResponseFromRaw.FromRawUnchecked"/>
    public static AddonUpdateAddonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonUpdateAddonResponse(AddonUpdateAddonResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class AddonUpdateAddonResponseFromRaw : IFromRawJson<AddonUpdateAddonResponse>
{
    /// <inheritdoc/>
    public AddonUpdateAddonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonUpdateAddonResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Addon configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonUpdateAddonResponseData, AddonUpdateAddonResponseDataFromRaw>)
)]
public sealed record class AddonUpdateAddonResponseData : JsonModel
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
    /// List of entitlements for the addon
    /// </summary>
    public required IReadOnlyList<AddonUpdateAddonResponseDataEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<AddonUpdateAddonResponseDataEntitlement>
            >("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonUpdateAddonResponseDataEntitlement>>(
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
    public required ApiEnum<string, AddonUpdateAddonResponseDataPricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AddonUpdateAddonResponseDataPricingType>
            >("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// The status of the package
    /// </summary>
    public required ApiEnum<string, AddonUpdateAddonResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonUpdateAddonResponseDataStatus>
            >("status");
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
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.VersionNumber;
    }

    public AddonUpdateAddonResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonUpdateAddonResponseData(AddonUpdateAddonResponseData addonUpdateAddonResponseData)
        : base(addonUpdateAddonResponseData) { }
#pragma warning restore CS8618

    public AddonUpdateAddonResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonUpdateAddonResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonUpdateAddonResponseDataFromRaw.FromRawUnchecked"/>
    public static AddonUpdateAddonResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonUpdateAddonResponseDataFromRaw : IFromRawJson<AddonUpdateAddonResponseData>
{
    /// <inheritdoc/>
    public AddonUpdateAddonResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonUpdateAddonResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonUpdateAddonResponseDataEntitlement,
        AddonUpdateAddonResponseDataEntitlementFromRaw
    >)
)]
public sealed record class AddonUpdateAddonResponseDataEntitlement : JsonModel
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

    public required ApiEnum<string, AddonUpdateAddonResponseDataEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonUpdateAddonResponseDataEntitlementType>
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

    public AddonUpdateAddonResponseDataEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonUpdateAddonResponseDataEntitlement(
        AddonUpdateAddonResponseDataEntitlement addonUpdateAddonResponseDataEntitlement
    )
        : base(addonUpdateAddonResponseDataEntitlement) { }
#pragma warning restore CS8618

    public AddonUpdateAddonResponseDataEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonUpdateAddonResponseDataEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonUpdateAddonResponseDataEntitlementFromRaw.FromRawUnchecked"/>
    public static AddonUpdateAddonResponseDataEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonUpdateAddonResponseDataEntitlementFromRaw
    : IFromRawJson<AddonUpdateAddonResponseDataEntitlement>
{
    /// <inheritdoc/>
    public AddonUpdateAddonResponseDataEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonUpdateAddonResponseDataEntitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AddonUpdateAddonResponseDataEntitlementTypeConverter))]
public enum AddonUpdateAddonResponseDataEntitlementType
{
    Feature,
    Credit,
}

sealed class AddonUpdateAddonResponseDataEntitlementTypeConverter
    : JsonConverter<AddonUpdateAddonResponseDataEntitlementType>
{
    public override AddonUpdateAddonResponseDataEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => AddonUpdateAddonResponseDataEntitlementType.Feature,
            "CREDIT" => AddonUpdateAddonResponseDataEntitlementType.Credit,
            _ => (AddonUpdateAddonResponseDataEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonUpdateAddonResponseDataEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonUpdateAddonResponseDataEntitlementType.Feature => "FEATURE",
                AddonUpdateAddonResponseDataEntitlementType.Credit => "CREDIT",
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
[JsonConverter(typeof(AddonUpdateAddonResponseDataPricingTypeConverter))]
public enum AddonUpdateAddonResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class AddonUpdateAddonResponseDataPricingTypeConverter
    : JsonConverter<AddonUpdateAddonResponseDataPricingType>
{
    public override AddonUpdateAddonResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => AddonUpdateAddonResponseDataPricingType.Free,
            "PAID" => AddonUpdateAddonResponseDataPricingType.Paid,
            "CUSTOM" => AddonUpdateAddonResponseDataPricingType.Custom,
            _ => (AddonUpdateAddonResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonUpdateAddonResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonUpdateAddonResponseDataPricingType.Free => "FREE",
                AddonUpdateAddonResponseDataPricingType.Paid => "PAID",
                AddonUpdateAddonResponseDataPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(AddonUpdateAddonResponseDataStatusConverter))]
public enum AddonUpdateAddonResponseDataStatus
{
    Draft,
    Published,
    Archived,
}

sealed class AddonUpdateAddonResponseDataStatusConverter
    : JsonConverter<AddonUpdateAddonResponseDataStatus>
{
    public override AddonUpdateAddonResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => AddonUpdateAddonResponseDataStatus.Draft,
            "PUBLISHED" => AddonUpdateAddonResponseDataStatus.Published,
            "ARCHIVED" => AddonUpdateAddonResponseDataStatus.Archived,
            _ => (AddonUpdateAddonResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonUpdateAddonResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonUpdateAddonResponseDataStatus.Draft => "DRAFT",
                AddonUpdateAddonResponseDataStatus.Published => "PUBLISHED",
                AddonUpdateAddonResponseDataStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
