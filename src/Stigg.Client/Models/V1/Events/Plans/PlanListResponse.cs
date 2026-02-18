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
/// Plan configuration object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlanListResponse, PlanListResponseFromRaw>))]
public sealed record class PlanListResponse : JsonModel
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
    public required IReadOnlyList<PlanListResponseEntitlement> Entitlements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PlanListResponseEntitlement>>(
                "entitlements"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PlanListResponseEntitlement>>(
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
    public required ApiEnum<string, PlanListResponsePricingType>? PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PlanListResponsePricingType>>(
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
    public required ApiEnum<string, PlanListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PlanListResponseStatus>>("status");
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

    public PlanListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListResponse(PlanListResponse planListResponse)
        : base(planListResponse) { }
#pragma warning restore CS8618

    public PlanListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListResponseFromRaw.FromRawUnchecked"/>
    public static PlanListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListResponseFromRaw : IFromRawJson<PlanListResponse>
{
    /// <inheritdoc/>
    public PlanListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Entitlement reference with type and identifier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PlanListResponseEntitlement, PlanListResponseEntitlementFromRaw>)
)]
public sealed record class PlanListResponseEntitlement : JsonModel
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

    public required ApiEnum<string, PlanListResponseEntitlementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PlanListResponseEntitlementType>>(
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

    public PlanListResponseEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanListResponseEntitlement(PlanListResponseEntitlement planListResponseEntitlement)
        : base(planListResponseEntitlement) { }
#pragma warning restore CS8618

    public PlanListResponseEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListResponseEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListResponseEntitlementFromRaw.FromRawUnchecked"/>
    public static PlanListResponseEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListResponseEntitlementFromRaw : IFromRawJson<PlanListResponseEntitlement>
{
    /// <inheritdoc/>
    public PlanListResponseEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListResponseEntitlement.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlanListResponseEntitlementTypeConverter))]
public enum PlanListResponseEntitlementType
{
    Feature,
    Credit,
}

sealed class PlanListResponseEntitlementTypeConverter
    : JsonConverter<PlanListResponseEntitlementType>
{
    public override PlanListResponseEntitlementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FEATURE" => PlanListResponseEntitlementType.Feature,
            "CREDIT" => PlanListResponseEntitlementType.Credit,
            _ => (PlanListResponseEntitlementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListResponseEntitlementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListResponseEntitlementType.Feature => "FEATURE",
                PlanListResponseEntitlementType.Credit => "CREDIT",
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
[JsonConverter(typeof(PlanListResponsePricingTypeConverter))]
public enum PlanListResponsePricingType
{
    Free,
    Paid,
    Custom,
}

sealed class PlanListResponsePricingTypeConverter : JsonConverter<PlanListResponsePricingType>
{
    public override PlanListResponsePricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => PlanListResponsePricingType.Free,
            "PAID" => PlanListResponsePricingType.Paid,
            "CUSTOM" => PlanListResponsePricingType.Custom,
            _ => (PlanListResponsePricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListResponsePricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListResponsePricingType.Free => "FREE",
                PlanListResponsePricingType.Paid => "PAID",
                PlanListResponsePricingType.Custom => "CUSTOM",
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
[JsonConverter(typeof(PlanListResponseStatusConverter))]
public enum PlanListResponseStatus
{
    Draft,
    Published,
    Archived,
}

sealed class PlanListResponseStatusConverter : JsonConverter<PlanListResponseStatus>
{
    public override PlanListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => PlanListResponseStatus.Draft,
            "PUBLISHED" => PlanListResponseStatus.Published,
            "ARCHIVED" => PlanListResponseStatus.Archived,
            _ => (PlanListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListResponseStatus.Draft => "DRAFT",
                PlanListResponseStatus.Published => "PUBLISHED",
                PlanListResponseStatus.Archived => "ARCHIVED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
