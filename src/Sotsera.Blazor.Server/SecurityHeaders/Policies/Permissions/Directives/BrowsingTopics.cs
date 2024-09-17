// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the browsing-topics feature.
/// </summary>
public class BrowsingTopics() : PermissionsPolicyDirective("browsing-topics")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="BrowsingTopics"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="BrowsingTopics"/> instance with the specified value.</returns>
    public static implicit operator BrowsingTopics(string value) => new() { Value = value };
}
