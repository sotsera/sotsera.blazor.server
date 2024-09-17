// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the screen-wake-lock feature.
/// </summary>
public class ScreenWakeLock() : PermissionsPolicyDirective("screen-wake-lock")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="ScreenWakeLock"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="ScreenWakeLock"/> instance with the specified value.</returns>
    public static implicit operator ScreenWakeLock(string value) => new() { Value = value };
}
