using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers;
using Stigg.Client.Services.V1.Customers;

namespace Stigg.Client.Services.V1;

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

    IPromotionalEntitlementService PromotionalEntitlements { get; }

    IIntegrationService Integrations { get; }

    /// <summary>
    /// Retrieves a customer by their unique identifier, including billing information
    /// and subscription status.
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
    /// Updates an existing customer's properties such as name, email, and billing
    /// information.
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
    /// Retrieves a paginated list of customers in the environment.
    /// </summary>
    Task<CustomerListPage> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives a customer, preventing new subscriptions. Optionally cancels existing
    /// subscriptions.
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
    /// Checks a single entitlement (feature or credit) for a customer or resource.
    /// Supports `requestedUsage` and `requestedValues` to evaluate against limits or
    /// enum values. Each call reaches the Stigg API directly, so latency reflects a
    /// network round trip. For entitlement checks on a hot path (e.g. gating a request
    /// in real time), the Stigg Node Server SDK (with its built-in cache) or the
    /// Sidecar will typically respond faster and keep working through brief Stigg
    /// outages; reach for this endpoint when a live HTTP call is the natural fit, such
    /// as from a non-Node backend or a server-side job.
    /// </summary>
    Task<CustomerCheckEntitlementResponse> CheckEntitlement(
        CustomerCheckEntitlementParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CheckEntitlement(CustomerCheckEntitlementParams, CancellationToken)"/>
    Task<CustomerCheckEntitlementResponse> CheckEntitlement(
        string id,
        CustomerCheckEntitlementParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Imports multiple customers in bulk. Used for migrating customer data from
    /// external systems.
    /// </summary>
    Task<CustomerImportResponse> Import(
        CustomerImportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a customer's contracts, fetched live from the connected billing
    /// provider, each enriched with a preview of its upcoming (next) invoice when
    /// available. Returns an empty list when no billing provider is connected or the
    /// customer is not synced.
    /// </summary>
    Task<CustomerListContractsResponse> ListContracts(
        CustomerListContractsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListContracts(CustomerListContractsParams, CancellationToken)"/>
    Task<CustomerListContractsResponse> ListContracts(
        string id,
        CustomerListContractsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a cursor-paginated list of a customer's invoices, fetched live from
    /// the connected billing provider. Ordered by issue date ascending by default;
    /// override with orderBy (issueDate | dueDate | total) and orderDir (ASC | DESC).
    /// Optionally narrowed to one contract, an issue-date range, and/or a set of
    /// invoice states. Returns an empty list when no billing provider is connected or
    /// the customer is not synced.
    /// </summary>
    Task<CustomerListInvoicesPage> ListInvoices(
        CustomerListInvoicesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListInvoices(CustomerListInvoicesParams, CancellationToken)"/>
    Task<CustomerListInvoicesPage> ListInvoices(
        string id,
        CustomerListInvoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of resources within the same customer.
    /// </summary>
    Task<CustomerListResourcesPage> ListResources(
        CustomerListResourcesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListResources(CustomerListResourcesParams, CancellationToken)"/>
    Task<CustomerListResourcesPage> ListResources(
        string id,
        CustomerListResourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    Task<CustomerResponse> Provision(
        CustomerProvisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the effective entitlements for a customer or resource, including
    /// feature and credit entitlements. Each call reaches the Stigg API directly, so
    /// latency reflects a network round trip. For entitlement checks on a hot path
    /// (e.g. gating a request in real time), the Stigg Node Server SDK (with its
    /// built-in cache) or the Sidecar will typically respond faster and keep working
    /// through brief Stigg outages; reach for this endpoint when a live HTTP call is
    /// the natural fit, such as from a non-Node backend or a server-side job.
    /// </summary>
    Task<CustomerRetrieveEntitlementsResponse> RetrieveEntitlements(
        CustomerRetrieveEntitlementsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveEntitlements(CustomerRetrieveEntitlementsParams, CancellationToken)"/>
    Task<CustomerRetrieveEntitlementsResponse> RetrieveEntitlements(
        string id,
        CustomerRetrieveEntitlementsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores an archived customer, allowing them to create new subscriptions again.
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

    IPromotionalEntitlementServiceWithRawResponse PromotionalEntitlements { get; }

    IIntegrationServiceWithRawResponse Integrations { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>patch /api/v1/customers/{id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /api/v1/customers</c>, but is otherwise the
    /// same as <see cref="ICustomerService.List(CustomerListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerListPage>> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/customers/{id}/archive</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}/entitlements/check</c>, but is otherwise the
    /// same as <see cref="ICustomerService.CheckEntitlement(CustomerCheckEntitlementParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerCheckEntitlementResponse>> CheckEntitlement(
        CustomerCheckEntitlementParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CheckEntitlement(CustomerCheckEntitlementParams, CancellationToken)"/>
    Task<HttpResponse<CustomerCheckEntitlementResponse>> CheckEntitlement(
        string id,
        CustomerCheckEntitlementParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/customers/import</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Import(CustomerImportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerImportResponse>> Import(
        CustomerImportParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}/contracts</c>, but is otherwise the
    /// same as <see cref="ICustomerService.ListContracts(CustomerListContractsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerListContractsResponse>> ListContracts(
        CustomerListContractsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListContracts(CustomerListContractsParams, CancellationToken)"/>
    Task<HttpResponse<CustomerListContractsResponse>> ListContracts(
        string id,
        CustomerListContractsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}/invoices</c>, but is otherwise the
    /// same as <see cref="ICustomerService.ListInvoices(CustomerListInvoicesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerListInvoicesPage>> ListInvoices(
        CustomerListInvoicesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListInvoices(CustomerListInvoicesParams, CancellationToken)"/>
    Task<HttpResponse<CustomerListInvoicesPage>> ListInvoices(
        string id,
        CustomerListInvoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}/resources</c>, but is otherwise the
    /// same as <see cref="ICustomerService.ListResources(CustomerListResourcesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerListResourcesPage>> ListResources(
        CustomerListResourcesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListResources(CustomerListResourcesParams, CancellationToken)"/>
    Task<HttpResponse<CustomerListResourcesPage>> ListResources(
        string id,
        CustomerListResourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/customers</c>, but is otherwise the
    /// same as <see cref="ICustomerService.Provision(CustomerProvisionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerResponse>> Provision(
        CustomerProvisionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}/entitlements</c>, but is otherwise the
    /// same as <see cref="ICustomerService.RetrieveEntitlements(CustomerRetrieveEntitlementsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerRetrieveEntitlementsResponse>> RetrieveEntitlements(
        CustomerRetrieveEntitlementsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveEntitlements(CustomerRetrieveEntitlementsParams, CancellationToken)"/>
    Task<HttpResponse<CustomerRetrieveEntitlementsResponse>> RetrieveEntitlements(
        string id,
        CustomerRetrieveEntitlementsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/customers/{id}/unarchive</c>, but is otherwise the
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
