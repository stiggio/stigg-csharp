using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Customers.Usage;

namespace Stigg.Services.V1.Customers;

/// <inheritdoc/>
public sealed class UsageService : IUsageService
{
    readonly Lazy<IUsageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageService(this._client.WithOptions(modifier));
    }

    public UsageService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UsageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UsageRetrieveResponse> Retrieve(
        UsageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UsageRetrieveResponse> Retrieve(
        string featureID,
        UsageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { FeatureID = featureID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class UsageServiceWithRawResponse : IUsageServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UsageServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageRetrieveResponse>> Retrieve(
        UsageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FeatureID == null)
        {
            throw new StiggInvalidDataException("'parameters.FeatureID' cannot be null");
        }

        HttpRequest<UsageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var usage = await response
                    .Deserialize<UsageRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    usage.Validate();
                }
                return usage;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UsageRetrieveResponse>> Retrieve(
        string featureID,
        UsageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { FeatureID = featureID }, cancellationToken);
    }
}
