using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Addons;
using Stigg.Client.Models.V1.Events.Plans;
using Stigg.Client.Services.V1.Events.Plans;

namespace Stigg.Client.Services.V1.Events;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPlanService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPlanServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDraftService Draft { get; }

    IEntitlementService Entitlements { get; }

    /// <summary>
    /// Creates a new plan in draft status.
    /// </summary>
    Task<Plan> Create(PlanCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a plan by its unique identifier, including entitlements and pricing details.
    /// </summary>
    Task<Plan> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PlanRetrieveParams, CancellationToken)"/>
    Task<Plan> Retrieve(
        string id,
        PlanRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing plan's properties such as display name, description,
    /// and metadata.
    /// </summary>
    Task<Plan> Update(PlanUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(PlanUpdateParams, CancellationToken)"/>
    Task<Plan> Update(
        string id,
        PlanUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of plans in the environment.
    /// </summary>
    Task<PlanListPage> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives a plan, preventing it from being used in new subscriptions.
    /// </summary>
    Task<Plan> Archive(PlanArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(PlanArchiveParams, CancellationToken)"/>
    Task<Plan> Archive(
        string id,
        PlanArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publishes a draft plan, making it available for use in subscriptions.
    /// </summary>
    Task<PlanPublishResponse> Publish(
        PlanPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(PlanPublishParams, CancellationToken)"/>
    Task<PlanPublishResponse> Publish(
        string id,
        PlanPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets the pricing configuration for a plan, including pricing models, overage
    /// pricing, and minimum spend.
    /// </summary>
    Task<SetPackagePricingResponse> SetPricing(
        PlanSetPricingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetPricing(PlanSetPricingParams, CancellationToken)"/>
    Task<SetPackagePricingResponse> SetPricing(
        string id,
        PlanSetPricingParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPlanService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPlanServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDraftServiceWithRawResponse Draft { get; }

    IEntitlementServiceWithRawResponse Entitlements { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/plans`, but is otherwise the
    /// same as <see cref="IPlanService.Create(PlanCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Plan>> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/plans/{id}`, but is otherwise the
    /// same as <see cref="IPlanService.Retrieve(PlanRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Plan>> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PlanRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Plan>> Retrieve(
        string id,
        PlanRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /api/v1/plans/{id}`, but is otherwise the
    /// same as <see cref="IPlanService.Update(PlanUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Plan>> Update(
        PlanUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PlanUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Plan>> Update(
        string id,
        PlanUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/plans`, but is otherwise the
    /// same as <see cref="IPlanService.List(PlanListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanListPage>> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/plans/{id}/archive`, but is otherwise the
    /// same as <see cref="IPlanService.Archive(PlanArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Plan>> Archive(
        PlanArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(PlanArchiveParams, CancellationToken)"/>
    Task<HttpResponse<Plan>> Archive(
        string id,
        PlanArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/plans/{id}/publish`, but is otherwise the
    /// same as <see cref="IPlanService.Publish(PlanPublishParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanPublishResponse>> Publish(
        PlanPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(PlanPublishParams, CancellationToken)"/>
    Task<HttpResponse<PlanPublishResponse>> Publish(
        string id,
        PlanPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /api/v1/plans/{id}/charges`, but is otherwise the
    /// same as <see cref="IPlanService.SetPricing(PlanSetPricingParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SetPackagePricingResponse>> SetPricing(
        PlanSetPricingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetPricing(PlanSetPricingParams, CancellationToken)"/>
    Task<HttpResponse<SetPackagePricingResponse>> SetPricing(
        string id,
        PlanSetPricingParams parameters,
        CancellationToken cancellationToken = default
    );
}
