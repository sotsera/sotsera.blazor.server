// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Sotsera.Blazor.Server.SecurityHeaders.Blazor;
using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.DefaultPolicies;

/// <summary>
/// See <see href="https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-9.0#server-side-blazor-apps" />
/// </summary>
public class DefaultBlazorSecurityHeadersPolicy : ISecurityHeadersPolicy
{
    private readonly string _baseCsp = string.Join(';',
        "base-uri 'self'",
        "default-src 'self'",
        "img-src data: https:",
        "object-src 'none'",
        "style-src 'self'",
        "upgrade-insecure-requests",
        "frame-ancestors 'none'",
        "script-src 'self' 'wasm-unsafe-eval'"
    );

    // Allow hot reload and Browser Link
    private const string DevelopmentScriptSrcSuffix = "localhost:* http://localhost:* ws://localhost:*";
    private const string DevelopmentConnectSrc = "connect-src http://localhost:* ws://localhost:*";

    public void ApplyHeaders(HttpContext context, IWebHostEnvironment environment)
    {
        var sha = context.GetRequiredService<IBlazorImportMapDefinitionShaProvider>().GetSha256(context);

        var headers = context.Response.Headers;

        headers.Remove(HeaderNames.Server);

        headers.CacheControl = "no-store";
        headers.ContentSecurityPolicy = "frame-ancestors 'none'";
        headers.XContentTypeOptions = "nosniff";
        headers.XFrameOptions = "DENY";
        headers["Referrer-Policy"] = "no-referrer";
        headers["Permissions-Policy"] = new PermissionsPolicy();

        headers.ContentSecurityPolicy = environment.IsDevelopment()
            ? $"{_baseCsp} 'sha256-{sha}' {DevelopmentScriptSrcSuffix}; {DevelopmentConnectSrc}"
            : $"{_baseCsp} 'sha256-{sha}'";

        if (environment.IsDevelopment() == false)
        {
            headers.StrictTransportSecurity = "max-age=63072000; includeSubDomains"; // 2 years
        }
    }
}
