// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using BlazorWebAppAutoGlobal.Components;
using BlazorWebAppAutoGlobal.Configuration.SecurityHeaders;
using Sotsera.Blazor.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurityHeaders(true, "SuperSecretName");

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

app.UseSecurityHeaders(new DefaultHeadersPolicy());

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppAutoGlobal.Client._Imports).Assembly)
    .RequireSecurityHeaders(new BlazorSecurityHeaders());

app.Run();

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Program;

