using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;

namespace Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

/// <summary>
/// Revokes a previously granted promotional entitlement from a customer for a specific feature.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PromotionalEntitlementRevokeParams : ParamsBase
{
    public required string CustomerID { get; init; }

    public string? FeatureID { get; init; }

    public PromotionalEntitlementRevokeParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PromotionalEntitlementRevokeParams(
        PromotionalEntitlementRevokeParams promotionalEntitlementRevokeParams
    )
        : base(promotionalEntitlementRevokeParams)
    {
        this.CustomerID = promotionalEntitlementRevokeParams.CustomerID;
        this.FeatureID = promotionalEntitlementRevokeParams.FeatureID;
    }
#pragma warning restore CS8618

    public PromotionalEntitlementRevokeParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PromotionalEntitlementRevokeParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PromotionalEntitlementRevokeParams FromRawUnchecked(
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
                ["CustomerID"] = this.CustomerID,
                ["FeatureID"] = this.FeatureID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PromotionalEntitlementRevokeParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.CustomerID.Equals(other.CustomerID)
            && (this.FeatureID?.Equals(other.FeatureID) ?? other.FeatureID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/api/v1/customers/{0}/promotional/{1}",
                    this.CustomerID,
                    this.FeatureID
                )
        )
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
