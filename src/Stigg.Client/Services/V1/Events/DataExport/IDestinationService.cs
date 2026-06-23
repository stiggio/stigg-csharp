using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.DataExport.Destinations;

namespace Stigg.Client.Services.V1.Events.DataExport;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDestinationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDestinationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDestinationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Register a destination on the environment's DATA_EXPORT integration.
    /// Lazy-creates the integration row + provider recipient on first call. Idempotent
    /// on destinationId.
    /// </summary>
    Task<DestinationCreateResponse> Create(
        DestinationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a destination's entity selection. Pushes the new enabled_models to the
    /// provider first, then persists the selection. Applies on the next scheduled
    /// transfer.
    /// </summary>
    Task<DestinationUpdateResponse> Update(
        DestinationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DestinationUpdateParams, CancellationToken)"/>
    Task<DestinationUpdateResponse> Update(
        string destinationID,
        DestinationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a destination from the DATA_EXPORT integration metadata. Idempotent.
    /// </summary>
    Task<DestinationDeleteResponse> Delete(
        DestinationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DestinationDeleteParams, CancellationToken)"/>
    Task<DestinationDeleteResponse> Delete(
        string destinationID,
        DestinationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDestinationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDestinationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDestinationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/data-export/destinations</c>, but is otherwise the
    /// same as <see cref="IDestinationService.Create(DestinationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DestinationCreateResponse>> Create(
        DestinationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/data-export/destinations/{destinationId}</c>, but is otherwise the
    /// same as <see cref="IDestinationService.Update(DestinationUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DestinationUpdateResponse>> Update(
        DestinationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DestinationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DestinationUpdateResponse>> Update(
        string destinationID,
        DestinationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/data-export/destinations/{destinationId}</c>, but is otherwise the
    /// same as <see cref="IDestinationService.Delete(DestinationDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DestinationDeleteResponse>> Delete(
        DestinationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DestinationDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DestinationDeleteResponse>> Delete(
        string destinationID,
        DestinationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
