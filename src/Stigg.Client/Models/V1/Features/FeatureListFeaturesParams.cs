using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Features;

/// <summary>
/// Retrieves a paginated list of features in the environment.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FeatureListFeaturesParams : ParamsBase
{
    /// <summary>
    /// Filter by entity ID
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("id", value);
        }
    }

    /// <summary>
    /// Return items that come after this cursor
    /// </summary>
    public string? After
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("after", value);
        }
    }

    /// <summary>
    /// Return items that come before this cursor
    /// </summary>
    public string? Before
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("before", value);
        }
    }

    /// <summary>
    /// Filter by creation date using range operators: gt, gte, lt, lte
    /// </summary>
    public CreatedAt? CreatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<CreatedAt>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Filter by feature type. Supports comma-separated values for multiple types
    /// </summary>
    public IReadOnlyList<ApiEnum<string, FeatureListFeaturesParamsFeatureType>>? FeatureType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, FeatureListFeaturesParamsFeatureType>>
            >("featureType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<
                ApiEnum<string, FeatureListFeaturesParamsFeatureType>
            >?>("featureType", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Maximum number of items to return
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter by meter type. Supports comma-separated values for multiple types
    /// </summary>
    public IReadOnlyList<ApiEnum<string, FeatureListFeaturesParamsMeterType>>? MeterType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, FeatureListFeaturesParamsMeterType>>
            >("meterType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<
                ApiEnum<string, FeatureListFeaturesParamsMeterType>
            >?>("meterType", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Filter by feature status. Supports comma-separated values for multiple statuses
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Status>>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, Status>>>(
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, Status>>?>(
                "status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public FeatureListFeaturesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureListFeaturesParams(FeatureListFeaturesParams featureListFeaturesParams)
        : base(featureListFeaturesParams) { }
#pragma warning restore CS8618

    public FeatureListFeaturesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureListFeaturesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FeatureListFeaturesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FeatureListFeaturesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/features")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Filter by creation date using range operators: gt, gte, lt, lte
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    /// <summary>
    /// Greater than the specified createdAt value
    /// </summary>
    public DateTimeOffset? Gt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("gt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gt", value);
        }
    }

    /// <summary>
    /// Greater than or equal to the specified createdAt value
    /// </summary>
    public DateTimeOffset? Gte
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("gte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// Less than the specified createdAt value
    /// </summary>
    public DateTimeOffset? Lt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lt", value);
        }
    }

    /// <summary>
    /// Less than or equal to the specified createdAt value
    /// </summary>
    public DateTimeOffset? Lte
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lte");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gt;
        _ = this.Gte;
        _ = this.Lt;
        _ = this.Lte;
    }

    public CreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt(CreatedAt createdAt)
        : base(createdAt) { }
#pragma warning restore CS8618

    public CreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FeatureListFeaturesParamsFeatureTypeConverter))]
public enum FeatureListFeaturesParamsFeatureType
{
    Boolean,
    Number,
    Enum,
}

sealed class FeatureListFeaturesParamsFeatureTypeConverter
    : JsonConverter<FeatureListFeaturesParamsFeatureType>
{
    public override FeatureListFeaturesParamsFeatureType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOOLEAN" => FeatureListFeaturesParamsFeatureType.Boolean,
            "NUMBER" => FeatureListFeaturesParamsFeatureType.Number,
            "ENUM" => FeatureListFeaturesParamsFeatureType.Enum,
            _ => (FeatureListFeaturesParamsFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureListFeaturesParamsFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureListFeaturesParamsFeatureType.Boolean => "BOOLEAN",
                FeatureListFeaturesParamsFeatureType.Number => "NUMBER",
                FeatureListFeaturesParamsFeatureType.Enum => "ENUM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FeatureListFeaturesParamsMeterTypeConverter))]
public enum FeatureListFeaturesParamsMeterType
{
    None,
    Fluctuating,
    Incremental,
}

sealed class FeatureListFeaturesParamsMeterTypeConverter
    : JsonConverter<FeatureListFeaturesParamsMeterType>
{
    public override FeatureListFeaturesParamsMeterType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "None" => FeatureListFeaturesParamsMeterType.None,
            "FLUCTUATING" => FeatureListFeaturesParamsMeterType.Fluctuating,
            "INCREMENTAL" => FeatureListFeaturesParamsMeterType.Incremental,
            _ => (FeatureListFeaturesParamsMeterType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FeatureListFeaturesParamsMeterType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FeatureListFeaturesParamsMeterType.None => "None",
                FeatureListFeaturesParamsMeterType.Fluctuating => "FLUCTUATING",
                FeatureListFeaturesParamsMeterType.Incremental => "INCREMENTAL",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    New,
    Suspended,
    Active,
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
            "NEW" => Status.New,
            "SUSPENDED" => Status.Suspended,
            "ACTIVE" => Status.Active,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.New => "NEW",
                Status.Suspended => "SUSPENDED",
                Status.Active => "ACTIVE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
