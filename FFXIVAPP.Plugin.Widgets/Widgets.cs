// FFXIVAPP.Plugin.Widgets ~ Widgets.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
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

using System;
using FFXIVAPP.Plugin.Widgets.Windows;

namespace FFXIVAPP.Plugin.Widgets
{
    public class Widgets
    {
        private static Widgets _instance;
        private CurrentTargetWidget _currentTargetWidget;
        private EnmityWidget _enmityWidget;
        private FocusTargetWidget _focusTargetWidget;

        public static Widgets Instance
        {
            get { return _instance ?? (_instance = new Widgets()); }
            set { _instance = value; }
        }

        public EnmityWidget EnmityWidget
        {
            get { return _enmityWidget ?? (_enmityWidget = new EnmityWidget()); }
        }

        public FocusTargetWidget FocusTargetWidget
        {
            get { return _focusTargetWidget ?? (_focusTargetWidget = new FocusTargetWidget()); }
        }

        public CurrentTargetWidget CurrentTargetWidget
        {
            get { return _currentTargetWidget ?? (_currentTargetWidget = new CurrentTargetWidget()); }
        }

        public void ShowEnmityWidget()
        {
            try
            {
                EnmityWidget.Show();
            }
            catch (Exception ex)
            {
            }
        }

        public void ShowFocusTargetWidget()
        {
            try
            {
                FocusTargetWidget.Show();
            }
            catch (Exception ex)
            {
            }
        }

        public void ShowCurrentTargetWidget()
        {
            try
            {
                CurrentTargetWidget.Show();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
