// FFXIVAPP.Plugin.Widgets ~ MainViewModel.cs
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

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FFXIVAPP.Common.ViewModelBase;
using FFXIVAPP.Plugin.Widgets.Properties;

namespace FFXIVAPP.Plugin.Widgets.ViewModels
{
    internal sealed class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            ResetEnmityWidgetCommand = new DelegateCommand(ResetEnmityWidget);
            OpenEnmityWidgetCommand = new DelegateCommand(OpenEnmityWidget);
            ResetFocusTargetWidgetCommand = new DelegateCommand(ResetFocusTargetWidget);
            OpenFocusTargetWidgetCommand = new DelegateCommand(OpenFocusTargetWidget);
            ResetCurrentTargetWidgetCommand = new DelegateCommand(ResetCurrentTargetWidget);
            OpenCurrentTargetWidgetCommand = new DelegateCommand(OpenCurrentTargetWidget);
        }

        #region Property Bindings

        private static MainViewModel _instance;

        public static MainViewModel Instance
        {
            get { return _instance ?? (_instance = new MainViewModel()); }
        }

        #endregion

        #region Declarations

        public ICommand ResetEnmityWidgetCommand { get; private set; }
        public ICommand OpenEnmityWidgetCommand { get; private set; }
        public ICommand ResetFocusTargetWidgetCommand { get; private set; }
        public ICommand OpenFocusTargetWidgetCommand { get; private set; }
        public ICommand ResetCurrentTargetWidgetCommand { get; private set; }
        public ICommand OpenCurrentTargetWidgetCommand { get; private set; }

        #endregion

        #region Loading Functions

        #endregion

        #region Utility Functions

        #endregion

        #region Command Bindings

        public void ResetEnmityWidget()
        {
            Settings.Default.EnmityWidgetUIScale = Settings.Default.Properties["EnmityWidgetUIScale"].DefaultValue.ToString();
            Settings.Default.EnmityWidgetTop = Int32.Parse(Settings.Default.Properties["EnmityWidgetTop"].DefaultValue.ToString());
            Settings.Default.EnmityWidgetLeft = Int32.Parse(Settings.Default.Properties["EnmityWidgetLeft"].DefaultValue.ToString());
            Settings.Default.EnmityWidgetHeight = Int32.Parse(Settings.Default.Properties["EnmityWidgetHeight"].DefaultValue.ToString());
            Settings.Default.EnmityWidgetWidth = Int32.Parse(Settings.Default.Properties["EnmityWidgetWidth"].DefaultValue.ToString());
        }

        public void OpenEnmityWidget()
        {
            Settings.Default.ShowEnmityWidgetOnLoad = true;
            Widgets.Instance.ShowEnmityWidget();
        }

        public void ResetFocusTargetWidget()
        {
            Settings.Default.FocusTargetWidgetUIScale = Settings.Default.Properties["FocusTargetWidgetUIScale"].DefaultValue.ToString();
            Settings.Default.FocusTargetWidgetTop = Int32.Parse(Settings.Default.Properties["FocusTargetWidgetTop"].DefaultValue.ToString());
            Settings.Default.FocusTargetWidgetLeft = Int32.Parse(Settings.Default.Properties["FocusTargetWidgetLeft"].DefaultValue.ToString());
            Settings.Default.FocusTargetWidgetHeight = Int32.Parse(Settings.Default.Properties["FocusTargetWidgetHeight"].DefaultValue.ToString());
            Settings.Default.FocusTargetWidgetWidth = Int32.Parse(Settings.Default.Properties["FocusTargetWidgetWidth"].DefaultValue.ToString());
        }

        public void OpenFocusTargetWidget()
        {
            Settings.Default.ShowFocusTargetWidgetOnLoad = true;
            Widgets.Instance.ShowFocusTargetWidget();
        }

        public void ResetCurrentTargetWidget()
        {
            Settings.Default.CurrentTargetWidgetUIScale = Settings.Default.Properties["CurrentTargetWidgetUIScale"].DefaultValue.ToString();
            Settings.Default.CurrentTargetWidgetTop = Int32.Parse(Settings.Default.Properties["CurrentTargetWidgetTop"].DefaultValue.ToString());
            Settings.Default.CurrentTargetWidgetLeft = Int32.Parse(Settings.Default.Properties["CurrentTargetWidgetLeft"].DefaultValue.ToString());
            Settings.Default.CurrentTargetWidgetHeight = Int32.Parse(Settings.Default.Properties["CurrentTargetWidgetHeight"].DefaultValue.ToString());
            Settings.Default.CurrentTargetWidgetWidth = Int32.Parse(Settings.Default.Properties["CurrentTargetWidgetWidth"].DefaultValue.ToString());
        }

        public void OpenCurrentTargetWidget()
        {
            Settings.Default.ShowCurrentTargetWidgetOnLoad = true;
            Widgets.Instance.ShowCurrentTargetWidget();
        }

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
