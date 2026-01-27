using System.Text.Json;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1;
using Stigg.Client.Models.V1.Customers;
using Coupons = Stigg.Client.Models.V1.Coupons;
using CustomersUsage = Stigg.Client.Models.V1.Customers.Usage;
using PaymentMethod = Stigg.Client.Models.V1.Customers.PaymentMethod;
using Subscriptions = Stigg.Client.Models.V1.Subscriptions;

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
            new ApiEnumConverter<string, UpdateBehavior>(),
            new ApiEnumConverter<string, DataDefaultPaymentMethodType>(),
            new ApiEnumConverter<string, DataIntegrationVendorIdentifier>(),
            new ApiEnumConverter<string, CustomerListResponseDefaultPaymentMethodType>(),
            new ApiEnumConverter<string, CustomerListResponseIntegrationVendorIdentifier>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, VendorIdentifier>(),
            new ApiEnumConverter<string, CustomerUpdateParamsIntegrationVendorIdentifier>(),
            new ApiEnumConverter<string, PaymentMethod::VendorIdentifier>(),
            new ApiEnumConverter<string, PaymentMethod::BillingCurrency>(),
            new ApiEnumConverter<string, CustomersUsage::Type>(),
            new ApiEnumConverter<string, Subscriptions::Status>(),
            new ApiEnumConverter<string, Subscriptions::PaymentCollection>(),
            new ApiEnumConverter<string, Subscriptions::PricingType>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionStatus>(),
            new ApiEnumConverter<string, Subscriptions::CancelReason>(),
            new ApiEnumConverter<string, Subscriptions::PaymentCollectionMethod>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionRetrieveResponseDataPaymentCollection
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionRetrieveResponseDataPricingType
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionRetrieveResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionRetrieveResponseDataCancelReason
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionRetrieveResponseDataPaymentCollectionMethod
            >(),
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
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionDelegateResponseDataPaymentCollection
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionDelegateResponseDataPricingType
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionDelegateResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionDelegateResponseDataCancelReason
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionDelegateResponseDataPaymentCollectionMethod
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionMigrateResponseDataPaymentCollection
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionMigrateResponseDataPricingType
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionMigrateResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionMigrateResponseDataCancelReason
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionMigrateResponseDataPaymentCollectionMethod
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionTransferResponseDataPaymentCollection
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionTransferResponseDataPricingType
            >(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionTransferResponseDataStatus>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionTransferResponseDataCancelReason
            >(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionTransferResponseDataPaymentCollectionMethod
            >(),
            new ApiEnumConverter<string, Subscriptions::BillingPeriod>(),
            new ApiEnumConverter<string, Subscriptions::TrialEndBehavior>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionMigrationTime>(),
            new ApiEnumConverter<string, Subscriptions::Currency>(),
            new ApiEnumConverter<string, Subscriptions::ProrationBehavior>(),
            new ApiEnumConverter<string, Subscriptions::SubscriptionPreviewParamsBillingPeriod>(),
            new ApiEnumConverter<string, Subscriptions::Type>(),
            new ApiEnumConverter<string, Subscriptions::ScheduleStrategy>(),
            new ApiEnumConverter<
                string,
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
            >(),
            new ApiEnumConverter<string, Coupons::DataAmountsOffCurrency>(),
            new ApiEnumConverter<string, Coupons::Source>(),
            new ApiEnumConverter<string, Coupons::Status>(),
            new ApiEnumConverter<string, Coupons::Type>(),
            new ApiEnumConverter<string, Coupons::CouponRetrieveResponseDataAmountsOffCurrency>(),
            new ApiEnumConverter<string, Coupons::CouponRetrieveResponseDataSource>(),
            new ApiEnumConverter<string, Coupons::CouponRetrieveResponseDataStatus>(),
            new ApiEnumConverter<string, Coupons::CouponRetrieveResponseDataType>(),
            new ApiEnumConverter<string, Coupons::CouponListResponseAmountsOffCurrency>(),
            new ApiEnumConverter<string, Coupons::CouponListResponseSource>(),
            new ApiEnumConverter<string, Coupons::CouponListResponseStatus>(),
            new ApiEnumConverter<string, Coupons::CouponListResponseType>(),
            new ApiEnumConverter<string, Coupons::Currency>(),
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
