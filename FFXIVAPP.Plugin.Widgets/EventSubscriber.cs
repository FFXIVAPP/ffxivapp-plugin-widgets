// FFXIVAPP.Plugin.Widgets
// EventSubscriber.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

using System;
using FFXIVAPP.IPluginInterface.Events;
using FFXIVAPP.Memory.Core;
using FFXIVAPP.Plugin.Widgets.Properties;
using FFXIVAPP.Plugin.Widgets.ViewModels;
using FFXIVAPP.Plugin.Widgets.Windows;

namespace FFXIVAPP.Plugin.Widgets
{
    public static class EventSubscriber
    {
        public static void Subscribe()
        {
            Plugin.PHost.NewConstantsEntity += OnNewConstantsEntity;
            //Plugin.PHost.NewChatLogEntry += OnNewChatLogEntry;
            //Plugin.PHost.NewMonsterEntries += OnNewMonsterEntries;
            //Plugin.PHost.NewNPCEntries += OnNewNPCEntries;
            Plugin.PHost.NewPCEntries += OnNewPCEntries;
            //Plugin.PHost.NewPlayerEntity += OnNewPlayerEntity;
            Plugin.PHost.NewTargetEntity += OnNewTargetEntity;
            //Plugin.PHost.NewPartyEntries += OnNewPartyEntries;
        }

        public static void UnSubscribe()
        {
            Plugin.PHost.NewConstantsEntity -= OnNewConstantsEntity;
            //Plugin.PHost.NewChatLogEntry -= OnNewChatLogEntry;
            //Plugin.PHost.NewMonsterEntries -= OnNewMonsterEntries;
            //Plugin.PHost.NewNPCEntries -= OnNewNPCEntries;
            Plugin.PHost.NewPCEntries -= OnNewPCEntries;
            //Plugin.PHost.NewPlayerEntity -= OnNewPlayerEntity;
            Plugin.PHost.NewTargetEntity -= OnNewTargetEntity;
            //Plugin.PHost.NewPartyEntries -= OnNewPartyEntries;
        }

        #region Subscriptions

        private static void OnNewConstantsEntity(object sender, ConstantsEntityEvent constantsEntityEvent)
        {
            // delegate event from constants, not required to subsribe, but recommended as it gives you app settings
            if (sender == null)
            {
                return;
            }
            var constantsEntity = constantsEntityEvent.ConstantsEntity;
            Constants.AutoTranslate = constantsEntity.AutoTranslate;
            Constants.ChatCodes = constantsEntity.ChatCodes;
            Constants.Colors = constantsEntity.Colors;
            Constants.CultureInfo = constantsEntity.CultureInfo;
            Constants.CharacterName = constantsEntity.CharacterName;
            Constants.ServerName = constantsEntity.ServerName;
            Constants.GameLanguage = constantsEntity.GameLanguage;
            Constants.EnableHelpLabels = constantsEntity.EnableHelpLabels;
            Constants.Theme = constantsEntity.Theme;
            PluginViewModel.Instance.EnableHelpLabels = Constants.EnableHelpLabels;
        }

        //private static void OnNewChatLogEntry(object sender, ChatLogEntryEvent chatLogEntryEvent)
        //{
        //    // delegate event from chat log, not required to subsribe
        //    // this updates 100 times a second and only sends a line when it gets a new one
        //    if (sender == null)
        //    {
        //        return;
        //    }
        //    var chatLogEntry = chatLogEntryEvent.ChatLogEntry;
        //    try
        //    {
        //        if (chatLogEntry.Line.ToLower()
        //                        .StartsWith("com:"))
        //        {
        //            LogPublisher.HandleCommands(chatLogEntry);
        //        }
        //        LogPublisher.Process(chatLogEntry);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private static void OnNewMonsterEntries(object sender, ActorEntitiesEvent actorEntitiesEvent)
        //{
        //    // delegate event from monster entities from ram, not required to subsribe
        //    // this updates 10x a second and only sends data if the items are found in ram
        //    // currently there no change/new/removed event handling (looking into it)
        //    if (sender == null)
        //    {
        //        return;
        //    }
        //    var monsterEntities = actorEntitiesEvent.ActorEntities;
        //}

        //private static void OnNewNPCEntries(object sender, ActorEntitiesEvent actorEntitiesEvent)
        //{
        //    // delegate event from npc entities from ram, not required to subsribe
        //    // this list includes anything that is not a player or monster
        //    // this updates 10x a second and only sends data if the items are found in ram
        //    // currently there no change/new/removed event handling (looking into it)
        //    if (sender == null)
        //    {
        //        return;
        //    }
        //    var npcEntities = actorEntitiesEvent.ActorEntities;
        //}

        private static void OnNewPCEntries(object sender, ActorEntitiesEvent actorEntitiesEvent)
        {
            // delegate event from player entities from ram, not required to subsribe
            // this updates 10x a second and only sends data if the items are found in ram
            // currently there no change/new/removed event handling (looking into it)
            if (sender == null)
            {
                return;
            }
            var pcEntities = actorEntitiesEvent.ActorEntities;
            XIVInfoViewModel.Instance.CurrentPCs = pcEntities;
        }

        //private static void OnNewPlayerEntity(object sender, PlayerEntityEvent playerEntityEvent)
        //{
        //    // delegate event from player info from ram, not required to subsribe
        //    // this is for YOU and includes all your stats and your agro list with hate values as %
        //    // this updates 10x a second and only sends data when the newly read data is differen than what was previously sent
        //    if (sender == null)
        //    {
        //        return;
        //    }
        //    var playerEntity = playerEntityEvent.PlayerEntity;
        //}

        private static void OnNewTargetEntity(object sender, TargetEntityEvent targetEntityEvent)
        {
            // delegate event from target info from ram, not required to subsribe
            // this includes the full entities for current, previous, mouseover, focus targets (if 0+ are found)
            // it also includes a list of upto 16 targets that currently have hate on the currently targeted monster
            // these hate values are realtime and change based on the action used
            // this updates 10x a second and only sends data when the newly read data is differen than what was previously sent
            if (sender == null)
            {
                return;
            }
            var targetEntity = targetEntityEvent.TargetEntity;
            var emptyEntity = new TargetEntity();
            // assign empty entity
            EnmityWidgetViewModel.Instance.TargetEntity = emptyEntity;
            FocusTargetWidgetViewModel.Instance.TargetEntity = emptyEntity;
            CurrentTargetWidgetViewModel.Instance.TargetEntity = emptyEntity;
            // assign default current/focus target info
            EnmityWidgetViewModel.Instance.EnmityTargetIsValid = false;
            EnmityWidgetViewModel.Instance.EnmityTargetHPPercent = 0;
            EnmityWidgetViewModel.Instance.EnmityTargetDistance = 0;
            FocusTargetWidgetViewModel.Instance.FocusTargetIsValid = false;
            FocusTargetWidgetViewModel.Instance.FocusTargetHPPercent = 0;
            FocusTargetWidgetViewModel.Instance.FocusTargetDistance = 0;
            CurrentTargetWidgetViewModel.Instance.CurrentTargetIsValid = false;
            CurrentTargetWidgetViewModel.Instance.CurrentTargetHPPercent = 0;
            CurrentTargetWidgetViewModel.Instance.CurrentTargetDistance = 0;
            // if valid assign actual current target info
            if (targetEntity.CurrentTarget != null && targetEntity.CurrentTarget.IsValid && Settings.Default.ShowEnmityWidgetOnLoad)
            {
                EnmityWidgetViewModel.Instance.TargetEntity = targetEntity;
                EnmityWidgetViewModel.Instance.EnmityTargetIsValid = true;
                EnmityWidgetViewModel.Instance.EnmityTargetHPPercent = targetEntity.CurrentTarget.HPPercent;
                try
                {
                    EnmityWidgetViewModel.Instance.EnmityTargetDistance = XIVInfoViewModel.Instance.CurrentUser.GetDistanceTo(targetEntity.CurrentTarget);
                }
                catch (Exception ex)
                {
                }
            }
            // if valid assign actual current target info
            if (targetEntity.CurrentTarget != null && targetEntity.CurrentTarget.IsValid && Settings.Default.ShowCurrentTargetWidgetOnLoad)
            {
                CurrentTargetWidgetViewModel.Instance.TargetEntity = targetEntity;
                CurrentTargetWidgetViewModel.Instance.CurrentTargetIsValid = true;
                CurrentTargetWidgetViewModel.Instance.CurrentTargetHPPercent = targetEntity.CurrentTarget.HPPercent;
                try
                {
                    CurrentTargetWidgetViewModel.Instance.CurrentTargetDistance = XIVInfoViewModel.Instance.CurrentUser.GetDistanceTo(targetEntity.CurrentTarget);
                }
                catch (Exception ex)
                {
                }
            }
            // if valid assign actual focus target info
            if (targetEntity.FocusTarget != null && targetEntity.FocusTarget.IsValid && Settings.Default.ShowFocusTargetWidgetOnLoad)
            {
                FocusTargetWidgetViewModel.Instance.TargetEntity = targetEntity;
                FocusTargetWidgetViewModel.Instance.FocusTargetIsValid = true;
                FocusTargetWidgetViewModel.Instance.FocusTargetHPPercent = targetEntity.FocusTarget.HPPercent;
                try
                {
                    FocusTargetWidgetViewModel.Instance.FocusTargetDistance = XIVInfoViewModel.Instance.CurrentUser.GetDistanceTo(targetEntity.FocusTarget);
                }
                catch (Exception ex)
                {
                }
            }
        }

        //private static void OnNewPartyEntries(object sender, PartyEntitiesEvent partyEntitiesEvent)
        //{
        //    // delegate event that shows current party basic info
        //    if (sender == null)
        //    {
        //        return;
        //    }
        //    var partyEntities = partyEntitiesEvent.PartyEntities;
        //}

        #endregion
    }
}
