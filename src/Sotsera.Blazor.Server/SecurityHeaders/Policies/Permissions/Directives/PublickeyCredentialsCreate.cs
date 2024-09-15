// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class PublickeyCredentialsCreate() : PermissionsPolicyDirective("publickey-credentials-create")
{
    public static implicit operator PublickeyCredentialsCreate(string value) => new() { Value = value };
}
