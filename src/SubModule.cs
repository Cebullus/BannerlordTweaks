﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

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

                    // BattleSize was converted to an array {200, 300, 400, 500, 600, 1000} in 1.5.7. Setting BattleSize to anything outside of those will crash the game.
                    // Solution is to let BannerlordConfig read a proper setting, then dynamically HarmonyPatch the BattleSize at the time of battle. Players will see 
                    // the options screen have the setting number, but battles sizes can range to whatever is in BT settings. 

                    //if (BannerlordTweaksSettings.Instance is { } settings && settings.BattleSizeTweakEnabled)
                    //    BannerlordConfig.BattleSize = settings.BattleSize;
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
        }

        private void AddModels(CampaignGameStarter gameStarter)
        {
            if (gameStarter != null && BannerlordTweaksSettings.Instance is { } settings)
            {
                if (settings.TroopBattleExperienceMultiplierEnabled || settings.ArenaHeroExperienceMultiplierEnabled || settings.TournamentHeroExperienceMultiplierEnabled)
                    gameStarter.AddModel(new TweakedCombatXpModel());
                if (settings.MaxWorkshopCountTweakEnabled || settings.WorkshopBuyingCostTweakEnabled)
                    gameStarter.AddModel(new TweakedWorkshopModel());
                if (settings.CompanionLimitTweakEnabled || settings.ClanPartiesLimitTweakEnabled)
                    gameStarter.AddModel(new TweakedClanTierModel());
                if (settings.SettlementMilitiaBonusEnabled)
                    gameStarter.AddModel(new TweakedSettlementMilitiaModel());
                if (settings.SiegeCasualtiesTweakEnabled || settings.SiegeConstructionProgressPerDayMultiplierEnabled)
                    gameStarter.AddModel(new TweakedSiegeEventModel());
                if (settings.NoStillbirthsTweakEnabled || settings.NoMaternalMortalityTweakEnabled ||
                        settings.PregnancyDurationTweakEnabled || settings.FemaleOffspringProbabilityTweakEnabled ||
                        settings.TwinsProbabilityTweakEnabled)
                    gameStarter.AddModel(new TweakedPregnancyModel());
                if (settings.AgeTweaksEnabled)
                {
                    TweakedAgeModel model = new TweakedAgeModel();
                    List<string> configErrors = model.GetConfigErrors().ToList();
                    if (configErrors.Any())
                    {
                        StringBuilder sb = new StringBuilder();
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
                if (settings.DamageToPlayerTweakEnabled || settings.DamageToFriendsTweakEnabled || settings.DamageToTroopsTweakEnabled || settings.CombatAIDifficultyTweakEnabled || settings.PlayerMapMovementSpeedBonusTweakEnabled)
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
    }
}

