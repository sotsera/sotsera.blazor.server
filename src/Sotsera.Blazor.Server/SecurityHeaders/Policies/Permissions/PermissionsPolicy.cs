// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Text;
using Microsoft.Extensions.Primitives;
using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;
using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global

/// <summary>
/// See <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Permissions-Policy"/>
/// Removed because not accepted by chrome
///         ambient-light-sensor, document-domain and speaker-selection: not implemented
/// Removed because not accepted by report-uri
///         attribution-reporting, compute-pressure, identity-credentials-get, otp-credentials,
///         publickey-credentials-create, storage-access, window-management
/// </summary>
public class PermissionsPolicy
{
    public List<PermissionsPolicyDirective> CustomDirectives { get; } = [];

    public Accelerometer Accelerometer { get; set; } = new();
    public Autoplay Autoplay { get; set; } = new();
    public Bluetooth Bluetooth { get; set; } = new();
    public BrowsingTopics BrowsingTopics { get; set; } = new();
    public Camera Camera { get; set; } = new();
    public DisplayCapture DisplayCapture { get; set; } = new();
    public EncryptedMedia EncryptedMedia { get; set; } = new();
    public Fullscreen Fullscreen { get; set; } = new();
    public Gamepad Gamepad { get; set; } = new();
    public Geolocation Geolocation { get; set; } = new();
    public Gyroscope Gyroscope { get; set; } = new();
    public Hid Hid { get; set; } = new();
    public IdleDetection IdleDetection { get; set; } = new();
    public LocalFonts LocalFonts { get; set; } = new();
    public Magnetometer Magnetometer { get; set; } = new();
    public Microphone Microphone { get; set; } = new();
    public Midi Midi { get; set; } = new();
    public Payment Payment { get; set; } = new();
    public PictureInPicture PictureInPicture { get; set; } = new();
    public PublickeyCredentialsGet PublickeyCredentialsGet { get; set; } = new();
    public ScreenWakeLock ScreenWakeLock { get; set; } = new();
    public Serial Serial { get; set; } = new();
    public Usb Usb { get; set; } = new();
    public WebShare WebShare { get; set; } = new();
    public XrSpatialTracking XrSpatialTracking { get; set; } = new();

    private PermissionsPolicyDirective[] AllDirectives =>
    [
        Accelerometer, Autoplay, Bluetooth, BrowsingTopics,
        Camera, DisplayCapture, EncryptedMedia, Fullscreen,
        Gamepad, Geolocation, Gyroscope, Hid, IdleDetection,
        LocalFonts, Magnetometer, Microphone, Midi, Payment,
        PictureInPicture, PublickeyCredentialsGet,
        ScreenWakeLock, Serial, Usb, WebShare, XrSpatialTracking,
        .. CustomDirectives
    ];

    public PermissionsPolicy DisableAll()
    {
        foreach (var directive in AllDirectives)
        {
            directive.Value = "()";
        }

        return this;
    }

    public static implicit operator StringValues(PermissionsPolicy policy)
    {
        return new StringValues(policy.Build());
    }

    private string Build()
    {
        var builder = new StringBuilder();
        var first = true;

        foreach (var directive in AllDirectives.Where(x=>x.Value.IsNonEmpty()))
        {
            if (first)
            {
                first = false;
            }
            else
            {
                builder.Append(", ");
            }

            builder.Append(directive.Name);
            builder.Append('=');
            builder.Append(directive.Value.IsEmpty() ? "()" : directive.Value);
        }

        return builder.ToString();
    }
}
