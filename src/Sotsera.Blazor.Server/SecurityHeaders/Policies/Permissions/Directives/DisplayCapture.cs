// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the display-capture feature.
/// </summary>
public class DisplayCapture() : PermissionsPolicyDirective("display-capture")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="DisplayCapture"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="DisplayCapture"/> instance with the specified value.</returns>
    public static implicit operator DisplayCapture(string value) => new() { Value = value };
}
