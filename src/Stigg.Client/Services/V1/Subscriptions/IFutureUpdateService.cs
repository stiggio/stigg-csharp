using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions.FutureUpdate;

namespace Stigg.Client.Services.V1.Subscriptions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFutureUpdateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFutureUpdateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFutureUpdateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Perform cancel future update on a Subscription
    /// </summary>
    Task<FutureUpdateCancelPendingPaymentResponse> CancelPendingPayment(
        FutureUpdateCancelPendingPaymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CancelPendingPayment(FutureUpdateCancelPendingPaymentParams, CancellationToken)"/>
    Task<FutureUpdateCancelPendingPaymentResponse> CancelPendingPayment(
        string id,
        FutureUpdateCancelPendingPaymentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform cancel future update on a Subscription
    /// </summary>
    Task<FutureUpdateCancelScheduleResponse> CancelSchedule(
        FutureUpdateCancelScheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CancelSchedule(FutureUpdateCancelScheduleParams, CancellationToken)"/>
    Task<FutureUpdateCancelScheduleResponse> CancelSchedule(
        string id,
        FutureUpdateCancelScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFutureUpdateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFutureUpdateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFutureUpdateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/subscriptions/{id}/future-update/pending-payment`, but is otherwise the
    /// same as <see cref="IFutureUpdateService.CancelPendingPayment(FutureUpdateCancelPendingPaymentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FutureUpdateCancelPendingPaymentResponse>> CancelPendingPayment(
        FutureUpdateCancelPendingPaymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CancelPendingPayment(FutureUpdateCancelPendingPaymentParams, CancellationToken)"/>
    Task<HttpResponse<FutureUpdateCancelPendingPaymentResponse>> CancelPendingPayment(
        string id,
        FutureUpdateCancelPendingPaymentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/subscriptions/{id}/future-update/schedule`, but is otherwise the
    /// same as <see cref="IFutureUpdateService.CancelSchedule(FutureUpdateCancelScheduleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FutureUpdateCancelScheduleResponse>> CancelSchedule(
        FutureUpdateCancelScheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CancelSchedule(FutureUpdateCancelScheduleParams, CancellationToken)"/>
    Task<HttpResponse<FutureUpdateCancelScheduleResponse>> CancelSchedule(
        string id,
        FutureUpdateCancelScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
