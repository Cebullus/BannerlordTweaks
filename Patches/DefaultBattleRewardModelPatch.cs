﻿using HarmonyLib;
using Helpers;
using System;
using System.Windows.Forms;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordTweaks.Patches
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), "CalculateRenownGain")]
    public class DefaultBattleRewardModelPatch
    {
        static bool Prefix(PartyBase party, float renownValueOfBattle, float contributionShare, StatExplainer explanation, ref float __result)
        {
            bool patched = false;
            try
            {
                if (party.LeaderHero != null && party.LeaderHero == Hero.MainHero)
                {
                    ExplainedNumber stat;
                    stat = new ExplainedNumber((renownValueOfBattle * contributionShare) * Settings.Instance.BattleRenownMultiplier, explanation);

                    if (party.IsMobile)
                    {
                        if (party.MobileParty.HasPerk(DefaultPerks.TwoHanded.Notorious))
                        {
                            PerkHelper.AddPerkBonusForParty(DefaultPerks.TwoHanded.Notorious, party.MobileParty, ref stat);
                        }
                        if (party.MobileParty.HasPerk(DefaultPerks.Charm.ShowYourScars))
                        {
                            PerkHelper.AddPerkBonusForParty(DefaultPerks.Charm.ShowYourScars, party.MobileParty, ref stat);
                        }
                    }
                    __result = stat.ResultNumber;
                    patched = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during DefaultBattleRewardModelPatch. Reverting to original behaviour...\n\nException:\n{ex.Message}\n\n{ex.InnerException?.Message}\n\n{ex.InnerException?.InnerException?.Message}");
            }
            return !patched;
        }

        static bool Prepare()
        {
            return Settings.Instance.BattleRenownMultiplierEnabled;
        }
    }
}
