// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.ForSotseraCommon;

public static class WebApplicationExtensions
{
    public static WebApplication UseRequestLocalizationForAllAvailableCultures(this WebApplication webApplication, string defaultCulture)
    {
        webApplication.ThrowIfNull();
        defaultCulture.ThrowIfEmpty();

        var supportedCultures = CultureInfo
            .GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures)
            .Where(cultureInfo => cultureInfo.Name.IsNonEmpty())
            .ToArray();

        webApplication.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(defaultCulture),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        return webApplication;
    }

    public static WebApplication UseRequestLocalizationForCultures(this WebApplication webApplication, string defaultCulture, params string[] cultures)
    {
        ArgumentNullException.ThrowIfNull(webApplication);
        ArgumentException.ThrowIfNullOrWhiteSpace(defaultCulture);
        ArgumentNullException.ThrowIfNull(cultures);
        ArgumentOutOfRangeException.ThrowIfLessThan(cultures.Length, 1);

        webApplication.UseRequestLocalization(new RequestLocalizationOptions()
            .SetDefaultCulture(defaultCulture)
            .AddSupportedCultures(cultures)
            .AddSupportedUICultures(cultures)
        );

        return webApplication;
    }
}
