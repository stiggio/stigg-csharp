using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Services.V1.Customers;

/// <inheritdoc/>
public sealed class IntegrationService : IIntegrationService
{
    readonly Lazy<IIntegrationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIntegrationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IIntegrationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IntegrationService(this._client.WithOptions(modifier));
    }

    public IntegrationService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new IntegrationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<IntegrationRetrieveResponse> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntegrationRetrieveResponse> Retrieve(
        string integrationID,
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { IntegrationID = integrationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IntegrationUpdateResponse> Update(
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntegrationUpdateResponse> Update(
        string integrationID,
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { IntegrationID = integrationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IntegrationListPage> List(
        IntegrationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntegrationListPage> List(
        string id,
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IntegrationLinkResponse> Link(
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Link(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntegrationLinkResponse> Link(
        string id,
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Link(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IntegrationUnlinkResponse> Unlink(
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unlink(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IntegrationUnlinkResponse> Unlink(
        string integrationID,
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unlink(parameters with { IntegrationID = integrationID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class IntegrationServiceWithRawResponse : IIntegrationServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIntegrationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IntegrationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IntegrationServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntegrationRetrieveResponse>> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IntegrationID == null)
        {
            throw new StiggInvalidDataException("'parameters.IntegrationID' cannot be null");
        }

        HttpRequest<IntegrationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var integration = await response
                    .Deserialize<IntegrationRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    integration.Validate();
                }
                return integration;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IntegrationRetrieveResponse>> Retrieve(
        string integrationID,
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { IntegrationID = integrationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntegrationUpdateResponse>> Update(
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IntegrationID == null)
        {
            throw new StiggInvalidDataException("'parameters.IntegrationID' cannot be null");
        }

        HttpRequest<IntegrationUpdateParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var integration = await response
                    .Deserialize<IntegrationUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    integration.Validate();
                }
                return integration;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IntegrationUpdateResponse>> Update(
        string integrationID,
        IntegrationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { IntegrationID = integrationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntegrationListPage>> List(
        IntegrationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<IntegrationListParams> request = new()
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
                    .Deserialize<IntegrationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new IntegrationListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IntegrationListPage>> List(
        string id,
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntegrationLinkResponse>> Link(
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<IntegrationLinkParams> request = new()
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
                    .Deserialize<IntegrationLinkResponse>(token)
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
    public Task<HttpResponse<IntegrationLinkResponse>> Link(
        string id,
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Link(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntegrationUnlinkResponse>> Unlink(
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IntegrationID == null)
        {
            throw new StiggInvalidDataException("'parameters.IntegrationID' cannot be null");
        }

        HttpRequest<IntegrationUnlinkParams> request = new()
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
                    .Deserialize<IntegrationUnlinkResponse>(token)
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
    public Task<HttpResponse<IntegrationUnlinkResponse>> Unlink(
        string integrationID,
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unlink(parameters with { IntegrationID = integrationID }, cancellationToken);
    }
}
