using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;
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
    public async Task<CustomerIntegrationResponse> Retrieve(
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
    public Task<CustomerIntegrationResponse> Retrieve(
        string integrationID,
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { IntegrationID = integrationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerIntegrationResponse> Update(
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
    public Task<CustomerIntegrationResponse> Update(
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
    public async Task<CustomerIntegrationResponse> Link(
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
    public Task<CustomerIntegrationResponse> Link(
        string id,
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Link(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerIntegrationResponse> Unlink(
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
    public Task<CustomerIntegrationResponse> Unlink(
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
    public async Task<HttpResponse<CustomerIntegrationResponse>> Retrieve(
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
                var customerIntegrationResponse = await response
                    .Deserialize<CustomerIntegrationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerIntegrationResponse.Validate();
                }
                return customerIntegrationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerIntegrationResponse>> Retrieve(
        string integrationID,
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { IntegrationID = integrationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerIntegrationResponse>> Update(
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
                var customerIntegrationResponse = await response
                    .Deserialize<CustomerIntegrationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerIntegrationResponse.Validate();
                }
                return customerIntegrationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerIntegrationResponse>> Update(
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
    public async Task<HttpResponse<CustomerIntegrationResponse>> Link(
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
                var customerIntegrationResponse = await response
                    .Deserialize<CustomerIntegrationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerIntegrationResponse.Validate();
                }
                return customerIntegrationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerIntegrationResponse>> Link(
        string id,
        IntegrationLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Link(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerIntegrationResponse>> Unlink(
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
                var customerIntegrationResponse = await response
                    .Deserialize<CustomerIntegrationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerIntegrationResponse.Validate();
                }
                return customerIntegrationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerIntegrationResponse>> Unlink(
        string integrationID,
        IntegrationUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unlink(parameters with { IntegrationID = integrationID }, cancellationToken);
    }
}
