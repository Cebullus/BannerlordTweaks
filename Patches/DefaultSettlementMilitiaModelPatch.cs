using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;
using System;


namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(DefaultSettlementMilitiaModel), "CalculateMilitiaChange")]

    public class DefaultSettlementMilitiaModelPatch
    {
        static void Postfix(Settlement settlement, ref ExplainedNumber __result)
        {
            if (BannerlordTweaksSettings.Instance is { } settings && settings.SettlementMilitiaBonusEnabled && !(settlement is null))
            {
                if (settlement.IsCastle)
                { 
                    __result.Add(settlement.Militia * 0.025f, new TextObject("{=gHnfFi1s}Retired", null));
                    __result.Add(settings.CastleMilitiaRetirementModifier * -settlement.Militia, new TextObject("{=gHnfFi1s}Retired", null));
                    __result.Add(settings.CastleMilitiaBonusFlat, new TextObject("Recruitment drive"));
                }
                if (settlement.IsTown)
                { 
                    __result.Add(settlement.Militia * 0.025f, new TextObject("{=gHnfFi1s}Retired", null));
                    __result.Add(settings.TownMilitiaRetirementModifier * -settlement.Militia, new TextObject("{=gHnfFi1s}Retired", null));
                    __result.Add(settings.TownMilitiaBonusFlat, new TextObject("Citizen militia"));
                }
            }
            return;
        }

        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.SettlementMilitiaBonusEnabled;
    }
}
