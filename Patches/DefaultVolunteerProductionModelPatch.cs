using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(DefaultVolunteerProductionModel), "GetDailyVolunteerProductionProbability")]
    public class DefaultVolunteerProductionModelPatch
    {
        static void Postfix(Hero hero, int index, Settlement settlement, ref float __result)
        { 
            if (BannerlordTweaksSettings.Instance is { } settings && settings.BalancingTimeRecruitsTweaksEnabled && hero.CurrentSettlement.OwnerClan.Kingdom.StringId != null)
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
                __result = (__result + (num * 0.75f));
            }
        }
        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.KingdomBalanceStrengthEnabled;
    }
}