using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers;
using Stigg.Client.Models.V1.Customers.PaymentMethod;

namespace Stigg.Client.Services.V1.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPaymentMethodService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPaymentMethodServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaymentMethodService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Attach payment method
    /// </summary>
    Task<CustomerResponse> Attach(
        PaymentMethodAttachParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Attach(PaymentMethodAttachParams, CancellationToken)"/>
    Task<CustomerResponse> Attach(
        string id,
        PaymentMethodAttachParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Detach payment method
    /// </summary>
    Task<CustomerResponse> Detach(
        PaymentMethodDetachParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Detach(PaymentMethodDetachParams, CancellationToken)"/>
    Task<CustomerResponse> Detach(
        string id,
        PaymentMethodDetachParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPaymentMethodService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPaymentMethodServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPaymentMethodServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/customers/{id}/payment-method`, but is otherwise the
    /// same as <see cref="IPaymentMethodService.Attach(PaymentMethodAttachParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Attach(
        PaymentMethodAttachParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Attach(PaymentMethodAttachParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Attach(
        string id,
        PaymentMethodAttachParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/customers/{id}/payment-method`, but is otherwise the
    /// same as <see cref="IPaymentMethodService.Detach(PaymentMethodDetachParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Detach(
        PaymentMethodDetachParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Detach(PaymentMethodDetachParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Detach(
        string id,
        PaymentMethodDetachParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
