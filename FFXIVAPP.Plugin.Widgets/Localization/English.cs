// FFXIVAPP.Plugin.Widgets
// English.cs
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
    public abstract class English
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
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
