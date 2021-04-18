using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;
using MCM.Abstractions.Dropdown;

namespace BannerlordTweaks
{
    public class BannerlordTweaksSettings : AttributeGlobalSettings<BannerlordTweaksSettings>
    {
        public override string Id => "BannerlordTweaksSettings";
        public override string DisplayName => "Bannerlord Tweaks Settings";
        public override string FolderName => "BannerlordTweaksSettings";
        public override string FormatType => "json2";


        #region Headline #1
        /*
           [SettingPropertyBool("All Tweaks marked with * need a restart when changed!", Order = 1, IsToggle = true, RequireRestart = false, HintText = ""), SettingPropertyGroup("All Tweaks marked with * need a restart when changed!",GroupOrder = 1)]
           public bool Dummy { get; set; } = false;
        */
        #endregion

        #region Battle Tweaks #2

        #region Battle Tweaks - Battle Reward Tweaks

        [SettingPropertyBool("Battle Renown, Influence, Morale Tweaks*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Applies the set multiplier to renown and influence gain from battles (applies to the player only)."), SettingPropertyGroup("Battle Tweaks/Battle Renown, Influence, Morale Tweaks*")]
        public bool BattleRewardTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Battle Renown Amount", 0.1f, 5f, "0%", Order = 2, RequireRestart = false, HintText = "Native value is 100%. The amount of renown you receive from a battle is multiplied by this value. Note: Battle Morale is also calculated from this value."), SettingPropertyGroup("Battle Tweaks/Battle Renown, Influence, Morale Tweaks*")]
        public float BattleRenownMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Battle Influence Amount", 0.1f, 5f, "0%", RequireRestart = false, Order = 3, HintText = "Native value is 100%. The amount of influence you receive from a battle is multiplied by this value."), SettingPropertyGroup("Battle Tweaks/Battle Renown, Influence, Morale Tweaks*")]
        public float BattleInfluenceMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Battle Morale Amount", 0.1f, 5f, "0%", RequireRestart = false, Order = 4, HintText = "Native value is 100%. The amount of morale you receive from a battle is multiplied by this value."), SettingPropertyGroup("Battle Tweaks/Battle Renown, Influence, Morale Tweaks*")]
        public float BattleMoraleMultiplier { get; set; } = 1f;

        [SettingPropertyBool("Also Apply To AI", Order = 5, RequireRestart = false, HintText = "Applies the renown and influence modifiers to AI parties."), SettingPropertyGroup("Battle Tweaks/Battle Renown, Influence, Morale Tweaks*")]
        public bool BattleRewardApplyToAI { get; set; } = false;

        [SettingPropertyBool("Show Calculation Message", Order = 6, RequireRestart = false, HintText = "Shows detailed calculation for renown and influence tweaks in message log."), SettingPropertyGroup("Battle Tweaks/Battle Renown, Influence, Morale Tweaks*")]
        public bool BattleRewardShowDebug { get; set; } = false;

        #endregion

        #region Battle Tweaks - Hideout Tweaks

        [SettingPropertyBool("Enable Hideout Battle Behavior*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes game behavior inside hideout battles."), SettingPropertyGroup("Battle Tweaks/Hideout Tweaks*")]
        public bool HideoutBattleTroopLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Hideout Battle Troop Limit", 5, 90, "0 Soldiers", Order = 2, RequireRestart = false, HintText = "Native value is 9 or 10. Changes the maximum troop limit to the set value inside hideout battles. Cannot be higher than 90 because it causes bugs."), SettingPropertyGroup("Battle Tweaks/Hideout Tweaks*")]
        public int HideoutBattleTroopLimit { get; set; } = 10;

        [SettingPropertyBool("Continue Hideout Battle On Player Death*", Order = 3, RequireRestart = true, HintText = "Native value is false. If enabled, you will not automatically lose the hideout battle if you die. Your troops will charge and the boss duel will be disabled."), SettingPropertyGroup("Battle Tweaks/Hideout Tweaks*")]
        public bool ContinueHideoutBattleOnPlayerDeath { get; set; } = false;

        [SettingPropertyBool("Continue Battle On Losing Duel*", Order = 4, RequireRestart = true, HintText = "Native value is false. If enabled, you will lose the battle if you lose the boss duel. If disabled, your troops will rush to avenge you and finish everyone off."), SettingPropertyGroup("Battle Tweaks/Hideout Tweaks*")]
        public bool ContinueHideoutBattleOnPlayerLoseDuel { get; set; } = false;

        #endregion

        #region Battle Tweaks - Siege Tweaks

        [SettingPropertyBool("Siege Tweaks*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Tweaks for siege engine construction speed and collateral casulaties during sieges."), SettingPropertyGroup("Battle Tweaks/Siege Tweaks*")]
        public bool SiegeTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Siege Construction Progress Per Day Amount", 0.1f, 10.0f, "0%", RequireRestart = false, Order = 2, HintText = "Native value is 100%. This tweak adds a modifier to the construction progress per day for sieges. A smaller number results in longer siege times."), SettingPropertyGroup("Battle Tweaks/Siege Tweaks*")]
        public float SiegeConstructionProgressPerDayMultiplier { get; set; } = 1f;

        [SettingPropertyInteger("Siege Collateral Damage Casualties", 0, 10, Order = 5, RequireRestart = false, HintText = "Native value is 0. This tweak adds to the base value (1 or 2 with Crossbow Terror Perk) used to calculate collateral casualties during the campaign map siege stage."), SettingPropertyGroup("Battle Tweaks/Siege Tweaks*")]
        public int SiegeCollateralDamageCasualties { get; set; } = 0;

        [SettingPropertyInteger("Siege Destruction Casualties", 0, 10, Order = 6, RequireRestart = false, HintText = "Native value is 0. This tweak adds to the base value (2) used to calculate destruction casualties during the campaign map siege stage."), SettingPropertyGroup("Battle Tweaks/Siege Tweaks*")]
        public int SiegeDestructionCasualties { get; set; } = 0;

        #endregion

        #region Battle Tweaks - Troop Experience Tweaks

        [SettingPropertyBool("Troop Experience*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Tweaks for experience gain of troops in battles and simulations."), SettingPropertyGroup("Battle Tweaks/Troop Experience*")]
        public bool TroopExperienceTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Troop Battle Experience", Order = 2, RequireRestart = false, IsToggle = true, HintText = "Modifies the amount of experience that ALL troops receive during battles (Note: Only troops, not heroes)."), SettingPropertyGroup("Battle Tweaks/Troop Experience*/Troop Battle Experience")]
        public bool TroopBattleExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Troop Battle Experience Amount", .01f, 6f, "0%", RequireRestart = false, Order = 3, HintText = "Native value is 100%. Modifies the amount of experience that ALL troops receive during fought battles (Note: Only troops, not heroes. Does not apply to simulated battles.)."), SettingPropertyGroup("Battle Tweaks/Troop Experience*/Troop Battle Experience")]
        public float TroopBattleExperienceMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("Troop Simulation Experience", Order = 4, RequireRestart = false, IsToggle = true, HintText = "Modifies the experience gained from simulated battles. This is applied to all fights (including NPC fights) on the campaign map."), SettingPropertyGroup("Battle Tweaks/Troop Experience*/Troop Simulation Experience")]
        public bool TroopBattleSimulationExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Troop Simulation Experience Amount", .01f, 8f, "0%", RequireRestart = false, Order = 5, HintText = "Native value is 90%. Provides a multiplier to experience gained from simulated battles. This is applied to all simulated fights on the campaign map."), SettingPropertyGroup("Battle Tweaks/Troop Experience*/Troop Simulation Experience")]
        public float TroopBattleSimulationExperienceMultiplier { get; set; } = 0.9f;

        #endregion

        #region Battle Tweaks - Weapon Cut Through Tweaks

        [SettingPropertyBool("Weapon Cut Through Tweaks*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "Allows all two-handed weapon types to cut through and hit multiple people."), SettingPropertyGroup("Battle Tweaks/Weapon Cut Through Tweaks*")]
        public bool SliceThroughEnabled { get; set; } = false;

        [SettingPropertyBool("All Two-Handed Weapons Cut Through", Order = 2, RequireRestart = false, HintText = "Allows all two-handed weapon types to cut through and hit multiple people."), SettingPropertyGroup("Battle Tweaks/Weapon Cut Through Tweaks*")]
        public bool TwoHandedWeaponsSliceThroughEnabled { get; set; } = false;

        [SettingPropertyBool("All One-Handed Weapons Cut Through", Order = 3, RequireRestart = false, HintText = "Allows all single-handed weapon types to cut through and hit multiple people."), SettingPropertyGroup("Battle Tweaks/Weapon Cut Through Tweaks*")]
        public bool SingleHandedWeaponsSliceThroughEnabled { get; set; } = false;

        #endregion

        #endregion

        #region Campaign Tweaks #2

        #region Campaign Tweaks - Battle Size Tweak

        [SettingPropertyBool("Battle Size Tweak*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "Allows you to set the battle size limit outside of native values. WARNING: Setting this above 1000 can cause performance degradation and crashes."), SettingPropertyGroup("Campaign Tweaks/Battle Size Tweak*")]
        public bool BattleSizeTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Battle Size Limit", 2, 1800, "0 Soldiers", Order = 2, RequireRestart = false, HintText = "Sets the limit for number of troops on a battlefield, ignoring what is in Bannerlord Options. WARNING: Will crash if all troops + their horses exceed 2000."), SettingPropertyGroup("Campaign Tweaks/Battle Size Tweak*")]
        public int BattleSize { get; set; } = 1000;

        #endregion

        #region Campaign Tweaks - Difficulty Settings

        [SettingPropertyBool("Difficulty Tweaks*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Allows you to change the multiplier for damage the player receives."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*")]
        public bool DifficultyTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Damage to Player Tweak", Order = 2, RequireRestart = false, IsToggle = true, HintText = "Allows you to change the multiplier for damage the player receives."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Damage to Player Tweak")]
        public bool DamageToPlayerTweakEnabled { get; set; } = false;
 
        [SettingPropertyFloatingInteger("Damage to Player Tweak Amount", 0.1f, 5.0f,"0%", RequireRestart = false, Order = 3, HintText = "Native values: Very Easy: 30%, Easy: 67%, Realistic: 100%. This value is used to calculate the damage player receives."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Damage to Player Tweak")]
        public float DamageToPlayerMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("Damage to Friends Tweak", Order = 4, RequireRestart = false, IsToggle = true, HintText = "Allows you to change the damage the player's friends receive."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Damage to Friends Tweak")]
        public bool DamageToFriendsTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Damage to Friends Tweak Amount", 0.1f, 5.0f, "0%", RequireRestart = false, Order = 5, HintText = "Native values: Very Easy: 30%, Easy: 67%, Realistic: 100%. This value is used to calculate the damage the player's friends receive."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Damage to Friends Tweak")]
        public float DamageToFriendsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("Damage to Player's Troops Tweak", Order = 6, RequireRestart = false, IsToggle = true, HintText = "Allows you to change the multiplier for damage the player's troops receive."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Damage to Player's Troops Tweak")]
        public bool DamageToTroopsTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Damage to Troops Tweak Amount", 0.1f, 5.0f, "0%", RequireRestart = false, Order = 7, HintText = "Native values: Very Easy: 30%, Easy: 67%, Realistic: 100%. This value is used to calculate the damage to the player's troops."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Damage to Player's Troops Tweak")]
        public float DamageToTroopsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("Combat AI Difficulty Tweak", Order = 8, RequireRestart = false, IsToggle = true, HintText = "Allows you to change the AI combat difficulty."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Combat AI Difficulty Tweak")]
        public bool CombatAIDifficultyTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Combat AI Difficulty Tweak Amount", 0.1f, 1.0f, "0%", RequireRestart = false, Order = 9, HintText = "Native values: Very Easy: 10%, Easy: 32%, Realistic: 96%. This value is used to calculate AI combat difficulty."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Combat AI Difficulty Tweak")]
        public float CombatAIDifficultyMultiplier { get; set; } = 0.96f;

        [SettingPropertyBool("Player Map Movement Speed Tweak", Order = 10, RequireRestart = false, IsToggle = true, HintText = "Allows you to change the bonus map movement speed multiplier the player receives."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Player Map Movement Speed Tweak")]
        public bool PlayerMapMovementSpeedBonusTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Player Map Movement Tweak Amount", 0.0f, 2.0f, "0%", RequireRestart = false, Order = 11, HintText = "Native values: Very Easy: 10%, Easy: 5%, Realistic: 0%. This value is used to calculate player's map movement speed."), SettingPropertyGroup("Campaign Tweaks/Difficulty Tweaks*/Player Map Movement Speed Tweak")]
        public float PlayerMapMovementSpeedBonusMultiplier { get; set; } = 0.0f;

        #endregion

        #endregion

        #region Character Tweaks #4

        #region Character Tweaks - Age Tweaks

        [SettingPropertyBool("Enable Age Tweaks*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Enables the tweaking of character age behavior."), SettingPropertyGroup("Character Tweaks/Age Tweaks*")]
        public bool AgeTweaksEnabled { get; set; } = false;

        [SettingPropertyInteger("Become Infant Age", 0, 125, "0 Years", RequireRestart = false, Order = 2, HintText = "Native: 3. Must be less than Become Child Age."), SettingPropertyGroup("Character Tweaks/Age Tweaks*")]
        public int BecomeInfantAge { get; set; } = 3;

        [SettingPropertyInteger("Become Child Age", 0, 125, "0 Years", RequireRestart = false, Order = 3, HintText = "Native: 6. Must be less than Become Teenager Age."), SettingPropertyGroup("Character Tweaks/Age Tweaks*")]
        public int BecomeChildAge { get; set; } = 6;

        [SettingPropertyInteger("Become Teenager Age", 0, 125, "0 Years", RequireRestart = false, Order = 4, HintText = "Native: 14. Must be less than Hero Comes Of Age."), SettingPropertyGroup("Character Tweaks/Age Tweaks*")]
        public int BecomeTeenagerAge { get; set; } = 14;

        [SettingPropertyInteger("Hero Comes Of Age", 0, 125, "0 Years", RequireRestart = false, Order = 5, HintText = "Native: 18. Must be less than Become Old Age."), SettingPropertyGroup("Character Tweaks/Age Tweaks*")]
        public int HeroComesOfAge { get; set; } = 18;

        [SettingPropertyInteger("Become Old Age", 0, 125, "0 Years", RequireRestart = false, Order = 6, HintText = "Native: 47. Must be less than Max Age."), SettingPropertyGroup("Character Tweaks/Age Tweaks*")]
        public int BecomeOldAge { get; set; } = 47;

        [SettingPropertyInteger("Max Age", 0, 125, "0 Years", RequireRestart = false, Order = 7, HintText = "Native: 125."), SettingPropertyGroup("Character Tweaks/Age Tweaks*")]
        public int MaxAge { get; set; } = 125;

        #endregion

        #region Character Tweaks - Attribute Focus Point Tweaks

        [SettingPropertyBool("Attribute-Focus Point Tweaks*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the values used to calculate how many Attribute and Focus points Heroes gain."), SettingPropertyGroup("Character Tweaks/Attribute-Focus Points Tweaks*")]
        public bool AttributeFocusPointTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Levels per Attribute Point", 1, 5, "0 Level", Order = 2, RequireRestart = false, HintText = "Native value is 4. How many levels you need to gain to receive an attribute point."), SettingPropertyGroup("Character Tweaks/Attribute-Focus Points Tweaks*")]
        public int AttributePointRequiredLevel { get; set; } = 4;

        [SettingPropertyInteger("Focus Point Per Level", 1, 5, "0 Points", Order = 3, RequireRestart = false, HintText = "Native value is 1. This is the amount of focus points earned per level."), SettingPropertyGroup("Character Tweaks/Attribute-Focus Points Tweaks*")]
        public int FocusPointsPerLevel { get; set; } = 1;

        #endregion

        #region Character Tweaks - Hero Skill Multiplier Tweaks

        [SettingPropertyBool("Hero Skill Experience*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "Enable bonuses to the skill experience your hero & companions members gain."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*")]
        public bool SkillExperienceMultipliersEnabled { get; set; } = false;

        [SettingPropertyBool("Player Skill Experience", Order = 2, RequireRestart = false, IsToggle = true, HintText = "Applies a modifier to the amount of experience recieved for skills. Affects the player only. 100% = No Bonus."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Player Skill Experience",GroupOrder =1)]
        public bool HeroSkillExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Player Skill Experience Amount", 1f, 5f,"0%", RequireRestart = false, HintText = "Applies a modifier to the amount of experience recieved for skills. Affects the player only. 100% = No Bonus."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Player Skill Experience")]
        public float HeroSkillExperienceMultiplier { get; set; } = 1f;

        [SettingPropertyBool("Companion Skill Experience", Order = 3, RequireRestart = false, IsToggle=true, HintText = "Applies a modifier to the amount of experience recieved for skills. Affects Compaions only. 100% = No Bonus."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Companion Skill Experience",GroupOrder = 2)]
        public bool CompanionSkillExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Companion Skill Experience Amount", 1f, 20f, "0%", RequireRestart = false, HintText = "Applies a modifier to the amount of experience recieved for skills. Affects the Companion only. 100% = No Bonus."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Companion Skill Experience")]
        public float CompanionSkillExperienceMultiplier { get; set; } = 1f;


        #region Character Tweaks - Hero Skill Multiplier Tweaks - Enable Per-Skill Bonuses

        [SettingPropertyBool("Per Skill Bonuses", Order = 4, RequireRestart = false, IsToggle = true, HintText = "Modifies the amount of experience recieved for specific skills before applying global experience modifier. Affects the player and companions only. 1.0 = No Bonus. 1.1 = 10%, etc."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses" ,GroupOrder = 3)]
        public bool PerSkillBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Per-Skill Experience Amount: Engineering", 1f, 10f, "0%", RequireRestart = false, HintText = "Modifies the amount of Engineering experience recieved."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses")]
        public float SkillBonusEngineering { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Per-Skill Experience Amount: Leadership", 1f, 10f, "0%", RequireRestart = false, HintText = "Modifies the amount of Leadership experience recieved."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses")]
        public float SkillBonusLeadership { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Per-Skill Experience Amount: Medicine", 1f, 10f, "0%", RequireRestart = false, HintText = "Modifies the amount of Medicine experience recieved."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses")]
        public float SkillBonusMedicine { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Per-Skill Experience Amount: Riding", 1f, 10f, "0%", RequireRestart = false, HintText = "Modifies the amount of Riding experience recieved."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses")]
        public float SkillBonusRiding { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Per-Skill Experience Amount: Roguery", 1f, 10f, "0%", RequireRestart = false, HintText = "Modifies the amount of Roguery experience recieved."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses")]
        public float SkillBonusRoguery { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Per-Skill Experience Amount: Scouting", 1f, 10f, "0%", RequireRestart = false, HintText = "Modifies the amount of Scouting experience recieved."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses")]
        public float SkillBonusScouting { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Per-Skill Experience Amount: Trade", 1f, 10f, "0%", RequireRestart = false, HintText = "Modifies the amount of Trade experience recieved."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses")]
        public float SkillBonusTrade { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Per-Skill Experience Amount: Smithing", 1f, 10f, "0%", RequireRestart = false, HintText = "Modifies the amount of Smithing experience recieved."), SettingPropertyGroup("Character Tweaks/Hero Skill Experience*/Per-Skill Bonuses")]
        public float SkillBonusSmithing { get; set; } = 1f;

        #endregion

        #endregion

        #region Character Tweaks - Pregnancy Tweaks

        [SettingPropertyBool("Pregnancy Tweaks*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "Enable bonuses to the skill experience your hero & companions members gain."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*")]
        public bool PregnancyTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("Disable Stillbirths", Order = 2, RequireRestart = false, HintText = "Disables the chance of children dying when born."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*")]
        public bool NoStillbirthsTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Disable Maternal Mortality", Order = 3, RequireRestart = false, HintText = "Disables the chance of mothers dying when giving birth."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*")]
        public bool NoMaternalMortalityTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Pregnancy Duration Tweak", Order = 4, RequireRestart = false, IsToggle = true, HintText = "Allows for adjusting the duration for a pregnancy."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Pregnancy Duration Tweak")]
        public bool PregnancyDurationTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Pregnancy Duration", 1, 96, "0 Days", RequireRestart = false, HintText = "Native value is 36 days."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Pregnancy Duration Tweak")]
        public int PregnancyDuration { get; set; } = 36;

        [SettingPropertyBool("Gender Ratio Tweak", Order = 5, RequireRestart = false, IsToggle = true, HintText = "Allows for adjusting the gender ratio of births."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Gender Ratio Tweak")]
        public bool FemaleOffspringProbabilityTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Probability for female children", 0.0f, 1.0f, "0%", RequireRestart = false, HintText = "Native value is 51%. Set to 0% to disable female births."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Gender Ratio Tweak")]
        public float FemaleOffspringProbability { get; set; } = 0.51f;

        [SettingPropertyBool("Twins Probability Tweak", Order = 6, RequireRestart = false, IsToggle = true, HintText = "Allows for adjusting the chance of giving birth to twins."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Twins Probability Tweak")]
        public bool TwinsProbabilityTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Probability to deliver twins", 0.0f, 1.0f, "0%", RequireRestart = false, HintText = "Native value is 3%. Determines the chance of giving birth to twins."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Twins Probability Tweak")]
        public float TwinsProbability { get; set; } = 0.03f;

        [SettingPropertyBool("Pregnancy Chance Tweaks", Order = 7, RequireRestart = false, IsToggle = true, HintText = "Enabling this will completely override the daily pregnancy check. All settings below will be applied!"), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Pregnancy Chance Tweaks")]
        public bool DailyChancePregnancyTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Player is Infertile", Order = 1, RequireRestart = false, HintText = "Native: disabled. If enabled, the player will not be able to have children."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Pregnancy Chance Tweaks")]
        public bool PlayerCharacterInfertileEnabled { get; set; } = false;

        [SettingPropertyInteger("Min Pregnancy Age", 0, 125, "0 Years", Order = 2, RequireRestart = false, HintText = "Native: 18. Minimum age that someone can get pregnant."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Pregnancy Chance Tweaks")]
        public int MinPregnancyAge { get; set; } = 18;

        [SettingPropertyInteger("Max Pregnancy Age", 0, 125, "0 Years",  Order = 3,  RequireRestart = false, HintText = "Native: 45. Maximum age that someone can get pregnant."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Pregnancy Chance Tweaks")]
        public int MaxPregnancyAge { get; set; } = 45;

        [SettingPropertyFloatingInteger("Clan Fertility Bonus", 1f, 10f, "0%", Order = 4, RequireRestart = false, HintText = "Adds modifier to your clan members to become pregnant. 100% = No Bonus, 200% = 2x chance. Note: May not do much after ~6-8 kids due to the base pregnancy calculations."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Pregnancy Chance Tweaks")]
        public float ClanFertilityBonus { get; set; } = 1f;

        [SettingPropertyInteger("Max Children", 0, 100, "0 children", Order = 5, RequireRestart = false, HintText = "Default: 5. Maximum number of children that someone can have."), SettingPropertyGroup("Character Tweaks/Pregnancy Tweaks*/Pregnancy Chance Tweaks")]
        public int MaxChildren { get; set; } = 5;

        #endregion

        #endregion

        #region Clan Tweaks #5

        #region Clan Tweaks - Companion Limit Tweak

        [SettingPropertyBool("Companion Limit Tweak*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Sets the base companion limit and the bonus gained per clan tier."), SettingPropertyGroup("Clan Tweaks/Companion Limit*")]
        public bool CompanionLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Base Companion Limit", 1, 20, "0 Companions", Order = 2, RequireRestart = false, HintText = "Native value is 3. Sets the base companion limit."), SettingPropertyGroup("Clan Tweaks/Companion Limit*")]
        public int CompanionBaseLimit { get; set; } = 3;

        [SettingPropertyInteger("Companion Bonus Per Clan Tier", 0, 10, Order = 3, RequireRestart = false, HintText = "Native value is 1. Sets the bonus to companion limit per clan tier. This value is multiplied by your clan tier. Note that Leadership 'We Pledge Our Swords' perk will also increse this number by 1."), SettingPropertyGroup("Clan Tweaks/Companion Limit*")]
        public int CompanionLimitBonusPerClanTier { get; set; } = 1;

        [SettingPropertyBool("Enable Unlimited Wanderers Patch*", Order = 4, RequireRestart = false, HintText = "Removes the soft cap on the maximum number of potential companions who can spawn. Native limits the # of wanderers to ~25. This will remove that limit. Note: Requires a new campaign to take effect, as the cap is set when a new game is generated. Credit to Bleinz for his UnlimitedWanderers mod."), SettingPropertyGroup("Clan Tweaks/Companion Limit*")]
        public bool UnlimitedWanderersPatch { get; set; } = false;

        #endregion

        #region Clan Tweaks - Party Limits - Player Parties Limit

        [SettingPropertyBool("Party Limits*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the number of parties you and ai lords can field and the bonus gained per clan tier."), SettingPropertyGroup("Clan Tweaks/Party Limits*")]
        public bool PartiesLimitTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Player Parties Limit", Order = 1, RequireRestart = false, IsToggle = true, HintText = "Changes the base number of parties you can field and the bonus gained per clan tier."), SettingPropertyGroup("Clan Tweaks/Party Limits*/Player Parties Limit", GroupOrder = 1)]
        public bool ClanPartiesLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Base Clan Parties Limit", 1, 10, "0 Parties", RequireRestart = false, Order = 2, HintText = "Native value is 1. This is the number of parties you can field at the start."), SettingPropertyGroup("Clan Tweaks/Party Limits*/Player Parties Limit")]
        public int BaseClanPartiesLimit { get; set; } = 1;

        [SettingPropertyFloatingInteger("Clan Parties Bonus Per Clan Tier", 0.0f, 6f, "0.0 Parties/Clan Tier", RequireRestart = false, Order = 3, HintText = "Native has a calculation for this: 1 party for under tier 3, 2 parties for under tier 5, 3 parties for over tier 5. This setting is multiplied by your clan tier. A value of 0.5 will equate to 1 extra party per 2 clan tiers, which eqautes to the same as native."), SettingPropertyGroup("Clan Tweaks/Party Limits*/Player Parties Limit")]
        public float ClanPartiesBonusPerClanTier { get; set; } = 0.5f;

        #endregion

        #region Clan Tweaks - AI Lord Parties Limmit

        [SettingPropertyBool("AI Lord Parties Limit", Order = 1, RequireRestart = false, IsToggle = true, HintText = "Changes the base number of parties AI Lords can field. Warning! Once new parties are spawned, it takes a long time until they get removed if you changew your mind!"), SettingPropertyGroup("Clan Tweaks/Party Limits*/AI Lord Parties Limit", GroupOrder = 2)]
        public bool AIClanPartiesLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Add to AI Lord Parties Limit", 1, 10, "0 Extra Parties", Order = 2, RequireRestart = false, HintText = "This adds to the the base number of parties AI Lords can field. [Native is 1 for Tier 3 and below, 2 at T4, 3 at T5 and up.] Minor Factions are not included unless the option below is also enabled."), SettingPropertyGroup("Clan Tweaks/Party Limits*/AI Lord Parties Limit")]
        public int BaseAIClanPartiesLimit { get; set; } = 0;

        [SettingPropertyBool("Also Adjust Minor Factions", Order = 3, RequireRestart = false, HintText = "Changes the base number of parties AI Minor Factiopn Lords can field. [Native is 1-4, depending on Clan tier.]"), SettingPropertyGroup("Clan Tweaks/Party Limits*/AI Lord Parties Limit")]
        public bool AIMinorClanPartiesLimitTweakEnabled { get; set; } = false;

        #endregion

        #region Clan Tweaks - Custom Spawns Parties Tweak

        [SettingPropertyBool("Custom Spawn Parties Limit", Order = 1, RequireRestart = false, IsToggle = true, HintText = "Changes the base number of parties Custom Spawn lords can field. Warning! Once new parties are spawned, it takes a long time until they get removed if you changew your mind!"), SettingPropertyGroup("Clan Tweaks/Party Limits*/Custom Spawns Parties Limit", GroupOrder = 3)]
        public bool AICustomSpawnPartiesLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Add to Custom Spawn Parties Limit", 1, 10, "0 Extra Parties", Order = 2, RequireRestart = false, HintText = "This adds to the the base number of parties Custom Lords can field. [Native is 1 for Tier 3 and below, 2 at T4, 3 at T5 and up.]."), SettingPropertyGroup("Clan Tweaks/Party Limits*/Custom Spawns Parties Limit")]
        public int BaseAICustomSpawnPartiesLimit { get; set; } = 0;

        #endregion

        #endregion

        #region Crafting Tweaks #6

        #region Crafting Tweaks - Crafting Stamina Tweaks
        [SettingPropertyBool("Crafting Stamina*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Enables tweaks which affect crafting stamina."), SettingPropertyGroup("Crafting Tweaks/Crafting Stamina*")]
        public bool CraftingStaminaTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Max Crafting Stamina", 100, 1000, "0 Stamina", Order = 2, RequireRestart = false, HintText = "Native value is 400. Sets the maximum crafting stamina value."), SettingPropertyGroup("Crafting Tweaks/Crafting Stamina*")]
        public int MaxCraftingStamina { get; set; } = 400;

        [SettingPropertyInteger("Crafting Stamina Gain", 0, 100, "0 Stamina/h", Order = 3, RequireRestart = false, HintText = "Native value is 5. You gain this amount of crafting stamina per hour."), SettingPropertyGroup("Crafting Tweaks/Crafting Stamina*")]
        public int CraftingStaminaGainAmount { get; set; } = 5;

        [SettingPropertyFloatingInteger("Crafting Stamina Gain Outside Settlement", 0f, 1f, "0%", Order = 4, RequireRestart = false, HintText = "Native value is 0%. In % of Crafting Stamina Gain. In native, you do not gain crafting stamina if you are not resting inside a settlement."), SettingPropertyGroup("Crafting Tweaks/Crafting Stamina*")]
        public float CraftingStaminaGainOutsideSettlementMultiplier { get; set; } = 0f;

        [SettingPropertyBool("Ignore Crafting Stamina", Order = 5, RequireRestart = false, HintText = "Native value is false. This disables crafting stamina completely. You will still lose crafting stamina when you craft, but you will still be able to craft when you hit zero."), SettingPropertyGroup("Crafting Tweaks/Crafting Stamina*")]
        public bool IgnoreCraftingStamina { get; set; } = false;


        #endregion

        #region Crafting Tweaks - Smelting

        [SettingPropertyBool("Smelting*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Native value is false. Prevent weapons that you have locked in your inventory from showing up in the smelting list to prevent accidental smelting."), SettingPropertyGroup("Crafting Tweaks/Smelting*")]
        public bool SmeltingTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Hide Locked Weapons in Smelting Menu", Order = 1, RequireRestart = false, HintText = "Native value is false. Prevent weapons that you have locked in your inventory from showing up in the smelting list to prevent accidental smelting."), SettingPropertyGroup("Crafting Tweaks/Smelting*")]
        public bool PreventSmeltingLockedItems { get; set; } = false;

        [SettingPropertyBool("Enable Unlocking Parts From Smelted Weapons", Order = 2, RequireRestart = false, HintText = "Native value is false. Unlock the parts that a weapon is made of when you smelt it."), SettingPropertyGroup("Crafting Tweaks/Smelting*")]
        public bool AutoLearnSmeltedParts { get; set; } = false;

        #endregion

        #endregion

        #region Kingdom Tweaks #7

        #region Kingdom Tweaks - Lord Bartering

        [SettingPropertyBool("Lord Bartering*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Enables tweaks which affect bartering (Marriage, Factions Joining You, etc.)"), SettingPropertyGroup("Kingdom Tweaks/Lord Bartering*")]
        public bool BarterablesTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Faction Joining Barter Adjustment", 0.01f, 2f, "0%", Order = 2, RequireRestart = false, HintText = "Adjust the % cost of swaying a faction to join your kingdom. Native value is 100% (no change)."), SettingPropertyGroup("Kingdom Tweaks/Lord Bartering*")]
        public float BarterablesJoinKingdomAsClanAdjustment { get; set; } = 1;

        [SettingPropertyBool("Relationship favored Faction Joining Barter", Order = 3, RequireRestart = false, HintText = "An alternate formula for calculating cost of swaying a faction to join your kingdom, with more emphasis on relationsip. [The higher your relationship to the lord, the cheaper the barter]."), SettingPropertyGroup("Kingdom Tweaks/Lord Bartering*")]
        public bool BarterablesJoinKingdomAsClanAltFormulaEnabled { get; set; } = false;

        #endregion

        #region Kingdom Tweaks - Balancing Tweaks

        [SettingPropertyBool("Faction Balancing*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Enables tweaks which affect the balancing of kingdoms."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public bool KingdomBalanceStrengthEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Vlandia Balancing Strength", -0.35f, 0.35f, "0%", Order = 9, RequireRestart = false, HintText = "Balancing strength for vlandia. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float VlandiaBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("Sturgia Balancing Strength", -0.35f, 0.35f, "0%", Order = 8, RequireRestart = false, HintText = "Balancing strength for sturgia. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float SturgiaBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("Battania Balancing Strength", -0.35f, 0.35f, "0%", Order = 2, RequireRestart = false, HintText = "Balancing strength for battania. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float BattaniaBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("Northern Empire Balancing Strength", -0.35f, 0.35f, "0%", Order = 5, RequireRestart = false, HintText = "Balancing strength for northern empire. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float Empire_N_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("Southern Empire Balancing Strength", -0.35f, 0.35f, "0%", Order = 6, RequireRestart = false, HintText = "Balancing strength for southern empire. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float Empire_S_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("Western Empire Balancing Strength", -0.35f, 0.35f, "0%", Order = 7, RequireRestart = false, HintText = "Balancing strength for western empire. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float Empire_W_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("Aserai Balancing Strength", -0.35f, 0.35f, "0%", Order = 1, RequireRestart = false, HintText = "Balancing strength for aserai. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float Aseraiboost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("Khuzait Balancing Strength", -0.35f, 0.35f, "0%", Order = 4, RequireRestart = false, HintText = "Balancing strength for khuzait. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float KhuzaitBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("Player Kingdom Balancing Strength", -0.35f, 0.35f, "0%", Order = 4, RequireRestart = false, HintText = "Balancing strength for player kingdom. Boosts or reduces the enabled tweaks further down. +/- 35% is pretty extreme."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public float PlayerBoost { get; set; } = 0.00f;

        [SettingPropertyBool("Party sizes", Order = 10, RequireRestart = false, HintText = "Modifier for max party sizes in relation to Balancing Strength. A balancing strength of +20% results in +20% party sizes for the specific kingdom."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public bool BalancingPartySizeTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("Village Food Production", Order = 11, RequireRestart = false, HintText = "Modifier for daily production of food goods in villages in relation to Balancing Strength. A balancing strength of +20% results in +20% food production for the specific kingdom."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public bool BalancingFoodTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Recruit replenish time", Order = 12, RequireRestart = false, HintText = "Flat % bonus chance of new recruits to spawn in settlements in relation to Balancing Strength (x 0.75). A balancing strength of +20% results in +15% daily spawn chance for the specific kingdom (20% * 0.75 = 15%)."), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public bool BalancingTimeRecruitsTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("Taxation Efficiency", Order = 13, RequireRestart = false, HintText = "Modifier for tax income from prosperity in towns and castles and trade tax income in villages in relation to Balancing Strength"), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public bool BalancingTaxTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("Wage costs", Order = 14, RequireRestart = false, HintText = "Modifier for troop and garrison wages in relation to Balancing Strength"), SettingPropertyGroup("Kingdom Tweaks/Faction Balancing*")]
        public bool BalancingWagesTweaksEnabled { get; set; } = false;

        #endregion

        #endregion

        #region Party Tweaks #8

        #region Party Tweaks - Cohesion Tweaks

        [SettingPropertyBool("Cohesion Tweaks*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Armies composed of only clan parties lose no cohesion."), SettingPropertyGroup("Party Tweaks/Cohesion Tweaks*")]
        public bool BTCohesionTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Cohesion Degradation Factor", 0f, 1f, "0%", Order = 2, RequireRestart = false, HintText = "Modifier to how much cohesion should degrade over time. Vanilla is 100%, 0% is disabled."), SettingPropertyGroup("Party Tweaks/Cohesion Tweaks*")]
        public float BTCohesionTweakv2 { get; set; } = 1f;

        [SettingPropertyBool("All-Clan Armies Lose No Cohesion", Order = 3, RequireRestart = false, HintText = "Armies composed of only clan parties lose no cohesion."), SettingPropertyGroup("Party Tweaks/Cohesion Tweaks*")]
        public bool ClanArmyLosesNoCohesionEnabled { get; set; } = false;

        #endregion

        #region Party Tweaks - Caravan Tweaks

        [SettingPropertyBool("Player Caravan Party Size*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Applies a configured value to your caravan party size"), SettingPropertyGroup("Party Tweaks/Caravan Party Size*")]
        public bool PlayerCaravanPartySizeTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Player Caravan Party Size Amount", 30, 100, "0 Troops", Order = 2, HintText = "Native: 30. Be aware that bigger parties are also slower parties."), SettingPropertyGroup("Party Tweaks/Caravan Party Size*")]
        public int PlayerCaravanPartySize { get; set; } = 30;

        #endregion

        #region Party Tweaks - Party Size Tweaks

        [SettingPropertyBool("Party Size*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Applies a bonues to you and AI lord's party size based on leadership and steward skills."), SettingPropertyGroup("Party Tweaks/Party Size*")]
        public bool PartySizeTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Leadership Bonus", Order = 2, IsToggle = true, RequireRestart = false, HintText = "Applies a bonus equal to the set percentage of your leadership skill to your party size."), SettingPropertyGroup("Party Tweaks/Party Size*/Leadership Bonus")]
        public bool LeadershipPartySizeBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Leadership Bonus Player", 0f, 2f, "0%", Order = 3, RequireRestart = false, HintText = "Applies a bonus equal to the set percentage of your leadership skill to your party size."), SettingPropertyGroup("Party Tweaks/Party Size*/Leadership Bonus")]
        public float LeadershipPartySizeBonus { get; set; } = 0.0f;

        [SettingPropertyBool("Steward Bonus", Order = 4, IsToggle = true, RequireRestart = false, HintText = "Applies a bonus equal to the set percentage of your steward skill to your party size."), SettingPropertyGroup("Party Tweaks/Party Size*/Steward Bonus")]
        public bool StewardPartySizeBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Steward Bonus Player", 0f, 2f, "0%", Order = 5, RequireRestart = false, HintText = "Applies a bonus equal to the set percentage of your steward skill to your party size."), SettingPropertyGroup("Party Tweaks/Party Size*/Steward Bonus")]
        public float StewardPartySizeBonus { get; set; } = 0.3f;

        [SettingPropertyFloatingInteger("Party Size Relation Player-AI", 0f, 2f, "0%", Order = 6, RequireRestart = false, HintText = "The percentage of the party size bonus set for the player to also apply for ai lords. 0% results in no bonus for ai. You may also want to increase food production amounts (Village Production, bigger demand)."), SettingPropertyGroup("Party Tweaks/Party Size*")]
        public float PartySizeTweakAIFactor { get; set; } = 0f;

        #endregion

        #region Party Tweaks - Party Wage Tweaks

        [SettingPropertyBool("Wages*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Allows you to reduce/increase wages for various groups."), SettingPropertyGroup("Party Tweaks/Wages*")]
        public bool PartyWageTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Party Wage Adjustment", .05f, 5f, "0%",  Order = 2, RequireRestart = false, HintText = "Adjusts party wages to a % of native value. Native is 100%."), SettingPropertyGroup("Party Tweaks/Wages*")]
        public float PartyWagePercent { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("Garrison Wage Adjustment", .05f, 5f, "0%",  Order = 3, RequireRestart = false, HintText = "Adjusts garrison wages to a % of native value. Native is 100%."), SettingPropertyGroup("Party Tweaks/Wages*")]
        public float GarrisonWagePercent { get; set; } = 1.0f;

        [SettingPropertyBool("Also Apply Wage Tweaks to Your Faction", Order = 4, RequireRestart = false, HintText = "Applies the wage modifiers to your clan/faction parties as well"), SettingPropertyGroup("Party Tweaks/Wages*")]
        public bool ApplyWageTweakToFaction { get; set; } = false;

        [SettingPropertyBool("Also Apply Wage Tweaks to AI Lords", Order = 5, RequireRestart = false, HintText = "Applies the wage modifiers to ai lord parties as well"), SettingPropertyGroup("Party Tweaks/Wages*")]
        public bool ApplyWageTweakToAI { get; set; } = false;

        #endregion

        #region Party Tweaks - Troop Daily Experience Tweak

        [SettingPropertyBool("Daily Troop Experience*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Gives each troop roster (stack) in a party an amount of experience each day based upon the leader's Leadership skill. By default only applies to the player."), SettingPropertyGroup("Party Tweaks/Daily Troop Experience*")]
        public bool DailyTroopExperienceTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Percentage of Leadership", 0.01f, 50f, "0%",  Order = 2, RequireRestart = false, HintText = "The percentage of the leader's Leadership skill to be given as experience to each of their troop rosters. With 100 leadership and a setting of 1000% each troop type stack will get 1.000 xp daily."), SettingPropertyGroup("Party Tweaks/Daily Troop Experience*")]
        public float LeadershipPercentageForDailyExperienceGain { get; set; } = 0f;

        [SettingPropertyInteger("Starting from Leadership Level", 1, 200, Order = 3, RequireRestart = false, HintText = "The Leadership level required to start giving experience to troop rosters. With this setting at 20, daily training of your troop stacks will start from leadership 20 onwards (but be calculated with the full 20 skillpoints)."), SettingPropertyGroup("Party Tweaks/Daily Troop Experience*")]
        public int DailyTroopExperienceRequiredLeadershipLevel { get; set; } = 30;

        [SettingPropertyBool("Apply to Player's Clan Members", Order = 4, RequireRestart = false, HintText = "Applies the daily troop experience gain to members of the player's clan also."), SettingPropertyGroup("Party Tweaks/Daily Troop Experience*")]
        public bool DailyTroopExperienceApplyToPlayerClanMembers { get; set; } = false;

        [SettingPropertyBool("Apply to all NPC Lords", Order = 5, RequireRestart = false, HintText = "Applies the daily troop experience gain to all NPC lords."), SettingPropertyGroup("Party Tweaks/Daily Troop Experience*")]
        public bool DailyTroopExperienceApplyToAllNPC { get; set; } = false;

        [SettingPropertyBool("Display Message", Order = 6, RequireRestart = false, HintText = "Displays a message showing the amount of experience granted."), SettingPropertyGroup("Party Tweaks/Daily Troop Experience*")]
        public bool DisplayMessageDailyExperienceGain { get; set; } = false;

        #endregion

        #endregion

        #region Prisoner Tweaks #9

        #region Imprisonmewnt Time Tweaks

        [SettingPropertyBool("Imprisonment Time*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Adds a minimum amount of time before lords can attempt to escape imprisonment."), SettingPropertyGroup("Prisoner Tweaks/Imprisonment Time*")]
        public bool PrisonerImprisonmentTweakEnabled { get; set; } = false;

        [SettingPropertyBool("Player Prisoners Only", Order = 2, RequireRestart = false, HintText = "Whether the tweak should be applied only to prisoners held by the player."), SettingPropertyGroup("Prisoner Tweaks/Imprisonment Time*")]
        public bool PrisonerImprisonmentPlayerOnly { get; set; } = true;

        [SettingPropertyInteger("Minimum Days of Imprisonment", 0, 180, "0 Days",  Order = 3, RequireRestart = false, HintText = "The minimum number of days a lord will remain imprisoned before they can attempt to escape."), SettingPropertyGroup("Prisoner Tweaks/Imprisonment Time*")]
        public int MinimumDaysOfImprisonment { get; set; } = 10;

        [SettingPropertyBool("Enable Missing Prisoner Hero Fix*", Order = 4, RequireRestart = true, HintText = "Will attempt to detect and release prisoner Heroes who may be bugged and do not respawn. Will trigger 3 days after the Minimum Days of Imprisonment setting."), SettingPropertyGroup("Prisoner Tweaks/Imprisonment Time*")]
        public bool EnableMissingHeroFix { get; set; } = false;

        #endregion

        #region Prisoner Size Tweak

        [SettingPropertyBool("Prisoner Size Bonus*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Enables a % bonus to your party's maximum prisoner size."), SettingPropertyGroup("Prisoner Tweaks/Prisoner Size Bonus*")]
        public bool PrisonerSizeTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Prisoner Size Bonus", 0f, 5f, "0%", Order = 2, RequireRestart = false, HintText = "Adds a % bonues to your party's maximum prisoner size. Native is 0%"), SettingPropertyGroup("Prisoner Tweaks/Prisoner Size Bonus*")]
        public float PrisonerSizeTweakPercent { get; set; } = 0;

        [SettingPropertyBool("Also apply to AI", Order = 2, RequireRestart = false, HintText = "Wether the prisoner size bonus should apply to AI Lords."), SettingPropertyGroup("Prisoner Tweaks/Prisoner Size Bonus*")]
        public bool PrisonerSizeTweakAI { get; set; } = false;

        #endregion

        #region Prisoner Confirmity Tweaks

        [SettingPropertyBool("Prisoner Confirmity*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Modifies the conformity rate of the base game, speeding/slowing the rate at which prisoners can be recruited"), SettingPropertyGroup("Prisoner Tweaks/Prisoner Confirmity*")]
        public bool PrisonerConformityTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Prisoner Confirmity Bonus", 0f, 10f, "0%", Order = 2, RequireRestart = false, HintText = "Adds a % bonues to the conformity generated each hour. Native is 0%"), SettingPropertyGroup("Prisoner Tweaks/Prisoner Confirmity*")]
        public float PrisonerConformityTweakBonus { get; set; } = 0;

        [SettingPropertyBool("Apply Prisoner Confirmity Tweaks to Clan", Order = 3, RequireRestart = false, HintText = "Applies Prisoner Conformity Tweaks to all clan parties as well."), SettingPropertyGroup("Prisoner Tweaks/Prisoner Confirmity*")]
        public bool PrisonerConformityTweaksApplyToClan { get; set; } = false;

        [SettingPropertyBool("Apply Prisoner Confirmity Tweaks to AI", Order = 4, RequireRestart = false, HintText = "Applies Prisoner Conformity Tweaks to all parties, including AI lords as well."), SettingPropertyGroup("Prisoner Tweaks/Prisoner Confirmity*")]
        public bool PrisonerConformityTweaksApplyToAi { get; set; } = false;

        #endregion

        #endregion

        #region Settlement Tweaks #10

        #region Settlement Tweaks - Settlement culture

        [SettingPropertyBool("Settlement Culture Transformation*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the culture of settlement in relation to the owner clan. On deactivation cultures revert back."), SettingPropertyGroup("Settlement Tweaks/Settlement Culture Transformation*")]
        public bool EnableCultureChanger { get; set; } = false;

        [SettingPropertyBool("Change To Culture Of Kingdom Faction Instead*", Order = 1, RequireRestart = true, IsToggle = false, HintText = "Instead of changing the faction to its owner-clan culture, change to its kingdom culture."), SettingPropertyGroup("Settlement Tweaks/Settlement Culture Transformation*")]
        public bool ChangeToKingdomCulture { get; set; } = false;

        [SettingPropertyDropdown("Override Culture For Player Clan*", Order = 3, RequireRestart = true, HintText = "Overrides the culture to change to for player clan owned settlements."), SettingPropertyGroup("Settlement Tweaks/Settlement Culture Transformation*")]
        public DropdownDefault<string> PlayerCultureOverride { get; } = new(new string[]
        {
            "No Override",
            "vlandia",
            "empire",
            "sturgia",
            "aserai",
            "khuzait"
        }, 0);

        [SettingPropertyInteger("Weeks for Settlement Culture Change",1,52, "0 Weeks", Order = 2, RequireRestart = false, HintText = "After how many weeks the culture of a settlement changes to its owner's culture (and produces recruits of the new culturegroup)."), SettingPropertyGroup("Settlement Tweaks/Settlement Culture Transformation*")]
        public int TimeToChanceCulture { get; set; } = 4;

        #endregion


        #region Settlement Tweaks - Disable Troop Donations

        [SettingPropertyBool("Disable Troop Donations*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Disables your clan parties from donating troops to clan owned settlements."), SettingPropertyGroup("Settlement Tweaks/Disable Troop Donations*")]
        public bool DisableTroopDonationPatchEnabled { get; set; } = false;

        [SettingPropertyBool("Disable Troop Donations - Any Settlement", Order = 1, RequireRestart = false, HintText = "Additionally disables your clan parties from donating troops to ANY settlement."), SettingPropertyGroup("Settlement Tweaks/Disable Troop Donations*")]
        public bool DisableTroopDonationAnyEnabled { get; set; } = false;

        #endregion

        #region Settlement Tweaks - Production Tweaks

        [SettingPropertyBool("Village Productivity*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "Enables Tweaks for increased productivity in villages."), SettingPropertyGroup("Settlement Tweaks/Village Productivity*")]
        public bool ProductionTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Village Production: Food", 1f, 3f, "0%", Order = 2, RequireRestart = false, HintText = "Modifies the daily production of food goods in villages."), SettingPropertyGroup("Settlement Tweaks/Village Productivity*")]
        public float ProductionFoodTweakEnabled { get; set; } = 1f;

        [SettingPropertyFloatingInteger("Village Production: Other goods", 1f, 3f, "0%", Order = 3, RequireRestart = false, HintText = "Modifies the daily production of other goods in villages."), SettingPropertyGroup("Settlement Tweaks/Village Productivity*")]
        public float ProductionOtherTweakEnabled { get; set; } = 1f;

        #endregion Settlement Tweaks - Disable Troop Donations

        #region Settlement Tweaks - Buildings

        #region Settlement Tweaks - Buildings - Castle

        #region Settlement Tweaks - Buildings - Castle - Training Fields

        [SettingPropertyBool("Castle Training Field*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the amount of experience the training fields provides for each level."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Training Field*")]
        public bool CastleTrainingFieldsBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("Castle Training Fields Experience Level 1*", 1, 100, RequireRestart = true, Order = 2, HintText = "Native value is 1. Changes the amount of experience the training fields provides at level 1."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Training Field*")]
        public int CastleTrainingFieldsXpAmountLevel1 { get; set; } = 1;

        [SettingPropertyInteger("Castle Training Fields Experience Level 2*", 2, 200, RequireRestart = true, Order = 3, HintText = "Native value is 2. Changes the amount of experience the training fields provides at level 2."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Training Field*")]
        public int CastleTrainingFieldsXpAmountLevel2 { get; set; } = 2;

        [SettingPropertyInteger("Castle Training Fields Experience Level 3*", 3, 300, RequireRestart = true, Order = 4, HintText = "Native value is 3. Changes the amount of experience the training fields provides at level 3."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Training Field*")]
        public int CastleTrainingFieldsXpAmountLevel3 { get; set; } = 3;

        #endregion

        #region Settlement Tweaks - Buildings - Castle - Granary 

        [SettingPropertyBool("Castle Granary*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the amount of food storage the castle granary provides per level."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Granary*")]
        public bool CastleGranaryBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("Castle Granary Food Storage Level 1*", 100, 1000, RequireRestart = true, Order = 2, HintText = "Native value is 100. Changes the amount of food storage the castle granary provides at level 1."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Granary*")]
        public int CastleGranaryStorageAmountLevel1 { get; set; } = 100;

        [SettingPropertyInteger("Castle Granary Food Storage Level 2*", 200, 2000, RequireRestart = true, Order = 3, HintText = "Native value is 200. Changes the amount of food storage the castle granary provides at level 2."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Granary*")]
        public int CastleGranaryStorageAmountLevel2 { get; set; } = 200;

        [SettingPropertyInteger("Castle Granary Food Storage Level 3*", 300, 3000, RequireRestart = true, Order = 4, HintText = "Native value is 300. Changes the amount of food storage the castle granary provides at level 3."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Granary*")]
        public int CastleGranaryStorageAmountLevel3 { get; set; } = 300;

        #endregion

        #region Settlement Tweaks - Buildings - Castle - Gardens

        [SettingPropertyBool("Castle Gardens*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the amount of food the castle gardens produce per level."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Gardens*")]
        public bool CastleGardensBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("Castle Garden Food Production Level 1*", 5, 50, RequireRestart = true, Order = 2, HintText = "Native value is 5. Changes the amount of food the castle gardens produce at level 1."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Gardens*")]
        public int CastleGardensFoodProductionAmountLevel1 { get; set; } = 5;

        [SettingPropertyInteger("Castle Garden Food Production Level 2*", 10, 100, RequireRestart = true, Order = 3, HintText = "Native value is 10. Changes the amount of food the castle gardens produce at level 2."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Gardens*")]
        public int CastleGardensFoodProductionAmountLevel2 { get; set; } = 10;

        [SettingPropertyInteger("Castle Garden Food Production Level 3*", 15, 150, RequireRestart = true, Order = 4, HintText = "Native value is 15. Changes the amount of food the castle gardens produce at level 3."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Gardens*")]
        public int CastleGardensFoodProductionAmountLevel3 { get; set; } = 15;

        #endregion

        #region Settlement Tweaks - Buildings - Castle - Militia Barracks

        [SettingPropertyBool("Castle Militia Barracks*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the militia production that the castle militia barracks provides per level."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Militia Barracks*")]
        public bool CastleMilitiaBarracksBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("Castle Militia Barracks Production Level 1*", 1, 10, RequireRestart = true, Order = 2, HintText = "Native value is 1. Changes the militia production that the castle militia barracks provides at level 1."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Militia Barracks*")]
        public int CastleMilitiaBarracksAmountLevel1 { get; set; } = 1;

        [SettingPropertyInteger("Castle Militia Barracks Production Level 2*", 2, 20, RequireRestart = true, Order = 3, HintText = "Native value is 2. Changes the militia production that the castle militia barracks provides at level 2."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Militia Barracks*")]
        public int CastleMilitiaBarracksAmountLevel2 { get; set; } = 2;

        [SettingPropertyInteger("Castle Militia Barracks Production Level 3*", 3, 30, RequireRestart = true, Order = 4, HintText = "Native value is 3. Changes the militia production that the castle militia barracks provides at level 3."), SettingPropertyGroup("Settlement Tweaks/Buildings/Castle/Castle Militia Barracks*")]
        public int CastleMilitiaBarracksAmountLevel3 { get; set; } = 3;

        #endregion

        #endregion

        #region Settlement Tweaks - Buildings - Town 

        #region Settlement Tweaks - Buildings - Town - Training Fields

        [SettingPropertyBool("Town Training Fields*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the amount of experience the training fields provides for each level."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Training Fields*")]
        public bool TownTrainingFieldsBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("Town Training Fields Experience Level 1*", 30, 300, RequireRestart = true, Order = 2, HintText = "Native value is 30. Changes the amount of experience the training fields provides at level 1."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Training Fields*")]
        public int TownTrainingFieldsXpAmountLevel1 { get; set; } = 30;

        [SettingPropertyInteger("Town Training Fields Experience Level 2*", 60, 600, RequireRestart = true, Order = 3, HintText = "Native value is 60. Changes the amount of experience the training fields provides at level 2."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Training Fields*")]
        public int TownTrainingFieldsXpAmountLevel2 { get; set; } = 60;

        [SettingPropertyInteger("Town Training Fields Experience Level 3*", 100, 1000, RequireRestart = true, Order = 4, HintText = "Native value is 100. Changes the amount of experience the training fields provides at level 3."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Training Fields*")]
        public int TownTrainingFieldsXpAmountLevel3 { get; set; } = 100;

        #endregion

        #region Settlement Tweaks - Buildings - Town - Granary

        [SettingPropertyBool("Town Granary*", RequireRestart = true, IsToggle = true, HintText = "Changes the amount of food storage the town granary provides per level."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Granary*")]
        public bool TownGranaryBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("Town Granary Food Storage Level 1*", 200, 2000, RequireRestart = true, Order = 1, HintText = "Native value is 200. Changes the amount of food storage the town granary provides at level 1."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Granary*")]
        public int TownGranaryStorageAmountLevel1 { get; set; } = 200;

        [SettingPropertyInteger("Town Granary Food Storage Level 2*", 400, 4000, RequireRestart = true, Order = 2, HintText = "Native value is 400. Changes the amount of food storage the town granary provides at level 2."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Granary*")]
        public int TownGranaryStorageAmountLevel2 { get; set; } = 400;

        [SettingPropertyInteger("Town Granary Food Storage Level 3*", 600, 6000, RequireRestart = true, Order = 3, HintText = "Native value is 600. Changes the amount of food storage the town granary provides at level 3."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Granary*")]
        public int TownGranaryStorageAmountLevel3 { get; set; } = 600;

        #endregion

        #region Settlement Tweaks - Settlement Buildings Tweaks - Town Buildings Tweaks - Orchards Tweak

        [SettingPropertyBool("Town Orchards*", Order = 1, RequireRestart = false, IsToggle = true, HintText = "Changes the amount of food the town orchards produce per level."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Orchards*")]
        public bool TownOrchardsBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("Town Orchard Food Production Level 1*", 10, 100, RequireRestart = true, Order = 2, HintText = "Native value is 10. Changes the amount of food the town orchards produce at level 1."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Orchards*")]
        public int TownOrchardsFoodProductionAmountLevel1 { get; set; } = 10;

        [SettingPropertyInteger("Town Orchard Food Production Level 2*", 20, 200, RequireRestart = true, Order = 3, HintText = "Native value is 20. Changes the amount of food the town orchards produce at level 2."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Orchards*")]
        public int TownOrchardsFoodProductionAmountLevel2 { get; set; } = 20;

        [SettingPropertyInteger("Town Orchard Food Production Level 3*", 30, 300, RequireRestart = true, Order = 4, HintText = "Native value is 30. Changes the amount of food the town orchards produce at level 3."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Orchards*")]
        public int TownOrchardsFoodProductionAmountLevel3 { get; set; } = 30;

        #endregion

        #region Settlement Tweaks - Settlement Buildings Tweaks - Town Buildings Tweaks - Militia Barracks Tweak

        [SettingPropertyBool("Town Militia Barracks*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Changes the militia production that the town militia barracks provides per level."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Militia Barracks*")]
        public bool TownMilitiaBarracksBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Town Militia Barracks Production Level 1*", .5f, 15, RequireRestart = true, Order = 2, HintText = "Native value is .5. Changes the militia production that the town militia barracks provides at level 1."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Militia Barracks*")]
        public float TownMilitiaBarracksAmountLevel1 { get; set; } = 0.5f;

        [SettingPropertyFloatingInteger("Town Militia Barracks Production Level 2*", 1f, 20f, RequireRestart = true, Order = 3, HintText = "Native value is 1. Changes the militia production that the town militia barracks provides at level 2."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Militia Barracks*")]
        public float TownMilitiaBarracksAmountLevel2 { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("Town Militia Barracks Production Level 3*", 1.5f, 30f, RequireRestart = true, Order = 4, HintText = "Native value is 1.5. Changes the militia production that the town militia barracks provides at level 3."), SettingPropertyGroup("Settlement Tweaks/Buildings/Town/Town Militia Barracks*")]
        public float TownMilitiaBarracksAmountLevel3 { get; set; } = 1.5f;

        #endregion

        #endregion

        #endregion

        #region Settlement Tweaks - Settlement Food

        [SettingPropertyBool("Settlement Food*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Enables tweaks which provide bonuses to food production in towns and castles."), SettingPropertyGroup("Settlement Tweaks/Settlement Food*")]
        public bool SettlementFoodBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Castle Food Modifier", 1f, 10f, "0%", Order = 2, RequireRestart = false, HintText = "Native value is 100%. Adds a modifier to food production in castles."), SettingPropertyGroup("Settlement Tweaks/Settlement Food*")]
        public float CastleFoodBonus { get; set; } = 0f;

        [SettingPropertyFloatingInteger("Town Food Modifier", 1f, 10f, "0%", Order = 3, RequireRestart = false, HintText = "Native value is 100%. Adds a modifier to food production in towns."), SettingPropertyGroup("Settlement Tweaks/Settlement Food*")]
        public float TownFoodBonus { get; set; } = 0f;

        #region Settlement Tweaks - Settlement Food Bonus - Food Loss from Prosperity Tweak

        [SettingPropertyBool("Food Loss From Prosperity", Order = 1, RequireRestart = false, IsToggle = true, HintText = "Allows you to adjust the loss to food production received from settlement prosperity."), SettingPropertyGroup("Settlement Tweaks/Settlement Food*/Food Loss from Prosperity")]
        public bool SettlementProsperityFoodMalusTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Prosperity Food Loss Divisor", 50, 400, RequireRestart = false, Order = 2, HintText = "Native value is 50. The prosperity of the settlement is divided by this value to calculate the loss. Increasing this value will decrease the amount of food lost."), SettingPropertyGroup("Settlement Tweaks/Settlement Food*/Food Loss from Prosperity")]
        public int SettlementProsperityFoodMalusDivisor { get; set; } = 50;

        #endregion

        #endregion

        #region Settlement Tweaks - Normal Militia

        [SettingPropertyBool("Normal Militia*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Grants a flat bonus to militia growth in towns and castles."), SettingPropertyGroup("Settlement Tweaks/Normal Militia*")]
        public bool SettlementMilitiaBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("Castle Militia Growth Bonus", 0, 50, "0 Militia/Day",  RequireRestart = false, Order = 2, HintText = "Native value is 0. Adds a flat bonus on how many militia gets recruited each day in castles."), SettingPropertyGroup("Settlement Tweaks/Normal Militia*")]
        public int CastleMilitiaBonusFlat { get; set; } = 0;

        [SettingPropertyInteger("Town Militia Growth Bonus", 0, 50, "0 Militia/Day",  RequireRestart = false, Order = 3, HintText = "Native value is 0. Adds a flat bonus on how many militia gets recruited each day in towns."), SettingPropertyGroup("Settlement Tweaks/Normal Militia*")]
        public int TownMilitiaBonusFlat { get; set; } = 0;

        [SettingPropertyFloatingInteger("Castle Militia Retirement Modifier", 0f, 0.25f, "0.0%/Day", RequireRestart = false, Order = 3, HintText = "Native value is 2.5%. Modifies the percentage of your militia retiring each dayin castles."), SettingPropertyGroup("Settlement Tweaks/Normal Militia*")]
        public float CastleMilitiaRetirementModifier { get; set; } = 0.025f;

        [SettingPropertyFloatingInteger("Town Militia Retirement Modifier", 0f, 0.25f, "0.0%/Day", RequireRestart = false, Order = 3, HintText = "Native value is 2.5%. Modifies the percentage of your militia retiring each dayin town."), SettingPropertyGroup("Settlement Tweaks/Normal Militia*")]
        public float TownMilitiaRetirementModifier { get; set; } = 0.025f;

        #endregion

        #region Settlement Tweaks - Militia Bonus Tweaks - Elite Militia

        [SettingPropertyBool("Elite Militia*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Adds a bonus to the chance that militia spawning in towns and castles are elite."), SettingPropertyGroup("Settlement Tweaks/Elite Militia*")]
        public bool SettlementMilitiaEliteSpawnRateBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Elite Melee Militia Spawn Chance", 0.01f, 1f, "0%", RequireRestart = false, Order = 2, HintText = "Native value is 10%. Sets the chance that the militia spawning in towns and castles are elite melee troops."), SettingPropertyGroup("Settlement Tweaks/Elite Militia*")]
        public float SettlementEliteMeleeSpawnRateBonus { get; set; } = 0.1f;

        [SettingPropertyFloatingInteger("Elite Ranged Militia Spawn Chance", 0.01f, 1f, "0%",  RequireRestart = false, Order = 3, HintText = "Native value is 10%. Sets the chance that the militia spawning in towns and castles are elite ranged troops."), SettingPropertyGroup("Settlement Tweaks/Elite Militia*")]
        public float SettlementEliteRangedSpawnRateBonus { get; set; } = 0.1f;

        #endregion

        #region Settlement Tweaks - Tournaments

        #region Settlement Tweaks - Tournaments - Renown Reward

        [SettingPropertyBool("Renown Reward*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Sets the amount of renown awarded when you win a tournament."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Renown Reward*")]
        public bool TournamentRenownIncreaseEnabled { get; set; } = false;

        [SettingPropertyInteger("Tournament Renown Reward", 1, 50, "0 Renown", RequireRestart = false, Order = 2, HintText = "Native value is 3. Increases the amount of renown awarded when you win a tournament."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Renown Reward*")]
        public int TournamentRenownAmount { get; set; } = 3;

        #endregion

        #region Settlement Tweaks - Tournaments - Gold Reward

        [SettingPropertyBool("Gold Reward*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Adds the set amount of gold to the rewards when you win a tournament."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Gold Reward*")]
        public bool TournamentGoldRewardEnabled { get; set; } = false;

        [SettingPropertyInteger("Tournament Gold Reward", 0, 5000, "0 Denar", RequireRestart = false, Order = 2, HintText = "Native value is 0. Adds the set amount of gold to the rewards when you win a tournament."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Gold Reward*")]
        public int TournamentGoldRewardAmount { get; set; } = 0;

        #endregion

        #region Settlement Tweaks - Tournaments - Maximum Bet

        [SettingPropertyBool("Maximum Bet*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Sets the maximum amount of gold that you can bet per round in tournaments."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Maximum Bet*")]
        public bool TournamentMaxBetAmountTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Maximum Bet Amount", 0, 4000, "0 Denar", RequireRestart = false, Order = 2, HintText = "Native value is 150. Sets the maximum amount of gold that you can bet per round in tournaments."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Maximum Bet*")]
        public int TournamentMaxBetAmount { get; set; } = 150;

        #endregion

        #region Settlement Tweaks - Tournaments - Hero Experience

        [SettingPropertyBool("Hero Experience Modifier*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Overrides the native multiplier value for experience gain in tournaments for hero characters."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Hero Experience Modifier*")]
        public bool TournamentHeroExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Tournament Hero Experience Modifier", 0.33f, 10f, "0%", RequireRestart = false, Order = 2, HintText = "Native value is 33%. Sets the modifier applied to experience gained in tournaments by hero characters. 100% = full real-world experience."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Hero Experience Modifier*")]
        public float TournamentHeroExperienceMultiplier { get; set; } = 0.33f;

        #endregion

        #region Settlement Tweaks - Tournaments - Arena Hero Experience

        [SettingPropertyBool("Arena Hero Experience Modifier*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Overrides the native multiplier value for experience gain in arena fights for hero characters."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Arena Experience Modifier*")]
        public bool ArenaHeroExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Arena Hero Experience Modifier", 0.06f, 5f, "0%", Order = 2, RequireRestart = false, HintText = "Native value is 6%. Sets the modifier applied to experience gain in arena fights for hero characters. 100% = full real-world experience."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Arena Experience Modifier*")]
        public float ArenaHeroExperienceMultiplier { get; set; } = 0.06f;

        #endregion

        #region Settlement Tweaks - Tournament Tweaks - Minimum Betting Odds

        [SettingPropertyBool("Minimum Betting Odds*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Allows you to set the minimum betting odds in tournaments."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Minimum Betting Odds*")]
        public bool MinimumBettingOddsTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("Minimum Betting Odds", 1.1f, 10f, RequireRestart = false, Order = 2, HintText = "Native: 1.1. The minimum odds for tournament bets, higher means more yield for your bets, if won."), SettingPropertyGroup("Settlement Tweaks/Tournaments/Minimum Betting Odds*")]
        public float MinimumBettingOdds { get; set; } = 1.1f;

        #endregion

        #endregion

        #region Settlement Tweaks - Workshops

        #region Settlement Tweaks - Workshops - Workshop Limit

        [SettingPropertyBool("Workshop Count Limit*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Sets the base maximum number of workshops you can have and the limit increase gained per clan tier."), SettingPropertyGroup("Settlement Tweaks/Workshops/Workshop Count Limit*")]
        public bool MaxWorkshopCountTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Base Workshop Count Limit", 0, 20, "0 Workshops", RequireRestart = false, Order = 2, HintText = "Native value is 1. Sets the base maximum number of workshops you can have."), SettingPropertyGroup("Settlement Tweaks/Workshops/Workshop Count Limit*")]
        public int BaseWorkshopCount { get; set; } = 1;

        [SettingPropertyInteger("Bonus Workshops Per Clan Tier", 0, 5, "0 Shops/Tier", RequireRestart = false, Order = 3, HintText = "Native value is 1. Sets the base maximum number of workshops you can have and the limit increase gained per clan tier."), SettingPropertyGroup("Settlement Tweaks/Workshops/Workshop Count Limit*")]
        public int BonusWorkshopsPerClanTier { get; set; } = 1;

        #endregion

        #region Settlement Tweaks - Workshops - Workshop Cost Tweak

        [SettingPropertyBool("Workshop Buy Cost*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "Sets the base value used to calculate the cost of workshops. Reduce to reduce cost of workshops."), SettingPropertyGroup("Settlement Tweaks/Workshops/Workshop Buy Cost*")]
        public bool WorkshopBuyingCostTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("Workshop Base Cost", 0, 15000, "0 Denar", RequireRestart = false, Order = 2, HintText = "Native value is 10,000. Sets the base value used to calculate the cost of workshops (+ workshop type base cost + 0.5 x town prosperity). Reduce to reduce cost of workshops."), SettingPropertyGroup("Settlement Tweaks/Workshops/Workshop Buy Cost*")]
        public int WorkshopBaseCost { get; set; } = 10000;

        #endregion

        #region Settlement Tweaks - Workshops - Workshop Effectivness

        [SettingPropertyBool("Workshop Effectivness*", RequireRestart = true, IsToggle=true, Order = 2, HintText = "Native value is 100%. Sets the base value used to calculate the cost of workshops (+ workshop type base cost + 0.5 x town prosperity). Reduce to reduce cost of workshops."), SettingPropertyGroup("Settlement Tweaks/Workshops/Workshop Effectivness*")]
        public bool WorkshopEffectivnessEnabled { get; set; } = false;
        [SettingPropertyFloatingInteger("Workshop Daily Cost Modifier", 1f, 5f, "0%", RequireRestart = false, Order = 2, HintText = "Native value is 100%. Increases effectivness of workshops by decreasing its daily expenses."), SettingPropertyGroup("Settlement Tweaks/Workshops/Workshop Effectivness*")]
        public float WorkshopEffectivnessFactor { get; set; } = 1f;

        #endregion

        #endregion

        #endregion

        #region Miscellaneous #11

        [SettingPropertyBool("Disable Quest Troops Affecting Morale*", Order = 1, RequireRestart = true, HintText = "When enabled, quest troops such as \"Borrowed Troop\" in your party are ignored when party morale is calculated."), SettingPropertyGroup("Misc")]
        public bool QuestCharactersIgnorePartySize { get; set; } = false;

        [SettingPropertyBool("Show Number of Days of Food*", Order = 2, RequireRestart = true, HintText = "Changes the number showing how much food you have to instead show how many days' worth of food you have. (Bottom right of campaign map UI)."), SettingPropertyGroup("Misc")]
        public bool ShowFoodDaysRemaining { get; set; } = false;

        [SettingPropertyInteger("Campaign Speed Fast Forward", 2, 32, Order = 3, RequireRestart = false, HintText = "Sets the campaign speed in fast forward mode. Vanilla is 4."), SettingPropertyGroup("Misc")]
        public int CampaignSpeed { get; set; } = 4;

        /* Disable in 1.5.7.2 until we understand changes to the main quest.
        [SettingPropertyBool("Enable Auto-Extension of the 'Stop the Conspiracy' Quest", RequireRestart = false, HintText = "Automatically extends the timer of the 'Stop the Conspiracy' quest as TW hasn't finished it yet.")]
        public bool TweakedConspiracyQuestTimerEnabled { get; set; } = true;
        */
        #endregion
    }
}
