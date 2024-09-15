// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sotsera.Blazor.Server.SecurityHeaders.Blazor;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSecurityHeaders(this IServiceCollection services, bool disableKestrelServerHeader)
    {
        services.ThrowIfNull();

        services.TryAddSingleton<IBlazorImportMapDefinitionShaProvider, BlazorImportMapDefinitionShaProvider>();

        if (disableKestrelServerHeader)
        {
            services.PostConfigure<KestrelServerOptions>(x =>
            {
                x.AddServerHeader = false;
            });
        }

        return services;
    }
}
