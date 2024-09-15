// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.DefaultPolicies;

public class DefaultSecurityHeadersPolicy : ISecurityHeadersPolicy
{
    public void ApplyHeaders(HttpContext context, IWebHostEnvironment environment)
    {
        var headers = context.Response.Headers;

        headers.Remove(HeaderNames.Server);

        headers.XContentTypeOptions = "nosniff";

        if (environment.IsDevelopment() == false)
        {
            headers.StrictTransportSecurity = "max-age=63072000; includeSubDomains"; // 2 years
        }
    }
}
