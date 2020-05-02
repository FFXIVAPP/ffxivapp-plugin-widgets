﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsView.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   SettingsView.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Views {
    /// <summary>
    ///     Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView {
        public static SettingsView View;

        public SettingsView() {
            this.InitializeComponent();
            View = this;
        }
    }
}