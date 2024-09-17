// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Builder;
using Sotsera.Blazor.Server.SecurityHeaders.Metadata;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders;

public static class EndpointConventionBuilderExtensions
{
    /// <summary>
    /// Requires security headers for the specified endpoint using the provided policy.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the endpoint convention builder.</typeparam>
    /// <param name="builder">The endpoint convention builder.</param>
    /// <param name="policy">The security headers policy to apply.</param>
    /// <returns>The endpoint convention builder with the security headers policy metadata added.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="policy"/> is null.</exception>
    public static TBuilder RequireSecurityHeaders<TBuilder>(this TBuilder builder, ISecurityHeadersPolicy policy)
        where TBuilder : IEndpointConventionBuilder
    {
        builder.ThrowIfNull();
        policy.ThrowIfNull();

        builder.WithMetadata(new SecurityHeadersPolicyMetadata(policy));

        return builder;
    }

    /// <summary>
    /// Disables security headers for the specified endpoint.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the endpoint convention builder.</typeparam>
    /// <param name="builder">The endpoint convention builder.</param>
    /// <returns>The endpoint convention builder with the disable security headers metadata added.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
    public static TBuilder DisableSecurityHeaders<TBuilder>(this TBuilder builder)
        where TBuilder : IEndpointConventionBuilder
    {
        builder.ThrowIfNull();

        builder.WithMetadata(new DisableSecurityHeaders());

        return builder;
    }
}
