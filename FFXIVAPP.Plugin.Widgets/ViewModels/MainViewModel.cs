// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   MainViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.ViewModels {
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    using FFXIVAPP.Common.ViewModelBase;
    using FFXIVAPP.Plugin.Widgets.Properties;

    internal sealed class MainViewModel : INotifyPropertyChanged {
        private static Lazy<MainViewModel> _instance = new Lazy<MainViewModel>(() => new MainViewModel());

        public MainViewModel() {
            this.ResetEnmityWidgetCommand = new DelegateCommand(this.ResetEnmityWidget);
            this.OpenEnmityWidgetCommand = new DelegateCommand(this.OpenEnmityWidget);
            this.ResetFocusTargetWidgetCommand = new DelegateCommand(this.ResetFocusTargetWidget);
            this.OpenFocusTargetWidgetCommand = new DelegateCommand(this.OpenFocusTargetWidget);
            this.ResetCurrentTargetWidgetCommand = new DelegateCommand(this.ResetCurrentTargetWidget);
            this.OpenCurrentTargetWidgetCommand = new DelegateCommand(this.OpenCurrentTargetWidget);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static MainViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        public ICommand OpenCurrentTargetWidgetCommand { get; private set; }

        public ICommand OpenEnmityWidgetCommand { get; private set; }

        public ICommand OpenFocusTargetWidgetCommand { get; private set; }

        public ICommand ResetCurrentTargetWidgetCommand { get; private set; }

        public ICommand ResetEnmityWidgetCommand { get; private set; }

        public ICommand ResetFocusTargetWidgetCommand { get; private set; }

        public void OpenCurrentTargetWidget() {
            Settings.Default.ShowCurrentTargetWidgetOnLoad = true;
            Widgets.Instance.ShowCurrentTargetWidget();
        }

        public void OpenEnmityWidget() {
            Settings.Default.ShowEnmityWidgetOnLoad = true;
            Widgets.Instance.ShowEnmityWidget();
        }

        public void OpenFocusTargetWidget() {
            Settings.Default.ShowFocusTargetWidgetOnLoad = true;
            Widgets.Instance.ShowFocusTargetWidget();
        }

        public void ResetCurrentTargetWidget() {
            Settings.Default.CurrentTargetWidgetUIScale = Settings.Default.Properties["CurrentTargetWidgetUIScale"].DefaultValue.ToString();
            Settings.Default.CurrentTargetWidgetTop = int.Parse(Settings.Default.Properties["CurrentTargetWidgetTop"].DefaultValue.ToString());
            Settings.Default.CurrentTargetWidgetLeft = int.Parse(Settings.Default.Properties["CurrentTargetWidgetLeft"].DefaultValue.ToString());
            Settings.Default.CurrentTargetWidgetHeight = int.Parse(Settings.Default.Properties["CurrentTargetWidgetHeight"].DefaultValue.ToString());
            Settings.Default.CurrentTargetWidgetWidth = int.Parse(Settings.Default.Properties["CurrentTargetWidgetWidth"].DefaultValue.ToString());
        }

        public void ResetEnmityWidget() {
            Settings.Default.EnmityWidgetUIScale = Settings.Default.Properties["EnmityWidgetUIScale"].DefaultValue.ToString();
            Settings.Default.EnmityWidgetTop = int.Parse(Settings.Default.Properties["EnmityWidgetTop"].DefaultValue.ToString());
            Settings.Default.EnmityWidgetLeft = int.Parse(Settings.Default.Properties["EnmityWidgetLeft"].DefaultValue.ToString());
            Settings.Default.EnmityWidgetHeight = int.Parse(Settings.Default.Properties["EnmityWidgetHeight"].DefaultValue.ToString());
            Settings.Default.EnmityWidgetWidth = int.Parse(Settings.Default.Properties["EnmityWidgetWidth"].DefaultValue.ToString());
        }

        public void ResetFocusTargetWidget() {
            Settings.Default.FocusTargetWidgetUIScale = Settings.Default.Properties["FocusTargetWidgetUIScale"].DefaultValue.ToString();
            Settings.Default.FocusTargetWidgetTop = int.Parse(Settings.Default.Properties["FocusTargetWidgetTop"].DefaultValue.ToString());
            Settings.Default.FocusTargetWidgetLeft = int.Parse(Settings.Default.Properties["FocusTargetWidgetLeft"].DefaultValue.ToString());
            Settings.Default.FocusTargetWidgetHeight = int.Parse(Settings.Default.Properties["FocusTargetWidgetHeight"].DefaultValue.ToString());
            Settings.Default.FocusTargetWidgetWidth = int.Parse(Settings.Default.Properties["FocusTargetWidgetWidth"].DefaultValue.ToString());
        }

        private void RaisePropertyChanged([CallerMemberName,] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}