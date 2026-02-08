using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProductServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves a paginated list of products in the environment.
    /// </summary>
    Task<ProductListProductsPage> ListProducts(
        ProductListProductsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProductService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProductServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProductServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/products`, but is otherwise the
    /// same as <see cref="IProductService.ListProducts(ProductListProductsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductListProductsPage>> ListProducts(
        ProductListProductsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
