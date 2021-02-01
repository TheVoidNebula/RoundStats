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

        public static string FirstKill = "empty";
        public static string FirstDeath = "empty";
        public static string FirstEscape = "empty";
        public static Dictionary<string, int> Kills = new Dictionary<string, int>();
        public static  Dictionary<string, int> Deaths = new Dictionary<string, int>();
        public static Dictionary<string, int> MostSCPsRecontained = new Dictionary<string, int>();
        public static Dictionary<string, TimeSpan> Escapes = new Dictionary<string, TimeSpan>();


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
            if (FirstKill == "empty" && ev.Killer != ev.Victim)
                FirstKill = ev.Killer.NickName;

            //code for most Kills
            if (!Kills.ContainsKey(ev.Killer.NickName))
                if (ev.Killer != ev.Victim)
                    Kills.Add(ev.Killer.NickName, 1);
            else
                if (ev.Killer != ev.Victim)
                    Kills[ev.Killer.NickName]++;

            //code for most Deaths
            if (FirstDeath == "empty")
                FirstDeath = ev.Victim.NickName;

            //code for most Kills
            if (!Deaths.ContainsKey(ev.Killer.NickName))
                    Deaths.Add(ev.Victim.NickName, 1);
                else
                    Deaths[ev.Victim.NickName]++;

            //code for Most SCPs recontained
            if (ev.Victim.RealTeam == Team.SCP && !MostSCPsRecontained.ContainsKey(ev.Killer.NickName))
                MostSCPsRecontained.Add(ev.Killer.NickName, 1);
            else
                MostSCPsRecontained[ev.Killer.NickName]++;
        }

        public void onEscape(Synapse.Api.Events.SynapseEventArguments.PlayerEscapeEventArgs ev)
        {
            if (FirstEscape == "empty")
                FirstEscape = ev.Player.NickName;

            if(!Escapes.ContainsKey(ev.Player.NickName))
                Escapes.Add(ev.Player.NickName, Map.Get.Round.RoundLength);
        }

        public StringBuilder broadcast = new StringBuilder();
        public void onRoundEnd()
        {
            if (Plugin.Config.IsEnabled)
            {
                if (Plugin.Config.ShowEscapeCount)
                    if(Escapes.Count == 0)
                        broadcast.Append(Plugin.Config.NoEscapeCountText + "\n");
                    else
                    broadcast.Append(Plugin.Config.EscapeCountText.Replace("%escaped%", Escapes.Keys.Count().ToString()) + "\n");

                if (Plugin.Config.ShowFastestEscape)
                    if(FirstEscape == "empty")
                        broadcast.Append(Plugin.Config.NoFastestEscapeText + "\n");
                    else
                    {
                        int min = Escapes[FirstEscape].Minutes;
                        int sek = Escapes[FirstEscape].Seconds;
                        broadcast.Append(Plugin.Config.FastesEscapeText.Replace("%player%", FirstEscape).Replace("%time%", min.ToString() + ":" + sek.ToString() + (min == 1 ? "Minute" : "Minuten")) + "\n");
                    }
                        

                if (Plugin.Config.ShowFirstDeath)
                    if (FirstDeath == "empty")
                        broadcast.Append(Plugin.Config.NoFirstDeathText + "\n");
                    else
                        broadcast.Append(Plugin.Config.FirstDeathText.Replace("%player%", FirstDeath) + "\n");

                if (Plugin.Config.ShowFirstKill)
                    if (FirstKill == "empty")
                        broadcast.Append(Plugin.Config.NoFirstKillText + "\n");
                    else
                        broadcast.Append(Plugin.Config.FirstKillText.Replace("%player%", FirstKill) + "\n");

                if (Plugin.Config.ShowMostDeaths)
                    if(Deaths.Count == 0)
                        broadcast.Append(Plugin.Config.NoMostDeathText + "\n");
                    else
                        broadcast.Append(Plugin.Config.MostDeathsText.Replace("%player%", Deaths.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%Deaths%", Deaths.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                if (Plugin.Config.ShowMostKills)
                    if (Kills.Count == 0)
                        broadcast.Append(Plugin.Config.NoMostKillsText + "\n");
                    else
                        broadcast.Append(Plugin.Config.MostKillsText.Replace("%player%", Kills.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%Kills%", Kills.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                if (Plugin.Config.ShowMostSCPsRecontained)
                    if (MostSCPsRecontained.Count == 0)
                        broadcast.Append(Plugin.Config.NoMostSCPsRecontainedText + "\n");
                    else
                        broadcast.Append(Plugin.Config.MostSCPsRecontainedText.Replace("%player%", MostSCPsRecontained.Aggregate((l, r) => l.Value > r.Value ? l : r).Key).Replace("%scps%", MostSCPsRecontained.Aggregate((l, r) => l.Value > r.Value ? l : r).Value.ToString()) + "\n");

                Map.Get.SendBroadcast(10, broadcast.ToString());
                FirstEscape = "empty";
                FirstKill = "empty";
                FirstDeath = "empty";
                Deaths.Clear();
                Kills.Clear();
                Escapes.Clear();
                MostSCPsRecontained.Clear();
            }
        }

        public void onRoundRestart() => broadcast.Clear();
        
    }
}
