using System.Text.Json;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;
using Stigg.Client.Models.V1.Features;
using Addons = Stigg.Client.Models.V1.Addons;
using Coupons = Stigg.Client.Models.V1.Coupons;
using Entitlements = Stigg.Client.Models.V1.Addons.Entitlements;
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
            new ApiEnumConverter<string, DataDefaultPaymentMethodType>(),
            new ApiEnumConverter<string, DataIntegrationVendorIdentifier>(),
            new ApiEnumConverter<string, CustomerListResponseDefaultPaymentMethodType>(),
            new ApiEnumConverter<string, CustomerListResponseIntegrationVendorIdentifier>(),
            new ApiEnumConverter<string, VendorIdentifier>(),
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
            new ApiEnumConverter<string, Subscriptions::DataPaymentCollectionMethod>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponsePaymentCollection
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionListResponsePricingType>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionListResponseStatus>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionListResponseCancelReason>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionListResponsePaymentCollectionMethod
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
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPaymentCollectionMethod
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPricePriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPriceTierFlatPriceCurrency
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionResponseDataSubscriptionPriceTierUnitPriceCurrency
            >(),
            new ApiEnumConverter<string, Subscriptions::Currency>(),
            new ApiEnumConverter<string, Subscriptions::BillingCycleAnchor>(),
            new ApiEnumConverter<string, Subscriptions::ProrationBehavior>(),
            new ApiEnumConverter<string, Subscriptions::BillingPeriod>(),
            new ApiEnumConverter<string, Subscriptions::Type>(),
            new ApiEnumConverter<string, Subscriptions::MinimumCurrency>(),
            new ApiEnumConverter<string, Subscriptions::PriceCurrency>(),
            new ApiEnumConverter<string, Subscriptions::ScheduleStrategy>(),
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
                Subscriptions::SubscriptionProvisionParamsMinimumSpendMinimumCurrency
            >(),
            new ApiEnumConverter<string, Subscriptions::PaymentCollectionMethod>(),
            new ApiEnumConverter<string, Subscriptions::CreditGrantCadence>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionProvisionParamsPriceOverridePriceCurrency
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
            new ApiEnumConverter<string, Entitlements::DataBehavior>(),
            new ApiEnumConverter<string, Entitlements::DataCadence>(),
            new ApiEnumConverter<string, Entitlements::DataHiddenFromWidget>(),
            new ApiEnumConverter<string, Entitlements::DataResetPeriod>(),
            new ApiEnumConverter<string, Entitlements::YearlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::MonthlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::WeeklyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::Type>(),
            new ApiEnumConverter<string, Entitlements::EntitlementCreateResponseDataBehavior>(),
            new ApiEnumConverter<string, Entitlements::EntitlementCreateResponseDataCadence>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataHiddenFromWidget
            >(),
            new ApiEnumConverter<string, Entitlements::EntitlementCreateResponseDataResetPeriod>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<string, Entitlements::EntitlementCreateResponseDataType>(),
            new ApiEnumConverter<string, Entitlements::EntitlementListResponseDataBehavior>(),
            new ApiEnumConverter<string, Entitlements::EntitlementListResponseDataCadence>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataHiddenFromWidget
            >(),
            new ApiEnumConverter<string, Entitlements::EntitlementListResponseDataResetPeriod>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<string, Entitlements::EntitlementListResponseDataType>(),
            new ApiEnumConverter<string, Entitlements::Cadence>(),
            new ApiEnumConverter<string, Entitlements::Behavior>(),
            new ApiEnumConverter<string, Entitlements::HiddenFromWidget>(),
            new ApiEnumConverter<string, Entitlements::FeatureBehavior>(),
            new ApiEnumConverter<string, Entitlements::FeatureHiddenFromWidget>(),
            new ApiEnumConverter<string, Entitlements::AccordingTo>(),
            new ApiEnumConverter<string, Entitlements::ResetPeriod>(),
            new ApiEnumConverter<string, Entitlements::WeeklyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::YearlyResetPeriodConfigurationAccordingTo>(),
            new ApiEnumConverter<string, Entitlements::EntitlementUpdateParamsCreditBehavior>(),
            new ApiEnumConverter<string, Entitlements::EntitlementUpdateParamsCreditCadence>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementUpdateParamsCreditHiddenFromWidget
            >(),
            new ApiEnumConverter<string, Entitlements::EntitlementUpdateParamsFeatureBehavior>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementUpdateParamsFeatureHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<string, Entitlements::EntitlementUpdateParamsFeatureResetPeriod>(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                Entitlements::EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
            >(),
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
            new ApiEnumConverter<string, PlansEntitlements::DataBehavior>(),
            new ApiEnumConverter<string, PlansEntitlements::DataCadence>(),
            new ApiEnumConverter<string, PlansEntitlements::DataHiddenFromWidget>(),
            new ApiEnumConverter<string, PlansEntitlements::DataResetPeriod>(),
            new ApiEnumConverter<string, PlansEntitlements::YearlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, PlansEntitlements::MonthlyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, PlansEntitlements::WeeklyResetPeriodConfigAccordingTo>(),
            new ApiEnumConverter<string, PlansEntitlements::Type>(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataBehavior
            >(),
            new ApiEnumConverter<string, PlansEntitlements::EntitlementCreateResponseDataCadence>(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementCreateResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<string, PlansEntitlements::EntitlementCreateResponseDataType>(),
            new ApiEnumConverter<string, PlansEntitlements::EntitlementListResponseDataBehavior>(),
            new ApiEnumConverter<string, PlansEntitlements::EntitlementListResponseDataCadence>(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataResetPeriodConfigurationYearlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataResetPeriodConfigurationMonthlyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementListResponseDataResetPeriodConfigurationWeeklyResetPeriodConfigAccordingTo
            >(),
            new ApiEnumConverter<string, PlansEntitlements::EntitlementListResponseDataType>(),
            new ApiEnumConverter<string, PlansEntitlements::Cadence>(),
            new ApiEnumConverter<string, PlansEntitlements::Behavior>(),
            new ApiEnumConverter<string, PlansEntitlements::HiddenFromWidget>(),
            new ApiEnumConverter<string, PlansEntitlements::FeatureBehavior>(),
            new ApiEnumConverter<string, PlansEntitlements::FeatureHiddenFromWidget>(),
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
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementUpdateParamsCreditBehavior
            >(),
            new ApiEnumConverter<string, PlansEntitlements::EntitlementUpdateParamsCreditCadence>(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementUpdateParamsCreditHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementUpdateParamsFeatureBehavior
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementUpdateParamsFeatureHiddenFromWidget
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementUpdateParamsFeatureMonthlyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementUpdateParamsFeatureResetPeriod
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementUpdateParamsFeatureWeeklyResetPeriodConfigurationAccordingTo
            >(),
            new ApiEnumConverter<
                string,
                PlansEntitlements::EntitlementUpdateParamsFeatureYearlyResetPeriodConfigurationAccordingTo
            >(),
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
