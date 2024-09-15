// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Sources.Common.Extensions;

namespace BlazorWebAppAutoGlobal;

public static class EndpointRouteBuilderExtensions
{
    public static TBuilder Map<TBuilder>(this TBuilder builder, Action<TBuilder> configure) where TBuilder : IEndpointRouteBuilder
    {
        builder.ThrowIfNull();
        configure.ThrowIfNull();

        configure(builder);

        return builder;
    }
}
