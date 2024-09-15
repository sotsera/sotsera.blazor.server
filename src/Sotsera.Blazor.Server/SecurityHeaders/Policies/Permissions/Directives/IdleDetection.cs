// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class IdleDetection() : PermissionsPolicyDirective("idle-detection")
{
    public static implicit operator IdleDetection(string value) => new() { Value = value };
}
