using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using System = System;

namespace Stigg.Client.Models.V1.Subscriptions;

/// <summary>
/// Cancels an active subscription, either immediately or at a specified time such
/// as end of billing period.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubscriptionCancelParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Action on cancellation (downgrade or revoke)
    /// </summary>
    public ApiEnum<string, CancellationAction>? CancellationAction
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CancellationAction>>(
                "cancellationAction"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cancellationAction", value);
        }
    }

    /// <summary>
    /// When to cancel (immediate, period end, or date)
    /// </summary>
    public ApiEnum<string, CancellationTime>? CancellationTime
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CancellationTime>>(
                "cancellationTime"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cancellationTime", value);
        }
    }

    /// <summary>
    /// Subscription end date
    /// </summary>
    public System::DateTimeOffset? EndDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("endDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("endDate", value);
        }
    }

    /// <summary>
    /// If set, enables or disables prorating of credits on subscription cancellation.
    /// </summary>
    public bool? Prorate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("prorate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("prorate", value);
        }
    }

    public SubscriptionCancelParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionCancelParams(SubscriptionCancelParams subscriptionCancelParams)
        : base(subscriptionCancelParams)
    {
        this.ID = subscriptionCancelParams.ID;

        this._rawBodyData = new(subscriptionCancelParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SubscriptionCancelParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionCancelParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubscriptionCancelParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SubscriptionCancelParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/subscriptions/{0}/cancel", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
/// Action on cancellation (downgrade or revoke)
/// </summary>
[JsonConverter(typeof(CancellationActionConverter))]
public enum CancellationAction
{
    Default,
    RevokeEntitlements,
}

sealed class CancellationActionConverter : JsonConverter<CancellationAction>
{
    public override CancellationAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DEFAULT" => CancellationAction.Default,
            "REVOKE_ENTITLEMENTS" => CancellationAction.RevokeEntitlements,
            _ => (CancellationAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancellationAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancellationAction.Default => "DEFAULT",
                CancellationAction.RevokeEntitlements => "REVOKE_ENTITLEMENTS",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When to cancel (immediate, period end, or date)
/// </summary>
[JsonConverter(typeof(CancellationTimeConverter))]
public enum CancellationTime
{
    EndOfBillingPeriod,
    Immediate,
    SpecificDate,
}

sealed class CancellationTimeConverter : JsonConverter<CancellationTime>
{
    public override CancellationTime Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "END_OF_BILLING_PERIOD" => CancellationTime.EndOfBillingPeriod,
            "IMMEDIATE" => CancellationTime.Immediate,
            "SPECIFIC_DATE" => CancellationTime.SpecificDate,
            _ => (CancellationTime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CancellationTime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CancellationTime.EndOfBillingPeriod => "END_OF_BILLING_PERIOD",
                CancellationTime.Immediate => "IMMEDIATE",
                CancellationTime.SpecificDate => "SPECIFIC_DATE",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
