// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ShellViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets {
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;

    using FFXIVAPP.Plugin.Widgets.Interop;
    using FFXIVAPP.Plugin.Widgets.Properties;

    public sealed class ShellViewModel : INotifyPropertyChanged {
        private static Lazy<ShellViewModel> _instance = new Lazy<ShellViewModel>(() => new ShellViewModel());

        public ShellViewModel() {
            Initializer.LoadSettings();
            Initializer.SetupWidgetTopMost();
            Settings.Default.PropertyChanged += DefaultOnPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static ShellViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        internal static void Loaded(object sender, RoutedEventArgs e) {
            ShellView.View.Loaded -= Loaded;
        }

        private static void DefaultOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
            var propertyName = propertyChangedEventArgs.PropertyName;
            switch (propertyName) {
                case "WidgetClickThroughEnabled":
                    WinAPI.ToggleClickThrough(Widgets.Instance.CurrentTargetWidget);
                    WinAPI.ToggleClickThrough(Widgets.Instance.EnmityWidget);
                    WinAPI.ToggleClickThrough(Widgets.Instance.FocusTargetWidget);
                    break;
                case "CurrentTargetWidgetUIScale":
                    try {
                        Settings.Default.CurrentTargetWidgetWidth = (int) (250 * double.Parse(Settings.Default.CurrentTargetWidgetUIScale));
                        Settings.Default.CurrentTargetWidgetHeight = (int) (450 * double.Parse(Settings.Default.CurrentTargetWidgetUIScale));
                    }
                    catch (Exception) {
                        Settings.Default.CurrentTargetWidgetWidth = 250;
                        Settings.Default.CurrentTargetWidgetHeight = 450;
                    }

                    break;
                case "FocusTargetWidgetUIScale":
                    try {
                        Settings.Default.FocusTargetWidgetWidth = (int) (250 * double.Parse(Settings.Default.FocusTargetWidgetUIScale));
                        Settings.Default.FocusTargetWidgetHeight = (int) (450 * double.Parse(Settings.Default.FocusTargetWidgetUIScale));
                    }
                    catch (Exception) {
                        Settings.Default.FocusTargetWidgetWidth = 250;
                        Settings.Default.FocusTargetWidgetHeight = 450;
                    }

                    break;
                case "EnmityWidgetUIScale":
                    try {
                        Settings.Default.EnmityWidgetWidth = (int) (250 * double.Parse(Settings.Default.EnmityWidgetUIScale));
                        Settings.Default.EnmityWidgetHeight = (int) (450 * double.Parse(Settings.Default.EnmityWidgetUIScale));
                    }
                    catch (Exception) {
                        Settings.Default.EnmityWidgetWidth = 250;
                        Settings.Default.EnmityWidgetHeight = 450;
                    }

                    break;
            }
        }

        private void RaisePropertyChanged([CallerMemberName,] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}