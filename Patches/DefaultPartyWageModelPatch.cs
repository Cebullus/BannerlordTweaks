using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), "GetTotalWage")]
    public class DefaultPartyWageModelPatch
    {
        static void Postfix(MobileParty mobileParty, ref ExplainedNumber __result)
        {
            if (BannerlordTweaksSettings.Instance is { } settings && settings.PartyWageTweaksEnabled && mobileParty != null)
            {
                float orig_result = __result.ResultNumber;
                if (!mobileParty.IsGarrison && ( mobileParty.IsMainParty || (mobileParty.Party.MapFaction == Hero.MainHero.MapFaction && settings.ApplyWageTweakToFaction) || settings.ApplyWageTweakToAI))
                {
                    float num = settings.PartyWagePercent;
                    num = orig_result * num - orig_result;
                    __result.Add(num, new TextObject("BT Party Wage Tweak"));
                }
                if (mobileParty.IsGarrison && (mobileParty.CurrentSettlement.OwnerClan == Clan.PlayerClan || (mobileParty.Party.MapFaction == Hero.MainHero.MapFaction && settings.ApplyWageTweakToFaction) || settings.ApplyWageTweakToAI))
                {
                    float num2 = settings.GarrisonWagePercent;
                    num2 = orig_result * num2 - orig_result;
                    __result.Add(num2, new TextObject("BT Garrison Wage Tweak"));
                }
            }

            if (BannerlordTweaksSettings.Instance is { } settings2 && settings2.BalancingWagesTweaksEnabled && settings2.KingdomBalanceStrengthEnabled && mobileParty != null && mobileParty.LeaderHero != null && mobileParty.LeaderHero.Clan.Kingdom != null)
            {
                float num = mobileParty.LeaderHero.Clan.Kingdom.StringId switch
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
                if (num == 0f && mobileParty.LeaderHero.Clan.Kingdom.Leader == Hero.MainHero) num = settings2.PlayerBoost;
                num = __result.ResultNumber * -num;
                __result.Add(num, new TextObject("BT Balancing Tweak"));
            }
        }

        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && (settings.PartyWageTweaksEnabled || settings.KingdomBalanceStrengthEnabled);
    }
}
