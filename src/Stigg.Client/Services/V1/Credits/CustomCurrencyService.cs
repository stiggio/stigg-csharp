using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits.CustomCurrencies;

namespace Stigg.Client.Services.V1.Credits;

/// <inheritdoc/>
public sealed class CustomCurrencyService : ICustomCurrencyService
{
    readonly Lazy<ICustomCurrencyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomCurrencyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public ICustomCurrencyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomCurrencyService(this._client.WithOptions(modifier));
    }

    public CustomCurrencyService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new CustomCurrencyServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CustomCurrency> Create(
        CustomCurrencyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomCurrency> Update(
        CustomCurrencyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomCurrency> Update(
        string currencyID,
        CustomCurrencyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CurrencyID = currencyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomCurrencyListPage> List(
        CustomCurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomCurrency> Archive(
        CustomCurrencyArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomCurrency> Archive(
        string currencyID,
        CustomCurrencyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { CurrencyID = currencyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomCurrencyListAssociatedEntitiesResponse> ListAssociatedEntities(
        CustomCurrencyListAssociatedEntitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAssociatedEntities(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomCurrencyListAssociatedEntitiesResponse> ListAssociatedEntities(
        string currencyID,
        CustomCurrencyListAssociatedEntitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAssociatedEntities(
            parameters with
            {
                CurrencyID = currencyID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CustomCurrency> Unarchive(
        CustomCurrencyUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unarchive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomCurrency> Unarchive(
        string currencyID,
        CustomCurrencyUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unarchive(parameters with { CurrencyID = currencyID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CustomCurrencyServiceWithRawResponse : ICustomCurrencyServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomCurrencyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CustomCurrencyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomCurrencyServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomCurrency>> Create(
        CustomCurrencyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomCurrencyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customCurrency = await response
                    .Deserialize<CustomCurrency>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customCurrency.Validate();
                }
                return customCurrency;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomCurrency>> Update(
        CustomCurrencyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CurrencyID == null)
        {
            throw new StiggInvalidDataException("'parameters.CurrencyID' cannot be null");
        }

        HttpRequest<CustomCurrencyUpdateParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customCurrency = await response
                    .Deserialize<CustomCurrency>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customCurrency.Validate();
                }
                return customCurrency;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomCurrency>> Update(
        string currencyID,
        CustomCurrencyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CurrencyID = currencyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomCurrencyListPage>> List(
        CustomCurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CustomCurrencyListParams> request = new()
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
                    .Deserialize<CustomCurrencyListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CustomCurrencyListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomCurrency>> Archive(
        CustomCurrencyArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CurrencyID == null)
        {
            throw new StiggInvalidDataException("'parameters.CurrencyID' cannot be null");
        }

        HttpRequest<CustomCurrencyArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customCurrency = await response
                    .Deserialize<CustomCurrency>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customCurrency.Validate();
                }
                return customCurrency;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomCurrency>> Archive(
        string currencyID,
        CustomCurrencyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { CurrencyID = currencyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<CustomCurrencyListAssociatedEntitiesResponse>
    > ListAssociatedEntities(
        CustomCurrencyListAssociatedEntitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CurrencyID == null)
        {
            throw new StiggInvalidDataException("'parameters.CurrencyID' cannot be null");
        }

        HttpRequest<CustomCurrencyListAssociatedEntitiesParams> request = new()
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
                    .Deserialize<CustomCurrencyListAssociatedEntitiesResponse>(token)
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
    public Task<HttpResponse<CustomCurrencyListAssociatedEntitiesResponse>> ListAssociatedEntities(
        string currencyID,
        CustomCurrencyListAssociatedEntitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAssociatedEntities(
            parameters with
            {
                CurrencyID = currencyID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomCurrency>> Unarchive(
        CustomCurrencyUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CurrencyID == null)
        {
            throw new StiggInvalidDataException("'parameters.CurrencyID' cannot be null");
        }

        HttpRequest<CustomCurrencyUnarchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customCurrency = await response
                    .Deserialize<CustomCurrency>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customCurrency.Validate();
                }
                return customCurrency;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomCurrency>> Unarchive(
        string currencyID,
        CustomCurrencyUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unarchive(parameters with { CurrencyID = currencyID }, cancellationToken);
    }
}
