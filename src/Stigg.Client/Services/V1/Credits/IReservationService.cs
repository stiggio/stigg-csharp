using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.Reservations;

namespace Stigg.Client.Services.V1.Credits;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IReservationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReservationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReservationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Releases a credit reservation, consuming the given amount and returning the rest
    /// of the held credits to the balance. Retry a failed release with the same
    /// reservation ID; it is applied once.
    /// </summary>
    Task<ReservationReleaseResponse> Release(
        ReservationReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(ReservationReleaseParams, CancellationToken)"/>
    Task<ReservationReleaseResponse> Release(
        string reservationID,
        ReservationReleaseParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IReservationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReservationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReservationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/credits/reservations/{reservationId}/release</c>, but is otherwise the
    /// same as <see cref="IReservationService.Release(ReservationReleaseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReservationReleaseResponse>> Release(
        ReservationReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(ReservationReleaseParams, CancellationToken)"/>
    Task<HttpResponse<ReservationReleaseResponse>> Release(
        string reservationID,
        ReservationReleaseParams parameters,
        CancellationToken cancellationToken = default
    );
}
