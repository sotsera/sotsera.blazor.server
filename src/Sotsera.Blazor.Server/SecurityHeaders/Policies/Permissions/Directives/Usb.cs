// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the usb feature.
/// </summary>
public class Usb() : PermissionsPolicyDirective("usb")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Usb"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Usb"/> instance with the specified value.</returns>
    public static implicit operator Usb(string value) => new() { Value = value };
}
