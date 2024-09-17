// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the compute-pressure feature.
/// </summary>
public class ComputePressure() : PermissionsPolicyDirective("compute-pressure")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="ComputePressure"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="ComputePressure"/> instance with the specified value.</returns>
    public static implicit operator ComputePressure(string value) => new() { Value = value };
}
