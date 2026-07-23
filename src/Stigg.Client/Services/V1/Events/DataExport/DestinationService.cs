using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.DataExport.Destinations;

namespace Stigg.Client.Services.V1.Events.DataExport;

/// <inheritdoc/>
public sealed class DestinationService : IDestinationService
{
    readonly Lazy<IDestinationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDestinationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IDestinationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DestinationService(this._client.WithOptions(modifier));
    }

    public DestinationService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DestinationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DestinationCreateResponse> Create(
        DestinationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DestinationDeleteResponse> Delete(
        DestinationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DestinationDeleteResponse> Delete(
        string destinationID,
        DestinationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DestinationUpdateSelectionResponse> UpdateSelection(
        DestinationUpdateSelectionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateSelection(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DestinationUpdateSelectionResponse> UpdateSelection(
        string destinationID,
        DestinationUpdateSelectionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateSelection(
            parameters with
            {
                DestinationID = destinationID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class DestinationServiceWithRawResponse : IDestinationServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDestinationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DestinationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DestinationServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DestinationCreateResponse>> Create(
        DestinationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DestinationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var destination = await response
                    .Deserialize<DestinationCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    destination.Validate();
                }
                return destination;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DestinationDeleteResponse>> Delete(
        DestinationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DestinationID == null)
        {
            throw new StiggInvalidDataException("'parameters.DestinationID' cannot be null");
        }

        HttpRequest<DestinationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var destination = await response
                    .Deserialize<DestinationDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    destination.Validate();
                }
                return destination;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DestinationDeleteResponse>> Delete(
        string destinationID,
        DestinationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DestinationID = destinationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DestinationUpdateSelectionResponse>> UpdateSelection(
        DestinationUpdateSelectionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DestinationID == null)
        {
            throw new StiggInvalidDataException("'parameters.DestinationID' cannot be null");
        }

        HttpRequest<DestinationUpdateSelectionParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<DestinationUpdateSelectionResponse>(token)
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
    public Task<HttpResponse<DestinationUpdateSelectionResponse>> UpdateSelection(
        string destinationID,
        DestinationUpdateSelectionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateSelection(
            parameters with
            {
                DestinationID = destinationID,
            },
            cancellationToken
        );
    }
}
