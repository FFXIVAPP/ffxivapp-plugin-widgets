// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   SettingsViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.ViewModels {
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    internal sealed class SettingsViewModel : INotifyPropertyChanged {
        private static Lazy<SettingsViewModel> _instance = new Lazy<SettingsViewModel>(() => new SettingsViewModel());

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static SettingsViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        private void RaisePropertyChanged([CallerMemberName,] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}