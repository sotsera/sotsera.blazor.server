// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class Bluetooth() : PermissionsPolicyDirective("bluetooth")
{
    public static implicit operator Bluetooth(string value) => new() { Value = value };
}
