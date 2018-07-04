// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandBuilder.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   CommandBuilder.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Widgets.Utilities {
    using System.Text.RegularExpressions;

    using FFXIVAPP.Common.RegularExpressions;

    public static class CommandBuilder {
        public static readonly Regex CommandsRegEx = new Regex(@"^com:widgets (?<widget>\w+)$", SharedRegEx.DefaultOptions);
    }
}