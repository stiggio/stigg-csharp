using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Credits.CustomCurrencies;

namespace Stigg.Client.Services.V1.Events.Credits;

/// <summary>
/// Operations related to custom currencies
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICustomCurrencyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomCurrencyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomCurrencyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new custom currency in the environment.
    /// </summary>
    Task<CustomCurrencyCreateResponse> Create(
        CustomCurrencyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing custom currency. Only the supplied fields are modified.
    /// </summary>
    Task<CustomCurrencyUpdateResponse> Update(
        CustomCurrencyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomCurrencyUpdateParams, CancellationToken)"/>
    Task<CustomCurrencyUpdateResponse> Update(
        string currencyID,
        CustomCurrencyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of custom currencies in the environment. Archived
    /// currencies are excluded by default; pass `status=ARCHIVED` (or
    /// `status=ACTIVE,ARCHIVED`) to include them.
    /// </summary>
    Task<CustomCurrencyListPage> List(
        CustomCurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives a custom currency. Fails if the currency is still associated with any
    /// active plan or addon — use the associated-entities endpoint first to inspect
    /// dependencies.
    /// </summary>
    Task<CustomCurrencyArchiveResponse> Archive(
        CustomCurrencyArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CustomCurrencyArchiveParams, CancellationToken)"/>
    Task<CustomCurrencyArchiveResponse> Archive(
        string currencyID,
        CustomCurrencyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the active plans and addons that reference a custom currency. Useful
    /// before archiving to inspect dependencies.
    /// </summary>
    Task<CustomCurrencyListAssociatedEntitiesResponse> ListAssociatedEntities(
        CustomCurrencyListAssociatedEntitiesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAssociatedEntities(CustomCurrencyListAssociatedEntitiesParams, CancellationToken)"/>
    Task<CustomCurrencyListAssociatedEntitiesResponse> ListAssociatedEntities(
        string currencyID,
        CustomCurrencyListAssociatedEntitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores a previously archived custom currency. Fails if another active currency
    /// with the same ID already exists.
    /// </summary>
    Task<CustomCurrencyUnarchiveResponse> Unarchive(
        CustomCurrencyUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(CustomCurrencyUnarchiveParams, CancellationToken)"/>
    Task<CustomCurrencyUnarchiveResponse> Unarchive(
        string currencyID,
        CustomCurrencyUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICustomCurrencyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomCurrencyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomCurrencyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/credits/custom-currencies</c>, but is otherwise the
    /// same as <see cref="ICustomCurrencyService.Create(CustomCurrencyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomCurrencyCreateResponse>> Create(
        CustomCurrencyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/credits/custom-currencies/{currencyId}</c>, but is otherwise the
    /// same as <see cref="ICustomCurrencyService.Update(CustomCurrencyUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomCurrencyUpdateResponse>> Update(
        CustomCurrencyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomCurrencyUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CustomCurrencyUpdateResponse>> Update(
        string currencyID,
        CustomCurrencyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/credits/custom-currencies</c>, but is otherwise the
    /// same as <see cref="ICustomCurrencyService.List(CustomCurrencyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomCurrencyListPage>> List(
        CustomCurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/credits/custom-currencies/{currencyId}/archive</c>, but is otherwise the
    /// same as <see cref="ICustomCurrencyService.Archive(CustomCurrencyArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomCurrencyArchiveResponse>> Archive(
        CustomCurrencyArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CustomCurrencyArchiveParams, CancellationToken)"/>
    Task<HttpResponse<CustomCurrencyArchiveResponse>> Archive(
        string currencyID,
        CustomCurrencyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/credits/custom-currencies/{currencyId}/associated-entities</c>, but is otherwise the
    /// same as <see cref="ICustomCurrencyService.ListAssociatedEntities(CustomCurrencyListAssociatedEntitiesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomCurrencyListAssociatedEntitiesResponse>> ListAssociatedEntities(
        CustomCurrencyListAssociatedEntitiesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAssociatedEntities(CustomCurrencyListAssociatedEntitiesParams, CancellationToken)"/>
    Task<HttpResponse<CustomCurrencyListAssociatedEntitiesResponse>> ListAssociatedEntities(
        string currencyID,
        CustomCurrencyListAssociatedEntitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/credits/custom-currencies/{currencyId}/unarchive</c>, but is otherwise the
    /// same as <see cref="ICustomCurrencyService.Unarchive(CustomCurrencyUnarchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomCurrencyUnarchiveResponse>> Unarchive(
        CustomCurrencyUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(CustomCurrencyUnarchiveParams, CancellationToken)"/>
    Task<HttpResponse<CustomCurrencyUnarchiveResponse>> Unarchive(
        string currencyID,
        CustomCurrencyUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
