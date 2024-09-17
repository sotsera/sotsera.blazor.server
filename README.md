![Sotsera.Blazor.Server](icon.png "Sotsera.Blazor.Server")

# sotsera.blazor.Server

Some Blazor Server extensions

[![GitHub license](https://img.shields.io/github/license/sotsera/sotsera.blazor.server?style=flat-square)](LICENSE)
[![Target](https://img.shields.io/static/v1?label=target&message=net9.0&color=512bd4&logo=.net&style=flat-square)](https://dotnet.microsoft.com/en-us/)
[![GitHub last commit](https://img.shields.io/github/last-commit/sotsera/sotsera.blazor.server?display_timestamp=committer&style=flat-square)](https://github.com/sotsera/sotsera.blazor.server)
[![NuGet](https://img.shields.io/nuget/v/sotsera.blazor.server.svg?style=flat-square)](https://www.nuget.org/packages/sotsera.blazor.server/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/sotsera.blazor.server?style=flat-square)](https://www.nuget.org/packages/sotsera.blazor.server/)
[![GitHub Repo stars](https://img.shields.io/github/stars/sotsera/sotsera.blazor.server?style=flat-square)](https://github.com/sotsera/sotsera.blazor.server)

## Security headers

A very simple middleware that adds headers to requests using the `Response.OnStarting` hook. In fact, it allows executing any code on an HttpContext at the start of a request, as it expects a type that implements the interface

```csharp
public interface ISecurityHeadersPolicy
{
    void ApplyHeaders(HttpContext context, IWebHostEnvironment environment);
}
```

I needed a simple way to manage security headers on a Blazor Server site and, well, the name stuck.

## Usage

Add the required services to the `WebApplicationBuilder` and, optionally, configure the only two settings available

```csharp
using Sotsera.Blazor.Server.SecurityHeaders.Blazor;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurityHeaders(c =>
{
    c.DisableKestrelServerHeader = true;
    c.AntiforgeryTokenPrefix = "SuperSecretToken";
});
```

Add the middleware to the pipeline specifying the default policy (example defined below)

```csharp
var app = builder.Build();

app.UseSecurityHeaders(new DefaultPolicy());
```

Override the policy on any IEndpointConventionBuilder like, for example, on a group

```csharp
// This endpoint will have the default policy
app.MapGet("with-default-headers", () => "default headers");

// Override the security headers for a specific or group of endpoints
var group = app.MapGroup("api")
    .RequireSecurityHeaders(new ApiPolicy());

// This endpoint will have the api policy
group.MapGet("with-api-headers", () => "api headers");
```

Disable the security headers for IEndpointConventionBuilder

```csharp
group.MapGet("without-headers", () => "without headers")
    .DisableSecurityHeaders();
```

Override the policy specifically for Blazor server. The library contains a SHA-256 provider for the **importmap** script added by the `<ImportMap />` component which can be resolved and used by a policy.

```csharp
app.MapRazorComponents<App>().AddInteractiveServerRenderMode()
    .RequireSecurityHeaders(new BlazorPolicy());
```

### Example policies

```csharp
// very basic policy
internal class DefaultPolicy : ISecurityHeadersPolicy
{
    public virtual void ApplyHeaders(HttpContext context, IWebHostEnvironment environment)
    {
        var headers = context.Response.Headers;
        headers.Remove("-- header name --");
        headers.XContentTypeOptions = "-- value --";
    }
}

// derived policy
internal class ApiPolicy : DefaultPolicy
{
    public override void ApplyHeaders(HttpContext context, IWebHostEnvironment environment)
    {
        base.ApplyHeaders(context, environment);
        context.Response.Headers.ContentSecurityPolicy = "-- value --";
    }
}

// Blazor specific policy with importmap's SHA-256 in the Csp and a simple Permission policy
internal class BlazorPolicy : DefaultPolicy
{
    public override void ApplyHeaders(HttpContext context, IWebHostEnvironment environment)
    {
        // retrieve the SHA-256 for the importmap script created by the <ImportMap /> component
        var provider = context.GetRequiredService<IBlazorImportMapDefinitionShaProvider>();
        var sha = provider.GetSha256(context);

        // append the sha to the allowed sources
        context.Response.Headers.ContentSecurityPolicy = $"script-src-elem {sha}";

        // disable the camera and geolocation usage
        context.Response.Headers["Permissions-Policy"] = new PermissionsPolicy
        {
            Camera = "()",
            Microphone = "()"
        };
    }
}
```

### Thanks

- Andrew Lock ([@andrewlocknet](https://twitter.com/andrewlocknet)) for [NetEscapades.AspNetCore.SecurityHeaders](https://github.com/andrewlock/NetEscapades.AspNetCore.SecurityHeaders)
- [IconShock (FreeIcons)](https://www.iconshock.com/freeicons/) for the library [icon](https://www.iconshock.com/freeicons/rack-server-solid) (color: #702AF7)
