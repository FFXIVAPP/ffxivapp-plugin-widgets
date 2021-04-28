// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnmityWidgetViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   EnmityWidgetViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Windows {
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Sharlayan.Core;

    internal sealed class EnmityWidgetViewModel : INotifyPropertyChanged {
        private static Lazy<EnmityWidgetViewModel> _instance = new Lazy<EnmityWidgetViewModel>(() => new EnmityWidgetViewModel());

        private float _enmityTargetDistance;

        private double _enmityTargetHPPercent;

        private bool _enmityTargetIsValid;

        private TargetInfo _targetEntity;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static EnmityWidgetViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        public float EnmityTargetDistance {
            get {
                return this._enmityTargetDistance;
            }

            set {
                this._enmityTargetDistance = value;
                this.RaisePropertyChanged();
            }
        }

        public double EnmityTargetHPPercent {
            get {
                return this._enmityTargetHPPercent;
            }

            set {
                this._enmityTargetHPPercent = value;
                this.RaisePropertyChanged();
            }
        }

        public bool EnmityTargetIsValid {
            get {
                return this._enmityTargetIsValid;
            }

            set {
                this._enmityTargetIsValid = value;
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