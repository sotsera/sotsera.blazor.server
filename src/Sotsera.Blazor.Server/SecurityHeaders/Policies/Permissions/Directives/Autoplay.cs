// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class Autoplay() : PermissionsPolicyDirective("autoplay")
{
    public static implicit operator Autoplay(string value) => new() { Value = value };
}
