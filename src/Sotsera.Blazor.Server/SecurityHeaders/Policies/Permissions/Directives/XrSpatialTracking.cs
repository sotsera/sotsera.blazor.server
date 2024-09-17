// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the xr-spatial-tracking feature.
/// </summary>
public class XrSpatialTracking() : PermissionsPolicyDirective("xr-spatial-tracking")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="XrSpatialTracking"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Accelerometer"/> instance with the specified value.</returns>
    public static implicit operator XrSpatialTracking(string value) => new() { Value = value };
}
