using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Customers.Promotional;

namespace Stigg.Services.V1.Customers;

/// <inheritdoc/>
public sealed class PromotionalService : IPromotionalService
{
    readonly Lazy<IPromotionalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPromotionalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IPromotionalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PromotionalService(this._client.WithOptions(modifier));
    }

    public PromotionalService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PromotionalServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PromotionalCreateResponse> Create(
        PromotionalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PromotionalCreateResponse> Create(
        string customerID,
        PromotionalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PromotionalRevokeResponse> Revoke(
        PromotionalRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Revoke(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PromotionalRevokeResponse> Revoke(
        string featureID,
        PromotionalRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Revoke(parameters with { FeatureID = featureID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PromotionalServiceWithRawResponse : IPromotionalServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPromotionalServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PromotionalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PromotionalServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PromotionalCreateResponse>> Create(
        PromotionalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new StiggInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<PromotionalCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var promotional = await response
                    .Deserialize<PromotionalCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    promotional.Validate();
                }
                return promotional;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PromotionalCreateResponse>> Create(
        string customerID,
        PromotionalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PromotionalRevokeResponse>> Revoke(
        PromotionalRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FeatureID == null)
        {
            throw new StiggInvalidDataException("'parameters.FeatureID' cannot be null");
        }

        HttpRequest<PromotionalRevokeParams> request = new()
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
                    .Deserialize<PromotionalRevokeResponse>(token)
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
    public Task<HttpResponse<PromotionalRevokeResponse>> Revoke(
        string featureID,
        PromotionalRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Revoke(parameters with { FeatureID = featureID }, cancellationToken);
    }
}
