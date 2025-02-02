﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.Overlay;

namespace BannerlordTweaks
{
    public class SubModule : MBSubModuleBase
    {
        public static readonly string ModuleFolderName = "zzBannerlordTweaks";
        private static Harmony? harmony = null;

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            if (harmony == null)
            {
                try
                {
                    harmony = new Harmony("mod.bannerlord.tweaks");
                    harmony.PatchAll();

                    DebugHelpers.ColorOrangeMessage("Bannerlord Tweaks Loaded");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Initialising Bannerlord Tweaks:\n\n{ex.ToStringFull()}");
                }
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            #pragma warning disable CS8604 // Possible null reference argument.
            AddModels(gameStarter: gameStarterObject as CampaignGameStarter);
            #pragma warning restore CS8604 // Possible null reference argument.

            if (Campaign.Current != null && BannerlordTweaksSettings.Instance is { } settings2 && settings2.EnableCultureChanger)
            {
                try
                {
                    CampaignGameStarter campaignGameStarter = (CampaignGameStarter)gameStarterObject;
                    campaignGameStarter.AddBehavior(new ChangeSettlementCulture());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Initialising Culture Changer:\n\n{ex.ToStringFull()}");
                }
            }
        }

        private void AddModels(CampaignGameStarter gameStarter)
        {
            if (gameStarter != null && BannerlordTweaksSettings.Instance is { } settings)
            {
                if (settings.TroopExperienceTweakEnabled || settings.ArenaHeroExperienceMultiplierEnabled || settings.TournamentHeroExperienceMultiplierEnabled)
                    gameStarter.AddModel(new TweakedCombatXpModel());
                if (settings.MaxWorkshopCountTweakEnabled || settings.WorkshopBuyingCostTweakEnabled || settings.WorkshopEffectivnessEnabled)
                    gameStarter.AddModel(new TweakedWorkshopModel());
                if (settings.PartiesLimitTweakEnabled || settings.CompanionLimitTweakEnabled || settings.BalancingPartyLimitTweaksEnabled)
                    gameStarter.AddModel(new TweakedClanTierModel());
                if (settings.SettlementMilitiaEliteSpawnRateBonusEnabled)
                    gameStarter.AddModel(new TweakedSettlementMilitiaModel());
                if (settings.SiegeTweaksEnabled)
                    gameStarter.AddModel(new TweakedSiegeEventModel());
                if (settings.PregnancyTweaksEnabled)
                    gameStarter.AddModel(new TweakedPregnancyModel());
                if (settings.AgeTweaksEnabled)
                {
                    TweakedAgeModel model = new();
                    List<string> configErrors = model.GetConfigErrors().ToList();
                    if (configErrors.Any())
                    {
                        StringBuilder sb = new();
                        sb.AppendLine("There is a configuration error in the \'Age\' tweaks from Bannerlord Tweaks.");
                        sb.AppendLine("Please check the below errors and fix the age settings in the settings menu:");
                        sb.AppendLine();
                        foreach (var e in configErrors)
                            sb.AppendLine(e);
                        sb.AppendLine();
                        sb.AppendLine("The age tweaks will not be applied until these errors have been resolved.");
                        sb.Append("Note that this is only a warning message and not a crash.");

                        MessageBox.Show(sb.ToString(), "Configuration Error in Bannerlord Tweaks");
                    }
                    else
                        gameStarter.AddModel(new TweakedAgeModel());
                }
                if (settings.AttributeFocusPointTweakEnabled)
                    gameStarter.AddModel(new TweakedCharacterDevelopmentModel());
                if (settings.DifficultyTweakEnabled)
                    gameStarter.AddModel(new TweakedDifficultyModel());
            }
        }

        public override bool DoLoading(Game game)
        {
            if (Campaign.Current != null && BannerlordTweaksSettings.Instance is { } settings)
            {
                if (settings.PrisonerImprisonmentTweakEnabled)
                    PrisonerImprisonmentTweak.Apply(Campaign.Current);
                if (settings.DailyTroopExperienceTweakEnabled)
                    DailyTroopExperienceTweak.Apply(Campaign.Current);
                // 1.5.7.2 - Disable until we understand main quest changes.
                //if (settings.TweakedConspiracyQuestTimerEnabled)
                //    ConspiracyQuestTimerTweak.Apply(Campaign.Current);
            }
            return base.DoLoading(game);
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            if (mission == null) return;
            base.OnMissionBehaviourInitialize(mission);
        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);
            if (Campaign.Current != null && BannerlordTweaksSettings.Instance is { } settings && (settings.EnableMissingHeroFix && settings.PrisonerImprisonmentTweakEnabled))
            {

                try
                {
                    CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, delegate
                    {
                        PrisonerImprisonmentTweak.DailyTick();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Initialising Missing Hero Fix:\n\n{ex.ToStringFull()}");
                }
            }
        }

        protected override void OnApplicationTick(float dt)
        {
            if (Campaign.Current != null && BannerlordTweaksSettings.Instance is { } settings2 && settings2.CampaignSpeed != 4)
            {
                Campaign.Current.SpeedUpMultiplier = settings2.CampaignSpeed;
            }
        }
    }
}

