// FFXIVAPP.Plugin.Widgets
// Chinese.cs
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
            return Dictionary;
        }
    }
}
