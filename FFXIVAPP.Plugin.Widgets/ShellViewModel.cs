// FFXIVAPP.Plugin.Widgets
// ShellViewModel.cs
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
using System.Windows;
using FFXIVAPP.Plugin.Widgets.Interop;
using FFXIVAPP.Plugin.Widgets.Properties;

namespace FFXIVAPP.Plugin.Widgets
{
    public sealed class ShellViewModel : INotifyPropertyChanged
    {
        #region Property Bindings

        private static ShellViewModel _instance;

        public static ShellViewModel Instance
        {
            get { return _instance ?? (_instance = new ShellViewModel()); }
        }

        #endregion

        #region Declarations

        #endregion

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
