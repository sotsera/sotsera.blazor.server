// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the local-fonts feature.
/// </summary>
public class LocalFonts() : PermissionsPolicyDirective("local-fonts")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="LocalFonts"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="LocalFonts"/> instance with the specified value.</returns>
    public static implicit operator LocalFonts(string value) => new() { Value = value };
}
