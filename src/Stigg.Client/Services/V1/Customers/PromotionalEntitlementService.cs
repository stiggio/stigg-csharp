using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Services.V1.Customers;

/// <inheritdoc/>
public sealed class PromotionalEntitlementService : IPromotionalEntitlementService
{
    readonly Lazy<IPromotionalEntitlementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPromotionalEntitlementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IPromotionalEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PromotionalEntitlementService(this._client.WithOptions(modifier));
    }

    public PromotionalEntitlementService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PromotionalEntitlementServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<PromotionalEntitlementCreateResponse> Create(
        PromotionalEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PromotionalEntitlementCreateResponse> Create(
        string id,
        PromotionalEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PromotionalEntitlementListPage> List(
        PromotionalEntitlementListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PromotionalEntitlementListPage> List(
        string id,
        PromotionalEntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PromotionalEntitlementRevokeResponse> Revoke(
        PromotionalEntitlementRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Revoke(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PromotionalEntitlementRevokeResponse> Revoke(
        string featureID,
        PromotionalEntitlementRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Revoke(parameters with { FeatureID = featureID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PromotionalEntitlementServiceWithRawResponse
    : IPromotionalEntitlementServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPromotionalEntitlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PromotionalEntitlementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PromotionalEntitlementServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PromotionalEntitlementCreateResponse>> Create(
        PromotionalEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PromotionalEntitlementCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var promotionalEntitlement = await response
                    .Deserialize<PromotionalEntitlementCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    promotionalEntitlement.Validate();
                }
                return promotionalEntitlement;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PromotionalEntitlementCreateResponse>> Create(
        string id,
        PromotionalEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PromotionalEntitlementListPage>> List(
        PromotionalEntitlementListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PromotionalEntitlementListParams> request = new()
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
                    .Deserialize<PromotionalEntitlementListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PromotionalEntitlementListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PromotionalEntitlementListPage>> List(
        string id,
        PromotionalEntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PromotionalEntitlementRevokeResponse>> Revoke(
        PromotionalEntitlementRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FeatureID == null)
        {
            throw new StiggInvalidDataException("'parameters.FeatureID' cannot be null");
        }

        HttpRequest<PromotionalEntitlementRevokeParams> request = new()
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
                    .Deserialize<PromotionalEntitlementRevokeResponse>(token)
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
    public Task<HttpResponse<PromotionalEntitlementRevokeResponse>> Revoke(
        string featureID,
        PromotionalEntitlementRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Revoke(parameters with { FeatureID = featureID }, cancellationToken);
    }
}
