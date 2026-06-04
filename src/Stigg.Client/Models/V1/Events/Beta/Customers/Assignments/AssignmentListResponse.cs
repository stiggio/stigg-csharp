using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Events.Beta.Customers.Assignments;

/// <summary>
/// A capability assignment for an entity belonging to a customer. Defines how much
/// of the capability the entity may consume (`usageLimit`) and how often the counter
/// resets (`cadence`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AssignmentListResponse, AssignmentListResponseFromRaw>))]
public sealed record class AssignmentListResponse : JsonModel
{
    /// <summary>
    /// Synthetic UUID identifier — also the cursor anchor for paginated lists
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
    /// Usage-reset cadence. Currently only `MONTH` is supported
    /// </summary>
    public required ApiEnum<string, AssignmentListResponseCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AssignmentListResponseCadence>>(
                "cadence"
            );
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The capability refId this assignment grants
    /// </summary>
    public required string CapabilityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("capabilityId");
        }
        init { this._rawData.Set("capabilityId", value); }
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
    /// The entity refId this assignment is attached to
    /// </summary>
    public required string EntityID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("entityId");
        }
        init { this._rawData.Set("entityId", value); }
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

    /// <summary>
    /// Maximum usage allowed within one cadence window
    /// </summary>
    public required double UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("usageLimit");
        }
        init { this._rawData.Set("usageLimit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Cadence.Validate();
        _ = this.CapabilityID;
        _ = this.CreatedAt;
        _ = this.EntityID;
        _ = this.UpdatedAt;
        _ = this.UsageLimit;
    }

    public AssignmentListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssignmentListResponse(AssignmentListResponse assignmentListResponse)
        : base(assignmentListResponse) { }
#pragma warning restore CS8618

    public AssignmentListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AssignmentListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssignmentListResponseFromRaw.FromRawUnchecked"/>
    public static AssignmentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AssignmentListResponseFromRaw : IFromRawJson<AssignmentListResponse>
{
    /// <inheritdoc/>
    public AssignmentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AssignmentListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Usage-reset cadence. Currently only `MONTH` is supported
/// </summary>
[JsonConverter(typeof(AssignmentListResponseCadenceConverter))]
public enum AssignmentListResponseCadence
{
    Month,
}

sealed class AssignmentListResponseCadenceConverter : JsonConverter<AssignmentListResponseCadence>
{
    public override AssignmentListResponseCadence Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => AssignmentListResponseCadence.Month,
            _ => (AssignmentListResponseCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AssignmentListResponseCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AssignmentListResponseCadence.Month => "MONTH",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
