using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Services.V1;

/// <summary>
/// Operations related to products
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Archives a product, preventing new subscriptions. All plans and addons are archived.
    /// </summary>
    Task<Product> ArchiveProduct(
        ProductArchiveProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ArchiveProduct(ProductArchiveProductParams, CancellationToken)"/>
    Task<Product> ArchiveProduct(
        string id,
        ProductArchiveProductParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new product.
    /// </summary>
    Task<Product> CreateProduct(
        ProductCreateProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Duplicates an existing product, including its plans, addons, and configuration.
    /// </summary>
    Task<Product> DuplicateProduct(
        ProductDuplicateProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DuplicateProduct(ProductDuplicateProductParams, CancellationToken)"/>
    Task<Product> DuplicateProduct(
        string id,
        ProductDuplicateProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of products in the environment.
    /// </summary>
    Task<ProductListProductsPage> ListProducts(
        ProductListProductsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores an archived product, allowing new subscriptions to be created.
    /// </summary>
    Task<Product> UnarchiveProduct(
        ProductUnarchiveProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UnarchiveProduct(ProductUnarchiveProductParams, CancellationToken)"/>
    Task<Product> UnarchiveProduct(
        string id,
        ProductUnarchiveProductParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing product's properties such as display name, description,
    /// and metadata.
    /// </summary>
    Task<Product> UpdateProduct(
        ProductUpdateProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateProduct(ProductUpdateProductParams, CancellationToken)"/>
    Task<Product> UpdateProduct(
        string id,
        ProductUpdateProductParams? parameters = null,
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
    /// Returns a raw HTTP response for `post /api/v1/products/{id}/archive`, but is otherwise the
    /// same as <see cref="IProductService.ArchiveProduct(ProductArchiveProductParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Product>> ArchiveProduct(
        ProductArchiveProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ArchiveProduct(ProductArchiveProductParams, CancellationToken)"/>
    Task<HttpResponse<Product>> ArchiveProduct(
        string id,
        ProductArchiveProductParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/products`, but is otherwise the
    /// same as <see cref="IProductService.CreateProduct(ProductCreateProductParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Product>> CreateProduct(
        ProductCreateProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/products/{id}/duplicate`, but is otherwise the
    /// same as <see cref="IProductService.DuplicateProduct(ProductDuplicateProductParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Product>> DuplicateProduct(
        ProductDuplicateProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DuplicateProduct(ProductDuplicateProductParams, CancellationToken)"/>
    Task<HttpResponse<Product>> DuplicateProduct(
        string id,
        ProductDuplicateProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/products`, but is otherwise the
    /// same as <see cref="IProductService.ListProducts(ProductListProductsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProductListProductsPage>> ListProducts(
        ProductListProductsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/products/{id}/unarchive`, but is otherwise the
    /// same as <see cref="IProductService.UnarchiveProduct(ProductUnarchiveProductParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Product>> UnarchiveProduct(
        ProductUnarchiveProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UnarchiveProduct(ProductUnarchiveProductParams, CancellationToken)"/>
    Task<HttpResponse<Product>> UnarchiveProduct(
        string id,
        ProductUnarchiveProductParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /api/v1/products/{id}`, but is otherwise the
    /// same as <see cref="IProductService.UpdateProduct(ProductUpdateProductParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Product>> UpdateProduct(
        ProductUpdateProductParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateProduct(ProductUpdateProductParams, CancellationToken)"/>
    Task<HttpResponse<Product>> UpdateProduct(
        string id,
        ProductUpdateProductParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
