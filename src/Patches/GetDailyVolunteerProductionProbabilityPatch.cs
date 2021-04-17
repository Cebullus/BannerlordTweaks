using HarmonyLib;
using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(DefaultVolunteerProductionModel), "GetDailyVolunteerProductionProbability")]
    public class GetDailyVolunteerProductionProbabilityPatch
    {

        static void Postfix(Hero hero, int index, Settlement settlement, ref float __result)
        { 
            if (BannerlordTweaksSettings.Instance is { } settings && (hero.CurrentSettlement.OwnerClan.Kingdom.StringId != null))
            {
                float num = 0;
                switch (hero.CurrentSettlement.OwnerClan.Kingdom.StringId)
                {
                    case "vlandia":
                        num = settings.VlandiaBoost;
                        break;
                    case "battania":
                        num = settings.BattaniaBoost;
                        break;
                    case "empire":
                        num = settings.Empire_N_Boost;
                        break;
                    case "empire_s":
                        num = settings.Empire_S_Boost;
                        break;
                    case "empire_w":
                        num = settings.Empire_W_Boost;
                        break;
                    case "sturgia":
                        num = settings.SturgiaBoost;
                        break;
                    case "khuzait":
                        num = settings.KhuzaitBoost;
                        break;
                    case "aserai":
                        num = settings.Aseraiboost;
                        break;
                }
                __result = ((__result + (__result * num)) > 1f ) ? 1f : (__result + (__result * num));
            }
        }
        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && (settings.KingdomBalanceStrengthEnabled && settings.BalancingTimeRecruitsTweaksEnabled);
    }
}