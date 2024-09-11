// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.Extensions.DependencyInjection;

namespace Sotsera.Blazor.Server;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSecurityHeaders(this IServiceCollection services)
    {
        return services;
    }
}
