// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the geolocation feature.
/// </summary>
public class Geolocation() : PermissionsPolicyDirective("geolocation")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Geolocation"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Geolocation"/> instance with the specified value.</returns>
    public static implicit operator Geolocation(string value) => new() { Value = value };
}
