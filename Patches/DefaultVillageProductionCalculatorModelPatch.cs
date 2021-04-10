using HarmonyLib;
using Helpers;
using System;
using System.Windows.Forms;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.Library;

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
            if (BannerlordTweaksSettings.Instance is { } settings2 && settings2.BalancingFoodTweakEnabled && village.TradeBound.OwnerClan.Kingdom != null)  //Null crash very rarely, added null-check for Kingdom
            {
                float num = 0f;
                switch (village.TradeBound.OwnerClan.Kingdom.StringId)
                {
                    case "vlandia":
                        num = settings2.VlandiaBoost;
                        break;
                    case "battania":
                        num = settings2.BattaniaBoost;
                        break;
                    case "empire":
                        num = settings2.Empire_N_Boost;
                        break;
                    case "empire_s":
                        num = settings2.Empire_S_Boost;
                        break;
                    case "empire_w":
                        num = settings2.Empire_W_Boost;
                        break;
                    case "sturgia":
                        num = settings2.SturgiaBoost;
                        break;
                    case "khuzait":
                        num = settings2.KhuzaitBoost;
                        break;
                    case "aserai":
                        num = settings2.Aseraiboost;
                        break;
                }
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