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
    typeof(JsonModelConverter<EventQueueDeleteResponse, EventQueueDeleteResponseFromRaw>)
)]
public sealed record class EventQueueDeleteResponse : JsonModel
{
    /// <summary>
    /// Event queue provisioning status and details
    /// </summary>
    public required EventQueueDeleteResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EventQueueDeleteResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public EventQueueDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueDeleteResponse(EventQueueDeleteResponse eventQueueDeleteResponse)
        : base(eventQueueDeleteResponse) { }
#pragma warning restore CS8618

    public EventQueueDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueDeleteResponseFromRaw.FromRawUnchecked"/>
    public static EventQueueDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventQueueDeleteResponse(EventQueueDeleteResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class EventQueueDeleteResponseFromRaw : IFromRawJson<EventQueueDeleteResponse>
{
    /// <inheritdoc/>
    public EventQueueDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Event queue provisioning status and details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<EventQueueDeleteResponseData, EventQueueDeleteResponseDataFromRaw>)
)]
public sealed record class EventQueueDeleteResponseData : JsonModel
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
    public required ApiEnum<string, EventQueueDeleteResponseDataRegion> Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EventQueueDeleteResponseDataRegion>
            >("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Current provisioning status
    /// </summary>
    public required ApiEnum<string, EventQueueDeleteResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EventQueueDeleteResponseDataStatus>
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

    public EventQueueDeleteResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueDeleteResponseData(EventQueueDeleteResponseData eventQueueDeleteResponseData)
        : base(eventQueueDeleteResponseData) { }
#pragma warning restore CS8618

    public EventQueueDeleteResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueDeleteResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueDeleteResponseDataFromRaw.FromRawUnchecked"/>
    public static EventQueueDeleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventQueueDeleteResponseDataFromRaw : IFromRawJson<EventQueueDeleteResponseData>
{
    /// <inheritdoc/>
    public EventQueueDeleteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueDeleteResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// AWS region where the queue is deployed
/// </summary>
[JsonConverter(typeof(EventQueueDeleteResponseDataRegionConverter))]
public enum EventQueueDeleteResponseDataRegion
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

sealed class EventQueueDeleteResponseDataRegionConverter
    : JsonConverter<EventQueueDeleteResponseDataRegion>
{
    public override EventQueueDeleteResponseDataRegion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us-east-1" => EventQueueDeleteResponseDataRegion.UsEast1,
            "us-east-2" => EventQueueDeleteResponseDataRegion.UsEast2,
            "us-west-1" => EventQueueDeleteResponseDataRegion.UsWest1,
            "us-west-2" => EventQueueDeleteResponseDataRegion.UsWest2,
            "ca-central-1" => EventQueueDeleteResponseDataRegion.CaCentral1,
            "eu-west-1" => EventQueueDeleteResponseDataRegion.EuWest1,
            "eu-west-2" => EventQueueDeleteResponseDataRegion.EuWest2,
            "eu-west-3" => EventQueueDeleteResponseDataRegion.EuWest3,
            "eu-central-1" => EventQueueDeleteResponseDataRegion.EuCentral1,
            "eu-central-2" => EventQueueDeleteResponseDataRegion.EuCentral2,
            "eu-north-1" => EventQueueDeleteResponseDataRegion.EuNorth1,
            "eu-south-1" => EventQueueDeleteResponseDataRegion.EuSouth1,
            "eu-south-2" => EventQueueDeleteResponseDataRegion.EuSouth2,
            "ap-southeast-1" => EventQueueDeleteResponseDataRegion.ApSoutheast1,
            "ap-southeast-2" => EventQueueDeleteResponseDataRegion.ApSoutheast2,
            "ap-southeast-3" => EventQueueDeleteResponseDataRegion.ApSoutheast3,
            "ap-northeast-1" => EventQueueDeleteResponseDataRegion.ApNortheast1,
            "ap-northeast-2" => EventQueueDeleteResponseDataRegion.ApNortheast2,
            "ap-northeast-3" => EventQueueDeleteResponseDataRegion.ApNortheast3,
            "ap-south-1" => EventQueueDeleteResponseDataRegion.ApSouth1,
            "ap-south-2" => EventQueueDeleteResponseDataRegion.ApSouth2,
            "ap-east-1" => EventQueueDeleteResponseDataRegion.ApEast1,
            "sa-east-1" => EventQueueDeleteResponseDataRegion.SaEast1,
            "af-south-1" => EventQueueDeleteResponseDataRegion.AfSouth1,
            "me-south-1" => EventQueueDeleteResponseDataRegion.MeSouth1,
            "me-central-1" => EventQueueDeleteResponseDataRegion.MeCentral1,
            "il-central-1" => EventQueueDeleteResponseDataRegion.IlCentral1,
            _ => (EventQueueDeleteResponseDataRegion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueDeleteResponseDataRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueDeleteResponseDataRegion.UsEast1 => "us-east-1",
                EventQueueDeleteResponseDataRegion.UsEast2 => "us-east-2",
                EventQueueDeleteResponseDataRegion.UsWest1 => "us-west-1",
                EventQueueDeleteResponseDataRegion.UsWest2 => "us-west-2",
                EventQueueDeleteResponseDataRegion.CaCentral1 => "ca-central-1",
                EventQueueDeleteResponseDataRegion.EuWest1 => "eu-west-1",
                EventQueueDeleteResponseDataRegion.EuWest2 => "eu-west-2",
                EventQueueDeleteResponseDataRegion.EuWest3 => "eu-west-3",
                EventQueueDeleteResponseDataRegion.EuCentral1 => "eu-central-1",
                EventQueueDeleteResponseDataRegion.EuCentral2 => "eu-central-2",
                EventQueueDeleteResponseDataRegion.EuNorth1 => "eu-north-1",
                EventQueueDeleteResponseDataRegion.EuSouth1 => "eu-south-1",
                EventQueueDeleteResponseDataRegion.EuSouth2 => "eu-south-2",
                EventQueueDeleteResponseDataRegion.ApSoutheast1 => "ap-southeast-1",
                EventQueueDeleteResponseDataRegion.ApSoutheast2 => "ap-southeast-2",
                EventQueueDeleteResponseDataRegion.ApSoutheast3 => "ap-southeast-3",
                EventQueueDeleteResponseDataRegion.ApNortheast1 => "ap-northeast-1",
                EventQueueDeleteResponseDataRegion.ApNortheast2 => "ap-northeast-2",
                EventQueueDeleteResponseDataRegion.ApNortheast3 => "ap-northeast-3",
                EventQueueDeleteResponseDataRegion.ApSouth1 => "ap-south-1",
                EventQueueDeleteResponseDataRegion.ApSouth2 => "ap-south-2",
                EventQueueDeleteResponseDataRegion.ApEast1 => "ap-east-1",
                EventQueueDeleteResponseDataRegion.SaEast1 => "sa-east-1",
                EventQueueDeleteResponseDataRegion.AfSouth1 => "af-south-1",
                EventQueueDeleteResponseDataRegion.MeSouth1 => "me-south-1",
                EventQueueDeleteResponseDataRegion.MeCentral1 => "me-central-1",
                EventQueueDeleteResponseDataRegion.IlCentral1 => "il-central-1",
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
[JsonConverter(typeof(EventQueueDeleteResponseDataStatusConverter))]
public enum EventQueueDeleteResponseDataStatus
{
    Provisioning,
    Active,
    Failed,
    Deprovisioning,
}

sealed class EventQueueDeleteResponseDataStatusConverter
    : JsonConverter<EventQueueDeleteResponseDataStatus>
{
    public override EventQueueDeleteResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROVISIONING" => EventQueueDeleteResponseDataStatus.Provisioning,
            "ACTIVE" => EventQueueDeleteResponseDataStatus.Active,
            "FAILED" => EventQueueDeleteResponseDataStatus.Failed,
            "DEPROVISIONING" => EventQueueDeleteResponseDataStatus.Deprovisioning,
            _ => (EventQueueDeleteResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueDeleteResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueDeleteResponseDataStatus.Provisioning => "PROVISIONING",
                EventQueueDeleteResponseDataStatus.Active => "ACTIVE",
                EventQueueDeleteResponseDataStatus.Failed => "FAILED",
                EventQueueDeleteResponseDataStatus.Deprovisioning => "DEPROVISIONING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
