# RoundStats
 Show the best players of each round to everyone on the server!

## Features
* Determine which of the stats you want to show at the end of the round
* Customize the messages for the stats

## Installation
1. [Install Synapse](https://github.com/SynapseSL/Synapse/wiki#hosting-guides)
2. Place the RoundStats.dll file that you can download [here](https://github.com/TheVoidNebula/RoundStats/releases) in your plugin directory
3. Restart/Start your server.

## Config
Name  | Type | Default | Description
------------ | ------------ | ------------- | ------------ 
`IsEnabled` | Boolean | true | Is this plugin enabled?
`ShowMostKills` | Boolean | true | Should the stat `mostKills` be activated? This shows the player who killed the most other players.
`MostKillsText` | String | %player% has killed the most with %kills% Kills! | The text for the stat, the `%%` will be replaced with the actual stat.
`NoMostKillsText` | String | Nobody has any Kills | This text will pop up when no one has got any kills.
`ShowFirstKill` | Boolean | true | Should the stat `firstKill` be activated? This shows the player who has the first kill of the round.
`FirstKillText` | String | %player% has killed the first player! | The text for the stat, the `%%` will be replaced with the actual stat.
`NoFirstKillText` | String | Nobody has the first Kill! | This text will pop up when no did the first kill.
`ShowMostDeaths` | Boolean | false | Should the stat `MostDeaths` be activated? This shows the player who died the most.
`MostDeathsText` | String | %player% has died the most with %deaths% Deaths! | The text for the stat, the `%%` will be replaced with the actual stat.
`NoMostDeathText` | String | Nobody has any Deaths | This text will pop up when nobody did die.
`ShowFirstDeath` | Boolean | false | The text for the stat, the `%%` will be replaced with the actual stat.
`FirstDeathText` | String | %player% was the first one to die! |  The text for the stat, the `%%` will be replaced with the actual stat.
`NoFirstDeathText` | String | Nobody has the first Death! | This text will pop up when nobody did die.
`ShowFastestEscape` | Boolean | true | Should the stat `FastestEscape` be activated? This shows the player who was the first to escape with his escape time.
`FastesEscapeText` | String | The Player %player% was the first one to escape in %time%! | The text for the stat, the `%%` will be replaced with the actual stat.
`NoFastestEscapeText` | String | Nobody has escaped! | This text will pop up when nobody did escape.
`ShowEscapeCount` | Boolean | false | The text for the stat, the `%%` will be replaced with the actual stat.
`EscapeCountText` | String | In this round %escaped% players did escape! |  The text for the stat, the `%%` will be replaced with the actual stat.
`NoEscapeCountText` | String | Nobody has escaped! | This text will pop up when nobody did escape.
`ShowMostSCPsRecontained` | Boolean | false | Should the stat `MostSCPsRecontained` be activated? This shows the player who has killed the most SCPs.
`MostSCPsRecontainedText` | String | %player% has recontained %scps%! | The text for the stat, the `%%` will be replaced with the actual stat.
`NoMostSCPsRecontainedText` | String | Nobody has recontained a SCP Subject! | This text will pop up when nobody did kill a SCP.
