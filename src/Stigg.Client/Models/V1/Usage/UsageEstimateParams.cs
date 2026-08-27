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

namespace Stigg.Client.Models.V1.Usage;

/// <summary>
/// Estimates the credit cost of a usage report without recording it. Returns the
/// estimated cost per credit currency, the current balance, and the balance after
/// the estimated consumption.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UsageEstimateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Customer id
    /// </summary>
    public required string CustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("customerId");
        }
        init { this._rawBodyData.Set("customerId", value); }
    }

    /// <summary>
    /// Feature id
    /// </summary>
    public required string FeatureID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("featureId");
        }
        init { this._rawBodyData.Set("featureId", value); }
    }

    /// <summary>
    /// The value to report for usage. Must be a whole number — the REST API does
    /// not accept fractional (float) usage values; scale up (e.g. report cents instead
    /// of dollars, or milliseconds instead of seconds) if you need sub-unit precision.
    /// </summary>
    public required long Value
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("value");
        }
        init { this._rawBodyData.Set("value", value); }
    }

    /// <summary>
    /// Additional dimensions for the usage report
    /// </summary>
    public IReadOnlyDictionary<string, Dimension>? Dimensions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, Dimension>>(
                "dimensions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, Dimension>?>(
                "dimensions",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The customer resource this usage applies to. Optional — only required if
    /// the customer has multiple resources (for example, one subscription per workspace
    /// or site) and usage needs to be tracked separately per resource; omit it to
    /// report usage at the customer level.
    /// </summary>
    public string? ResourceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("resourceId");
        }
        init { this._rawBodyData.Set("resourceId", value); }
    }

    /// <summary>
    /// How the reported value is applied: DELTA (default) adds it to the feature's
    /// current usage; SET treats it as the new absolute usage total, and Stigg computes
    /// the delta internally.
    /// </summary>
    public ApiEnum<string, UpdateBehavior>? UpdateBehavior
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, UpdateBehavior>>(
                "updateBehavior"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("updateBehavior", value);
        }
    }

    public string? XAccountID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ACCOUNT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ACCOUNT-ID", value);
        }
    }

    public string? XEnvironmentID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-ENVIRONMENT-ID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-ENVIRONMENT-ID", value);
        }
    }

    public UsageEstimateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageEstimateParams(UsageEstimateParams usageEstimateParams)
        : base(usageEstimateParams)
    {
        this._rawBodyData = new(usageEstimateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UsageEstimateParams(
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
    UsageEstimateParams(
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
    public static UsageEstimateParams FromRawUnchecked(
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

    public virtual bool Equals(UsageEstimateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/usage/estimate"
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

[JsonConverter(typeof(DimensionConverter))]
public record class Dimension : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dimension(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Dimension(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Dimension(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Dimension(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new StiggInvalidDataException("Data did not match any variant of Dimension");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new StiggInvalidDataException("Data did not match any variant of Dimension"),
        };
    }

    public static implicit operator Dimension(string value) => new(value);

    public static implicit operator Dimension(double value) => new(value);

    public static implicit operator Dimension(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new StiggInvalidDataException("Data did not match any variant of Dimension");
        }
    }

    public virtual bool Equals(Dimension? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class DimensionConverter : JsonConverter<Dimension>
{
    public override Dimension? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is StiggInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Dimension value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// How the reported value is applied: DELTA (default) adds it to the feature's current
/// usage; SET treats it as the new absolute usage total, and Stigg computes the
/// delta internally.
/// </summary>
[JsonConverter(typeof(UpdateBehaviorConverter))]
public enum UpdateBehavior
{
    Delta,
    Set,
}

sealed class UpdateBehaviorConverter : JsonConverter<UpdateBehavior>
{
    public override UpdateBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DELTA" => UpdateBehavior.Delta,
            "SET" => UpdateBehavior.Set,
            _ => (UpdateBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UpdateBehavior.Delta => "DELTA",
                UpdateBehavior.Set => "SET",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
