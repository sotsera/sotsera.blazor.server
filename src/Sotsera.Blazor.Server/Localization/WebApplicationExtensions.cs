// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.Localization;

public static class WebApplicationExtensions
{
    /// <summary>
    /// Configures request localization to support all available cultures, with a specified default culture.
    /// </summary>
    /// <param name="webApplication">The <see cref="WebApplication"/> instance.</param>
    /// <param name="defaultCulture">The default culture to use if no culture is specified in the request.</param>
    /// <returns>The <see cref="WebApplication"/> instance with request localization configured.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="webApplication"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="defaultCulture"/> is null or empty.</exception>
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

    /// <summary>
    /// Configures request localization to support a specified set of cultures, with a specified default culture.
    /// </summary>
    /// <param name="webApplication">The <see cref="WebApplication"/> instance.</param>
    /// <param name="defaultCulture">The default culture to use if no culture is specified in the request.</param>
    /// <param name="cultures">An array of culture names to support.</param>
    /// <returns>The <see cref="WebApplication"/> instance with request localization configured.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="webApplication"/> or <paramref name="cultures"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="defaultCulture"/> is null or whitespace.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="cultures"/> is empty.</exception>
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
