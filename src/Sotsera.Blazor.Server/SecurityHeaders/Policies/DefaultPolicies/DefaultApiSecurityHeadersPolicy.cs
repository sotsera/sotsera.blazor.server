// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.DefaultPolicies;

/// <summary>
/// See <see href="https://cheatsheetseries.owasp.org/cheatsheets/REST_Security_Cheat_Sheet.html#security-headers"/>
/// </summary>
public class DefaultApiSecurityHeadersPolicy : ISecurityHeadersPolicy
{
    public void ApplyHeaders(HttpContext context, IWebHostEnvironment environment)
    {
        var headers = context.Response.Headers;

        headers.Remove(HeaderNames.Server);

        headers.CacheControl = "no-store";
        headers.ContentSecurityPolicy = "frame-ancestors 'none'";
        headers.XContentTypeOptions = "nosniff";
        headers.XFrameOptions = "DENY";

        if (environment.IsDevelopment() == false)
        {
            headers.StrictTransportSecurity = "max-age=63072000; includeSubDomains"; // 2 years
        }
    }
}
