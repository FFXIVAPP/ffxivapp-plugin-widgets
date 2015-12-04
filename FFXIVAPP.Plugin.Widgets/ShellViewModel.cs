// FFXIVAPP.Plugin.Widgets ~ ShellViewModel.cs
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using FFXIVAPP.Plugin.Widgets.Interop;
using FFXIVAPP.Plugin.Widgets.Properties;

namespace FFXIVAPP.Plugin.Widgets
{
    public sealed class ShellViewModel : INotifyPropertyChanged
    {
        public ShellViewModel()
        {
            Initializer.LoadSettings();
            Initializer.SetupWidgetTopMost();
            Settings.Default.PropertyChanged += DefaultOnPropertyChanged;
        }

        internal static void Loaded(object sender, RoutedEventArgs e)
        {
            ShellView.View.Loaded -= Loaded;
        }

        private static void DefaultOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            var propertyName = propertyChangedEventArgs.PropertyName;
            switch (propertyName)
            {
                case "WidgetClickThroughEnabled":
                    WinAPI.ToggleClickThrough(Widgets.Instance.CurrentTargetWidget);
                    WinAPI.ToggleClickThrough(Widgets.Instance.EnmityWidget);
                    WinAPI.ToggleClickThrough(Widgets.Instance.FocusTargetWidget);
                    break;
                case "CurrentTargetWidgetUIScale":
                    try
                    {
                        Settings.Default.CurrentTargetWidgetWidth = (int) (250 * Double.Parse(Settings.Default.CurrentTargetWidgetUIScale));
                        Settings.Default.CurrentTargetWidgetHeight = (int) (450 * Double.Parse(Settings.Default.CurrentTargetWidgetUIScale));
                    }
                    catch (Exception ex)
                    {
                        Settings.Default.CurrentTargetWidgetWidth = 250;
                        Settings.Default.CurrentTargetWidgetHeight = 450;
                    }
                    break;
                case "FocusTargetWidgetUIScale":
                    try
                    {
                        Settings.Default.FocusTargetWidgetWidth = (int) (250 * Double.Parse(Settings.Default.FocusTargetWidgetUIScale));
                        Settings.Default.FocusTargetWidgetHeight = (int) (450 * Double.Parse(Settings.Default.FocusTargetWidgetUIScale));
                    }
                    catch (Exception ex)
                    {
                        Settings.Default.FocusTargetWidgetWidth = 250;
                        Settings.Default.FocusTargetWidgetHeight = 450;
                    }
                    break;
                case "EnmityWidgetUIScale":
                    try
                    {
                        Settings.Default.EnmityWidgetWidth = (int) (250 * Double.Parse(Settings.Default.EnmityWidgetUIScale));
                        Settings.Default.EnmityWidgetHeight = (int) (450 * Double.Parse(Settings.Default.EnmityWidgetUIScale));
                    }
                    catch (Exception ex)
                    {
                        Settings.Default.EnmityWidgetWidth = 250;
                        Settings.Default.EnmityWidgetHeight = 450;
                    }
                    break;
            }
        }

        #region Property Bindings

        private static ShellViewModel _instance;

        public static ShellViewModel Instance
        {
            get { return _instance ?? (_instance = new ShellViewModel()); }
        }

        #endregion

        #region Declarations

        #endregion

        #region Loading Functions

        #endregion

        #region Utility Functions

        #endregion

        #region Command Bindings

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion
    }
}
