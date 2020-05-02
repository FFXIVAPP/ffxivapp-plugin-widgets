// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Japanese.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Japanese.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Localization {
    using System.Windows;

    public abstract class Japanese {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context() {
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
            Dictionary.Add("widgets_AboutColorsParsingLabel", "* Colors are used as either ARGB (Alpha, Red, Green, Blue) or a named color (SkyBlue)");
            Dictionary.Add("widgets_ColorsJobsLabel", "COLORS:JOBS");
            Dictionary.Add("widgets_EnmityWidgetSettingsTabLabel", "SETTINGS:ENMITY");
            Dictionary.Add("widgets_FocusTargetWidgetSettingsTabLabel", "SETTINGS:FOCUS TARGET");
            Dictionary.Add("widgets_CurrentTargetWidgetSettingsTabLabel", "SETTINGS:CURRENT TARGET");
            return Dictionary;
        }
    }
}