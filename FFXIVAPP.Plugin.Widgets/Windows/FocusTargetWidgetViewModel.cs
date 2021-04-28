// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FocusTargetWidgetViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   FocusTargetWidgetViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Windows {
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Sharlayan.Core;

    internal sealed class FocusTargetWidgetViewModel : INotifyPropertyChanged {
        private static Lazy<FocusTargetWidgetViewModel> _instance = new Lazy<FocusTargetWidgetViewModel>(() => new FocusTargetWidgetViewModel());

        private float _focusTargetDistance;

        private double _focusTargetHPPercent;

        private bool _focusTargetIsValid;

        private TargetInfo _targetEntity;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static FocusTargetWidgetViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        public float FocusTargetDistance {
            get {
                return this._focusTargetDistance;
            }

            set {
                this._focusTargetDistance = value;
                this.RaisePropertyChanged();
            }
        }

        public double FocusTargetHPPercent {
            get {
                return this._focusTargetHPPercent;
            }

            set {
                this._focusTargetHPPercent = value;
                this.RaisePropertyChanged();
            }
        }

        public bool FocusTargetIsValid {
            get {
                return this._focusTargetIsValid;
            }

            set {
                this._focusTargetIsValid = value;
                this.RaisePropertyChanged();
            }
        }

        public TargetInfo TargetEntity {
            get {
                return this._targetEntity ?? (this._targetEntity = new TargetInfo());
            }

            set {
                this._targetEntity = value;
                this.RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName,] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}