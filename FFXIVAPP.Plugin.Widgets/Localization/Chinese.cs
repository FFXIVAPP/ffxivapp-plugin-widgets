// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Chinese.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Chinese.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Localization {
    using System.Windows;

    public abstract class Chinese {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context() {
            Dictionary.Clear();
            Dictionary.Add("widgets_", "*PH*");
            Dictionary.Add("widgets_OpenNowButtonText", "现在打开");
            Dictionary.Add("widgets_ResetPositionButtonText", "重置设置");
            Dictionary.Add("widgets_DPSTitleBar", "[DPS]");
            Dictionary.Add("widgets_HPSTitleBar", "[HPS]");
            Dictionary.Add("widgets_DTPSTitleBar", "[DTPS]");
            Dictionary.Add("widgets_EnmityTitleBar", "[敌意]");
            Dictionary.Add("widgets_FocusTitleBar", "[焦点]");
            Dictionary.Add("widgets_CurrentTitleBar", "[当前]");
            Dictionary.Add("widgets_DPSWidgetHeader", "DPS 工具");
            Dictionary.Add("widgets_HPSWidgetHeader", "HPS 工具");
            Dictionary.Add("widgets_DTPSWidgetHeader", "DTPS 工具");
            Dictionary.Add("widgets_EnmityWidgetHeader", "Enmity 工具");
            Dictionary.Add("widgets_FocusWidgetHeader", "焦点目标工具");
            Dictionary.Add("widgets_CurrentWidgetHeader", "当前目标工具");
            Dictionary.Add("widgets_EnableClickThroughHeader", "在工具上开启 Click-Through");
            Dictionary.Add("widgets_WidgetOpacityHeader", "不透明工具");
            Dictionary.Add("widgets_GitHubButtonText", "打开项目源代码(GitHub)");
            Dictionary.Add("widgets_ShowTitlesOnWidgetsHeader", "在工具上显示注释");
            Dictionary.Add("widgets_ColorsTabHeader", "颜色");
            Dictionary.Add("widgets_DefaultProgressBarForegroundHeader", "默认前置进度条");
            Dictionary.Add("widgets_UIScaleHeader", "界面精度");
            Dictionary.Add("widgets_SortDirectionHeader", "排序顺序");
            Dictionary.Add("widgets_SortPropertyHeader", "排序属性");
            Dictionary.Add("widgets_DisplayPropertyHeader", "显示属性");
            Dictionary.Add("widgets_PlayerVisibilityThresholdHeader", "玩家可视度门槛");
            Dictionary.Add("widgets_EnmityShowCurrentTargetInfoHeader", "显示当前目标");
            Dictionary.Add("widgets_WidgetSettingsTabHeader", "工具设置");
            Dictionary.Add("widgets_AboutColorsParsingLabel", "* Colors are used as either ARGB (Alpha, Red, Green, Blue) or a named color (SkyBlue)");
            Dictionary.Add("widgets_ColorsJobsLabel", "COLORS:JOBS");
            Dictionary.Add("widgets_EnmityWidgetSettingsTabLabel", "SETTINGS:ENMITY");
            Dictionary.Add("widgets_FocusTargetWidgetSettingsTabLabel", "SETTINGS:FOCUS TARGET");
            Dictionary.Add("widgets_CurrentTargetWidgetSettingsTabLabel", "SETTINGS:CURRENT TARGET");
            return Dictionary;
        }
    }
}