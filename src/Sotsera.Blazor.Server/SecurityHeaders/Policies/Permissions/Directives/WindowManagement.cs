// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the window-management feature.
/// </summary>
public class WindowManagement() : PermissionsPolicyDirective("window-management")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="WindowManagement"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Accelerometer"/> instance with the specified value.</returns>
    public static implicit operator WindowManagement(string value) => new() { Value = value };
}
