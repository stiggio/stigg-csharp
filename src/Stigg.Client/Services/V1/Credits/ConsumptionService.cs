using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.Consumption;

namespace Stigg.Client.Services.V1.Credits;

/// <inheritdoc/>
public sealed class ConsumptionService : IConsumptionService
{
    readonly Lazy<IConsumptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConsumptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IConsumptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConsumptionService(this._client.WithOptions(modifier));
    }

    public ConsumptionService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ConsumptionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ConsumptionConsumeResponse> Consume(
        ConsumptionConsumeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Consume(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConsumptionConsumeAsyncResponse> ConsumeAsync(
        ConsumptionConsumeAsyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ConsumeAsync(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ConsumptionServiceWithRawResponse : IConsumptionServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConsumptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConsumptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConsumptionServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConsumptionConsumeResponse>> Consume(
        ConsumptionConsumeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ConsumptionConsumeParams> request = new()
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
                    .Deserialize<ConsumptionConsumeResponse>(token)
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
    public async Task<HttpResponse<ConsumptionConsumeAsyncResponse>> ConsumeAsync(
        ConsumptionConsumeAsyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ConsumptionConsumeAsyncParams> request = new()
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
                    .Deserialize<ConsumptionConsumeAsyncResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
