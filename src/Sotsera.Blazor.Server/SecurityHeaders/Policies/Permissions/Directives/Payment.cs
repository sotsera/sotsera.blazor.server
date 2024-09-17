// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the payment feature.
/// </summary>
public class Payment() : PermissionsPolicyDirective("payment")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Payment"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Payment"/> instance with the specified value.</returns>
    public static implicit operator Payment(string value) => new() { Value = value };
}
