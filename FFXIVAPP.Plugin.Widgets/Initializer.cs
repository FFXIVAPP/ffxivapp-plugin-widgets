// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Initializer.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Initializer.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets {
    using System.Globalization;
    using System.Xml.Linq;

    using FFXIVAPP.Plugin.Widgets.Helpers;
    using FFXIVAPP.Plugin.Widgets.Properties;

    internal static class Initializer {
        /// <summary>
        /// </summary>
        public static void LoadSettings() {
            if (Constants.XSettings != null) {
                Settings.Default.Reset();
                foreach (XElement xElement in Constants.XSettings.Descendants().Elements("Setting")) {
                    var xKey = (string) xElement.Attribute("Key");
                    var xValue = (string) xElement.Element("Value");
                    if (string.IsNullOrWhiteSpace(xKey) || string.IsNullOrWhiteSpace(xValue)) {
                        return;
                    }

                    if (Constants.Settings.Contains(xKey)) {
                        Settings.Default.SetValue(xKey, xValue, CultureInfo.InvariantCulture);
                    }
                    else {
                        Constants.Settings.Add(xKey);
                    }
                }
            }
        }

        public static void SetupWidgetTopMost() {
            WidgetTopMostHelper.HookWidgetTopMost();
        }
    }
}