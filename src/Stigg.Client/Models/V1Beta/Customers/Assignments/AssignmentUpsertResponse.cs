using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1Beta.Customers.Assignments;

/// <summary>
/// Assignments after upsert.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AssignmentUpsertResponse, AssignmentUpsertResponseFromRaw>)
)]
public sealed record class AssignmentUpsertResponse : JsonModel
{
    public required IReadOnlyList<Data> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Data>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public AssignmentUpsertResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssignmentUpsertResponse(AssignmentUpsertResponse assignmentUpsertResponse)
        : base(assignmentUpsertResponse) { }
#pragma warning restore CS8618

    public AssignmentUpsertResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AssignmentUpsertResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssignmentUpsertResponseFromRaw.FromRawUnchecked"/>
    public static AssignmentUpsertResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AssignmentUpsertResponse(IReadOnlyList<Data> data)
        : this()
    {
        this.Data = data;
    }
}

class AssignmentUpsertResponseFromRaw : IFromRawJson<AssignmentUpsertResponse>
{
    /// <inheritdoc/>
    public AssignmentUpsertResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AssignmentUpsertResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A capability assignment for an entity belonging to a customer. Defines how much
/// of the capability the entity may consume (`usageLimit`) and how often the counter
/// resets (`cadence`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public required ApiEnum<string, DataCadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataCadence>>("cadence");
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
/// Usage-reset cadence. Currently only `MONTH` is supported
/// </summary>
[JsonConverter(typeof(DataCadenceConverter))]
public enum DataCadence
{
    Month,
}

sealed class DataCadenceConverter : JsonConverter<DataCadence>
{
    public override DataCadence Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => DataCadence.Month,
            _ => (DataCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataCadence.Month => "MONTH",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
