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
/// Update event queue configuration
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EventQueueUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? QueueName { get; init; }

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

    public IReadOnlyList<ApiEnum<string, EventType>>? EventTypes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, EventType>>>(
                "eventTypes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, EventType>>?>(
                "eventTypes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public EventQueueUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EventQueueUpdateParams(EventQueueUpdateParams eventQueueUpdateParams)
        : base(eventQueueUpdateParams)
    {
        this.QueueName = eventQueueUpdateParams.QueueName;

        this._rawBodyData = new(eventQueueUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EventQueueUpdateParams(
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
    EventQueueUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string queueName
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.QueueName = queueName;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EventQueueUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string queueName
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            queueName
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["QueueName"] = JsonSerializer.SerializeToElement(this.QueueName),
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

    public virtual bool Equals(EventQueueUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.QueueName?.Equals(other.QueueName) ?? other.QueueName == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/internal/beta/event-queues/{0}", this.QueueName)
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

[JsonConverter(typeof(EventTypeConverter))]
public enum EventType
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
    ResyncIntegration,
    SyncCoupon,
    ImportIntegrationCatalog,
    ImportIntegrationCustomers,
    SyncFailed,
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

sealed class EventTypeConverter : JsonConverter<EventType>
{
    public override EventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MEMBER_INVITED" => EventType.MemberInvited,
            "SYNC_SUBSCRIPTION" => EventType.SyncSubscription,
            "SYNC_CREDIT_GRANT" => EventType.SyncCreditGrant,
            "CUSTOMER_CREATED" => EventType.CustomerCreated,
            "CUSTOMER_UPDATED" => EventType.CustomerUpdated,
            "CUSTOMER_DELETED" => EventType.CustomerDeleted,
            "SYNC_CUSTOMER" => EventType.SyncCustomer,
            "SUBSCRIPTION_CREATED" => EventType.SubscriptionCreated,
            "SUBSCRIPTION_CANCELED" => EventType.SubscriptionCanceled,
            "SUBSCRIPTION_EXPIRED" => EventType.SubscriptionExpired,
            "SUBSCRIPTION_UPDATED" => EventType.SubscriptionUpdated,
            "SUBSCRIPTION_TRIAL_STARTED" => EventType.SubscriptionTrialStarted,
            "SUBSCRIPTION_TRIAL_EXPIRED" => EventType.SubscriptionTrialExpired,
            "SUBSCRIPTION_TRIAL_CONVERTED" => EventType.SubscriptionTrialConverted,
            "SUBSCRIPTION_TRIAL_ENDS_SOON" => EventType.SubscriptionTrialEndsSoon,
            "SYNC_SUBSCRIPTION_USAGE" => EventType.SyncSubscriptionUsage,
            "SUBSCRIPTION_USAGE_UPDATED" => EventType.SubscriptionUsageUpdated,
            "SUBSCRIPTION_SPENT_LIMIT_EXCEEDED" => EventType.SubscriptionSpentLimitExceeded,
            "CREATE_SUBSCRIPTION_FAILED" => EventType.CreateSubscriptionFailed,
            "PLAN_CREATED" => EventType.PlanCreated,
            "PLAN_UPDATED" => EventType.PlanUpdated,
            "PLAN_DELETED" => EventType.PlanDeleted,
            "ADDON_CREATED" => EventType.AddonCreated,
            "ADDON_UPDATED" => EventType.AddonUpdated,
            "ADDON_DELETED" => EventType.AddonDeleted,
            "SYNC_PACKAGE" => EventType.SyncPackage,
            "FEATURE_CREATED" => EventType.FeatureCreated,
            "FEATURE_UPDATED" => EventType.FeatureUpdated,
            "FEATURE_DELETED" => EventType.FeatureDeleted,
            "FEATURE_ARCHIVED" => EventType.FeatureArchived,
            "API_KEY_CREATED" => EventType.ApiKeyCreated,
            "API_KEY_UPDATED" => EventType.ApiKeyUpdated,
            "API_KEY_ROTATED" => EventType.ApiKeyRotated,
            "API_KEY_REVOKED" => EventType.ApiKeyRevoked,
            "ENTITLEMENT_REQUESTED" => EventType.EntitlementRequested,
            "ENTITLEMENT_GRANTED" => EventType.EntitlementGranted,
            "ENTITLEMENT_DENIED" => EventType.EntitlementDenied,
            "MEASUREMENT_REPORTED" => EventType.MeasurementReported,
            "USAGE_THRESHOLD_EXCEEDED" => EventType.UsageThresholdExceeded,
            "PROMOTIONAL_ENTITLEMENT_GRANTED" => EventType.PromotionalEntitlementGranted,
            "PROMOTIONAL_ENTITLEMENT_REVOKED" => EventType.PromotionalEntitlementRevoked,
            "PROMOTIONAL_ENTITLEMENT_UPDATED" => EventType.PromotionalEntitlementUpdated,
            "PROMOTIONAL_ENTITLEMENT_EXPIRED" => EventType.PromotionalEntitlementExpired,
            "PROMOTIONAL_ENTITLEMENT_ENDS_SOON" => EventType.PromotionalEntitlementEndsSoon,
            "PACKAGE_PUBLISHED" => EventType.PackagePublished,
            "MIGRATE_SUBSCRIPTIONS" => EventType.MigrateSubscriptions,
            "RECALCULATE_MIGRATED_ENTITLEMENTS_BATCH" =>
                EventType.RecalculateMigratedEntitlementsBatch,
            "MIGRATE_SUBSCRIPTIONS_SCHEDULED_UPDATES" =>
                EventType.MigrateSubscriptionsScheduledUpdates,
            "ENTITLEMENTS_UPDATED" => EventType.EntitlementsUpdated,
            "RESYNC_INTEGRATION_TRIGGERED" => EventType.ResyncIntegrationTriggered,
            "COUPON_CREATED" => EventType.CouponCreated,
            "COUPON_UPDATED" => EventType.CouponUpdated,
            "IMPORT_INTEGRATION_CATALOG_TRIGGERED" => EventType.ImportIntegrationCatalogTriggered,
            "IMPORT_INTEGRATION_CUSTOMERS_TRIGGERED" =>
                EventType.ImportIntegrationCustomersTriggered,
            "INCOMING_STRIPE_WEBHOOK" => EventType.IncomingStripeWebhook,
            "INCOMING_AWS_MARKETPLACE_WEBHOOK" => EventType.IncomingAwsMarketplaceWebhook,
            "INCOMING_ZUORA_WEBHOOK" => EventType.IncomingZuoraWebhook,
            "INCOMING_DOGGO_WEBHOOK" => EventType.IncomingDoggoWebhook,
            "INCOMING_APP_STORE_WEBHOOK" => EventType.IncomingAppStoreWebhook,
            "RESYNC_INTEGRATION" => EventType.ResyncIntegration,
            "SYNC_COUPON" => EventType.SyncCoupon,
            "IMPORT_INTEGRATION_CATALOG" => EventType.ImportIntegrationCatalog,
            "IMPORT_INTEGRATION_CUSTOMERS" => EventType.ImportIntegrationCustomers,
            "SYNC_FAILED" => EventType.SyncFailed,
            "CUSTOMER_PAYMENT_FAILED" => EventType.CustomerPaymentFailed,
            "PRODUCT_CREATED" => EventType.ProductCreated,
            "PRODUCT_UPDATED" => EventType.ProductUpdated,
            "PRODUCT_DELETED" => EventType.ProductDeleted,
            "PRODUCT_UNARCHIVED" => EventType.ProductUnarchived,
            "PACKAGE_GROUP_CREATED" => EventType.PackageGroupCreated,
            "PACKAGE_GROUP_UPDATED" => EventType.PackageGroupUpdated,
            "ENVIRONMENT_DELETED" => EventType.EnvironmentDeleted,
            "WIDGET_CONFIGURATION_UPDATED" => EventType.WidgetConfigurationUpdated,
            "EDGE_API_DATA_RESYNC" => EventType.EdgeApiDataResync,
            "EDGE_API_DOGGO_RESYNC" => EventType.EdgeApiDoggoResync,
            "EDGE_API_CLIENT_CONFIGURATION_DATA_RESYNC" =>
                EventType.EdgeApiClientConfigurationDataResync,
            "PURGE_CUSTOMER_PERSISTENT_CACHE_REQUESTED" =>
                EventType.PurgeCustomerPersistentCacheRequested,
            "CUSTOMER_RESOURCE_ENTITLEMENT_CALCULATION_TRIGGERED" =>
                EventType.CustomerResourceEntitlementCalculationTriggered,
            "RECALCULATE_RESOURCE_ENTITLEMENTS" => EventType.RecalculateResourceEntitlements,
            "CUSTOMER_ENTITLEMENT_CALCULATION_TRIGGERED[" =>
                EventType.CustomerEntitlementCalculationTriggered,
            "RECALCULATE_ENTITLEMENTS_TRIGGERED" => EventType.RecalculateEntitlementsTriggered,
            "IMPORT_SUBSCRIPTIONS_BULK_TRIGGERED" => EventType.ImportSubscriptionsBulkTriggered,
            "EDGE_API_CUSTOMER_DATA_RESYNC" => EventType.EdgeApiCustomerDataResync,
            "EDGE_API_SUBSCRIPTIONS_DATA_RESYNC" => EventType.EdgeApiSubscriptionsDataResync,
            "EDGE_API_PACKAGE_ENTITLEMENTS_DATA_RESYNC" =>
                EventType.EdgeApiPackageEntitlementsDataResync,
            "EDGE_API_PRODUCT_CACHE_DATA_RESYNC" => EventType.EdgeApiProductCacheDataResync,
            "EDGE_API_PLAN_CACHE_DATA_RESYNC" => EventType.EdgeApiPlanCacheDataResync,
            "EDGE_API_CUSTOM_CURRENCY_CACHE_DATA_RESYNC" =>
                EventType.EdgeApiCustomCurrencyCacheDataResync,
            "REPLAY_WEBHOOK_EVENT" => EventType.ReplayWebhookEvent,
            "SUBSCRIPTIONS_MIGRATED" => EventType.SubscriptionsMigrated,
            "SUBSCRIPTIONS_MIGRATION_TRIGGERED" => EventType.SubscriptionsMigrationTriggered,
            "SUBSCRIPTION_BILLING_MONTH_ENDS_SOON" => EventType.SubscriptionBillingMonthEndsSoon,
            "SUBSCRIPTION_USAGE_CHARGE_TRIGGERED" => EventType.SubscriptionUsageChargeTriggered,
            "SCHEDULER_BATCH" => EventType.SchedulerBatch,
            "EVENT_LOG_CREATED" => EventType.EventLogCreated,
            "CREDIT_GRANT_CREATED" => EventType.CreditGrantCreated,
            "CREDIT_GRANT_EXPIRED" => EventType.CreditGrantExpired,
            "CREDIT_GRANT_VOIDED" => EventType.CreditGrantVoided,
            "CREDIT_GRANT_UPDATED" => EventType.CreditGrantUpdated,
            "CREDIT_GRANT_DEPLETED" => EventType.CreditGrantDepleted,
            "CREDIT_GRANT_BALANCE_LOW" => EventType.CreditGrantBalanceLow,
            "CREDIT_BALANCE_UPDATED" => EventType.CreditBalanceUpdated,
            "CREDIT_BALANCE_DEPLETED" => EventType.CreditBalanceDepleted,
            "CREDIT_BALANCE_LOW" => EventType.CreditBalanceLow,
            "CREDIT_GRANT_PROCESS_COMPLETED" => EventType.CreditGrantProcessCompleted,
            "AUTOMATIC_RECHARGE_THRESHOLD_BREACH" => EventType.AutomaticRechargeThresholdBreach,
            "AUTOMATIC_RECHARGE_OPERATION_ATTEMPTED" =>
                EventType.AutomaticRechargeOperationAttempted,
            "CREDITS_AUTOMATIC_RECHARGE_LIMIT_EXCEEDED" =>
                EventType.CreditsAutomaticRechargeLimitExceeded,
            "AUTOMATIC_RECHARGE_CONFIGURATION_CHANGED" =>
                EventType.AutomaticRechargeConfigurationChanged,
            "FEATURE_GROUP_CREATED" => EventType.FeatureGroupCreated,
            "FEATURE_GROUP_UPDATED" => EventType.FeatureGroupUpdated,
            "FEATURE_GROUP_ARCHIVED" => EventType.FeatureGroupArchived,
            "FEATURE_GROUP_UN_ARCHIVED" => EventType.FeatureGroupUnArchived,
            "CUSTOM_CURRENCY_CREATED" => EventType.CustomCurrencyCreated,
            "CUSTOM_CURRENCY_UPDATED" => EventType.CustomCurrencyUpdated,
            "CUSTOM_CURRENCY_ARCHIVED" => EventType.CustomCurrencyArchived,
            "CUSTOM_CURRENCY_UNARCHIVED" => EventType.CustomCurrencyUnarchived,
            "STRIPE_APP_DRAWER_VIEWED" => EventType.StripeAppDrawerViewed,
            "EVENT_QUEUE_PROVISIONING_REQUESTED" => EventType.EventQueueProvisioningRequested,
            "EVENT_QUEUE_DEPROVISIONING_REQUESTED" => EventType.EventQueueDeprovisioningRequested,
            _ => (EventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EventType.MemberInvited => "MEMBER_INVITED",
                EventType.SyncSubscription => "SYNC_SUBSCRIPTION",
                EventType.SyncCreditGrant => "SYNC_CREDIT_GRANT",
                EventType.CustomerCreated => "CUSTOMER_CREATED",
                EventType.CustomerUpdated => "CUSTOMER_UPDATED",
                EventType.CustomerDeleted => "CUSTOMER_DELETED",
                EventType.SyncCustomer => "SYNC_CUSTOMER",
                EventType.SubscriptionCreated => "SUBSCRIPTION_CREATED",
                EventType.SubscriptionCanceled => "SUBSCRIPTION_CANCELED",
                EventType.SubscriptionExpired => "SUBSCRIPTION_EXPIRED",
                EventType.SubscriptionUpdated => "SUBSCRIPTION_UPDATED",
                EventType.SubscriptionTrialStarted => "SUBSCRIPTION_TRIAL_STARTED",
                EventType.SubscriptionTrialExpired => "SUBSCRIPTION_TRIAL_EXPIRED",
                EventType.SubscriptionTrialConverted => "SUBSCRIPTION_TRIAL_CONVERTED",
                EventType.SubscriptionTrialEndsSoon => "SUBSCRIPTION_TRIAL_ENDS_SOON",
                EventType.SyncSubscriptionUsage => "SYNC_SUBSCRIPTION_USAGE",
                EventType.SubscriptionUsageUpdated => "SUBSCRIPTION_USAGE_UPDATED",
                EventType.SubscriptionSpentLimitExceeded => "SUBSCRIPTION_SPENT_LIMIT_EXCEEDED",
                EventType.CreateSubscriptionFailed => "CREATE_SUBSCRIPTION_FAILED",
                EventType.PlanCreated => "PLAN_CREATED",
                EventType.PlanUpdated => "PLAN_UPDATED",
                EventType.PlanDeleted => "PLAN_DELETED",
                EventType.AddonCreated => "ADDON_CREATED",
                EventType.AddonUpdated => "ADDON_UPDATED",
                EventType.AddonDeleted => "ADDON_DELETED",
                EventType.SyncPackage => "SYNC_PACKAGE",
                EventType.FeatureCreated => "FEATURE_CREATED",
                EventType.FeatureUpdated => "FEATURE_UPDATED",
                EventType.FeatureDeleted => "FEATURE_DELETED",
                EventType.FeatureArchived => "FEATURE_ARCHIVED",
                EventType.ApiKeyCreated => "API_KEY_CREATED",
                EventType.ApiKeyUpdated => "API_KEY_UPDATED",
                EventType.ApiKeyRotated => "API_KEY_ROTATED",
                EventType.ApiKeyRevoked => "API_KEY_REVOKED",
                EventType.EntitlementRequested => "ENTITLEMENT_REQUESTED",
                EventType.EntitlementGranted => "ENTITLEMENT_GRANTED",
                EventType.EntitlementDenied => "ENTITLEMENT_DENIED",
                EventType.MeasurementReported => "MEASUREMENT_REPORTED",
                EventType.UsageThresholdExceeded => "USAGE_THRESHOLD_EXCEEDED",
                EventType.PromotionalEntitlementGranted => "PROMOTIONAL_ENTITLEMENT_GRANTED",
                EventType.PromotionalEntitlementRevoked => "PROMOTIONAL_ENTITLEMENT_REVOKED",
                EventType.PromotionalEntitlementUpdated => "PROMOTIONAL_ENTITLEMENT_UPDATED",
                EventType.PromotionalEntitlementExpired => "PROMOTIONAL_ENTITLEMENT_EXPIRED",
                EventType.PromotionalEntitlementEndsSoon => "PROMOTIONAL_ENTITLEMENT_ENDS_SOON",
                EventType.PackagePublished => "PACKAGE_PUBLISHED",
                EventType.MigrateSubscriptions => "MIGRATE_SUBSCRIPTIONS",
                EventType.RecalculateMigratedEntitlementsBatch =>
                    "RECALCULATE_MIGRATED_ENTITLEMENTS_BATCH",
                EventType.MigrateSubscriptionsScheduledUpdates =>
                    "MIGRATE_SUBSCRIPTIONS_SCHEDULED_UPDATES",
                EventType.EntitlementsUpdated => "ENTITLEMENTS_UPDATED",
                EventType.ResyncIntegrationTriggered => "RESYNC_INTEGRATION_TRIGGERED",
                EventType.CouponCreated => "COUPON_CREATED",
                EventType.CouponUpdated => "COUPON_UPDATED",
                EventType.ImportIntegrationCatalogTriggered =>
                    "IMPORT_INTEGRATION_CATALOG_TRIGGERED",
                EventType.ImportIntegrationCustomersTriggered =>
                    "IMPORT_INTEGRATION_CUSTOMERS_TRIGGERED",
                EventType.IncomingStripeWebhook => "INCOMING_STRIPE_WEBHOOK",
                EventType.IncomingAwsMarketplaceWebhook => "INCOMING_AWS_MARKETPLACE_WEBHOOK",
                EventType.IncomingZuoraWebhook => "INCOMING_ZUORA_WEBHOOK",
                EventType.IncomingDoggoWebhook => "INCOMING_DOGGO_WEBHOOK",
                EventType.IncomingAppStoreWebhook => "INCOMING_APP_STORE_WEBHOOK",
                EventType.ResyncIntegration => "RESYNC_INTEGRATION",
                EventType.SyncCoupon => "SYNC_COUPON",
                EventType.ImportIntegrationCatalog => "IMPORT_INTEGRATION_CATALOG",
                EventType.ImportIntegrationCustomers => "IMPORT_INTEGRATION_CUSTOMERS",
                EventType.SyncFailed => "SYNC_FAILED",
                EventType.CustomerPaymentFailed => "CUSTOMER_PAYMENT_FAILED",
                EventType.ProductCreated => "PRODUCT_CREATED",
                EventType.ProductUpdated => "PRODUCT_UPDATED",
                EventType.ProductDeleted => "PRODUCT_DELETED",
                EventType.ProductUnarchived => "PRODUCT_UNARCHIVED",
                EventType.PackageGroupCreated => "PACKAGE_GROUP_CREATED",
                EventType.PackageGroupUpdated => "PACKAGE_GROUP_UPDATED",
                EventType.EnvironmentDeleted => "ENVIRONMENT_DELETED",
                EventType.WidgetConfigurationUpdated => "WIDGET_CONFIGURATION_UPDATED",
                EventType.EdgeApiDataResync => "EDGE_API_DATA_RESYNC",
                EventType.EdgeApiDoggoResync => "EDGE_API_DOGGO_RESYNC",
                EventType.EdgeApiClientConfigurationDataResync =>
                    "EDGE_API_CLIENT_CONFIGURATION_DATA_RESYNC",
                EventType.PurgeCustomerPersistentCacheRequested =>
                    "PURGE_CUSTOMER_PERSISTENT_CACHE_REQUESTED",
                EventType.CustomerResourceEntitlementCalculationTriggered =>
                    "CUSTOMER_RESOURCE_ENTITLEMENT_CALCULATION_TRIGGERED",
                EventType.RecalculateResourceEntitlements => "RECALCULATE_RESOURCE_ENTITLEMENTS",
                EventType.CustomerEntitlementCalculationTriggered =>
                    "CUSTOMER_ENTITLEMENT_CALCULATION_TRIGGERED[",
                EventType.RecalculateEntitlementsTriggered => "RECALCULATE_ENTITLEMENTS_TRIGGERED",
                EventType.ImportSubscriptionsBulkTriggered => "IMPORT_SUBSCRIPTIONS_BULK_TRIGGERED",
                EventType.EdgeApiCustomerDataResync => "EDGE_API_CUSTOMER_DATA_RESYNC",
                EventType.EdgeApiSubscriptionsDataResync => "EDGE_API_SUBSCRIPTIONS_DATA_RESYNC",
                EventType.EdgeApiPackageEntitlementsDataResync =>
                    "EDGE_API_PACKAGE_ENTITLEMENTS_DATA_RESYNC",
                EventType.EdgeApiProductCacheDataResync => "EDGE_API_PRODUCT_CACHE_DATA_RESYNC",
                EventType.EdgeApiPlanCacheDataResync => "EDGE_API_PLAN_CACHE_DATA_RESYNC",
                EventType.EdgeApiCustomCurrencyCacheDataResync =>
                    "EDGE_API_CUSTOM_CURRENCY_CACHE_DATA_RESYNC",
                EventType.ReplayWebhookEvent => "REPLAY_WEBHOOK_EVENT",
                EventType.SubscriptionsMigrated => "SUBSCRIPTIONS_MIGRATED",
                EventType.SubscriptionsMigrationTriggered => "SUBSCRIPTIONS_MIGRATION_TRIGGERED",
                EventType.SubscriptionBillingMonthEndsSoon =>
                    "SUBSCRIPTION_BILLING_MONTH_ENDS_SOON",
                EventType.SubscriptionUsageChargeTriggered => "SUBSCRIPTION_USAGE_CHARGE_TRIGGERED",
                EventType.SchedulerBatch => "SCHEDULER_BATCH",
                EventType.EventLogCreated => "EVENT_LOG_CREATED",
                EventType.CreditGrantCreated => "CREDIT_GRANT_CREATED",
                EventType.CreditGrantExpired => "CREDIT_GRANT_EXPIRED",
                EventType.CreditGrantVoided => "CREDIT_GRANT_VOIDED",
                EventType.CreditGrantUpdated => "CREDIT_GRANT_UPDATED",
                EventType.CreditGrantDepleted => "CREDIT_GRANT_DEPLETED",
                EventType.CreditGrantBalanceLow => "CREDIT_GRANT_BALANCE_LOW",
                EventType.CreditBalanceUpdated => "CREDIT_BALANCE_UPDATED",
                EventType.CreditBalanceDepleted => "CREDIT_BALANCE_DEPLETED",
                EventType.CreditBalanceLow => "CREDIT_BALANCE_LOW",
                EventType.CreditGrantProcessCompleted => "CREDIT_GRANT_PROCESS_COMPLETED",
                EventType.AutomaticRechargeThresholdBreach => "AUTOMATIC_RECHARGE_THRESHOLD_BREACH",
                EventType.AutomaticRechargeOperationAttempted =>
                    "AUTOMATIC_RECHARGE_OPERATION_ATTEMPTED",
                EventType.CreditsAutomaticRechargeLimitExceeded =>
                    "CREDITS_AUTOMATIC_RECHARGE_LIMIT_EXCEEDED",
                EventType.AutomaticRechargeConfigurationChanged =>
                    "AUTOMATIC_RECHARGE_CONFIGURATION_CHANGED",
                EventType.FeatureGroupCreated => "FEATURE_GROUP_CREATED",
                EventType.FeatureGroupUpdated => "FEATURE_GROUP_UPDATED",
                EventType.FeatureGroupArchived => "FEATURE_GROUP_ARCHIVED",
                EventType.FeatureGroupUnArchived => "FEATURE_GROUP_UN_ARCHIVED",
                EventType.CustomCurrencyCreated => "CUSTOM_CURRENCY_CREATED",
                EventType.CustomCurrencyUpdated => "CUSTOM_CURRENCY_UPDATED",
                EventType.CustomCurrencyArchived => "CUSTOM_CURRENCY_ARCHIVED",
                EventType.CustomCurrencyUnarchived => "CUSTOM_CURRENCY_UNARCHIVED",
                EventType.StripeAppDrawerViewed => "STRIPE_APP_DRAWER_VIEWED",
                EventType.EventQueueProvisioningRequested => "EVENT_QUEUE_PROVISIONING_REQUESTED",
                EventType.EventQueueDeprovisioningRequested =>
                    "EVENT_QUEUE_DEPROVISIONING_REQUESTED",
                _ => throw new StiggInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
