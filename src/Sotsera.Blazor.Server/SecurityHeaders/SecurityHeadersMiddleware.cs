// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sotsera.Blazor.Server.SecurityHeaders.Metadata;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders;

/// <summary>
/// Middleware for applying security headers to HTTP responses.
/// </summary>
public class SecurityHeadersMiddleware(RequestDelegate next, ISecurityHeadersPolicy policy, ILogger<SecurityHeadersMiddleware> logger)
{
    private readonly ISecurityHeadersPolicy _policy = policy.ThrowIfNull();
    private readonly RequestDelegate _next = next.ThrowIfNull();
    private readonly ILogger<SecurityHeadersMiddleware> _logger = logger.ThrowIfNull();

    /// <summary>
    /// Invokes the middleware to apply security headers to the HTTP context.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task that represents the completion of the middleware execution.</returns>
    public Task Invoke(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        var metadata = endpoint?.Metadata.GetMetadata<ISecurityHeadersMetadata>();

        if (metadata is IDisableSecurityHeadersAttribute)
        {
            return _next(context);
        }

        var policy = metadata is ISecurityHeadersPolicyMetadata policyMetadata
            ? policyMetadata.Policy
            : _policy;

        context.Response.OnStarting(OnResponseStartingDelegate, (context, policy));

        return _next(context);
    }

    /// <summary>
    /// Delegate method that is called when the response is starting.
    /// </summary>
    /// <param name="state">The state object containing the HTTP context and security headers policy.</param>
    /// <returns>A task that represents the completion of the response starting delegate.</returns>
    private Task OnResponseStartingDelegate(object state)
    {
        var (context, policy) = ((HttpContext, ISecurityHeadersPolicy))state;

        try
        {
            var environment = context.RequestServices.GetRequiredService<IWebHostEnvironment>();
            policy.ApplyHeaders(context, environment);
        }
        catch (Exception exception)
        {
            _logger.FailedToSetHeaders(exception);
        }

        return Task.CompletedTask;
    }
}

