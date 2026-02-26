using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons.Entitlements;

namespace Stigg.Client.Services.V1.Events.Addons;

/// <inheritdoc/>
public sealed class EntitlementService : IEntitlementService
{
    readonly Lazy<IEntitlementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEntitlementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntitlementService(this._client.WithOptions(modifier));
    }

    public EntitlementService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EntitlementServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EntitlementCreateResponse> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementCreateResponse> Create(
        string addonID,
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { AddonID = addonID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonPackageEntitlement> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonPackageEntitlement> Update(
        string id,
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntitlementListResponse> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementListResponse> List(
        string addonID,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { AddonID = addonID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonPackageEntitlement> Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonPackageEntitlement> Delete(
        string id,
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EntitlementServiceWithRawResponse : IEntitlementServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEntitlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EntitlementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EntitlementServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementCreateResponse>> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AddonID == null)
        {
            throw new StiggInvalidDataException("'parameters.AddonID' cannot be null");
        }

        HttpRequest<EntitlementCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlement = await response
                    .Deserialize<EntitlementCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlement.Validate();
                }
                return entitlement;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementCreateResponse>> Create(
        string addonID,
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { AddonID = addonID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonPackageEntitlement>> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntitlementUpdateParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addonPackageEntitlement = await response
                    .Deserialize<AddonPackageEntitlement>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addonPackageEntitlement.Validate();
                }
                return addonPackageEntitlement;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonPackageEntitlement>> Update(
        string id,
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementListResponse>> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AddonID == null)
        {
            throw new StiggInvalidDataException("'parameters.AddonID' cannot be null");
        }

        HttpRequest<EntitlementListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var entitlements = await response
                    .Deserialize<EntitlementListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    entitlements.Validate();
                }
                return entitlements;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementListResponse>> List(
        string addonID,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { AddonID = addonID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonPackageEntitlement>> Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntitlementDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var addonPackageEntitlement = await response
                    .Deserialize<AddonPackageEntitlement>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    addonPackageEntitlement.Validate();
                }
                return addonPackageEntitlement;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonPackageEntitlement>> Delete(
        string id,
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
