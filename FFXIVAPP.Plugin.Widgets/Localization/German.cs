// --------------------------------------------------------------------------------------------------------------------
// <copyright file="German.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   German.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Localization {
    using System.Windows;

    public abstract class German {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context() {
            Dictionary.Clear();
            Dictionary.Add("widgets_", "*PH*");
            Dictionary.Add("widgets_OpenNowButtonText", "Open Now");
            Dictionary.Add("widgets_ResetPositionButtonText", "Reset Settings");
            Dictionary.Add("widgets_DPSTitleBar", "[DPS]");
            Dictionary.Add("widgets_HPSTitleBar", "[HPS]");
            Dictionary.Add("widgets_DTPSTitleBar", "[DTPS]");
            Dictionary.Add("widgets_EnmityTitleBar", "[ENMITY]");
            Dictionary.Add("widgets_FocusTitleBar", "[FOCUS]");
            Dictionary.Add("widgets_CurrentTitleBar", "[CURRENT]");
            Dictionary.Add("widgets_DPSWidgetHeader", "DPS Widget");
            Dictionary.Add("widgets_HPSWidgetHeader", "HPS Widget");
            Dictionary.Add("widgets_DTPSWidgetHeader", "DTPS Widget");
            Dictionary.Add("widgets_EnmityWidgetHeader", "Enmity Widget");
            Dictionary.Add("widgets_FocusWidgetHeader", "Focus Target Widget");
            Dictionary.Add("widgets_CurrentWidgetHeader", "Current Target Widget");
            Dictionary.Add("widgets_EnableClickThroughHeader", "Enable Click-Through On Widgets");
            Dictionary.Add("widgets_WidgetOpacityHeader", "Widget Opacity");
            Dictionary.Add("widgets_GitHubButtonText", "Open Project Source (GitHub)");
            Dictionary.Add("widgets_ShowTitlesOnWidgetsHeader", "Show Titles On Widgets");
            Dictionary.Add("widgets_ColorsTabHeader", "Colors");
            Dictionary.Add("widgets_DefaultProgressBarForegroundHeader", "Default Progress Bar Foreground");
            Dictionary.Add("widgets_UIScaleHeader", "UI Scale");
            Dictionary.Add("widgets_SortDirectionHeader", "Sort Direction");
            Dictionary.Add("widgets_SortPropertyHeader", "Sort Property");
            Dictionary.Add("widgets_DisplayPropertyHeader", "Display Property");
            Dictionary.Add("widgets_PlayerVisibilityThresholdHeader", "Player Visibility Threshold");
            Dictionary.Add("widgets_EnmityShowCurrentTargetInfoHeader", "Show Current Target");
            Dictionary.Add("widgets_WidgetSettingsTabHeader", "Widget Settings");
            Dictionary.Add("widgets_AboutColorsParsingLabel", "* Colors are used as either ARGB (Alpha, Red, Green, Blue) or a named color (SkyBlue)");
            Dictionary.Add("widgets_ColorsJobsLabel", "COLORS:JOBS");
            Dictionary.Add("widgets_EnmityWidgetSettingsTabLabel", "SETTINGS:ENMITY");
            Dictionary.Add("widgets_FocusTargetWidgetSettingsTabLabel", "SETTINGS:FOCUS TARGET");
            Dictionary.Add("widgets_CurrentTargetWidgetSettingsTabLabel", "SETTINGS:CURRENT TARGET");
            return Dictionary;
        }
    }
}