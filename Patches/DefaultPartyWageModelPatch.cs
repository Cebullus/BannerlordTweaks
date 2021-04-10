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
                if (mobileParty.IsGarrison && (mobileParty.IsMainParty || (mobileParty.Party.MapFaction == Hero.MainHero.MapFaction && settings.ApplyWageTweakToFaction) || settings.ApplyWageTweakToAI))
                {
                    float num2 = settings.GarrisonWagePercent;
                    num2 = orig_result * num2 - orig_result;
                    __result.Add(num2, new TextObject("BT Garrison Wage Tweak"));
                }
            }
        }

        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.PartyWageTweaksEnabled;
    }
}
