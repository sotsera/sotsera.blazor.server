// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.Net.Http.Headers;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;

namespace BlazorWebAppAutoGlobal.Configuration.SecurityHeaders;

/// <summary>
/// See <see href="https://cheatsheetseries.owasp.org/cheatsheets/REST_Security_Cheat_Sheet.html#security-headers"/>
/// </summary>
public class DefaultHeadersPolicy : ISecurityHeadersPolicy
{
    public virtual void ApplyHeaders(HttpContext context, IWebHostEnvironment environment) {
        var headers = context.Response.Headers;

        headers.Remove(HeaderNames.Server);

        headers.XContentTypeOptions = "nosniff";
        headers.XFrameOptions = "DENY";
        headers["Referrer-Policy"] = "strict-origin-when-cross-origin";

        headers["Cross-Origin-Embedder-Policy"] = "require-corp";
        headers["Cross-Origin-Opener-Policy"] = "same-origin";

        headers.ContentSecurityPolicy = string.Join(';',
            "default-src 'none'",
            "form-action 'self'",
            "frame-ancestors 'none'",
            "upgrade-insecure-requests"
        );

        if (environment.IsDevelopment() == false)
        {
            headers.StrictTransportSecurity = "max-age=63113904; includeSubDomains; preload";
        }
    }
}
