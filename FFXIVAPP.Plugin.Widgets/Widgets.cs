// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Widgets.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Widgets.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets {
    using System;

    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;
    using FFXIVAPP.Plugin.Widgets.Windows;

    using NLog;

    public class Widgets {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static Lazy<Widgets> _instance = new Lazy<Widgets>(() => new Widgets());

        private CurrentTargetWidget _currentTargetWidget;

        private EnmityWidget _enmityWidget;

        private FocusTargetWidget _focusTargetWidget;

        public static Widgets Instance {
            get {
                return _instance.Value;
            }
        }

        public CurrentTargetWidget CurrentTargetWidget {
            get {
                return this._currentTargetWidget ?? (this._currentTargetWidget = new CurrentTargetWidget());
            }
        }

        public EnmityWidget EnmityWidget {
            get {
                return this._enmityWidget ?? (this._enmityWidget = new EnmityWidget());
            }
        }

        public FocusTargetWidget FocusTargetWidget {
            get {
                return this._focusTargetWidget ?? (this._focusTargetWidget = new FocusTargetWidget());
            }
        }

        public void ShowCurrentTargetWidget() {
            try {
                this.CurrentTargetWidget.Show();
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }

        public void ShowEnmityWidget() {
            try {
                this.EnmityWidget.Show();
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }

        public void ShowFocusTargetWidget() {
            try {
                this.FocusTargetWidget.Show();
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }
    }
}