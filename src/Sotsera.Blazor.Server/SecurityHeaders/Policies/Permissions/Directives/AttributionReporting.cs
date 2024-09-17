// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the attribution-reporting feature.
/// </summary>
public class AttributionReporting() : PermissionsPolicyDirective("attribution-reporting")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="AttributionReporting"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="AttributionReporting"/> instance with the specified value.</returns>
    public static implicit operator AttributionReporting(string value) => new() { Value = value };
}
