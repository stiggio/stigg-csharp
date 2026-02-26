using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Addons;
using Stigg.Client.Services.V1.Events.Addons;

namespace Stigg.Client.Services.V1.Events;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
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

    IDraftService Draft { get; }

    IEntitlementService Entitlements { get; }

    /// <summary>
    /// Archives an addon, preventing it from being used in new subscriptions.
    /// </summary>
    Task<Addon> ArchiveAddon(
        AddonArchiveAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ArchiveAddon(AddonArchiveAddonParams, CancellationToken)"/>
    Task<Addon> ArchiveAddon(
        string id,
        AddonArchiveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new addon in draft status, associated with a specific product.
    /// </summary>
    Task<Addon> CreateAddon(
        AddonCreateAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of addons in the environment.
    /// </summary>
    Task<AddonListAddonsPage> ListAddons(
        AddonListAddonsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publishes a draft addon, making it available for use in subscriptions.
    /// </summary>
    Task<AddonPublishAddonResponse> PublishAddon(
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PublishAddon(AddonPublishAddonParams, CancellationToken)"/>
    Task<AddonPublishAddonResponse> PublishAddon(
        string id,
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves an addon by its unique identifier, including entitlements and pricing details.
    /// </summary>
    Task<Addon> RetrieveAddon(
        AddonRetrieveAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveAddon(AddonRetrieveAddonParams, CancellationToken)"/>
    Task<Addon> RetrieveAddon(
        string id,
        AddonRetrieveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets the pricing configuration for an addon.
    /// </summary>
    Task<SetPackagePricingResponse> SetPricing(
        AddonSetPricingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetPricing(AddonSetPricingParams, CancellationToken)"/>
    Task<SetPackagePricingResponse> SetPricing(
        string id,
        AddonSetPricingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing addon's properties such as display name, description,
    /// and metadata.
    /// </summary>
    Task<Addon> UpdateAddon(
        AddonUpdateAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateAddon(AddonUpdateAddonParams, CancellationToken)"/>
    Task<Addon> UpdateAddon(
        string id,
        AddonUpdateAddonParams? parameters = null,
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

    IDraftServiceWithRawResponse Draft { get; }

    IEntitlementServiceWithRawResponse Entitlements { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/addons/{id}/archive`, but is otherwise the
    /// same as <see cref="IAddonService.ArchiveAddon(AddonArchiveAddonParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> ArchiveAddon(
        AddonArchiveAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ArchiveAddon(AddonArchiveAddonParams, CancellationToken)"/>
    Task<HttpResponse<Addon>> ArchiveAddon(
        string id,
        AddonArchiveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/addons`, but is otherwise the
    /// same as <see cref="IAddonService.CreateAddon(AddonCreateAddonParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> CreateAddon(
        AddonCreateAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/addons`, but is otherwise the
    /// same as <see cref="IAddonService.ListAddons(AddonListAddonsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonListAddonsPage>> ListAddons(
        AddonListAddonsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/addons/{id}/publish`, but is otherwise the
    /// same as <see cref="IAddonService.PublishAddon(AddonPublishAddonParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonPublishAddonResponse>> PublishAddon(
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PublishAddon(AddonPublishAddonParams, CancellationToken)"/>
    Task<HttpResponse<AddonPublishAddonResponse>> PublishAddon(
        string id,
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/addons/{id}`, but is otherwise the
    /// same as <see cref="IAddonService.RetrieveAddon(AddonRetrieveAddonParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> RetrieveAddon(
        AddonRetrieveAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveAddon(AddonRetrieveAddonParams, CancellationToken)"/>
    Task<HttpResponse<Addon>> RetrieveAddon(
        string id,
        AddonRetrieveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /api/v1/addons/{id}/charges`, but is otherwise the
    /// same as <see cref="IAddonService.SetPricing(AddonSetPricingParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SetPackagePricingResponse>> SetPricing(
        AddonSetPricingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetPricing(AddonSetPricingParams, CancellationToken)"/>
    Task<HttpResponse<SetPackagePricingResponse>> SetPricing(
        string id,
        AddonSetPricingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /api/v1/addons/{id}`, but is otherwise the
    /// same as <see cref="IAddonService.UpdateAddon(AddonUpdateAddonParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Addon>> UpdateAddon(
        AddonUpdateAddonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateAddon(AddonUpdateAddonParams, CancellationToken)"/>
    Task<HttpResponse<Addon>> UpdateAddon(
        string id,
        AddonUpdateAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
