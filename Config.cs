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
        public bool isEnabled = true;

        public bool showMostKills = true;

        public string mostKillsText = "<b><color=yellow>%player%</color> has killed the most with <color=yellow>%kills%</color> Kills!</b>";

        public string noMostKillsText = "<b>Nobody has any Kills!</b>";

        public bool showFirstKill = true;

        public string firstKillText = "<b><color=red>%player%</color> has killed the first player!</b>";

        public string noFirstKillText = "<b>Nobody has the first Kill!</b>";

        public bool showMostDeaths = false;

        public string mostDeathsText = "<b><color=#1632F6>%player%</color> has died the most with <color=#1632F6>%deaths%</color> Deaths!</b>";

        public string noMostDeathText = "<b>Nobody has any Deaths!</b>";

        public bool showFirstDeath = false;

        public string firstDeathText = "<b><color=#18F610>%player%</color> was the first one to die!</b>";

        public string noFirstDeathText = "<b>Nobody has the first Death!</b>";

        public bool showFastestEscape = true;

        public string fastesEscapeText = "<b>The Player <color=#F6941A>%player%</color> was the first one to escape in <color=#F6941A>%time%</color>!</b>";

        public string noFastestEscapeText = "<b>Nobody has escaped!</b>";

        public bool showEscapeCount = false;

        public string escapeCountText = "<b>In this round <color=#25F6E3>%escaped%</color> players did escape!</b>";

        public string noEscapeCountText = "<b>Nobody has escaped!</b>";

        public bool showMostSCPsRecontained = false;

        public string mostSCPsRecontainedText = "<b><color=#C53DF6>%player%</color> has recontained <color=#C53DF6>%scps%</color>!</b>";

        public string noMostSCPsRecontainedText = "<b>Nobody has recontained a SCP Subject!</b>";

    }
}
