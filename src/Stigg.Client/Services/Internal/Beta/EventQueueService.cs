using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Services.Internal.Beta;

/// <inheritdoc/>
public sealed class EventQueueService : IEventQueueService
{
    readonly Lazy<IEventQueueServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventQueueServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IEventQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventQueueService(this._client.WithOptions(modifier));
    }

    public EventQueueService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EventQueueServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EventQueueResponse> Retrieve(
        EventQueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventQueueResponse> Retrieve(
        string queueName,
        EventQueueRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { QueueName = queueName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventQueueResponse> Update(
        EventQueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventQueueResponse> Update(
        string queueName,
        EventQueueUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { QueueName = queueName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventQueueListResponse> List(
        EventQueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EventQueueResponse> Delete(
        EventQueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EventQueueResponse> Delete(
        string queueName,
        EventQueueDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { QueueName = queueName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventQueueResponse> Provision(
        EventQueueProvisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Provision(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EventQueueServiceWithRawResponse : IEventQueueServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventQueueServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EventQueueServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventQueueServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventQueueResponse>> Retrieve(
        EventQueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueName == null)
        {
            throw new StiggInvalidDataException("'parameters.QueueName' cannot be null");
        }

        HttpRequest<EventQueueRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventQueueResponse = await response
                    .Deserialize<EventQueueResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventQueueResponse.Validate();
                }
                return eventQueueResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EventQueueResponse>> Retrieve(
        string queueName,
        EventQueueRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { QueueName = queueName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventQueueResponse>> Update(
        EventQueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueName == null)
        {
            throw new StiggInvalidDataException("'parameters.QueueName' cannot be null");
        }

        HttpRequest<EventQueueUpdateParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventQueueResponse = await response
                    .Deserialize<EventQueueResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventQueueResponse.Validate();
                }
                return eventQueueResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EventQueueResponse>> Update(
        string queueName,
        EventQueueUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { QueueName = queueName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventQueueListResponse>> List(
        EventQueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EventQueueListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventQueues = await response
                    .Deserialize<EventQueueListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventQueues.Validate();
                }
                return eventQueues;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventQueueResponse>> Delete(
        EventQueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QueueName == null)
        {
            throw new StiggInvalidDataException("'parameters.QueueName' cannot be null");
        }

        HttpRequest<EventQueueDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventQueueResponse = await response
                    .Deserialize<EventQueueResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventQueueResponse.Validate();
                }
                return eventQueueResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EventQueueResponse>> Delete(
        string queueName,
        EventQueueDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { QueueName = queueName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventQueueResponse>> Provision(
        EventQueueProvisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EventQueueProvisionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventQueueResponse = await response
                    .Deserialize<EventQueueResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventQueueResponse.Validate();
                }
                return eventQueueResponse;
            }
        );
    }
}
