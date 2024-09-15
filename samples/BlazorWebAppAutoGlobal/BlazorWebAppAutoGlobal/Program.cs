// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Net.Mime;
using System.Text;
using BlazorWebAppAutoGlobal.Components;
using Sotsera.Blazor.Server;
using Sotsera.Blazor.Server.SecurityHeaders.Policies.DefaultPolicies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurityHeaders(true);

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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.UseSecurityHeaders(new DefaultSecurityHeadersPolicy());

app.MapStaticAssets();

app.MapGroup("api")
    .AddTestApi()
    .RequireSecurityHeaders(new DefaultApiSecurityHeadersPolicy());

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppAutoGlobal.Client._Imports).Assembly)
    .RequireSecurityHeaders(new DefaultBlazorSecurityHeadersPolicy());

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
