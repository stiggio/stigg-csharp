using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventQueueUpdateParams
        {
            QueueName = "x",
            AllowedAssumeRoleArns = ["string"],
            CreateLowPriorityQueues = true,
            EventTypes = [EventType.MemberInvited],
        };

        string expectedQueueName = "x";
        List<string> expectedAllowedAssumeRoleArns = ["string"];
        bool expectedCreateLowPriorityQueues = true;
        List<ApiEnum<string, EventType>> expectedEventTypes = [EventType.MemberInvited];

        Assert.Equal(expectedQueueName, parameters.QueueName);
        Assert.NotNull(parameters.AllowedAssumeRoleArns);
        Assert.Equal(expectedAllowedAssumeRoleArns.Count, parameters.AllowedAssumeRoleArns.Count);
        for (int i = 0; i < expectedAllowedAssumeRoleArns.Count; i++)
        {
            Assert.Equal(expectedAllowedAssumeRoleArns[i], parameters.AllowedAssumeRoleArns[i]);
        }
        Assert.Equal(expectedCreateLowPriorityQueues, parameters.CreateLowPriorityQueues);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventQueueUpdateParams { QueueName = "x" };

        Assert.Null(parameters.AllowedAssumeRoleArns);
        Assert.False(parameters.RawBodyData.ContainsKey("allowedAssumeRoleArns"));
        Assert.Null(parameters.CreateLowPriorityQueues);
        Assert.False(parameters.RawBodyData.ContainsKey("createLowPriorityQueues"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventQueueUpdateParams
        {
            QueueName = "x",

            // Null should be interpreted as omitted for these properties
            AllowedAssumeRoleArns = null,
            CreateLowPriorityQueues = null,
            EventTypes = null,
        };

        Assert.Null(parameters.AllowedAssumeRoleArns);
        Assert.False(parameters.RawBodyData.ContainsKey("allowedAssumeRoleArns"));
        Assert.Null(parameters.CreateLowPriorityQueues);
        Assert.False(parameters.RawBodyData.ContainsKey("createLowPriorityQueues"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
    }

    [Fact]
    public void Url_Works()
    {
        EventQueueUpdateParams parameters = new() { QueueName = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/internal/beta/event-queues/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventQueueUpdateParams
        {
            QueueName = "x",
            AllowedAssumeRoleArns = ["string"],
            CreateLowPriorityQueues = true,
            EventTypes = [EventType.MemberInvited],
        };

        EventQueueUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventType.MemberInvited)]
    [InlineData(EventType.SyncSubscription)]
    [InlineData(EventType.SyncCreditGrant)]
    [InlineData(EventType.CustomerCreated)]
    [InlineData(EventType.CustomerUpdated)]
    [InlineData(EventType.CustomerDeleted)]
    [InlineData(EventType.SyncCustomer)]
    [InlineData(EventType.SubscriptionCreated)]
    [InlineData(EventType.SubscriptionCanceled)]
    [InlineData(EventType.SubscriptionExpired)]
    [InlineData(EventType.SubscriptionUpdated)]
    [InlineData(EventType.SubscriptionTrialStarted)]
    [InlineData(EventType.SubscriptionTrialExpired)]
    [InlineData(EventType.SubscriptionTrialConverted)]
    [InlineData(EventType.SubscriptionTrialEndsSoon)]
    [InlineData(EventType.SyncSubscriptionUsage)]
    [InlineData(EventType.SubscriptionUsageUpdated)]
    [InlineData(EventType.SubscriptionSpentLimitExceeded)]
    [InlineData(EventType.CreateSubscriptionFailed)]
    [InlineData(EventType.PlanCreated)]
    [InlineData(EventType.PlanUpdated)]
    [InlineData(EventType.PlanDeleted)]
    [InlineData(EventType.AddonCreated)]
    [InlineData(EventType.AddonUpdated)]
    [InlineData(EventType.AddonDeleted)]
    [InlineData(EventType.SyncPackage)]
    [InlineData(EventType.FeatureCreated)]
    [InlineData(EventType.FeatureUpdated)]
    [InlineData(EventType.FeatureDeleted)]
    [InlineData(EventType.FeatureArchived)]
    [InlineData(EventType.ApiKeyCreated)]
    [InlineData(EventType.ApiKeyUpdated)]
    [InlineData(EventType.ApiKeyRotated)]
    [InlineData(EventType.ApiKeyRevoked)]
    [InlineData(EventType.EntitlementRequested)]
    [InlineData(EventType.EntitlementGranted)]
    [InlineData(EventType.EntitlementDenied)]
    [InlineData(EventType.MeasurementReported)]
    [InlineData(EventType.UsageThresholdExceeded)]
    [InlineData(EventType.PromotionalEntitlementGranted)]
    [InlineData(EventType.PromotionalEntitlementRevoked)]
    [InlineData(EventType.PromotionalEntitlementUpdated)]
    [InlineData(EventType.PromotionalEntitlementExpired)]
    [InlineData(EventType.PromotionalEntitlementEndsSoon)]
    [InlineData(EventType.PackagePublished)]
    [InlineData(EventType.MigrateSubscriptions)]
    [InlineData(EventType.RecalculateMigratedEntitlementsBatch)]
    [InlineData(EventType.MigrateSubscriptionsScheduledUpdates)]
    [InlineData(EventType.EntitlementsUpdated)]
    [InlineData(EventType.ResyncIntegrationTriggered)]
    [InlineData(EventType.CouponCreated)]
    [InlineData(EventType.CouponUpdated)]
    [InlineData(EventType.ImportIntegrationCatalogTriggered)]
    [InlineData(EventType.ImportIntegrationCustomersTriggered)]
    [InlineData(EventType.IncomingStripeWebhook)]
    [InlineData(EventType.IncomingAwsMarketplaceWebhook)]
    [InlineData(EventType.IncomingZuoraWebhook)]
    [InlineData(EventType.IncomingDoggoWebhook)]
    [InlineData(EventType.IncomingAppStoreWebhook)]
    [InlineData(EventType.ResyncIntegration)]
    [InlineData(EventType.SyncCoupon)]
    [InlineData(EventType.ImportIntegrationCatalog)]
    [InlineData(EventType.ImportIntegrationCustomers)]
    [InlineData(EventType.SyncFailed)]
    [InlineData(EventType.CustomerPaymentFailed)]
    [InlineData(EventType.ProductCreated)]
    [InlineData(EventType.ProductUpdated)]
    [InlineData(EventType.ProductDeleted)]
    [InlineData(EventType.ProductUnarchived)]
    [InlineData(EventType.PackageGroupCreated)]
    [InlineData(EventType.PackageGroupUpdated)]
    [InlineData(EventType.EnvironmentDeleted)]
    [InlineData(EventType.WidgetConfigurationUpdated)]
    [InlineData(EventType.EdgeApiDataResync)]
    [InlineData(EventType.EdgeApiDoggoResync)]
    [InlineData(EventType.EdgeApiClientConfigurationDataResync)]
    [InlineData(EventType.PurgeCustomerPersistentCacheRequested)]
    [InlineData(EventType.CustomerResourceEntitlementCalculationTriggered)]
    [InlineData(EventType.RecalculateResourceEntitlements)]
    [InlineData(EventType.CustomerEntitlementCalculationTriggered)]
    [InlineData(EventType.RecalculateEntitlementsTriggered)]
    [InlineData(EventType.ImportSubscriptionsBulkTriggered)]
    [InlineData(EventType.EdgeApiCustomerDataResync)]
    [InlineData(EventType.EdgeApiSubscriptionsDataResync)]
    [InlineData(EventType.EdgeApiPackageEntitlementsDataResync)]
    [InlineData(EventType.EdgeApiProductCacheDataResync)]
    [InlineData(EventType.EdgeApiPlanCacheDataResync)]
    [InlineData(EventType.ReplayWebhookEvent)]
    [InlineData(EventType.SubscriptionsMigrated)]
    [InlineData(EventType.SubscriptionsMigrationTriggered)]
    [InlineData(EventType.SubscriptionBillingMonthEndsSoon)]
    [InlineData(EventType.SubscriptionUsageChargeTriggered)]
    [InlineData(EventType.SchedulerBatch)]
    [InlineData(EventType.EventLogCreated)]
    [InlineData(EventType.CreditGrantCreated)]
    [InlineData(EventType.CreditGrantExpired)]
    [InlineData(EventType.CreditGrantVoided)]
    [InlineData(EventType.CreditGrantUpdated)]
    [InlineData(EventType.CreditGrantDepleted)]
    [InlineData(EventType.CreditGrantBalanceLow)]
    [InlineData(EventType.CreditBalanceUpdated)]
    [InlineData(EventType.CreditBalanceDepleted)]
    [InlineData(EventType.CreditBalanceLow)]
    [InlineData(EventType.CreditGrantProcessCompleted)]
    [InlineData(EventType.AutomaticRechargeThresholdBreach)]
    [InlineData(EventType.AutomaticRechargeOperationAttempted)]
    [InlineData(EventType.CreditsAutomaticRechargeLimitExceeded)]
    [InlineData(EventType.AutomaticRechargeConfigurationChanged)]
    [InlineData(EventType.FeatureGroupCreated)]
    [InlineData(EventType.FeatureGroupUpdated)]
    [InlineData(EventType.FeatureGroupArchived)]
    [InlineData(EventType.FeatureGroupUnArchived)]
    [InlineData(EventType.StripeAppDrawerViewed)]
    [InlineData(EventType.EventQueueProvisioningRequested)]
    [InlineData(EventType.EventQueueDeprovisioningRequested)]
    public void Validation_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventType.MemberInvited)]
    [InlineData(EventType.SyncSubscription)]
    [InlineData(EventType.SyncCreditGrant)]
    [InlineData(EventType.CustomerCreated)]
    [InlineData(EventType.CustomerUpdated)]
    [InlineData(EventType.CustomerDeleted)]
    [InlineData(EventType.SyncCustomer)]
    [InlineData(EventType.SubscriptionCreated)]
    [InlineData(EventType.SubscriptionCanceled)]
    [InlineData(EventType.SubscriptionExpired)]
    [InlineData(EventType.SubscriptionUpdated)]
    [InlineData(EventType.SubscriptionTrialStarted)]
    [InlineData(EventType.SubscriptionTrialExpired)]
    [InlineData(EventType.SubscriptionTrialConverted)]
    [InlineData(EventType.SubscriptionTrialEndsSoon)]
    [InlineData(EventType.SyncSubscriptionUsage)]
    [InlineData(EventType.SubscriptionUsageUpdated)]
    [InlineData(EventType.SubscriptionSpentLimitExceeded)]
    [InlineData(EventType.CreateSubscriptionFailed)]
    [InlineData(EventType.PlanCreated)]
    [InlineData(EventType.PlanUpdated)]
    [InlineData(EventType.PlanDeleted)]
    [InlineData(EventType.AddonCreated)]
    [InlineData(EventType.AddonUpdated)]
    [InlineData(EventType.AddonDeleted)]
    [InlineData(EventType.SyncPackage)]
    [InlineData(EventType.FeatureCreated)]
    [InlineData(EventType.FeatureUpdated)]
    [InlineData(EventType.FeatureDeleted)]
    [InlineData(EventType.FeatureArchived)]
    [InlineData(EventType.ApiKeyCreated)]
    [InlineData(EventType.ApiKeyUpdated)]
    [InlineData(EventType.ApiKeyRotated)]
    [InlineData(EventType.ApiKeyRevoked)]
    [InlineData(EventType.EntitlementRequested)]
    [InlineData(EventType.EntitlementGranted)]
    [InlineData(EventType.EntitlementDenied)]
    [InlineData(EventType.MeasurementReported)]
    [InlineData(EventType.UsageThresholdExceeded)]
    [InlineData(EventType.PromotionalEntitlementGranted)]
    [InlineData(EventType.PromotionalEntitlementRevoked)]
    [InlineData(EventType.PromotionalEntitlementUpdated)]
    [InlineData(EventType.PromotionalEntitlementExpired)]
    [InlineData(EventType.PromotionalEntitlementEndsSoon)]
    [InlineData(EventType.PackagePublished)]
    [InlineData(EventType.MigrateSubscriptions)]
    [InlineData(EventType.RecalculateMigratedEntitlementsBatch)]
    [InlineData(EventType.MigrateSubscriptionsScheduledUpdates)]
    [InlineData(EventType.EntitlementsUpdated)]
    [InlineData(EventType.ResyncIntegrationTriggered)]
    [InlineData(EventType.CouponCreated)]
    [InlineData(EventType.CouponUpdated)]
    [InlineData(EventType.ImportIntegrationCatalogTriggered)]
    [InlineData(EventType.ImportIntegrationCustomersTriggered)]
    [InlineData(EventType.IncomingStripeWebhook)]
    [InlineData(EventType.IncomingAwsMarketplaceWebhook)]
    [InlineData(EventType.IncomingZuoraWebhook)]
    [InlineData(EventType.IncomingDoggoWebhook)]
    [InlineData(EventType.IncomingAppStoreWebhook)]
    [InlineData(EventType.ResyncIntegration)]
    [InlineData(EventType.SyncCoupon)]
    [InlineData(EventType.ImportIntegrationCatalog)]
    [InlineData(EventType.ImportIntegrationCustomers)]
    [InlineData(EventType.SyncFailed)]
    [InlineData(EventType.CustomerPaymentFailed)]
    [InlineData(EventType.ProductCreated)]
    [InlineData(EventType.ProductUpdated)]
    [InlineData(EventType.ProductDeleted)]
    [InlineData(EventType.ProductUnarchived)]
    [InlineData(EventType.PackageGroupCreated)]
    [InlineData(EventType.PackageGroupUpdated)]
    [InlineData(EventType.EnvironmentDeleted)]
    [InlineData(EventType.WidgetConfigurationUpdated)]
    [InlineData(EventType.EdgeApiDataResync)]
    [InlineData(EventType.EdgeApiDoggoResync)]
    [InlineData(EventType.EdgeApiClientConfigurationDataResync)]
    [InlineData(EventType.PurgeCustomerPersistentCacheRequested)]
    [InlineData(EventType.CustomerResourceEntitlementCalculationTriggered)]
    [InlineData(EventType.RecalculateResourceEntitlements)]
    [InlineData(EventType.CustomerEntitlementCalculationTriggered)]
    [InlineData(EventType.RecalculateEntitlementsTriggered)]
    [InlineData(EventType.ImportSubscriptionsBulkTriggered)]
    [InlineData(EventType.EdgeApiCustomerDataResync)]
    [InlineData(EventType.EdgeApiSubscriptionsDataResync)]
    [InlineData(EventType.EdgeApiPackageEntitlementsDataResync)]
    [InlineData(EventType.EdgeApiProductCacheDataResync)]
    [InlineData(EventType.EdgeApiPlanCacheDataResync)]
    [InlineData(EventType.ReplayWebhookEvent)]
    [InlineData(EventType.SubscriptionsMigrated)]
    [InlineData(EventType.SubscriptionsMigrationTriggered)]
    [InlineData(EventType.SubscriptionBillingMonthEndsSoon)]
    [InlineData(EventType.SubscriptionUsageChargeTriggered)]
    [InlineData(EventType.SchedulerBatch)]
    [InlineData(EventType.EventLogCreated)]
    [InlineData(EventType.CreditGrantCreated)]
    [InlineData(EventType.CreditGrantExpired)]
    [InlineData(EventType.CreditGrantVoided)]
    [InlineData(EventType.CreditGrantUpdated)]
    [InlineData(EventType.CreditGrantDepleted)]
    [InlineData(EventType.CreditGrantBalanceLow)]
    [InlineData(EventType.CreditBalanceUpdated)]
    [InlineData(EventType.CreditBalanceDepleted)]
    [InlineData(EventType.CreditBalanceLow)]
    [InlineData(EventType.CreditGrantProcessCompleted)]
    [InlineData(EventType.AutomaticRechargeThresholdBreach)]
    [InlineData(EventType.AutomaticRechargeOperationAttempted)]
    [InlineData(EventType.CreditsAutomaticRechargeLimitExceeded)]
    [InlineData(EventType.AutomaticRechargeConfigurationChanged)]
    [InlineData(EventType.FeatureGroupCreated)]
    [InlineData(EventType.FeatureGroupUpdated)]
    [InlineData(EventType.FeatureGroupArchived)]
    [InlineData(EventType.FeatureGroupUnArchived)]
    [InlineData(EventType.StripeAppDrawerViewed)]
    [InlineData(EventType.EventQueueProvisioningRequested)]
    [InlineData(EventType.EventQueueDeprovisioningRequested)]
    public void SerializationRoundtrip_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
