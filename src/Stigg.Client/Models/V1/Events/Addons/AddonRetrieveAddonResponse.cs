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
    typeof(JsonModelConverter<AddonRetrieveAddonResponse, AddonRetrieveAddonResponseFromRaw>)
)]
public sealed record class AddonRetrieveAddonResponse : JsonModel
{
    /// <summary>
    /// Addon configuration object
    /// </summary>
    public required AddonRetrieveAddonResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AddonRetrieveAddonResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AddonRetrieveAddonResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonRetrieveAddonResponse(AddonRetrieveAddonResponse addonRetrieveAddonResponse)
        : base(addonRetrieveAddonResponse) { }
#pragma warning restore CS8618

    public AddonRetrieveAddonResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonRetrieveAddonResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonRetrieveAddonResponseFromRaw.FromRawUnchecked"/>
    public static AddonRetrieveAddonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonRetrieveAddonResponse(AddonRetrieveAddonResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class AddonRetrieveAddonResponseFromRaw : IFromRawJson<AddonRetrieveAddonResponse>
{
    /// <inheritdoc/>
    public AddonRetrieveAddonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonRetrieveAddonResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Addon configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonRetrieveAddonResponseData,
        AddonRetrieveAddonResponseDataFromRaw
    >)
)]
public sealed record class AddonRetrieveAddonResponseData : JsonModel
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
    public required IReadOnlyList<AddonRetrieveAddonResponseDataEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<AddonRetrieveAddonResponseDataEntitlement>
            >("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonRetrieveAddonResponseDataEntitlement>>(
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
    public required ApiEnum<string, AddonRetrieveAddonResponseDataPricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AddonRetrieveAddonResponseDataPricingType>
            >("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// The status of the package
    /// </summary>
    public required ApiEnum<string, AddonRetrieveAddonResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonRetrieveAddonResponseDataStatus>
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

    public AddonRetrieveAddonResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonRetrieveAddonResponseData(
        AddonRetrieveAddonResponseData addonRetrieveAddonResponseData
    )
        : base(addonRetrieveAddonResponseData) { }
#pragma warning restore CS8618

    public AddonRetrieveAddonResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonRetrieveAddonResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonRetrieveAddonResponseDataFromRaw.FromRawUnchecked"/>
    public static AddonRetrieveAddonResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonRetrieveAddonResponseDataFromRaw : IFromRawJson<AddonRetrieveAddonResponseData>
{
    /// <inheritdoc/>
    public AddonRetrieveAddonResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonRetrieveAddonResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonRetrieveAddonResponseDataEntitlement,
        AddonRetrieveAddonResponseDataEntitlementFromRaw
    >)
)]
public sealed record class AddonRetrieveAddonResponseDataEntitlement : JsonModel
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

    public required ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType>
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

    public AddonRetrieveAddonResponseDataEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonRetrieveAddonResponseDataEntitlement(
        AddonRetrieveAddonResponseDataEntitlement addonRetrieveAddonResponseDataEntitlement
    )
        : base(addonRetrieveAddonResponseDataEntitlement) { }
#pragma warning restore CS8618

    public AddonRetrieveAddonResponseDataEntitlement(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonRetrieveAddonResponseDataEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonRetrieveAddonResponseDataEntitlementFromRaw.FromRawUnchecked"/>
    public static AddonRetrieveAddonResponseDataEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonRetrieveAddonResponseDataEntitlementFromRaw
    : IFromRawJson<AddonRetrieveAddonResponseDataEntitlement>
{
    /// <inheritdoc/>
    public AddonRetrieveAddonResponseDataEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonRetrieveAddonResponseDataEntitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AddonRetrieveAddonResponseDataEntitlementTypeConverter))]
public enum AddonRetrieveAddonResponseDataEntitlementType
{
    Feature,
    Credit,
}

sealed class AddonRetrieveAddonResponseDataEntitlementTypeConverter
    : JsonConverter<AddonRetrieveAddonResponseDataEntitlementType>
{
    public override AddonRetrieveAddonResponseDataEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => AddonRetrieveAddonResponseDataEntitlementType.Feature,
            "CREDIT" => AddonRetrieveAddonResponseDataEntitlementType.Credit,
            _ => (AddonRetrieveAddonResponseDataEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonRetrieveAddonResponseDataEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonRetrieveAddonResponseDataEntitlementType.Feature => "FEATURE",
                AddonRetrieveAddonResponseDataEntitlementType.Credit => "CREDIT",
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
[JsonConverter(typeof(AddonRetrieveAddonResponseDataPricingTypeConverter))]
public enum AddonRetrieveAddonResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class AddonRetrieveAddonResponseDataPricingTypeConverter
    : JsonConverter<AddonRetrieveAddonResponseDataPricingType>
{
    public override AddonRetrieveAddonResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => AddonRetrieveAddonResponseDataPricingType.Free,
            "PAID" => AddonRetrieveAddonResponseDataPricingType.Paid,
            "CUSTOM" => AddonRetrieveAddonResponseDataPricingType.Custom,
            _ => (AddonRetrieveAddonResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonRetrieveAddonResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonRetrieveAddonResponseDataPricingType.Free => "FREE",
                AddonRetrieveAddonResponseDataPricingType.Paid => "PAID",
                AddonRetrieveAddonResponseDataPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(AddonRetrieveAddonResponseDataStatusConverter))]
public enum AddonRetrieveAddonResponseDataStatus
{
    Draft,
    Published,
    Archived,
}

sealed class AddonRetrieveAddonResponseDataStatusConverter
    : JsonConverter<AddonRetrieveAddonResponseDataStatus>
{
    public override AddonRetrieveAddonResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => AddonRetrieveAddonResponseDataStatus.Draft,
            "PUBLISHED" => AddonRetrieveAddonResponseDataStatus.Published,
            "ARCHIVED" => AddonRetrieveAddonResponseDataStatus.Archived,
            _ => (AddonRetrieveAddonResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonRetrieveAddonResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonRetrieveAddonResponseDataStatus.Draft => "DRAFT",
                AddonRetrieveAddonResponseDataStatus.Published => "PUBLISHED",
                AddonRetrieveAddonResponseDataStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
