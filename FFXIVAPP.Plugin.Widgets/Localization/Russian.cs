// FFXIVAPP.Plugin.Widgets
// Russian.cs
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
    public abstract class Russian
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
            Dictionary.Clear();
            Dictionary.Add("widgets_", "*PH*");
            Dictionary.Add("widgets_OpenNowButtonText", "Открыть Сейчас");
            Dictionary.Add("widgets_ResetPositionButtonText", "Сбросить Настройки");
            Dictionary.Add("widgets_DPSTitleBar", "[УВС]");
            Dictionary.Add("widgets_HPSTitleBar", "[ЛВС]");
            Dictionary.Add("widgets_DTPSTitleBar", "[УВСД]");
            Dictionary.Add("widgets_EnmityTitleBar", "[АГРЕССИЯ]");
            Dictionary.Add("widgets_FocusTitleBar", "[ЦЕЛЬ в ФОКУСЕ]");
            Dictionary.Add("widgets_CurrentTitleBar", "[ВЫБРАННАЯ ЦЕЛЬ]");
            Dictionary.Add("widgets_DPSWidgetHeader", "ВИДЖЕТ УВС");
            Dictionary.Add("widgets_HPSWidgetHeader", "ВИДЖЕТ ЛВС");
            Dictionary.Add("widgets_DTPSWidgetHeader", "ВИДЖЕТ УВСД");
            Dictionary.Add("widgets_EnmityWidgetHeader", "ВИДЖЕТ АГРЕССИИ");
            Dictionary.Add("widgets_FocusWidgetHeader", "ВИДЖЕТ ЦЕЛЬ в ФОКУСЕ");
            Dictionary.Add("widgets_CurrentWidgetHeader", "ВИДЖЕТ ВЫБРАННАЯ ЦЕЛЬ");
            Dictionary.Add("widgets_EnableClickThroughHeader", "Забокировать Перетаскивание Мышью");
            Dictionary.Add("widgets_WidgetOpacityHeader", "Прозрачность Виджета");
            Dictionary.Add("widgets_GitHubButtonText", "Страница Проекта (GitHub)");
            Dictionary.Add("widgets_ShowTitlesOnWidgetsHeader", "Показать Заголовки на Виджетах");
            Dictionary.Add("widgets_ColorsTabHeader", "Цвета");
            Dictionary.Add("widgets_DefaultProgressBarForegroundHeader", "Стандартный передний план Полоски Прогресса");
            Dictionary.Add("widgets_UIScaleHeader", "Размер Интерфейса");
            Dictionary.Add("widgets_SortDirectionHeader", "Отсортировать по Расположению");
            Dictionary.Add("widgets_SortPropertyHeader", "Сортировать по Свойствам");
            Dictionary.Add("widgets_DisplayPropertyHeader", "Отобразить Свойства");
            Dictionary.Add("widgets_PlayerVisibilityThresholdHeader", "Порого Видимости Игроком");
            Dictionary.Add("widgets_EnmityShowCurrentTargetInfoHeader", "Показать Выбранную Цель");
            Dictionary.Add("widgets_WidgetSettingsTabHeader", "Настройки Виджета");
            Dictionary.Add("widgets_AboutColorsParsingLabel", "* Цвета используют кодировку ARGB (Alpha, Red, Green, Blue) или именные цвета (SkyBlue)");
            Dictionary.Add("widgets_ColorsJobsLabel", "ЦВЕТА:JOBS");
            Dictionary.Add("widgets_EnmityWidgetSettingsTabLabel", "НАСТРОЙКИ ВИДЖЕТА:АГРЕССИЯ");
            Dictionary.Add("widgets_FocusTargetWidgetSettingsTabLabel", "НАСТРОЙКИ ВИДЖЕТА:ЦЕЛЬ В ФОКУСЕ");
            Dictionary.Add("widgets_CurrentTargetWidgetSettingsTabLabel", "НАСТРОЙКИ ВИДЖЕТА:ВЫБРАННАЯ ЦЕЛЬ");
            return Dictionary;
        }
    }
}
