﻿using Synapse;
using Synapse.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStats.Handlers
{
    class EventHandlers
    {

        public string firstKill;
        public string firstDeath;
        public string firstEscape;
        public Dictionary<string, int> kills = new Dictionary<string, int>();
        public Dictionary<string, int> deaths = new Dictionary<string, int>();
        public Dictionary<string, int> mostSCPsRecontained = new Dictionary<string, int>();
        public Dictionary<string, TimeSpan> escapes = new Dictionary<string, TimeSpan>();

        public EventHandlers()
        {
            Server.Get.Events.Player.PlayerDeathEvent += onKill;
            Server.Get.Events.Player.PlayerEscapesEvent += onEscape;
            Server.Get.Events.Round.RoundEndEvent += onRoundEnd;
            Server.Get.Events.Round.RoundRestartEvent += onRoundRestart;
        }

        public void onKill(Synapse.Api.Events.SynapseEventArguments.PlayerDeathEventArgs ev)
        {
            //code for the first kill
            if (firstKill.IsEmpty() && ev.Killer != ev.Victim)
                firstKill = ev.Killer.DisplayName;

            //code for most kills
            if (!kills.ContainsKey(ev.Killer.DisplayName))
                if (ev.Killer != ev.Victim)
                    kills.Add(ev.Killer.DisplayName, 1);
            else
                if (ev.Killer != ev.Victim)
                    kills[ev.Killer.DisplayName]++;

            //code for most deaths
            if (firstDeath.IsEmpty())
                firstDeath = ev.Victim.DisplayName;

            //code for most kills
            if (!deaths.ContainsKey(ev.Killer.DisplayName))
                    deaths.Add(ev.Victim.DisplayName, 1);
                else
                    deaths[ev.Victim.DisplayName]++;

            //code for Most SCPs recontained
            if (ev.Victim.RealTeam == Team.SCP && !mostSCPsRecontained.ContainsKey(ev.Killer.DisplayName))
                mostSCPsRecontained.Add(ev.Killer.DisplayName, 1);
            else
                mostSCPsRecontained[ev.Killer.DisplayName]++;
        }

        public void onEscape(Synapse.Api.Events.SynapseEventArguments.PlayerEscapeEventArgs ev)
        {
            if (firstEscape == null)
                firstEscape = ev.Player.DisplayName;

            escapes.Add(ev.Player.DisplayName, Map.Get.Round.RoundLength);
        }

        public StringBuilder broadcast = new StringBuilder();
        public void onRoundEnd()
        {
            int min = escapes[firstEscape].Minutes;
            int sek = escapes[firstEscape].Seconds;
            if (Plugin.Config.isEnabled)
            {
                if (Plugin.Config.showEscapeCount == true)
                    if(escapes.IsEmpty())
                        broadcast.Append(Plugin.Config.noEscapeCountText + "\n");
                    else
                    broadcast.Append(Plugin.Config.escapeCountText.Replace("%escaped%", escapes.Keys.Count.ToString()) + "\n");

                if (Plugin.Config.showFastestEscape == true)
                    if(firstEscape.IsEmpty())
                        broadcast.Append(Plugin.Config.noFastestEscapeText + "\n");
                    else 
                        broadcast.Append(Plugin.Config.fastesEscapeText.Replace("%player%", firstEscape).Replace("%time%", min.ToString() + ":" + sek.ToString() + (min == 1 ? "Minute" : "Minuten")) + "\n");

                if (Plugin.Config.showFirstDeath == true)
                    if (firstDeath.IsEmpty())
                        broadcast.Append(Plugin.Config.noFirstDeathText + "\n");
                    else
                        broadcast.Append(Plugin.Config.firstDeathText.Replace("%player%", firstDeath) + "\n");

                if (Plugin.Config.showFirstKill == true)
                    if (firstKill.IsEmpty())
                        broadcast.Append(Plugin.Config.noFirstKillText + "\n");
                    else
                        broadcast.Append(Plugin.Config.firstKillText.Replace("%player%", firstKill) + "\n");

                if (Plugin.Config.showMostDeaths == true)
                    if(deaths.IsEmpty())
                        broadcast.Append(Plugin.Config.noMostDeathText + "\n");
                    else
                        broadcast.Append(Plugin.Config.mostDeathsText.Replace("%player%", deaths.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%deaths%", deaths.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                if (Plugin.Config.showMostKills == true)
                    if (kills.IsEmpty())
                        broadcast.Append(Plugin.Config.noMostKillsText + "\n");
                    else
                        broadcast.Append(Plugin.Config.mostKillsText.Replace("%player%", kills.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%kills%", kills.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                if (Plugin.Config.showMostSCPsRecontained == true)
                    if (mostSCPsRecontained.IsEmpty())
                        broadcast.Append(Plugin.Config.noMostSCPsRecontainedText + "\n");
                    else
                        broadcast.Append(Plugin.Config.mostSCPsRecontainedText.Replace("%player%", mostSCPsRecontained.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%scps%", mostSCPsRecontained.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                Map.Get.SendBroadcast(10, broadcast.ToString());
                firstEscape = "";
                firstKill = "";
                firstDeath = "";
            }
        }

        public void onRoundRestart() => broadcast.Clear();
        
    }
}
