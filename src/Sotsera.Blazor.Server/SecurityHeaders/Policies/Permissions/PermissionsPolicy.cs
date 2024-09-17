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
    /// <summary>
    /// Gets the list of custom directives.
    /// </summary>
    public List<PermissionsPolicyDirective> CustomDirectives { get; } = [];

    /// <summary>
    /// Gets or sets the accelerometer directive.
    /// </summary>
    public Accelerometer Accelerometer { get; set; } = new();

    /// <summary>
    /// Gets or sets the autoplay directive.
    /// </summary>
    public Autoplay Autoplay { get; set; } = new();

    /// <summary>
    /// Gets or sets the bluetooth directive.
    /// </summary>
    public Bluetooth Bluetooth { get; set; } = new();

    /// <summary>
    /// Gets or sets the browsing topics directive.
    /// </summary>
    public BrowsingTopics BrowsingTopics { get; set; } = new();

    /// <summary>
    /// Gets or sets the camera directive.
    /// </summary>
    public Camera Camera { get; set; } = new();

    /// <summary>
    /// Gets or sets the display capture directive.
    /// </summary>
    public DisplayCapture DisplayCapture { get; set; } = new();

    /// <summary>
    /// Gets or sets the encrypted media directive.
    /// </summary>
    public EncryptedMedia EncryptedMedia { get; set; } = new();

    /// <summary>
    /// Gets or sets the fullscreen directive.
    /// </summary>
    public Fullscreen Fullscreen { get; set; } = new();

    /// <summary>
    /// Gets or sets the gamepad directive.
    /// </summary>
    public Gamepad Gamepad { get; set; } = new();

    /// <summary>
    /// Gets or sets the geolocation directive.
    /// </summary>
    public Geolocation Geolocation { get; set; } = new();

    /// <summary>
    /// Gets or sets the gyroscope directive.
    /// </summary>
    public Gyroscope Gyroscope { get; set; } = new();

    /// <summary>
    /// Gets or sets the hid directive.
    /// </summary>
    public Hid Hid { get; set; } = new();

    /// <summary>
    /// Gets or sets the idle detection directive.
    /// </summary>
    public IdleDetection IdleDetection { get; set; } = new();

    /// <summary>
    /// Gets or sets the local fonts directive.
    /// </summary>
    public LocalFonts LocalFonts { get; set; } = new();

    /// <summary>
    /// Gets or sets the magnetometer directive.
    /// </summary>
    public Magnetometer Magnetometer { get; set; } = new();

    /// <summary>
    /// Gets or sets the microphone directive.
    /// </summary>
    public Microphone Microphone { get; set; } = new();

    /// <summary>
    /// Gets or sets the midi directive.
    /// </summary>
    public Midi Midi { get; set; } = new();

    /// <summary>
    /// Gets or sets the payment directive.
    /// </summary>
    public Payment Payment { get; set; } = new();

    /// <summary>
    /// Gets or sets the picture-in-picture directive.
    /// </summary>
    public PictureInPicture PictureInPicture { get; set; } = new();

    /// <summary>
    /// Gets or sets the public key credentials get directive.
    /// </summary>
    public PublickeyCredentialsGet PublickeyCredentialsGet { get; set; } = new();

    /// <summary>
    /// Gets or sets the screen wake lock directive.
    /// </summary>
    public ScreenWakeLock ScreenWakeLock { get; set; } = new();

    /// <summary>
    /// Gets or sets the serial directive.
    /// </summary>
    public Serial Serial { get; set; } = new();

    /// <summary>
    /// Gets or sets the usb directive.
    /// </summary>
    public Usb Usb { get; set; } = new();

    /// <summary>
    /// Gets or sets the web share directive.
    /// </summary>
    public WebShare WebShare { get; set; } = new();

    /// <summary>
    /// Gets or sets the XR spatial tracking directive.
    /// </summary>
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

    /// <summary>
    /// Disables all directives by setting their values to "()".
    /// </summary>
    /// <returns>The current <see cref="PermissionsPolicy"/> instance.</returns>
    public PermissionsPolicy DisableAll()
    {
        foreach (var directive in AllDirectives)
        {
            directive.Value = "()";
        }

        return this;
    }

    /// <summary>
    /// Implicitly converts a <see cref="PermissionsPolicy"/> instance to a <see cref="StringValues"/> instance.
    /// </summary>
    /// <param name="policy">The <see cref="PermissionsPolicy"/> instance to convert.</param>
    public static implicit operator StringValues(PermissionsPolicy policy)
    {
        return new StringValues(policy.Build());
    }

    private string Build()
    {
        var builder = new StringBuilder();
        var first = true;

        foreach (var directive in AllDirectives.Where(x => x.Value.IsNonEmpty()))
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
