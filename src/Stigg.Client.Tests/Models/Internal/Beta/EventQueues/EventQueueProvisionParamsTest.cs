using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Tests.Models.Internal.Beta.EventQueues;

public class EventQueueProvisionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventQueueProvisionParams
        {
            Region = Region.UsEast1,
            AllowedAssumeRoleArns = ["string"],
            CreateLowPriorityQueues = true,
            EventTypes = [EventQueueProvisionParamsEventType.MemberInvited],
            Suffix = "suffix",
        };

        ApiEnum<string, Region> expectedRegion = Region.UsEast1;
        List<string> expectedAllowedAssumeRoleArns = ["string"];
        bool expectedCreateLowPriorityQueues = true;
        List<ApiEnum<string, EventQueueProvisionParamsEventType>> expectedEventTypes =
        [
            EventQueueProvisionParamsEventType.MemberInvited,
        ];
        string expectedSuffix = "suffix";

        Assert.Equal(expectedRegion, parameters.Region);
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
        Assert.Equal(expectedSuffix, parameters.Suffix);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventQueueProvisionParams { Region = Region.UsEast1 };

        Assert.Null(parameters.AllowedAssumeRoleArns);
        Assert.False(parameters.RawBodyData.ContainsKey("allowedAssumeRoleArns"));
        Assert.Null(parameters.CreateLowPriorityQueues);
        Assert.False(parameters.RawBodyData.ContainsKey("createLowPriorityQueues"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.Suffix);
        Assert.False(parameters.RawBodyData.ContainsKey("suffix"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventQueueProvisionParams
        {
            Region = Region.UsEast1,

            // Null should be interpreted as omitted for these properties
            AllowedAssumeRoleArns = null,
            CreateLowPriorityQueues = null,
            EventTypes = null,
            Suffix = null,
        };

        Assert.Null(parameters.AllowedAssumeRoleArns);
        Assert.False(parameters.RawBodyData.ContainsKey("allowedAssumeRoleArns"));
        Assert.Null(parameters.CreateLowPriorityQueues);
        Assert.False(parameters.RawBodyData.ContainsKey("createLowPriorityQueues"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("eventTypes"));
        Assert.Null(parameters.Suffix);
        Assert.False(parameters.RawBodyData.ContainsKey("suffix"));
    }

    [Fact]
    public void Url_Works()
    {
        EventQueueProvisionParams parameters = new() { Region = Region.UsEast1 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/internal/beta/event-queues/provision"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventQueueProvisionParams
        {
            Region = Region.UsEast1,
            AllowedAssumeRoleArns = ["string"],
            CreateLowPriorityQueues = true,
            EventTypes = [EventQueueProvisionParamsEventType.MemberInvited],
            Suffix = "suffix",
        };

        EventQueueProvisionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RegionTest : TestBase
{
    [Theory]
    [InlineData(Region.UsEast1)]
    [InlineData(Region.UsEast2)]
    [InlineData(Region.UsWest1)]
    [InlineData(Region.UsWest2)]
    [InlineData(Region.CaCentral1)]
    [InlineData(Region.EuWest1)]
    [InlineData(Region.EuWest2)]
    [InlineData(Region.EuWest3)]
    [InlineData(Region.EuCentral1)]
    [InlineData(Region.EuCentral2)]
    [InlineData(Region.EuNorth1)]
    [InlineData(Region.EuSouth1)]
    [InlineData(Region.EuSouth2)]
    [InlineData(Region.ApSoutheast1)]
    [InlineData(Region.ApSoutheast2)]
    [InlineData(Region.ApSoutheast3)]
    [InlineData(Region.ApNortheast1)]
    [InlineData(Region.ApNortheast2)]
    [InlineData(Region.ApNortheast3)]
    [InlineData(Region.ApSouth1)]
    [InlineData(Region.ApSouth2)]
    [InlineData(Region.ApEast1)]
    [InlineData(Region.SaEast1)]
    [InlineData(Region.AfSouth1)]
    [InlineData(Region.MeSouth1)]
    [InlineData(Region.MeCentral1)]
    [InlineData(Region.IlCentral1)]
    public void Validation_Works(Region rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Region> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Region.UsEast1)]
    [InlineData(Region.UsEast2)]
    [InlineData(Region.UsWest1)]
    [InlineData(Region.UsWest2)]
    [InlineData(Region.CaCentral1)]
    [InlineData(Region.EuWest1)]
    [InlineData(Region.EuWest2)]
    [InlineData(Region.EuWest3)]
    [InlineData(Region.EuCentral1)]
    [InlineData(Region.EuCentral2)]
    [InlineData(Region.EuNorth1)]
    [InlineData(Region.EuSouth1)]
    [InlineData(Region.EuSouth2)]
    [InlineData(Region.ApSoutheast1)]
    [InlineData(Region.ApSoutheast2)]
    [InlineData(Region.ApSoutheast3)]
    [InlineData(Region.ApNortheast1)]
    [InlineData(Region.ApNortheast2)]
    [InlineData(Region.ApNortheast3)]
    [InlineData(Region.ApSouth1)]
    [InlineData(Region.ApSouth2)]
    [InlineData(Region.ApEast1)]
    [InlineData(Region.SaEast1)]
    [InlineData(Region.AfSouth1)]
    [InlineData(Region.MeSouth1)]
    [InlineData(Region.MeCentral1)]
    [InlineData(Region.IlCentral1)]
    public void SerializationRoundtrip_Works(Region rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Region> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Region>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EventQueueProvisionParamsEventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventQueueProvisionParamsEventType.MemberInvited)]
    [InlineData(EventQueueProvisionParamsEventType.SyncSubscription)]
    [InlineData(EventQueueProvisionParamsEventType.SyncCreditGrant)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.SyncCustomer)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionCreated)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionCanceled)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionExpired)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionTrialStarted)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionTrialExpired)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionTrialConverted)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionTrialEndsSoon)]
    [InlineData(EventQueueProvisionParamsEventType.SyncSubscriptionUsage)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionUsageUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionSpentLimitExceeded)]
    [InlineData(EventQueueProvisionParamsEventType.CreateSubscriptionFailed)]
    [InlineData(EventQueueProvisionParamsEventType.PlanCreated)]
    [InlineData(EventQueueProvisionParamsEventType.PlanUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.PlanDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.AddonCreated)]
    [InlineData(EventQueueProvisionParamsEventType.AddonUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.AddonDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.SyncPackage)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureCreated)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureArchived)]
    [InlineData(EventQueueProvisionParamsEventType.ApiKeyCreated)]
    [InlineData(EventQueueProvisionParamsEventType.ApiKeyUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.ApiKeyRotated)]
    [InlineData(EventQueueProvisionParamsEventType.ApiKeyRevoked)]
    [InlineData(EventQueueProvisionParamsEventType.EntitlementRequested)]
    [InlineData(EventQueueProvisionParamsEventType.EntitlementGranted)]
    [InlineData(EventQueueProvisionParamsEventType.EntitlementDenied)]
    [InlineData(EventQueueProvisionParamsEventType.MeasurementReported)]
    [InlineData(EventQueueProvisionParamsEventType.UsageThresholdExceeded)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementGranted)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementRevoked)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementExpired)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementEndsSoon)]
    [InlineData(EventQueueProvisionParamsEventType.PackagePublished)]
    [InlineData(EventQueueProvisionParamsEventType.MigrateSubscriptions)]
    [InlineData(EventQueueProvisionParamsEventType.RecalculateMigratedEntitlementsBatch)]
    [InlineData(EventQueueProvisionParamsEventType.MigrateSubscriptionsScheduledUpdates)]
    [InlineData(EventQueueProvisionParamsEventType.EntitlementsUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.ResyncIntegrationTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.CouponCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CouponUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.ImportIntegrationCatalogTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.ImportIntegrationCustomersTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingStripeWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingAwsMarketplaceWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingZuoraWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingDoggoWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingAppStoreWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.ResyncIntegration)]
    [InlineData(EventQueueProvisionParamsEventType.SyncCoupon)]
    [InlineData(EventQueueProvisionParamsEventType.ImportIntegrationCatalog)]
    [InlineData(EventQueueProvisionParamsEventType.ImportIntegrationCustomers)]
    [InlineData(EventQueueProvisionParamsEventType.SyncFailed)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerPaymentFailed)]
    [InlineData(EventQueueProvisionParamsEventType.ProductCreated)]
    [InlineData(EventQueueProvisionParamsEventType.ProductUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.ProductDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.ProductUnarchived)]
    [InlineData(EventQueueProvisionParamsEventType.PackageGroupCreated)]
    [InlineData(EventQueueProvisionParamsEventType.PackageGroupUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.EnvironmentDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.WidgetConfigurationUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiDoggoResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiClientConfigurationDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.PurgeCustomerPersistentCacheRequested)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerResourceEntitlementCalculationTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.RecalculateResourceEntitlements)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerEntitlementCalculationTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.RecalculateEntitlementsTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.ImportSubscriptionsBulkTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiCustomerDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiSubscriptionsDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiPackageEntitlementsDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiProductCacheDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiPlanCacheDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiCustomCurrencyCacheDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.ReplayWebhookEvent)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionsMigrated)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionsMigrationTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionBillingMonthEndsSoon)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionUsageChargeTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.SchedulerBatch)]
    [InlineData(EventQueueProvisionParamsEventType.EventLogCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantExpired)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantVoided)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantDepleted)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantBalanceLow)]
    [InlineData(EventQueueProvisionParamsEventType.CreditBalanceUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.CreditBalanceDepleted)]
    [InlineData(EventQueueProvisionParamsEventType.CreditBalanceLow)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantProcessCompleted)]
    [InlineData(EventQueueProvisionParamsEventType.AutomaticRechargeThresholdBreach)]
    [InlineData(EventQueueProvisionParamsEventType.AutomaticRechargeOperationAttempted)]
    [InlineData(EventQueueProvisionParamsEventType.CreditsAutomaticRechargeLimitExceeded)]
    [InlineData(EventQueueProvisionParamsEventType.AutomaticRechargeConfigurationChanged)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureGroupCreated)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureGroupUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureGroupArchived)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureGroupUnArchived)]
    [InlineData(EventQueueProvisionParamsEventType.CustomCurrencyCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CustomCurrencyUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.CustomCurrencyArchived)]
    [InlineData(EventQueueProvisionParamsEventType.CustomCurrencyUnarchived)]
    [InlineData(EventQueueProvisionParamsEventType.StripeAppDrawerViewed)]
    [InlineData(EventQueueProvisionParamsEventType.EventQueueProvisioningRequested)]
    [InlineData(EventQueueProvisionParamsEventType.EventQueueDeprovisioningRequested)]
    public void Validation_Works(EventQueueProvisionParamsEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueProvisionParamsEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueProvisionParamsEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventQueueProvisionParamsEventType.MemberInvited)]
    [InlineData(EventQueueProvisionParamsEventType.SyncSubscription)]
    [InlineData(EventQueueProvisionParamsEventType.SyncCreditGrant)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.SyncCustomer)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionCreated)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionCanceled)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionExpired)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionTrialStarted)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionTrialExpired)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionTrialConverted)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionTrialEndsSoon)]
    [InlineData(EventQueueProvisionParamsEventType.SyncSubscriptionUsage)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionUsageUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionSpentLimitExceeded)]
    [InlineData(EventQueueProvisionParamsEventType.CreateSubscriptionFailed)]
    [InlineData(EventQueueProvisionParamsEventType.PlanCreated)]
    [InlineData(EventQueueProvisionParamsEventType.PlanUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.PlanDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.AddonCreated)]
    [InlineData(EventQueueProvisionParamsEventType.AddonUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.AddonDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.SyncPackage)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureCreated)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureArchived)]
    [InlineData(EventQueueProvisionParamsEventType.ApiKeyCreated)]
    [InlineData(EventQueueProvisionParamsEventType.ApiKeyUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.ApiKeyRotated)]
    [InlineData(EventQueueProvisionParamsEventType.ApiKeyRevoked)]
    [InlineData(EventQueueProvisionParamsEventType.EntitlementRequested)]
    [InlineData(EventQueueProvisionParamsEventType.EntitlementGranted)]
    [InlineData(EventQueueProvisionParamsEventType.EntitlementDenied)]
    [InlineData(EventQueueProvisionParamsEventType.MeasurementReported)]
    [InlineData(EventQueueProvisionParamsEventType.UsageThresholdExceeded)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementGranted)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementRevoked)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementExpired)]
    [InlineData(EventQueueProvisionParamsEventType.PromotionalEntitlementEndsSoon)]
    [InlineData(EventQueueProvisionParamsEventType.PackagePublished)]
    [InlineData(EventQueueProvisionParamsEventType.MigrateSubscriptions)]
    [InlineData(EventQueueProvisionParamsEventType.RecalculateMigratedEntitlementsBatch)]
    [InlineData(EventQueueProvisionParamsEventType.MigrateSubscriptionsScheduledUpdates)]
    [InlineData(EventQueueProvisionParamsEventType.EntitlementsUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.ResyncIntegrationTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.CouponCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CouponUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.ImportIntegrationCatalogTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.ImportIntegrationCustomersTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingStripeWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingAwsMarketplaceWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingZuoraWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingDoggoWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.IncomingAppStoreWebhook)]
    [InlineData(EventQueueProvisionParamsEventType.ResyncIntegration)]
    [InlineData(EventQueueProvisionParamsEventType.SyncCoupon)]
    [InlineData(EventQueueProvisionParamsEventType.ImportIntegrationCatalog)]
    [InlineData(EventQueueProvisionParamsEventType.ImportIntegrationCustomers)]
    [InlineData(EventQueueProvisionParamsEventType.SyncFailed)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerPaymentFailed)]
    [InlineData(EventQueueProvisionParamsEventType.ProductCreated)]
    [InlineData(EventQueueProvisionParamsEventType.ProductUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.ProductDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.ProductUnarchived)]
    [InlineData(EventQueueProvisionParamsEventType.PackageGroupCreated)]
    [InlineData(EventQueueProvisionParamsEventType.PackageGroupUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.EnvironmentDeleted)]
    [InlineData(EventQueueProvisionParamsEventType.WidgetConfigurationUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiDoggoResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiClientConfigurationDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.PurgeCustomerPersistentCacheRequested)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerResourceEntitlementCalculationTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.RecalculateResourceEntitlements)]
    [InlineData(EventQueueProvisionParamsEventType.CustomerEntitlementCalculationTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.RecalculateEntitlementsTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.ImportSubscriptionsBulkTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiCustomerDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiSubscriptionsDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiPackageEntitlementsDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiProductCacheDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiPlanCacheDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.EdgeApiCustomCurrencyCacheDataResync)]
    [InlineData(EventQueueProvisionParamsEventType.ReplayWebhookEvent)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionsMigrated)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionsMigrationTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionBillingMonthEndsSoon)]
    [InlineData(EventQueueProvisionParamsEventType.SubscriptionUsageChargeTriggered)]
    [InlineData(EventQueueProvisionParamsEventType.SchedulerBatch)]
    [InlineData(EventQueueProvisionParamsEventType.EventLogCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantExpired)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantVoided)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantDepleted)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantBalanceLow)]
    [InlineData(EventQueueProvisionParamsEventType.CreditBalanceUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.CreditBalanceDepleted)]
    [InlineData(EventQueueProvisionParamsEventType.CreditBalanceLow)]
    [InlineData(EventQueueProvisionParamsEventType.CreditGrantProcessCompleted)]
    [InlineData(EventQueueProvisionParamsEventType.AutomaticRechargeThresholdBreach)]
    [InlineData(EventQueueProvisionParamsEventType.AutomaticRechargeOperationAttempted)]
    [InlineData(EventQueueProvisionParamsEventType.CreditsAutomaticRechargeLimitExceeded)]
    [InlineData(EventQueueProvisionParamsEventType.AutomaticRechargeConfigurationChanged)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureGroupCreated)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureGroupUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureGroupArchived)]
    [InlineData(EventQueueProvisionParamsEventType.FeatureGroupUnArchived)]
    [InlineData(EventQueueProvisionParamsEventType.CustomCurrencyCreated)]
    [InlineData(EventQueueProvisionParamsEventType.CustomCurrencyUpdated)]
    [InlineData(EventQueueProvisionParamsEventType.CustomCurrencyArchived)]
    [InlineData(EventQueueProvisionParamsEventType.CustomCurrencyUnarchived)]
    [InlineData(EventQueueProvisionParamsEventType.StripeAppDrawerViewed)]
    [InlineData(EventQueueProvisionParamsEventType.EventQueueProvisioningRequested)]
    [InlineData(EventQueueProvisionParamsEventType.EventQueueDeprovisioningRequested)]
    public void SerializationRoundtrip_Works(EventQueueProvisionParamsEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventQueueProvisionParamsEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionParamsEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventQueueProvisionParamsEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EventQueueProvisionParamsEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
