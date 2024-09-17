// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies;

/// <summary>
/// Defines a policy for applying security headers.
/// </summary>
public interface ISecurityHeadersPolicy
{
    /// <summary>
    /// Applies security headers to the given HTTP context.
    /// </summary>
    /// <param name="context">The HTTP context to which the headers will be applied.</param>
    /// <param name="environment">The web host environment.</param>
    void ApplyHeaders(HttpContext context, IWebHostEnvironment environment);
}

/// <summary>
/// Provides extension methods for the <see cref="HttpContext"/> class.
/// </summary>
public static class HttpContextExtensions
{
    /// <summary>
    /// Gets a required service from the HTTP context's request services.
    /// </summary>
    /// <typeparam name="T">The type of the service to retrieve.</typeparam>
    /// <param name="context">The HTTP context.</param>
    /// <returns>The requested service.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the service is not found.</exception>
    public static T GetRequiredService<T>(this HttpContext context) where T : notnull
    {
        return context.RequestServices.GetRequiredService<T>();
    }
}
