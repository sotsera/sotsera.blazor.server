// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

public class PermissionsPolicyDirective(string name, string value = "()")
{
    private readonly string _value = value.ThrowIfEmpty();

    public string Name { get; } = name.ThrowIfEmpty();

    public string Value
    {
        get => _value;
        protected init => _value = value.IsEmpty() ? "()" : value;
    }
}

