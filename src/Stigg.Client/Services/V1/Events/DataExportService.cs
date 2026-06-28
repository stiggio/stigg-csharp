using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.DataExport;
using Stigg.Client.Services.V1.Events.DataExport;

namespace Stigg.Client.Services.V1.Events;

/// <inheritdoc/>
public sealed class DataExportService : IDataExportService
{
    readonly Lazy<IDataExportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDataExportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IDataExportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataExportService(this._client.WithOptions(modifier));
    }

    public DataExportService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DataExportServiceWithRawResponse(client.WithRawResponse));
        _destinations = new(() => new DestinationService(client));
    }

    readonly Lazy<IDestinationService> _destinations;
    public IDestinationService Destinations
    {
        get { return _destinations.Value; }
    }

    /// <inheritdoc/>
    public async Task<DataExportListModelsResponse> ListModels(
        DataExportListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListModels(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DataExportMintScopedTokenResponse> MintScopedToken(
        DataExportMintScopedTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MintScopedToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DataExportTriggerSyncResponse> TriggerSync(
        DataExportTriggerSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TriggerSync(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DataExportServiceWithRawResponse : IDataExportServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDataExportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DataExportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DataExportServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _destinations = new(() => new DestinationServiceWithRawResponse(client));
    }

    readonly Lazy<IDestinationServiceWithRawResponse> _destinations;
    public IDestinationServiceWithRawResponse Destinations
    {
        get { return _destinations.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DataExportListModelsResponse>> ListModels(
        DataExportListModelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DataExportListModelsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<DataExportListModelsResponse>(token)
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
    public async Task<HttpResponse<DataExportMintScopedTokenResponse>> MintScopedToken(
        DataExportMintScopedTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DataExportMintScopedTokenParams> request = new()
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
                    .Deserialize<DataExportMintScopedTokenResponse>(token)
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
    public async Task<HttpResponse<DataExportTriggerSyncResponse>> TriggerSync(
        DataExportTriggerSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DataExportTriggerSyncParams> request = new()
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
                    .Deserialize<DataExportTriggerSyncResponse>(token)
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
