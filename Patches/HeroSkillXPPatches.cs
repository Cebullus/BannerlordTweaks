using HarmonyLib;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(Hero), "AddSkillXp")]
    public class AddSkillXpPatch
    {
        private static FieldInfo? hdFieldInfo = null;

        static bool Prefix(Hero __instance, SkillObject skill, float xpAmount)
        {
            try
            {
                if (hdFieldInfo == null) GetFieldInfo();

                HeroDeveloper hd = (HeroDeveloper)hdFieldInfo!.GetValue(__instance);

                if (!(BannerlordTweaksSettings.Instance is { } settings))
                    return true;

                if (hd != null)
                {
                    if (xpAmount > 0)
                    {
                        if (settings.HeroSkillExperienceMultiplierEnabled && hd.Hero.IsHumanPlayerCharacter)
                        {
                            if (settings.PerSkillBonusEnabled)
                            {
                                float PerSkillBonus = GetPerSkillBonus(skill, xpAmount);
                                xpAmount = PerSkillBonus;
                            }
                            float newXpAmount = (int)Math.Ceiling(xpAmount * settings.HeroSkillExperienceMultiplier);
                            hd.AddSkillXp(skill, newXpAmount, true, true);
                        }
                        else if (settings.CompanionSkillExperienceMultiplierEnabled && !hd.Hero.IsHumanPlayerCharacter &&
                           ( hd.Hero.Clan == Hero.MainHero.Clan) )
                        {
                            if (settings.PerSkillBonusEnabled)
                            {
                                float PerSkillBonus = GetPerSkillBonus(skill, xpAmount);
                                xpAmount = PerSkillBonus;
                            }
                            float newXpAmount = (int)Math.Ceiling(xpAmount * settings.CompanionSkillExperienceMultiplier);
                            hd.AddSkillXp(skill, newXpAmount, true, true);
                        }

                        else 
                            hd.AddSkillXp(skill, xpAmount, true, true);
                    }
                    else
                        hd.AddSkillXp(skill, xpAmount, true, true);
                }
            }
            catch (Exception ex)
            {
                DebugHelpers.ShowError("An exception occurred while trying to apply the hero xp multiplier.", "", ex);
            }
            return false;
        }

        static bool Prepare()
        {
            if (BannerlordTweaksSettings.Instance is { } settings)
            {
                if (settings.SkillExperienceMultipliersEnabled)
                    GetFieldInfo();
                return settings.SkillExperienceMultipliersEnabled;
            }
            else return false;
        }

        private static void GetFieldInfo()
        {
            hdFieldInfo = typeof(Hero).GetField("_heroDeveloper", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        private static float GetPerSkillBonus(SkillObject skill, float xpamount)
        {
            float newxpamount = xpamount;
            string skillname = skill.Name.ToString();

            if (!(BannerlordTweaksSettings.Instance is { } settings))
                return 0;

            return skillname switch
            {
                "Engineering" => (newxpamount * settings.SkillBonusEngineering),
                "Leadership" => (newxpamount * settings.SkillBonusLeadership),
                "Medicine" => (newxpamount * settings.SkillBonusMedicine),
                "Riding" => (newxpamount * settings.SkillBonusRiding),
                "Roguery" => (newxpamount * settings.SkillBonusRoguery),
                "Scouting" => (newxpamount * settings.SkillBonusScouting),
                "Trade" => (newxpamount * settings.SkillBonusTrade),
                "Smithing" => (newxpamount * settings.SkillBonusSmithing),
                _ => xpamount,
            };
        }
    }
}
