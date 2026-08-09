using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IContractService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IContractServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IContractService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a contract for a customer together with all of its (custom)
    /// subscriptions in a single atomic operation. Every new subscription is created
    /// inside one transaction — any validation or creation failure rolls the whole
    /// contract back. Each subscription entry is either a new subscription to create or
    /// a reference to an existing custom subscription. Returns the created contract.
    /// </summary>
    Task<ContractCreateResponse> Create(
        ContractCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a single contract by its ID, enriched with a preview of its upcoming
    /// (next) invoice when one is available. Returns 404 when no contract with that ID
    /// exists in the environment.
    /// </summary>
    Task<ContractRetrieveResponse> Retrieve(
        ContractRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ContractRetrieveParams, CancellationToken)"/>
    Task<ContractRetrieveResponse> Retrieve(
        string id,
        ContractRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a contract's metadata (name, PO number, activation dates) and optionally
    /// re-links its subscriptions. Best-effort re-syncs the change to the connected
    /// billing provider.
    /// </summary>
    Task<ContractUpdateResponse> Update(
        ContractUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ContractUpdateParams, CancellationToken)"/>
    Task<ContractUpdateResponse> Update(
        string id,
        ContractUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a cursor-paginated list of contracts in the environment, fetched live
    /// from the connected billing provider. Each contract is enriched with a preview of
    /// its upcoming (next) invoice when one is available. Returns an empty list when no
    /// billing provider is connected. Supports filtering by customer external ID,
    /// state, and name.
    /// </summary>
    Task<ContractListPage> List(
        ContractListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a contract: cancels the contract in the connected billing provider and
    /// cancels every subscription linked to it.
    /// </summary>
    Task<ContractDeleteResponse> Delete(
        ContractDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ContractDeleteParams, CancellationToken)"/>
    Task<ContractDeleteResponse> Delete(
        string id,
        ContractDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IContractService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IContractServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IContractServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/contracts</c>, but is otherwise the
    /// same as <see cref="IContractService.Create(ContractCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContractCreateResponse>> Create(
        ContractCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/contracts/{id}</c>, but is otherwise the
    /// same as <see cref="IContractService.Retrieve(ContractRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContractRetrieveResponse>> Retrieve(
        ContractRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ContractRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ContractRetrieveResponse>> Retrieve(
        string id,
        ContractRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/contracts/{id}</c>, but is otherwise the
    /// same as <see cref="IContractService.Update(ContractUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContractUpdateResponse>> Update(
        ContractUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ContractUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ContractUpdateResponse>> Update(
        string id,
        ContractUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/contracts</c>, but is otherwise the
    /// same as <see cref="IContractService.List(ContractListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContractListPage>> List(
        ContractListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/contracts/{id}/archive</c>, but is otherwise the
    /// same as <see cref="IContractService.Delete(ContractDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContractDeleteResponse>> Delete(
        ContractDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ContractDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ContractDeleteResponse>> Delete(
        string id,
        ContractDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
