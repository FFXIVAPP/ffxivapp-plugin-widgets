// FFXIVAPP.Plugin.Widgets ~ EnmityWidgetViewModel.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
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
    internal sealed class EnmityWidgetViewModel : INotifyPropertyChanged
    {
        #region Property Bindings

        private static EnmityWidgetViewModel _instance;
        private float _enmityTargetDistance;
        private double _enmityTargetHPPercent;
        private bool _enmityTargetIsValid;
        private TargetEntity _targetEntity;

        public static EnmityWidgetViewModel Instance
        {
            get { return _instance ?? (_instance = new EnmityWidgetViewModel()); }
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

        public bool EnmityTargetIsValid
        {
            get { return _enmityTargetIsValid; }
            set
            {
                _enmityTargetIsValid = value;
                RaisePropertyChanged();
            }
        }

        public double EnmityTargetHPPercent
        {
            get { return _enmityTargetHPPercent; }
            set
            {
                _enmityTargetHPPercent = value;
                RaisePropertyChanged();
            }
        }

        public float EnmityTargetDistance
        {
            get { return _enmityTargetDistance; }
            set
            {
                _enmityTargetDistance = value;
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
