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
    public async Task<PromotionalEntitlementGrantResponse> Grant(
        PromotionalEntitlementGrantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Grant(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PromotionalEntitlementGrantResponse> Grant(
        string customerID,
        PromotionalEntitlementGrantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Grant(parameters with { CustomerID = customerID }, cancellationToken);
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
    public async Task<HttpResponse<PromotionalEntitlementGrantResponse>> Grant(
        PromotionalEntitlementGrantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new StiggInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<PromotionalEntitlementGrantParams> request = new()
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
                    .Deserialize<PromotionalEntitlementGrantResponse>(token)
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
    public Task<HttpResponse<PromotionalEntitlementGrantResponse>> Grant(
        string customerID,
        PromotionalEntitlementGrantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Grant(parameters with { CustomerID = customerID }, cancellationToken);
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
