// FFXIVAPP.Plugin.Widgets ~ Chinese.cs
// 
// Copyright © 2007 - 2016 Ryan Wilson - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Windows;

namespace FFXIVAPP.Plugin.Widgets.Localization
{
    public abstract class Chinese
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
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
