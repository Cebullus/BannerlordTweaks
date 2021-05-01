using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;

namespace BannerlordTweaks
{
    public class TweakedClanTierModel : DefaultClanTierModel
    {

        public override int GetCompanionLimit(Clan clan)
        {
            if (BannerlordTweaksSettings.Instance is { } settings && settings.CompanionLimitTweakEnabled)
            {
                int clanTier = clan.Tier;
                int companionLimitFromTier = BannerlordTweaksSettings.Instance.CompanionLimitBonusPerClanTier;

                ExplainedNumber explainedNumber = new ExplainedNumber((float)companionLimitFromTier, false);
                if (clan.Leader.GetPerkValue(DefaultPerks.Leadership.WePledgeOurSwords))
                {
                    explainedNumber.Add(DefaultPerks.Leadership.WePledgeOurSwords.PrimaryBonus, null, null);
                }
                return BannerlordTweaksSettings.Instance.CompanionBaseLimit + (int)explainedNumber.ResultNumber * clanTier;
            }
            else
                return base.GetCompanionLimit(clan);
        }

        public override int GetPartyLimitForTier(Clan clan, int clanTierToCheck)
        {
            ExplainedNumber result = new ExplainedNumber(0f, false);
            if (clan.Leader != null && clan.Leader.GetPerkValue(DefaultPerks.Leadership.TalentMagnet))
            {
                result.Add(DefaultPerks.Leadership.TalentMagnet.SecondaryBonus, DefaultPerks.Leadership.TalentMagnet.Name, null);
            }

            if (BannerlordTweaksSettings.Instance is { } settings2 && settings2.ClanPartiesLimitTweakEnabled && clan == Clan.PlayerClan)
            {
                result.Add((float)(BannerlordTweaksSettings.Instance.BaseClanPartiesLimit + Math.Floor(clanTierToCheck * BannerlordTweaksSettings.Instance.ClanPartiesBonusPerClanTier)), null);
            }
            else if (BannerlordTweaksSettings.Instance is { } settings3 && settings3.AIClanPartiesLimitTweakEnabled && clan.IsClan && !clan.StringId.Contains("_deserters"))
            {
                if (settings3.AICustomSpawnPartiesLimitTweakEnabled && clan.StringId.StartsWith("cs_"))
                {
                    result.Add((float)(base.GetPartyLimitForTier(clan, clanTierToCheck) + BannerlordTweaksSettings.Instance.BaseAICustomSpawnPartiesLimit), new TextObject("BT AI Custom Spawn Parties Tweak"));
                }

                else if (clan.IsClan || (settings3.AIMinorClanPartiesLimitTweakEnabled && clan.IsMinorFaction && !clan.StringId.StartsWith("cs_")))
                {
                    result.Add((float)(base.GetPartyLimitForTier(clan, clanTierToCheck) + BannerlordTweaksSettings.Instance.BaseAIClanPartiesLimit), new TextObject("BT AI Lord Parties Tweak"));
                }
            }
            else
            {
                result.Add((float)(base.GetPartyLimitForTier(clan, clanTierToCheck)),null);
            }

            if (BannerlordTweaksSettings.Instance is { } settings4  && settings4.KingdomBalanceStrengthEnabled && settings4.BalancingPartyLimitTweaksEnabled && clan != null && clan.Kingdom != null)
            {
                float num = 0f;
                if (settings4.KingdomBalanceStrengthVanEnabled)
                {
                    num = clan.Kingdom.StringId switch
                    {
                        "vlandia" => settings4.VlandiaBoost,
                        "battania" => settings4.BattaniaBoost,
                        "empire" => settings4.Empire_N_Boost,
                        "empire_s" => settings4.Empire_S_Boost,
                        "empire_w" => settings4.Empire_W_Boost,
                        "sturgia" => settings4.SturgiaBoost,
                        "khuzait" => settings4.KhuzaitBoost,
                        "aserai" => settings4.AseraiBoost,
                        _ => 0f
                    };
                }
                if (settings4.KingdomBalanceStrengthCEKEnabled)
                {
                    num = clan.Kingdom.StringId switch
                    {
                        "nordlings" => settings4.NordlingsBoost,
                        "vagir" => settings4.VagirBoost,
                        "royalist_vlandia" => settings4.RoyalistVlandiaBoost,
                        "apolssaly" => settings4.ApolssalyBoost,
                        "lyrion" => settings4.LyrionBoost,
                        "rebel_khuzait" => settings4.RebelKhuzaitBoost,
                        "paleician" => settings4.PaleicianBoost,
                        "ariorum" => settings4.AriorumBoost,
                        "vlandia" => settings4.Vlandia_CEK_Boost,
                        "battania" => settings4.Battania_CEK_Boost,
                        "empire" => settings4.Empire_CEK_Boost,
                        "empire_s" => settings4.Empire_S_CEK_Boost,
                        "empire_w" => settings4.Empire_W_CEK_Boost,
                        "sturgia" => settings4.Sturgia_CEK_Boost,
                        "khuzait" => settings4.Khuzait_CEK_Boost,
                        "aserai" => settings4.Aserai_CEK_Boost,
                        _ => 0f
                    };
                }
                if (num == 0f && clan.Kingdom.Leader == Hero.MainHero) num = (settings4.KingdomBalanceStrengthCEKEnabled) ? settings4.Player_CEK_Boost : settings4.PlayerBoost;
                result.Add(result.ResultNumber * num, new TextObject("BT Balancing Tweak"));

            }
            return (int)Math.Ceiling(result.ResultNumber);
        }            
    }
}
