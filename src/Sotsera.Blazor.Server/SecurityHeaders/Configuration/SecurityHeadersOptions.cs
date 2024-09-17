// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

namespace Sotsera.Blazor.Server.SecurityHeaders.Configuration;

/// <summary>
/// Options used during the web application configuration phase
/// </summary>
public class SecurityHeadersOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to disable the Kestrel server header. Defaults to true.
    /// </summary>
    public bool DisableKestrelServerHeader { get; set; } = true;

    /// <summary>
    /// Gets or sets the prefix for the antiforgery token. When null no action will be taken. Defaults to null.
    /// </summary>
    public string? AntiforgeryTokenPrefix { get; set; }
}
