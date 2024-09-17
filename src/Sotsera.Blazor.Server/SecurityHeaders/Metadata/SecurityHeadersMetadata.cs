// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders.Metadata;

/// <summary>
/// Interface for security headers policy metadata.
/// </summary>
public interface ISecurityHeadersPolicyMetadata : ISecurityHeadersMetadata
{
    /// <summary>
    /// Gets the security headers policy.
    /// </summary>
    ISecurityHeadersPolicy Policy { get; }
}

/// <summary>
/// Implementation of <see cref="ISecurityHeadersPolicyMetadata"/> that holds a security headers policy.
/// </summary>
public class SecurityHeadersPolicyMetadata(ISecurityHeadersPolicy policy) : ISecurityHeadersPolicyMetadata
{
    /// <summary>
    /// Gets the security headers policy.
    /// </summary>
    public ISecurityHeadersPolicy Policy { get; } = policy.ThrowIfNull();
}
