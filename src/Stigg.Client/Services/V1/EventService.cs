using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events;
using Stigg.Client.Services.V1.Events;

namespace Stigg.Client.Services.V1;

/// <inheritdoc/>
public sealed class EventService : IEventService
{
    readonly Lazy<IEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventService(this._client.WithOptions(modifier));
    }

    public EventService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EventServiceWithRawResponse(client.WithRawResponse));
        _credits = new(() => new CreditService(client));
    }

    readonly Lazy<ICreditService> _credits;
    public ICreditService Credits
    {
        get { return _credits.Value; }
    }

    /// <inheritdoc/>
    public async Task<EventReportResponse> Report(
        EventReportParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Report(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EventServiceWithRawResponse : IEventServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _credits = new(() => new CreditServiceWithRawResponse(client));
    }

    readonly Lazy<ICreditServiceWithRawResponse> _credits;
    public ICreditServiceWithRawResponse Credits
    {
        get { return _credits.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventReportResponse>> Report(
        EventReportParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EventReportParams> request = new()
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
                    .Deserialize<EventReportResponse>(token)
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
