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
    typeof(JsonModelConverter<AddonCreateAddonResponse, AddonCreateAddonResponseFromRaw>)
)]
public sealed record class AddonCreateAddonResponse : JsonModel
{
    /// <summary>
    /// Addon configuration object
    /// </summary>
    public required AddonCreateAddonResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AddonCreateAddonResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AddonCreateAddonResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonCreateAddonResponse(AddonCreateAddonResponse addonCreateAddonResponse)
        : base(addonCreateAddonResponse) { }
#pragma warning restore CS8618

    public AddonCreateAddonResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonCreateAddonResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonCreateAddonResponseFromRaw.FromRawUnchecked"/>
    public static AddonCreateAddonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddonCreateAddonResponse(AddonCreateAddonResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class AddonCreateAddonResponseFromRaw : IFromRawJson<AddonCreateAddonResponse>
{
    /// <inheritdoc/>
    public AddonCreateAddonResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonCreateAddonResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Addon configuration object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AddonCreateAddonResponseData, AddonCreateAddonResponseDataFromRaw>)
)]
public sealed record class AddonCreateAddonResponseData : JsonModel
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
    public required IReadOnlyList<AddonCreateAddonResponseDataEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<AddonCreateAddonResponseDataEntitlement>
            >("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AddonCreateAddonResponseDataEntitlement>>(
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
    public required ApiEnum<string, AddonCreateAddonResponseDataPricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AddonCreateAddonResponseDataPricingType>
            >("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// The status of the package
    /// </summary>
    public required ApiEnum<string, AddonCreateAddonResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonCreateAddonResponseDataStatus>
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

    public AddonCreateAddonResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonCreateAddonResponseData(AddonCreateAddonResponseData addonCreateAddonResponseData)
        : base(addonCreateAddonResponseData) { }
#pragma warning restore CS8618

    public AddonCreateAddonResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonCreateAddonResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonCreateAddonResponseDataFromRaw.FromRawUnchecked"/>
    public static AddonCreateAddonResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonCreateAddonResponseDataFromRaw : IFromRawJson<AddonCreateAddonResponseData>
{
    /// <inheritdoc/>
    public AddonCreateAddonResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonCreateAddonResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AddonCreateAddonResponseDataEntitlement,
        AddonCreateAddonResponseDataEntitlementFromRaw
    >)
)]
public sealed record class AddonCreateAddonResponseDataEntitlement : JsonModel
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

    public required ApiEnum<string, AddonCreateAddonResponseDataEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, AddonCreateAddonResponseDataEntitlementType>
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

    public AddonCreateAddonResponseDataEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddonCreateAddonResponseDataEntitlement(
        AddonCreateAddonResponseDataEntitlement addonCreateAddonResponseDataEntitlement
    )
        : base(addonCreateAddonResponseDataEntitlement) { }
#pragma warning restore CS8618

    public AddonCreateAddonResponseDataEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddonCreateAddonResponseDataEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddonCreateAddonResponseDataEntitlementFromRaw.FromRawUnchecked"/>
    public static AddonCreateAddonResponseDataEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddonCreateAddonResponseDataEntitlementFromRaw
    : IFromRawJson<AddonCreateAddonResponseDataEntitlement>
{
    /// <inheritdoc/>
    public AddonCreateAddonResponseDataEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddonCreateAddonResponseDataEntitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AddonCreateAddonResponseDataEntitlementTypeConverter))]
public enum AddonCreateAddonResponseDataEntitlementType
{
    Feature,
    Credit,
}

sealed class AddonCreateAddonResponseDataEntitlementTypeConverter
    : JsonConverter<AddonCreateAddonResponseDataEntitlementType>
{
    public override AddonCreateAddonResponseDataEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => AddonCreateAddonResponseDataEntitlementType.Feature,
            "CREDIT" => AddonCreateAddonResponseDataEntitlementType.Credit,
            _ => (AddonCreateAddonResponseDataEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonCreateAddonResponseDataEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonCreateAddonResponseDataEntitlementType.Feature => "FEATURE",
                AddonCreateAddonResponseDataEntitlementType.Credit => "CREDIT",
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
[JsonConverter(typeof(AddonCreateAddonResponseDataPricingTypeConverter))]
public enum AddonCreateAddonResponseDataPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class AddonCreateAddonResponseDataPricingTypeConverter
    : JsonConverter<AddonCreateAddonResponseDataPricingType>
{
    public override AddonCreateAddonResponseDataPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => AddonCreateAddonResponseDataPricingType.Free,
            "PAID" => AddonCreateAddonResponseDataPricingType.Paid,
            "CUSTOM" => AddonCreateAddonResponseDataPricingType.Custom,
            _ => (AddonCreateAddonResponseDataPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonCreateAddonResponseDataPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonCreateAddonResponseDataPricingType.Free => "FREE",
                AddonCreateAddonResponseDataPricingType.Paid => "PAID",
                AddonCreateAddonResponseDataPricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(AddonCreateAddonResponseDataStatusConverter))]
public enum AddonCreateAddonResponseDataStatus
{
    Draft,
    Published,
    Archived,
}

sealed class AddonCreateAddonResponseDataStatusConverter
    : JsonConverter<AddonCreateAddonResponseDataStatus>
{
    public override AddonCreateAddonResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => AddonCreateAddonResponseDataStatus.Draft,
            "PUBLISHED" => AddonCreateAddonResponseDataStatus.Published,
            "ARCHIVED" => AddonCreateAddonResponseDataStatus.Archived,
            _ => (AddonCreateAddonResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddonCreateAddonResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddonCreateAddonResponseDataStatus.Draft => "DRAFT",
                AddonCreateAddonResponseDataStatus.Published => "PUBLISHED",
                AddonCreateAddonResponseDataStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
