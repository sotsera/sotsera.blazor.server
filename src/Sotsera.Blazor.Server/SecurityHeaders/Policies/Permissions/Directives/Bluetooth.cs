// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the bluetooth feature.
/// </summary>
public class Bluetooth() : PermissionsPolicyDirective("bluetooth")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Bluetooth"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Bluetooth"/> instance with the specified value.</returns>
    public static implicit operator Bluetooth(string value) => new() { Value = value };
}
