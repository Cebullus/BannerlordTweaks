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
                float num = hero.CurrentSettlement.OwnerClan.Kingdom.StringId switch
                {
                    "vlandia" => settings.VlandiaBoost,
                    "battania" => settings.BattaniaBoost,
                    "empire" => settings.Empire_N_Boost,
                    "empire_s" => settings.Empire_S_Boost,
                    "empire_w" => settings.Empire_W_Boost,
                    "sturgia" => settings.SturgiaBoost,
                    "khuzait" => settings.KhuzaitBoost,
                    "aserai" => settings.Aseraiboost,
                    _ => 0f
                };
                __result = (__result + (num * 0.75f));
            }
        }
        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.KingdomBalanceStrengthEnabled;
    }
}