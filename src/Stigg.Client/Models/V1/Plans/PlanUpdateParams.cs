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
using System = System;

namespace Stigg.Client.Models.V1.Plans;

/// <summary>
/// Updates an existing plan's properties such as display name, description, and metadata.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlanUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// The unique identifier for the entity in the billing provider
    /// </summary>
    public string? BillingID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("billingId");
        }
        init { this._rawBodyData.Set("billingId", value); }
    }

    /// <summary>
    /// Pricing configuration to set on the plan draft. Unlike the rest of this request,
    /// this is a full replace of the pricing configuration, not a merge — see SetPackagePricingRequest.
    /// </summary>
    public Charges? Charges
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Charges>("charges");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("charges", value);
        }
    }

    public IReadOnlyList<string>? CompatibleAddonIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "compatibleAddonIds"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "compatibleAddonIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Default trial configuration for the plan. When set, subscriptions provisioned
    /// on this plan without explicit trial settings automatically start in trial
    /// for the configured duration; leave unset for no automatic trial.
    /// </summary>
    public PlanUpdateParamsDefaultTrialConfig? DefaultTrialConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PlanUpdateParamsDefaultTrialConfig>(
                "defaultTrialConfig"
            );
        }
        init { this._rawBodyData.Set("defaultTrialConfig", value); }
    }

    /// <summary>
    /// The description of the package
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// The display name of the package
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Metadata associated with the entity
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The ID of the parent plan, if this plan should inherit entitlements from another
    /// plan. Optional — omit to create a standalone plan with no inherited entitlements.
    /// </summary>
    public string? ParentPlanID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("parentPlanId");
        }
        init { this._rawBodyData.Set("parentPlanId", value); }
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

    public PlanUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanUpdateParams(PlanUpdateParams planUpdateParams)
        : base(planUpdateParams)
    {
        this.ID = planUpdateParams.ID;

        this._rawBodyData = new(planUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PlanUpdateParams(
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
    PlanUpdateParams(
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
    public static PlanUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(PlanUpdateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/api/v1/plans/{0}", this.ID)
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
/// Pricing configuration to set on the plan draft. Unlike the rest of this request,
/// this is a full replace of the pricing configuration, not a merge — see SetPackagePricingRequest.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Charges, ChargesFromRaw>))]
public sealed record class Charges : JsonModel
{
    /// <summary>
    /// The pricing type (FREE, PAID, or CUSTOM)
    /// </summary>
    public required ApiEnum<string, ChargesPricingType> PricingType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChargesPricingType>>(
                "pricingType"
            );
        }
        init { this._rawData.Set("pricingType", value); }
    }

    /// <summary>
    /// Deprecated: billing integration ID
    /// </summary>
    public string? BillingID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingId", value);
        }
    }

    /// <summary>
    /// Minimum spend configuration per billing period
    /// </summary>
    public IReadOnlyList<MinimumSpend>? MinimumSpend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MinimumSpend>>("minimumSpend");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MinimumSpend>?>(
                "minimumSpend",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When overage charges are billed
    /// </summary>
    public ApiEnum<string, OverageBillingPeriod>? OverageBillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OverageBillingPeriod>>(
                "overageBillingPeriod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("overageBillingPeriod", value);
        }
    }

    /// <summary>
    /// Array of overage pricing model configurations. Replaces all existing overage
    /// pricing models on the draft — omit this to end up with no overage pricing.
    /// </summary>
    public IReadOnlyList<OveragePricingModel>? OveragePricingModels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OveragePricingModel>>(
                "overagePricingModels"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OveragePricingModel>?>(
                "overagePricingModels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of pricing model configurations. Replaces all existing base pricing
    /// models on the draft — omit this to end up with no base pricing.
    /// </summary>
    public IReadOnlyList<PricingModel>? PricingModels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PricingModel>>("pricingModels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PricingModel>?>(
                "pricingModels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PricingType.Validate();
        _ = this.BillingID;
        foreach (var item in this.MinimumSpend ?? [])
        {
            item.Validate();
        }
        this.OverageBillingPeriod?.Validate();
        foreach (var item in this.OveragePricingModels ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PricingModels ?? [])
        {
            item.Validate();
        }
    }

    public Charges() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Charges(Charges charges)
        : base(charges) { }
#pragma warning restore CS8618

    public Charges(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Charges(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChargesFromRaw.FromRawUnchecked"/>
    public static Charges FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Charges(ApiEnum<string, ChargesPricingType> pricingType)
        : this()
    {
        this.PricingType = pricingType;
    }
}

class ChargesFromRaw : IFromRawJson<Charges>
{
    /// <inheritdoc/>
    public Charges FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Charges.FromRawUnchecked(rawData);
}

/// <summary>
/// The pricing type (FREE, PAID, or CUSTOM)
/// </summary>
[JsonConverter(typeof(ChargesPricingTypeConverter))]
public enum ChargesPricingType
{
    Free,
    Paid,
    Custom,
}

sealed class ChargesPricingTypeConverter : JsonConverter<ChargesPricingType>
{
    public override ChargesPricingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FREE" => ChargesPricingType.Free,
            "PAID" => ChargesPricingType.Paid,
            "CUSTOM" => ChargesPricingType.Custom,
            _ => (ChargesPricingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChargesPricingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChargesPricingType.Free => "FREE",
                ChargesPricingType.Paid => "PAID",
                ChargesPricingType.Custom => "CUSTOM",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Minimum spend configuration for a billing period.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MinimumSpend, MinimumSpendFromRaw>))]
public sealed record class MinimumSpend : JsonModel
{
    /// <summary>
    /// The billing period
    /// </summary>
    public required ApiEnum<string, BillingPeriod> BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BillingPeriod>>("billingPeriod");
        }
        init { this._rawData.Set("billingPeriod", value); }
    }

    /// <summary>
    /// The minimum spend amount
    /// </summary>
    public required Minimum Minimum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Minimum>("minimum");
        }
        init { this._rawData.Set("minimum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingPeriod.Validate();
        this.Minimum.Validate();
    }

    public MinimumSpend() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MinimumSpend(MinimumSpend minimumSpend)
        : base(minimumSpend) { }
#pragma warning restore CS8618

    public MinimumSpend(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimumSpend(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MinimumSpendFromRaw.FromRawUnchecked"/>
    public static MinimumSpend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MinimumSpendFromRaw : IFromRawJson<MinimumSpend>
{
    /// <inheritdoc/>
    public MinimumSpend FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MinimumSpend.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing period
/// </summary>
[JsonConverter(typeof(BillingPeriodConverter))]
public enum BillingPeriod
{
    Monthly,
    Annually,
}

sealed class BillingPeriodConverter : JsonConverter<BillingPeriod>
{
    public override BillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => BillingPeriod.Monthly,
            "ANNUALLY" => BillingPeriod.Annually,
            _ => (BillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingPeriod.Monthly => "MONTHLY",
                BillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The minimum spend amount
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Minimum, MinimumFromRaw>))]
public sealed record class Minimum : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, Currency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Currency>>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public Minimum() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Minimum(Minimum minimum)
        : base(minimum) { }
#pragma warning restore CS8618

    public Minimum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Minimum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MinimumFromRaw.FromRawUnchecked"/>
    public static Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Minimum(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class MinimumFromRaw : IFromRawJson<Minimum>
{
    /// <inheritdoc/>
    public Minimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Minimum.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(CurrencyConverter))]
public enum Currency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => Currency.Usd,
            "aed" => Currency.Aed,
            "all" => Currency.All,
            "amd" => Currency.Amd,
            "ang" => Currency.Ang,
            "aud" => Currency.Aud,
            "awg" => Currency.Awg,
            "azn" => Currency.Azn,
            "bam" => Currency.Bam,
            "bbd" => Currency.Bbd,
            "bdt" => Currency.Bdt,
            "bgn" => Currency.Bgn,
            "bif" => Currency.Bif,
            "bmd" => Currency.Bmd,
            "bnd" => Currency.Bnd,
            "bsd" => Currency.Bsd,
            "bwp" => Currency.Bwp,
            "byn" => Currency.Byn,
            "bzd" => Currency.Bzd,
            "brl" => Currency.Brl,
            "cad" => Currency.Cad,
            "cdf" => Currency.Cdf,
            "chf" => Currency.Chf,
            "cny" => Currency.Cny,
            "czk" => Currency.Czk,
            "dkk" => Currency.Dkk,
            "dop" => Currency.Dop,
            "dzd" => Currency.Dzd,
            "egp" => Currency.Egp,
            "etb" => Currency.Etb,
            "eur" => Currency.Eur,
            "fjd" => Currency.Fjd,
            "gbp" => Currency.Gbp,
            "gel" => Currency.Gel,
            "gip" => Currency.Gip,
            "gmd" => Currency.Gmd,
            "gyd" => Currency.Gyd,
            "hkd" => Currency.Hkd,
            "hrk" => Currency.Hrk,
            "htg" => Currency.Htg,
            "idr" => Currency.Idr,
            "ils" => Currency.Ils,
            "inr" => Currency.Inr,
            "isk" => Currency.Isk,
            "jmd" => Currency.Jmd,
            "jpy" => Currency.Jpy,
            "kes" => Currency.Kes,
            "kgs" => Currency.Kgs,
            "khr" => Currency.Khr,
            "kmf" => Currency.Kmf,
            "krw" => Currency.Krw,
            "kyd" => Currency.Kyd,
            "kzt" => Currency.Kzt,
            "lbp" => Currency.Lbp,
            "lkr" => Currency.Lkr,
            "lrd" => Currency.Lrd,
            "lsl" => Currency.Lsl,
            "mad" => Currency.Mad,
            "mdl" => Currency.Mdl,
            "mga" => Currency.Mga,
            "mkd" => Currency.Mkd,
            "mmk" => Currency.Mmk,
            "mnt" => Currency.Mnt,
            "mop" => Currency.Mop,
            "mro" => Currency.Mro,
            "mvr" => Currency.Mvr,
            "mwk" => Currency.Mwk,
            "mxn" => Currency.Mxn,
            "myr" => Currency.Myr,
            "mzn" => Currency.Mzn,
            "nad" => Currency.Nad,
            "ngn" => Currency.Ngn,
            "nok" => Currency.Nok,
            "npr" => Currency.Npr,
            "nzd" => Currency.Nzd,
            "pgk" => Currency.Pgk,
            "php" => Currency.Php,
            "pkr" => Currency.Pkr,
            "pln" => Currency.Pln,
            "qar" => Currency.Qar,
            "ron" => Currency.Ron,
            "rsd" => Currency.Rsd,
            "rub" => Currency.Rub,
            "rwf" => Currency.Rwf,
            "sar" => Currency.Sar,
            "sbd" => Currency.Sbd,
            "scr" => Currency.Scr,
            "sek" => Currency.Sek,
            "sgd" => Currency.Sgd,
            "sle" => Currency.Sle,
            "sll" => Currency.Sll,
            "sos" => Currency.Sos,
            "szl" => Currency.Szl,
            "thb" => Currency.Thb,
            "tjs" => Currency.Tjs,
            "top" => Currency.Top,
            "try" => Currency.Try,
            "ttd" => Currency.Ttd,
            "tzs" => Currency.Tzs,
            "uah" => Currency.Uah,
            "uzs" => Currency.Uzs,
            "vnd" => Currency.Vnd,
            "vuv" => Currency.Vuv,
            "wst" => Currency.Wst,
            "xaf" => Currency.Xaf,
            "xcd" => Currency.Xcd,
            "yer" => Currency.Yer,
            "zar" => Currency.Zar,
            "zmw" => Currency.Zmw,
            "clp" => Currency.Clp,
            "djf" => Currency.Djf,
            "gnf" => Currency.Gnf,
            "ugx" => Currency.Ugx,
            "pyg" => Currency.Pyg,
            "xof" => Currency.Xof,
            "xpf" => Currency.Xpf,
            _ => (Currency)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Currency.Usd => "usd",
                Currency.Aed => "aed",
                Currency.All => "all",
                Currency.Amd => "amd",
                Currency.Ang => "ang",
                Currency.Aud => "aud",
                Currency.Awg => "awg",
                Currency.Azn => "azn",
                Currency.Bam => "bam",
                Currency.Bbd => "bbd",
                Currency.Bdt => "bdt",
                Currency.Bgn => "bgn",
                Currency.Bif => "bif",
                Currency.Bmd => "bmd",
                Currency.Bnd => "bnd",
                Currency.Bsd => "bsd",
                Currency.Bwp => "bwp",
                Currency.Byn => "byn",
                Currency.Bzd => "bzd",
                Currency.Brl => "brl",
                Currency.Cad => "cad",
                Currency.Cdf => "cdf",
                Currency.Chf => "chf",
                Currency.Cny => "cny",
                Currency.Czk => "czk",
                Currency.Dkk => "dkk",
                Currency.Dop => "dop",
                Currency.Dzd => "dzd",
                Currency.Egp => "egp",
                Currency.Etb => "etb",
                Currency.Eur => "eur",
                Currency.Fjd => "fjd",
                Currency.Gbp => "gbp",
                Currency.Gel => "gel",
                Currency.Gip => "gip",
                Currency.Gmd => "gmd",
                Currency.Gyd => "gyd",
                Currency.Hkd => "hkd",
                Currency.Hrk => "hrk",
                Currency.Htg => "htg",
                Currency.Idr => "idr",
                Currency.Ils => "ils",
                Currency.Inr => "inr",
                Currency.Isk => "isk",
                Currency.Jmd => "jmd",
                Currency.Jpy => "jpy",
                Currency.Kes => "kes",
                Currency.Kgs => "kgs",
                Currency.Khr => "khr",
                Currency.Kmf => "kmf",
                Currency.Krw => "krw",
                Currency.Kyd => "kyd",
                Currency.Kzt => "kzt",
                Currency.Lbp => "lbp",
                Currency.Lkr => "lkr",
                Currency.Lrd => "lrd",
                Currency.Lsl => "lsl",
                Currency.Mad => "mad",
                Currency.Mdl => "mdl",
                Currency.Mga => "mga",
                Currency.Mkd => "mkd",
                Currency.Mmk => "mmk",
                Currency.Mnt => "mnt",
                Currency.Mop => "mop",
                Currency.Mro => "mro",
                Currency.Mvr => "mvr",
                Currency.Mwk => "mwk",
                Currency.Mxn => "mxn",
                Currency.Myr => "myr",
                Currency.Mzn => "mzn",
                Currency.Nad => "nad",
                Currency.Ngn => "ngn",
                Currency.Nok => "nok",
                Currency.Npr => "npr",
                Currency.Nzd => "nzd",
                Currency.Pgk => "pgk",
                Currency.Php => "php",
                Currency.Pkr => "pkr",
                Currency.Pln => "pln",
                Currency.Qar => "qar",
                Currency.Ron => "ron",
                Currency.Rsd => "rsd",
                Currency.Rub => "rub",
                Currency.Rwf => "rwf",
                Currency.Sar => "sar",
                Currency.Sbd => "sbd",
                Currency.Scr => "scr",
                Currency.Sek => "sek",
                Currency.Sgd => "sgd",
                Currency.Sle => "sle",
                Currency.Sll => "sll",
                Currency.Sos => "sos",
                Currency.Szl => "szl",
                Currency.Thb => "thb",
                Currency.Tjs => "tjs",
                Currency.Top => "top",
                Currency.Try => "try",
                Currency.Ttd => "ttd",
                Currency.Tzs => "tzs",
                Currency.Uah => "uah",
                Currency.Uzs => "uzs",
                Currency.Vnd => "vnd",
                Currency.Vuv => "vuv",
                Currency.Wst => "wst",
                Currency.Xaf => "xaf",
                Currency.Xcd => "xcd",
                Currency.Yer => "yer",
                Currency.Zar => "zar",
                Currency.Zmw => "zmw",
                Currency.Clp => "clp",
                Currency.Djf => "djf",
                Currency.Gnf => "gnf",
                Currency.Ugx => "ugx",
                Currency.Pyg => "pyg",
                Currency.Xof => "xof",
                Currency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When overage charges are billed
/// </summary>
[JsonConverter(typeof(OverageBillingPeriodConverter))]
public enum OverageBillingPeriod
{
    OnSubscriptionRenewal,
    Monthly,
}

sealed class OverageBillingPeriodConverter : JsonConverter<OverageBillingPeriod>
{
    public override OverageBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ON_SUBSCRIPTION_RENEWAL" => OverageBillingPeriod.OnSubscriptionRenewal,
            "MONTHLY" => OverageBillingPeriod.Monthly,
            _ => (OverageBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OverageBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OverageBillingPeriod.OnSubscriptionRenewal => "ON_SUBSCRIPTION_RENEWAL",
                OverageBillingPeriod.Monthly => "MONTHLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Overage pricing model configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OveragePricingModel, OveragePricingModelFromRaw>))]
public sealed record class OveragePricingModel : JsonModel
{
    /// <summary>
    /// Price periods for overage pricing
    /// </summary>
    public required IReadOnlyList<PricePeriod> PricePeriods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PricePeriod>>("pricePeriods");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PricePeriod>>(
                "pricePeriods",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Credit entitlement to grant when a credit overage targets a currency not
    /// yet granted on the plan
    /// </summary>
    public CreditEntitlement? CreditEntitlement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditEntitlement>("creditEntitlement");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditEntitlement", value);
        }
    }

    /// <summary>
    /// The refId of the custom currency this credit overage applies to
    /// </summary>
    public string? CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currencyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currencyId", value);
        }
    }

    /// <summary>
    /// Entitlement configuration for the overage feature
    /// </summary>
    public Entitlement? Entitlement
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Entitlement>("entitlement");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entitlement", value);
        }
    }

    /// <summary>
    /// The feature ID for overage pricing
    /// </summary>
    public string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("featureId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.PricePeriods)
        {
            item.Validate();
        }
        this.CreditEntitlement?.Validate();
        _ = this.CurrencyID;
        this.Entitlement?.Validate();
        _ = this.FeatureID;
    }

    public OveragePricingModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OveragePricingModel(OveragePricingModel overagePricingModel)
        : base(overagePricingModel) { }
#pragma warning restore CS8618

    public OveragePricingModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OveragePricingModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OveragePricingModelFromRaw.FromRawUnchecked"/>
    public static OveragePricingModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OveragePricingModel(IReadOnlyList<PricePeriod> pricePeriods)
        : this()
    {
        this.PricePeriods = pricePeriods;
    }
}

class OveragePricingModelFromRaw : IFromRawJson<OveragePricingModel>
{
    /// <inheritdoc/>
    public OveragePricingModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OveragePricingModel.FromRawUnchecked(rawData);
}

/// <summary>
/// Price configuration for a specific billing period.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PricePeriod, PricePeriodFromRaw>))]
public sealed record class PricePeriod : JsonModel
{
    /// <summary>
    /// The billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public required ApiEnum<string, PricePeriodBillingPeriod> BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PricePeriodBillingPeriod>>(
                "billingPeriod"
            );
        }
        init { this._rawData.Set("billingPeriod", value); }
    }

    /// <summary>
    /// ISO country code for localized pricing, or "eu" for the European Union group
    /// you map countries into
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCountryCode", value);
        }
    }

    /// <summary>
    /// Block size for usage-based pricing
    /// </summary>
    public double? BlockSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("blockSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blockSize", value);
        }
    }

    /// <summary>
    /// When credits are granted
    /// </summary>
    public ApiEnum<string, CreditGrantCadence>? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreditGrantCadence>>(
                "creditGrantCadence"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditGrantCadence", value);
        }
    }

    /// <summary>
    /// Credit rate configuration for credit-based pricing
    /// </summary>
    public CreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditRate>("creditRate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditRate", value);
        }
    }

    /// <summary>
    /// The price amount and currency
    /// </summary>
    public Price? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Price>("price");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price", value);
        }
    }

    /// <summary>
    /// Tiered pricing configuration
    /// </summary>
    public IReadOnlyList<Tier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tier>>("tiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Tier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingPeriod.Validate();
        _ = this.BillingCountryCode;
        _ = this.BlockSize;
        this.CreditGrantCadence?.Validate();
        this.CreditRate?.Validate();
        this.Price?.Validate();
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public PricePeriod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricePeriod(PricePeriod pricePeriod)
        : base(pricePeriod) { }
#pragma warning restore CS8618

    public PricePeriod(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricePeriod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricePeriodFromRaw.FromRawUnchecked"/>
    public static PricePeriod FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PricePeriod(ApiEnum<string, PricePeriodBillingPeriod> billingPeriod)
        : this()
    {
        this.BillingPeriod = billingPeriod;
    }
}

class PricePeriodFromRaw : IFromRawJson<PricePeriod>
{
    /// <inheritdoc/>
    public PricePeriod FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PricePeriod.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing period (MONTHLY or ANNUALLY)
/// </summary>
[JsonConverter(typeof(PricePeriodBillingPeriodConverter))]
public enum PricePeriodBillingPeriod
{
    Monthly,
    Annually,
}

sealed class PricePeriodBillingPeriodConverter : JsonConverter<PricePeriodBillingPeriod>
{
    public override PricePeriodBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => PricePeriodBillingPeriod.Monthly,
            "ANNUALLY" => PricePeriodBillingPeriod.Annually,
            _ => (PricePeriodBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricePeriodBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricePeriodBillingPeriod.Monthly => "MONTHLY",
                PricePeriodBillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When credits are granted
/// </summary>
[JsonConverter(typeof(CreditGrantCadenceConverter))]
public enum CreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class CreditGrantCadenceConverter : JsonConverter<CreditGrantCadence>
{
    public override CreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" => CreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => CreditGrantCadence.Monthly,
            _ => (CreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditGrantCadence.BeginningOfBillingPeriod => "BEGINNING_OF_BILLING_PERIOD",
                CreditGrantCadence.Monthly => "MONTHLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit rate configuration for credit-based pricing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditRate, CreditRateFromRaw>))]
public sealed record class CreditRate : JsonModel
{
    /// <summary>
    /// The credit rate amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The custom currency ID
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currencyId");
        }
        init { this._rawData.Set("currencyId", value); }
    }

    /// <summary>
    /// Optional cost formula expression
    /// </summary>
    public string? CostFormula
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("costFormula");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("costFormula", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CurrencyID;
        _ = this.CostFormula;
    }

    public CreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditRate(CreditRate creditRate)
        : base(creditRate) { }
#pragma warning restore CS8618

    public CreditRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditRateFromRaw.FromRawUnchecked"/>
    public static CreditRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditRateFromRaw : IFromRawJson<CreditRate>
{
    /// <inheritdoc/>
    public CreditRate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The price amount and currency
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Price, PriceFromRaw>))]
public sealed record class Price : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, PriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PriceCurrency>>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public Price() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Price(Price price)
        : base(price) { }
#pragma warning restore CS8618

    public Price(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Price(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceFromRaw.FromRawUnchecked"/>
    public static Price FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Price(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class PriceFromRaw : IFromRawJson<Price>
{
    /// <inheritdoc/>
    public Price FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Price.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(PriceCurrencyConverter))]
public enum PriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class PriceCurrencyConverter : JsonConverter<PriceCurrency>
{
    public override PriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PriceCurrency.Usd,
            "aed" => PriceCurrency.Aed,
            "all" => PriceCurrency.All,
            "amd" => PriceCurrency.Amd,
            "ang" => PriceCurrency.Ang,
            "aud" => PriceCurrency.Aud,
            "awg" => PriceCurrency.Awg,
            "azn" => PriceCurrency.Azn,
            "bam" => PriceCurrency.Bam,
            "bbd" => PriceCurrency.Bbd,
            "bdt" => PriceCurrency.Bdt,
            "bgn" => PriceCurrency.Bgn,
            "bif" => PriceCurrency.Bif,
            "bmd" => PriceCurrency.Bmd,
            "bnd" => PriceCurrency.Bnd,
            "bsd" => PriceCurrency.Bsd,
            "bwp" => PriceCurrency.Bwp,
            "byn" => PriceCurrency.Byn,
            "bzd" => PriceCurrency.Bzd,
            "brl" => PriceCurrency.Brl,
            "cad" => PriceCurrency.Cad,
            "cdf" => PriceCurrency.Cdf,
            "chf" => PriceCurrency.Chf,
            "cny" => PriceCurrency.Cny,
            "czk" => PriceCurrency.Czk,
            "dkk" => PriceCurrency.Dkk,
            "dop" => PriceCurrency.Dop,
            "dzd" => PriceCurrency.Dzd,
            "egp" => PriceCurrency.Egp,
            "etb" => PriceCurrency.Etb,
            "eur" => PriceCurrency.Eur,
            "fjd" => PriceCurrency.Fjd,
            "gbp" => PriceCurrency.Gbp,
            "gel" => PriceCurrency.Gel,
            "gip" => PriceCurrency.Gip,
            "gmd" => PriceCurrency.Gmd,
            "gyd" => PriceCurrency.Gyd,
            "hkd" => PriceCurrency.Hkd,
            "hrk" => PriceCurrency.Hrk,
            "htg" => PriceCurrency.Htg,
            "idr" => PriceCurrency.Idr,
            "ils" => PriceCurrency.Ils,
            "inr" => PriceCurrency.Inr,
            "isk" => PriceCurrency.Isk,
            "jmd" => PriceCurrency.Jmd,
            "jpy" => PriceCurrency.Jpy,
            "kes" => PriceCurrency.Kes,
            "kgs" => PriceCurrency.Kgs,
            "khr" => PriceCurrency.Khr,
            "kmf" => PriceCurrency.Kmf,
            "krw" => PriceCurrency.Krw,
            "kyd" => PriceCurrency.Kyd,
            "kzt" => PriceCurrency.Kzt,
            "lbp" => PriceCurrency.Lbp,
            "lkr" => PriceCurrency.Lkr,
            "lrd" => PriceCurrency.Lrd,
            "lsl" => PriceCurrency.Lsl,
            "mad" => PriceCurrency.Mad,
            "mdl" => PriceCurrency.Mdl,
            "mga" => PriceCurrency.Mga,
            "mkd" => PriceCurrency.Mkd,
            "mmk" => PriceCurrency.Mmk,
            "mnt" => PriceCurrency.Mnt,
            "mop" => PriceCurrency.Mop,
            "mro" => PriceCurrency.Mro,
            "mvr" => PriceCurrency.Mvr,
            "mwk" => PriceCurrency.Mwk,
            "mxn" => PriceCurrency.Mxn,
            "myr" => PriceCurrency.Myr,
            "mzn" => PriceCurrency.Mzn,
            "nad" => PriceCurrency.Nad,
            "ngn" => PriceCurrency.Ngn,
            "nok" => PriceCurrency.Nok,
            "npr" => PriceCurrency.Npr,
            "nzd" => PriceCurrency.Nzd,
            "pgk" => PriceCurrency.Pgk,
            "php" => PriceCurrency.Php,
            "pkr" => PriceCurrency.Pkr,
            "pln" => PriceCurrency.Pln,
            "qar" => PriceCurrency.Qar,
            "ron" => PriceCurrency.Ron,
            "rsd" => PriceCurrency.Rsd,
            "rub" => PriceCurrency.Rub,
            "rwf" => PriceCurrency.Rwf,
            "sar" => PriceCurrency.Sar,
            "sbd" => PriceCurrency.Sbd,
            "scr" => PriceCurrency.Scr,
            "sek" => PriceCurrency.Sek,
            "sgd" => PriceCurrency.Sgd,
            "sle" => PriceCurrency.Sle,
            "sll" => PriceCurrency.Sll,
            "sos" => PriceCurrency.Sos,
            "szl" => PriceCurrency.Szl,
            "thb" => PriceCurrency.Thb,
            "tjs" => PriceCurrency.Tjs,
            "top" => PriceCurrency.Top,
            "try" => PriceCurrency.Try,
            "ttd" => PriceCurrency.Ttd,
            "tzs" => PriceCurrency.Tzs,
            "uah" => PriceCurrency.Uah,
            "uzs" => PriceCurrency.Uzs,
            "vnd" => PriceCurrency.Vnd,
            "vuv" => PriceCurrency.Vuv,
            "wst" => PriceCurrency.Wst,
            "xaf" => PriceCurrency.Xaf,
            "xcd" => PriceCurrency.Xcd,
            "yer" => PriceCurrency.Yer,
            "zar" => PriceCurrency.Zar,
            "zmw" => PriceCurrency.Zmw,
            "clp" => PriceCurrency.Clp,
            "djf" => PriceCurrency.Djf,
            "gnf" => PriceCurrency.Gnf,
            "ugx" => PriceCurrency.Ugx,
            "pyg" => PriceCurrency.Pyg,
            "xof" => PriceCurrency.Xof,
            "xpf" => PriceCurrency.Xpf,
            _ => (PriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceCurrency.Usd => "usd",
                PriceCurrency.Aed => "aed",
                PriceCurrency.All => "all",
                PriceCurrency.Amd => "amd",
                PriceCurrency.Ang => "ang",
                PriceCurrency.Aud => "aud",
                PriceCurrency.Awg => "awg",
                PriceCurrency.Azn => "azn",
                PriceCurrency.Bam => "bam",
                PriceCurrency.Bbd => "bbd",
                PriceCurrency.Bdt => "bdt",
                PriceCurrency.Bgn => "bgn",
                PriceCurrency.Bif => "bif",
                PriceCurrency.Bmd => "bmd",
                PriceCurrency.Bnd => "bnd",
                PriceCurrency.Bsd => "bsd",
                PriceCurrency.Bwp => "bwp",
                PriceCurrency.Byn => "byn",
                PriceCurrency.Bzd => "bzd",
                PriceCurrency.Brl => "brl",
                PriceCurrency.Cad => "cad",
                PriceCurrency.Cdf => "cdf",
                PriceCurrency.Chf => "chf",
                PriceCurrency.Cny => "cny",
                PriceCurrency.Czk => "czk",
                PriceCurrency.Dkk => "dkk",
                PriceCurrency.Dop => "dop",
                PriceCurrency.Dzd => "dzd",
                PriceCurrency.Egp => "egp",
                PriceCurrency.Etb => "etb",
                PriceCurrency.Eur => "eur",
                PriceCurrency.Fjd => "fjd",
                PriceCurrency.Gbp => "gbp",
                PriceCurrency.Gel => "gel",
                PriceCurrency.Gip => "gip",
                PriceCurrency.Gmd => "gmd",
                PriceCurrency.Gyd => "gyd",
                PriceCurrency.Hkd => "hkd",
                PriceCurrency.Hrk => "hrk",
                PriceCurrency.Htg => "htg",
                PriceCurrency.Idr => "idr",
                PriceCurrency.Ils => "ils",
                PriceCurrency.Inr => "inr",
                PriceCurrency.Isk => "isk",
                PriceCurrency.Jmd => "jmd",
                PriceCurrency.Jpy => "jpy",
                PriceCurrency.Kes => "kes",
                PriceCurrency.Kgs => "kgs",
                PriceCurrency.Khr => "khr",
                PriceCurrency.Kmf => "kmf",
                PriceCurrency.Krw => "krw",
                PriceCurrency.Kyd => "kyd",
                PriceCurrency.Kzt => "kzt",
                PriceCurrency.Lbp => "lbp",
                PriceCurrency.Lkr => "lkr",
                PriceCurrency.Lrd => "lrd",
                PriceCurrency.Lsl => "lsl",
                PriceCurrency.Mad => "mad",
                PriceCurrency.Mdl => "mdl",
                PriceCurrency.Mga => "mga",
                PriceCurrency.Mkd => "mkd",
                PriceCurrency.Mmk => "mmk",
                PriceCurrency.Mnt => "mnt",
                PriceCurrency.Mop => "mop",
                PriceCurrency.Mro => "mro",
                PriceCurrency.Mvr => "mvr",
                PriceCurrency.Mwk => "mwk",
                PriceCurrency.Mxn => "mxn",
                PriceCurrency.Myr => "myr",
                PriceCurrency.Mzn => "mzn",
                PriceCurrency.Nad => "nad",
                PriceCurrency.Ngn => "ngn",
                PriceCurrency.Nok => "nok",
                PriceCurrency.Npr => "npr",
                PriceCurrency.Nzd => "nzd",
                PriceCurrency.Pgk => "pgk",
                PriceCurrency.Php => "php",
                PriceCurrency.Pkr => "pkr",
                PriceCurrency.Pln => "pln",
                PriceCurrency.Qar => "qar",
                PriceCurrency.Ron => "ron",
                PriceCurrency.Rsd => "rsd",
                PriceCurrency.Rub => "rub",
                PriceCurrency.Rwf => "rwf",
                PriceCurrency.Sar => "sar",
                PriceCurrency.Sbd => "sbd",
                PriceCurrency.Scr => "scr",
                PriceCurrency.Sek => "sek",
                PriceCurrency.Sgd => "sgd",
                PriceCurrency.Sle => "sle",
                PriceCurrency.Sll => "sll",
                PriceCurrency.Sos => "sos",
                PriceCurrency.Szl => "szl",
                PriceCurrency.Thb => "thb",
                PriceCurrency.Tjs => "tjs",
                PriceCurrency.Top => "top",
                PriceCurrency.Try => "try",
                PriceCurrency.Ttd => "ttd",
                PriceCurrency.Tzs => "tzs",
                PriceCurrency.Uah => "uah",
                PriceCurrency.Uzs => "uzs",
                PriceCurrency.Vnd => "vnd",
                PriceCurrency.Vuv => "vuv",
                PriceCurrency.Wst => "wst",
                PriceCurrency.Xaf => "xaf",
                PriceCurrency.Xcd => "xcd",
                PriceCurrency.Yer => "yer",
                PriceCurrency.Zar => "zar",
                PriceCurrency.Zmw => "zmw",
                PriceCurrency.Clp => "clp",
                PriceCurrency.Djf => "djf",
                PriceCurrency.Gnf => "gnf",
                PriceCurrency.Ugx => "ugx",
                PriceCurrency.Pyg => "pyg",
                PriceCurrency.Xof => "xof",
                PriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A tier in tiered pricing.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tier, TierFromRaw>))]
public sealed record class Tier : JsonModel
{
    /// <summary>
    /// Flat price for this tier
    /// </summary>
    public FlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FlatPrice>("flatPrice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("flatPrice", value);
        }
    }

    /// <summary>
    /// Per-unit price in this tier
    /// </summary>
    public UnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnitPrice>("unitPrice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unitPrice", value);
        }
    }

    /// <summary>
    /// Upper bound of this tier (null for unlimited)
    /// </summary>
    public double? UpTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("upTo", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FlatPrice?.Validate();
        this.UnitPrice?.Validate();
        _ = this.UpTo;
    }

    public Tier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tier(Tier tier)
        : base(tier) { }
#pragma warning restore CS8618

    public Tier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TierFromRaw.FromRawUnchecked"/>
    public static Tier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TierFromRaw : IFromRawJson<Tier>
{
    /// <inheritdoc/>
    public Tier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tier.FromRawUnchecked(rawData);
}

/// <summary>
/// Flat price for this tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FlatPrice, FlatPriceFromRaw>))]
public sealed record class FlatPrice : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, FlatPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FlatPriceCurrency>>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public FlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlatPrice(FlatPrice flatPrice)
        : base(flatPrice) { }
#pragma warning restore CS8618

    public FlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlatPriceFromRaw.FromRawUnchecked"/>
    public static FlatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FlatPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class FlatPriceFromRaw : IFromRawJson<FlatPrice>
{
    /// <inheritdoc/>
    public FlatPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(FlatPriceCurrencyConverter))]
public enum FlatPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class FlatPriceCurrencyConverter : JsonConverter<FlatPriceCurrency>
{
    public override FlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => FlatPriceCurrency.Usd,
            "aed" => FlatPriceCurrency.Aed,
            "all" => FlatPriceCurrency.All,
            "amd" => FlatPriceCurrency.Amd,
            "ang" => FlatPriceCurrency.Ang,
            "aud" => FlatPriceCurrency.Aud,
            "awg" => FlatPriceCurrency.Awg,
            "azn" => FlatPriceCurrency.Azn,
            "bam" => FlatPriceCurrency.Bam,
            "bbd" => FlatPriceCurrency.Bbd,
            "bdt" => FlatPriceCurrency.Bdt,
            "bgn" => FlatPriceCurrency.Bgn,
            "bif" => FlatPriceCurrency.Bif,
            "bmd" => FlatPriceCurrency.Bmd,
            "bnd" => FlatPriceCurrency.Bnd,
            "bsd" => FlatPriceCurrency.Bsd,
            "bwp" => FlatPriceCurrency.Bwp,
            "byn" => FlatPriceCurrency.Byn,
            "bzd" => FlatPriceCurrency.Bzd,
            "brl" => FlatPriceCurrency.Brl,
            "cad" => FlatPriceCurrency.Cad,
            "cdf" => FlatPriceCurrency.Cdf,
            "chf" => FlatPriceCurrency.Chf,
            "cny" => FlatPriceCurrency.Cny,
            "czk" => FlatPriceCurrency.Czk,
            "dkk" => FlatPriceCurrency.Dkk,
            "dop" => FlatPriceCurrency.Dop,
            "dzd" => FlatPriceCurrency.Dzd,
            "egp" => FlatPriceCurrency.Egp,
            "etb" => FlatPriceCurrency.Etb,
            "eur" => FlatPriceCurrency.Eur,
            "fjd" => FlatPriceCurrency.Fjd,
            "gbp" => FlatPriceCurrency.Gbp,
            "gel" => FlatPriceCurrency.Gel,
            "gip" => FlatPriceCurrency.Gip,
            "gmd" => FlatPriceCurrency.Gmd,
            "gyd" => FlatPriceCurrency.Gyd,
            "hkd" => FlatPriceCurrency.Hkd,
            "hrk" => FlatPriceCurrency.Hrk,
            "htg" => FlatPriceCurrency.Htg,
            "idr" => FlatPriceCurrency.Idr,
            "ils" => FlatPriceCurrency.Ils,
            "inr" => FlatPriceCurrency.Inr,
            "isk" => FlatPriceCurrency.Isk,
            "jmd" => FlatPriceCurrency.Jmd,
            "jpy" => FlatPriceCurrency.Jpy,
            "kes" => FlatPriceCurrency.Kes,
            "kgs" => FlatPriceCurrency.Kgs,
            "khr" => FlatPriceCurrency.Khr,
            "kmf" => FlatPriceCurrency.Kmf,
            "krw" => FlatPriceCurrency.Krw,
            "kyd" => FlatPriceCurrency.Kyd,
            "kzt" => FlatPriceCurrency.Kzt,
            "lbp" => FlatPriceCurrency.Lbp,
            "lkr" => FlatPriceCurrency.Lkr,
            "lrd" => FlatPriceCurrency.Lrd,
            "lsl" => FlatPriceCurrency.Lsl,
            "mad" => FlatPriceCurrency.Mad,
            "mdl" => FlatPriceCurrency.Mdl,
            "mga" => FlatPriceCurrency.Mga,
            "mkd" => FlatPriceCurrency.Mkd,
            "mmk" => FlatPriceCurrency.Mmk,
            "mnt" => FlatPriceCurrency.Mnt,
            "mop" => FlatPriceCurrency.Mop,
            "mro" => FlatPriceCurrency.Mro,
            "mvr" => FlatPriceCurrency.Mvr,
            "mwk" => FlatPriceCurrency.Mwk,
            "mxn" => FlatPriceCurrency.Mxn,
            "myr" => FlatPriceCurrency.Myr,
            "mzn" => FlatPriceCurrency.Mzn,
            "nad" => FlatPriceCurrency.Nad,
            "ngn" => FlatPriceCurrency.Ngn,
            "nok" => FlatPriceCurrency.Nok,
            "npr" => FlatPriceCurrency.Npr,
            "nzd" => FlatPriceCurrency.Nzd,
            "pgk" => FlatPriceCurrency.Pgk,
            "php" => FlatPriceCurrency.Php,
            "pkr" => FlatPriceCurrency.Pkr,
            "pln" => FlatPriceCurrency.Pln,
            "qar" => FlatPriceCurrency.Qar,
            "ron" => FlatPriceCurrency.Ron,
            "rsd" => FlatPriceCurrency.Rsd,
            "rub" => FlatPriceCurrency.Rub,
            "rwf" => FlatPriceCurrency.Rwf,
            "sar" => FlatPriceCurrency.Sar,
            "sbd" => FlatPriceCurrency.Sbd,
            "scr" => FlatPriceCurrency.Scr,
            "sek" => FlatPriceCurrency.Sek,
            "sgd" => FlatPriceCurrency.Sgd,
            "sle" => FlatPriceCurrency.Sle,
            "sll" => FlatPriceCurrency.Sll,
            "sos" => FlatPriceCurrency.Sos,
            "szl" => FlatPriceCurrency.Szl,
            "thb" => FlatPriceCurrency.Thb,
            "tjs" => FlatPriceCurrency.Tjs,
            "top" => FlatPriceCurrency.Top,
            "try" => FlatPriceCurrency.Try,
            "ttd" => FlatPriceCurrency.Ttd,
            "tzs" => FlatPriceCurrency.Tzs,
            "uah" => FlatPriceCurrency.Uah,
            "uzs" => FlatPriceCurrency.Uzs,
            "vnd" => FlatPriceCurrency.Vnd,
            "vuv" => FlatPriceCurrency.Vuv,
            "wst" => FlatPriceCurrency.Wst,
            "xaf" => FlatPriceCurrency.Xaf,
            "xcd" => FlatPriceCurrency.Xcd,
            "yer" => FlatPriceCurrency.Yer,
            "zar" => FlatPriceCurrency.Zar,
            "zmw" => FlatPriceCurrency.Zmw,
            "clp" => FlatPriceCurrency.Clp,
            "djf" => FlatPriceCurrency.Djf,
            "gnf" => FlatPriceCurrency.Gnf,
            "ugx" => FlatPriceCurrency.Ugx,
            "pyg" => FlatPriceCurrency.Pyg,
            "xof" => FlatPriceCurrency.Xof,
            "xpf" => FlatPriceCurrency.Xpf,
            _ => (FlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FlatPriceCurrency.Usd => "usd",
                FlatPriceCurrency.Aed => "aed",
                FlatPriceCurrency.All => "all",
                FlatPriceCurrency.Amd => "amd",
                FlatPriceCurrency.Ang => "ang",
                FlatPriceCurrency.Aud => "aud",
                FlatPriceCurrency.Awg => "awg",
                FlatPriceCurrency.Azn => "azn",
                FlatPriceCurrency.Bam => "bam",
                FlatPriceCurrency.Bbd => "bbd",
                FlatPriceCurrency.Bdt => "bdt",
                FlatPriceCurrency.Bgn => "bgn",
                FlatPriceCurrency.Bif => "bif",
                FlatPriceCurrency.Bmd => "bmd",
                FlatPriceCurrency.Bnd => "bnd",
                FlatPriceCurrency.Bsd => "bsd",
                FlatPriceCurrency.Bwp => "bwp",
                FlatPriceCurrency.Byn => "byn",
                FlatPriceCurrency.Bzd => "bzd",
                FlatPriceCurrency.Brl => "brl",
                FlatPriceCurrency.Cad => "cad",
                FlatPriceCurrency.Cdf => "cdf",
                FlatPriceCurrency.Chf => "chf",
                FlatPriceCurrency.Cny => "cny",
                FlatPriceCurrency.Czk => "czk",
                FlatPriceCurrency.Dkk => "dkk",
                FlatPriceCurrency.Dop => "dop",
                FlatPriceCurrency.Dzd => "dzd",
                FlatPriceCurrency.Egp => "egp",
                FlatPriceCurrency.Etb => "etb",
                FlatPriceCurrency.Eur => "eur",
                FlatPriceCurrency.Fjd => "fjd",
                FlatPriceCurrency.Gbp => "gbp",
                FlatPriceCurrency.Gel => "gel",
                FlatPriceCurrency.Gip => "gip",
                FlatPriceCurrency.Gmd => "gmd",
                FlatPriceCurrency.Gyd => "gyd",
                FlatPriceCurrency.Hkd => "hkd",
                FlatPriceCurrency.Hrk => "hrk",
                FlatPriceCurrency.Htg => "htg",
                FlatPriceCurrency.Idr => "idr",
                FlatPriceCurrency.Ils => "ils",
                FlatPriceCurrency.Inr => "inr",
                FlatPriceCurrency.Isk => "isk",
                FlatPriceCurrency.Jmd => "jmd",
                FlatPriceCurrency.Jpy => "jpy",
                FlatPriceCurrency.Kes => "kes",
                FlatPriceCurrency.Kgs => "kgs",
                FlatPriceCurrency.Khr => "khr",
                FlatPriceCurrency.Kmf => "kmf",
                FlatPriceCurrency.Krw => "krw",
                FlatPriceCurrency.Kyd => "kyd",
                FlatPriceCurrency.Kzt => "kzt",
                FlatPriceCurrency.Lbp => "lbp",
                FlatPriceCurrency.Lkr => "lkr",
                FlatPriceCurrency.Lrd => "lrd",
                FlatPriceCurrency.Lsl => "lsl",
                FlatPriceCurrency.Mad => "mad",
                FlatPriceCurrency.Mdl => "mdl",
                FlatPriceCurrency.Mga => "mga",
                FlatPriceCurrency.Mkd => "mkd",
                FlatPriceCurrency.Mmk => "mmk",
                FlatPriceCurrency.Mnt => "mnt",
                FlatPriceCurrency.Mop => "mop",
                FlatPriceCurrency.Mro => "mro",
                FlatPriceCurrency.Mvr => "mvr",
                FlatPriceCurrency.Mwk => "mwk",
                FlatPriceCurrency.Mxn => "mxn",
                FlatPriceCurrency.Myr => "myr",
                FlatPriceCurrency.Mzn => "mzn",
                FlatPriceCurrency.Nad => "nad",
                FlatPriceCurrency.Ngn => "ngn",
                FlatPriceCurrency.Nok => "nok",
                FlatPriceCurrency.Npr => "npr",
                FlatPriceCurrency.Nzd => "nzd",
                FlatPriceCurrency.Pgk => "pgk",
                FlatPriceCurrency.Php => "php",
                FlatPriceCurrency.Pkr => "pkr",
                FlatPriceCurrency.Pln => "pln",
                FlatPriceCurrency.Qar => "qar",
                FlatPriceCurrency.Ron => "ron",
                FlatPriceCurrency.Rsd => "rsd",
                FlatPriceCurrency.Rub => "rub",
                FlatPriceCurrency.Rwf => "rwf",
                FlatPriceCurrency.Sar => "sar",
                FlatPriceCurrency.Sbd => "sbd",
                FlatPriceCurrency.Scr => "scr",
                FlatPriceCurrency.Sek => "sek",
                FlatPriceCurrency.Sgd => "sgd",
                FlatPriceCurrency.Sle => "sle",
                FlatPriceCurrency.Sll => "sll",
                FlatPriceCurrency.Sos => "sos",
                FlatPriceCurrency.Szl => "szl",
                FlatPriceCurrency.Thb => "thb",
                FlatPriceCurrency.Tjs => "tjs",
                FlatPriceCurrency.Top => "top",
                FlatPriceCurrency.Try => "try",
                FlatPriceCurrency.Ttd => "ttd",
                FlatPriceCurrency.Tzs => "tzs",
                FlatPriceCurrency.Uah => "uah",
                FlatPriceCurrency.Uzs => "uzs",
                FlatPriceCurrency.Vnd => "vnd",
                FlatPriceCurrency.Vuv => "vuv",
                FlatPriceCurrency.Wst => "wst",
                FlatPriceCurrency.Xaf => "xaf",
                FlatPriceCurrency.Xcd => "xcd",
                FlatPriceCurrency.Yer => "yer",
                FlatPriceCurrency.Zar => "zar",
                FlatPriceCurrency.Zmw => "zmw",
                FlatPriceCurrency.Clp => "clp",
                FlatPriceCurrency.Djf => "djf",
                FlatPriceCurrency.Gnf => "gnf",
                FlatPriceCurrency.Ugx => "ugx",
                FlatPriceCurrency.Pyg => "pyg",
                FlatPriceCurrency.Xof => "xof",
                FlatPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Per-unit price in this tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UnitPrice, UnitPriceFromRaw>))]
public sealed record class UnitPrice : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, UnitPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UnitPriceCurrency>>("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public UnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnitPrice(UnitPrice unitPrice)
        : base(unitPrice) { }
#pragma warning restore CS8618

    public UnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnitPriceFromRaw.FromRawUnchecked"/>
    public static UnitPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UnitPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class UnitPriceFromRaw : IFromRawJson<UnitPrice>
{
    /// <inheritdoc/>
    public UnitPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(UnitPriceCurrencyConverter))]
public enum UnitPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class UnitPriceCurrencyConverter : JsonConverter<UnitPriceCurrency>
{
    public override UnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => UnitPriceCurrency.Usd,
            "aed" => UnitPriceCurrency.Aed,
            "all" => UnitPriceCurrency.All,
            "amd" => UnitPriceCurrency.Amd,
            "ang" => UnitPriceCurrency.Ang,
            "aud" => UnitPriceCurrency.Aud,
            "awg" => UnitPriceCurrency.Awg,
            "azn" => UnitPriceCurrency.Azn,
            "bam" => UnitPriceCurrency.Bam,
            "bbd" => UnitPriceCurrency.Bbd,
            "bdt" => UnitPriceCurrency.Bdt,
            "bgn" => UnitPriceCurrency.Bgn,
            "bif" => UnitPriceCurrency.Bif,
            "bmd" => UnitPriceCurrency.Bmd,
            "bnd" => UnitPriceCurrency.Bnd,
            "bsd" => UnitPriceCurrency.Bsd,
            "bwp" => UnitPriceCurrency.Bwp,
            "byn" => UnitPriceCurrency.Byn,
            "bzd" => UnitPriceCurrency.Bzd,
            "brl" => UnitPriceCurrency.Brl,
            "cad" => UnitPriceCurrency.Cad,
            "cdf" => UnitPriceCurrency.Cdf,
            "chf" => UnitPriceCurrency.Chf,
            "cny" => UnitPriceCurrency.Cny,
            "czk" => UnitPriceCurrency.Czk,
            "dkk" => UnitPriceCurrency.Dkk,
            "dop" => UnitPriceCurrency.Dop,
            "dzd" => UnitPriceCurrency.Dzd,
            "egp" => UnitPriceCurrency.Egp,
            "etb" => UnitPriceCurrency.Etb,
            "eur" => UnitPriceCurrency.Eur,
            "fjd" => UnitPriceCurrency.Fjd,
            "gbp" => UnitPriceCurrency.Gbp,
            "gel" => UnitPriceCurrency.Gel,
            "gip" => UnitPriceCurrency.Gip,
            "gmd" => UnitPriceCurrency.Gmd,
            "gyd" => UnitPriceCurrency.Gyd,
            "hkd" => UnitPriceCurrency.Hkd,
            "hrk" => UnitPriceCurrency.Hrk,
            "htg" => UnitPriceCurrency.Htg,
            "idr" => UnitPriceCurrency.Idr,
            "ils" => UnitPriceCurrency.Ils,
            "inr" => UnitPriceCurrency.Inr,
            "isk" => UnitPriceCurrency.Isk,
            "jmd" => UnitPriceCurrency.Jmd,
            "jpy" => UnitPriceCurrency.Jpy,
            "kes" => UnitPriceCurrency.Kes,
            "kgs" => UnitPriceCurrency.Kgs,
            "khr" => UnitPriceCurrency.Khr,
            "kmf" => UnitPriceCurrency.Kmf,
            "krw" => UnitPriceCurrency.Krw,
            "kyd" => UnitPriceCurrency.Kyd,
            "kzt" => UnitPriceCurrency.Kzt,
            "lbp" => UnitPriceCurrency.Lbp,
            "lkr" => UnitPriceCurrency.Lkr,
            "lrd" => UnitPriceCurrency.Lrd,
            "lsl" => UnitPriceCurrency.Lsl,
            "mad" => UnitPriceCurrency.Mad,
            "mdl" => UnitPriceCurrency.Mdl,
            "mga" => UnitPriceCurrency.Mga,
            "mkd" => UnitPriceCurrency.Mkd,
            "mmk" => UnitPriceCurrency.Mmk,
            "mnt" => UnitPriceCurrency.Mnt,
            "mop" => UnitPriceCurrency.Mop,
            "mro" => UnitPriceCurrency.Mro,
            "mvr" => UnitPriceCurrency.Mvr,
            "mwk" => UnitPriceCurrency.Mwk,
            "mxn" => UnitPriceCurrency.Mxn,
            "myr" => UnitPriceCurrency.Myr,
            "mzn" => UnitPriceCurrency.Mzn,
            "nad" => UnitPriceCurrency.Nad,
            "ngn" => UnitPriceCurrency.Ngn,
            "nok" => UnitPriceCurrency.Nok,
            "npr" => UnitPriceCurrency.Npr,
            "nzd" => UnitPriceCurrency.Nzd,
            "pgk" => UnitPriceCurrency.Pgk,
            "php" => UnitPriceCurrency.Php,
            "pkr" => UnitPriceCurrency.Pkr,
            "pln" => UnitPriceCurrency.Pln,
            "qar" => UnitPriceCurrency.Qar,
            "ron" => UnitPriceCurrency.Ron,
            "rsd" => UnitPriceCurrency.Rsd,
            "rub" => UnitPriceCurrency.Rub,
            "rwf" => UnitPriceCurrency.Rwf,
            "sar" => UnitPriceCurrency.Sar,
            "sbd" => UnitPriceCurrency.Sbd,
            "scr" => UnitPriceCurrency.Scr,
            "sek" => UnitPriceCurrency.Sek,
            "sgd" => UnitPriceCurrency.Sgd,
            "sle" => UnitPriceCurrency.Sle,
            "sll" => UnitPriceCurrency.Sll,
            "sos" => UnitPriceCurrency.Sos,
            "szl" => UnitPriceCurrency.Szl,
            "thb" => UnitPriceCurrency.Thb,
            "tjs" => UnitPriceCurrency.Tjs,
            "top" => UnitPriceCurrency.Top,
            "try" => UnitPriceCurrency.Try,
            "ttd" => UnitPriceCurrency.Ttd,
            "tzs" => UnitPriceCurrency.Tzs,
            "uah" => UnitPriceCurrency.Uah,
            "uzs" => UnitPriceCurrency.Uzs,
            "vnd" => UnitPriceCurrency.Vnd,
            "vuv" => UnitPriceCurrency.Vuv,
            "wst" => UnitPriceCurrency.Wst,
            "xaf" => UnitPriceCurrency.Xaf,
            "xcd" => UnitPriceCurrency.Xcd,
            "yer" => UnitPriceCurrency.Yer,
            "zar" => UnitPriceCurrency.Zar,
            "zmw" => UnitPriceCurrency.Zmw,
            "clp" => UnitPriceCurrency.Clp,
            "djf" => UnitPriceCurrency.Djf,
            "gnf" => UnitPriceCurrency.Gnf,
            "ugx" => UnitPriceCurrency.Ugx,
            "pyg" => UnitPriceCurrency.Pyg,
            "xof" => UnitPriceCurrency.Xof,
            "xpf" => UnitPriceCurrency.Xpf,
            _ => (UnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnitPriceCurrency.Usd => "usd",
                UnitPriceCurrency.Aed => "aed",
                UnitPriceCurrency.All => "all",
                UnitPriceCurrency.Amd => "amd",
                UnitPriceCurrency.Ang => "ang",
                UnitPriceCurrency.Aud => "aud",
                UnitPriceCurrency.Awg => "awg",
                UnitPriceCurrency.Azn => "azn",
                UnitPriceCurrency.Bam => "bam",
                UnitPriceCurrency.Bbd => "bbd",
                UnitPriceCurrency.Bdt => "bdt",
                UnitPriceCurrency.Bgn => "bgn",
                UnitPriceCurrency.Bif => "bif",
                UnitPriceCurrency.Bmd => "bmd",
                UnitPriceCurrency.Bnd => "bnd",
                UnitPriceCurrency.Bsd => "bsd",
                UnitPriceCurrency.Bwp => "bwp",
                UnitPriceCurrency.Byn => "byn",
                UnitPriceCurrency.Bzd => "bzd",
                UnitPriceCurrency.Brl => "brl",
                UnitPriceCurrency.Cad => "cad",
                UnitPriceCurrency.Cdf => "cdf",
                UnitPriceCurrency.Chf => "chf",
                UnitPriceCurrency.Cny => "cny",
                UnitPriceCurrency.Czk => "czk",
                UnitPriceCurrency.Dkk => "dkk",
                UnitPriceCurrency.Dop => "dop",
                UnitPriceCurrency.Dzd => "dzd",
                UnitPriceCurrency.Egp => "egp",
                UnitPriceCurrency.Etb => "etb",
                UnitPriceCurrency.Eur => "eur",
                UnitPriceCurrency.Fjd => "fjd",
                UnitPriceCurrency.Gbp => "gbp",
                UnitPriceCurrency.Gel => "gel",
                UnitPriceCurrency.Gip => "gip",
                UnitPriceCurrency.Gmd => "gmd",
                UnitPriceCurrency.Gyd => "gyd",
                UnitPriceCurrency.Hkd => "hkd",
                UnitPriceCurrency.Hrk => "hrk",
                UnitPriceCurrency.Htg => "htg",
                UnitPriceCurrency.Idr => "idr",
                UnitPriceCurrency.Ils => "ils",
                UnitPriceCurrency.Inr => "inr",
                UnitPriceCurrency.Isk => "isk",
                UnitPriceCurrency.Jmd => "jmd",
                UnitPriceCurrency.Jpy => "jpy",
                UnitPriceCurrency.Kes => "kes",
                UnitPriceCurrency.Kgs => "kgs",
                UnitPriceCurrency.Khr => "khr",
                UnitPriceCurrency.Kmf => "kmf",
                UnitPriceCurrency.Krw => "krw",
                UnitPriceCurrency.Kyd => "kyd",
                UnitPriceCurrency.Kzt => "kzt",
                UnitPriceCurrency.Lbp => "lbp",
                UnitPriceCurrency.Lkr => "lkr",
                UnitPriceCurrency.Lrd => "lrd",
                UnitPriceCurrency.Lsl => "lsl",
                UnitPriceCurrency.Mad => "mad",
                UnitPriceCurrency.Mdl => "mdl",
                UnitPriceCurrency.Mga => "mga",
                UnitPriceCurrency.Mkd => "mkd",
                UnitPriceCurrency.Mmk => "mmk",
                UnitPriceCurrency.Mnt => "mnt",
                UnitPriceCurrency.Mop => "mop",
                UnitPriceCurrency.Mro => "mro",
                UnitPriceCurrency.Mvr => "mvr",
                UnitPriceCurrency.Mwk => "mwk",
                UnitPriceCurrency.Mxn => "mxn",
                UnitPriceCurrency.Myr => "myr",
                UnitPriceCurrency.Mzn => "mzn",
                UnitPriceCurrency.Nad => "nad",
                UnitPriceCurrency.Ngn => "ngn",
                UnitPriceCurrency.Nok => "nok",
                UnitPriceCurrency.Npr => "npr",
                UnitPriceCurrency.Nzd => "nzd",
                UnitPriceCurrency.Pgk => "pgk",
                UnitPriceCurrency.Php => "php",
                UnitPriceCurrency.Pkr => "pkr",
                UnitPriceCurrency.Pln => "pln",
                UnitPriceCurrency.Qar => "qar",
                UnitPriceCurrency.Ron => "ron",
                UnitPriceCurrency.Rsd => "rsd",
                UnitPriceCurrency.Rub => "rub",
                UnitPriceCurrency.Rwf => "rwf",
                UnitPriceCurrency.Sar => "sar",
                UnitPriceCurrency.Sbd => "sbd",
                UnitPriceCurrency.Scr => "scr",
                UnitPriceCurrency.Sek => "sek",
                UnitPriceCurrency.Sgd => "sgd",
                UnitPriceCurrency.Sle => "sle",
                UnitPriceCurrency.Sll => "sll",
                UnitPriceCurrency.Sos => "sos",
                UnitPriceCurrency.Szl => "szl",
                UnitPriceCurrency.Thb => "thb",
                UnitPriceCurrency.Tjs => "tjs",
                UnitPriceCurrency.Top => "top",
                UnitPriceCurrency.Try => "try",
                UnitPriceCurrency.Ttd => "ttd",
                UnitPriceCurrency.Tzs => "tzs",
                UnitPriceCurrency.Uah => "uah",
                UnitPriceCurrency.Uzs => "uzs",
                UnitPriceCurrency.Vnd => "vnd",
                UnitPriceCurrency.Vuv => "vuv",
                UnitPriceCurrency.Wst => "wst",
                UnitPriceCurrency.Xaf => "xaf",
                UnitPriceCurrency.Xcd => "xcd",
                UnitPriceCurrency.Yer => "yer",
                UnitPriceCurrency.Zar => "zar",
                UnitPriceCurrency.Zmw => "zmw",
                UnitPriceCurrency.Clp => "clp",
                UnitPriceCurrency.Djf => "djf",
                UnitPriceCurrency.Gnf => "gnf",
                UnitPriceCurrency.Ugx => "ugx",
                UnitPriceCurrency.Pyg => "pyg",
                UnitPriceCurrency.Xof => "xof",
                UnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit entitlement to grant when a credit overage targets a currency not yet granted
/// on the plan
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreditEntitlement, CreditEntitlementFromRaw>))]
public sealed record class CreditEntitlement : JsonModel
{
    /// <summary>
    /// The base credit balance granted per cadence
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The credit grant cadence (MONTH or YEAR)
    /// </summary>
    public required ApiEnum<string, Cadence> Cadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Cadence>>("cadence");
        }
        init { this._rawData.Set("cadence", value); }
    }

    /// <summary>
    /// The refId of the custom currency to grant
    /// </summary>
    public required string CustomCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("customCurrencyId");
        }
        init { this._rawData.Set("customCurrencyId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Cadence.Validate();
        _ = this.CustomCurrencyID;
    }

    public CreditEntitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditEntitlement(CreditEntitlement creditEntitlement)
        : base(creditEntitlement) { }
#pragma warning restore CS8618

    public CreditEntitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditEntitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditEntitlementFromRaw.FromRawUnchecked"/>
    public static CreditEntitlement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditEntitlementFromRaw : IFromRawJson<CreditEntitlement>
{
    /// <inheritdoc/>
    public CreditEntitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditEntitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// The credit grant cadence (MONTH or YEAR)
/// </summary>
[JsonConverter(typeof(CadenceConverter))]
public enum Cadence
{
    Month,
    Year,
}

sealed class CadenceConverter : JsonConverter<Cadence>
{
    public override Cadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTH" => Cadence.Month,
            "YEAR" => Cadence.Year,
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
                Cadence.Year => "YEAR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Entitlement configuration for the overage feature
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Entitlement, EntitlementFromRaw>))]
public sealed record class Entitlement : JsonModel
{
    /// <summary>
    /// The feature ID for the entitlement
    /// </summary>
    public required string FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("featureId");
        }
        init { this._rawData.Set("featureId", value); }
    }

    /// <summary>
    /// Whether the limit is soft (allows overage)
    /// </summary>
    public bool? HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasSoftLimit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasSoftLimit", value);
        }
    }

    /// <summary>
    /// Whether usage is unlimited
    /// </summary>
    public bool? HasUnlimitedUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasUnlimitedUsage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasUnlimitedUsage", value);
        }
    }

    /// <summary>
    /// Monthly reset configuration
    /// </summary>
    public MonthlyResetPeriodConfiguration? MonthlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MonthlyResetPeriodConfiguration>(
                "monthlyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monthlyResetPeriodConfiguration", value);
        }
    }

    /// <summary>
    /// The usage reset period
    /// </summary>
    public ApiEnum<string, ResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ResetPeriod>>("resetPeriod");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resetPeriod", value);
        }
    }

    /// <summary>
    /// The usage limit before overage kicks in
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

    /// <summary>
    /// Weekly reset configuration
    /// </summary>
    public WeeklyResetPeriodConfiguration? WeeklyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WeeklyResetPeriodConfiguration>(
                "weeklyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("weeklyResetPeriodConfiguration", value);
        }
    }

    /// <summary>
    /// Yearly reset configuration
    /// </summary>
    public YearlyResetPeriodConfiguration? YearlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<YearlyResetPeriodConfiguration>(
                "yearlyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("yearlyResetPeriodConfiguration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FeatureID;
        _ = this.HasSoftLimit;
        _ = this.HasUnlimitedUsage;
        this.MonthlyResetPeriodConfiguration?.Validate();
        this.ResetPeriod?.Validate();
        _ = this.UsageLimit;
        this.WeeklyResetPeriodConfiguration?.Validate();
        this.YearlyResetPeriodConfiguration?.Validate();
    }

    public Entitlement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entitlement(Entitlement entitlement)
        : base(entitlement) { }
#pragma warning restore CS8618

    public Entitlement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Entitlement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EntitlementFromRaw.FromRawUnchecked"/>
    public static Entitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Entitlement(string featureID)
        : this()
    {
        this.FeatureID = featureID;
    }
}

class EntitlementFromRaw : IFromRawJson<Entitlement>
{
    /// <inheritdoc/>
    public Entitlement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Entitlement.FromRawUnchecked(rawData);
}

/// <summary>
/// Monthly reset configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MonthlyResetPeriodConfiguration,
        MonthlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class MonthlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<string, AccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccordingTo>>("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public MonthlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MonthlyResetPeriodConfiguration(
        MonthlyResetPeriodConfiguration monthlyResetPeriodConfiguration
    )
        : base(monthlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public MonthlyResetPeriodConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonthlyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MonthlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static MonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MonthlyResetPeriodConfiguration(ApiEnum<string, AccordingTo> accordingTo)
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class MonthlyResetPeriodConfigurationFromRaw : IFromRawJson<MonthlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public MonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MonthlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(typeof(AccordingToConverter))]
public enum AccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class AccordingToConverter : JsonConverter<AccordingTo>
{
    public override AccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => AccordingTo.SubscriptionStart,
            "StartOfTheMonth" => AccordingTo.StartOfTheMonth,
            _ => (AccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccordingTo.SubscriptionStart => "SubscriptionStart",
                AccordingTo.StartOfTheMonth => "StartOfTheMonth",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The usage reset period
/// </summary>
[JsonConverter(typeof(ResetPeriodConverter))]
public enum ResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class ResetPeriodConverter : JsonConverter<ResetPeriod>
{
    public override ResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => ResetPeriod.Year,
            "MONTH" => ResetPeriod.Month,
            "WEEK" => ResetPeriod.Week,
            "DAY" => ResetPeriod.Day,
            "HOUR" => ResetPeriod.Hour,
            _ => (ResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResetPeriod.Year => "YEAR",
                ResetPeriod.Month => "MONTH",
                ResetPeriod.Week => "WEEK",
                ResetPeriod.Day => "DAY",
                ResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Weekly reset configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WeeklyResetPeriodConfiguration,
        WeeklyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class WeeklyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public WeeklyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WeeklyResetPeriodConfiguration(
        WeeklyResetPeriodConfiguration weeklyResetPeriodConfiguration
    )
        : base(weeklyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public WeeklyResetPeriodConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WeeklyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WeeklyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static WeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WeeklyResetPeriodConfiguration(
        ApiEnum<string, WeeklyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class WeeklyResetPeriodConfigurationFromRaw : IFromRawJson<WeeklyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public WeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WeeklyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(typeof(WeeklyResetPeriodConfigurationAccordingToConverter))]
public enum WeeklyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
    EverySunday,
    EveryMonday,
    EveryTuesday,
    EveryWednesday,
    EveryThursday,
    EveryFriday,
    EverySaturday,
}

sealed class WeeklyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<WeeklyResetPeriodConfigurationAccordingTo>
{
    public override WeeklyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "EverySunday" => WeeklyResetPeriodConfigurationAccordingTo.EverySunday,
            "EveryMonday" => WeeklyResetPeriodConfigurationAccordingTo.EveryMonday,
            "EveryTuesday" => WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday,
            "EveryWednesday" => WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday,
            "EveryThursday" => WeeklyResetPeriodConfigurationAccordingTo.EveryThursday,
            "EveryFriday" => WeeklyResetPeriodConfigurationAccordingTo.EveryFriday,
            "EverySaturday" => WeeklyResetPeriodConfigurationAccordingTo.EverySaturday,
            _ => (WeeklyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WeeklyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart => "SubscriptionStart",
                WeeklyResetPeriodConfigurationAccordingTo.EverySunday => "EverySunday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryMonday => "EveryMonday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryTuesday => "EveryTuesday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryWednesday => "EveryWednesday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryThursday => "EveryThursday",
                WeeklyResetPeriodConfigurationAccordingTo.EveryFriday => "EveryFriday",
                WeeklyResetPeriodConfigurationAccordingTo.EverySaturday => "EverySaturday",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Yearly reset configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        YearlyResetPeriodConfiguration,
        YearlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class YearlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public YearlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public YearlyResetPeriodConfiguration(
        YearlyResetPeriodConfiguration yearlyResetPeriodConfiguration
    )
        : base(yearlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public YearlyResetPeriodConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    YearlyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="YearlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static YearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public YearlyResetPeriodConfiguration(
        ApiEnum<string, YearlyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class YearlyResetPeriodConfigurationFromRaw : IFromRawJson<YearlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public YearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => YearlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(typeof(YearlyResetPeriodConfigurationAccordingToConverter))]
public enum YearlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
}

sealed class YearlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<YearlyResetPeriodConfigurationAccordingTo>
{
    public override YearlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" => YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            _ => (YearlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        YearlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart => "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A pricing model configuration with billing details and price periods.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PricingModel, PricingModelFromRaw>))]
public sealed record class PricingModel : JsonModel
{
    /// <summary>
    /// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED)
    /// </summary>
    public required ApiEnum<string, BillingModel> BillingModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BillingModel>>("billingModel");
        }
        init { this._rawData.Set("billingModel", value); }
    }

    /// <summary>
    /// Array of price period configurations (at least one required)
    /// </summary>
    public required IReadOnlyList<PricingModelPricePeriod> PricePeriods
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PricingModelPricePeriod>>(
                "pricePeriods"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PricingModelPricePeriod>>(
                "pricePeriods",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The billing cadence (RECURRING or ONE_OFF)
    /// </summary>
    public ApiEnum<string, BillingCadence>? BillingCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillingCadence>>(
                "billingCadence"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCadence", value);
        }
    }

    /// <summary>
    /// The feature ID this pricing model is associated with
    /// </summary>
    public string? FeatureID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("featureId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("featureId", value);
        }
    }

    /// <summary>
    /// Maximum number of units (max 999999)
    /// </summary>
    public long? MaxUnitQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxUnitQuantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxUnitQuantity", value);
        }
    }

    /// <summary>
    /// Minimum number of units
    /// </summary>
    public long? MinUnitQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("minUnitQuantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minUnitQuantity", value);
        }
    }

    /// <summary>
    /// Monthly reset period configuration
    /// </summary>
    public PricingModelMonthlyResetPeriodConfiguration? MonthlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PricingModelMonthlyResetPeriodConfiguration>(
                "monthlyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monthlyResetPeriodConfiguration", value);
        }
    }

    /// <summary>
    /// The usage reset period
    /// </summary>
    public ApiEnum<string, PricingModelResetPeriod>? ResetPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PricingModelResetPeriod>>(
                "resetPeriod"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resetPeriod", value);
        }
    }

    /// <summary>
    /// The tiered pricing mode (VOLUME or GRADUATED)
    /// </summary>
    public ApiEnum<string, TiersMode>? TiersMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TiersMode>>("tiersMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tiersMode", value);
        }
    }

    /// <summary>
    /// The custom currency ID for top-up pricing
    /// </summary>
    public string? TopUpCustomCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("topUpCustomCurrencyId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("topUpCustomCurrencyId", value);
        }
    }

    /// <summary>
    /// Weekly reset period configuration
    /// </summary>
    public PricingModelWeeklyResetPeriodConfiguration? WeeklyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PricingModelWeeklyResetPeriodConfiguration>(
                "weeklyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("weeklyResetPeriodConfiguration", value);
        }
    }

    /// <summary>
    /// Yearly reset period configuration
    /// </summary>
    public PricingModelYearlyResetPeriodConfiguration? YearlyResetPeriodConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PricingModelYearlyResetPeriodConfiguration>(
                "yearlyResetPeriodConfiguration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("yearlyResetPeriodConfiguration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingModel.Validate();
        foreach (var item in this.PricePeriods)
        {
            item.Validate();
        }
        this.BillingCadence?.Validate();
        _ = this.FeatureID;
        _ = this.MaxUnitQuantity;
        _ = this.MinUnitQuantity;
        this.MonthlyResetPeriodConfiguration?.Validate();
        this.ResetPeriod?.Validate();
        this.TiersMode?.Validate();
        _ = this.TopUpCustomCurrencyID;
        this.WeeklyResetPeriodConfiguration?.Validate();
        this.YearlyResetPeriodConfiguration?.Validate();
    }

    public PricingModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModel(PricingModel pricingModel)
        : base(pricingModel) { }
#pragma warning restore CS8618

    public PricingModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelFromRaw.FromRawUnchecked"/>
    public static PricingModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PricingModelFromRaw : IFromRawJson<PricingModel>
{
    /// <inheritdoc/>
    public PricingModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PricingModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing model (FLAT_FEE, PER_UNIT, USAGE_BASED, CREDIT_BASED)
/// </summary>
[JsonConverter(typeof(BillingModelConverter))]
public enum BillingModel
{
    FlatFee,
    MinimumSpend,
    PerUnit,
    UsageBased,
    CreditBased,
}

sealed class BillingModelConverter : JsonConverter<BillingModel>
{
    public override BillingModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FLAT_FEE" => BillingModel.FlatFee,
            "MINIMUM_SPEND" => BillingModel.MinimumSpend,
            "PER_UNIT" => BillingModel.PerUnit,
            "USAGE_BASED" => BillingModel.UsageBased,
            "CREDIT_BASED" => BillingModel.CreditBased,
            _ => (BillingModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingModel.FlatFee => "FLAT_FEE",
                BillingModel.MinimumSpend => "MINIMUM_SPEND",
                BillingModel.PerUnit => "PER_UNIT",
                BillingModel.UsageBased => "USAGE_BASED",
                BillingModel.CreditBased => "CREDIT_BASED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Price configuration for a specific billing period.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PricingModelPricePeriod, PricingModelPricePeriodFromRaw>))]
public sealed record class PricingModelPricePeriod : JsonModel
{
    /// <summary>
    /// The billing period (MONTHLY or ANNUALLY)
    /// </summary>
    public required ApiEnum<string, PricingModelPricePeriodBillingPeriod> BillingPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PricingModelPricePeriodBillingPeriod>
            >("billingPeriod");
        }
        init { this._rawData.Set("billingPeriod", value); }
    }

    /// <summary>
    /// ISO country code for localized pricing, or "eu" for the European Union group
    /// you map countries into
    /// </summary>
    public string? BillingCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billingCountryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("billingCountryCode", value);
        }
    }

    /// <summary>
    /// Block size for usage-based pricing
    /// </summary>
    public double? BlockSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("blockSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blockSize", value);
        }
    }

    /// <summary>
    /// When credits are granted
    /// </summary>
    public ApiEnum<string, PricingModelPricePeriodCreditGrantCadence>? CreditGrantCadence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PricingModelPricePeriodCreditGrantCadence>
            >("creditGrantCadence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditGrantCadence", value);
        }
    }

    /// <summary>
    /// Credit rate configuration for credit-based pricing
    /// </summary>
    public PricingModelPricePeriodCreditRate? CreditRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PricingModelPricePeriodCreditRate>("creditRate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("creditRate", value);
        }
    }

    /// <summary>
    /// The price amount and currency
    /// </summary>
    public PricingModelPricePeriodPrice? Price
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PricingModelPricePeriodPrice>("price");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("price", value);
        }
    }

    /// <summary>
    /// Tiered pricing configuration
    /// </summary>
    public IReadOnlyList<PricingModelPricePeriodTier>? Tiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PricingModelPricePeriodTier>>(
                "tiers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PricingModelPricePeriodTier>?>(
                "tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillingPeriod.Validate();
        _ = this.BillingCountryCode;
        _ = this.BlockSize;
        this.CreditGrantCadence?.Validate();
        this.CreditRate?.Validate();
        this.Price?.Validate();
        foreach (var item in this.Tiers ?? [])
        {
            item.Validate();
        }
    }

    public PricingModelPricePeriod() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelPricePeriod(PricingModelPricePeriod pricingModelPricePeriod)
        : base(pricingModelPricePeriod) { }
#pragma warning restore CS8618

    public PricingModelPricePeriod(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelPricePeriod(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelPricePeriodFromRaw.FromRawUnchecked"/>
    public static PricingModelPricePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PricingModelPricePeriod(
        ApiEnum<string, PricingModelPricePeriodBillingPeriod> billingPeriod
    )
        : this()
    {
        this.BillingPeriod = billingPeriod;
    }
}

class PricingModelPricePeriodFromRaw : IFromRawJson<PricingModelPricePeriod>
{
    /// <inheritdoc/>
    public PricingModelPricePeriod FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelPricePeriod.FromRawUnchecked(rawData);
}

/// <summary>
/// The billing period (MONTHLY or ANNUALLY)
/// </summary>
[JsonConverter(typeof(PricingModelPricePeriodBillingPeriodConverter))]
public enum PricingModelPricePeriodBillingPeriod
{
    Monthly,
    Annually,
}

sealed class PricingModelPricePeriodBillingPeriodConverter
    : JsonConverter<PricingModelPricePeriodBillingPeriod>
{
    public override PricingModelPricePeriodBillingPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MONTHLY" => PricingModelPricePeriodBillingPeriod.Monthly,
            "ANNUALLY" => PricingModelPricePeriodBillingPeriod.Annually,
            _ => (PricingModelPricePeriodBillingPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelPricePeriodBillingPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelPricePeriodBillingPeriod.Monthly => "MONTHLY",
                PricingModelPricePeriodBillingPeriod.Annually => "ANNUALLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// When credits are granted
/// </summary>
[JsonConverter(typeof(PricingModelPricePeriodCreditGrantCadenceConverter))]
public enum PricingModelPricePeriodCreditGrantCadence
{
    BeginningOfBillingPeriod,
    Monthly,
}

sealed class PricingModelPricePeriodCreditGrantCadenceConverter
    : JsonConverter<PricingModelPricePeriodCreditGrantCadence>
{
    public override PricingModelPricePeriodCreditGrantCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BEGINNING_OF_BILLING_PERIOD" =>
                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod,
            "MONTHLY" => PricingModelPricePeriodCreditGrantCadence.Monthly,
            _ => (PricingModelPricePeriodCreditGrantCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelPricePeriodCreditGrantCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelPricePeriodCreditGrantCadence.BeginningOfBillingPeriod =>
                    "BEGINNING_OF_BILLING_PERIOD",
                PricingModelPricePeriodCreditGrantCadence.Monthly => "MONTHLY",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Credit rate configuration for credit-based pricing
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PricingModelPricePeriodCreditRate,
        PricingModelPricePeriodCreditRateFromRaw
    >)
)]
public sealed record class PricingModelPricePeriodCreditRate : JsonModel
{
    /// <summary>
    /// The credit rate amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The custom currency ID
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currencyId");
        }
        init { this._rawData.Set("currencyId", value); }
    }

    /// <summary>
    /// Optional cost formula expression
    /// </summary>
    public string? CostFormula
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("costFormula");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("costFormula", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CurrencyID;
        _ = this.CostFormula;
    }

    public PricingModelPricePeriodCreditRate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelPricePeriodCreditRate(
        PricingModelPricePeriodCreditRate pricingModelPricePeriodCreditRate
    )
        : base(pricingModelPricePeriodCreditRate) { }
#pragma warning restore CS8618

    public PricingModelPricePeriodCreditRate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelPricePeriodCreditRate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelPricePeriodCreditRateFromRaw.FromRawUnchecked"/>
    public static PricingModelPricePeriodCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PricingModelPricePeriodCreditRateFromRaw : IFromRawJson<PricingModelPricePeriodCreditRate>
{
    /// <inheritdoc/>
    public PricingModelPricePeriodCreditRate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelPricePeriodCreditRate.FromRawUnchecked(rawData);
}

/// <summary>
/// The price amount and currency
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PricingModelPricePeriodPrice, PricingModelPricePeriodPriceFromRaw>)
)]
public sealed record class PricingModelPricePeriodPrice : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, PricingModelPricePeriodPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PricingModelPricePeriodPriceCurrency>
            >("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public PricingModelPricePeriodPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelPricePeriodPrice(PricingModelPricePeriodPrice pricingModelPricePeriodPrice)
        : base(pricingModelPricePeriodPrice) { }
#pragma warning restore CS8618

    public PricingModelPricePeriodPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelPricePeriodPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelPricePeriodPriceFromRaw.FromRawUnchecked"/>
    public static PricingModelPricePeriodPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PricingModelPricePeriodPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class PricingModelPricePeriodPriceFromRaw : IFromRawJson<PricingModelPricePeriodPrice>
{
    /// <inheritdoc/>
    public PricingModelPricePeriodPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelPricePeriodPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(PricingModelPricePeriodPriceCurrencyConverter))]
public enum PricingModelPricePeriodPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class PricingModelPricePeriodPriceCurrencyConverter
    : JsonConverter<PricingModelPricePeriodPriceCurrency>
{
    public override PricingModelPricePeriodPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PricingModelPricePeriodPriceCurrency.Usd,
            "aed" => PricingModelPricePeriodPriceCurrency.Aed,
            "all" => PricingModelPricePeriodPriceCurrency.All,
            "amd" => PricingModelPricePeriodPriceCurrency.Amd,
            "ang" => PricingModelPricePeriodPriceCurrency.Ang,
            "aud" => PricingModelPricePeriodPriceCurrency.Aud,
            "awg" => PricingModelPricePeriodPriceCurrency.Awg,
            "azn" => PricingModelPricePeriodPriceCurrency.Azn,
            "bam" => PricingModelPricePeriodPriceCurrency.Bam,
            "bbd" => PricingModelPricePeriodPriceCurrency.Bbd,
            "bdt" => PricingModelPricePeriodPriceCurrency.Bdt,
            "bgn" => PricingModelPricePeriodPriceCurrency.Bgn,
            "bif" => PricingModelPricePeriodPriceCurrency.Bif,
            "bmd" => PricingModelPricePeriodPriceCurrency.Bmd,
            "bnd" => PricingModelPricePeriodPriceCurrency.Bnd,
            "bsd" => PricingModelPricePeriodPriceCurrency.Bsd,
            "bwp" => PricingModelPricePeriodPriceCurrency.Bwp,
            "byn" => PricingModelPricePeriodPriceCurrency.Byn,
            "bzd" => PricingModelPricePeriodPriceCurrency.Bzd,
            "brl" => PricingModelPricePeriodPriceCurrency.Brl,
            "cad" => PricingModelPricePeriodPriceCurrency.Cad,
            "cdf" => PricingModelPricePeriodPriceCurrency.Cdf,
            "chf" => PricingModelPricePeriodPriceCurrency.Chf,
            "cny" => PricingModelPricePeriodPriceCurrency.Cny,
            "czk" => PricingModelPricePeriodPriceCurrency.Czk,
            "dkk" => PricingModelPricePeriodPriceCurrency.Dkk,
            "dop" => PricingModelPricePeriodPriceCurrency.Dop,
            "dzd" => PricingModelPricePeriodPriceCurrency.Dzd,
            "egp" => PricingModelPricePeriodPriceCurrency.Egp,
            "etb" => PricingModelPricePeriodPriceCurrency.Etb,
            "eur" => PricingModelPricePeriodPriceCurrency.Eur,
            "fjd" => PricingModelPricePeriodPriceCurrency.Fjd,
            "gbp" => PricingModelPricePeriodPriceCurrency.Gbp,
            "gel" => PricingModelPricePeriodPriceCurrency.Gel,
            "gip" => PricingModelPricePeriodPriceCurrency.Gip,
            "gmd" => PricingModelPricePeriodPriceCurrency.Gmd,
            "gyd" => PricingModelPricePeriodPriceCurrency.Gyd,
            "hkd" => PricingModelPricePeriodPriceCurrency.Hkd,
            "hrk" => PricingModelPricePeriodPriceCurrency.Hrk,
            "htg" => PricingModelPricePeriodPriceCurrency.Htg,
            "idr" => PricingModelPricePeriodPriceCurrency.Idr,
            "ils" => PricingModelPricePeriodPriceCurrency.Ils,
            "inr" => PricingModelPricePeriodPriceCurrency.Inr,
            "isk" => PricingModelPricePeriodPriceCurrency.Isk,
            "jmd" => PricingModelPricePeriodPriceCurrency.Jmd,
            "jpy" => PricingModelPricePeriodPriceCurrency.Jpy,
            "kes" => PricingModelPricePeriodPriceCurrency.Kes,
            "kgs" => PricingModelPricePeriodPriceCurrency.Kgs,
            "khr" => PricingModelPricePeriodPriceCurrency.Khr,
            "kmf" => PricingModelPricePeriodPriceCurrency.Kmf,
            "krw" => PricingModelPricePeriodPriceCurrency.Krw,
            "kyd" => PricingModelPricePeriodPriceCurrency.Kyd,
            "kzt" => PricingModelPricePeriodPriceCurrency.Kzt,
            "lbp" => PricingModelPricePeriodPriceCurrency.Lbp,
            "lkr" => PricingModelPricePeriodPriceCurrency.Lkr,
            "lrd" => PricingModelPricePeriodPriceCurrency.Lrd,
            "lsl" => PricingModelPricePeriodPriceCurrency.Lsl,
            "mad" => PricingModelPricePeriodPriceCurrency.Mad,
            "mdl" => PricingModelPricePeriodPriceCurrency.Mdl,
            "mga" => PricingModelPricePeriodPriceCurrency.Mga,
            "mkd" => PricingModelPricePeriodPriceCurrency.Mkd,
            "mmk" => PricingModelPricePeriodPriceCurrency.Mmk,
            "mnt" => PricingModelPricePeriodPriceCurrency.Mnt,
            "mop" => PricingModelPricePeriodPriceCurrency.Mop,
            "mro" => PricingModelPricePeriodPriceCurrency.Mro,
            "mvr" => PricingModelPricePeriodPriceCurrency.Mvr,
            "mwk" => PricingModelPricePeriodPriceCurrency.Mwk,
            "mxn" => PricingModelPricePeriodPriceCurrency.Mxn,
            "myr" => PricingModelPricePeriodPriceCurrency.Myr,
            "mzn" => PricingModelPricePeriodPriceCurrency.Mzn,
            "nad" => PricingModelPricePeriodPriceCurrency.Nad,
            "ngn" => PricingModelPricePeriodPriceCurrency.Ngn,
            "nok" => PricingModelPricePeriodPriceCurrency.Nok,
            "npr" => PricingModelPricePeriodPriceCurrency.Npr,
            "nzd" => PricingModelPricePeriodPriceCurrency.Nzd,
            "pgk" => PricingModelPricePeriodPriceCurrency.Pgk,
            "php" => PricingModelPricePeriodPriceCurrency.Php,
            "pkr" => PricingModelPricePeriodPriceCurrency.Pkr,
            "pln" => PricingModelPricePeriodPriceCurrency.Pln,
            "qar" => PricingModelPricePeriodPriceCurrency.Qar,
            "ron" => PricingModelPricePeriodPriceCurrency.Ron,
            "rsd" => PricingModelPricePeriodPriceCurrency.Rsd,
            "rub" => PricingModelPricePeriodPriceCurrency.Rub,
            "rwf" => PricingModelPricePeriodPriceCurrency.Rwf,
            "sar" => PricingModelPricePeriodPriceCurrency.Sar,
            "sbd" => PricingModelPricePeriodPriceCurrency.Sbd,
            "scr" => PricingModelPricePeriodPriceCurrency.Scr,
            "sek" => PricingModelPricePeriodPriceCurrency.Sek,
            "sgd" => PricingModelPricePeriodPriceCurrency.Sgd,
            "sle" => PricingModelPricePeriodPriceCurrency.Sle,
            "sll" => PricingModelPricePeriodPriceCurrency.Sll,
            "sos" => PricingModelPricePeriodPriceCurrency.Sos,
            "szl" => PricingModelPricePeriodPriceCurrency.Szl,
            "thb" => PricingModelPricePeriodPriceCurrency.Thb,
            "tjs" => PricingModelPricePeriodPriceCurrency.Tjs,
            "top" => PricingModelPricePeriodPriceCurrency.Top,
            "try" => PricingModelPricePeriodPriceCurrency.Try,
            "ttd" => PricingModelPricePeriodPriceCurrency.Ttd,
            "tzs" => PricingModelPricePeriodPriceCurrency.Tzs,
            "uah" => PricingModelPricePeriodPriceCurrency.Uah,
            "uzs" => PricingModelPricePeriodPriceCurrency.Uzs,
            "vnd" => PricingModelPricePeriodPriceCurrency.Vnd,
            "vuv" => PricingModelPricePeriodPriceCurrency.Vuv,
            "wst" => PricingModelPricePeriodPriceCurrency.Wst,
            "xaf" => PricingModelPricePeriodPriceCurrency.Xaf,
            "xcd" => PricingModelPricePeriodPriceCurrency.Xcd,
            "yer" => PricingModelPricePeriodPriceCurrency.Yer,
            "zar" => PricingModelPricePeriodPriceCurrency.Zar,
            "zmw" => PricingModelPricePeriodPriceCurrency.Zmw,
            "clp" => PricingModelPricePeriodPriceCurrency.Clp,
            "djf" => PricingModelPricePeriodPriceCurrency.Djf,
            "gnf" => PricingModelPricePeriodPriceCurrency.Gnf,
            "ugx" => PricingModelPricePeriodPriceCurrency.Ugx,
            "pyg" => PricingModelPricePeriodPriceCurrency.Pyg,
            "xof" => PricingModelPricePeriodPriceCurrency.Xof,
            "xpf" => PricingModelPricePeriodPriceCurrency.Xpf,
            _ => (PricingModelPricePeriodPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelPricePeriodPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelPricePeriodPriceCurrency.Usd => "usd",
                PricingModelPricePeriodPriceCurrency.Aed => "aed",
                PricingModelPricePeriodPriceCurrency.All => "all",
                PricingModelPricePeriodPriceCurrency.Amd => "amd",
                PricingModelPricePeriodPriceCurrency.Ang => "ang",
                PricingModelPricePeriodPriceCurrency.Aud => "aud",
                PricingModelPricePeriodPriceCurrency.Awg => "awg",
                PricingModelPricePeriodPriceCurrency.Azn => "azn",
                PricingModelPricePeriodPriceCurrency.Bam => "bam",
                PricingModelPricePeriodPriceCurrency.Bbd => "bbd",
                PricingModelPricePeriodPriceCurrency.Bdt => "bdt",
                PricingModelPricePeriodPriceCurrency.Bgn => "bgn",
                PricingModelPricePeriodPriceCurrency.Bif => "bif",
                PricingModelPricePeriodPriceCurrency.Bmd => "bmd",
                PricingModelPricePeriodPriceCurrency.Bnd => "bnd",
                PricingModelPricePeriodPriceCurrency.Bsd => "bsd",
                PricingModelPricePeriodPriceCurrency.Bwp => "bwp",
                PricingModelPricePeriodPriceCurrency.Byn => "byn",
                PricingModelPricePeriodPriceCurrency.Bzd => "bzd",
                PricingModelPricePeriodPriceCurrency.Brl => "brl",
                PricingModelPricePeriodPriceCurrency.Cad => "cad",
                PricingModelPricePeriodPriceCurrency.Cdf => "cdf",
                PricingModelPricePeriodPriceCurrency.Chf => "chf",
                PricingModelPricePeriodPriceCurrency.Cny => "cny",
                PricingModelPricePeriodPriceCurrency.Czk => "czk",
                PricingModelPricePeriodPriceCurrency.Dkk => "dkk",
                PricingModelPricePeriodPriceCurrency.Dop => "dop",
                PricingModelPricePeriodPriceCurrency.Dzd => "dzd",
                PricingModelPricePeriodPriceCurrency.Egp => "egp",
                PricingModelPricePeriodPriceCurrency.Etb => "etb",
                PricingModelPricePeriodPriceCurrency.Eur => "eur",
                PricingModelPricePeriodPriceCurrency.Fjd => "fjd",
                PricingModelPricePeriodPriceCurrency.Gbp => "gbp",
                PricingModelPricePeriodPriceCurrency.Gel => "gel",
                PricingModelPricePeriodPriceCurrency.Gip => "gip",
                PricingModelPricePeriodPriceCurrency.Gmd => "gmd",
                PricingModelPricePeriodPriceCurrency.Gyd => "gyd",
                PricingModelPricePeriodPriceCurrency.Hkd => "hkd",
                PricingModelPricePeriodPriceCurrency.Hrk => "hrk",
                PricingModelPricePeriodPriceCurrency.Htg => "htg",
                PricingModelPricePeriodPriceCurrency.Idr => "idr",
                PricingModelPricePeriodPriceCurrency.Ils => "ils",
                PricingModelPricePeriodPriceCurrency.Inr => "inr",
                PricingModelPricePeriodPriceCurrency.Isk => "isk",
                PricingModelPricePeriodPriceCurrency.Jmd => "jmd",
                PricingModelPricePeriodPriceCurrency.Jpy => "jpy",
                PricingModelPricePeriodPriceCurrency.Kes => "kes",
                PricingModelPricePeriodPriceCurrency.Kgs => "kgs",
                PricingModelPricePeriodPriceCurrency.Khr => "khr",
                PricingModelPricePeriodPriceCurrency.Kmf => "kmf",
                PricingModelPricePeriodPriceCurrency.Krw => "krw",
                PricingModelPricePeriodPriceCurrency.Kyd => "kyd",
                PricingModelPricePeriodPriceCurrency.Kzt => "kzt",
                PricingModelPricePeriodPriceCurrency.Lbp => "lbp",
                PricingModelPricePeriodPriceCurrency.Lkr => "lkr",
                PricingModelPricePeriodPriceCurrency.Lrd => "lrd",
                PricingModelPricePeriodPriceCurrency.Lsl => "lsl",
                PricingModelPricePeriodPriceCurrency.Mad => "mad",
                PricingModelPricePeriodPriceCurrency.Mdl => "mdl",
                PricingModelPricePeriodPriceCurrency.Mga => "mga",
                PricingModelPricePeriodPriceCurrency.Mkd => "mkd",
                PricingModelPricePeriodPriceCurrency.Mmk => "mmk",
                PricingModelPricePeriodPriceCurrency.Mnt => "mnt",
                PricingModelPricePeriodPriceCurrency.Mop => "mop",
                PricingModelPricePeriodPriceCurrency.Mro => "mro",
                PricingModelPricePeriodPriceCurrency.Mvr => "mvr",
                PricingModelPricePeriodPriceCurrency.Mwk => "mwk",
                PricingModelPricePeriodPriceCurrency.Mxn => "mxn",
                PricingModelPricePeriodPriceCurrency.Myr => "myr",
                PricingModelPricePeriodPriceCurrency.Mzn => "mzn",
                PricingModelPricePeriodPriceCurrency.Nad => "nad",
                PricingModelPricePeriodPriceCurrency.Ngn => "ngn",
                PricingModelPricePeriodPriceCurrency.Nok => "nok",
                PricingModelPricePeriodPriceCurrency.Npr => "npr",
                PricingModelPricePeriodPriceCurrency.Nzd => "nzd",
                PricingModelPricePeriodPriceCurrency.Pgk => "pgk",
                PricingModelPricePeriodPriceCurrency.Php => "php",
                PricingModelPricePeriodPriceCurrency.Pkr => "pkr",
                PricingModelPricePeriodPriceCurrency.Pln => "pln",
                PricingModelPricePeriodPriceCurrency.Qar => "qar",
                PricingModelPricePeriodPriceCurrency.Ron => "ron",
                PricingModelPricePeriodPriceCurrency.Rsd => "rsd",
                PricingModelPricePeriodPriceCurrency.Rub => "rub",
                PricingModelPricePeriodPriceCurrency.Rwf => "rwf",
                PricingModelPricePeriodPriceCurrency.Sar => "sar",
                PricingModelPricePeriodPriceCurrency.Sbd => "sbd",
                PricingModelPricePeriodPriceCurrency.Scr => "scr",
                PricingModelPricePeriodPriceCurrency.Sek => "sek",
                PricingModelPricePeriodPriceCurrency.Sgd => "sgd",
                PricingModelPricePeriodPriceCurrency.Sle => "sle",
                PricingModelPricePeriodPriceCurrency.Sll => "sll",
                PricingModelPricePeriodPriceCurrency.Sos => "sos",
                PricingModelPricePeriodPriceCurrency.Szl => "szl",
                PricingModelPricePeriodPriceCurrency.Thb => "thb",
                PricingModelPricePeriodPriceCurrency.Tjs => "tjs",
                PricingModelPricePeriodPriceCurrency.Top => "top",
                PricingModelPricePeriodPriceCurrency.Try => "try",
                PricingModelPricePeriodPriceCurrency.Ttd => "ttd",
                PricingModelPricePeriodPriceCurrency.Tzs => "tzs",
                PricingModelPricePeriodPriceCurrency.Uah => "uah",
                PricingModelPricePeriodPriceCurrency.Uzs => "uzs",
                PricingModelPricePeriodPriceCurrency.Vnd => "vnd",
                PricingModelPricePeriodPriceCurrency.Vuv => "vuv",
                PricingModelPricePeriodPriceCurrency.Wst => "wst",
                PricingModelPricePeriodPriceCurrency.Xaf => "xaf",
                PricingModelPricePeriodPriceCurrency.Xcd => "xcd",
                PricingModelPricePeriodPriceCurrency.Yer => "yer",
                PricingModelPricePeriodPriceCurrency.Zar => "zar",
                PricingModelPricePeriodPriceCurrency.Zmw => "zmw",
                PricingModelPricePeriodPriceCurrency.Clp => "clp",
                PricingModelPricePeriodPriceCurrency.Djf => "djf",
                PricingModelPricePeriodPriceCurrency.Gnf => "gnf",
                PricingModelPricePeriodPriceCurrency.Ugx => "ugx",
                PricingModelPricePeriodPriceCurrency.Pyg => "pyg",
                PricingModelPricePeriodPriceCurrency.Xof => "xof",
                PricingModelPricePeriodPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A tier in tiered pricing.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PricingModelPricePeriodTier, PricingModelPricePeriodTierFromRaw>)
)]
public sealed record class PricingModelPricePeriodTier : JsonModel
{
    /// <summary>
    /// Flat price for this tier
    /// </summary>
    public PricingModelPricePeriodTierFlatPrice? FlatPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PricingModelPricePeriodTierFlatPrice>(
                "flatPrice"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("flatPrice", value);
        }
    }

    /// <summary>
    /// Per-unit price in this tier
    /// </summary>
    public PricingModelPricePeriodTierUnitPrice? UnitPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PricingModelPricePeriodTierUnitPrice>(
                "unitPrice"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unitPrice", value);
        }
    }

    /// <summary>
    /// Upper bound of this tier (null for unlimited)
    /// </summary>
    public double? UpTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("upTo", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FlatPrice?.Validate();
        this.UnitPrice?.Validate();
        _ = this.UpTo;
    }

    public PricingModelPricePeriodTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelPricePeriodTier(PricingModelPricePeriodTier pricingModelPricePeriodTier)
        : base(pricingModelPricePeriodTier) { }
#pragma warning restore CS8618

    public PricingModelPricePeriodTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelPricePeriodTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelPricePeriodTierFromRaw.FromRawUnchecked"/>
    public static PricingModelPricePeriodTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PricingModelPricePeriodTierFromRaw : IFromRawJson<PricingModelPricePeriodTier>
{
    /// <inheritdoc/>
    public PricingModelPricePeriodTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelPricePeriodTier.FromRawUnchecked(rawData);
}

/// <summary>
/// Flat price for this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PricingModelPricePeriodTierFlatPrice,
        PricingModelPricePeriodTierFlatPriceFromRaw
    >)
)]
public sealed record class PricingModelPricePeriodTierFlatPrice : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PricingModelPricePeriodTierFlatPriceCurrency>
            >("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public PricingModelPricePeriodTierFlatPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelPricePeriodTierFlatPrice(
        PricingModelPricePeriodTierFlatPrice pricingModelPricePeriodTierFlatPrice
    )
        : base(pricingModelPricePeriodTierFlatPrice) { }
#pragma warning restore CS8618

    public PricingModelPricePeriodTierFlatPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelPricePeriodTierFlatPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelPricePeriodTierFlatPriceFromRaw.FromRawUnchecked"/>
    public static PricingModelPricePeriodTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PricingModelPricePeriodTierFlatPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class PricingModelPricePeriodTierFlatPriceFromRaw
    : IFromRawJson<PricingModelPricePeriodTierFlatPrice>
{
    /// <inheritdoc/>
    public PricingModelPricePeriodTierFlatPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelPricePeriodTierFlatPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(PricingModelPricePeriodTierFlatPriceCurrencyConverter))]
public enum PricingModelPricePeriodTierFlatPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class PricingModelPricePeriodTierFlatPriceCurrencyConverter
    : JsonConverter<PricingModelPricePeriodTierFlatPriceCurrency>
{
    public override PricingModelPricePeriodTierFlatPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PricingModelPricePeriodTierFlatPriceCurrency.Usd,
            "aed" => PricingModelPricePeriodTierFlatPriceCurrency.Aed,
            "all" => PricingModelPricePeriodTierFlatPriceCurrency.All,
            "amd" => PricingModelPricePeriodTierFlatPriceCurrency.Amd,
            "ang" => PricingModelPricePeriodTierFlatPriceCurrency.Ang,
            "aud" => PricingModelPricePeriodTierFlatPriceCurrency.Aud,
            "awg" => PricingModelPricePeriodTierFlatPriceCurrency.Awg,
            "azn" => PricingModelPricePeriodTierFlatPriceCurrency.Azn,
            "bam" => PricingModelPricePeriodTierFlatPriceCurrency.Bam,
            "bbd" => PricingModelPricePeriodTierFlatPriceCurrency.Bbd,
            "bdt" => PricingModelPricePeriodTierFlatPriceCurrency.Bdt,
            "bgn" => PricingModelPricePeriodTierFlatPriceCurrency.Bgn,
            "bif" => PricingModelPricePeriodTierFlatPriceCurrency.Bif,
            "bmd" => PricingModelPricePeriodTierFlatPriceCurrency.Bmd,
            "bnd" => PricingModelPricePeriodTierFlatPriceCurrency.Bnd,
            "bsd" => PricingModelPricePeriodTierFlatPriceCurrency.Bsd,
            "bwp" => PricingModelPricePeriodTierFlatPriceCurrency.Bwp,
            "byn" => PricingModelPricePeriodTierFlatPriceCurrency.Byn,
            "bzd" => PricingModelPricePeriodTierFlatPriceCurrency.Bzd,
            "brl" => PricingModelPricePeriodTierFlatPriceCurrency.Brl,
            "cad" => PricingModelPricePeriodTierFlatPriceCurrency.Cad,
            "cdf" => PricingModelPricePeriodTierFlatPriceCurrency.Cdf,
            "chf" => PricingModelPricePeriodTierFlatPriceCurrency.Chf,
            "cny" => PricingModelPricePeriodTierFlatPriceCurrency.Cny,
            "czk" => PricingModelPricePeriodTierFlatPriceCurrency.Czk,
            "dkk" => PricingModelPricePeriodTierFlatPriceCurrency.Dkk,
            "dop" => PricingModelPricePeriodTierFlatPriceCurrency.Dop,
            "dzd" => PricingModelPricePeriodTierFlatPriceCurrency.Dzd,
            "egp" => PricingModelPricePeriodTierFlatPriceCurrency.Egp,
            "etb" => PricingModelPricePeriodTierFlatPriceCurrency.Etb,
            "eur" => PricingModelPricePeriodTierFlatPriceCurrency.Eur,
            "fjd" => PricingModelPricePeriodTierFlatPriceCurrency.Fjd,
            "gbp" => PricingModelPricePeriodTierFlatPriceCurrency.Gbp,
            "gel" => PricingModelPricePeriodTierFlatPriceCurrency.Gel,
            "gip" => PricingModelPricePeriodTierFlatPriceCurrency.Gip,
            "gmd" => PricingModelPricePeriodTierFlatPriceCurrency.Gmd,
            "gyd" => PricingModelPricePeriodTierFlatPriceCurrency.Gyd,
            "hkd" => PricingModelPricePeriodTierFlatPriceCurrency.Hkd,
            "hrk" => PricingModelPricePeriodTierFlatPriceCurrency.Hrk,
            "htg" => PricingModelPricePeriodTierFlatPriceCurrency.Htg,
            "idr" => PricingModelPricePeriodTierFlatPriceCurrency.Idr,
            "ils" => PricingModelPricePeriodTierFlatPriceCurrency.Ils,
            "inr" => PricingModelPricePeriodTierFlatPriceCurrency.Inr,
            "isk" => PricingModelPricePeriodTierFlatPriceCurrency.Isk,
            "jmd" => PricingModelPricePeriodTierFlatPriceCurrency.Jmd,
            "jpy" => PricingModelPricePeriodTierFlatPriceCurrency.Jpy,
            "kes" => PricingModelPricePeriodTierFlatPriceCurrency.Kes,
            "kgs" => PricingModelPricePeriodTierFlatPriceCurrency.Kgs,
            "khr" => PricingModelPricePeriodTierFlatPriceCurrency.Khr,
            "kmf" => PricingModelPricePeriodTierFlatPriceCurrency.Kmf,
            "krw" => PricingModelPricePeriodTierFlatPriceCurrency.Krw,
            "kyd" => PricingModelPricePeriodTierFlatPriceCurrency.Kyd,
            "kzt" => PricingModelPricePeriodTierFlatPriceCurrency.Kzt,
            "lbp" => PricingModelPricePeriodTierFlatPriceCurrency.Lbp,
            "lkr" => PricingModelPricePeriodTierFlatPriceCurrency.Lkr,
            "lrd" => PricingModelPricePeriodTierFlatPriceCurrency.Lrd,
            "lsl" => PricingModelPricePeriodTierFlatPriceCurrency.Lsl,
            "mad" => PricingModelPricePeriodTierFlatPriceCurrency.Mad,
            "mdl" => PricingModelPricePeriodTierFlatPriceCurrency.Mdl,
            "mga" => PricingModelPricePeriodTierFlatPriceCurrency.Mga,
            "mkd" => PricingModelPricePeriodTierFlatPriceCurrency.Mkd,
            "mmk" => PricingModelPricePeriodTierFlatPriceCurrency.Mmk,
            "mnt" => PricingModelPricePeriodTierFlatPriceCurrency.Mnt,
            "mop" => PricingModelPricePeriodTierFlatPriceCurrency.Mop,
            "mro" => PricingModelPricePeriodTierFlatPriceCurrency.Mro,
            "mvr" => PricingModelPricePeriodTierFlatPriceCurrency.Mvr,
            "mwk" => PricingModelPricePeriodTierFlatPriceCurrency.Mwk,
            "mxn" => PricingModelPricePeriodTierFlatPriceCurrency.Mxn,
            "myr" => PricingModelPricePeriodTierFlatPriceCurrency.Myr,
            "mzn" => PricingModelPricePeriodTierFlatPriceCurrency.Mzn,
            "nad" => PricingModelPricePeriodTierFlatPriceCurrency.Nad,
            "ngn" => PricingModelPricePeriodTierFlatPriceCurrency.Ngn,
            "nok" => PricingModelPricePeriodTierFlatPriceCurrency.Nok,
            "npr" => PricingModelPricePeriodTierFlatPriceCurrency.Npr,
            "nzd" => PricingModelPricePeriodTierFlatPriceCurrency.Nzd,
            "pgk" => PricingModelPricePeriodTierFlatPriceCurrency.Pgk,
            "php" => PricingModelPricePeriodTierFlatPriceCurrency.Php,
            "pkr" => PricingModelPricePeriodTierFlatPriceCurrency.Pkr,
            "pln" => PricingModelPricePeriodTierFlatPriceCurrency.Pln,
            "qar" => PricingModelPricePeriodTierFlatPriceCurrency.Qar,
            "ron" => PricingModelPricePeriodTierFlatPriceCurrency.Ron,
            "rsd" => PricingModelPricePeriodTierFlatPriceCurrency.Rsd,
            "rub" => PricingModelPricePeriodTierFlatPriceCurrency.Rub,
            "rwf" => PricingModelPricePeriodTierFlatPriceCurrency.Rwf,
            "sar" => PricingModelPricePeriodTierFlatPriceCurrency.Sar,
            "sbd" => PricingModelPricePeriodTierFlatPriceCurrency.Sbd,
            "scr" => PricingModelPricePeriodTierFlatPriceCurrency.Scr,
            "sek" => PricingModelPricePeriodTierFlatPriceCurrency.Sek,
            "sgd" => PricingModelPricePeriodTierFlatPriceCurrency.Sgd,
            "sle" => PricingModelPricePeriodTierFlatPriceCurrency.Sle,
            "sll" => PricingModelPricePeriodTierFlatPriceCurrency.Sll,
            "sos" => PricingModelPricePeriodTierFlatPriceCurrency.Sos,
            "szl" => PricingModelPricePeriodTierFlatPriceCurrency.Szl,
            "thb" => PricingModelPricePeriodTierFlatPriceCurrency.Thb,
            "tjs" => PricingModelPricePeriodTierFlatPriceCurrency.Tjs,
            "top" => PricingModelPricePeriodTierFlatPriceCurrency.Top,
            "try" => PricingModelPricePeriodTierFlatPriceCurrency.Try,
            "ttd" => PricingModelPricePeriodTierFlatPriceCurrency.Ttd,
            "tzs" => PricingModelPricePeriodTierFlatPriceCurrency.Tzs,
            "uah" => PricingModelPricePeriodTierFlatPriceCurrency.Uah,
            "uzs" => PricingModelPricePeriodTierFlatPriceCurrency.Uzs,
            "vnd" => PricingModelPricePeriodTierFlatPriceCurrency.Vnd,
            "vuv" => PricingModelPricePeriodTierFlatPriceCurrency.Vuv,
            "wst" => PricingModelPricePeriodTierFlatPriceCurrency.Wst,
            "xaf" => PricingModelPricePeriodTierFlatPriceCurrency.Xaf,
            "xcd" => PricingModelPricePeriodTierFlatPriceCurrency.Xcd,
            "yer" => PricingModelPricePeriodTierFlatPriceCurrency.Yer,
            "zar" => PricingModelPricePeriodTierFlatPriceCurrency.Zar,
            "zmw" => PricingModelPricePeriodTierFlatPriceCurrency.Zmw,
            "clp" => PricingModelPricePeriodTierFlatPriceCurrency.Clp,
            "djf" => PricingModelPricePeriodTierFlatPriceCurrency.Djf,
            "gnf" => PricingModelPricePeriodTierFlatPriceCurrency.Gnf,
            "ugx" => PricingModelPricePeriodTierFlatPriceCurrency.Ugx,
            "pyg" => PricingModelPricePeriodTierFlatPriceCurrency.Pyg,
            "xof" => PricingModelPricePeriodTierFlatPriceCurrency.Xof,
            "xpf" => PricingModelPricePeriodTierFlatPriceCurrency.Xpf,
            _ => (PricingModelPricePeriodTierFlatPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelPricePeriodTierFlatPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelPricePeriodTierFlatPriceCurrency.Usd => "usd",
                PricingModelPricePeriodTierFlatPriceCurrency.Aed => "aed",
                PricingModelPricePeriodTierFlatPriceCurrency.All => "all",
                PricingModelPricePeriodTierFlatPriceCurrency.Amd => "amd",
                PricingModelPricePeriodTierFlatPriceCurrency.Ang => "ang",
                PricingModelPricePeriodTierFlatPriceCurrency.Aud => "aud",
                PricingModelPricePeriodTierFlatPriceCurrency.Awg => "awg",
                PricingModelPricePeriodTierFlatPriceCurrency.Azn => "azn",
                PricingModelPricePeriodTierFlatPriceCurrency.Bam => "bam",
                PricingModelPricePeriodTierFlatPriceCurrency.Bbd => "bbd",
                PricingModelPricePeriodTierFlatPriceCurrency.Bdt => "bdt",
                PricingModelPricePeriodTierFlatPriceCurrency.Bgn => "bgn",
                PricingModelPricePeriodTierFlatPriceCurrency.Bif => "bif",
                PricingModelPricePeriodTierFlatPriceCurrency.Bmd => "bmd",
                PricingModelPricePeriodTierFlatPriceCurrency.Bnd => "bnd",
                PricingModelPricePeriodTierFlatPriceCurrency.Bsd => "bsd",
                PricingModelPricePeriodTierFlatPriceCurrency.Bwp => "bwp",
                PricingModelPricePeriodTierFlatPriceCurrency.Byn => "byn",
                PricingModelPricePeriodTierFlatPriceCurrency.Bzd => "bzd",
                PricingModelPricePeriodTierFlatPriceCurrency.Brl => "brl",
                PricingModelPricePeriodTierFlatPriceCurrency.Cad => "cad",
                PricingModelPricePeriodTierFlatPriceCurrency.Cdf => "cdf",
                PricingModelPricePeriodTierFlatPriceCurrency.Chf => "chf",
                PricingModelPricePeriodTierFlatPriceCurrency.Cny => "cny",
                PricingModelPricePeriodTierFlatPriceCurrency.Czk => "czk",
                PricingModelPricePeriodTierFlatPriceCurrency.Dkk => "dkk",
                PricingModelPricePeriodTierFlatPriceCurrency.Dop => "dop",
                PricingModelPricePeriodTierFlatPriceCurrency.Dzd => "dzd",
                PricingModelPricePeriodTierFlatPriceCurrency.Egp => "egp",
                PricingModelPricePeriodTierFlatPriceCurrency.Etb => "etb",
                PricingModelPricePeriodTierFlatPriceCurrency.Eur => "eur",
                PricingModelPricePeriodTierFlatPriceCurrency.Fjd => "fjd",
                PricingModelPricePeriodTierFlatPriceCurrency.Gbp => "gbp",
                PricingModelPricePeriodTierFlatPriceCurrency.Gel => "gel",
                PricingModelPricePeriodTierFlatPriceCurrency.Gip => "gip",
                PricingModelPricePeriodTierFlatPriceCurrency.Gmd => "gmd",
                PricingModelPricePeriodTierFlatPriceCurrency.Gyd => "gyd",
                PricingModelPricePeriodTierFlatPriceCurrency.Hkd => "hkd",
                PricingModelPricePeriodTierFlatPriceCurrency.Hrk => "hrk",
                PricingModelPricePeriodTierFlatPriceCurrency.Htg => "htg",
                PricingModelPricePeriodTierFlatPriceCurrency.Idr => "idr",
                PricingModelPricePeriodTierFlatPriceCurrency.Ils => "ils",
                PricingModelPricePeriodTierFlatPriceCurrency.Inr => "inr",
                PricingModelPricePeriodTierFlatPriceCurrency.Isk => "isk",
                PricingModelPricePeriodTierFlatPriceCurrency.Jmd => "jmd",
                PricingModelPricePeriodTierFlatPriceCurrency.Jpy => "jpy",
                PricingModelPricePeriodTierFlatPriceCurrency.Kes => "kes",
                PricingModelPricePeriodTierFlatPriceCurrency.Kgs => "kgs",
                PricingModelPricePeriodTierFlatPriceCurrency.Khr => "khr",
                PricingModelPricePeriodTierFlatPriceCurrency.Kmf => "kmf",
                PricingModelPricePeriodTierFlatPriceCurrency.Krw => "krw",
                PricingModelPricePeriodTierFlatPriceCurrency.Kyd => "kyd",
                PricingModelPricePeriodTierFlatPriceCurrency.Kzt => "kzt",
                PricingModelPricePeriodTierFlatPriceCurrency.Lbp => "lbp",
                PricingModelPricePeriodTierFlatPriceCurrency.Lkr => "lkr",
                PricingModelPricePeriodTierFlatPriceCurrency.Lrd => "lrd",
                PricingModelPricePeriodTierFlatPriceCurrency.Lsl => "lsl",
                PricingModelPricePeriodTierFlatPriceCurrency.Mad => "mad",
                PricingModelPricePeriodTierFlatPriceCurrency.Mdl => "mdl",
                PricingModelPricePeriodTierFlatPriceCurrency.Mga => "mga",
                PricingModelPricePeriodTierFlatPriceCurrency.Mkd => "mkd",
                PricingModelPricePeriodTierFlatPriceCurrency.Mmk => "mmk",
                PricingModelPricePeriodTierFlatPriceCurrency.Mnt => "mnt",
                PricingModelPricePeriodTierFlatPriceCurrency.Mop => "mop",
                PricingModelPricePeriodTierFlatPriceCurrency.Mro => "mro",
                PricingModelPricePeriodTierFlatPriceCurrency.Mvr => "mvr",
                PricingModelPricePeriodTierFlatPriceCurrency.Mwk => "mwk",
                PricingModelPricePeriodTierFlatPriceCurrency.Mxn => "mxn",
                PricingModelPricePeriodTierFlatPriceCurrency.Myr => "myr",
                PricingModelPricePeriodTierFlatPriceCurrency.Mzn => "mzn",
                PricingModelPricePeriodTierFlatPriceCurrency.Nad => "nad",
                PricingModelPricePeriodTierFlatPriceCurrency.Ngn => "ngn",
                PricingModelPricePeriodTierFlatPriceCurrency.Nok => "nok",
                PricingModelPricePeriodTierFlatPriceCurrency.Npr => "npr",
                PricingModelPricePeriodTierFlatPriceCurrency.Nzd => "nzd",
                PricingModelPricePeriodTierFlatPriceCurrency.Pgk => "pgk",
                PricingModelPricePeriodTierFlatPriceCurrency.Php => "php",
                PricingModelPricePeriodTierFlatPriceCurrency.Pkr => "pkr",
                PricingModelPricePeriodTierFlatPriceCurrency.Pln => "pln",
                PricingModelPricePeriodTierFlatPriceCurrency.Qar => "qar",
                PricingModelPricePeriodTierFlatPriceCurrency.Ron => "ron",
                PricingModelPricePeriodTierFlatPriceCurrency.Rsd => "rsd",
                PricingModelPricePeriodTierFlatPriceCurrency.Rub => "rub",
                PricingModelPricePeriodTierFlatPriceCurrency.Rwf => "rwf",
                PricingModelPricePeriodTierFlatPriceCurrency.Sar => "sar",
                PricingModelPricePeriodTierFlatPriceCurrency.Sbd => "sbd",
                PricingModelPricePeriodTierFlatPriceCurrency.Scr => "scr",
                PricingModelPricePeriodTierFlatPriceCurrency.Sek => "sek",
                PricingModelPricePeriodTierFlatPriceCurrency.Sgd => "sgd",
                PricingModelPricePeriodTierFlatPriceCurrency.Sle => "sle",
                PricingModelPricePeriodTierFlatPriceCurrency.Sll => "sll",
                PricingModelPricePeriodTierFlatPriceCurrency.Sos => "sos",
                PricingModelPricePeriodTierFlatPriceCurrency.Szl => "szl",
                PricingModelPricePeriodTierFlatPriceCurrency.Thb => "thb",
                PricingModelPricePeriodTierFlatPriceCurrency.Tjs => "tjs",
                PricingModelPricePeriodTierFlatPriceCurrency.Top => "top",
                PricingModelPricePeriodTierFlatPriceCurrency.Try => "try",
                PricingModelPricePeriodTierFlatPriceCurrency.Ttd => "ttd",
                PricingModelPricePeriodTierFlatPriceCurrency.Tzs => "tzs",
                PricingModelPricePeriodTierFlatPriceCurrency.Uah => "uah",
                PricingModelPricePeriodTierFlatPriceCurrency.Uzs => "uzs",
                PricingModelPricePeriodTierFlatPriceCurrency.Vnd => "vnd",
                PricingModelPricePeriodTierFlatPriceCurrency.Vuv => "vuv",
                PricingModelPricePeriodTierFlatPriceCurrency.Wst => "wst",
                PricingModelPricePeriodTierFlatPriceCurrency.Xaf => "xaf",
                PricingModelPricePeriodTierFlatPriceCurrency.Xcd => "xcd",
                PricingModelPricePeriodTierFlatPriceCurrency.Yer => "yer",
                PricingModelPricePeriodTierFlatPriceCurrency.Zar => "zar",
                PricingModelPricePeriodTierFlatPriceCurrency.Zmw => "zmw",
                PricingModelPricePeriodTierFlatPriceCurrency.Clp => "clp",
                PricingModelPricePeriodTierFlatPriceCurrency.Djf => "djf",
                PricingModelPricePeriodTierFlatPriceCurrency.Gnf => "gnf",
                PricingModelPricePeriodTierFlatPriceCurrency.Ugx => "ugx",
                PricingModelPricePeriodTierFlatPriceCurrency.Pyg => "pyg",
                PricingModelPricePeriodTierFlatPriceCurrency.Xof => "xof",
                PricingModelPricePeriodTierFlatPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Per-unit price in this tier
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PricingModelPricePeriodTierUnitPrice,
        PricingModelPricePeriodTierUnitPriceFromRaw
    >)
)]
public sealed record class PricingModelPricePeriodTierUnitPrice : JsonModel
{
    /// <summary>
    /// The price amount
    /// </summary>
    public required double Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The price currency
    /// </summary>
    public ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency>? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PricingModelPricePeriodTierUnitPriceCurrency>
            >("currency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency?.Validate();
    }

    public PricingModelPricePeriodTierUnitPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelPricePeriodTierUnitPrice(
        PricingModelPricePeriodTierUnitPrice pricingModelPricePeriodTierUnitPrice
    )
        : base(pricingModelPricePeriodTierUnitPrice) { }
#pragma warning restore CS8618

    public PricingModelPricePeriodTierUnitPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelPricePeriodTierUnitPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelPricePeriodTierUnitPriceFromRaw.FromRawUnchecked"/>
    public static PricingModelPricePeriodTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PricingModelPricePeriodTierUnitPrice(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class PricingModelPricePeriodTierUnitPriceFromRaw
    : IFromRawJson<PricingModelPricePeriodTierUnitPrice>
{
    /// <inheritdoc/>
    public PricingModelPricePeriodTierUnitPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelPricePeriodTierUnitPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The price currency
/// </summary>
[JsonConverter(typeof(PricingModelPricePeriodTierUnitPriceCurrencyConverter))]
public enum PricingModelPricePeriodTierUnitPriceCurrency
{
    Usd,
    Aed,
    All,
    Amd,
    Ang,
    Aud,
    Awg,
    Azn,
    Bam,
    Bbd,
    Bdt,
    Bgn,
    Bif,
    Bmd,
    Bnd,
    Bsd,
    Bwp,
    Byn,
    Bzd,
    Brl,
    Cad,
    Cdf,
    Chf,
    Cny,
    Czk,
    Dkk,
    Dop,
    Dzd,
    Egp,
    Etb,
    Eur,
    Fjd,
    Gbp,
    Gel,
    Gip,
    Gmd,
    Gyd,
    Hkd,
    Hrk,
    Htg,
    Idr,
    Ils,
    Inr,
    Isk,
    Jmd,
    Jpy,
    Kes,
    Kgs,
    Khr,
    Kmf,
    Krw,
    Kyd,
    Kzt,
    Lbp,
    Lkr,
    Lrd,
    Lsl,
    Mad,
    Mdl,
    Mga,
    Mkd,
    Mmk,
    Mnt,
    Mop,
    Mro,
    Mvr,
    Mwk,
    Mxn,
    Myr,
    Mzn,
    Nad,
    Ngn,
    Nok,
    Npr,
    Nzd,
    Pgk,
    Php,
    Pkr,
    Pln,
    Qar,
    Ron,
    Rsd,
    Rub,
    Rwf,
    Sar,
    Sbd,
    Scr,
    Sek,
    Sgd,
    Sle,
    Sll,
    Sos,
    Szl,
    Thb,
    Tjs,
    Top,
    Try,
    Ttd,
    Tzs,
    Uah,
    Uzs,
    Vnd,
    Vuv,
    Wst,
    Xaf,
    Xcd,
    Yer,
    Zar,
    Zmw,
    Clp,
    Djf,
    Gnf,
    Ugx,
    Pyg,
    Xof,
    Xpf,
}

sealed class PricingModelPricePeriodTierUnitPriceCurrencyConverter
    : JsonConverter<PricingModelPricePeriodTierUnitPriceCurrency>
{
    public override PricingModelPricePeriodTierUnitPriceCurrency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usd" => PricingModelPricePeriodTierUnitPriceCurrency.Usd,
            "aed" => PricingModelPricePeriodTierUnitPriceCurrency.Aed,
            "all" => PricingModelPricePeriodTierUnitPriceCurrency.All,
            "amd" => PricingModelPricePeriodTierUnitPriceCurrency.Amd,
            "ang" => PricingModelPricePeriodTierUnitPriceCurrency.Ang,
            "aud" => PricingModelPricePeriodTierUnitPriceCurrency.Aud,
            "awg" => PricingModelPricePeriodTierUnitPriceCurrency.Awg,
            "azn" => PricingModelPricePeriodTierUnitPriceCurrency.Azn,
            "bam" => PricingModelPricePeriodTierUnitPriceCurrency.Bam,
            "bbd" => PricingModelPricePeriodTierUnitPriceCurrency.Bbd,
            "bdt" => PricingModelPricePeriodTierUnitPriceCurrency.Bdt,
            "bgn" => PricingModelPricePeriodTierUnitPriceCurrency.Bgn,
            "bif" => PricingModelPricePeriodTierUnitPriceCurrency.Bif,
            "bmd" => PricingModelPricePeriodTierUnitPriceCurrency.Bmd,
            "bnd" => PricingModelPricePeriodTierUnitPriceCurrency.Bnd,
            "bsd" => PricingModelPricePeriodTierUnitPriceCurrency.Bsd,
            "bwp" => PricingModelPricePeriodTierUnitPriceCurrency.Bwp,
            "byn" => PricingModelPricePeriodTierUnitPriceCurrency.Byn,
            "bzd" => PricingModelPricePeriodTierUnitPriceCurrency.Bzd,
            "brl" => PricingModelPricePeriodTierUnitPriceCurrency.Brl,
            "cad" => PricingModelPricePeriodTierUnitPriceCurrency.Cad,
            "cdf" => PricingModelPricePeriodTierUnitPriceCurrency.Cdf,
            "chf" => PricingModelPricePeriodTierUnitPriceCurrency.Chf,
            "cny" => PricingModelPricePeriodTierUnitPriceCurrency.Cny,
            "czk" => PricingModelPricePeriodTierUnitPriceCurrency.Czk,
            "dkk" => PricingModelPricePeriodTierUnitPriceCurrency.Dkk,
            "dop" => PricingModelPricePeriodTierUnitPriceCurrency.Dop,
            "dzd" => PricingModelPricePeriodTierUnitPriceCurrency.Dzd,
            "egp" => PricingModelPricePeriodTierUnitPriceCurrency.Egp,
            "etb" => PricingModelPricePeriodTierUnitPriceCurrency.Etb,
            "eur" => PricingModelPricePeriodTierUnitPriceCurrency.Eur,
            "fjd" => PricingModelPricePeriodTierUnitPriceCurrency.Fjd,
            "gbp" => PricingModelPricePeriodTierUnitPriceCurrency.Gbp,
            "gel" => PricingModelPricePeriodTierUnitPriceCurrency.Gel,
            "gip" => PricingModelPricePeriodTierUnitPriceCurrency.Gip,
            "gmd" => PricingModelPricePeriodTierUnitPriceCurrency.Gmd,
            "gyd" => PricingModelPricePeriodTierUnitPriceCurrency.Gyd,
            "hkd" => PricingModelPricePeriodTierUnitPriceCurrency.Hkd,
            "hrk" => PricingModelPricePeriodTierUnitPriceCurrency.Hrk,
            "htg" => PricingModelPricePeriodTierUnitPriceCurrency.Htg,
            "idr" => PricingModelPricePeriodTierUnitPriceCurrency.Idr,
            "ils" => PricingModelPricePeriodTierUnitPriceCurrency.Ils,
            "inr" => PricingModelPricePeriodTierUnitPriceCurrency.Inr,
            "isk" => PricingModelPricePeriodTierUnitPriceCurrency.Isk,
            "jmd" => PricingModelPricePeriodTierUnitPriceCurrency.Jmd,
            "jpy" => PricingModelPricePeriodTierUnitPriceCurrency.Jpy,
            "kes" => PricingModelPricePeriodTierUnitPriceCurrency.Kes,
            "kgs" => PricingModelPricePeriodTierUnitPriceCurrency.Kgs,
            "khr" => PricingModelPricePeriodTierUnitPriceCurrency.Khr,
            "kmf" => PricingModelPricePeriodTierUnitPriceCurrency.Kmf,
            "krw" => PricingModelPricePeriodTierUnitPriceCurrency.Krw,
            "kyd" => PricingModelPricePeriodTierUnitPriceCurrency.Kyd,
            "kzt" => PricingModelPricePeriodTierUnitPriceCurrency.Kzt,
            "lbp" => PricingModelPricePeriodTierUnitPriceCurrency.Lbp,
            "lkr" => PricingModelPricePeriodTierUnitPriceCurrency.Lkr,
            "lrd" => PricingModelPricePeriodTierUnitPriceCurrency.Lrd,
            "lsl" => PricingModelPricePeriodTierUnitPriceCurrency.Lsl,
            "mad" => PricingModelPricePeriodTierUnitPriceCurrency.Mad,
            "mdl" => PricingModelPricePeriodTierUnitPriceCurrency.Mdl,
            "mga" => PricingModelPricePeriodTierUnitPriceCurrency.Mga,
            "mkd" => PricingModelPricePeriodTierUnitPriceCurrency.Mkd,
            "mmk" => PricingModelPricePeriodTierUnitPriceCurrency.Mmk,
            "mnt" => PricingModelPricePeriodTierUnitPriceCurrency.Mnt,
            "mop" => PricingModelPricePeriodTierUnitPriceCurrency.Mop,
            "mro" => PricingModelPricePeriodTierUnitPriceCurrency.Mro,
            "mvr" => PricingModelPricePeriodTierUnitPriceCurrency.Mvr,
            "mwk" => PricingModelPricePeriodTierUnitPriceCurrency.Mwk,
            "mxn" => PricingModelPricePeriodTierUnitPriceCurrency.Mxn,
            "myr" => PricingModelPricePeriodTierUnitPriceCurrency.Myr,
            "mzn" => PricingModelPricePeriodTierUnitPriceCurrency.Mzn,
            "nad" => PricingModelPricePeriodTierUnitPriceCurrency.Nad,
            "ngn" => PricingModelPricePeriodTierUnitPriceCurrency.Ngn,
            "nok" => PricingModelPricePeriodTierUnitPriceCurrency.Nok,
            "npr" => PricingModelPricePeriodTierUnitPriceCurrency.Npr,
            "nzd" => PricingModelPricePeriodTierUnitPriceCurrency.Nzd,
            "pgk" => PricingModelPricePeriodTierUnitPriceCurrency.Pgk,
            "php" => PricingModelPricePeriodTierUnitPriceCurrency.Php,
            "pkr" => PricingModelPricePeriodTierUnitPriceCurrency.Pkr,
            "pln" => PricingModelPricePeriodTierUnitPriceCurrency.Pln,
            "qar" => PricingModelPricePeriodTierUnitPriceCurrency.Qar,
            "ron" => PricingModelPricePeriodTierUnitPriceCurrency.Ron,
            "rsd" => PricingModelPricePeriodTierUnitPriceCurrency.Rsd,
            "rub" => PricingModelPricePeriodTierUnitPriceCurrency.Rub,
            "rwf" => PricingModelPricePeriodTierUnitPriceCurrency.Rwf,
            "sar" => PricingModelPricePeriodTierUnitPriceCurrency.Sar,
            "sbd" => PricingModelPricePeriodTierUnitPriceCurrency.Sbd,
            "scr" => PricingModelPricePeriodTierUnitPriceCurrency.Scr,
            "sek" => PricingModelPricePeriodTierUnitPriceCurrency.Sek,
            "sgd" => PricingModelPricePeriodTierUnitPriceCurrency.Sgd,
            "sle" => PricingModelPricePeriodTierUnitPriceCurrency.Sle,
            "sll" => PricingModelPricePeriodTierUnitPriceCurrency.Sll,
            "sos" => PricingModelPricePeriodTierUnitPriceCurrency.Sos,
            "szl" => PricingModelPricePeriodTierUnitPriceCurrency.Szl,
            "thb" => PricingModelPricePeriodTierUnitPriceCurrency.Thb,
            "tjs" => PricingModelPricePeriodTierUnitPriceCurrency.Tjs,
            "top" => PricingModelPricePeriodTierUnitPriceCurrency.Top,
            "try" => PricingModelPricePeriodTierUnitPriceCurrency.Try,
            "ttd" => PricingModelPricePeriodTierUnitPriceCurrency.Ttd,
            "tzs" => PricingModelPricePeriodTierUnitPriceCurrency.Tzs,
            "uah" => PricingModelPricePeriodTierUnitPriceCurrency.Uah,
            "uzs" => PricingModelPricePeriodTierUnitPriceCurrency.Uzs,
            "vnd" => PricingModelPricePeriodTierUnitPriceCurrency.Vnd,
            "vuv" => PricingModelPricePeriodTierUnitPriceCurrency.Vuv,
            "wst" => PricingModelPricePeriodTierUnitPriceCurrency.Wst,
            "xaf" => PricingModelPricePeriodTierUnitPriceCurrency.Xaf,
            "xcd" => PricingModelPricePeriodTierUnitPriceCurrency.Xcd,
            "yer" => PricingModelPricePeriodTierUnitPriceCurrency.Yer,
            "zar" => PricingModelPricePeriodTierUnitPriceCurrency.Zar,
            "zmw" => PricingModelPricePeriodTierUnitPriceCurrency.Zmw,
            "clp" => PricingModelPricePeriodTierUnitPriceCurrency.Clp,
            "djf" => PricingModelPricePeriodTierUnitPriceCurrency.Djf,
            "gnf" => PricingModelPricePeriodTierUnitPriceCurrency.Gnf,
            "ugx" => PricingModelPricePeriodTierUnitPriceCurrency.Ugx,
            "pyg" => PricingModelPricePeriodTierUnitPriceCurrency.Pyg,
            "xof" => PricingModelPricePeriodTierUnitPriceCurrency.Xof,
            "xpf" => PricingModelPricePeriodTierUnitPriceCurrency.Xpf,
            _ => (PricingModelPricePeriodTierUnitPriceCurrency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelPricePeriodTierUnitPriceCurrency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelPricePeriodTierUnitPriceCurrency.Usd => "usd",
                PricingModelPricePeriodTierUnitPriceCurrency.Aed => "aed",
                PricingModelPricePeriodTierUnitPriceCurrency.All => "all",
                PricingModelPricePeriodTierUnitPriceCurrency.Amd => "amd",
                PricingModelPricePeriodTierUnitPriceCurrency.Ang => "ang",
                PricingModelPricePeriodTierUnitPriceCurrency.Aud => "aud",
                PricingModelPricePeriodTierUnitPriceCurrency.Awg => "awg",
                PricingModelPricePeriodTierUnitPriceCurrency.Azn => "azn",
                PricingModelPricePeriodTierUnitPriceCurrency.Bam => "bam",
                PricingModelPricePeriodTierUnitPriceCurrency.Bbd => "bbd",
                PricingModelPricePeriodTierUnitPriceCurrency.Bdt => "bdt",
                PricingModelPricePeriodTierUnitPriceCurrency.Bgn => "bgn",
                PricingModelPricePeriodTierUnitPriceCurrency.Bif => "bif",
                PricingModelPricePeriodTierUnitPriceCurrency.Bmd => "bmd",
                PricingModelPricePeriodTierUnitPriceCurrency.Bnd => "bnd",
                PricingModelPricePeriodTierUnitPriceCurrency.Bsd => "bsd",
                PricingModelPricePeriodTierUnitPriceCurrency.Bwp => "bwp",
                PricingModelPricePeriodTierUnitPriceCurrency.Byn => "byn",
                PricingModelPricePeriodTierUnitPriceCurrency.Bzd => "bzd",
                PricingModelPricePeriodTierUnitPriceCurrency.Brl => "brl",
                PricingModelPricePeriodTierUnitPriceCurrency.Cad => "cad",
                PricingModelPricePeriodTierUnitPriceCurrency.Cdf => "cdf",
                PricingModelPricePeriodTierUnitPriceCurrency.Chf => "chf",
                PricingModelPricePeriodTierUnitPriceCurrency.Cny => "cny",
                PricingModelPricePeriodTierUnitPriceCurrency.Czk => "czk",
                PricingModelPricePeriodTierUnitPriceCurrency.Dkk => "dkk",
                PricingModelPricePeriodTierUnitPriceCurrency.Dop => "dop",
                PricingModelPricePeriodTierUnitPriceCurrency.Dzd => "dzd",
                PricingModelPricePeriodTierUnitPriceCurrency.Egp => "egp",
                PricingModelPricePeriodTierUnitPriceCurrency.Etb => "etb",
                PricingModelPricePeriodTierUnitPriceCurrency.Eur => "eur",
                PricingModelPricePeriodTierUnitPriceCurrency.Fjd => "fjd",
                PricingModelPricePeriodTierUnitPriceCurrency.Gbp => "gbp",
                PricingModelPricePeriodTierUnitPriceCurrency.Gel => "gel",
                PricingModelPricePeriodTierUnitPriceCurrency.Gip => "gip",
                PricingModelPricePeriodTierUnitPriceCurrency.Gmd => "gmd",
                PricingModelPricePeriodTierUnitPriceCurrency.Gyd => "gyd",
                PricingModelPricePeriodTierUnitPriceCurrency.Hkd => "hkd",
                PricingModelPricePeriodTierUnitPriceCurrency.Hrk => "hrk",
                PricingModelPricePeriodTierUnitPriceCurrency.Htg => "htg",
                PricingModelPricePeriodTierUnitPriceCurrency.Idr => "idr",
                PricingModelPricePeriodTierUnitPriceCurrency.Ils => "ils",
                PricingModelPricePeriodTierUnitPriceCurrency.Inr => "inr",
                PricingModelPricePeriodTierUnitPriceCurrency.Isk => "isk",
                PricingModelPricePeriodTierUnitPriceCurrency.Jmd => "jmd",
                PricingModelPricePeriodTierUnitPriceCurrency.Jpy => "jpy",
                PricingModelPricePeriodTierUnitPriceCurrency.Kes => "kes",
                PricingModelPricePeriodTierUnitPriceCurrency.Kgs => "kgs",
                PricingModelPricePeriodTierUnitPriceCurrency.Khr => "khr",
                PricingModelPricePeriodTierUnitPriceCurrency.Kmf => "kmf",
                PricingModelPricePeriodTierUnitPriceCurrency.Krw => "krw",
                PricingModelPricePeriodTierUnitPriceCurrency.Kyd => "kyd",
                PricingModelPricePeriodTierUnitPriceCurrency.Kzt => "kzt",
                PricingModelPricePeriodTierUnitPriceCurrency.Lbp => "lbp",
                PricingModelPricePeriodTierUnitPriceCurrency.Lkr => "lkr",
                PricingModelPricePeriodTierUnitPriceCurrency.Lrd => "lrd",
                PricingModelPricePeriodTierUnitPriceCurrency.Lsl => "lsl",
                PricingModelPricePeriodTierUnitPriceCurrency.Mad => "mad",
                PricingModelPricePeriodTierUnitPriceCurrency.Mdl => "mdl",
                PricingModelPricePeriodTierUnitPriceCurrency.Mga => "mga",
                PricingModelPricePeriodTierUnitPriceCurrency.Mkd => "mkd",
                PricingModelPricePeriodTierUnitPriceCurrency.Mmk => "mmk",
                PricingModelPricePeriodTierUnitPriceCurrency.Mnt => "mnt",
                PricingModelPricePeriodTierUnitPriceCurrency.Mop => "mop",
                PricingModelPricePeriodTierUnitPriceCurrency.Mro => "mro",
                PricingModelPricePeriodTierUnitPriceCurrency.Mvr => "mvr",
                PricingModelPricePeriodTierUnitPriceCurrency.Mwk => "mwk",
                PricingModelPricePeriodTierUnitPriceCurrency.Mxn => "mxn",
                PricingModelPricePeriodTierUnitPriceCurrency.Myr => "myr",
                PricingModelPricePeriodTierUnitPriceCurrency.Mzn => "mzn",
                PricingModelPricePeriodTierUnitPriceCurrency.Nad => "nad",
                PricingModelPricePeriodTierUnitPriceCurrency.Ngn => "ngn",
                PricingModelPricePeriodTierUnitPriceCurrency.Nok => "nok",
                PricingModelPricePeriodTierUnitPriceCurrency.Npr => "npr",
                PricingModelPricePeriodTierUnitPriceCurrency.Nzd => "nzd",
                PricingModelPricePeriodTierUnitPriceCurrency.Pgk => "pgk",
                PricingModelPricePeriodTierUnitPriceCurrency.Php => "php",
                PricingModelPricePeriodTierUnitPriceCurrency.Pkr => "pkr",
                PricingModelPricePeriodTierUnitPriceCurrency.Pln => "pln",
                PricingModelPricePeriodTierUnitPriceCurrency.Qar => "qar",
                PricingModelPricePeriodTierUnitPriceCurrency.Ron => "ron",
                PricingModelPricePeriodTierUnitPriceCurrency.Rsd => "rsd",
                PricingModelPricePeriodTierUnitPriceCurrency.Rub => "rub",
                PricingModelPricePeriodTierUnitPriceCurrency.Rwf => "rwf",
                PricingModelPricePeriodTierUnitPriceCurrency.Sar => "sar",
                PricingModelPricePeriodTierUnitPriceCurrency.Sbd => "sbd",
                PricingModelPricePeriodTierUnitPriceCurrency.Scr => "scr",
                PricingModelPricePeriodTierUnitPriceCurrency.Sek => "sek",
                PricingModelPricePeriodTierUnitPriceCurrency.Sgd => "sgd",
                PricingModelPricePeriodTierUnitPriceCurrency.Sle => "sle",
                PricingModelPricePeriodTierUnitPriceCurrency.Sll => "sll",
                PricingModelPricePeriodTierUnitPriceCurrency.Sos => "sos",
                PricingModelPricePeriodTierUnitPriceCurrency.Szl => "szl",
                PricingModelPricePeriodTierUnitPriceCurrency.Thb => "thb",
                PricingModelPricePeriodTierUnitPriceCurrency.Tjs => "tjs",
                PricingModelPricePeriodTierUnitPriceCurrency.Top => "top",
                PricingModelPricePeriodTierUnitPriceCurrency.Try => "try",
                PricingModelPricePeriodTierUnitPriceCurrency.Ttd => "ttd",
                PricingModelPricePeriodTierUnitPriceCurrency.Tzs => "tzs",
                PricingModelPricePeriodTierUnitPriceCurrency.Uah => "uah",
                PricingModelPricePeriodTierUnitPriceCurrency.Uzs => "uzs",
                PricingModelPricePeriodTierUnitPriceCurrency.Vnd => "vnd",
                PricingModelPricePeriodTierUnitPriceCurrency.Vuv => "vuv",
                PricingModelPricePeriodTierUnitPriceCurrency.Wst => "wst",
                PricingModelPricePeriodTierUnitPriceCurrency.Xaf => "xaf",
                PricingModelPricePeriodTierUnitPriceCurrency.Xcd => "xcd",
                PricingModelPricePeriodTierUnitPriceCurrency.Yer => "yer",
                PricingModelPricePeriodTierUnitPriceCurrency.Zar => "zar",
                PricingModelPricePeriodTierUnitPriceCurrency.Zmw => "zmw",
                PricingModelPricePeriodTierUnitPriceCurrency.Clp => "clp",
                PricingModelPricePeriodTierUnitPriceCurrency.Djf => "djf",
                PricingModelPricePeriodTierUnitPriceCurrency.Gnf => "gnf",
                PricingModelPricePeriodTierUnitPriceCurrency.Ugx => "ugx",
                PricingModelPricePeriodTierUnitPriceCurrency.Pyg => "pyg",
                PricingModelPricePeriodTierUnitPriceCurrency.Xof => "xof",
                PricingModelPricePeriodTierUnitPriceCurrency.Xpf => "xpf",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The billing cadence (RECURRING or ONE_OFF)
/// </summary>
[JsonConverter(typeof(BillingCadenceConverter))]
public enum BillingCadence
{
    Recurring,
    OneOff,
}

sealed class BillingCadenceConverter : JsonConverter<BillingCadence>
{
    public override BillingCadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RECURRING" => BillingCadence.Recurring,
            "ONE_OFF" => BillingCadence.OneOff,
            _ => (BillingCadence)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingCadence value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillingCadence.Recurring => "RECURRING",
                BillingCadence.OneOff => "ONE_OFF",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Monthly reset period configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PricingModelMonthlyResetPeriodConfiguration,
        PricingModelMonthlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class PricingModelMonthlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or StartOfTheMonth)
    /// </summary>
    public required ApiEnum<
        string,
        PricingModelMonthlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PricingModelMonthlyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public PricingModelMonthlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelMonthlyResetPeriodConfiguration(
        PricingModelMonthlyResetPeriodConfiguration pricingModelMonthlyResetPeriodConfiguration
    )
        : base(pricingModelMonthlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public PricingModelMonthlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelMonthlyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelMonthlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static PricingModelMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PricingModelMonthlyResetPeriodConfiguration(
        ApiEnum<string, PricingModelMonthlyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PricingModelMonthlyResetPeriodConfigurationFromRaw
    : IFromRawJson<PricingModelMonthlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public PricingModelMonthlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelMonthlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or StartOfTheMonth)
/// </summary>
[JsonConverter(typeof(PricingModelMonthlyResetPeriodConfigurationAccordingToConverter))]
public enum PricingModelMonthlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
    StartOfTheMonth,
}

sealed class PricingModelMonthlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<PricingModelMonthlyResetPeriodConfigurationAccordingTo>
{
    public override PricingModelMonthlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "StartOfTheMonth" =>
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth,
            _ => (PricingModelMonthlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelMonthlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                PricingModelMonthlyResetPeriodConfigurationAccordingTo.StartOfTheMonth =>
                    "StartOfTheMonth",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The usage reset period
/// </summary>
[JsonConverter(typeof(PricingModelResetPeriodConverter))]
public enum PricingModelResetPeriod
{
    Year,
    Month,
    Week,
    Day,
    Hour,
}

sealed class PricingModelResetPeriodConverter : JsonConverter<PricingModelResetPeriod>
{
    public override PricingModelResetPeriod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "YEAR" => PricingModelResetPeriod.Year,
            "MONTH" => PricingModelResetPeriod.Month,
            "WEEK" => PricingModelResetPeriod.Week,
            "DAY" => PricingModelResetPeriod.Day,
            "HOUR" => PricingModelResetPeriod.Hour,
            _ => (PricingModelResetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelResetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelResetPeriod.Year => "YEAR",
                PricingModelResetPeriod.Month => "MONTH",
                PricingModelResetPeriod.Week => "WEEK",
                PricingModelResetPeriod.Day => "DAY",
                PricingModelResetPeriod.Hour => "HOUR",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The tiered pricing mode (VOLUME or GRADUATED)
/// </summary>
[JsonConverter(typeof(TiersModeConverter))]
public enum TiersMode
{
    Volume,
    Graduated,
}

sealed class TiersModeConverter : JsonConverter<TiersMode>
{
    public override TiersMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VOLUME" => TiersMode.Volume,
            "GRADUATED" => TiersMode.Graduated,
            _ => (TiersMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TiersMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TiersMode.Volume => "VOLUME",
                TiersMode.Graduated => "GRADUATED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Weekly reset period configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PricingModelWeeklyResetPeriodConfiguration,
        PricingModelWeeklyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class PricingModelWeeklyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart or specific day)
    /// </summary>
    public required ApiEnum<
        string,
        PricingModelWeeklyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public PricingModelWeeklyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelWeeklyResetPeriodConfiguration(
        PricingModelWeeklyResetPeriodConfiguration pricingModelWeeklyResetPeriodConfiguration
    )
        : base(pricingModelWeeklyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public PricingModelWeeklyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelWeeklyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelWeeklyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static PricingModelWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PricingModelWeeklyResetPeriodConfiguration(
        ApiEnum<string, PricingModelWeeklyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PricingModelWeeklyResetPeriodConfigurationFromRaw
    : IFromRawJson<PricingModelWeeklyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public PricingModelWeeklyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelWeeklyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart or specific day)
/// </summary>
[JsonConverter(typeof(PricingModelWeeklyResetPeriodConfigurationAccordingToConverter))]
public enum PricingModelWeeklyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
    EverySunday,
    EveryMonday,
    EveryTuesday,
    EveryWednesday,
    EveryThursday,
    EveryFriday,
    EverySaturday,
}

sealed class PricingModelWeeklyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<PricingModelWeeklyResetPeriodConfigurationAccordingTo>
{
    public override PricingModelWeeklyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            "EverySunday" => PricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySunday,
            "EveryMonday" => PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryMonday,
            "EveryTuesday" => PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday,
            "EveryWednesday" =>
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday,
            "EveryThursday" => PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryThursday,
            "EveryFriday" => PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryFriday,
            "EverySaturday" => PricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySaturday,
            _ => (PricingModelWeeklyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelWeeklyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySunday => "EverySunday",
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryMonday => "EveryMonday",
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryTuesday =>
                    "EveryTuesday",
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryWednesday =>
                    "EveryWednesday",
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryThursday =>
                    "EveryThursday",
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.EveryFriday => "EveryFriday",
                PricingModelWeeklyResetPeriodConfigurationAccordingTo.EverySaturday =>
                    "EverySaturday",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Yearly reset period configuration
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PricingModelYearlyResetPeriodConfiguration,
        PricingModelYearlyResetPeriodConfigurationFromRaw
    >)
)]
public sealed record class PricingModelYearlyResetPeriodConfiguration : JsonModel
{
    /// <summary>
    /// Reset anchor (SubscriptionStart)
    /// </summary>
    public required ApiEnum<
        string,
        PricingModelYearlyResetPeriodConfigurationAccordingTo
    > AccordingTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo>
            >("accordingTo");
        }
        init { this._rawData.Set("accordingTo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AccordingTo.Validate();
    }

    public PricingModelYearlyResetPeriodConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PricingModelYearlyResetPeriodConfiguration(
        PricingModelYearlyResetPeriodConfiguration pricingModelYearlyResetPeriodConfiguration
    )
        : base(pricingModelYearlyResetPeriodConfiguration) { }
#pragma warning restore CS8618

    public PricingModelYearlyResetPeriodConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PricingModelYearlyResetPeriodConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PricingModelYearlyResetPeriodConfigurationFromRaw.FromRawUnchecked"/>
    public static PricingModelYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PricingModelYearlyResetPeriodConfiguration(
        ApiEnum<string, PricingModelYearlyResetPeriodConfigurationAccordingTo> accordingTo
    )
        : this()
    {
        this.AccordingTo = accordingTo;
    }
}

class PricingModelYearlyResetPeriodConfigurationFromRaw
    : IFromRawJson<PricingModelYearlyResetPeriodConfiguration>
{
    /// <inheritdoc/>
    public PricingModelYearlyResetPeriodConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PricingModelYearlyResetPeriodConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Reset anchor (SubscriptionStart)
/// </summary>
[JsonConverter(typeof(PricingModelYearlyResetPeriodConfigurationAccordingToConverter))]
public enum PricingModelYearlyResetPeriodConfigurationAccordingTo
{
    SubscriptionStart,
}

sealed class PricingModelYearlyResetPeriodConfigurationAccordingToConverter
    : JsonConverter<PricingModelYearlyResetPeriodConfigurationAccordingTo>
{
    public override PricingModelYearlyResetPeriodConfigurationAccordingTo Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SubscriptionStart" =>
                PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart,
            _ => (PricingModelYearlyResetPeriodConfigurationAccordingTo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PricingModelYearlyResetPeriodConfigurationAccordingTo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PricingModelYearlyResetPeriodConfigurationAccordingTo.SubscriptionStart =>
                    "SubscriptionStart",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Default trial configuration for the plan. When set, subscriptions provisioned
/// on this plan without explicit trial settings automatically start in trial for
/// the configured duration; leave unset for no automatic trial.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanUpdateParamsDefaultTrialConfig,
        PlanUpdateParamsDefaultTrialConfigFromRaw
    >)
)]
public sealed record class PlanUpdateParamsDefaultTrialConfig : JsonModel
{
    /// <summary>
    /// The duration of the trial in the specified units
    /// </summary>
    public required double Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// The time unit for the trial duration (DAY or MONTH)
    /// </summary>
    public required ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> Units
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
            >("units");
        }
        init { this._rawData.Set("units", value); }
    }

    /// <summary>
    /// Budget configuration for the trial
    /// </summary>
    public PlanUpdateParamsDefaultTrialConfigBudget? Budget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlanUpdateParamsDefaultTrialConfigBudget>(
                "budget"
            );
        }
        init { this._rawData.Set("budget", value); }
    }

    /// <summary>
    /// Behavior when the trial ends (CONVERT_TO_PAID or CANCEL_SUBSCRIPTION)
    /// </summary>
    public ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>? TrialEndBehavior
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
            >("trialEndBehavior");
        }
        init { this._rawData.Set("trialEndBehavior", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        this.Units.Validate();
        this.Budget?.Validate();
        this.TrialEndBehavior?.Validate();
    }

    public PlanUpdateParamsDefaultTrialConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanUpdateParamsDefaultTrialConfig(
        PlanUpdateParamsDefaultTrialConfig planUpdateParamsDefaultTrialConfig
    )
        : base(planUpdateParamsDefaultTrialConfig) { }
#pragma warning restore CS8618

    public PlanUpdateParamsDefaultTrialConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanUpdateParamsDefaultTrialConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanUpdateParamsDefaultTrialConfigFromRaw.FromRawUnchecked"/>
    public static PlanUpdateParamsDefaultTrialConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanUpdateParamsDefaultTrialConfigFromRaw : IFromRawJson<PlanUpdateParamsDefaultTrialConfig>
{
    /// <inheritdoc/>
    public PlanUpdateParamsDefaultTrialConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanUpdateParamsDefaultTrialConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The time unit for the trial duration (DAY or MONTH)
/// </summary>
[JsonConverter(typeof(PlanUpdateParamsDefaultTrialConfigUnitsConverter))]
public enum PlanUpdateParamsDefaultTrialConfigUnits
{
    Day,
    Month,
}

sealed class PlanUpdateParamsDefaultTrialConfigUnitsConverter
    : JsonConverter<PlanUpdateParamsDefaultTrialConfigUnits>
{
    public override PlanUpdateParamsDefaultTrialConfigUnits Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DAY" => PlanUpdateParamsDefaultTrialConfigUnits.Day,
            "MONTH" => PlanUpdateParamsDefaultTrialConfigUnits.Month,
            _ => (PlanUpdateParamsDefaultTrialConfigUnits)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanUpdateParamsDefaultTrialConfigUnits value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanUpdateParamsDefaultTrialConfigUnits.Day => "DAY",
                PlanUpdateParamsDefaultTrialConfigUnits.Month => "MONTH",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Budget configuration for the trial
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlanUpdateParamsDefaultTrialConfigBudget,
        PlanUpdateParamsDefaultTrialConfigBudgetFromRaw
    >)
)]
public sealed record class PlanUpdateParamsDefaultTrialConfigBudget : JsonModel
{
    /// <summary>
    /// Whether the budget limit is a soft limit (allows overage) or hard limit
    /// </summary>
    public required bool HasSoftLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasSoftLimit");
        }
        init { this._rawData.Set("hasSoftLimit", value); }
    }

    /// <summary>
    /// The budget limit amount
    /// </summary>
    public required double Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasSoftLimit;
        _ = this.Limit;
    }

    public PlanUpdateParamsDefaultTrialConfigBudget() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlanUpdateParamsDefaultTrialConfigBudget(
        PlanUpdateParamsDefaultTrialConfigBudget planUpdateParamsDefaultTrialConfigBudget
    )
        : base(planUpdateParamsDefaultTrialConfigBudget) { }
#pragma warning restore CS8618

    public PlanUpdateParamsDefaultTrialConfigBudget(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanUpdateParamsDefaultTrialConfigBudget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanUpdateParamsDefaultTrialConfigBudgetFromRaw.FromRawUnchecked"/>
    public static PlanUpdateParamsDefaultTrialConfigBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanUpdateParamsDefaultTrialConfigBudgetFromRaw
    : IFromRawJson<PlanUpdateParamsDefaultTrialConfigBudget>
{
    /// <inheritdoc/>
    public PlanUpdateParamsDefaultTrialConfigBudget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanUpdateParamsDefaultTrialConfigBudget.FromRawUnchecked(rawData);
}

/// <summary>
/// Behavior when the trial ends (CONVERT_TO_PAID or CANCEL_SUBSCRIPTION)
/// </summary>
[JsonConverter(typeof(PlanUpdateParamsDefaultTrialConfigTrialEndBehaviorConverter))]
public enum PlanUpdateParamsDefaultTrialConfigTrialEndBehavior
{
    ConvertToPaid,
    CancelSubscription,
}

sealed class PlanUpdateParamsDefaultTrialConfigTrialEndBehaviorConverter
    : JsonConverter<PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
{
    public override PlanUpdateParamsDefaultTrialConfigTrialEndBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CONVERT_TO_PAID" => PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            "CANCEL_SUBSCRIPTION" =>
                PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.CancelSubscription,
            _ => (PlanUpdateParamsDefaultTrialConfigTrialEndBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanUpdateParamsDefaultTrialConfigTrialEndBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid =>
                    "CONVERT_TO_PAID",
                PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.CancelSubscription =>
                    "CANCEL_SUBSCRIPTION",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
