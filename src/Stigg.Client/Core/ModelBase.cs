using System.Text.Json;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;
using Stigg.Client.Models.V1.Events.Features;
using Addons = Stigg.Client.Models.V1.Events.Addons;
using Coupons = Stigg.Client.Models.V1.Coupons;
using Draft = Stigg.Client.Models.V1.Events.Addons.Draft;
using PaymentMethod = Stigg.Client.Models.V1.Customers.PaymentMethod;
using Plans = Stigg.Client.Models.V1.Events.Plans;
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
            new ApiEnumConverter<string, Subscriptions::UnionMember0Type>(),
            new ApiEnumConverter<string, Subscriptions::FeatureStatus>(),
            new ApiEnumConverter<string, Subscriptions::FeatureType>(),
            new ApiEnumConverter<string, Subscriptions::UnionMember0ResetPeriod>(),
            new ApiEnumConverter<string, Subscriptions::UnionMember1AccessDeniedReason>(),
            new ApiEnumConverter<string, Subscriptions::UnionMember1Type>(),
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
            new ApiEnumConverter<string, Subscriptions::SubscriptionMigrationTime>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency
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
            new ApiEnumConverter<string, FeatureCreateFeatureResponseDataFeatureStatus>(),
            new ApiEnumConverter<string, FeatureCreateFeatureResponseDataFeatureType>(),
            new ApiEnumConverter<string, FeatureCreateFeatureResponseDataMeterType>(),
            new ApiEnumConverter<string, FeatureCreateFeatureResponseDataUnitTransformationRound>(),
            new ApiEnumConverter<string, FeatureListFeaturesResponseFeatureStatus>(),
            new ApiEnumConverter<string, FeatureListFeaturesResponseFeatureType>(),
            new ApiEnumConverter<string, FeatureListFeaturesResponseMeterType>(),
            new ApiEnumConverter<string, FeatureListFeaturesResponseUnitTransformationRound>(),
            new ApiEnumConverter<string, FeatureRetrieveFeatureResponseDataFeatureStatus>(),
            new ApiEnumConverter<string, FeatureRetrieveFeatureResponseDataFeatureType>(),
            new ApiEnumConverter<string, FeatureRetrieveFeatureResponseDataMeterType>(),
            new ApiEnumConverter<
                string,
                FeatureRetrieveFeatureResponseDataUnitTransformationRound
            >(),
            new ApiEnumConverter<string, FeatureUnarchiveFeatureResponseDataFeatureStatus>(),
            new ApiEnumConverter<string, FeatureUnarchiveFeatureResponseDataFeatureType>(),
            new ApiEnumConverter<string, FeatureUnarchiveFeatureResponseDataMeterType>(),
            new ApiEnumConverter<
                string,
                FeatureUnarchiveFeatureResponseDataUnitTransformationRound
            >(),
            new ApiEnumConverter<string, FeatureUpdateFeatureResponseDataFeatureStatus>(),
            new ApiEnumConverter<string, FeatureUpdateFeatureResponseDataFeatureType>(),
            new ApiEnumConverter<string, FeatureUpdateFeatureResponseDataMeterType>(),
            new ApiEnumConverter<string, FeatureUpdateFeatureResponseDataUnitTransformationRound>(),
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
            new ApiEnumConverter<string, Addons::AddonCreateAddonResponseDataEntitlementType>(),
            new ApiEnumConverter<string, Addons::AddonCreateAddonResponseDataPricingType>(),
            new ApiEnumConverter<string, Addons::AddonCreateAddonResponseDataStatus>(),
            new ApiEnumConverter<string, Addons::AddonListAddonsResponseEntitlementType>(),
            new ApiEnumConverter<string, Addons::AddonListAddonsResponsePricingType>(),
            new ApiEnumConverter<string, Addons::AddonListAddonsResponseStatus>(),
            new ApiEnumConverter<string, Addons::AddonRetrieveAddonResponseDataEntitlementType>(),
            new ApiEnumConverter<string, Addons::AddonRetrieveAddonResponseDataPricingType>(),
            new ApiEnumConverter<string, Addons::AddonRetrieveAddonResponseDataStatus>(),
            new ApiEnumConverter<string, Addons::AddonUpdateAddonResponseDataEntitlementType>(),
            new ApiEnumConverter<string, Addons::AddonUpdateAddonResponseDataPricingType>(),
            new ApiEnumConverter<string, Addons::AddonUpdateAddonResponseDataStatus>(),
            new ApiEnumConverter<string, Addons::PricingType>(),
            new ApiEnumConverter<string, Addons::Status>(),
            new ApiEnumConverter<string, Addons::MigrationType>(),
            new ApiEnumConverter<string, Draft::Type>(),
            new ApiEnumConverter<string, Draft::PricingType>(),
            new ApiEnumConverter<string, Draft::Status>(),
            new ApiEnumConverter<string, Plans::Type>(),
            new ApiEnumConverter<string, Plans::DataPricingType>(),
            new ApiEnumConverter<string, Plans::DataStatus>(),
            new ApiEnumConverter<string, Plans::PlanRetrieveResponseDataEntitlementType>(),
            new ApiEnumConverter<string, Plans::PlanRetrieveResponseDataPricingType>(),
            new ApiEnumConverter<string, Plans::PlanRetrieveResponseDataStatus>(),
            new ApiEnumConverter<string, Plans::PlanListResponseEntitlementType>(),
            new ApiEnumConverter<string, Plans::PlanListResponsePricingType>(),
            new ApiEnumConverter<string, Plans::PlanListResponseStatus>(),
            new ApiEnumConverter<string, Plans::PricingType>(),
            new ApiEnumConverter<string, Plans::Status>(),
            new ApiEnumConverter<string, Usage::Type>(),
            new ApiEnumConverter<string, Usage::UpdateBehavior>(),
            new ApiEnumConverter<string, Products::Status>(),
            new ApiEnumConverter<
                string,
                Products::DataProductSettingsSubscriptionCancellationTime
            >(),
            new ApiEnumConverter<string, Products::DataProductSettingsSubscriptionEndSetup>(),
            new ApiEnumConverter<string, Products::DataProductSettingsSubscriptionStartSetup>(),
            new ApiEnumConverter<string, Products::ProductCreateProductResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Products::ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup
            >(),
            new ApiEnumConverter<string, Products::ProductDuplicateProductResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Products::ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
            >(),
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
            new ApiEnumConverter<string, Products::ProductUnarchiveProductResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Products::ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
            >(),
            new ApiEnumConverter<string, Products::ProductUpdateProductResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Products::ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup
            >(),
            new ApiEnumConverter<
                string,
                Products::ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup
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
