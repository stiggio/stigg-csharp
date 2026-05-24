using System;
using Stigg.Client.Core;
using Stigg.Client.Services.V1Beta;

namespace Stigg.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1BetaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1BetaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1BetaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomerService Customers { get; }

    IEntityTypeService EntityTypes { get; }
}

/// <summary>
/// A view of <see cref="IV1BetaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1BetaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1BetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomerServiceWithRawResponse Customers { get; }

    IEntityTypeServiceWithRawResponse EntityTypes { get; }
}
