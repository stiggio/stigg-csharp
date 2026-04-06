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
    typeof(JsonModelConverter<EventQueueProvisionResponse, EventQueueProvisionResponseFromRaw>)
)]
public sealed record class EventQueueProvisionResponse : JsonModel
{
    /// <summary>
    /// Event queue provisioning status and details
    /// </summary>
    public required EventQueueProvisionResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EventQueueProvisionResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public EventQueueProvisionResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueProvisionResponse(EventQueueProvisionResponse eventQueueProvisionResponse)
        : base(eventQueueProvisionResponse) { }
#pragma warning restore CS8618

    public EventQueueProvisionResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueProvisionResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueProvisionResponseFromRaw.FromRawUnchecked"/>
    public static EventQueueProvisionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventQueueProvisionResponse(EventQueueProvisionResponseData data)
        : this()
    {
        this.Data = data;
    }
}

class EventQueueProvisionResponseFromRaw : IFromRawJson<EventQueueProvisionResponse>
{
    /// <inheritdoc/>
    public EventQueueProvisionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueProvisionResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Event queue provisioning status and details
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        EventQueueProvisionResponseData,
        EventQueueProvisionResponseDataFromRaw
    >)
)]
public sealed record class EventQueueProvisionResponseData : JsonModel
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
    public required ApiEnum<string, EventQueueProvisionResponseDataRegion> Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EventQueueProvisionResponseDataRegion>
            >("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Current provisioning status
    /// </summary>
    public required ApiEnum<string, EventQueueProvisionResponseDataStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EventQueueProvisionResponseDataStatus>
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

    public EventQueueProvisionResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueProvisionResponseData(
        EventQueueProvisionResponseData eventQueueProvisionResponseData
    )
        : base(eventQueueProvisionResponseData) { }
#pragma warning restore CS8618

    public EventQueueProvisionResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueProvisionResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueProvisionResponseDataFromRaw.FromRawUnchecked"/>
    public static EventQueueProvisionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventQueueProvisionResponseDataFromRaw : IFromRawJson<EventQueueProvisionResponseData>
{
    /// <inheritdoc/>
    public EventQueueProvisionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueProvisionResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// AWS region where the queue is deployed
/// </summary>
[JsonConverter(typeof(EventQueueProvisionResponseDataRegionConverter))]
public enum EventQueueProvisionResponseDataRegion
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

sealed class EventQueueProvisionResponseDataRegionConverter
    : JsonConverter<EventQueueProvisionResponseDataRegion>
{
    public override EventQueueProvisionResponseDataRegion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us-east-1" => EventQueueProvisionResponseDataRegion.UsEast1,
            "us-east-2" => EventQueueProvisionResponseDataRegion.UsEast2,
            "us-west-1" => EventQueueProvisionResponseDataRegion.UsWest1,
            "us-west-2" => EventQueueProvisionResponseDataRegion.UsWest2,
            "ca-central-1" => EventQueueProvisionResponseDataRegion.CaCentral1,
            "eu-west-1" => EventQueueProvisionResponseDataRegion.EuWest1,
            "eu-west-2" => EventQueueProvisionResponseDataRegion.EuWest2,
            "eu-west-3" => EventQueueProvisionResponseDataRegion.EuWest3,
            "eu-central-1" => EventQueueProvisionResponseDataRegion.EuCentral1,
            "eu-central-2" => EventQueueProvisionResponseDataRegion.EuCentral2,
            "eu-north-1" => EventQueueProvisionResponseDataRegion.EuNorth1,
            "eu-south-1" => EventQueueProvisionResponseDataRegion.EuSouth1,
            "eu-south-2" => EventQueueProvisionResponseDataRegion.EuSouth2,
            "ap-southeast-1" => EventQueueProvisionResponseDataRegion.ApSoutheast1,
            "ap-southeast-2" => EventQueueProvisionResponseDataRegion.ApSoutheast2,
            "ap-southeast-3" => EventQueueProvisionResponseDataRegion.ApSoutheast3,
            "ap-northeast-1" => EventQueueProvisionResponseDataRegion.ApNortheast1,
            "ap-northeast-2" => EventQueueProvisionResponseDataRegion.ApNortheast2,
            "ap-northeast-3" => EventQueueProvisionResponseDataRegion.ApNortheast3,
            "ap-south-1" => EventQueueProvisionResponseDataRegion.ApSouth1,
            "ap-south-2" => EventQueueProvisionResponseDataRegion.ApSouth2,
            "ap-east-1" => EventQueueProvisionResponseDataRegion.ApEast1,
            "sa-east-1" => EventQueueProvisionResponseDataRegion.SaEast1,
            "af-south-1" => EventQueueProvisionResponseDataRegion.AfSouth1,
            "me-south-1" => EventQueueProvisionResponseDataRegion.MeSouth1,
            "me-central-1" => EventQueueProvisionResponseDataRegion.MeCentral1,
            "il-central-1" => EventQueueProvisionResponseDataRegion.IlCentral1,
            _ => (EventQueueProvisionResponseDataRegion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueProvisionResponseDataRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueProvisionResponseDataRegion.UsEast1 => "us-east-1",
                EventQueueProvisionResponseDataRegion.UsEast2 => "us-east-2",
                EventQueueProvisionResponseDataRegion.UsWest1 => "us-west-1",
                EventQueueProvisionResponseDataRegion.UsWest2 => "us-west-2",
                EventQueueProvisionResponseDataRegion.CaCentral1 => "ca-central-1",
                EventQueueProvisionResponseDataRegion.EuWest1 => "eu-west-1",
                EventQueueProvisionResponseDataRegion.EuWest2 => "eu-west-2",
                EventQueueProvisionResponseDataRegion.EuWest3 => "eu-west-3",
                EventQueueProvisionResponseDataRegion.EuCentral1 => "eu-central-1",
                EventQueueProvisionResponseDataRegion.EuCentral2 => "eu-central-2",
                EventQueueProvisionResponseDataRegion.EuNorth1 => "eu-north-1",
                EventQueueProvisionResponseDataRegion.EuSouth1 => "eu-south-1",
                EventQueueProvisionResponseDataRegion.EuSouth2 => "eu-south-2",
                EventQueueProvisionResponseDataRegion.ApSoutheast1 => "ap-southeast-1",
                EventQueueProvisionResponseDataRegion.ApSoutheast2 => "ap-southeast-2",
                EventQueueProvisionResponseDataRegion.ApSoutheast3 => "ap-southeast-3",
                EventQueueProvisionResponseDataRegion.ApNortheast1 => "ap-northeast-1",
                EventQueueProvisionResponseDataRegion.ApNortheast2 => "ap-northeast-2",
                EventQueueProvisionResponseDataRegion.ApNortheast3 => "ap-northeast-3",
                EventQueueProvisionResponseDataRegion.ApSouth1 => "ap-south-1",
                EventQueueProvisionResponseDataRegion.ApSouth2 => "ap-south-2",
                EventQueueProvisionResponseDataRegion.ApEast1 => "ap-east-1",
                EventQueueProvisionResponseDataRegion.SaEast1 => "sa-east-1",
                EventQueueProvisionResponseDataRegion.AfSouth1 => "af-south-1",
                EventQueueProvisionResponseDataRegion.MeSouth1 => "me-south-1",
                EventQueueProvisionResponseDataRegion.MeCentral1 => "me-central-1",
                EventQueueProvisionResponseDataRegion.IlCentral1 => "il-central-1",
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
[JsonConverter(typeof(EventQueueProvisionResponseDataStatusConverter))]
public enum EventQueueProvisionResponseDataStatus
{
    Provisioning,
    Active,
    Failed,
    Deprovisioning,
}

sealed class EventQueueProvisionResponseDataStatusConverter
    : JsonConverter<EventQueueProvisionResponseDataStatus>
{
    public override EventQueueProvisionResponseDataStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROVISIONING" => EventQueueProvisionResponseDataStatus.Provisioning,
            "ACTIVE" => EventQueueProvisionResponseDataStatus.Active,
            "FAILED" => EventQueueProvisionResponseDataStatus.Failed,
            "DEPROVISIONING" => EventQueueProvisionResponseDataStatus.Deprovisioning,
            _ => (EventQueueProvisionResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueProvisionResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueProvisionResponseDataStatus.Provisioning => "PROVISIONING",
                EventQueueProvisionResponseDataStatus.Active => "ACTIVE",
                EventQueueProvisionResponseDataStatus.Failed => "FAILED",
                EventQueueProvisionResponseDataStatus.Deprovisioning => "DEPROVISIONING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
