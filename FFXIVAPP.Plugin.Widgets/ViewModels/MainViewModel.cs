// FFXIVAPP.Plugin.Widgets
// MainViewModel.cs
// 
// Copyright © 2007 - 2014 Ryan Wilson - All Rights Reserved
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

        public MainViewModel()
        {
            ResetEnmityWidgetCommand = new DelegateCommand(ResetEnmityWidget);
            OpenEnmityWidgetCommand = new DelegateCommand(OpenEnmityWidget);
            ResetFocusTargetWidgetCommand = new DelegateCommand(ResetFocusTargetWidget);
            OpenFocusTargetWidgetCommand = new DelegateCommand(OpenFocusTargetWidget);
            ResetCurrentTargetWidgetCommand = new DelegateCommand(ResetCurrentTargetWidget);
            OpenCurrentTargetWidgetCommand = new DelegateCommand(OpenCurrentTargetWidget);
        }

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
