// FFXIVAPP.Plugin.Widgets ~ FocusTargetWidgetViewModel.cs
// 
// Copyright © 2007 - 2016 Ryan Wilson - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.ComponentModel;
using System.Runtime.CompilerServices;
using FFXIVAPP.Memory.Core;

namespace FFXIVAPP.Plugin.Widgets.Windows
{
    internal sealed class FocusTargetWidgetViewModel : INotifyPropertyChanged
    {
        #region Property Bindings

        private static FocusTargetWidgetViewModel _instance;
        private float _focusTargetDistance;
        private double _focusTargetHPPercent;
        private bool _focusTargetIsValid;
        private TargetEntity _targetEntity;

        public static FocusTargetWidgetViewModel Instance
        {
            get { return _instance ?? (_instance = new FocusTargetWidgetViewModel()); }
        }

        public TargetEntity TargetEntity
        {
            get { return _targetEntity ?? (_targetEntity = new TargetEntity()); }
            set
            {
                _targetEntity = value;
                RaisePropertyChanged();
            }
        }

        public bool FocusTargetIsValid
        {
            get { return _focusTargetIsValid; }
            set
            {
                _focusTargetIsValid = value;
                RaisePropertyChanged();
            }
        }

        public double FocusTargetHPPercent
        {
            get { return _focusTargetHPPercent; }
            set
            {
                _focusTargetHPPercent = value;
                RaisePropertyChanged();
            }
        }

        public float FocusTargetDistance
        {
            get { return _focusTargetDistance; }
            set
            {
                _focusTargetDistance = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Declarations

        #endregion

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
