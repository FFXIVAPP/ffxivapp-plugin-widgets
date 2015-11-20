// FFXIVAPP.Plugin.Widgets
// Settings.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

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

namespace FFXIVAPP.Plugin.Widgets.Properties
{
    internal class Settings : ApplicationSettingsBase, INotifyPropertyChanged
    {
        private static Settings _default;

        public static Settings Default
        {
            get { return _default ?? (_default = ((Settings) (Synchronized(new Settings())))); }
        }

        public override void Save()
        {
            // this call to default settings only ensures we keep the settings we want and delete the ones we don't (old)
            DefaultSettings();
            SaveSettingsNode();
            Constants.XSettings.Save(Path.Combine(Common.Constants.PluginsSettingsPath, "FFXIVAPP.Plugin.Widgets.xml"));
        }

        private void DefaultSettings()
        {
            Constants.Settings.Clear();

            #region Widgets

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

            #endregion

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

        public new void Reset()
        {
            DefaultSettings();
            foreach (var key in Constants.Settings)
            {
                var settingsProperty = Default.Properties[key];
                if (settingsProperty == null)
                {
                    continue;
                }
                var value = settingsProperty.DefaultValue.ToString();
                SetValue(key, value, CultureInfo.InvariantCulture);
            }
        }

        public void SetValue(string key, string value, CultureInfo cultureInfo)
        {
            try
            {
                var type = Default[key].GetType()
                                       .Name;
                switch (type)
                {
                    case "Boolean":
                        Default[key] = Boolean.Parse(value);
                        break;
                    case "Color":
                        var cc = new ColorConverter();
                        var color = cc.ConvertFrom(value);
                        Default[key] = color ?? Colors.Black;
                        break;
                    case "Double":
                        Default[key] = Double.Parse(value, cultureInfo);
                        break;
                    case "Font":
                        var fc = new FontConverter();
                        var font = fc.ConvertFromString(value);
                        Default[key] = font ?? new Font(new FontFamily("Microsoft Sans Serif"), 12);
                        break;
                    case "Int32":
                        Default[key] = Int32.Parse(value, cultureInfo);
                        break;
                    default:
                        Default[key] = value;
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.Log(LogManager.GetCurrentClassLogger(), "", ex);
            }
            RaisePropertyChanged(key);
        }

        #region Iterative Settings Saving

        private void SaveSettingsNode()
        {
            if (Constants.XSettings == null)
            {
                return;
            }
            var xElements = Constants.XSettings.Descendants()
                                     .Elements("Setting");
            var enumerable = xElements as XElement[] ?? xElements.ToArray();
            foreach (var setting in Constants.Settings)
            {
                var element = enumerable.FirstOrDefault(e => e.Attribute("Key")
                                                              .Value == setting);
                var xKey = setting;
                if (Default[xKey] == null)
                {
                    continue;
                }
                if (element == null)
                {
                    var xValue = Default[xKey].ToString();
                    var keyPairList = new List<XValuePair>
                    {
                        new XValuePair
                        {
                            Key = "Value",
                            Value = xValue
                        }
                    };
                    XmlHelper.SaveXmlNode(Constants.XSettings, "Settings", "Setting", xKey, keyPairList);
                }
                else
                {
                    var xElement = element.Element("Value");
                    if (xElement != null)
                    {
                        xElement.Value = Default[setting].ToString();
                    }
                }
            }
        }

        #endregion

        #region Property Bindings (Settings)

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("#FF000000")]
        public Color ChatBackgroundColor
        {
            get { return ((Color) (this["ChatBackgroundColor"])); }
            set
            {
                this["ChatBackgroundColor"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("#FF800080")]
        public Color TimeStampColor
        {
            get { return ((Color) (this["TimeStampColor"])); }
            set
            {
                this["TimeStampColor"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Microsoft Sans Serif, 12pt")]
        public Font ChatFont
        {
            get { return ((Font) (this["ChatFont"])); }
            set
            {
                this["ChatFont"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public Double Zoom
        {
            get { return ((Double) (this["Zoom"])); }
            set
            {
                this["Zoom"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0.7")]
        public string WidgetOpacity
        {
            get { return ((string) (this["WidgetOpacity"])); }
            set
            {
                this["WidgetOpacity"] = value;
                RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.5</string>
  <string>0.6</string>
  <string>0.7</string>
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
</ArrayOfString>")]
        public StringCollection WidgetOpacityList
        {
            get { return ((StringCollection) (this["WidgetOpacityList"])); }
            set
            {
                this["WidgetOpacityList"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool WidgetClickThroughEnabled
        {
            get { return ((bool) (this["WidgetClickThroughEnabled"])); }
            set
            {
                this["WidgetClickThroughEnabled"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowTitlesOnWidgets
        {
            get { return ((bool) (this["ShowTitlesOnWidgets"])); }
            set
            {
                this["ShowTitlesOnWidgets"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowJobNameInWidgets
        {
            get { return ((bool) (this["ShowJobNameInWidgets"])); }
            set
            {
                this["ShowJobNameInWidgets"] = value;
                RaisePropertyChanged();
            }
        }

        #region Widget Color Settings

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("FF00FF00")]
        public string DefaultProgressBarForeground
        {
            get { return ((string) (this["DefaultProgressBarForeground"])); }
            set
            {
                this["DefaultProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("SkyBlue")]
        public string PLDProgressBarForeground
        {
            get { return ((string) (this["PLDProgressBarForeground"])); }
            set
            {
                this["PLDProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("DarkSlateBlue")]
        public string DRGProgressBarForeground
        {
            get { return ((string) (this["DRGProgressBarForeground"])); }
            set
            {
                this["DRGProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Purple")]
        public string BLMProgressBarForeground
        {
            get { return ((string) (this["BLMProgressBarForeground"])); }
            set
            {
                this["BLMProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Red")]
        public string WARProgressBarForeground
        {
            get { return ((string) (this["WARProgressBarForeground"])); }
            set
            {
                this["WARProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("White")]
        public string WHMProgressBarForeground
        {
            get { return ((string) (this["WHMProgressBarForeground"])); }
            set
            {
                this["WHMProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("MediumPurple")]
        public string SCHProgressBarForeground
        {
            get { return ((string) (this["SCHProgressBarForeground"])); }
            set
            {
                this["SCHProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("GoldenRod")]
        public string MNKProgressBarForeground
        {
            get { return ((string) (this["MNKProgressBarForeground"])); }
            set
            {
                this["MNKProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("GreenYellow")]
        public string BRDProgressBarForeground
        {
            get { return ((string) (this["BRDProgressBarForeground"])); }
            set
            {
                this["BRDProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("LimeGreen")]
        public string SMNProgressBarForeground
        {
            get { return ((string) (this["SMNProgressBarForeground"])); }
            set
            {
                this["SMNProgressBarForeground"] = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Enmity Widget Settings

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int EnmityWidgetWidth
        {
            get { return ((int) (this["EnmityWidgetWidth"])); }
            set
            {
                this["EnmityWidgetWidth"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int EnmityWidgetHeight
        {
            get { return ((int) (this["EnmityWidgetHeight"])); }
            set
            {
                this["EnmityWidgetHeight"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string EnmityWidgetUIScale
        {
            get { return ((string) (this["EnmityWidgetUIScale"])); }
            set
            {
                this["EnmityWidgetUIScale"] = value;
                RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(@"<?xml version=""1.0"" encoding=""utf-16""?>
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
        public StringCollection EnmityWidgetUIScaleList
        {
            get { return ((StringCollection) (this["EnmityWidgetUIScaleList"])); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowEnmityWidgetOnLoad
        {
            get { return ((bool) (this["ShowEnmityWidgetOnLoad"])); }
            set
            {
                this["ShowEnmityWidgetOnLoad"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int EnmityWidgetTop
        {
            get { return ((int) (this["EnmityWidgetTop"])); }
            set
            {
                this["EnmityWidgetTop"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int EnmityWidgetLeft
        {
            get { return ((int) (this["EnmityWidgetLeft"])); }
            set
            {
                this["EnmityWidgetLeft"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowEnmityWidgetCurrentTargetInfo
        {
            get { return ((bool) (this["ShowEnmityWidgetCurrentTargetInfo"])); }
            set
            {
                this["ShowEnmityWidgetCurrentTargetInfo"] = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Focus Target Widget Settings

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int FocusTargetWidgetWidth
        {
            get { return ((int) (this["FocusTargetWidgetWidth"])); }
            set
            {
                this["FocusTargetWidgetWidth"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int FocusTargetWidgetHeight
        {
            get { return ((int) (this["FocusTargetWidgetHeight"])); }
            set
            {
                this["FocusTargetWidgetHeight"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string FocusTargetWidgetUIScale
        {
            get { return ((string) (this["FocusTargetWidgetUIScale"])); }
            set
            {
                this["FocusTargetWidgetUIScale"] = value;
                RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(@"<?xml version=""1.0"" encoding=""utf-16""?>
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
        public StringCollection FocusTargetWidgetUIScaleList
        {
            get { return ((StringCollection) (this["FocusTargetWidgetUIScaleList"])); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowFocusTargetWidgetOnLoad
        {
            get { return ((bool) (this["ShowFocusTargetWidgetOnLoad"])); }
            set
            {
                this["ShowFocusTargetWidgetOnLoad"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("200")]
        public int FocusTargetWidgetTop
        {
            get { return ((int) (this["FocusTargetWidgetTop"])); }
            set
            {
                this["FocusTargetWidgetTop"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int FocusTargetWidgetLeft
        {
            get { return ((int) (this["FocusTargetWidgetLeft"])); }
            set
            {
                this["FocusTargetWidgetLeft"] = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Current Target Widget Settings

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("250")]
        public int CurrentTargetWidgetWidth
        {
            get { return ((int) (this["CurrentTargetWidgetWidth"])); }
            set
            {
                this["CurrentTargetWidgetWidth"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("450")]
        public int CurrentTargetWidgetHeight
        {
            get { return ((int) (this["CurrentTargetWidgetHeight"])); }
            set
            {
                this["CurrentTargetWidgetHeight"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string CurrentTargetWidgetUIScale
        {
            get { return ((string) (this["CurrentTargetWidgetUIScale"])); }
            set
            {
                this["CurrentTargetWidgetUIScale"] = value;
                RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(@"<?xml version=""1.0"" encoding=""utf-16""?>
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
        public StringCollection CurrentTargetWidgetUIScaleList
        {
            get { return ((StringCollection) (this["CurrentTargetWidgetUIScaleList"])); }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowCurrentTargetWidgetOnLoad
        {
            get { return ((bool) (this["ShowCurrentTargetWidgetOnLoad"])); }
            set
            {
                this["ShowCurrentTargetWidgetOnLoad"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("300")]
        public int CurrentTargetWidgetTop
        {
            get { return ((int) (this["CurrentTargetWidgetTop"])); }
            set
            {
                this["CurrentTargetWidgetTop"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int CurrentTargetWidgetLeft
        {
            get { return ((int) (this["CurrentTargetWidgetLeft"])); }
            set
            {
                this["CurrentTargetWidgetLeft"] = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #endregion

        #region Implementation of INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion
    }
}
