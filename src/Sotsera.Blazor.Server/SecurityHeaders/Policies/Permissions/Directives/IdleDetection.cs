// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the idle-detection feature.
/// </summary>
public class IdleDetection() : PermissionsPolicyDirective("idle-detection")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="IdleDetection"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="IdleDetection"/> instance with the specified value.</returns>
    public static implicit operator IdleDetection(string value) => new() { Value = value };
}
