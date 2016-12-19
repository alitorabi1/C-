﻿// Copyright (C) Josh Smith - July 2008
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Windows.Markup;
using System.Xml;

namespace WPF.JoshSmith.Markup
{
    /// <summary>
    /// This markup extension conditionally instantiates the XAML you pass it
    /// if and only if the application is running in full-trust.
    /// </summary>
    /// <remarks>
    /// Documentation: http://joshsmithonwpf.wordpress.com/2008/06/12/writing-xaml-that-gracefully-degrades-in-partial-trust-scenarios/
    /// </remarks>
    [ContentProperty("Xaml")]
    public class IfFullTrustExtension : MarkupExtension
    {
        readonly static bool FullTrust;

        static IfFullTrustExtension()
        {
            try
            {
                var state = PermissionState.Unrestricted;
                new UIPermission(state).Assert();
                FullTrust = true;
            }
            catch { }
        }

        /// <summary>
        /// The XAML that should be turned into live objects
        /// if running with full-trust from the CLR.
        /// </summary>
        public string Xaml { get; set; }

        /// <summary>
        /// Returns the objects declared by the Xaml property
        /// or null, if running in partial-trust.
        /// </summary>
        public override object ProvideValue(IServiceProvider sp)
        {
            object value = null;
            if (FullTrust)
            {
                try
                {
                    using (var str = new StringReader(Xaml))
                    using (var xml = XmlReader.Create(str))
                        value = XamlReader.Load(xml);
                }
                catch (Exception ex)
                {
                    Debug.Fail("Invalid XAML.\r\n" + ex);
                }
            }
            return value;
        }
    }
}