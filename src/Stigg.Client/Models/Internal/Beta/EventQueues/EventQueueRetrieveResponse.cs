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
    typeof(JsonModelConverter<EventQueueRetrieveResponse, EventQueueRetrieveResponseFromRaw>)
)]
public sealed record class EventQueueRetrieveResponse : JsonModel
{
    /// <summary>
    /// Event queue provisioning status and details
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

    public EventQueueRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueRetrieveResponse(EventQueueRetrieveResponse eventQueueRetrieveResponse)
        : base(eventQueueRetrieveResponse) { }
#pragma warning restore CS8618

    public EventQueueRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EventQueueRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventQueueRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EventQueueRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EventQueueRetrieveResponse(Data data)
        : this()
    {
        this.Data = data;
    }
}

class EventQueueRetrieveResponseFromRaw : IFromRawJson<EventQueueRetrieveResponse>
{
    /// <inheritdoc/>
    public EventQueueRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EventQueueRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Event queue provisioning status and details
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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
    public required ApiEnum<string, DataRegion> Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataRegion>>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Current provisioning status
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
/// AWS region where the queue is deployed
/// </summary>
[JsonConverter(typeof(DataRegionConverter))]
public enum DataRegion
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

sealed class DataRegionConverter : JsonConverter<DataRegion>
{
    public override DataRegion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us-east-1" => DataRegion.UsEast1,
            "us-east-2" => DataRegion.UsEast2,
            "us-west-1" => DataRegion.UsWest1,
            "us-west-2" => DataRegion.UsWest2,
            "ca-central-1" => DataRegion.CaCentral1,
            "eu-west-1" => DataRegion.EuWest1,
            "eu-west-2" => DataRegion.EuWest2,
            "eu-west-3" => DataRegion.EuWest3,
            "eu-central-1" => DataRegion.EuCentral1,
            "eu-central-2" => DataRegion.EuCentral2,
            "eu-north-1" => DataRegion.EuNorth1,
            "eu-south-1" => DataRegion.EuSouth1,
            "eu-south-2" => DataRegion.EuSouth2,
            "ap-southeast-1" => DataRegion.ApSoutheast1,
            "ap-southeast-2" => DataRegion.ApSoutheast2,
            "ap-southeast-3" => DataRegion.ApSoutheast3,
            "ap-northeast-1" => DataRegion.ApNortheast1,
            "ap-northeast-2" => DataRegion.ApNortheast2,
            "ap-northeast-3" => DataRegion.ApNortheast3,
            "ap-south-1" => DataRegion.ApSouth1,
            "ap-south-2" => DataRegion.ApSouth2,
            "ap-east-1" => DataRegion.ApEast1,
            "sa-east-1" => DataRegion.SaEast1,
            "af-south-1" => DataRegion.AfSouth1,
            "me-south-1" => DataRegion.MeSouth1,
            "me-central-1" => DataRegion.MeCentral1,
            "il-central-1" => DataRegion.IlCentral1,
            _ => (DataRegion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataRegion.UsEast1 => "us-east-1",
                DataRegion.UsEast2 => "us-east-2",
                DataRegion.UsWest1 => "us-west-1",
                DataRegion.UsWest2 => "us-west-2",
                DataRegion.CaCentral1 => "ca-central-1",
                DataRegion.EuWest1 => "eu-west-1",
                DataRegion.EuWest2 => "eu-west-2",
                DataRegion.EuWest3 => "eu-west-3",
                DataRegion.EuCentral1 => "eu-central-1",
                DataRegion.EuCentral2 => "eu-central-2",
                DataRegion.EuNorth1 => "eu-north-1",
                DataRegion.EuSouth1 => "eu-south-1",
                DataRegion.EuSouth2 => "eu-south-2",
                DataRegion.ApSoutheast1 => "ap-southeast-1",
                DataRegion.ApSoutheast2 => "ap-southeast-2",
                DataRegion.ApSoutheast3 => "ap-southeast-3",
                DataRegion.ApNortheast1 => "ap-northeast-1",
                DataRegion.ApNortheast2 => "ap-northeast-2",
                DataRegion.ApNortheast3 => "ap-northeast-3",
                DataRegion.ApSouth1 => "ap-south-1",
                DataRegion.ApSouth2 => "ap-south-2",
                DataRegion.ApEast1 => "ap-east-1",
                DataRegion.SaEast1 => "sa-east-1",
                DataRegion.AfSouth1 => "af-south-1",
                DataRegion.MeSouth1 => "me-south-1",
                DataRegion.MeCentral1 => "me-central-1",
                DataRegion.IlCentral1 => "il-central-1",
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Provisioning,
    Active,
    Failed,
    Deprovisioning,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PROVISIONING" => Status.Provisioning,
            "ACTIVE" => Status.Active,
            "FAILED" => Status.Failed,
            "DEPROVISIONING" => Status.Deprovisioning,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Provisioning => "PROVISIONING",
                Status.Active => "ACTIVE",
                Status.Failed => "FAILED",
                Status.Deprovisioning => "DEPROVISIONING",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
