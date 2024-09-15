// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class DisplayCapture() : PermissionsPolicyDirective("display-capture")
{
    public static implicit operator DisplayCapture(string value) => new() { Value = value };
}
