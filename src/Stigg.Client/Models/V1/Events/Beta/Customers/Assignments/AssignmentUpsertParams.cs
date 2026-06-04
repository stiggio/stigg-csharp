using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;

namespace Stigg.Client.Models.V1.Events.Beta.Customers.Assignments;

/// <summary>
/// Batched create-or-update of capability assignments. Existing assignments matched
/// by (entityId, capabilityId) are updated; new pairs are created. On update, omitted
/// fields (usageLimit, cadence) are preserved; on create both are required by the
/// governance service.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AssignmentUpsertParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Assignments to upsert (1–100 per request)
    /// </summary>
    public required IReadOnlyList<Assignment> Assignments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Assignment>>("assignments");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Assignment>>(
                "assignments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AssignmentUpsertParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssignmentUpsertParams(AssignmentUpsertParams assignmentUpsertParams)
        : base(assignmentUpsertParams)
    {
        this.ID = assignmentUpsertParams.ID;

        this._rawBodyData = new(assignmentUpsertParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AssignmentUpsertParams(
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
    AssignmentUpsertParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AssignmentUpsertParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
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

    public virtual bool Equals(AssignmentUpsertParams? other)
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1-beta/customers/{0}/assignments", this.ID)
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
/// A single assignment to create or update. The natural key is the `(entityId, capabilityId)`
/// pair. On create both `usageLimit` and `cadence` are required; on update they
/// may be omitted individually to preserve the existing value.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Assignment, AssignmentFromRaw>))]
public sealed record class Assignment : JsonModel
{
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
    /// Usage-reset cadence (required on create). Currently only `MONTH` is supported
    /// </summary>
    public ApiEnum<string, Cadence>? Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Cadence>>("cadence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cadence", value);
        }
    }

    /// <summary>
    /// Maximum usage allowed within one cadence window (required on create)
    /// </summary>
    public double? UsageLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("usageLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usageLimit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CapabilityID;
        _ = this.EntityID;
        this.Cadence?.Validate();
        _ = this.UsageLimit;
    }

    public Assignment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Assignment(Assignment assignment)
        : base(assignment) { }
#pragma warning restore CS8618

    public Assignment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Assignment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssignmentFromRaw.FromRawUnchecked"/>
    public static Assignment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AssignmentFromRaw : IFromRawJson<Assignment>
{
    /// <inheritdoc/>
    public Assignment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Assignment.FromRawUnchecked(rawData);
}

/// <summary>
/// Usage-reset cadence (required on create). Currently only `MONTH` is supported
/// </summary>
[JsonConverter(typeof(CadenceConverter))]
public enum Cadence
{
    Month,
}

sealed class CadenceConverter : JsonConverter<Cadence>
{
    public override Cadence Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => Cadence.Month,
            _ => (Cadence)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Cadence value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cadence.Month => "MONTH",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
