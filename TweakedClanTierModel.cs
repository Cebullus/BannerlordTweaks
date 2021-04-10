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
                return base.GetPartyLimitForTier(clan, clanTierToCheck);

            return (int)Math.Ceiling(result.ResultNumber);
        }            
    }
}
