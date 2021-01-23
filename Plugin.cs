using RoundStats.Handlers;
using Synapse.Api.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundStats
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "Show different Stats at the round ending.",
        LoadPriority = 0,
        Name = "RoundStats",
        SynapseMajor = 2,
        SynapseMinor = 5,
        SynapsePatch = 0,
        Version = "b1.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "RoundStats")]
        public static Config Config;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("RoundStats loaded!");

            new EventHandlers();
        }

    }
}