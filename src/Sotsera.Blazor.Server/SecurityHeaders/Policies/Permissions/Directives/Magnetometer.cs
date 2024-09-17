// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the magnetometer feature.
/// </summary>
public class Magnetometer() : PermissionsPolicyDirective("magnetometer")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Magnetometer"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Magnetometer"/> instance with the specified value.</returns>
    public static implicit operator Magnetometer(string value) => new() { Value = value };
}
