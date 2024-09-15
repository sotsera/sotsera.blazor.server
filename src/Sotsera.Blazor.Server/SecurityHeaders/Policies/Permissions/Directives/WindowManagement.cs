// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class WindowManagement() : PermissionsPolicyDirective("window-management")
{
    public static implicit operator WindowManagement(string value) => new() { Value = value };
}
