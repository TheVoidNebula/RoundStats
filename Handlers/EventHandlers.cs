using Synapse;
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

        public static string firstKill = "empty";
        public static string firstDeath = "empty";
        public static string firstEscape = "empty";
        public static Dictionary<string, int> kills = new Dictionary<string, int>();
        public static  Dictionary<string, int> deaths = new Dictionary<string, int>();
        public static Dictionary<string, int> mostSCPsRecontained = new Dictionary<string, int>();
        public static Dictionary<string, TimeSpan> escapes = new Dictionary<string, TimeSpan>();


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
            if (firstKill == "empty" && ev.Killer != ev.Victim)
                firstKill = ev.Killer.NickName;

            //code for most kills
            if (!kills.ContainsKey(ev.Killer.NickName))
                if (ev.Killer != ev.Victim)
                    kills.Add(ev.Killer.NickName, 1);
            else
                if (ev.Killer != ev.Victim)
                    kills[ev.Killer.NickName]++;

            //code for most deaths
            if (firstDeath == "empty")
                firstDeath = ev.Victim.NickName;

            //code for most kills
            if (!deaths.ContainsKey(ev.Killer.NickName))
                    deaths.Add(ev.Victim.NickName, 1);
                else
                    deaths[ev.Victim.NickName]++;

            //code for Most SCPs recontained
            if (ev.Victim.RealTeam == Team.SCP && !mostSCPsRecontained.ContainsKey(ev.Killer.NickName))
                mostSCPsRecontained.Add(ev.Killer.NickName, 1);
            else
                mostSCPsRecontained[ev.Killer.NickName]++;
        }

        public void onEscape(Synapse.Api.Events.SynapseEventArguments.PlayerEscapeEventArgs ev)
        {
            if (firstEscape == "empty")
                firstEscape = ev.Player.NickName;

            if(!escapes.ContainsKey(ev.Player.NickName))
                escapes.Add(ev.Player.NickName, Map.Get.Round.RoundLength);
        }

        public StringBuilder broadcast = new StringBuilder();
        public void onRoundEnd()
        {
            if (Plugin.Config.isEnabled)
            {
                if (Plugin.Config.showEscapeCount == true)
                    if(escapes.Count == 0)
                        broadcast.Append(Plugin.Config.noEscapeCountText + "\n");
                    else
                    broadcast.Append(Plugin.Config.escapeCountText.Replace("%escaped%", escapes.Keys.Count().ToString()) + "\n");

                if (Plugin.Config.showFastestEscape == true)
                    if(firstEscape == "empty")
                        broadcast.Append(Plugin.Config.noFastestEscapeText + "\n");
                    else
                    {
                        int min = escapes[firstEscape].Minutes;
                        int sek = escapes[firstEscape].Seconds;
                        broadcast.Append(Plugin.Config.fastesEscapeText.Replace("%player%", firstEscape).Replace("%time%", min.ToString() + ":" + sek.ToString() + (min == 1 ? "Minute" : "Minuten")) + "\n");
                    }
                        

                if (Plugin.Config.showFirstDeath == true)
                    if (firstDeath == "empty")
                        broadcast.Append(Plugin.Config.noFirstDeathText + "\n");
                    else
                        broadcast.Append(Plugin.Config.firstDeathText.Replace("%player%", firstDeath) + "\n");

                if (Plugin.Config.showFirstKill == true)
                    if (firstKill == "empty")
                        broadcast.Append(Plugin.Config.noFirstKillText + "\n");
                    else
                        broadcast.Append(Plugin.Config.firstKillText.Replace("%player%", firstKill) + "\n");

                if (Plugin.Config.showMostDeaths == true)
                    if(deaths.Count == 0)
                        broadcast.Append(Plugin.Config.noMostDeathText + "\n");
                    else
                        broadcast.Append(Plugin.Config.mostDeathsText.Replace("%player%", deaths.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%deaths%", deaths.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                if (Plugin.Config.showMostKills == true)
                    if (kills.Count == 0)
                        broadcast.Append(Plugin.Config.noMostKillsText + "\n");
                    else
                        broadcast.Append(Plugin.Config.mostKillsText.Replace("%player%", kills.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%kills%", kills.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                if (Plugin.Config.showMostSCPsRecontained == true)
                    if (mostSCPsRecontained.Count == 0)
                        broadcast.Append(Plugin.Config.noMostSCPsRecontainedText + "\n");
                    else
                        broadcast.Append(Plugin.Config.mostSCPsRecontainedText.Replace("%player%", mostSCPsRecontained.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%scps%", mostSCPsRecontained.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                Map.Get.SendBroadcast(10, broadcast.ToString());
                firstEscape = "empty";
                firstKill = "empty";
                firstDeath = "empty";
                deaths.Clear();
                kills.Clear();
                escapes.Clear();
                mostSCPsRecontained.Clear();
            }
        }

        public void onRoundRestart() => broadcast.Clear();
        
    }
}
