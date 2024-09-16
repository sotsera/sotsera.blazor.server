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
    public static IServiceCollection AddSecurityHeaders(this IServiceCollection services,
        bool disableKestrelServerHeader, string? antiforgeryTokenPrefix = null)
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

        if (antiforgeryTokenPrefix.IsNonEmpty())
        {
            // See: https://github.com/dotnet/aspnetcore/blob/b6b29ca3c2cdc316e8eb20cb4077ea81f21340c4/src/Antiforgery/src/Internal/AntiforgeryOptionsSetup.cs#L28
            services.AddAntiforgery(x => x.Cookie.Name = antiforgeryTokenPrefix);
        }

        return services;
    }
}
