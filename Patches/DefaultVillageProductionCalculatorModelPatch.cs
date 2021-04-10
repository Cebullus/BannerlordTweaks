﻿using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordTweaks.Patches
{

    [HarmonyPatch(typeof(DefaultVillageProductionCalculatorModel), "CalculateDailyFoodProductionAmount")]
    public class CalculateDailyFoodProductionAmountPatch
    {
        static void Postfix(Village village, ref float __result)
        {
            if (BannerlordTweaksSettings.Instance is { } settings && settings.ProductionTweakEnabled)
            {
                __result = (__result * settings.ProductionFoodTweakEnabled);
            }
            if (BannerlordTweaksSettings.Instance is { } settings2 && settings2.BalancingFoodTweakEnabled && village.TradeBound.OwnerClan.Kingdom != null)
            {
                float num = village.TradeBound.OwnerClan.Kingdom.StringId switch
                {
                    "vlandia" => settings2.VlandiaBoost,
                    "battania" => settings2.BattaniaBoost,
                    "empire" => settings2.Empire_N_Boost,
                    "empire_s" => settings2.Empire_S_Boost,
                    "empire_w" => settings2.Empire_W_Boost,
                    "sturgia" => settings2.SturgiaBoost,
                    "khuzait" => settings2.KhuzaitBoost,
                    "aserai" => settings2.Aseraiboost,
                    _ => 0f
                };
                __result = (__result+ (__result * num));
            }
        }

    static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && (settings.ProductionTweakEnabled || settings.KingdomBalanceStrengthEnabled);
    }

    [HarmonyPatch(typeof(DefaultVillageProductionCalculatorModel), "CalculateDailyProductionAmount")]
    public class CalculateDailyProductionAmountPatch
    {
        static void Postfix(Village village, ItemObject item, ref float __result)
        {
            if ((BannerlordTweaksSettings.Instance is { } settings && settings.ProductionTweakEnabled))
            {
             __result = (__result * settings.ProductionOtherTweakEnabled);
            }
        }
        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.ProductionTweakEnabled;
    }

}