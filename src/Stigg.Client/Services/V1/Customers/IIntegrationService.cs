using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Services.V1.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIntegrationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntegrationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntegrationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves a specific integration for a customer by integration ID.
    /// </summary>
    Task<IntegrationRetrieveResponse> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IntegrationRetrieveParams, CancellationToken)"/>
    Task<IntegrationRetrieveResponse> Retrieve(
        string integrationID,
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a customer's integration link, such as changing the synced external
    /// entity ID.
    /// </summary>
    Task<IntegrationUpdateResponse> Update(
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(IntegrationUpdateParams, CancellationToken)"/>
    Task<IntegrationUpdateResponse> Update(
        string integrationID,
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of a customer's external integrations (billing, CRM,
    /// etc.).
    /// </summary>
    Task<IntegrationListPage> List(
        IntegrationListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(IntegrationListParams, CancellationToken)"/>
    Task<IntegrationListPage> List(
        string id,
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Links a customer to an external integration by specifying the vendor and
    /// external entity ID.
    /// </summary>
    Task<IntegrationLinkResponse> Link(
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Link(IntegrationLinkParams, CancellationToken)"/>
    Task<IntegrationLinkResponse> Link(
        string id,
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes the link between a customer and an external integration.
    /// </summary>
    Task<IntegrationUnlinkResponse> Unlink(
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unlink(IntegrationUnlinkParams, CancellationToken)"/>
    Task<IntegrationUnlinkResponse> Unlink(
        string integrationID,
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIntegrationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntegrationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntegrationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}/integrations/{integrationId}</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.Retrieve(IntegrationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationRetrieveResponse>> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IntegrationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<IntegrationRetrieveResponse>> Retrieve(
        string integrationID,
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/customers/{id}/integrations/{integrationId}</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.Update(IntegrationUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationUpdateResponse>> Update(
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(IntegrationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<IntegrationUpdateResponse>> Update(
        string integrationID,
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}/integrations</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.List(IntegrationListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationListPage>> List(
        IntegrationListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(IntegrationListParams, CancellationToken)"/>
    Task<HttpResponse<IntegrationListPage>> List(
        string id,
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/customers/{id}/integrations</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.Link(IntegrationLinkParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationLinkResponse>> Link(
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Link(IntegrationLinkParams, CancellationToken)"/>
    Task<HttpResponse<IntegrationLinkResponse>> Link(
        string id,
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/customers/{id}/integrations/{integrationId}</c>, but is otherwise the
    /// same as <see cref="IIntegrationService.Unlink(IntegrationUnlinkParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntegrationUnlinkResponse>> Unlink(
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unlink(IntegrationUnlinkParams, CancellationToken)"/>
    Task<HttpResponse<IntegrationUnlinkResponse>> Unlink(
        string integrationID,
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    );
}
