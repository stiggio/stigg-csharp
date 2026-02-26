using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Services.V1;

/// <inheritdoc/>
public sealed class ProductService : IProductService
{
    readonly Lazy<IProductServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProductServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductService(this._client.WithOptions(modifier));
    }

    public ProductService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProductServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Product> ArchiveProduct(
        ProductArchiveProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ArchiveProduct(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Product> ArchiveProduct(
        string id,
        ProductArchiveProductParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveProduct(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Product> CreateProduct(
        ProductCreateProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateProduct(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Product> DuplicateProduct(
        ProductDuplicateProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DuplicateProduct(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Product> DuplicateProduct(
        string id,
        ProductDuplicateProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DuplicateProduct(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProductListProductsPage> ListProducts(
        ProductListProductsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListProducts(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Product> UnarchiveProduct(
        ProductUnarchiveProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UnarchiveProduct(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Product> UnarchiveProduct(
        string id,
        ProductUnarchiveProductParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UnarchiveProduct(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Product> UpdateProduct(
        ProductUpdateProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateProduct(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Product> UpdateProduct(
        string id,
        ProductUpdateProductParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateProduct(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ProductServiceWithRawResponse : IProductServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProductServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProductServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProductServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Product>> ArchiveProduct(
        ProductArchiveProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductArchiveProductParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var product = await response.Deserialize<Product>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    product.Validate();
                }
                return product;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Product>> ArchiveProduct(
        string id,
        ProductArchiveProductParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveProduct(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Product>> CreateProduct(
        ProductCreateProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProductCreateProductParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var product = await response.Deserialize<Product>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    product.Validate();
                }
                return product;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Product>> DuplicateProduct(
        ProductDuplicateProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductDuplicateProductParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var product = await response.Deserialize<Product>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    product.Validate();
                }
                return product;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Product>> DuplicateProduct(
        string id,
        ProductDuplicateProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DuplicateProduct(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProductListProductsPage>> ListProducts(
        ProductListProductsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProductListProductsParams> request = new()
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
                    .Deserialize<ProductListProductsPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ProductListProductsPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Product>> UnarchiveProduct(
        ProductUnarchiveProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductUnarchiveProductParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var product = await response.Deserialize<Product>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    product.Validate();
                }
                return product;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Product>> UnarchiveProduct(
        string id,
        ProductUnarchiveProductParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UnarchiveProduct(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Product>> UpdateProduct(
        ProductUpdateProductParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ProductUpdateProductParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var product = await response.Deserialize<Product>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    product.Validate();
                }
                return product;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Product>> UpdateProduct(
        string id,
        ProductUpdateProductParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateProduct(parameters with { ID = id }, cancellationToken);
    }
}
