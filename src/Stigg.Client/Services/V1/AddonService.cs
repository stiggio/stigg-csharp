using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons;
using Stigg.Client.Services.V1.Addons;

namespace Stigg.Client.Services.V1;

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
        _entitlements = new(() => new EntitlementService(client));
    }

    readonly Lazy<IEntitlementService> _entitlements;
    public IEntitlementService Entitlements
    {
        get { return _entitlements.Value; }
    }

    /// <inheritdoc/>
    public async Task<Addon> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Addon> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Addon> Retrieve(
        string id,
        AddonRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Addon> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Addon> Update(
        string id,
        AddonUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonListPage> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Addon> Archive(
        AddonArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Addon> Archive(
        string id,
        AddonArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Addon> CreateDraft(
        AddonCreateDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateDraft(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Addon> CreateDraft(
        string id,
        AddonCreateDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateDraft(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonPublishResponse> Publish(
        AddonPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Publish(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonPublishResponse> Publish(
        string id,
        AddonPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Publish(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonRemoveDraftResponse> RemoveDraft(
        AddonRemoveDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RemoveDraft(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonRemoveDraftResponse> RemoveDraft(
        string id,
        AddonRemoveDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RemoveDraft(parameters with { ID = id }, cancellationToken);
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

        _entitlements = new(() => new EntitlementServiceWithRawResponse(client));
    }

    readonly Lazy<IEntitlementServiceWithRawResponse> _entitlements;
    public IEntitlementServiceWithRawResponse Entitlements
    {
        get { return _entitlements.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Addon>> Create(
        AddonCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddonCreateParams> request = new()
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
    public async Task<HttpResponse<Addon>> Retrieve(
        AddonRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonRetrieveParams> request = new()
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
    public Task<HttpResponse<Addon>> Retrieve(
        string id,
        AddonRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Addon>> Update(
        AddonUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonUpdateParams> request = new()
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
    public Task<HttpResponse<Addon>> Update(
        string id,
        AddonUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonListPage>> List(
        AddonListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AddonListParams> request = new()
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
                    .Deserialize<AddonListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AddonListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Addon>> Archive(
        AddonArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonArchiveParams> request = new()
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
    public Task<HttpResponse<Addon>> Archive(
        string id,
        AddonArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Addon>> CreateDraft(
        AddonCreateDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonCreateDraftParams> request = new()
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
    public Task<HttpResponse<Addon>> CreateDraft(
        string id,
        AddonCreateDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateDraft(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonPublishResponse>> Publish(
        AddonPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonPublishParams> request = new()
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
                    .Deserialize<AddonPublishResponse>(token)
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
    public Task<HttpResponse<AddonPublishResponse>> Publish(
        string id,
        AddonPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Publish(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonRemoveDraftResponse>> RemoveDraft(
        AddonRemoveDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonRemoveDraftParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AddonRemoveDraftResponse>(token)
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
    public Task<HttpResponse<AddonRemoveDraftResponse>> RemoveDraft(
        string id,
        AddonRemoveDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RemoveDraft(parameters with { ID = id }, cancellationToken);
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
}
