using Synapse.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStats
{
    public class Config : AbstractConfigSection
    {
        [Description("You can only show 3 Stats at a time, if you do more than 3 nothing will show.")]
        public bool IsEnabled = true;

        public bool ShowMostKills = true;

        public string MostKillsText = "<b><color=yellow>%player%</color> has killed the most with <color=yellow>%kills%</color> Kills!</b>";

        public string NoMostKillsText = "<b>Nobody has any Kills!</b>";

        public bool ShowFirstKill = true;

        public string FirstKillText = "<b><color=red>%player%</color> has killed the first player!</b>";

        public string NoFirstKillText = "<b>Nobody has the first Kill!</b>";

        public bool ShowMostDeaths = false;

        public string MostDeathsText = "<b><color=#1632F6>%player%</color> has died the most with <color=#1632F6>%deaths%</color> Deaths!</b>";

        public string NoMostDeathText = "<b>Nobody has any Deaths!</b>";

        public bool ShowFirstDeath = false;

        public string FirstDeathText = "<b><color=#18F610>%player%</color> was the first one to die!</b>";

        public string NoFirstDeathText = "<b>Nobody has the first Death!</b>";

        public bool ShowFastestEscape = true;

        public string FastesEscapeText = "<b>The Player <color=#F6941A>%player%</color> was the first one to escape in <color=#F6941A>%time%</color>!</b>";

        public string NoFastestEscapeText = "<b>Nobody has escaped!</b>";

        public bool ShowEscapeCount = false;

        public string EscapeCountText = "<b>In this round <color=#25F6E3>%escaped%</color> players did escape!</b>";

        public string NoEscapeCountText = "<b>Nobody has escaped!</b>";

        public bool ShowMostSCPsRecontained = false;

        public string MostSCPsRecontainedText = "<b><color=#C53DF6>%player%</color> has recontained <color=#C53DF6>%scps%</color>!</b>";

        public string NoMostSCPsRecontainedText = "<b>Nobody has recontained a SCP Subject!</b>";

    }
}
