// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class StorageAccess() : PermissionsPolicyDirective("storage-access")
{
    public static implicit operator StorageAccess(string value) => new() { Value = value };
}
