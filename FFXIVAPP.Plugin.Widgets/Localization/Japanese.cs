// FFXIVAPP.Plugin.Widgets
// Japanese.cs
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
    public abstract class Japanese
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
            Dictionary.Clear();
            Dictionary.Add("widgets_", "*PH*");
            Dictionary.Add("widgets_OpenNowButtonText", "ウィジェットを開く");
            Dictionary.Add("widgets_ResetPositionButtonText", "位置をリセットする");
            Dictionary.Add("widgets_DPSTitleBar", "[DPS]");
            Dictionary.Add("widgets_HPSTitleBar", "[HPS]");
            Dictionary.Add("widgets_DTPSTitleBar", "[DTPS]");
            Dictionary.Add("widgets_EnmityTitleBar", "[敵対]");
            Dictionary.Add("widgets_FocusTitleBar", "[フォーカス]");
            Dictionary.Add("widgets_CurrentTitleBar", "[ターゲット中]");
            Dictionary.Add("widgets_DPSWidgetHeader", "DPSウィジェット");
            Dictionary.Add("widgets_HPSWidgetHeader", "HPSウィジェット");
            Dictionary.Add("widgets_DTPSWidgetHeader", "DTPSウィジェット");
            Dictionary.Add("widgets_EnmityWidgetHeader", "敵対ウィジェット");
            Dictionary.Add("widgets_FocusWidgetHeader", "フォーカスターゲットウィジェット");
            Dictionary.Add("widgets_CurrentWidgetHeader", "現在ターゲットウィジェット");
            Dictionary.Add("widgets_EnableClickThroughHeader", "ウィジェット上のクリックを下に通す");
            Dictionary.Add("widgets_WidgetOpacityHeader", "ウィジェット透過率");
            Dictionary.Add("widgets_GitHubButtonText", "プロジェクトソースを開く(GitHub)");
            Dictionary.Add("widgets_ShowTitlesOnWidgetsHeader", "ウィジェットにタイトルを表示する");
            Dictionary.Add("widgets_ColorsTabHeader", "色");
            Dictionary.Add("widgets_DefaultProgressBarForegroundHeader", "前面プログレスバーのデフォルト色");
            Dictionary.Add("widgets_UIScaleHeader", "UI比率");
            Dictionary.Add("widgets_SortDirectionHeader", "ソート順");
            Dictionary.Add("widgets_SortPropertyHeader", "ソート項目");
            Dictionary.Add("widgets_DisplayPropertyHeader", "表示形式");
            Dictionary.Add("widgets_PlayerVisibilityThresholdHeader", "プレイヤー可視率しきい値");
            Dictionary.Add("widgets_EnmityShowCurrentTargetInfoHeader", "現在のターゲットを表示する");
            Dictionary.Add("widgets_WidgetSettingsTabHeader", "ウィジェット設定");
            return Dictionary;
        }
    }
}
