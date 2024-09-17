// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Builder;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder builder, ISecurityHeadersPolicy policy)
    {
        builder.ThrowIfNull();
        policy.ThrowIfNull();

        return builder.UseMiddleware<SecurityHeadersMiddleware>(policy);
    }
}
