// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the fullscreen feature.
/// </summary>
public class Fullscreen() : PermissionsPolicyDirective("fullscreen")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Fullscreen"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Fullscreen"/> instance with the specified value.</returns>
    public static implicit operator Fullscreen(string value) => new() { Value = value };
}
