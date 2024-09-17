// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

/// <summary>
/// Represents a base class for permissions policy directives.
/// </summary>
public class PermissionsPolicyDirective(string name, string? value = null)
{
    private string? _value = value;

    /// <summary>
    /// Gets the name of the directive.
    /// </summary>
    public string Name { get; } = name.ThrowIfEmpty();

    /// <summary>
    /// Gets or sets the value of the directive.
    /// </summary>
    public string? Value
    {
        get => _value;
        set => _value = value.IsEmpty() ? null : value;
    }
}

