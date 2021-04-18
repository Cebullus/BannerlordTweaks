﻿using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;


namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "CalculateMobilePartyMemberSizeLimit")]
    public class DefaultPartySizeLimitModelPatch
    {
        static void Postfix(MobileParty party, ref ExplainedNumber __result)
        {
            if (!(party is null) && !(party.LeaderHero is null) && BannerlordTweaksSettings.Instance is { } settings)
            {
                float num;
                if (settings.LeadershipPartySizeBonusEnabled)
                {
                    num = (int)Math.Ceiling(party.LeaderHero.GetSkillValue(DefaultSkills.Leadership) * settings.LeadershipPartySizeBonus * ((party.LeaderHero == Hero.MainHero) ? 1 : settings.PartySizeTweakAIFactor));
                    __result.Add((float)num, new TextObject("BT Leadership bonus"));
                }

                if (settings.StewardPartySizeBonusEnabled && party.LeaderHero == Hero.MainHero)
                {
                    num = (int)Math.Ceiling(party.LeaderHero.GetSkillValue(DefaultSkills.Steward) * settings.StewardPartySizeBonus * ((party.LeaderHero == Hero.MainHero) ? 1:settings.PartySizeTweakAIFactor));
                    __result.Add((float)num, new TextObject("BT Steward bonus"));
                }
                if (settings.BalancingPartySizeTweaksEnabled && settings.KingdomBalanceStrengthEnabled && party.LeaderHero.Clan.Kingdom != null)
                {
                    float num2 = party.LeaderHero.Clan.Kingdom.StringId switch
                    {
                        "vlandia" => settings.VlandiaBoost,
                        "battania" => settings.BattaniaBoost,
                        "empire" => settings.Empire_N_Boost,
                        "empire_s" => settings.Empire_S_Boost,
                        "empire_w" => settings.Empire_W_Boost,
                        "sturgia" => settings.SturgiaBoost,
                        "khuzait" => settings.KhuzaitBoost,
                        "aserai" => settings.AseraiBoost,
                        _ => 0f
                    };

                    if (settings.KingdomBalanceStrengthCEKEnabled)
                    {
                        num2 = party.LeaderHero.Clan.Kingdom.StringId switch
                        {
                            "nordlings" => settings.NordlingsBoost,
                            "vagir" => settings.VagirBoost,
                            "royalist_vlandia" => settings.RoyalistVlandiaBoost,
                            "apolssaly" => settings.ApolssalyBoost,
                            "lyrion" => settings.LyrionBoost,
                            "rebel_khuzait" => settings.RebelKhuzaitBoost,
                            "paleician" => settings.PaleicianBoost,
                            "ariorum" => settings.AriorumBoost,
                            _ => 0f
                        };
                    }

                    if (num2 == 0f && party.LeaderHero.Clan.Kingdom.Leader == Hero.MainHero) num2 = settings.PlayerBoost;
                    __result.Add((float)__result.ResultNumber * num2, new TextObject("BT Balancing Tweak"));
                }
            }
        }

        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && (settings.PartySizeTweakEnabled || settings.KingdomBalanceStrengthEnabled);
    }

    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    public class DefaultPrisonerSizeLimitModelPatch
    {
        private static void Postfix(PartyBase party, ref ExplainedNumber __result)
        {
            if (party.LeaderHero != null && party.LeaderHero == Hero.MainHero)
            {
                if (BannerlordTweaksSettings.Instance is { } settings && settings.PrisonerSizeTweakEnabled)
                {
                    double num = (int)Math.Ceiling(__result.ResultNumber * settings.PrisonerSizeTweakPercent);
                    __result.Add((float)num, new TextObject("BT Prisoner Limit Bonus"));
                }
            }
        }

        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.PrisonerSizeTweakEnabled;
    }
}
