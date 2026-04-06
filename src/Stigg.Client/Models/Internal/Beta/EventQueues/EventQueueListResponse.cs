using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.Internal.Beta.EventQueues;

/// <summary>
/// Response list object
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EventQueueListResponse, EventQueueListResponseFromRaw>))]
public sealed record class EventQueueListResponse : JsonModel
{
    public required IReadOnlyList<EventQueueListResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EventQueueListResponseData>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<EventQueueListResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including cursors for navigating through results
    /// </summary>
    public required Pagination Pagination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagination>("pagination");
        }
        init { this._rawData.Set("pagination", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Pagination.Validate();
    }

    public EventQueueListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueListResponse(EventQueueListResponse eventQueueListResponse)
        : base(eventQueueListResponse) { }
#pragma warning restore CS8618

    public EventQueueListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueListResponseFromRaw.FromRawUnchecked"/>
    public static EventQueueListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventQueueListResponseFromRaw : IFromRawJson<EventQueueListResponse>
{
    /// <inheritdoc/>
    public EventQueueListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Event queue provisioning status and details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EventQueueListResponseData, EventQueueListResponseDataFromRaw>)
)]
public sealed record class EventQueueListResponseData : JsonModel
{
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
    /// Unique queue identifier
    /// </summary>
    public required string QueueName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("queueName");
        }
        init { this._rawData.Set("queueName", value); }
    }

    /// <summary>
    /// AWS region where the queue is deployed
    /// </summary>
    public required ApiEnum<string, EventQueueListResponseDataRegion> Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventQueueListResponseDataRegion>>(
                "region"
            );
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Current provisioning status
    /// </summary>
    public required ApiEnum<string, EventQueueListResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, EventQueueListResponseDataStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
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
    /// SQS queue URL
    /// </summary>
    public string? QueueUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("queueUrl");
        }
        init { this._rawData.Set("queueUrl", value); }
    }

    /// <summary>
    /// IAM role ARN for queue access
    /// </summary>
    public string? RoleArn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("roleArn");
        }
        init { this._rawData.Set("roleArn", value); }
    }

    /// <summary>
    /// Queue suffix for disambiguation
    /// </summary>
    public string? Suffix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suffix");
        }
        init { this._rawData.Set("suffix", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.QueueName;
        this.Region.Validate();
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.QueueUrl;
        _ = this.RoleArn;
        _ = this.Suffix;
    }

    public EventQueueListResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueListResponseData(EventQueueListResponseData eventQueueListResponseData)
        : base(eventQueueListResponseData) { }
#pragma warning restore CS8618

    public EventQueueListResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueListResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueListResponseDataFromRaw.FromRawUnchecked"/>
    public static EventQueueListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventQueueListResponseDataFromRaw : IFromRawJson<EventQueueListResponseData>
{
    /// <inheritdoc/>
    public EventQueueListResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueListResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// AWS region where the queue is deployed
/// </summary>
[JsonConverter(typeof(EventQueueListResponseDataRegionConverter))]
public enum EventQueueListResponseDataRegion
{
    UsEast1,
    UsEast2,
    UsWest1,
    UsWest2,
    CaCentral1,
    EuWest1,
    EuWest2,
    EuWest3,
    EuCentral1,
    EuCentral2,
    EuNorth1,
    EuSouth1,
    EuSouth2,
    ApSoutheast1,
    ApSoutheast2,
    ApSoutheast3,
    ApNortheast1,
    ApNortheast2,
    ApNortheast3,
    ApSouth1,
    ApSouth2,
    ApEast1,
    SaEast1,
    AfSouth1,
    MeSouth1,
    MeCentral1,
    IlCentral1,
}

sealed class EventQueueListResponseDataRegionConverter
    : JsonConverter<EventQueueListResponseDataRegion>
{
    public override EventQueueListResponseDataRegion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us-east-1" => EventQueueListResponseDataRegion.UsEast1,
            "us-east-2" => EventQueueListResponseDataRegion.UsEast2,
            "us-west-1" => EventQueueListResponseDataRegion.UsWest1,
            "us-west-2" => EventQueueListResponseDataRegion.UsWest2,
            "ca-central-1" => EventQueueListResponseDataRegion.CaCentral1,
            "eu-west-1" => EventQueueListResponseDataRegion.EuWest1,
            "eu-west-2" => EventQueueListResponseDataRegion.EuWest2,
            "eu-west-3" => EventQueueListResponseDataRegion.EuWest3,
            "eu-central-1" => EventQueueListResponseDataRegion.EuCentral1,
            "eu-central-2" => EventQueueListResponseDataRegion.EuCentral2,
            "eu-north-1" => EventQueueListResponseDataRegion.EuNorth1,
            "eu-south-1" => EventQueueListResponseDataRegion.EuSouth1,
            "eu-south-2" => EventQueueListResponseDataRegion.EuSouth2,
            "ap-southeast-1" => EventQueueListResponseDataRegion.ApSoutheast1,
            "ap-southeast-2" => EventQueueListResponseDataRegion.ApSoutheast2,
            "ap-southeast-3" => EventQueueListResponseDataRegion.ApSoutheast3,
            "ap-northeast-1" => EventQueueListResponseDataRegion.ApNortheast1,
            "ap-northeast-2" => EventQueueListResponseDataRegion.ApNortheast2,
            "ap-northeast-3" => EventQueueListResponseDataRegion.ApNortheast3,
            "ap-south-1" => EventQueueListResponseDataRegion.ApSouth1,
            "ap-south-2" => EventQueueListResponseDataRegion.ApSouth2,
            "ap-east-1" => EventQueueListResponseDataRegion.ApEast1,
            "sa-east-1" => EventQueueListResponseDataRegion.SaEast1,
            "af-south-1" => EventQueueListResponseDataRegion.AfSouth1,
            "me-south-1" => EventQueueListResponseDataRegion.MeSouth1,
            "me-central-1" => EventQueueListResponseDataRegion.MeCentral1,
            "il-central-1" => EventQueueListResponseDataRegion.IlCentral1,
            _ => (EventQueueListResponseDataRegion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueListResponseDataRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueListResponseDataRegion.UsEast1 => "us-east-1",
                EventQueueListResponseDataRegion.UsEast2 => "us-east-2",
                EventQueueListResponseDataRegion.UsWest1 => "us-west-1",
                EventQueueListResponseDataRegion.UsWest2 => "us-west-2",
                EventQueueListResponseDataRegion.CaCentral1 => "ca-central-1",
                EventQueueListResponseDataRegion.EuWest1 => "eu-west-1",
                EventQueueListResponseDataRegion.EuWest2 => "eu-west-2",
                EventQueueListResponseDataRegion.EuWest3 => "eu-west-3",
                EventQueueListResponseDataRegion.EuCentral1 => "eu-central-1",
                EventQueueListResponseDataRegion.EuCentral2 => "eu-central-2",
                EventQueueListResponseDataRegion.EuNorth1 => "eu-north-1",
                EventQueueListResponseDataRegion.EuSouth1 => "eu-south-1",
                EventQueueListResponseDataRegion.EuSouth2 => "eu-south-2",
                EventQueueListResponseDataRegion.ApSoutheast1 => "ap-southeast-1",
                EventQueueListResponseDataRegion.ApSoutheast2 => "ap-southeast-2",
                EventQueueListResponseDataRegion.ApSoutheast3 => "ap-southeast-3",
                EventQueueListResponseDataRegion.ApNortheast1 => "ap-northeast-1",
                EventQueueListResponseDataRegion.ApNortheast2 => "ap-northeast-2",
                EventQueueListResponseDataRegion.ApNortheast3 => "ap-northeast-3",
                EventQueueListResponseDataRegion.ApSouth1 => "ap-south-1",
                EventQueueListResponseDataRegion.ApSouth2 => "ap-south-2",
                EventQueueListResponseDataRegion.ApEast1 => "ap-east-1",
                EventQueueListResponseDataRegion.SaEast1 => "sa-east-1",
                EventQueueListResponseDataRegion.AfSouth1 => "af-south-1",
                EventQueueListResponseDataRegion.MeSouth1 => "me-south-1",
                EventQueueListResponseDataRegion.MeCentral1 => "me-central-1",
                EventQueueListResponseDataRegion.IlCentral1 => "il-central-1",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Current provisioning status
/// </summary>
[JsonConverter(typeof(EventQueueListResponseDataStatusConverter))]
public enum EventQueueListResponseDataStatus
{
    Provisioning,
    Active,
    Failed,
    Deprovisioning,
}

sealed class EventQueueListResponseDataStatusConverter
    : JsonConverter<EventQueueListResponseDataStatus>
{
    public override EventQueueListResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROVISIONING" => EventQueueListResponseDataStatus.Provisioning,
            "ACTIVE" => EventQueueListResponseDataStatus.Active,
            "FAILED" => EventQueueListResponseDataStatus.Failed,
            "DEPROVISIONING" => EventQueueListResponseDataStatus.Deprovisioning,
            _ => (EventQueueListResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueListResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueListResponseDataStatus.Provisioning => "PROVISIONING",
                EventQueueListResponseDataStatus.Active => "ACTIVE",
                EventQueueListResponseDataStatus.Failed => "FAILED",
                EventQueueListResponseDataStatus.Deprovisioning => "DEPROVISIONING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Pagination metadata including cursors for navigating through results
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    /// <summary>
    /// Cursor for fetching the next page of results, or null if no additional pages exist
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// Cursor for fetching the previous page of results, or null if at the beginning
    /// </summary>
    public required string? Prev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev");
        }
        init { this._rawData.Set("prev", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Next;
        _ = this.Prev;
    }

    public Pagination() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pagination(Pagination pagination)
        : base(pagination) { }
#pragma warning restore CS8618

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}
