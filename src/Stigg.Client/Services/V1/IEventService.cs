using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events;
using Stigg.Client.Services.V1.Events;

namespace Stigg.Client.Services.V1;

/// <summary>
/// Operations related to usage &amp; metering
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDataExportService DataExport { get; }

    IBetaService Beta { get; }

    /// <summary>
    /// Estimates the credit cost of a usage event without ingesting it. Returns the
    /// estimated cost per credit currency, the current balance, and the balance after
    /// the estimated consumption.
    /// </summary>
    Task<EventEstimateResponse> Estimate(
        EventEstimateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reports raw usage events for event-based metering. Events are ingested
    /// asynchronously and aggregated into usage totals.
    /// </summary>
    Task<EventReportResponse> Report(
        EventReportParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDataExportServiceWithRawResponse DataExport { get; }

    IBetaServiceWithRawResponse Beta { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/events/estimate</c>, but is otherwise the
    /// same as <see cref="IEventService.Estimate(EventEstimateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventEstimateResponse>> Estimate(
        EventEstimateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/events</c>, but is otherwise the
    /// same as <see cref="IEventService.Report(EventReportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventReportResponse>> Report(
        EventReportParams parameters,
        CancellationToken cancellationToken = default
    );
}
