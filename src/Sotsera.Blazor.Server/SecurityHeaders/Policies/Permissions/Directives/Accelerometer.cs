// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the accelerometer feature.
/// </summary>
public class Accelerometer() : PermissionsPolicyDirective("accelerometer")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Accelerometer"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Accelerometer"/> instance with the specified value.</returns>
    public static implicit operator Accelerometer(string value) => new() { Value = value };
}
