// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace Sotsera.Blazor.Server.SecurityHeaders.Blazor;

public interface IBlazorImportMapDefinitionShaProvider
{
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
public class BlazorImportMapDefinitionShaProvider : IBlazorImportMapDefinitionShaProvider
{
    private string? _importMapDefinitionSha256;

    public string? GetSha256(HttpContext context)
    {
        var importMapDefinition = context.GetEndpoint()?.Metadata.GetMetadata<ImportMapDefinition>()?.ToString();

        if (importMapDefinition == null)
        {
            return null;
        }

        if (_importMapDefinitionSha256 is not null)
        {
            return _importMapDefinitionSha256;
        }

        var sha = CalculateSha256(importMapDefinition);

        _importMapDefinitionSha256 = sha;

        return sha;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Global
    public string CalculateSha256(string importMapDefinition)
    {
        var sanitized = importMapDefinition.Replace("\r\n", "\n");
        var bytes = Encoding.UTF8.GetBytes(sanitized);
        var sha = SHA256.HashData(bytes);
        return Convert.ToBase64String(sha);
    }
}
