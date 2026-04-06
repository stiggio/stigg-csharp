using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.Internal.Beta.EventQueues;

/// <summary>
/// Response object
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EventQueueUpdateResponse, EventQueueUpdateResponseFromRaw>)
)]
public sealed record class EventQueueUpdateResponse : JsonModel
{
    /// <summary>
    /// Event queue provisioning status and details
    /// </summary>
    public required EventQueueUpdateResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EventQueueUpdateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public EventQueueUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueUpdateResponse(EventQueueUpdateResponse eventQueueUpdateResponse)
        : base(eventQueueUpdateResponse) { }
#pragma warning restore CS8618

    public EventQueueUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueUpdateResponseFromRaw.FromRawUnchecked"/>
    public static EventQueueUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventQueueUpdateResponse(EventQueueUpdateResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class EventQueueUpdateResponseFromRaw : IFromRawJson<EventQueueUpdateResponse>
{
    /// <inheritdoc/>
    public EventQueueUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Event queue provisioning status and details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EventQueueUpdateResponseData, EventQueueUpdateResponseDataFromRaw>)
)]
public sealed record class EventQueueUpdateResponseData : JsonModel
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
    public required ApiEnum<string, EventQueueUpdateResponseDataRegion> Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EventQueueUpdateResponseDataRegion>
            >("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Current provisioning status
    /// </summary>
    public required ApiEnum<string, EventQueueUpdateResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EventQueueUpdateResponseDataStatus>
            >("status");
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

    public EventQueueUpdateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueUpdateResponseData(EventQueueUpdateResponseData eventQueueUpdateResponseData)
        : base(eventQueueUpdateResponseData) { }
#pragma warning restore CS8618

    public EventQueueUpdateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueUpdateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueUpdateResponseDataFromRaw.FromRawUnchecked"/>
    public static EventQueueUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventQueueUpdateResponseDataFromRaw : IFromRawJson<EventQueueUpdateResponseData>
{
    /// <inheritdoc/>
    public EventQueueUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueUpdateResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// AWS region where the queue is deployed
/// </summary>
[JsonConverter(typeof(EventQueueUpdateResponseDataRegionConverter))]
public enum EventQueueUpdateResponseDataRegion
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

sealed class EventQueueUpdateResponseDataRegionConverter
    : JsonConverter<EventQueueUpdateResponseDataRegion>
{
    public override EventQueueUpdateResponseDataRegion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us-east-1" => EventQueueUpdateResponseDataRegion.UsEast1,
            "us-east-2" => EventQueueUpdateResponseDataRegion.UsEast2,
            "us-west-1" => EventQueueUpdateResponseDataRegion.UsWest1,
            "us-west-2" => EventQueueUpdateResponseDataRegion.UsWest2,
            "ca-central-1" => EventQueueUpdateResponseDataRegion.CaCentral1,
            "eu-west-1" => EventQueueUpdateResponseDataRegion.EuWest1,
            "eu-west-2" => EventQueueUpdateResponseDataRegion.EuWest2,
            "eu-west-3" => EventQueueUpdateResponseDataRegion.EuWest3,
            "eu-central-1" => EventQueueUpdateResponseDataRegion.EuCentral1,
            "eu-central-2" => EventQueueUpdateResponseDataRegion.EuCentral2,
            "eu-north-1" => EventQueueUpdateResponseDataRegion.EuNorth1,
            "eu-south-1" => EventQueueUpdateResponseDataRegion.EuSouth1,
            "eu-south-2" => EventQueueUpdateResponseDataRegion.EuSouth2,
            "ap-southeast-1" => EventQueueUpdateResponseDataRegion.ApSoutheast1,
            "ap-southeast-2" => EventQueueUpdateResponseDataRegion.ApSoutheast2,
            "ap-southeast-3" => EventQueueUpdateResponseDataRegion.ApSoutheast3,
            "ap-northeast-1" => EventQueueUpdateResponseDataRegion.ApNortheast1,
            "ap-northeast-2" => EventQueueUpdateResponseDataRegion.ApNortheast2,
            "ap-northeast-3" => EventQueueUpdateResponseDataRegion.ApNortheast3,
            "ap-south-1" => EventQueueUpdateResponseDataRegion.ApSouth1,
            "ap-south-2" => EventQueueUpdateResponseDataRegion.ApSouth2,
            "ap-east-1" => EventQueueUpdateResponseDataRegion.ApEast1,
            "sa-east-1" => EventQueueUpdateResponseDataRegion.SaEast1,
            "af-south-1" => EventQueueUpdateResponseDataRegion.AfSouth1,
            "me-south-1" => EventQueueUpdateResponseDataRegion.MeSouth1,
            "me-central-1" => EventQueueUpdateResponseDataRegion.MeCentral1,
            "il-central-1" => EventQueueUpdateResponseDataRegion.IlCentral1,
            _ => (EventQueueUpdateResponseDataRegion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueUpdateResponseDataRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueUpdateResponseDataRegion.UsEast1 => "us-east-1",
                EventQueueUpdateResponseDataRegion.UsEast2 => "us-east-2",
                EventQueueUpdateResponseDataRegion.UsWest1 => "us-west-1",
                EventQueueUpdateResponseDataRegion.UsWest2 => "us-west-2",
                EventQueueUpdateResponseDataRegion.CaCentral1 => "ca-central-1",
                EventQueueUpdateResponseDataRegion.EuWest1 => "eu-west-1",
                EventQueueUpdateResponseDataRegion.EuWest2 => "eu-west-2",
                EventQueueUpdateResponseDataRegion.EuWest3 => "eu-west-3",
                EventQueueUpdateResponseDataRegion.EuCentral1 => "eu-central-1",
                EventQueueUpdateResponseDataRegion.EuCentral2 => "eu-central-2",
                EventQueueUpdateResponseDataRegion.EuNorth1 => "eu-north-1",
                EventQueueUpdateResponseDataRegion.EuSouth1 => "eu-south-1",
                EventQueueUpdateResponseDataRegion.EuSouth2 => "eu-south-2",
                EventQueueUpdateResponseDataRegion.ApSoutheast1 => "ap-southeast-1",
                EventQueueUpdateResponseDataRegion.ApSoutheast2 => "ap-southeast-2",
                EventQueueUpdateResponseDataRegion.ApSoutheast3 => "ap-southeast-3",
                EventQueueUpdateResponseDataRegion.ApNortheast1 => "ap-northeast-1",
                EventQueueUpdateResponseDataRegion.ApNortheast2 => "ap-northeast-2",
                EventQueueUpdateResponseDataRegion.ApNortheast3 => "ap-northeast-3",
                EventQueueUpdateResponseDataRegion.ApSouth1 => "ap-south-1",
                EventQueueUpdateResponseDataRegion.ApSouth2 => "ap-south-2",
                EventQueueUpdateResponseDataRegion.ApEast1 => "ap-east-1",
                EventQueueUpdateResponseDataRegion.SaEast1 => "sa-east-1",
                EventQueueUpdateResponseDataRegion.AfSouth1 => "af-south-1",
                EventQueueUpdateResponseDataRegion.MeSouth1 => "me-south-1",
                EventQueueUpdateResponseDataRegion.MeCentral1 => "me-central-1",
                EventQueueUpdateResponseDataRegion.IlCentral1 => "il-central-1",
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
[JsonConverter(typeof(EventQueueUpdateResponseDataStatusConverter))]
public enum EventQueueUpdateResponseDataStatus
{
    Provisioning,
    Active,
    Failed,
    Deprovisioning,
}

sealed class EventQueueUpdateResponseDataStatusConverter
    : JsonConverter<EventQueueUpdateResponseDataStatus>
{
    public override EventQueueUpdateResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROVISIONING" => EventQueueUpdateResponseDataStatus.Provisioning,
            "ACTIVE" => EventQueueUpdateResponseDataStatus.Active,
            "FAILED" => EventQueueUpdateResponseDataStatus.Failed,
            "DEPROVISIONING" => EventQueueUpdateResponseDataStatus.Deprovisioning,
            _ => (EventQueueUpdateResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueUpdateResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueUpdateResponseDataStatus.Provisioning => "PROVISIONING",
                EventQueueUpdateResponseDataStatus.Active => "ACTIVE",
                EventQueueUpdateResponseDataStatus.Failed => "FAILED",
                EventQueueUpdateResponseDataStatus.Deprovisioning => "DEPROVISIONING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
