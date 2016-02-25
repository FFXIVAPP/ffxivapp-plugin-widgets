// FFXIVAPP.Plugin.Widgets ~ Russian.cs
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
