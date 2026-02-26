using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons;
using Stigg.Client.Services.V1.Events.Addons;

namespace Stigg.Client.Services.V1.Events;

/// <inheritdoc/>
public sealed class AddonService : IAddonService
{
    readonly Lazy<IAddonServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAddonServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddonService(this._client.WithOptions(modifier));
    }

    public AddonService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AddonServiceWithRawResponse(client.WithRawResponse));
        _draft = new(() => new DraftService(client));
        _entitlements = new(() => new EntitlementService(client));
    }

    readonly Lazy<IDraftService> _draft;
    public IDraftService Draft
    {
        get { return _draft.Value; }
    }

    readonly Lazy<IEntitlementService> _entitlements;
    public IEntitlementService Entitlements
    {
        get { return _entitlements.Value; }
    }

    /// <inheritdoc/>
    public async Task<Addon> ArchiveAddon(
        AddonArchiveAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ArchiveAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Addon> ArchiveAddon(
        string id,
        AddonArchiveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Addon> CreateAddon(
        AddonCreateAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddonListAddonsPage> ListAddons(
        AddonListAddonsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAddons(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddonPublishAddonResponse> PublishAddon(
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.PublishAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonPublishAddonResponse> PublishAddon(
        string id,
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PublishAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Addon> RetrieveAddon(
        AddonRetrieveAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Addon> RetrieveAddon(
        string id,
        AddonRetrieveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SetPackagePricingResponse> SetPricing(
        AddonSetPricingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SetPricing(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SetPackagePricingResponse> SetPricing(
        string id,
        AddonSetPricingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetPricing(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Addon> UpdateAddon(
        AddonUpdateAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Addon> UpdateAddon(
        string id,
        AddonUpdateAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateAddon(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AddonServiceWithRawResponse : IAddonServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAddonServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddonServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AddonServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _draft = new(() => new DraftServiceWithRawResponse(client));
        _entitlements = new(() => new EntitlementServiceWithRawResponse(client));
    }

    readonly Lazy<IDraftServiceWithRawResponse> _draft;
    public IDraftServiceWithRawResponse Draft
    {
        get { return _draft.Value; }
    }

    readonly Lazy<IEntitlementServiceWithRawResponse> _entitlements;
    public IEntitlementServiceWithRawResponse Entitlements
    {
        get { return _entitlements.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Addon>> ArchiveAddon(
        AddonArchiveAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonArchiveAddonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addon = await response.Deserialize<Addon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addon.Validate();
                }
                return addon;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Addon>> ArchiveAddon(
        string id,
        AddonArchiveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Addon>> CreateAddon(
        AddonCreateAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddonCreateAddonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addon = await response.Deserialize<Addon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addon.Validate();
                }
                return addon;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonListAddonsPage>> ListAddons(
        AddonListAddonsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AddonListAddonsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<AddonListAddonsPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AddonListAddonsPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonPublishAddonResponse>> PublishAddon(
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonPublishAddonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AddonPublishAddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonPublishAddonResponse>> PublishAddon(
        string id,
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PublishAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Addon>> RetrieveAddon(
        AddonRetrieveAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonRetrieveAddonParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addon = await response.Deserialize<Addon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addon.Validate();
                }
                return addon;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Addon>> RetrieveAddon(
        string id,
        AddonRetrieveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SetPackagePricingResponse>> SetPricing(
        AddonSetPricingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonSetPricingParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var setPackagePricingResponse = await response
                    .Deserialize<SetPackagePricingResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    setPackagePricingResponse.Validate();
                }
                return setPackagePricingResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SetPackagePricingResponse>> SetPricing(
        string id,
        AddonSetPricingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetPricing(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Addon>> UpdateAddon(
        AddonUpdateAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonUpdateAddonParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addon = await response.Deserialize<Addon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addon.Validate();
                }
                return addon;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Addon>> UpdateAddon(
        string id,
        AddonUpdateAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateAddon(parameters with { ID = id }, cancellationToken);
    }
}
