using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions;
using Stigg.Client.Services.V1.Subscriptions;

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

    IFutureUpdateService FutureUpdate { get; }

    /// <summary>
    /// Get a single subscription by ID
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
    /// Update a subscription
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
    /// Get a list of subscriptions
    /// </summary>
    Task<SubscriptionListPage> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel subscription
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
    /// Delegate subscription payment to customer
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
    /// Bulk import subscriptions
    /// </summary>
    Task<SubscriptionImportResponse> Import(
        SubscriptionImportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Migrate subscription to latest plan version
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
    /// Preview subscription
    /// </summary>
    Task<SubscriptionPreviewResponse> Preview(
        SubscriptionPreviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Provision subscription
    /// </summary>
    Task<SubscriptionProvisionResponse> Provision(
        SubscriptionProvisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Transfer subscription to resource
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

    IFutureUpdateServiceWithRawResponse FutureUpdate { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/subscriptions/{id}`, but is otherwise the
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
    /// Returns a raw HTTP response for `patch /api/v1/subscriptions/{id}`, but is otherwise the
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
    /// Returns a raw HTTP response for `get /api/v1/subscriptions`, but is otherwise the
    /// same as <see cref="ISubscriptionService.List(SubscriptionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionListPage>> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/{id}/cancel`, but is otherwise the
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
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/{id}/delegate`, but is otherwise the
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
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/import`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Import(SubscriptionImportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionImportResponse>> Import(
        SubscriptionImportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/{id}/migrate`, but is otherwise the
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
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/preview`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Preview(SubscriptionPreviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionPreviewResponse>> Preview(
        SubscriptionPreviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/subscriptions`, but is otherwise the
    /// same as <see cref="ISubscriptionService.Provision(SubscriptionProvisionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubscriptionProvisionResponse>> Provision(
        SubscriptionProvisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/{id}/transfer`, but is otherwise the
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
