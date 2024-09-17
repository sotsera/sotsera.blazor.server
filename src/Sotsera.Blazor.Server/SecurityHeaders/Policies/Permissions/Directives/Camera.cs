// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the camera feature.
/// </summary>
public class Camera() : PermissionsPolicyDirective("camera")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Camera"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Camera"/> instance with the specified value.</returns>
    public static implicit operator Camera(string value) => new() { Value = value };
}
