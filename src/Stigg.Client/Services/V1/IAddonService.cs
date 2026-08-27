using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Addons;
using Stigg.Client.Services.V1.Addons;

namespace Stigg.Client.Services.V1;

/// <summary>
/// Operations related to addons
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAddonService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAddonServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEntitlementService Entitlements { get; }

    /// <summary>
    /// Creates a new addon in draft status, associated with a specific product.
    /// </summary>
    Task<Addon> Create(AddonCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an addon by its unique identifier, including entitlements and pricing
    /// details.
    /// </summary>
    Task<Addon> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AddonRetrieveParams, CancellationToken)"/>
    Task<Addon> Retrieve(
        string id,
        AddonRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing addon's properties such as display name, description, and
    /// metadata.
    /// </summary>
    Task<Addon> Update(AddonUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(AddonUpdateParams, CancellationToken)"/>
    Task<Addon> Update(
        string id,
        AddonUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of addons in the environment.
    /// </summary>
    Task<AddonListPage> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives an addon, preventing it from being used in new subscriptions.
    /// </summary>
    Task<Addon> Archive(
        AddonArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(AddonArchiveParams, CancellationToken)"/>
    Task<Addon> Archive(
        string id,
        AddonArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a draft version of an existing addon for modification before publishing.
    /// </summary>
    Task<Addon> CreateDraft(
        AddonCreateDraftParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateDraft(AddonCreateDraftParams, CancellationToken)"/>
    Task<Addon> CreateDraft(
        string id,
        AddonCreateDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the list of charges configured on an addon.
    /// </summary>
    Task<AddonListChargesPage> ListCharges(
        AddonListChargesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListCharges(AddonListChargesParams, CancellationToken)"/>
    Task<AddonListChargesPage> ListCharges(
        string id,
        AddonListChargesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publishes a draft addon, making it available for use in subscriptions. The
    /// required `migrationType` field controls whether subscriptions already using this
    /// addon are moved onto the new version immediately (`ALL_CUSTOMERS`) or stay on
    /// the version they were using — grandfathered — until you explicitly migrate them
    /// (`NEW_CUSTOMERS`).
    /// </summary>
    Task<AddonPublishResponse> Publish(
        AddonPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(AddonPublishParams, CancellationToken)"/>
    Task<AddonPublishResponse> Publish(
        string id,
        AddonPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a draft version of an addon.
    /// </summary>
    Task<AddonRemoveDraftResponse> RemoveDraft(
        AddonRemoveDraftParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveDraft(AddonRemoveDraftParams, CancellationToken)"/>
    Task<AddonRemoveDraftResponse> RemoveDraft(
        string id,
        AddonRemoveDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAddonService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAddonServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddonServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEntitlementServiceWithRawResponse Entitlements { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/addons</c>, but is otherwise the
    /// same as <see cref="IAddonService.Create(AddonCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/addons/{id}</c>, but is otherwise the
    /// same as <see cref="IAddonService.Retrieve(AddonRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AddonRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Addon>> Retrieve(
        string id,
        AddonRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/addons/{id}</c>, but is otherwise the
    /// same as <see cref="IAddonService.Update(AddonUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AddonUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Addon>> Update(
        string id,
        AddonUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/addons</c>, but is otherwise the
    /// same as <see cref="IAddonService.List(AddonListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonListPage>> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/addons/{id}/archive</c>, but is otherwise the
    /// same as <see cref="IAddonService.Archive(AddonArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> Archive(
        AddonArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(AddonArchiveParams, CancellationToken)"/>
    Task<HttpResponse<Addon>> Archive(
        string id,
        AddonArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/addons/{id}/draft</c>, but is otherwise the
    /// same as <see cref="IAddonService.CreateDraft(AddonCreateDraftParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> CreateDraft(
        AddonCreateDraftParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateDraft(AddonCreateDraftParams, CancellationToken)"/>
    Task<HttpResponse<Addon>> CreateDraft(
        string id,
        AddonCreateDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/addons/{id}/charges</c>, but is otherwise the
    /// same as <see cref="IAddonService.ListCharges(AddonListChargesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonListChargesPage>> ListCharges(
        AddonListChargesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListCharges(AddonListChargesParams, CancellationToken)"/>
    Task<HttpResponse<AddonListChargesPage>> ListCharges(
        string id,
        AddonListChargesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/addons/{id}/publish</c>, but is otherwise the
    /// same as <see cref="IAddonService.Publish(AddonPublishParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonPublishResponse>> Publish(
        AddonPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(AddonPublishParams, CancellationToken)"/>
    Task<HttpResponse<AddonPublishResponse>> Publish(
        string id,
        AddonPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/addons/{id}/draft</c>, but is otherwise the
    /// same as <see cref="IAddonService.RemoveDraft(AddonRemoveDraftParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonRemoveDraftResponse>> RemoveDraft(
        AddonRemoveDraftParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveDraft(AddonRemoveDraftParams, CancellationToken)"/>
    Task<HttpResponse<AddonRemoveDraftResponse>> RemoveDraft(
        string id,
        AddonRemoveDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
