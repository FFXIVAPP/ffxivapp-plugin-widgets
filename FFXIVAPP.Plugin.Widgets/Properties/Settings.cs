// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Settings.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Properties {
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;
    using System.Xml.Linq;

    using FFXIVAPP.Common.Helpers;
    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;

    using NLog;

    using Color = System.Windows.Media.Color;
    using ColorConverter = System.Windows.Media.ColorConverter;
    using FontFamily = System.Drawing.FontFamily;

    internal class Settings : ApplicationSettingsBase, INotifyPropertyChanged {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static Settings _default;

        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static Settings Default {
            get {
                return _default ?? (_default = (Settings) Synchronized(new Settings()));
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Purple")]
        public string BLMProgressBarForeground {
            get {
                return (string) this["BLMProgressBarForeground"];
            }

            set {
                this["BLMProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("GreenYellow")]
        public string BRDProgressBarForeground {
            get {
                return (string) this["BRDProgressBarForeground"];
            }

            set {
                this["BRDProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("#FF000000")]
        public Color ChatBackgroundColor {
            get {
                return (Color) this["ChatBackgroundColor"];
            }

            set {
                this["ChatBackgroundColor"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Microsoft Sans Serif, 12pt")]
        public Font ChatFont {
            get {
                return (Font) this["ChatFont"];
            }

            set {
                this["ChatFont"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int CurrentTargetWidgetHeight {
            get {
                return (int) this["CurrentTargetWidgetHeight"];
            }

            set {
                this["CurrentTargetWidgetHeight"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int CurrentTargetWidgetLeft {
            get {
                return (int) this["CurrentTargetWidgetLeft"];
            }

            set {
                this["CurrentTargetWidgetLeft"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("300")]
        public int CurrentTargetWidgetTop {
            get {
                return (int) this["CurrentTargetWidgetTop"];
            }

            set {
                this["CurrentTargetWidgetTop"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string CurrentTargetWidgetUIScale {
            get {
                return (string) this["CurrentTargetWidgetUIScale"];
            }

            set {
                this["CurrentTargetWidgetUIScale"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
  <string>1.1</string>
  <string>1.2</string>
  <string>1.3</string>
  <string>1.4</string>
  <string>1.5</string>
</ArrayOfString>")]
        public StringCollection CurrentTargetWidgetUIScaleList {
            get {
                return (StringCollection) this["CurrentTargetWidgetUIScaleList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int CurrentTargetWidgetWidth {
            get {
                return (int) this["CurrentTargetWidgetWidth"];
            }

            set {
                this["CurrentTargetWidgetWidth"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("FF00FF00")]
        public string DefaultProgressBarForeground {
            get {
                return (string) this["DefaultProgressBarForeground"];
            }

            set {
                this["DefaultProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("DarkSlateBlue")]
        public string DRGProgressBarForeground {
            get {
                return (string) this["DRGProgressBarForeground"];
            }

            set {
                this["DRGProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int EnmityWidgetHeight {
            get {
                return (int) this["EnmityWidgetHeight"];
            }

            set {
                this["EnmityWidgetHeight"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int EnmityWidgetLeft {
            get {
                return (int) this["EnmityWidgetLeft"];
            }

            set {
                this["EnmityWidgetLeft"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int EnmityWidgetTop {
            get {
                return (int) this["EnmityWidgetTop"];
            }

            set {
                this["EnmityWidgetTop"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string EnmityWidgetUIScale {
            get {
                return (string) this["EnmityWidgetUIScale"];
            }

            set {
                this["EnmityWidgetUIScale"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
  <string>1.1</string>
  <string>1.2</string>
  <string>1.3</string>
  <string>1.4</string>
  <string>1.5</string>
</ArrayOfString>")]
        public StringCollection EnmityWidgetUIScaleList {
            get {
                return (StringCollection) this["EnmityWidgetUIScaleList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int EnmityWidgetWidth {
            get {
                return (int) this["EnmityWidgetWidth"];
            }

            set {
                this["EnmityWidgetWidth"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int FocusTargetWidgetHeight {
            get {
                return (int) this["FocusTargetWidgetHeight"];
            }

            set {
                this["FocusTargetWidgetHeight"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int FocusTargetWidgetLeft {
            get {
                return (int) this["FocusTargetWidgetLeft"];
            }

            set {
                this["FocusTargetWidgetLeft"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("200")]
        public int FocusTargetWidgetTop {
            get {
                return (int) this["FocusTargetWidgetTop"];
            }

            set {
                this["FocusTargetWidgetTop"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string FocusTargetWidgetUIScale {
            get {
                return (string) this["FocusTargetWidgetUIScale"];
            }

            set {
                this["FocusTargetWidgetUIScale"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
  <string>1.1</string>
  <string>1.2</string>
  <string>1.3</string>
  <string>1.4</string>
  <string>1.5</string>
</ArrayOfString>")]
        public StringCollection FocusTargetWidgetUIScaleList {
            get {
                return (StringCollection) this["FocusTargetWidgetUIScaleList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int FocusTargetWidgetWidth {
            get {
                return (int) this["FocusTargetWidgetWidth"];
            }

            set {
                this["FocusTargetWidgetWidth"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("GoldenRod")]
        public string MNKProgressBarForeground {
            get {
                return (string) this["MNKProgressBarForeground"];
            }

            set {
                this["MNKProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("SkyBlue")]
        public string PLDProgressBarForeground {
            get {
                return (string) this["PLDProgressBarForeground"];
            }

            set {
                this["PLDProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("MediumPurple")]
        public string SCHProgressBarForeground {
            get {
                return (string) this["SCHProgressBarForeground"];
            }

            set {
                this["SCHProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowCurrentTargetWidgetOnLoad {
            get {
                return (bool) this["ShowCurrentTargetWidgetOnLoad"];
            }

            set {
                this["ShowCurrentTargetWidgetOnLoad"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowEnmityWidgetCurrentTargetInfo {
            get {
                return (bool) this["ShowEnmityWidgetCurrentTargetInfo"];
            }

            set {
                this["ShowEnmityWidgetCurrentTargetInfo"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowEnmityWidgetOnLoad {
            get {
                return (bool) this["ShowEnmityWidgetOnLoad"];
            }

            set {
                this["ShowEnmityWidgetOnLoad"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowFocusTargetWidgetOnLoad {
            get {
                return (bool) this["ShowFocusTargetWidgetOnLoad"];
            }

            set {
                this["ShowFocusTargetWidgetOnLoad"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowJobNameInWidgets {
            get {
                return (bool) this["ShowJobNameInWidgets"];
            }

            set {
                this["ShowJobNameInWidgets"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowTitlesOnWidgets {
            get {
                return (bool) this["ShowTitlesOnWidgets"];
            }

            set {
                this["ShowTitlesOnWidgets"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("LimeGreen")]
        public string SMNProgressBarForeground {
            get {
                return (string) this["SMNProgressBarForeground"];
            }

            set {
                this["SMNProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("#FF800080")]
        public Color TimeStampColor {
            get {
                return (Color) this["TimeStampColor"];
            }

            set {
                this["TimeStampColor"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Red")]
        public string WARProgressBarForeground {
            get {
                return (string) this["WARProgressBarForeground"];
            }

            set {
                this["WARProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("White")]
        public string WHMProgressBarForeground {
            get {
                return (string) this["WHMProgressBarForeground"];
            }

            set {
                this["WHMProgressBarForeground"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool WidgetClickThroughEnabled {
            get {
                return (bool) this["WidgetClickThroughEnabled"];
            }

            set {
                this["WidgetClickThroughEnabled"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0.7")]
        public string WidgetOpacity {
            get {
                return (string) this["WidgetOpacity"];
            }

            set {
                this["WidgetOpacity"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.5</string>
  <string>0.6</string>
  <string>0.7</string>
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
</ArrayOfString>")]
        public StringCollection WidgetOpacityList {
            get {
                return (StringCollection) this["WidgetOpacityList"];
            }

            set {
                this["WidgetOpacityList"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public double Zoom {
            get {
                return (double) this["Zoom"];
            }

            set {
                this["Zoom"] = value;
                this.RaisePropertyChanged();
            }
        }

        public new void Reset() {
            this.DefaultSettings();
            foreach (var key in Constants.Settings) {
                SettingsProperty settingsProperty = Default.Properties[key];
                if (settingsProperty == null) {
                    continue;
                }

                var value = settingsProperty.DefaultValue.ToString();
                this.SetValue(key, value, CultureInfo.InvariantCulture);
            }
        }

        public override void Save() {
            // this call to default settings only ensures we keep the settings we want and delete the ones we don't (old)
            this.DefaultSettings();
            this.SaveSettingsNode();
            Constants.XSettings.Save(Path.Combine(Common.Constants.PluginsSettingsPath, "FFXIVAPP.Plugin.Widgets.xml"));
        }

        public void SetValue(string key, string value, CultureInfo cultureInfo) {
            try {
                var type = Default[key].GetType().Name;
                switch (type) {
                    case "Boolean":
                        Default[key] = bool.Parse(value);
                        break;
                    case "Color":
                        var cc = new ColorConverter();
                        object color = cc.ConvertFrom(value);
                        Default[key] = color ?? Colors.Black;
                        break;
                    case "Double":
                        Default[key] = double.Parse(value, cultureInfo);
                        break;
                    case "Font":
                        var fc = new FontConverter();
                        object font = fc.ConvertFromString(value);
                        Default[key] = font ?? new Font(new FontFamily("Microsoft Sans Serif"), 12);
                        break;
                    case "Int32":
                        Default[key] = int.Parse(value, cultureInfo);
                        break;
                    default:
                        Default[key] = value;
                        break;
                }
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            this.RaisePropertyChanged(key);
        }

        private void DefaultSettings() {
            Constants.Settings.Clear();

            

            Constants.Settings.Add("EnmityWidgetWidth");
            Constants.Settings.Add("EnmityWidgetHeight");
            Constants.Settings.Add("EnmityWidgetUIScale");
            Constants.Settings.Add("ShowEnmityWidgetOnLoad");
            Constants.Settings.Add("EnmityWidgetTop");
            Constants.Settings.Add("EnmityWidgetLeft");
            Constants.Settings.Add("ShowEnmityWidgetCurrentTargetInfo");
            Constants.Settings.Add("CurrentTargetWidgetWidth");
            Constants.Settings.Add("CurrentTargetWidgetHeight");
            Constants.Settings.Add("CurrentTargetWidgetUIScale");
            Constants.Settings.Add("ShowCurrentTargetWidgetOnLoad");
            Constants.Settings.Add("CurrentTargetWidgetTop");
            Constants.Settings.Add("CurrentTargetWidgetLeft");
            Constants.Settings.Add("FocusTargetWidgetWidth");
            Constants.Settings.Add("FocusTargetWidgetHeight");
            Constants.Settings.Add("FocusTargetWidgetUIScale");
            Constants.Settings.Add("ShowFocusTargetWidgetOnLoad");
            Constants.Settings.Add("FocusTargetWidgetTop");
            Constants.Settings.Add("FocusTargetWidgetLeft");

            

            Constants.Settings.Add("ShowJobNameInWidgets");
            Constants.Settings.Add("WidgetClickThroughEnabled");
            Constants.Settings.Add("ShowTitlesOnWidgets");
            Constants.Settings.Add("WidgetOpacity");

            #region Colors

            Constants.Settings.Add("DefaultProgressBarForeground");
            Constants.Settings.Add("PLDProgressBarForeground");
            Constants.Settings.Add("DRGProgressBarForeground");
            Constants.Settings.Add("BLMProgressBarForeground");
            Constants.Settings.Add("WARProgressBarForeground");
            Constants.Settings.Add("WHMProgressBarForeground");
            Constants.Settings.Add("SCHProgressBarForeground");
            Constants.Settings.Add("MNKProgressBarForeground");
            Constants.Settings.Add("BRDProgressBarForeground");
            Constants.Settings.Add("SMNProgressBarForeground");

            #endregion
        }

        private void RaisePropertyChanged([CallerMemberName] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        private void SaveSettingsNode() {
            if (Constants.XSettings == null) {
                return;
            }

            IEnumerable<XElement> xElements = Constants.XSettings.Descendants().Elements("Setting");
            XElement[] enumerable = xElements as XElement[] ?? xElements.ToArray();
            foreach (var setting in Constants.Settings) {
                XElement element = enumerable.FirstOrDefault(e => e.Attribute("Key").Value == setting);
                var xKey = setting;
                if (Default[xKey] == null) {
                    continue;
                }

                if (element == null) {
                    var xValue = Default[xKey].ToString();
                    List<XValuePair> keyPairList = new List<XValuePair> {
                        new XValuePair {
                            Key = "Value",
                            Value = xValue
                        }
                    };
                    XmlHelper.SaveXmlNode(Constants.XSettings, "Settings", "Setting", xKey, keyPairList);
                }
                else {
                    XElement xElement = element.Element("Value");
                    if (xElement != null) {
                        xElement.Value = Default[setting].ToString();
                    }
                }
            }
        }
    }
}