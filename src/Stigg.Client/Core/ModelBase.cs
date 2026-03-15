using System.Text.Json;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;
using Stigg.Client.Models.V1.Events.Credits;
using Stigg.Client.Models.V1.Features;
using Addons = Stigg.Client.Models.V1.Addons;
using Coupons = Stigg.Client.Models.V1.Coupons;
using Entitlements = Stigg.Client.Models.V1.Addons.Entitlements;
using Grants = Stigg.Client.Models.V1.Events.Credits.Grants;
using PaymentMethod = Stigg.Client.Models.V1.Customers.PaymentMethod;
using Plans = Stigg.Client.Models.V1.Plans;
using PlansEntitlements = Stigg.Client.Models.V1.Plans.Entitlements;
using Products = Stigg.Client.Models.V1.Products;
using Subscriptions = Stigg.Client.Models.V1.Subscriptions;
using Usage = Stigg.Client.Models.V1.Usage;

namespace Stigg.Client.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, DataBillingCurrency>(),
            new ApiEnumConverter<string, DataDefaultPaymentMethodType>(),
            new ApiEnumConverter<string, DataIntegrationVendorIdentifier>(),
            new ApiEnumConverter<string, CustomerListResponseBillingCurrency>(),
            new ApiEnumConverter<string, CustomerListResponseDefaultPaymentMethodType>(),
            new ApiEnumConverter<string, CustomerListResponseIntegrationVendorIdentifier>(),
            new ApiEnumConverter<string, BillingCurrency>(),
            new ApiEnumConverter<string, VendorIdentifier>(),
            new ApiEnumConverter<string, CustomerProvisionParamsBillingCurrency>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, CustomerProvisionParamsIntegrationVendorIdentifier>(),
            new ApiEnumConverter<string, PaymentMethod::VendorIdentifier>(),
            new ApiEnumConverter<string, PaymentMethod::BillingCurrency>(),
            new ApiEnumConverter<string, DataPeriod>(),
            new ApiEnumConverter<string, DataResetPeriod>(),
            new ApiEnumConverter<string, YearlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, MonthlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, WeeklyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, PromotionalEntitlementListResponsePeriod>(),
            new ApiEnumConverter<string, PromotionalEntitlementListResponseResetPeriod>(),
            new ApiEnumConverter<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PromotionalEntitlementListResponseResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<string, PromotionalEntitlementListResponseStatus>(),
            new ApiEnumConverter<string, PromotionalEntitlementRevokeResponseDataPeriod>(),
            new ApiEnumConverter<string, PromotionalEntitlementRevokeResponseDataResetPeriod>(),
            new ApiEnumConverter<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PromotionalEntitlementRevokeResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<string, PromotionalEntitlementRevokeResponseDataStatus>(),
            new ApiEnumConverter<string, AccordingTo>(),
            new ApiEnumConverter<string, Period>(),
            new ApiEnumConverter<string, ResetPeriod>(),
            new ApiEnumConverter<string, WeeklyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, YearlyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Subscriptions::PaymentCollection>(),
            new ApiEnumConverter<string, Subscriptions::PricingType>(),
            new ApiEnumConverter<string, Subscriptions::Status>(),
            new ApiEnumConverter<string, Subscriptions::CancelReason>(),
            new ApiEnumConverter<string, Subscriptions::CouponStatus>(),
            new ApiEnumConverter<string, Subscriptions::CouponAmountsOffCurrency>(),
            new ApiEnumConverter<string, Subscriptions::ScheduleStatus>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionScheduleType>(),
            new ApiEnumConverter<string, Subscriptions::LatestInvoiceStatus>(),
            new ApiEnumConverter<string, Subscriptions::BillingReason>(),
            new ApiEnumConverter<string, Subscriptions::DataMinimumSpendCurrency>(),
            new ApiEnumConverter<string, Subscriptions::DataPaymentCollectionMethod>(),
            new ApiEnumConverter<string, Subscriptions::PriceCurrency>(),
            new ApiEnumConverter<string, Subscriptions::PriceTierFlatPriceCurrency>(),
            new ApiEnumConverter<string, Subscriptions::PriceTierUnitPriceCurrency>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionEntitlementType>(),
            new ApiEnumConverter<string, Subscriptions::TrialTrialEndBehavior>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponsePaymentCollection
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionListResponsePricingType>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionListResponseStatus>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionListResponseCancelReason>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionListResponseCouponStatus>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponseCouponAmountsOffCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponseFutureUpdateScheduleStatus
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponseFutureUpdateSubscriptionScheduleType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponseLatestInvoiceStatus
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponseLatestInvoiceBillingReason
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponseMinimumSpendCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponsePaymentCollectionMethod
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionListResponsePriceCurrency>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponsePriceTierFlatPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponsePriceTierUnitPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponseSubscriptionEntitlementType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponseTrialTrialEndBehavior
            >(),
            new ApiEnumConverter<string, Subscriptions::AccessDeniedReason>(),
            new ApiEnumConverter<string, Subscriptions::UnionObjectVariant0Type>(),
            new ApiEnumConverter<string, Subscriptions::FeatureStatus>(),
            new ApiEnumConverter<string, Subscriptions::FeatureType>(),
            new ApiEnumConverter<string, Subscriptions::UnionObjectVariant0ResetPeriod>(),
            new ApiEnumConverter<string, Subscriptions::UnionObjectVariant1AccessDeniedReason>(),
            new ApiEnumConverter<string, Subscriptions::UnionObjectVariant1Type>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionProvisionResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPaymentCollection
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPricingType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionStatus
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionCancelReason
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionCouponStatus
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionCouponAmountsOffCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionFutureUpdateScheduleStatus
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionFutureUpdateSubscriptionScheduleType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionLatestInvoiceStatus
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionLatestInvoiceBillingReason
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionMinimumSpendCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionSubscriptionEntitlementType
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionTrialTrialEndBehavior
            >(),
            new ApiEnumConverter<string, Subscriptions::Currency>(),
            new ApiEnumConverter<string, Subscriptions::BillingCycleAnchor>(),
            new ApiEnumConverter<string, Subscriptions::ProrationBehavior>(),
            new ApiEnumConverter<string, Subscriptions::BillingPeriod>(),
            new ApiEnumConverter<string, Subscriptions::Type>(),
            new ApiEnumConverter<string, Subscriptions::AccordingTo>(),
            new ApiEnumConverter<string, Subscriptions::ResetPeriod>(),
            new ApiEnumConverter<
                string,
                Subscriptions::WeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::YearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Subscriptions::Cadence>(),
            new ApiEnumConverter<string, Subscriptions::MinimumSpendCurrency>(),
            new ApiEnumConverter<string, Subscriptions::PriceOverrideCurrency>(),
            new ApiEnumConverter<string, Subscriptions::ScheduleStrategy>(),
            new ApiEnumConverter<string, Subscriptions::CancellationAction>(),
            new ApiEnumConverter<string, Subscriptions::CancellationTime>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionBillingPeriod>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionChargeType>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionMigrationTime>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewParamsBillingCycleAnchor
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewParamsBillingInformationProrationBehavior
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionPreviewParamsBillingPeriod>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionPreviewParamsChargeType>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewParamsScheduleStrategy
            >(),
            new ApiEnumConverter<string, Subscriptions::TrialEndBehavior>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsAppliedCouponDiscountAmountsOffCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsBillingCycleAnchor
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsBillingInformationProrationBehavior
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionProvisionParamsBillingPeriod>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionProvisionParamsChargeType>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsEntitlementFeatureMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsEntitlementFeatureResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsEntitlementFeatureWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsEntitlementFeatureYearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsEntitlementCreditCadence
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsMinimumSpendCurrency
            >(),
            new ApiEnumConverter<string, Subscriptions::PaymentCollectionMethod>(),
            new ApiEnumConverter<string, Subscriptions::CreditGrantCadence>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsPriceOverrideCurrency
            >(),
            new ApiEnumConverter<string, Subscriptions::FlatPriceCurrency>(),
            new ApiEnumConverter<string, Subscriptions::UnitPriceCurrency>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsScheduleStrategy
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsTrialOverrideConfigurationTrialEndBehavior
            >(),
            new ApiEnumConverter<string, Coupons::DataAmountsOffCurrency>(),
            new ApiEnumConverter<string, Coupons::Source>(),
            new ApiEnumConverter<string, Coupons::Status>(),
            new ApiEnumConverter<string, Coupons::DataType>(),
            new ApiEnumConverter<string, Coupons::CouponListResponseAmountsOffCurrency>(),
            new ApiEnumConverter<string, Coupons::CouponListResponseSource>(),
            new ApiEnumConverter<string, Coupons::CouponListResponseStatus>(),
            new ApiEnumConverter<string, Coupons::CouponListResponseType>(),
            new ApiEnumConverter<string, Coupons::Currency>(),
            new ApiEnumConverter<string, Coupons::Type>(),
            new ApiEnumConverter<string, GrantExpirationPeriod>(),
            new ApiEnumConverter<string, ThresholdType>(),
            new ApiEnumConverter<string, EventType>(),
            new ApiEnumConverter<string, TimeRange>(),
            new ApiEnumConverter<string, Grants::DataGrantType>(),
            new ApiEnumConverter<string, Grants::BillingReason>(),
            new ApiEnumConverter<string, Grants::Status>(),
            new ApiEnumConverter<string, Grants::PaymentCollection>(),
            new ApiEnumConverter<string, Grants::SourceType>(),
            new ApiEnumConverter<string, Grants::DataStatus>(),
            new ApiEnumConverter<string, Grants::GrantListResponseGrantType>(),
            new ApiEnumConverter<string, Grants::GrantListResponseLatestInvoiceBillingReason>(),
            new ApiEnumConverter<string, Grants::GrantListResponseLatestInvoiceStatus>(),
            new ApiEnumConverter<string, Grants::GrantListResponsePaymentCollection>(),
            new ApiEnumConverter<string, Grants::GrantListResponseSourceType>(),
            new ApiEnumConverter<string, Grants::GrantListResponseStatus>(),
            new ApiEnumConverter<string, Grants::GrantType>(),
            new ApiEnumConverter<string, Grants::Currency>(),
            new ApiEnumConverter<string, Grants::PaymentCollectionMethod>(),
            new ApiEnumConverter<string, DataFeatureStatus>(),
            new ApiEnumConverter<string, DataFeatureType>(),
            new ApiEnumConverter<string, DataMeterType>(),
            new ApiEnumConverter<string, DataUnitTransformationRound>(),
            new ApiEnumConverter<string, FeatureListFeaturesResponseFeatureStatus>(),
            new ApiEnumConverter<string, FeatureListFeaturesResponseFeatureType>(),
            new ApiEnumConverter<string, FeatureListFeaturesResponseMeterType>(),
            new ApiEnumConverter<string, FeatureListFeaturesResponseUnitTransformationRound>(),
            new ApiEnumConverter<string, FeatureType>(),
            new ApiEnumConverter<string, FeatureStatus>(),
            new ApiEnumConverter<string, MeterType>(),
            new ApiEnumConverter<string, Round>(),
            new ApiEnumConverter<string, Function>(),
            new ApiEnumConverter<string, Operation>(),
            new ApiEnumConverter<string, FeatureUpdateFeatureParamsUnitTransformationRound>(),
            new ApiEnumConverter<string, Addons::Type>(),
            new ApiEnumConverter<string, Addons::DataPricingType>(),
            new ApiEnumConverter<string, Addons::DataStatus>(),
            new ApiEnumConverter<string, Addons::SetPackagePricingPricingType>(),
            new ApiEnumConverter<string, Addons::SetPackagePricingMinimumSpendBillingPeriod>(),
            new ApiEnumConverter<string, Addons::SetPackagePricingMinimumSpendMinimumCurrency>(),
            new ApiEnumConverter<string, Addons::SetPackagePricingOverageBillingPeriod>(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelBillingModel
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelPricePeriodBillingPeriod
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelPricePeriodCreditGrantCadence
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelPricePeriodPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelPricePeriodTierFlatPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelPricePeriodTierUnitPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelBillingCadence
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelEntitlementMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelEntitlementResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelEntitlementWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingOveragePricingModelEntitlementYearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Addons::SetPackagePricingPricingModelBillingModel>(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingPricingModelPricePeriodBillingPeriod
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingPricingModelPricePeriodCreditGrantCadence
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingPricingModelPricePeriodPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingPricingModelPricePeriodTierFlatPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingPricingModelPricePeriodTierUnitPriceCurrency
            >(),
            new ApiEnumConverter<string, Addons::SetPackagePricingPricingModelBillingCadence>(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingPricingModelMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Addons::SetPackagePricingPricingModelResetPeriod>(),
            new ApiEnumConverter<string, Addons::SetPackagePricingPricingModelTiersMode>(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingPricingModelWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Addons::SetPackagePricingPricingModelYearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Addons::SetPackagePricingResponseDataPricingType>(),
            new ApiEnumConverter<string, Addons::AddonListResponseEntitlementType>(),
            new ApiEnumConverter<string, Addons::AddonListResponsePricingType>(),
            new ApiEnumConverter<string, Addons::AddonListResponseStatus>(),
            new ApiEnumConverter<string, Addons::PricingType>(),
            new ApiEnumConverter<string, Addons::Status>(),
            new ApiEnumConverter<string, Addons::AddonUpdateParamsStatus>(),
            new ApiEnumConverter<string, Addons::MigrationType>(),
            new ApiEnumConverter<string, Addons::AddonSetPricingParamsPricingType>(),
            new ApiEnumConverter<string, Addons::BillingPeriod>(),
            new ApiEnumConverter<string, Addons::Currency>(),
            new ApiEnumConverter<string, Addons::OverageBillingPeriod>(),
            new ApiEnumConverter<string, Addons::BillingModel>(),
            new ApiEnumConverter<string, Addons::PricePeriodBillingPeriod>(),
            new ApiEnumConverter<string, Addons::CreditGrantCadence>(),
            new ApiEnumConverter<string, Addons::PriceCurrency>(),
            new ApiEnumConverter<string, Addons::FlatPriceCurrency>(),
            new ApiEnumConverter<string, Addons::UnitPriceCurrency>(),
            new ApiEnumConverter<string, Addons::BillingCadence>(),
            new ApiEnumConverter<string, Addons::AccordingTo>(),
            new ApiEnumConverter<string, Addons::ResetPeriod>(),
            new ApiEnumConverter<string, Addons::WeeklyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Addons::YearlyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Addons::PricingModelBillingModel>(),
            new ApiEnumConverter<string, Addons::PricingModelPricePeriodBillingPeriod>(),
            new ApiEnumConverter<string, Addons::PricingModelPricePeriodCreditGrantCadence>(),
            new ApiEnumConverter<string, Addons::PricingModelPricePeriodPriceCurrency>(),
            new ApiEnumConverter<string, Addons::PricingModelPricePeriodTierFlatPriceCurrency>(),
            new ApiEnumConverter<string, Addons::PricingModelPricePeriodTierUnitPriceCurrency>(),
            new ApiEnumConverter<string, Addons::PricingModelBillingCadence>(),
            new ApiEnumConverter<
                string,
                Addons::PricingModelMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Addons::PricingModelResetPeriod>(),
            new ApiEnumConverter<string, Addons::TiersMode>(),
            new ApiEnumConverter<
                string,
                Addons::PricingModelWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Addons::PricingModelYearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Entitlements::DataFeatureBehavior>(),
            new ApiEnumConverter<string, Entitlements::DataFeatureHiddenFromWidget>(),
            new ApiEnumConverter<string, Entitlements::DataFeatureResetPeriod>(),
            new ApiEnumConverter<string, Entitlements::YearlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::MonthlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::WeeklyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::DataCreditBehavior>(),
            new ApiEnumConverter<string, Entitlements::DataCreditCadence>(),
            new ApiEnumConverter<string, Entitlements::DataCreditHiddenFromWidget>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataFeatureBehavior
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataFeatureHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataFeatureResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataCreditBehavior
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataCreditCadence
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataCreditHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataFeatureBehavior
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataFeatureHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataFeatureResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<string, Entitlements::EntitlementListResponseDataCreditBehavior>(),
            new ApiEnumConverter<string, Entitlements::EntitlementListResponseDataCreditCadence>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataCreditHiddenFromWidget
            >(),
            new ApiEnumConverter<string, Entitlements::Behavior>(),
            new ApiEnumConverter<string, Entitlements::HiddenFromWidget>(),
            new ApiEnumConverter<string, Entitlements::AccordingTo>(),
            new ApiEnumConverter<string, Entitlements::ResetPeriod>(),
            new ApiEnumConverter<string, Entitlements::WeeklyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::YearlyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::Cadence>(),
            new ApiEnumConverter<string, Entitlements::CreditBehavior>(),
            new ApiEnumConverter<string, Entitlements::CreditHiddenFromWidget>(),
            new ApiEnumConverter<string, Entitlements::BodyFeatureBehavior>(),
            new ApiEnumConverter<string, Entitlements::BodyFeatureHiddenFromWidget>(),
            new ApiEnumConverter<
                string,
                Entitlements::BodyFeatureMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Entitlements::BodyFeatureResetPeriod>(),
            new ApiEnumConverter<
                string,
                Entitlements::BodyFeatureWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::BodyFeatureYearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Entitlements::BodyCreditBehavior>(),
            new ApiEnumConverter<string, Entitlements::BodyCreditCadence>(),
            new ApiEnumConverter<string, Entitlements::BodyCreditHiddenFromWidget>(),
            new ApiEnumConverter<string, Plans::DataDefaultTrialConfigUnits>(),
            new ApiEnumConverter<string, Plans::DataDefaultTrialConfigTrialEndBehavior>(),
            new ApiEnumConverter<string, Plans::Type>(),
            new ApiEnumConverter<string, Plans::DataPricingType>(),
            new ApiEnumConverter<string, Plans::DataStatus>(),
            new ApiEnumConverter<string, Plans::PlanListResponseDefaultTrialConfigUnits>(),
            new ApiEnumConverter<
                string,
                Plans::PlanListResponseDefaultTrialConfigTrialEndBehavior
            >(),
            new ApiEnumConverter<string, Plans::PlanListResponseEntitlementType>(),
            new ApiEnumConverter<string, Plans::PlanListResponsePricingType>(),
            new ApiEnumConverter<string, Plans::PlanListResponseStatus>(),
            new ApiEnumConverter<string, Plans::Units>(),
            new ApiEnumConverter<string, Plans::TrialEndBehavior>(),
            new ApiEnumConverter<string, Plans::PricingType>(),
            new ApiEnumConverter<string, Plans::Status>(),
            new ApiEnumConverter<string, Plans::PlanUpdateParamsDefaultTrialConfigUnits>(),
            new ApiEnumConverter<
                string,
                Plans::PlanUpdateParamsDefaultTrialConfigTrialEndBehavior
            >(),
            new ApiEnumConverter<string, Plans::MigrationType>(),
            new ApiEnumConverter<string, Plans::PlanSetPricingParamsPricingType>(),
            new ApiEnumConverter<string, Plans::BillingPeriod>(),
            new ApiEnumConverter<string, Plans::Currency>(),
            new ApiEnumConverter<string, Plans::OverageBillingPeriod>(),
            new ApiEnumConverter<string, Plans::BillingModel>(),
            new ApiEnumConverter<string, Plans::PricePeriodBillingPeriod>(),
            new ApiEnumConverter<string, Plans::CreditGrantCadence>(),
            new ApiEnumConverter<string, Plans::PriceCurrency>(),
            new ApiEnumConverter<string, Plans::FlatPriceCurrency>(),
            new ApiEnumConverter<string, Plans::UnitPriceCurrency>(),
            new ApiEnumConverter<string, Plans::BillingCadence>(),
            new ApiEnumConverter<string, Plans::AccordingTo>(),
            new ApiEnumConverter<string, Plans::ResetPeriod>(),
            new ApiEnumConverter<string, Plans::WeeklyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Plans::YearlyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Plans::PricingModelBillingModel>(),
            new ApiEnumConverter<string, Plans::PricingModelPricePeriodBillingPeriod>(),
            new ApiEnumConverter<string, Plans::PricingModelPricePeriodCreditGrantCadence>(),
            new ApiEnumConverter<string, Plans::PricingModelPricePeriodPriceCurrency>(),
            new ApiEnumConverter<string, Plans::PricingModelPricePeriodTierFlatPriceCurrency>(),
            new ApiEnumConverter<string, Plans::PricingModelPricePeriodTierUnitPriceCurrency>(),
            new ApiEnumConverter<string, Plans::PricingModelBillingCadence>(),
            new ApiEnumConverter<
                string,
                Plans::PricingModelMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Plans::PricingModelResetPeriod>(),
            new ApiEnumConverter<string, Plans::TiersMode>(),
            new ApiEnumConverter<
                string,
                Plans::PricingModelWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Plans::PricingModelYearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, PlansEntitlements::DataFeatureBehavior>(),
            new ApiEnumConverter<string, PlansEntitlements::DataFeatureHiddenFromWidget>(),
            new ApiEnumConverter<string, PlansEntitlements::DataFeatureResetPeriod>(),
            new ApiEnumConverter<string, PlansEntitlements::YearlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, PlansEntitlements::MonthlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, PlansEntitlements::WeeklyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, PlansEntitlements::DataCreditBehavior>(),
            new ApiEnumConverter<string, PlansEntitlements::DataCreditCadence>(),
            new ApiEnumConverter<string, PlansEntitlements::DataCreditHiddenFromWidget>(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataFeatureBehavior
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataFeatureHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataFeatureResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataCreditBehavior
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataCreditCadence
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataCreditHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataFeatureBehavior
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataFeatureHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataFeatureResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataFeatureResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataFeatureResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataFeatureResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataCreditBehavior
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataCreditCadence
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataCreditHiddenFromWidget
            >(),
            new ApiEnumConverter<string, PlansEntitlements::Behavior>(),
            new ApiEnumConverter<string, PlansEntitlements::HiddenFromWidget>(),
            new ApiEnumConverter<string, PlansEntitlements::AccordingTo>(),
            new ApiEnumConverter<string, PlansEntitlements::ResetPeriod>(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::WeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::YearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, PlansEntitlements::Cadence>(),
            new ApiEnumConverter<string, PlansEntitlements::CreditBehavior>(),
            new ApiEnumConverter<string, PlansEntitlements::CreditHiddenFromWidget>(),
            new ApiEnumConverter<string, PlansEntitlements::BodyFeatureBehavior>(),
            new ApiEnumConverter<string, PlansEntitlements::BodyFeatureHiddenFromWidget>(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::BodyFeatureMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, PlansEntitlements::BodyFeatureResetPeriod>(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::BodyFeatureWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::BodyFeatureYearlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, PlansEntitlements::BodyCreditBehavior>(),
            new ApiEnumConverter<string, PlansEntitlements::BodyCreditCadence>(),
            new ApiEnumConverter<string, PlansEntitlements::BodyCreditHiddenFromWidget>(),
            new ApiEnumConverter<string, Usage::Type>(),
            new ApiEnumConverter<string, Usage::UpdateBehavior>(),
            new ApiEnumConverter<string, Products::Status>(),
            new ApiEnumConverter<
                string,
                Products::DataProductSettingsSubscriptionCancellationTime
            >(),
            new ApiEnumConverter<string, Products::DataProductSettingsSubscriptionEndSetup>(),
            new ApiEnumConverter<string, Products::DataProductSettingsSubscriptionStartSetup>(),
            new ApiEnumConverter<string, Products::ProductListProductsResponseStatus>(),
            new ApiEnumConverter<
                string,
                Products::ProductListProductsResponseProductSettingsSubscriptionCancellationTime
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductListProductsResponseProductSettingsSubscriptionEndSetup
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductListProductsResponseProductSettingsSubscriptionStartSetup
            >(),
            new ApiEnumConverter<string, Products::SubscriptionCancellationTime>(),
            new ApiEnumConverter<string, Products::SubscriptionEndSetup>(),
            new ApiEnumConverter<string, Products::SubscriptionStartSetup>(),
            new ApiEnumConverter<string, Products::Behavior>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="StiggInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
