﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Constants.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Xml.Linq;

    using FFXIVAPP.Common.Helpers;

    public static class Constants {
        public const string LibraryPack = "pack://application:,,,/FFXIVAPP.Plugin.Widgets;component/";

        public static readonly string[] Supported = {
            "ja",
            "fr",
            "en",
            "de",
            "ru",
        };

        private static Dictionary<string, string> _autoTranslate;

        private static Dictionary<string, string> _chatCodes;

        private static Dictionary<string, string[]> _colors;

        private static CultureInfo _cultureInfo;

        private static List<string> _settings;

        private static XDocument _xSettings;

        public static Dictionary<string, string> AutoTranslate {
            get {
                return _autoTranslate ?? (_autoTranslate = new Dictionary<string, string>());
            }

            set {
                _autoTranslate = value;
            }
        }

        public static string BaseDirectory {
            get {
                var appDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
                return Path.Combine(appDirectory, "Plugins", Plugin.PName);
            }
        }

        public static string CharacterName { get; set; }

        public static Dictionary<string, string> ChatCodes {
            get {
                return _chatCodes ?? (_chatCodes = new Dictionary<string, string>());
            }

            set {
                _chatCodes = value;
            }
        }

        public static string ChatCodesXml { get; set; }

        public static Dictionary<string, string[]> Colors {
            get {
                return _colors ?? (_colors = new Dictionary<string, string[]>());
            }

            set {
                _colors = value;
            }
        }

        public static CultureInfo CultureInfo {
            get {
                return _cultureInfo ?? (_cultureInfo = new CultureInfo("en"));
            }

            set {
                _cultureInfo = value;
            }
        }

        public static bool EnableHelpLabels { get; set; }

        public static string GameLanguage { get; set; }

        public static string ServerName { get; set; }

        public static List<string> Settings {
            get {
                return _settings ?? (_settings = new List<string>());
            }

            set {
                _settings = value;
            }
        }

        public static string Theme { get; set; }

        public static XDocument XSettings {
            get {
                var file = Path.Combine(Common.Constants.PluginsSettingsPath, "FFXIVAPP.Plugin.Widgets.xml");
                var legacyFile = "./Plugins/FFXIVAPP.Plugin.Widgets/Settings.xml";
                if (_xSettings != null) {
                    return _xSettings;
                }

                try {
                    var found = File.Exists(file);
                    if (found) {
                        _xSettings = XDocument.Load(file);
                    }
                    else {
                        found = File.Exists(legacyFile);
                        _xSettings = found
                                         ? XDocument.Load(legacyFile)
                                         : ResourceHelper.XDocResource(LibraryPack + "/Defaults/Settings.xml");
                    }
                }
                catch (Exception) {
                    _xSettings = ResourceHelper.XDocResource(LibraryPack + "/Defaults/Settings.xml");
                }

                return _xSettings;
            }

            set {
                _xSettings = value;
            }
        }
    }
}