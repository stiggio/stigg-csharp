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

namespace Stigg.Client.Models.Internal.Beta.EventQueues;

/// <summary>
/// Provision SQS queue, SNS subscriptions, and IAM role for the current environment
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EventQueueProvisionParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// AWS region for the SQS queue (e.g., us-east-1, eu-west-1)
    /// </summary>
    public required ApiEnum<string, Region> Region
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Region>>("region");
        }
        init { this._rawBodyData.Set("region", value); }
    }

    /// <summary>
    /// Additional IAM role ARNs allowed to assume the external role for queue access
    /// </summary>
    public IReadOnlyList<string>? AllowedAssumeRoleArns
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "allowedAssumeRoleArns"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "allowedAssumeRoleArns",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether to create separate low-priority queues for standard topic events
    /// </summary>
    public bool? CreateLowPriorityQueues
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("createLowPriorityQueues");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("createLowPriorityQueues", value);
        }
    }

    /// <summary>
    /// Event types to subscribe to. Defaults to entitlements, measurements, and migrations.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, EventQueueProvisionParamsEventType>>? EventTypes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, EventQueueProvisionParamsEventType>>
            >("eventTypes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<
                ApiEnum<string, EventQueueProvisionParamsEventType>
            >?>("eventTypes", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Optional suffix to allow multiple queues for the same environment and region
    /// </summary>
    public string? Suffix
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("suffix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("suffix", value);
        }
    }

    public EventQueueProvisionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueProvisionParams(EventQueueProvisionParams eventQueueProvisionParams)
        : base(eventQueueProvisionParams)
    {
        this._rawBodyData = new(eventQueueProvisionParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EventQueueProvisionParams(
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
    EventQueueProvisionParams(
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
    public static EventQueueProvisionParams FromRawUnchecked(
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

    public virtual bool Equals(EventQueueProvisionParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/internal/beta/event-queues/provision"
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
/// AWS region for the SQS queue (e.g., us-east-1, eu-west-1)
/// </summary>
[JsonConverter(typeof(RegionConverter))]
public enum Region
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

sealed class RegionConverter : JsonConverter<Region>
{
    public override Region Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "us-east-1" => Region.UsEast1,
            "us-east-2" => Region.UsEast2,
            "us-west-1" => Region.UsWest1,
            "us-west-2" => Region.UsWest2,
            "ca-central-1" => Region.CaCentral1,
            "eu-west-1" => Region.EuWest1,
            "eu-west-2" => Region.EuWest2,
            "eu-west-3" => Region.EuWest3,
            "eu-central-1" => Region.EuCentral1,
            "eu-central-2" => Region.EuCentral2,
            "eu-north-1" => Region.EuNorth1,
            "eu-south-1" => Region.EuSouth1,
            "eu-south-2" => Region.EuSouth2,
            "ap-southeast-1" => Region.ApSoutheast1,
            "ap-southeast-2" => Region.ApSoutheast2,
            "ap-southeast-3" => Region.ApSoutheast3,
            "ap-northeast-1" => Region.ApNortheast1,
            "ap-northeast-2" => Region.ApNortheast2,
            "ap-northeast-3" => Region.ApNortheast3,
            "ap-south-1" => Region.ApSouth1,
            "ap-south-2" => Region.ApSouth2,
            "ap-east-1" => Region.ApEast1,
            "sa-east-1" => Region.SaEast1,
            "af-south-1" => Region.AfSouth1,
            "me-south-1" => Region.MeSouth1,
            "me-central-1" => Region.MeCentral1,
            "il-central-1" => Region.IlCentral1,
            _ => (Region)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Region value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Region.UsEast1 => "us-east-1",
                Region.UsEast2 => "us-east-2",
                Region.UsWest1 => "us-west-1",
                Region.UsWest2 => "us-west-2",
                Region.CaCentral1 => "ca-central-1",
                Region.EuWest1 => "eu-west-1",
                Region.EuWest2 => "eu-west-2",
                Region.EuWest3 => "eu-west-3",
                Region.EuCentral1 => "eu-central-1",
                Region.EuCentral2 => "eu-central-2",
                Region.EuNorth1 => "eu-north-1",
                Region.EuSouth1 => "eu-south-1",
                Region.EuSouth2 => "eu-south-2",
                Region.ApSoutheast1 => "ap-southeast-1",
                Region.ApSoutheast2 => "ap-southeast-2",
                Region.ApSoutheast3 => "ap-southeast-3",
                Region.ApNortheast1 => "ap-northeast-1",
                Region.ApNortheast2 => "ap-northeast-2",
                Region.ApNortheast3 => "ap-northeast-3",
                Region.ApSouth1 => "ap-south-1",
                Region.ApSouth2 => "ap-south-2",
                Region.ApEast1 => "ap-east-1",
                Region.SaEast1 => "sa-east-1",
                Region.AfSouth1 => "af-south-1",
                Region.MeSouth1 => "me-south-1",
                Region.MeCentral1 => "me-central-1",
                Region.IlCentral1 => "il-central-1",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(EventQueueProvisionParamsEventTypeConverter))]
public enum EventQueueProvisionParamsEventType
{
    MemberInvited,
    SyncSubscription,
    SyncCreditGrant,
    CustomerCreated,
    CustomerUpdated,
    CustomerDeleted,
    SyncCustomer,
    SubscriptionCreated,
    SubscriptionCanceled,
    SubscriptionExpired,
    SubscriptionUpdated,
    SubscriptionTrialStarted,
    SubscriptionTrialExpired,
    SubscriptionTrialConverted,
    SubscriptionTrialEndsSoon,
    SyncSubscriptionUsage,
    SubscriptionUsageUpdated,
    SubscriptionSpentLimitExceeded,
    CreateSubscriptionFailed,
    PlanCreated,
    PlanUpdated,
    PlanDeleted,
    AddonCreated,
    AddonUpdated,
    AddonDeleted,
    SyncPackage,
    FeatureCreated,
    FeatureUpdated,
    FeatureDeleted,
    FeatureArchived,
    ApiKeyCreated,
    ApiKeyUpdated,
    ApiKeyRotated,
    ApiKeyRevoked,
    EntitlementRequested,
    EntitlementGranted,
    EntitlementDenied,
    MeasurementReported,
    UsageThresholdExceeded,
    PromotionalEntitlementGranted,
    PromotionalEntitlementRevoked,
    PromotionalEntitlementUpdated,
    PromotionalEntitlementExpired,
    PromotionalEntitlementEndsSoon,
    PackagePublished,
    MigrateSubscriptions,
    RecalculateMigratedEntitlementsBatch,
    MigrateSubscriptionsScheduledUpdates,
    EntitlementsUpdated,
    ResyncIntegrationTriggered,
    CouponCreated,
    CouponUpdated,
    ImportIntegrationCatalogTriggered,
    ImportIntegrationCustomersTriggered,
    IncomingStripeWebhook,
    IncomingAwsMarketplaceWebhook,
    IncomingZuoraWebhook,
    IncomingDoggoWebhook,
    IncomingAppStoreWebhook,
    IncomingAirbyteWebhook,
    ResyncIntegration,
    SyncCoupon,
    ImportIntegrationCatalog,
    ImportIntegrationCustomers,
    SyncFailed,
    DataExportSyncFailed,
    CustomerPaymentFailed,
    ProductCreated,
    ProductUpdated,
    ProductDeleted,
    ProductUnarchived,
    PackageGroupCreated,
    PackageGroupUpdated,
    EnvironmentDeleted,
    WidgetConfigurationUpdated,
    EdgeApiDataResync,
    EdgeApiDoggoResync,
    EdgeApiClientConfigurationDataResync,
    PurgeCustomerPersistentCacheRequested,
    CustomerResourceEntitlementCalculationTriggered,
    RecalculateResourceEntitlements,
    CustomerEntitlementCalculationTriggered,
    RecalculateEntitlementsTriggered,
    ImportSubscriptionsBulkTriggered,
    EdgeApiCustomerDataResync,
    EdgeApiSubscriptionsDataResync,
    EdgeApiPackageEntitlementsDataResync,
    EdgeApiProductCacheDataResync,
    EdgeApiPlanCacheDataResync,
    EdgeApiCustomCurrencyCacheDataResync,
    ReplayWebhookEvent,
    SubscriptionsMigrated,
    SubscriptionsMigrationTriggered,
    SubscriptionBillingMonthEndsSoon,
    SubscriptionUsageChargeTriggered,
    SchedulerBatch,
    EventLogCreated,
    CreditGrantCreated,
    CreditGrantExpired,
    CreditGrantVoided,
    CreditGrantUpdated,
    CreditGrantDepleted,
    CreditGrantBalanceLow,
    CreditBalanceUpdated,
    CreditBalanceDepleted,
    CreditBalanceLow,
    CreditGrantProcessCompleted,
    AutomaticRechargeThresholdBreach,
    AutomaticRechargeOperationAttempted,
    CreditsAutomaticRechargeLimitExceeded,
    AutomaticRechargeConfigurationChanged,
    FeatureGroupCreated,
    FeatureGroupUpdated,
    FeatureGroupArchived,
    FeatureGroupUnArchived,
    CustomCurrencyCreated,
    CustomCurrencyUpdated,
    CustomCurrencyArchived,
    CustomCurrencyUnarchived,
    StripeAppDrawerViewed,
    EventQueueProvisioningRequested,
    EventQueueDeprovisioningRequested,
}

sealed class EventQueueProvisionParamsEventTypeConverter
    : JsonConverter<EventQueueProvisionParamsEventType>
{
    public override EventQueueProvisionParamsEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MEMBER_INVITED" => EventQueueProvisionParamsEventType.MemberInvited,
            "SYNC_SUBSCRIPTION" => EventQueueProvisionParamsEventType.SyncSubscription,
            "SYNC_CREDIT_GRANT" => EventQueueProvisionParamsEventType.SyncCreditGrant,
            "CUSTOMER_CREATED" => EventQueueProvisionParamsEventType.CustomerCreated,
            "CUSTOMER_UPDATED" => EventQueueProvisionParamsEventType.CustomerUpdated,
            "CUSTOMER_DELETED" => EventQueueProvisionParamsEventType.CustomerDeleted,
            "SYNC_CUSTOMER" => EventQueueProvisionParamsEventType.SyncCustomer,
            "SUBSCRIPTION_CREATED" => EventQueueProvisionParamsEventType.SubscriptionCreated,
            "SUBSCRIPTION_CANCELED" => EventQueueProvisionParamsEventType.SubscriptionCanceled,
            "SUBSCRIPTION_EXPIRED" => EventQueueProvisionParamsEventType.SubscriptionExpired,
            "SUBSCRIPTION_UPDATED" => EventQueueProvisionParamsEventType.SubscriptionUpdated,
            "SUBSCRIPTION_TRIAL_STARTED" =>
                EventQueueProvisionParamsEventType.SubscriptionTrialStarted,
            "SUBSCRIPTION_TRIAL_EXPIRED" =>
                EventQueueProvisionParamsEventType.SubscriptionTrialExpired,
            "SUBSCRIPTION_TRIAL_CONVERTED" =>
                EventQueueProvisionParamsEventType.SubscriptionTrialConverted,
            "SUBSCRIPTION_TRIAL_ENDS_SOON" =>
                EventQueueProvisionParamsEventType.SubscriptionTrialEndsSoon,
            "SYNC_SUBSCRIPTION_USAGE" => EventQueueProvisionParamsEventType.SyncSubscriptionUsage,
            "SUBSCRIPTION_USAGE_UPDATED" =>
                EventQueueProvisionParamsEventType.SubscriptionUsageUpdated,
            "SUBSCRIPTION_SPENT_LIMIT_EXCEEDED" =>
                EventQueueProvisionParamsEventType.SubscriptionSpentLimitExceeded,
            "CREATE_SUBSCRIPTION_FAILED" =>
                EventQueueProvisionParamsEventType.CreateSubscriptionFailed,
            "PLAN_CREATED" => EventQueueProvisionParamsEventType.PlanCreated,
            "PLAN_UPDATED" => EventQueueProvisionParamsEventType.PlanUpdated,
            "PLAN_DELETED" => EventQueueProvisionParamsEventType.PlanDeleted,
            "ADDON_CREATED" => EventQueueProvisionParamsEventType.AddonCreated,
            "ADDON_UPDATED" => EventQueueProvisionParamsEventType.AddonUpdated,
            "ADDON_DELETED" => EventQueueProvisionParamsEventType.AddonDeleted,
            "SYNC_PACKAGE" => EventQueueProvisionParamsEventType.SyncPackage,
            "FEATURE_CREATED" => EventQueueProvisionParamsEventType.FeatureCreated,
            "FEATURE_UPDATED" => EventQueueProvisionParamsEventType.FeatureUpdated,
            "FEATURE_DELETED" => EventQueueProvisionParamsEventType.FeatureDeleted,
            "FEATURE_ARCHIVED" => EventQueueProvisionParamsEventType.FeatureArchived,
            "API_KEY_CREATED" => EventQueueProvisionParamsEventType.ApiKeyCreated,
            "API_KEY_UPDATED" => EventQueueProvisionParamsEventType.ApiKeyUpdated,
            "API_KEY_ROTATED" => EventQueueProvisionParamsEventType.ApiKeyRotated,
            "API_KEY_REVOKED" => EventQueueProvisionParamsEventType.ApiKeyRevoked,
            "ENTITLEMENT_REQUESTED" => EventQueueProvisionParamsEventType.EntitlementRequested,
            "ENTITLEMENT_GRANTED" => EventQueueProvisionParamsEventType.EntitlementGranted,
            "ENTITLEMENT_DENIED" => EventQueueProvisionParamsEventType.EntitlementDenied,
            "MEASUREMENT_REPORTED" => EventQueueProvisionParamsEventType.MeasurementReported,
            "USAGE_THRESHOLD_EXCEEDED" => EventQueueProvisionParamsEventType.UsageThresholdExceeded,
            "PROMOTIONAL_ENTITLEMENT_GRANTED" =>
                EventQueueProvisionParamsEventType.PromotionalEntitlementGranted,
            "PROMOTIONAL_ENTITLEMENT_REVOKED" =>
                EventQueueProvisionParamsEventType.PromotionalEntitlementRevoked,
            "PROMOTIONAL_ENTITLEMENT_UPDATED" =>
                EventQueueProvisionParamsEventType.PromotionalEntitlementUpdated,
            "PROMOTIONAL_ENTITLEMENT_EXPIRED" =>
                EventQueueProvisionParamsEventType.PromotionalEntitlementExpired,
            "PROMOTIONAL_ENTITLEMENT_ENDS_SOON" =>
                EventQueueProvisionParamsEventType.PromotionalEntitlementEndsSoon,
            "PACKAGE_PUBLISHED" => EventQueueProvisionParamsEventType.PackagePublished,
            "MIGRATE_SUBSCRIPTIONS" => EventQueueProvisionParamsEventType.MigrateSubscriptions,
            "RECALCULATE_MIGRATED_ENTITLEMENTS_BATCH" =>
                EventQueueProvisionParamsEventType.RecalculateMigratedEntitlementsBatch,
            "MIGRATE_SUBSCRIPTIONS_SCHEDULED_UPDATES" =>
                EventQueueProvisionParamsEventType.MigrateSubscriptionsScheduledUpdates,
            "ENTITLEMENTS_UPDATED" => EventQueueProvisionParamsEventType.EntitlementsUpdated,
            "RESYNC_INTEGRATION_TRIGGERED" =>
                EventQueueProvisionParamsEventType.ResyncIntegrationTriggered,
            "COUPON_CREATED" => EventQueueProvisionParamsEventType.CouponCreated,
            "COUPON_UPDATED" => EventQueueProvisionParamsEventType.CouponUpdated,
            "IMPORT_INTEGRATION_CATALOG_TRIGGERED" =>
                EventQueueProvisionParamsEventType.ImportIntegrationCatalogTriggered,
            "IMPORT_INTEGRATION_CUSTOMERS_TRIGGERED" =>
                EventQueueProvisionParamsEventType.ImportIntegrationCustomersTriggered,
            "INCOMING_STRIPE_WEBHOOK" => EventQueueProvisionParamsEventType.IncomingStripeWebhook,
            "INCOMING_AWS_MARKETPLACE_WEBHOOK" =>
                EventQueueProvisionParamsEventType.IncomingAwsMarketplaceWebhook,
            "INCOMING_ZUORA_WEBHOOK" => EventQueueProvisionParamsEventType.IncomingZuoraWebhook,
            "INCOMING_DOGGO_WEBHOOK" => EventQueueProvisionParamsEventType.IncomingDoggoWebhook,
            "INCOMING_APP_STORE_WEBHOOK" =>
                EventQueueProvisionParamsEventType.IncomingAppStoreWebhook,
            "INCOMING_AIRBYTE_WEBHOOK" => EventQueueProvisionParamsEventType.IncomingAirbyteWebhook,
            "RESYNC_INTEGRATION" => EventQueueProvisionParamsEventType.ResyncIntegration,
            "SYNC_COUPON" => EventQueueProvisionParamsEventType.SyncCoupon,
            "IMPORT_INTEGRATION_CATALOG" =>
                EventQueueProvisionParamsEventType.ImportIntegrationCatalog,
            "IMPORT_INTEGRATION_CUSTOMERS" =>
                EventQueueProvisionParamsEventType.ImportIntegrationCustomers,
            "SYNC_FAILED" => EventQueueProvisionParamsEventType.SyncFailed,
            "DATA_EXPORT_SYNC_FAILED" => EventQueueProvisionParamsEventType.DataExportSyncFailed,
            "CUSTOMER_PAYMENT_FAILED" => EventQueueProvisionParamsEventType.CustomerPaymentFailed,
            "PRODUCT_CREATED" => EventQueueProvisionParamsEventType.ProductCreated,
            "PRODUCT_UPDATED" => EventQueueProvisionParamsEventType.ProductUpdated,
            "PRODUCT_DELETED" => EventQueueProvisionParamsEventType.ProductDeleted,
            "PRODUCT_UNARCHIVED" => EventQueueProvisionParamsEventType.ProductUnarchived,
            "PACKAGE_GROUP_CREATED" => EventQueueProvisionParamsEventType.PackageGroupCreated,
            "PACKAGE_GROUP_UPDATED" => EventQueueProvisionParamsEventType.PackageGroupUpdated,
            "ENVIRONMENT_DELETED" => EventQueueProvisionParamsEventType.EnvironmentDeleted,
            "WIDGET_CONFIGURATION_UPDATED" =>
                EventQueueProvisionParamsEventType.WidgetConfigurationUpdated,
            "EDGE_API_DATA_RESYNC" => EventQueueProvisionParamsEventType.EdgeApiDataResync,
            "EDGE_API_DOGGO_RESYNC" => EventQueueProvisionParamsEventType.EdgeApiDoggoResync,
            "EDGE_API_CLIENT_CONFIGURATION_DATA_RESYNC" =>
                EventQueueProvisionParamsEventType.EdgeApiClientConfigurationDataResync,
            "PURGE_CUSTOMER_PERSISTENT_CACHE_REQUESTED" =>
                EventQueueProvisionParamsEventType.PurgeCustomerPersistentCacheRequested,
            "CUSTOMER_RESOURCE_ENTITLEMENT_CALCULATION_TRIGGERED" =>
                EventQueueProvisionParamsEventType.CustomerResourceEntitlementCalculationTriggered,
            "RECALCULATE_RESOURCE_ENTITLEMENTS" =>
                EventQueueProvisionParamsEventType.RecalculateResourceEntitlements,
            "CUSTOMER_ENTITLEMENT_CALCULATION_TRIGGERED[" =>
                EventQueueProvisionParamsEventType.CustomerEntitlementCalculationTriggered,
            "RECALCULATE_ENTITLEMENTS_TRIGGERED" =>
                EventQueueProvisionParamsEventType.RecalculateEntitlementsTriggered,
            "IMPORT_SUBSCRIPTIONS_BULK_TRIGGERED" =>
                EventQueueProvisionParamsEventType.ImportSubscriptionsBulkTriggered,
            "EDGE_API_CUSTOMER_DATA_RESYNC" =>
                EventQueueProvisionParamsEventType.EdgeApiCustomerDataResync,
            "EDGE_API_SUBSCRIPTIONS_DATA_RESYNC" =>
                EventQueueProvisionParamsEventType.EdgeApiSubscriptionsDataResync,
            "EDGE_API_PACKAGE_ENTITLEMENTS_DATA_RESYNC" =>
                EventQueueProvisionParamsEventType.EdgeApiPackageEntitlementsDataResync,
            "EDGE_API_PRODUCT_CACHE_DATA_RESYNC" =>
                EventQueueProvisionParamsEventType.EdgeApiProductCacheDataResync,
            "EDGE_API_PLAN_CACHE_DATA_RESYNC" =>
                EventQueueProvisionParamsEventType.EdgeApiPlanCacheDataResync,
            "EDGE_API_CUSTOM_CURRENCY_CACHE_DATA_RESYNC" =>
                EventQueueProvisionParamsEventType.EdgeApiCustomCurrencyCacheDataResync,
            "REPLAY_WEBHOOK_EVENT" => EventQueueProvisionParamsEventType.ReplayWebhookEvent,
            "SUBSCRIPTIONS_MIGRATED" => EventQueueProvisionParamsEventType.SubscriptionsMigrated,
            "SUBSCRIPTIONS_MIGRATION_TRIGGERED" =>
                EventQueueProvisionParamsEventType.SubscriptionsMigrationTriggered,
            "SUBSCRIPTION_BILLING_MONTH_ENDS_SOON" =>
                EventQueueProvisionParamsEventType.SubscriptionBillingMonthEndsSoon,
            "SUBSCRIPTION_USAGE_CHARGE_TRIGGERED" =>
                EventQueueProvisionParamsEventType.SubscriptionUsageChargeTriggered,
            "SCHEDULER_BATCH" => EventQueueProvisionParamsEventType.SchedulerBatch,
            "EVENT_LOG_CREATED" => EventQueueProvisionParamsEventType.EventLogCreated,
            "CREDIT_GRANT_CREATED" => EventQueueProvisionParamsEventType.CreditGrantCreated,
            "CREDIT_GRANT_EXPIRED" => EventQueueProvisionParamsEventType.CreditGrantExpired,
            "CREDIT_GRANT_VOIDED" => EventQueueProvisionParamsEventType.CreditGrantVoided,
            "CREDIT_GRANT_UPDATED" => EventQueueProvisionParamsEventType.CreditGrantUpdated,
            "CREDIT_GRANT_DEPLETED" => EventQueueProvisionParamsEventType.CreditGrantDepleted,
            "CREDIT_GRANT_BALANCE_LOW" => EventQueueProvisionParamsEventType.CreditGrantBalanceLow,
            "CREDIT_BALANCE_UPDATED" => EventQueueProvisionParamsEventType.CreditBalanceUpdated,
            "CREDIT_BALANCE_DEPLETED" => EventQueueProvisionParamsEventType.CreditBalanceDepleted,
            "CREDIT_BALANCE_LOW" => EventQueueProvisionParamsEventType.CreditBalanceLow,
            "CREDIT_GRANT_PROCESS_COMPLETED" =>
                EventQueueProvisionParamsEventType.CreditGrantProcessCompleted,
            "AUTOMATIC_RECHARGE_THRESHOLD_BREACH" =>
                EventQueueProvisionParamsEventType.AutomaticRechargeThresholdBreach,
            "AUTOMATIC_RECHARGE_OPERATION_ATTEMPTED" =>
                EventQueueProvisionParamsEventType.AutomaticRechargeOperationAttempted,
            "CREDITS_AUTOMATIC_RECHARGE_LIMIT_EXCEEDED" =>
                EventQueueProvisionParamsEventType.CreditsAutomaticRechargeLimitExceeded,
            "AUTOMATIC_RECHARGE_CONFIGURATION_CHANGED" =>
                EventQueueProvisionParamsEventType.AutomaticRechargeConfigurationChanged,
            "FEATURE_GROUP_CREATED" => EventQueueProvisionParamsEventType.FeatureGroupCreated,
            "FEATURE_GROUP_UPDATED" => EventQueueProvisionParamsEventType.FeatureGroupUpdated,
            "FEATURE_GROUP_ARCHIVED" => EventQueueProvisionParamsEventType.FeatureGroupArchived,
            "FEATURE_GROUP_UN_ARCHIVED" =>
                EventQueueProvisionParamsEventType.FeatureGroupUnArchived,
            "CUSTOM_CURRENCY_CREATED" => EventQueueProvisionParamsEventType.CustomCurrencyCreated,
            "CUSTOM_CURRENCY_UPDATED" => EventQueueProvisionParamsEventType.CustomCurrencyUpdated,
            "CUSTOM_CURRENCY_ARCHIVED" => EventQueueProvisionParamsEventType.CustomCurrencyArchived,
            "CUSTOM_CURRENCY_UNARCHIVED" =>
                EventQueueProvisionParamsEventType.CustomCurrencyUnarchived,
            "STRIPE_APP_DRAWER_VIEWED" => EventQueueProvisionParamsEventType.StripeAppDrawerViewed,
            "EVENT_QUEUE_PROVISIONING_REQUESTED" =>
                EventQueueProvisionParamsEventType.EventQueueProvisioningRequested,
            "EVENT_QUEUE_DEPROVISIONING_REQUESTED" =>
                EventQueueProvisionParamsEventType.EventQueueDeprovisioningRequested,
            _ => (EventQueueProvisionParamsEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventQueueProvisionParamsEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventQueueProvisionParamsEventType.MemberInvited => "MEMBER_INVITED",
                EventQueueProvisionParamsEventType.SyncSubscription => "SYNC_SUBSCRIPTION",
                EventQueueProvisionParamsEventType.SyncCreditGrant => "SYNC_CREDIT_GRANT",
                EventQueueProvisionParamsEventType.CustomerCreated => "CUSTOMER_CREATED",
                EventQueueProvisionParamsEventType.CustomerUpdated => "CUSTOMER_UPDATED",
                EventQueueProvisionParamsEventType.CustomerDeleted => "CUSTOMER_DELETED",
                EventQueueProvisionParamsEventType.SyncCustomer => "SYNC_CUSTOMER",
                EventQueueProvisionParamsEventType.SubscriptionCreated => "SUBSCRIPTION_CREATED",
                EventQueueProvisionParamsEventType.SubscriptionCanceled => "SUBSCRIPTION_CANCELED",
                EventQueueProvisionParamsEventType.SubscriptionExpired => "SUBSCRIPTION_EXPIRED",
                EventQueueProvisionParamsEventType.SubscriptionUpdated => "SUBSCRIPTION_UPDATED",
                EventQueueProvisionParamsEventType.SubscriptionTrialStarted =>
                    "SUBSCRIPTION_TRIAL_STARTED",
                EventQueueProvisionParamsEventType.SubscriptionTrialExpired =>
                    "SUBSCRIPTION_TRIAL_EXPIRED",
                EventQueueProvisionParamsEventType.SubscriptionTrialConverted =>
                    "SUBSCRIPTION_TRIAL_CONVERTED",
                EventQueueProvisionParamsEventType.SubscriptionTrialEndsSoon =>
                    "SUBSCRIPTION_TRIAL_ENDS_SOON",
                EventQueueProvisionParamsEventType.SyncSubscriptionUsage =>
                    "SYNC_SUBSCRIPTION_USAGE",
                EventQueueProvisionParamsEventType.SubscriptionUsageUpdated =>
                    "SUBSCRIPTION_USAGE_UPDATED",
                EventQueueProvisionParamsEventType.SubscriptionSpentLimitExceeded =>
                    "SUBSCRIPTION_SPENT_LIMIT_EXCEEDED",
                EventQueueProvisionParamsEventType.CreateSubscriptionFailed =>
                    "CREATE_SUBSCRIPTION_FAILED",
                EventQueueProvisionParamsEventType.PlanCreated => "PLAN_CREATED",
                EventQueueProvisionParamsEventType.PlanUpdated => "PLAN_UPDATED",
                EventQueueProvisionParamsEventType.PlanDeleted => "PLAN_DELETED",
                EventQueueProvisionParamsEventType.AddonCreated => "ADDON_CREATED",
                EventQueueProvisionParamsEventType.AddonUpdated => "ADDON_UPDATED",
                EventQueueProvisionParamsEventType.AddonDeleted => "ADDON_DELETED",
                EventQueueProvisionParamsEventType.SyncPackage => "SYNC_PACKAGE",
                EventQueueProvisionParamsEventType.FeatureCreated => "FEATURE_CREATED",
                EventQueueProvisionParamsEventType.FeatureUpdated => "FEATURE_UPDATED",
                EventQueueProvisionParamsEventType.FeatureDeleted => "FEATURE_DELETED",
                EventQueueProvisionParamsEventType.FeatureArchived => "FEATURE_ARCHIVED",
                EventQueueProvisionParamsEventType.ApiKeyCreated => "API_KEY_CREATED",
                EventQueueProvisionParamsEventType.ApiKeyUpdated => "API_KEY_UPDATED",
                EventQueueProvisionParamsEventType.ApiKeyRotated => "API_KEY_ROTATED",
                EventQueueProvisionParamsEventType.ApiKeyRevoked => "API_KEY_REVOKED",
                EventQueueProvisionParamsEventType.EntitlementRequested => "ENTITLEMENT_REQUESTED",
                EventQueueProvisionParamsEventType.EntitlementGranted => "ENTITLEMENT_GRANTED",
                EventQueueProvisionParamsEventType.EntitlementDenied => "ENTITLEMENT_DENIED",
                EventQueueProvisionParamsEventType.MeasurementReported => "MEASUREMENT_REPORTED",
                EventQueueProvisionParamsEventType.UsageThresholdExceeded =>
                    "USAGE_THRESHOLD_EXCEEDED",
                EventQueueProvisionParamsEventType.PromotionalEntitlementGranted =>
                    "PROMOTIONAL_ENTITLEMENT_GRANTED",
                EventQueueProvisionParamsEventType.PromotionalEntitlementRevoked =>
                    "PROMOTIONAL_ENTITLEMENT_REVOKED",
                EventQueueProvisionParamsEventType.PromotionalEntitlementUpdated =>
                    "PROMOTIONAL_ENTITLEMENT_UPDATED",
                EventQueueProvisionParamsEventType.PromotionalEntitlementExpired =>
                    "PROMOTIONAL_ENTITLEMENT_EXPIRED",
                EventQueueProvisionParamsEventType.PromotionalEntitlementEndsSoon =>
                    "PROMOTIONAL_ENTITLEMENT_ENDS_SOON",
                EventQueueProvisionParamsEventType.PackagePublished => "PACKAGE_PUBLISHED",
                EventQueueProvisionParamsEventType.MigrateSubscriptions => "MIGRATE_SUBSCRIPTIONS",
                EventQueueProvisionParamsEventType.RecalculateMigratedEntitlementsBatch =>
                    "RECALCULATE_MIGRATED_ENTITLEMENTS_BATCH",
                EventQueueProvisionParamsEventType.MigrateSubscriptionsScheduledUpdates =>
                    "MIGRATE_SUBSCRIPTIONS_SCHEDULED_UPDATES",
                EventQueueProvisionParamsEventType.EntitlementsUpdated => "ENTITLEMENTS_UPDATED",
                EventQueueProvisionParamsEventType.ResyncIntegrationTriggered =>
                    "RESYNC_INTEGRATION_TRIGGERED",
                EventQueueProvisionParamsEventType.CouponCreated => "COUPON_CREATED",
                EventQueueProvisionParamsEventType.CouponUpdated => "COUPON_UPDATED",
                EventQueueProvisionParamsEventType.ImportIntegrationCatalogTriggered =>
                    "IMPORT_INTEGRATION_CATALOG_TRIGGERED",
                EventQueueProvisionParamsEventType.ImportIntegrationCustomersTriggered =>
                    "IMPORT_INTEGRATION_CUSTOMERS_TRIGGERED",
                EventQueueProvisionParamsEventType.IncomingStripeWebhook =>
                    "INCOMING_STRIPE_WEBHOOK",
                EventQueueProvisionParamsEventType.IncomingAwsMarketplaceWebhook =>
                    "INCOMING_AWS_MARKETPLACE_WEBHOOK",
                EventQueueProvisionParamsEventType.IncomingZuoraWebhook => "INCOMING_ZUORA_WEBHOOK",
                EventQueueProvisionParamsEventType.IncomingDoggoWebhook => "INCOMING_DOGGO_WEBHOOK",
                EventQueueProvisionParamsEventType.IncomingAppStoreWebhook =>
                    "INCOMING_APP_STORE_WEBHOOK",
                EventQueueProvisionParamsEventType.IncomingAirbyteWebhook =>
                    "INCOMING_AIRBYTE_WEBHOOK",
                EventQueueProvisionParamsEventType.ResyncIntegration => "RESYNC_INTEGRATION",
                EventQueueProvisionParamsEventType.SyncCoupon => "SYNC_COUPON",
                EventQueueProvisionParamsEventType.ImportIntegrationCatalog =>
                    "IMPORT_INTEGRATION_CATALOG",
                EventQueueProvisionParamsEventType.ImportIntegrationCustomers =>
                    "IMPORT_INTEGRATION_CUSTOMERS",
                EventQueueProvisionParamsEventType.SyncFailed => "SYNC_FAILED",
                EventQueueProvisionParamsEventType.DataExportSyncFailed =>
                    "DATA_EXPORT_SYNC_FAILED",
                EventQueueProvisionParamsEventType.CustomerPaymentFailed =>
                    "CUSTOMER_PAYMENT_FAILED",
                EventQueueProvisionParamsEventType.ProductCreated => "PRODUCT_CREATED",
                EventQueueProvisionParamsEventType.ProductUpdated => "PRODUCT_UPDATED",
                EventQueueProvisionParamsEventType.ProductDeleted => "PRODUCT_DELETED",
                EventQueueProvisionParamsEventType.ProductUnarchived => "PRODUCT_UNARCHIVED",
                EventQueueProvisionParamsEventType.PackageGroupCreated => "PACKAGE_GROUP_CREATED",
                EventQueueProvisionParamsEventType.PackageGroupUpdated => "PACKAGE_GROUP_UPDATED",
                EventQueueProvisionParamsEventType.EnvironmentDeleted => "ENVIRONMENT_DELETED",
                EventQueueProvisionParamsEventType.WidgetConfigurationUpdated =>
                    "WIDGET_CONFIGURATION_UPDATED",
                EventQueueProvisionParamsEventType.EdgeApiDataResync => "EDGE_API_DATA_RESYNC",
                EventQueueProvisionParamsEventType.EdgeApiDoggoResync => "EDGE_API_DOGGO_RESYNC",
                EventQueueProvisionParamsEventType.EdgeApiClientConfigurationDataResync =>
                    "EDGE_API_CLIENT_CONFIGURATION_DATA_RESYNC",
                EventQueueProvisionParamsEventType.PurgeCustomerPersistentCacheRequested =>
                    "PURGE_CUSTOMER_PERSISTENT_CACHE_REQUESTED",
                EventQueueProvisionParamsEventType.CustomerResourceEntitlementCalculationTriggered =>
                    "CUSTOMER_RESOURCE_ENTITLEMENT_CALCULATION_TRIGGERED",
                EventQueueProvisionParamsEventType.RecalculateResourceEntitlements =>
                    "RECALCULATE_RESOURCE_ENTITLEMENTS",
                EventQueueProvisionParamsEventType.CustomerEntitlementCalculationTriggered =>
                    "CUSTOMER_ENTITLEMENT_CALCULATION_TRIGGERED[",
                EventQueueProvisionParamsEventType.RecalculateEntitlementsTriggered =>
                    "RECALCULATE_ENTITLEMENTS_TRIGGERED",
                EventQueueProvisionParamsEventType.ImportSubscriptionsBulkTriggered =>
                    "IMPORT_SUBSCRIPTIONS_BULK_TRIGGERED",
                EventQueueProvisionParamsEventType.EdgeApiCustomerDataResync =>
                    "EDGE_API_CUSTOMER_DATA_RESYNC",
                EventQueueProvisionParamsEventType.EdgeApiSubscriptionsDataResync =>
                    "EDGE_API_SUBSCRIPTIONS_DATA_RESYNC",
                EventQueueProvisionParamsEventType.EdgeApiPackageEntitlementsDataResync =>
                    "EDGE_API_PACKAGE_ENTITLEMENTS_DATA_RESYNC",
                EventQueueProvisionParamsEventType.EdgeApiProductCacheDataResync =>
                    "EDGE_API_PRODUCT_CACHE_DATA_RESYNC",
                EventQueueProvisionParamsEventType.EdgeApiPlanCacheDataResync =>
                    "EDGE_API_PLAN_CACHE_DATA_RESYNC",
                EventQueueProvisionParamsEventType.EdgeApiCustomCurrencyCacheDataResync =>
                    "EDGE_API_CUSTOM_CURRENCY_CACHE_DATA_RESYNC",
                EventQueueProvisionParamsEventType.ReplayWebhookEvent => "REPLAY_WEBHOOK_EVENT",
                EventQueueProvisionParamsEventType.SubscriptionsMigrated =>
                    "SUBSCRIPTIONS_MIGRATED",
                EventQueueProvisionParamsEventType.SubscriptionsMigrationTriggered =>
                    "SUBSCRIPTIONS_MIGRATION_TRIGGERED",
                EventQueueProvisionParamsEventType.SubscriptionBillingMonthEndsSoon =>
                    "SUBSCRIPTION_BILLING_MONTH_ENDS_SOON",
                EventQueueProvisionParamsEventType.SubscriptionUsageChargeTriggered =>
                    "SUBSCRIPTION_USAGE_CHARGE_TRIGGERED",
                EventQueueProvisionParamsEventType.SchedulerBatch => "SCHEDULER_BATCH",
                EventQueueProvisionParamsEventType.EventLogCreated => "EVENT_LOG_CREATED",
                EventQueueProvisionParamsEventType.CreditGrantCreated => "CREDIT_GRANT_CREATED",
                EventQueueProvisionParamsEventType.CreditGrantExpired => "CREDIT_GRANT_EXPIRED",
                EventQueueProvisionParamsEventType.CreditGrantVoided => "CREDIT_GRANT_VOIDED",
                EventQueueProvisionParamsEventType.CreditGrantUpdated => "CREDIT_GRANT_UPDATED",
                EventQueueProvisionParamsEventType.CreditGrantDepleted => "CREDIT_GRANT_DEPLETED",
                EventQueueProvisionParamsEventType.CreditGrantBalanceLow =>
                    "CREDIT_GRANT_BALANCE_LOW",
                EventQueueProvisionParamsEventType.CreditBalanceUpdated => "CREDIT_BALANCE_UPDATED",
                EventQueueProvisionParamsEventType.CreditBalanceDepleted =>
                    "CREDIT_BALANCE_DEPLETED",
                EventQueueProvisionParamsEventType.CreditBalanceLow => "CREDIT_BALANCE_LOW",
                EventQueueProvisionParamsEventType.CreditGrantProcessCompleted =>
                    "CREDIT_GRANT_PROCESS_COMPLETED",
                EventQueueProvisionParamsEventType.AutomaticRechargeThresholdBreach =>
                    "AUTOMATIC_RECHARGE_THRESHOLD_BREACH",
                EventQueueProvisionParamsEventType.AutomaticRechargeOperationAttempted =>
                    "AUTOMATIC_RECHARGE_OPERATION_ATTEMPTED",
                EventQueueProvisionParamsEventType.CreditsAutomaticRechargeLimitExceeded =>
                    "CREDITS_AUTOMATIC_RECHARGE_LIMIT_EXCEEDED",
                EventQueueProvisionParamsEventType.AutomaticRechargeConfigurationChanged =>
                    "AUTOMATIC_RECHARGE_CONFIGURATION_CHANGED",
                EventQueueProvisionParamsEventType.FeatureGroupCreated => "FEATURE_GROUP_CREATED",
                EventQueueProvisionParamsEventType.FeatureGroupUpdated => "FEATURE_GROUP_UPDATED",
                EventQueueProvisionParamsEventType.FeatureGroupArchived => "FEATURE_GROUP_ARCHIVED",
                EventQueueProvisionParamsEventType.FeatureGroupUnArchived =>
                    "FEATURE_GROUP_UN_ARCHIVED",
                EventQueueProvisionParamsEventType.CustomCurrencyCreated =>
                    "CUSTOM_CURRENCY_CREATED",
                EventQueueProvisionParamsEventType.CustomCurrencyUpdated =>
                    "CUSTOM_CURRENCY_UPDATED",
                EventQueueProvisionParamsEventType.CustomCurrencyArchived =>
                    "CUSTOM_CURRENCY_ARCHIVED",
                EventQueueProvisionParamsEventType.CustomCurrencyUnarchived =>
                    "CUSTOM_CURRENCY_UNARCHIVED",
                EventQueueProvisionParamsEventType.StripeAppDrawerViewed =>
                    "STRIPE_APP_DRAWER_VIEWED",
                EventQueueProvisionParamsEventType.EventQueueProvisioningRequested =>
                    "EVENT_QUEUE_PROVISIONING_REQUESTED",
                EventQueueProvisionParamsEventType.EventQueueDeprovisioningRequested =>
                    "EVENT_QUEUE_DEPROVISIONING_REQUESTED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
