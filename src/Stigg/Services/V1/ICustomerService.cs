using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Core;
using Stigg.Models.V1.Customers;
using Stigg.Services.V1.Customers;

namespace Stigg.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPaymentMethodService PaymentMethod { get; }

    IUsageService Usage { get; }

    /// <summary>
    /// Create a new Customer
    /// </summary>
    Task<CustomerResponse> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single Customer by id
    /// </summary>
    Task<CustomerResponse> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CustomerRetrieveParams, CancellationToken)"/>
    Task<CustomerResponse> Retrieve(
        string id,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing Customer
    /// </summary>
    Task<CustomerResponse> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomerUpdateParams, CancellationToken)"/>
    Task<CustomerResponse> Update(
        string id,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of Customers
    /// </summary>
    Task<CustomerListResponse> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform archive on a Customer
    /// </summary>
    Task<CustomerResponse> Archive(
        CustomerArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CustomerArchiveParams, CancellationToken)"/>
    Task<CustomerResponse> Archive(
        string id,
        CustomerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform unarchive on a Customer
    /// </summary>
    Task<CustomerResponse> Unarchive(
        CustomerUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(CustomerUnarchiveParams, CancellationToken)"/>
    Task<CustomerResponse> Unarchive(
        string id,
        CustomerUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICustomerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPaymentMethodServiceWithRawResponse PaymentMethod { get; }

    IUsageServiceWithRawResponse Usage { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/customers`, but is otherwise the
    /// same as <see cref="ICustomerService.Create(CustomerCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/customers/{id}`, but is otherwise the
    /// same as <see cref="ICustomerService.Retrieve(CustomerRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CustomerRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Retrieve(
        string id,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /api/v1/customers/{id}`, but is otherwise the
    /// same as <see cref="ICustomerService.Update(CustomerUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomerUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Update(
        string id,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/customers`, but is otherwise the
    /// same as <see cref="ICustomerService.List(CustomerListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerListResponse>> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/customers/{id}/archive`, but is otherwise the
    /// same as <see cref="ICustomerService.Archive(CustomerArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Archive(
        CustomerArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CustomerArchiveParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Archive(
        string id,
        CustomerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/customers/{id}/unarchive`, but is otherwise the
    /// same as <see cref="ICustomerService.Unarchive(CustomerUnarchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Unarchive(
        CustomerUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(CustomerUnarchiveParams, CancellationToken)"/>
    Task<HttpResponse<CustomerResponse>> Unarchive(
        string id,
        CustomerUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
