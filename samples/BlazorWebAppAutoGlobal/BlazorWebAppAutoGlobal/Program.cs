// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Net.Mime;
using System.Text;
using BlazorWebAppAutoGlobal.Components;
using BlazorWebAppAutoGlobal.Configuration.SecurityHeaders;
using Sotsera.Blazor.Server.SecurityHeaders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurityHeaders(c =>
{
    c.DisableKestrelServerHeader = true;
    c.AntiforgeryTokenPrefix = "SuperSecretToken";
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.UseSecurityHeaders(new DefaultHeadersPolicy());

app.MapStaticAssets();

app.MapGroup("api")
    .AddTestApi();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppAutoGlobal.Client._Imports).Assembly)
    .RequireSecurityHeaders(new BlazorSecurityHeaders());

app.Run();

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Program;

internal static class TestApi
{
    public static RouteGroupBuilder AddTestApi(this RouteGroupBuilder builder)
    {
        builder.MapGet("/text", () => "Ciao!");

        builder.MapGet("/json", () => TypedResults.Ok(new { Message = "Ciao!" }));

        builder.MapGet("/json-no-headers", () => TypedResults.Ok(new { Message = "Ciao!" }))
            .DisableSecurityHeaders();

        builder.MapGet("/html", () =>
        {
            const string content = "<html><body><h1>Ciao!</h1></body></html>";
            return TypedResults.Content(content, MediaTypeNames.Text.Html, Encoding.UTF8);
        });

        return builder;
    }
}
