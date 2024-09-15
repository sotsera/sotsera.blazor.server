// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class ScreenWakeLock() : PermissionsPolicyDirective("screen-wake-lock")
{
    public static implicit operator ScreenWakeLock(string value) => new() { Value = value };
}
