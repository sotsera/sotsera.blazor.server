// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Builder;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders;

public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds middleware to the application's request pipeline to apply security headers based on the specified policy.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <param name="policy">The security headers policy to apply.</param>
    /// <returns>The application builder with the security headers middleware added.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="policy"/> is null.</exception>
    public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder builder, ISecurityHeadersPolicy policy)
    {
        builder.ThrowIfNull();
        policy.ThrowIfNull();

        return builder.UseMiddleware<SecurityHeadersMiddleware>(policy);
    }
}
