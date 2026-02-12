using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Coupons;

/// <summary>
/// Retrieves a paginated list of coupons in the environment.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CouponListParams : ParamsBase
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
    /// Filter by coupon status. Supports comma-separated values for multiple statuses
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    /// <summary>
    /// Filter by coupon type (FIXED or PERCENTAGE)
    /// </summary>
    public ApiEnum<string, global::Stigg.Client.Models.V1.Coupons.Type>? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, global::Stigg.Client.Models.V1.Coupons.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("type", value);
        }
    }

    public CouponListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponListParams(CouponListParams couponListParams)
        : base(couponListParams) { }
#pragma warning restore CS8618

    public CouponListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CouponListParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CouponListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/coupons")
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
    public System::DateTimeOffset? Gt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("gt");
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
    public System::DateTimeOffset? Gte
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("gte");
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
    public System::DateTimeOffset? Lt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("lt");
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
    public System::DateTimeOffset? Lte
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("lte");
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

/// <summary>
/// Filter by coupon type (FIXED or PERCENTAGE)
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Fixed,
    Percentage,
}

sealed class TypeConverter : JsonConverter<global::Stigg.Client.Models.V1.Coupons.Type>
{
    public override global::Stigg.Client.Models.V1.Coupons.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FIXED" => global::Stigg.Client.Models.V1.Coupons.Type.Fixed,
            "PERCENTAGE" => global::Stigg.Client.Models.V1.Coupons.Type.Percentage,
            _ => (global::Stigg.Client.Models.V1.Coupons.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Stigg.Client.Models.V1.Coupons.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Stigg.Client.Models.V1.Coupons.Type.Fixed => "FIXED",
                global::Stigg.Client.Models.V1.Coupons.Type.Percentage => "PERCENTAGE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
