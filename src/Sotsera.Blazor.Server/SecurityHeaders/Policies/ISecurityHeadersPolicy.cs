// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies;

public interface ISecurityHeadersPolicy
{
    void ApplyHeaders(HttpContext context, IWebHostEnvironment environment);
}

public static class HttpContextExtensions
{
    public static T GetRequiredService<T>(this HttpContext context) where T : notnull
    {
        return context.RequestServices.GetRequiredService<T>();
    }
}
