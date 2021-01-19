# RoundStats
 Show the best players of each round to everyone on the server!

## Features
* Determine which of the stats you want to show at the end of the round
* Customize the messages for the stats

## Config
Name  | Type | Default | Description
------------ | ------------ | ------------- | ------------ 
`isEnabled` | Boolean | true | Is this plugin enabled?
`showMostKills` | Boolean | true | Should the stat `mostKills` be activated? This shows the player who killed the most other players.
`mostKillsText` | String | %player% has killed the most with %kills% Kills! | The text for the stat, the `%%` will be replaced with the actual stat.
`noMostKillsText` | String | Nobody has any Kills | This text will pop up when no one has got any kills.
`showFirstKill` | Boolean | true | Should the stat `firstKill` be activated? This shows the player who has the first kill of the round.
`firstKillText` | String | %player% has killed the first player! | The text for the stat, the `%%` will be replaced with the actual stat.
`noFirstKillText` | String | Nobody has the first Kill! | This text will pop up when no did the first kill.
`showMostDeaths` | Boolean | false | Should the stat `MostDeaths` be activated? This shows the player who died the most.
`mostDeathsText` | String | %player% has died the most with %deaths% Deaths! | The text for the stat, the `%%` will be replaced with the actual stat.
`noMostDeathText` | String | Nobody has any Deaths | This text will pop up when nobody did die.
`showFirstDeath` | Boolean | false | The text for the stat, the `%%` will be replaced with the actual stat.
`firstDeathText` | String | %player% was the first one to die! |  The text for the stat, the `%%` will be replaced with the actual stat.
`noFirstDeathText` | String | Nobody has the first Death! | This text will pop up when nobody did die.
`showFastestEscape` | Boolean | true | Should the stat `FastestEscape` be activated? This shows the player who was the first to escape with his escape time.
`fastesEscapeText` | String | The Player %player% was the first one to escape in %time%! | The text for the stat, the `%%` will be replaced with the actual stat.
`noFastestEscapeText` | String | Nobody has escaped! | This text will pop up when nobody did escape.
`showEscapeCount` | Boolean | false | The text for the stat, the `%%` will be replaced with the actual stat.
`escapeCountText` | String | In this round %escaped% players did escape! |  The text for the stat, the `%%` will be replaced with the actual stat.
`noEscapeCountText` | String | Nobody has escaped! | This text will pop up when nobody did escape.
`showMostSCPsRecontained` | Boolean | false | Should the stat `MostSCPsRecontained` be activated? This shows the player who has killed the most SCPs.
`mostSCPsRecontainedText` | String | %player% has recontained %scps%! | The text for the stat, the `%%` will be replaced with the actual stat.
`noMostSCPsRecontainedText` | String | Nobody has recontained a SCP Subject! | This text will pop up when nobody did kill a SCP.
