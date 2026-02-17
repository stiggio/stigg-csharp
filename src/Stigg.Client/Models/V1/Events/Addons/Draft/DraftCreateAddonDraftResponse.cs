using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Events.Addons.Draft;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DraftCreateAddonDraftResponse, DraftCreateAddonDraftResponseFromRaw>)
)]
public sealed record class DraftCreateAddonDraftResponse : JsonModel
{
    /// <summary>
    /// Addon configuration object
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public DraftCreateAddonDraftResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DraftCreateAddonDraftResponse(
        DraftCreateAddonDraftResponse draftCreateAddonDraftResponse
    )
        : base(draftCreateAddonDraftResponse) { }
#pragma warning restore CS8618

    public DraftCreateAddonDraftResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DraftCreateAddonDraftResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DraftCreateAddonDraftResponseFromRaw.FromRawUnchecked"/>
    public static DraftCreateAddonDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DraftCreateAddonDraftResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class DraftCreateAddonDraftResponseFromRaw : IFromRawJson<DraftCreateAddonDraftResponse>
{
    /// <inheritdoc/>
    public DraftCreateAddonDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DraftCreateAddonDraftResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Addon configuration object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public required IReadOnlyList<Entitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Entitlement>>("entitlements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Entitlement>>(
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
    public required ApiEnum<string, PricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PricingType>>("pricingType");
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// The status of the package
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Entitlement, EntitlementFromRaw>))]
public sealed record class Entitlement : JsonModel
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

    public required ApiEnum<string, global::Stigg.Client.Models.V1.Events.Addons.Draft.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Stigg.Client.Models.V1.Events.Addons.Draft.Type>
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

    public Entitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entitlement(Entitlement entitlement)
        : base(entitlement) { }
#pragma warning restore CS8618

    public Entitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementFromRaw.FromRawUnchecked"/>
    public static Entitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EntitlementFromRaw : IFromRawJson<Entitlement>
{
    /// <inheritdoc/>
    public Entitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Feature,
    Credit,
}

sealed class TypeConverter : JsonConverter<global::Stigg.Client.Models.V1.Events.Addons.Draft.Type>
{
    public override global::Stigg.Client.Models.V1.Events.Addons.Draft.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => global::Stigg.Client.Models.V1.Events.Addons.Draft.Type.Feature,
            "CREDIT" => global::Stigg.Client.Models.V1.Events.Addons.Draft.Type.Credit,
            _ => (global::Stigg.Client.Models.V1.Events.Addons.Draft.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Stigg.Client.Models.V1.Events.Addons.Draft.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Stigg.Client.Models.V1.Events.Addons.Draft.Type.Feature => "FEATURE",
                global::Stigg.Client.Models.V1.Events.Addons.Draft.Type.Credit => "CREDIT",
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
[JsonConverter(typeof(PricingTypeConverter))]
public enum PricingType
{
    Free,
    Paid,
    Custom,
}

sealed class PricingTypeConverter : JsonConverter<PricingType>
{
    public override PricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => PricingType.Free,
            "PAID" => PricingType.Paid,
            "CUSTOM" => PricingType.Custom,
            _ => (PricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingType.Free => "FREE",
                PricingType.Paid => "PAID",
                PricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft,
    Published,
    Archived,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => Status.Draft,
            "PUBLISHED" => Status.Published,
            "ARCHIVED" => Status.Archived,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Draft => "DRAFT",
                Status.Published => "PUBLISHED",
                Status.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
