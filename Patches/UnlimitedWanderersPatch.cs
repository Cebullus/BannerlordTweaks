﻿using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;


namespace BannerlordTweaks.Patches
{
	[HarmonyPatch(typeof(UrbanCharactersCampaignBehavior), "SpawnUrbanCharactersAtGameStart")]
	
	public static class SpawnUrbanCharactersPatch
	{
		private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> list = new List<CodeInstruction>(instructions);
			list.RemoveRange(147, 3);
			return list.AsEnumerable<CodeInstruction>();
		}

		static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.UnlimitedWanderersPatch;
	}
}
