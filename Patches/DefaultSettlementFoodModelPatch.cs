using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Localization;


namespace BannerlordTweaks.Patches
{    
    [HarmonyPatch(typeof(DefaultSettlementFoodModel), "CalculateTownFoodStocksChange")]
    public class DefaultSettlementFoodModelPatch
    {
        static void Postfix(Town town, ref ExplainedNumber __result)
        {
            if (BannerlordTweaksSettings.Instance is { } settings && settings.SettlementFoodBonusEnabled && !(town is null))
            {
                if (settings.SettlementProsperityFoodMalusTweakEnabled && settings.SettlementProsperityFoodMalusDivisor != 50)
                {
                    float malus = town.Owner.Settlement.Prosperity / 50f;
                    TextObject prosperityTextObj = GameTexts.FindText("str_prosperity", null);
                    __result.Add(malus, prosperityTextObj);

                    malus = -town.Owner.Settlement.Prosperity / settings.SettlementProsperityFoodMalusDivisor;
                    __result.Add(malus, prosperityTextObj);
                }
                if (town.IsCastle)
                    __result.Add(Math.Abs(__result.ResultNumber) * (settings.CastleFoodBonus-1), new TextObject("Military rations"));
                else if (town.IsTown)
                    __result.Add(Math.Abs(__result.ResultNumber) * (settings.TownFoodBonus-1), new TextObject("Citizen food drive"));
            }
            return;
        }
        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.SettlementFoodBonusEnabled;
    }
}
