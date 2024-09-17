// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the gyroscope feature.
/// </summary>
public class Gyroscope() : PermissionsPolicyDirective("gyroscope")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Gyroscope"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Gyroscope"/> instance with the specified value.</returns>
    public static implicit operator Gyroscope(string value) => new() { Value = value };
}
