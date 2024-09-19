// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders.Blazor;

/// <summary>
/// Provides an interface for retrieving the SHA-256 hash of the Blazor import map definition.
/// </summary>
public interface IBlazorImportMapDefinitionShaProvider
{
    /// <summary>
    /// Retrieves the SHA-256 hash of the import map definition from the given HTTP context.
    /// </summary>
    /// <param name="context">The HTTP context containing the import map definition.</param>
    /// <returns>The SHA-256 hash of the import map definition, or null if the definition is not found.</returns>
    string? GetSha256(HttpContext context);
}

/// <summary>
/// Provides a SHA-256 hash for the Blazor import map definition.
/// </summary>
/// <remarks>
/// By the time the Blazor endpoint is executed, the import map definition is already established and should remain unchanged <br/>
/// <br/>
/// MapRazorComponents --> WithStaticAssets <br/>
/// WithStaticAssets <br/>
///     --> IEndpointConventionBuilder.OnBeforeCreateEndpoints += ResourceCollectionConvention.OnBeforeCreateEndpoints <br/>
///     --> IEndpointConventionBuilder.Add(ResourceCollectionConvention.ApplyConvention) <br/>
/// </remarks>
public class BlazorImportMapDefinitionShaProvider(ILogger<BlazorImportMapDefinitionShaProvider> logger)
    : IBlazorImportMapDefinitionShaProvider
{
    private readonly ILogger<BlazorImportMapDefinitionShaProvider> _logger = logger.ThrowIfNull();
    private string? _importMapDefinitionSha256;

    /// <inheritdoc cref="IBlazorImportMapDefinitionShaProvider"/>
    public string? GetSha256(HttpContext context)
    {
        if (_importMapDefinitionSha256 is not null)
        {
            return _importMapDefinitionSha256;
        }

        var importMapDefinition = context.GetEndpoint()?.Metadata.GetMetadata<ImportMapDefinition>();

        if (importMapDefinition == null)
        {
            _logger.ImportMapDefinitionNotFound();
            return null;
        }

        var sha = CalculateSha256(importMapDefinition.ToString());

        _importMapDefinitionSha256 = sha;

        return sha;
    }

    /// <inheritdoc cref="IBlazorImportMapDefinitionShaProvider"/>
    public static string CalculateSha256(string importMapDefinition)
    {
        var sanitized = importMapDefinition.Replace("\r\n", "\n");
        var bytes = Encoding.UTF8.GetBytes(sanitized);
        var sha = SHA256.HashData(bytes);
        return Convert.ToBase64String(sha);
    }
}
