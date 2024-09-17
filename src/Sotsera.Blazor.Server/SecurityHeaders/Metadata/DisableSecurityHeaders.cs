// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

namespace Sotsera.Blazor.Server.SecurityHeaders.Metadata;

/// <summary>
/// Interface for disabling security headers.
/// </summary>
public interface IDisableSecurityHeadersAttribute : ISecurityHeadersMetadata;

/// <summary>
/// Attribute to disable security headers.
/// </summary>
public class DisableSecurityHeaders : IDisableSecurityHeadersAttribute;
