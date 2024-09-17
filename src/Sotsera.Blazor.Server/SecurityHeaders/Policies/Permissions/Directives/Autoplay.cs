// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the autoplay feature.
/// </summary>
public class Autoplay() : PermissionsPolicyDirective("autoplay")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Autoplay"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Autoplay"/> instance with the specified value.</returns>
    public static implicit operator Autoplay(string value) => new() { Value = value };
}
