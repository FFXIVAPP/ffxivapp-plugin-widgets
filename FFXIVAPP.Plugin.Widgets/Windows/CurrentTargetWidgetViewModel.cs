// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentTargetWidgetViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   CurrentTargetWidgetViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Windows {
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Sharlayan.Core;

    internal sealed class CurrentTargetWidgetViewModel : INotifyPropertyChanged {
        private static Lazy<CurrentTargetWidgetViewModel> _instance = new Lazy<CurrentTargetWidgetViewModel>(() => new CurrentTargetWidgetViewModel());

        private float _currentTargetDistance;

        private double _currentTargetHPPercent;

        private bool _currentTargetIsValid;

        private TargetInfo _targetEntity;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static CurrentTargetWidgetViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        public float CurrentTargetDistance {
            get {
                return this._currentTargetDistance;
            }

            set {
                this._currentTargetDistance = value;
                this.RaisePropertyChanged();
            }
        }

        public double CurrentTargetHPPercent {
            get {
                return this._currentTargetHPPercent;
            }

            set {
                this._currentTargetHPPercent = value;
                this.RaisePropertyChanged();
            }
        }

        public bool CurrentTargetIsValid {
            get {
                return this._currentTargetIsValid;
            }

            set {
                this._currentTargetIsValid = value;
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