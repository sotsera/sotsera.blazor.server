// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class Gamepad() : PermissionsPolicyDirective("gamepad")
{
    public static implicit operator Gamepad(string value) => new() { Value = value };
}
