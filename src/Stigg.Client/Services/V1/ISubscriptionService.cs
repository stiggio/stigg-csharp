using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions;
using Subscriptions = Stigg.Client.Services.V1.Subscriptions;

namespace Stigg.Client.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISubscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Subscriptions::IFutureUpdateService FutureUpdate { get; }

    Subscriptions::IUsageService Usage { get; }

    Subscriptions::IInvoiceService Invoice { get; }

    /// <summary>
    /// Retrieves a subscription by its unique identifier, including plan details,
    /// billing period, status, and add-ons.
    /// </summary>
    Task<SubscriptionSubscription> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>
    Task<SubscriptionSubscription> Retrieve(
        string id,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an active subscription's properties including billing period, add-ons,
    /// unit quantities, and discounts.
    /// </summary>
    Task<SubscriptionSubscription> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task<SubscriptionSubscription> Update(
        string id,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of subscriptions, with optional filters for customer,
    /// status, and plan.
    /// </summary>
    Task<SubscriptionListPage> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an active subscription, either immediately or at a specified time such
    /// as end of billing period.
    /// </summary>
    Task<SubscriptionSubscription> Cancel(
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(SubscriptionCancelParams, CancellationToken)"/>
    Task<SubscriptionSubscription> Cancel(
        string id,
        SubscriptionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delegates the payment responsibility of a subscription to a different customer.
    /// The delegated customer will be billed for this subscription.
    /// </summary>
    Task<SubscriptionSubscription> Delegate(
        SubscriptionDelegateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delegate(SubscriptionDelegateParams, CancellationToken)"/>
    Task<SubscriptionSubscription> Delegate(
        string id,
        SubscriptionDelegateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Imports multiple subscriptions in bulk. Used for migrating subscription data
    /// from external systems.
    /// </summary>
    Task<SubscriptionImportResponse> Import(
        SubscriptionImportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Migrates a subscription to the latest published version of its plan or add-ons.
    /// Handles prorated charges or credits automatically.
    /// </summary>
    Task<SubscriptionSubscription> Migrate(
        SubscriptionMigrateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Migrate(SubscriptionMigrateParams, CancellationToken)"/>
    Task<SubscriptionSubscription> Migrate(
        string id,
        SubscriptionMigrateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Previews the pricing impact of creating or updating a subscription without
    /// making changes. Returns estimated costs, taxes, and proration details.
    /// </summary>
    Task<SubscriptionPreviewResponse> Preview(
        SubscriptionPreviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new subscription for an existing customer. When payment is required
    /// and no payment method exists, returns a checkout URL.
    /// </summary>
    Task<SubscriptionProvisionResponse> Provision(
        SubscriptionProvisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Transfers a subscription to a different resource ID. Used for multi-resource
    /// products where subscriptions apply to specific entities like websites or apps.
    /// </summary>
    Task<SubscriptionSubscription> Transfer(
        SubscriptionTransferParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Transfer(SubscriptionTransferParams, CancellationToken)"/>
    Task<SubscriptionSubscription> Transfer(
        string id,
        SubscriptionTransferParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISubscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubscriptionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Subscriptions::IFutureUpdateServiceWithRawResponse FutureUpdate { get; }

    Subscriptions::IUsageServiceWithRawResponse Usage { get; }

    Subscriptions::IInvoiceServiceWithRawResponse Invoice { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/subscriptions/{id}</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionSubscription>> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubscriptionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionSubscription>> Retrieve(
        string id,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/subscriptions/{id}</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Update(SubscriptionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionSubscription>> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubscriptionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionSubscription>> Update(
        string id,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/subscriptions</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.List(SubscriptionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionListPage>> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/subscriptions/{id}/cancel</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Cancel(SubscriptionCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionSubscription>> Cancel(
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(SubscriptionCancelParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionSubscription>> Cancel(
        string id,
        SubscriptionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/subscriptions/{id}/delegate</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Delegate(SubscriptionDelegateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionSubscription>> Delegate(
        SubscriptionDelegateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delegate(SubscriptionDelegateParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionSubscription>> Delegate(
        string id,
        SubscriptionDelegateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/subscriptions/import</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Import(SubscriptionImportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionImportResponse>> Import(
        SubscriptionImportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/subscriptions/{id}/migrate</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Migrate(SubscriptionMigrateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionSubscription>> Migrate(
        SubscriptionMigrateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Migrate(SubscriptionMigrateParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionSubscription>> Migrate(
        string id,
        SubscriptionMigrateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/subscriptions/preview</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Preview(SubscriptionPreviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionPreviewResponse>> Preview(
        SubscriptionPreviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/subscriptions</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Provision(SubscriptionProvisionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionProvisionResponse>> Provision(
        SubscriptionProvisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/subscriptions/{id}/transfer</c>, but is otherwise the
    /// same as <see cref="ISubscriptionService.Transfer(SubscriptionTransferParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionSubscription>> Transfer(
        SubscriptionTransferParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Transfer(SubscriptionTransferParams, CancellationToken)"/>
    Task<HttpResponse<SubscriptionSubscription>> Transfer(
        string id,
        SubscriptionTransferParams parameters,
        CancellationToken cancellationToken = default
    );
}
