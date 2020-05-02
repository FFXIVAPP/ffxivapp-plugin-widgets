// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FocusTargetWidget.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   FocusTargetWidget.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Windows {
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    using FFXIVAPP.Plugin.Widgets.Interop;
    using FFXIVAPP.Plugin.Widgets.Properties;

    /// <summary>
    ///     Interaction logic for FocusTargetWidget.xaml
    /// </summary>
    public partial class FocusTargetWidget {
        public static FocusTargetWidget View;

        public FocusTargetWidget() {
            View = this;
            this.InitializeComponent();
            View.SourceInitialized += delegate {
                WinAPI.ToggleClickThrough(this);
            };
        }

        private void TitleBar_OnPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (Mouse.LeftButton == MouseButtonState.Pressed) {
                this.DragMove();
            }
        }

        private void Widget_OnClosing(object sender, CancelEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }

        private void WidgetClose_OnClick(object sender, RoutedEventArgs e) {
            Settings.Default.ShowFocusTargetWidgetOnLoad = false;
            this.Close();
        }
    }
}