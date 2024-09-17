// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the gamepad feature.
/// </summary>
public class Gamepad() : PermissionsPolicyDirective("gamepad")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Gamepad"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Gamepad"/> instance with the specified value.</returns>
    public static implicit operator Gamepad(string value) => new() { Value = value };
}
