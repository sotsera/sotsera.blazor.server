// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Blazor;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions;

namespace BlazorWebAppAutoGlobal.Configuration.SecurityHeaders;

internal sealed class BlazorSecurityHeaders : DefaultHeadersPolicy
{
    private string? _csp;

    private static string GetContentSecurityPolicy(HttpContext context, IWebHostEnvironment environment)
    {
        var sha = context.GetRequiredService<IBlazorImportMapDefinitionShaProvider>().GetSha256(context);

        var developmentConnectSrc = environment.IsDevelopment()
            ? "http://localhost:* ws://localhost:* wss://localhost:*"
            : string.Empty;

        return string.Join(';',
            "default-src 'none'",
            $"connect-src 'self' {developmentConnectSrc}",
            $"script-src-elem 'self' 'sha256-{sha}'",
            "script-src 'wasm-unsafe-eval'",
            "style-src-elem 'self'",
            "img-src 'self' data:",
            "form-action 'self'",
            "frame-ancestors 'none'",
            "upgrade-insecure-requests"
        );
    }

    public override void ApplyHeaders(HttpContext context, IWebHostEnvironment environment)
    {
        base.ApplyHeaders(context, environment);

        var headers = context.Response.Headers;

        headers.CacheControl = "no-store, no-cache, must-revalidate";

        headers.ContentSecurityPolicy = _csp ??= GetContentSecurityPolicy(context, environment);

        headers["Permissions-Policy"] = new PermissionsPolicy
        {
            Camera = "()",
            Geolocation = "()",
            Microphone = "()"
        };
    }
}
