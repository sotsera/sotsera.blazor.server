// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Builder;
using Sotsera.Blazor.Server.SecurityHeaders.Metadata;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server;

public static class EndpointConventionBuilderExtensions
{
    public static TBuilder RequireSecurityHeaders<TBuilder>(this TBuilder builder, ISecurityHeadersPolicy policy)
        where TBuilder : IEndpointConventionBuilder
    {
        builder.ThrowIfNull();
        policy.ThrowIfNull();

        builder.WithMetadata(new SecurityHeadersPolicyMetadata(policy));

        return builder;
    }

    public static TBuilder DisableSecurityHeaders<TBuilder>(this TBuilder builder)
        where TBuilder : IEndpointConventionBuilder
    {
        builder.ThrowIfNull();

        builder.WithMetadata(new DisableSecurityHeaders());

        return builder;
    }
}
