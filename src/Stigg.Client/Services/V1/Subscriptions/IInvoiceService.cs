using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions.Invoice;

namespace Stigg.Client.Services.V1.Subscriptions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Marks the latest invoice of a subscription as paid in the billing provider.
    /// The invoice must exist and have an OPEN status.
    /// </summary>
    Task<InvoiceMarkAsPaidResponse> MarkAsPaid(
        InvoiceMarkAsPaidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MarkAsPaid(InvoiceMarkAsPaidParams, CancellationToken)"/>
    Task<InvoiceMarkAsPaidResponse> MarkAsPaid(
        string id,
        InvoiceMarkAsPaidParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/{id}/invoice/paid`, but is otherwise the
    /// same as <see cref="IInvoiceService.MarkAsPaid(InvoiceMarkAsPaidParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvoiceMarkAsPaidResponse>> MarkAsPaid(
        InvoiceMarkAsPaidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MarkAsPaid(InvoiceMarkAsPaidParams, CancellationToken)"/>
    Task<HttpResponse<InvoiceMarkAsPaidResponse>> MarkAsPaid(
        string id,
        InvoiceMarkAsPaidParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
