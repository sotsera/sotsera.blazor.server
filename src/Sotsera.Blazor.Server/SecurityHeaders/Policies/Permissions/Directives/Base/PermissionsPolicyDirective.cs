// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

public class PermissionsPolicyDirective(string name, string? value = null)
{
    private string? _value = value;

    public string Name { get; } = name.ThrowIfEmpty();

    public string? Value
    {
        get => _value;
        set => _value = value.IsEmpty() ? null : value;
    }
}

