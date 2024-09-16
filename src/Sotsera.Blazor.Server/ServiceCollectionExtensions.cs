// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sotsera.Blazor.Server.SecurityHeaders.Blazor;
using Sotsera.Blazor.Server.SecurityHeaders.Configuration;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSecurityHeaders(this IServiceCollection services,
        Action<SecurityHeadersOptions>? configure = null)
    {
        services.ThrowIfNull();

        var options = new SecurityHeadersOptions();
        configure?.Invoke(options);

        services.TryAddSingleton<IBlazorImportMapDefinitionShaProvider, BlazorImportMapDefinitionShaProvider>();

        if (options.DisableKestrelServerHeader)
        {
            services.PostConfigure<KestrelServerOptions>(x =>
            {
                x.AddServerHeader = false;
            });
        }

        if (options.AntiforgeryTokenPrefix.IsNonEmpty())
        {
            // See: https://github.com/dotnet/aspnetcore/blob/b6b29ca3c2cdc316e8eb20cb4077ea81f21340c4/src/Antiforgery/src/Internal/AntiforgeryOptionsSetup.cs#L28
            services.AddAntiforgery(x => x.Cookie.Name = options.AntiforgeryTokenPrefix);
        }

        return services;
    }
}
