using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;
using MCM.Abstractions.Dropdown;
using MCM.Abstractions.Settings.Base;
using System;
using System.Collections.Generic;

namespace BannerlordTweaks
{
    public class BannerlordTweaksSettings : AttributeGlobalSettings<BannerlordTweaksSettings>
    {
        public override string Id => "BannerlordTweaksSettings";
        public override string DisplayName => "Bannerlord Tweaks";
        public override string FolderName => "BannerlordTweaksSettings";
        public override string FormatType => "json2";


        #region Battle Tweaks #2

        #region Battle Tweaks - Battle Renown, Influence, Morale Tweaks

        [SettingPropertyBool("{=BT_Settings_000100}Battle Renown, Influence, Morale Tweaks" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_000100_Desc}Applies the set multiplier to renown, influence and morale gain from battles (applies to the player only)."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000100}Battle Renown, Influence, Morale Tweaks" + "*", GroupOrder =1)]
        public bool BattleRewardTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_000101}Battle Renown Amount", 0.1f, 5f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_000101_Desc}Native value is 100%. The amount of renown you receive from a battle is multiplied by this value."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000100}Battle Renown, Influence, Morale Tweaks" + "*")]
        public float BattleRenownMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_000102}Battle Influence Amount", 0.1f, 5f, "0%", RequireRestart = false, Order = 3, HintText = "{=BT_Settings_000102_Desc}Native value is 100%. The amount of influence you receive from a battle is multiplied by this value."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000100}Battle Renown, Influence, Morale Tweaks" + "*")]
        public float BattleInfluenceMultiplier { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_000103}Battle Morale Amount", 0.1f, 5f, "0%", RequireRestart = false, Order = 4, HintText = "{=BT_Settings_000103_Desc}Native value is 100%. The amount of morale you receive from a battle is multiplied by this value."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000100}Battle Renown, Influence, Morale Tweaks" + "*")]
        public float BattleMoraleMultiplier { get; set; } = 1f;

        [SettingPropertyBool("{=BT_Settings_000104}Also Apply To AI", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_000104_Desc}Applies the renown, influence and morale modifiers to AI parties."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000100}Battle Renown, Influence, Morale Tweaks" + "*")]
        public bool BattleRewardApplyToAI { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_000105}Show Calculation Message", Order = 6, RequireRestart = false, HintText = "{=BT_Settings_000105_Desc}Shows detailed calculation for renown, influence and morale tweaks in message log."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000100}Battle Renown, Influence, Morale Tweaks" + "*")]
        public bool BattleRewardShowDebug { get; set; } = false;

        #endregion

        #region Battle Tweaks - Hideout Tweaks

        [SettingPropertyBool("{=BT_Settings_000200}Hideout Tweaks" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_000200_Desc}Changes game behavior inside hideout battles."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks"+ "/" + "{=BT_Settings_000200}Hideout Tweaks" + "*", GroupOrder =2)]
        public bool HideoutBattleTroopLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_000201}Hideout Battle Troop Limit", 5, 90, "0 Soldiers", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_000201_Desc}Native value is 9 or 10. Changes the maximum troop limit to the set value inside hideout battles. Cannot be higher than 90 because it causes bugs."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000200}Hideout Tweaks" + "*")]
        public int HideoutBattleTroopLimit { get; set; } = 10;

        [SettingPropertyBool("{=BT_Settings_000202}Continue Hideout Battle On Player Death" + "*", Order = 3, RequireRestart = true, HintText = "{=BT_Settings_000202_Desc}Native value is false. If enabled, you will not automatically lose the hideout battle if you die. Your troops will charge and the boss duel will be disabled."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000200}Hideout Tweaks" + "*")]
        public bool ContinueHideoutBattleOnPlayerDeath { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_000203}Continue Battle On Losing Duel" + "*", Order = 4, RequireRestart = true, HintText = "{=BT_Settings_000203_Desc}Native value is false. If enabled, your troops will rush to avenge you and finish everyone off."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000200}Hideout Tweaks" + "*")]
        public bool ContinueHideoutBattleOnPlayerLoseDuel { get; set; } = false;

        #endregion

        #region Battle Tweaks - Siege Tweaks

        [SettingPropertyBool("{=BT_Settings_000300}Siege Tweaks" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_000300_Desc}Tweaks for siege engine construction speed and collateral casulaties during sieges."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000300}Siege Tweaks" + "*", GroupOrder =3)]
        public bool SiegeTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_000301}Siege Construction Progress Per Day Amount", 0.1f, 10.0f, "0%", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_000301_Desc}Native value is 100%. This tweak adds a modifier to the construction progress per day for sieges. A smaller number results in longer siege times."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000300}Siege Tweaks" + "*")]
        public float SiegeConstructionProgressPerDayMultiplier { get; set; } = 1f;

        [SettingPropertyInteger("{=BT_Settings_000302}Siege Collateral Damage Casualties", 0, 10, Order = 5, RequireRestart = false, HintText = "{=BT_Settings_000302_Desc}Native value is 0. This tweak adds to the base value (1 or 2 with Crossbow Terror Perk) used to calculate collateral casualties during the campaign map siege stage."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000300}Siege Tweaks" + "*")]
        public int SiegeCollateralDamageCasualties { get; set; } = 0;

        [SettingPropertyInteger("{=BT_Settings_000303}Siege Destruction Casualties", 0, 10, Order = 6, RequireRestart = false, HintText = "{=BT_Settings_000303_Desc}Native value is 0. This tweak adds to the base value (2) used to calculate destruction casualties during the campaign map siege stage."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000300}Siege Tweaks" + "*")]
        public int SiegeDestructionCasualties { get; set; } = 0;

        #endregion

        #region Battle Tweaks - Troop Experience Tweaks

        [SettingPropertyBool("{=BT_Settings_000400}Troop Experience" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_000400_Desc}Tweaks for experience gain of troops in battles and simulations."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000400}Troop Experience" + "*", GroupOrder =4)]
        public bool TroopExperienceTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_000401}Troop Battle Experience", Order = 2, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_000401_Desc}Modifies the amount of experience that ALL troops receive during battles (Note: Only troops, not heroes)."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000400}Troop Experience" + "*/" + "{=BT_Settings_000401}Troop Battle Experience", GroupOrder =1)]
        public bool TroopBattleExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_000402}Troop Battle Experience Amount", .01f, 6f, "0%", RequireRestart = false, Order = 3, HintText = "{=BT_Settings_000402_Desc}Native value is 100%. Modifies the amount of experience that ALL troops receive during fought battles (Note: Only troops, not heroes. Does not apply to simulated battles.)."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000400}Troop Experience" + "*/" + "{=BT_Settings_000401}Troop Battle Experience")]
        public float TroopBattleExperienceMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=BT_Settings_000403}Troop Simulation Experience", Order = 4, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_000403_Desc}Modifies the experience gained from simulated battles. This is applied to all fights (including NPC fights) on the campaign map."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000400}Troop Experience" + "*/" + "{=BT_Settings_000403}Troop Simulation Experience", GroupOrder =2)]
        public bool TroopBattleSimulationExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_000404}Troop Simulation Experience Amount", .01f, 8f, "0%", RequireRestart = false, Order = 5, HintText = "{=BT_Settings_000404_Desc}Native value is 90%. Provides a multiplier to experience gained from simulated battles. This is applied to all simulated fights on the campaign map."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000400}Troop Experience" + "*/" + "{=BT_Settings_000403}Troop Simulation Experience")]
        public float TroopBattleSimulationExperienceMultiplier { get; set; } = 0.9f;

        #endregion

        #region Battle Tweaks - Weapon Cut Through Tweaks

        [SettingPropertyBool("{=BT_Settings_000500}Weapon Cut Through Tweaks" + "*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "{=BT_Settings_000500_Desc}Allows all weapon types to cut through and hit multiple people."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000500}Weapon Cut Through Tweaks" + "*", GroupOrder =5)]
        public bool SliceThroughEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_000501}All Two-Handed Weapons Cut Through", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_000501_Desc}Allows all two-handed weapon types to cut through and hit multiple people."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000500}Weapon Cut Through Tweaks" + "*")]
        public bool TwoHandedWeaponsSliceThroughEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_000502}All One-Handed Weapons Cut Through", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_000502_Desc}Allows all single-handed weapon types to cut through and hit multiple people."), SettingPropertyGroup("{=BT_Settings_000000}Battle Tweaks" + "/" + "{=BT_Settings_000500}Weapon Cut Through Tweaks" + "*")]
        public bool SingleHandedWeaponsSliceThroughEnabled { get; set; } = false;

        #endregion

        #endregion

        #region Campaign Tweaks #2

        #region Campaign Tweaks - Battle Size Tweak

        [SettingPropertyBool("{=BT_Settings_001100}Battle Size Tweak"+"*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "{=BT_Settings_001100_Desc}Allows you to set the battle size limit outside of native values. WARNING: Setting this above 1000 can cause performance degradation and crashes."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks"+"/"+ "{=BT_Settings_001100}Battle Size Tweak"+"*", GroupOrder =1)]
        public bool BattleSizeTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_001101}Battle Size Limit", 2, 1800, "0 Soldiers", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_001101_Desc}Sets the limit for number of troops on a battlefield, ignoring what is in Bannerlord Options. WARNING: Will crash if all troops + their horses exceed 2000."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001100}Battle Size Tweak" + "*")]
        public int BattleSize { get; set; } = 1000;

        #endregion

        #region Campaign Tweaks - Difficulty Settings

        [SettingPropertyBool("{=BT_Settings_001200}Difficulty Tweaks"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_001200_Desc}Allows you to change the multiplier for several difficulty settings."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks"+"*", GroupOrder =2)]
        public bool DifficultyTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_001201}Damage to Player Tweak", Order = 2, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_001201_Desc}Allows you to change the multiplier for damage the player receives."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001201}Damage to Player Tweak", GroupOrder =1)]
        public bool DamageToPlayerTweakEnabled { get; set; } = false;
 
        [SettingPropertyFloatingInteger("{=BT_Settings_001202}Damage to Player Tweak Amount", 0.1f, 5.0f,"0%", RequireRestart = false, Order = 3, HintText = "{=BT_Settings_001202_Desc}Native values: Very Easy: 30%, Easy: 67%, Realistic: 100%. This value is used to calculate the damage player receives."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001201}Damage to Player Tweak")]
        public float DamageToPlayerMultiplier { get; set; } = 1.0f;
// removed in 1.5.10
//        [SettingPropertyBool("{=BT_Settings_001203}Damage to Friends Tweak", Order = 4, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_001203_Desc}Allows you to change the damage the player's friends receive."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001203}Damage to Friends Tweak", GroupOrder =2)]
//        public bool DamageToFriendsTweakEnabled { get; set; } = false;
//
//        [SettingPropertyFloatingInteger("{=BT_Settings_001204}Damage to Friends Tweak Amount", 0.1f, 5.0f, "0%", RequireRestart = false, Order = 5, HintText = "{=BT_Settings_001204_Desc}Native values: Very Easy: 30%, Easy: 67%, Realistic: 100%. This value is used to calculate the damage the player's friends receive."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001203}Damage to Friends Tweak")]
//        public float DamageToFriendsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=BT_Settings_001205}Damage to Player's Troops Tweak", Order = 6, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_001205_Desc}Allows you to change the multiplier for damage the player's troops receive."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001205}Damage to Player's Troops Tweak", GroupOrder =3)]
        public bool DamageToTroopsTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_001206}Damage to Troops Tweak Amount", 0.1f, 5.0f, "0%", RequireRestart = false, Order = 7, HintText = "{=BT_Settings_001206_Desc}Native values: Very Easy: 30%, Easy: 67%, Realistic: 100%. This value is used to calculate the damage to the player's troops."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001205}Damage to Player's Troops Tweak")]
        public float DamageToTroopsMultiplier { get; set; } = 1.0f;

        [SettingPropertyBool("{=BT_Settings_001207}Combat AI Difficulty Tweak", Order = 8, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_001207_Desc}Allows you to change the AI combat difficulty."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001207}Combat AI Difficulty Tweak", GroupOrder =4)]
        public bool CombatAIDifficultyTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_001208}Combat AI Difficulty Tweak Amount", 0.1f, 1.0f, "0%", RequireRestart = false, Order = 9, HintText = "{=BT_Settings_001208_Desc}Native values: Very Easy: 10%, Easy: 32%, Realistic: 96%. This value is used to calculate AI combat difficulty."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001207}Combat AI Difficulty Tweak")]
        public float CombatAIDifficultyMultiplier { get; set; } = 0.96f;

        [SettingPropertyBool("{=BT_Settings_001209}Player Map Movement Speed Tweak", Order = 10, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_001209_Desc}Allows you to change the bonus map movement speed multiplier the player receives."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001209}Player Map Movement Speed Tweak", GroupOrder =5)]
        public bool PlayerMapMovementSpeedBonusTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_001210}Player Map Movement Tweak Amount", 0.0f, 2.0f, "0%", RequireRestart = false, Order = 11, HintText = "{=BT_Settings_001210_Desc}Native values: Very Easy: 10%, Easy: 5%, Realistic: 0%. This value is used to calculate player's map movement speed."), SettingPropertyGroup("{=BT_Settings_001000}Campaign Tweaks" + "/" + "{=BT_Settings_001200}Difficulty Tweaks" + "*/" + "{=BT_Settings_001209}Player Map Movement Speed Tweak")]
        public float PlayerMapMovementSpeedBonusMultiplier { get; set; } = 0.0f;

        #endregion

        #endregion

        #region Character Tweaks #4

        #region Character Tweaks - Age Tweaks

        [SettingPropertyBool("{=BT_Settings_002100}Age Tweaks"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_002100_Desc}Enables the tweaking of character age behavior."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks"+"/" + "{=BT_Settings_002100}Age Tweaks"+"*", GroupOrder =1)]
        public bool AgeTweaksEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_002101}Become Infant Age", 0, 125, "0 Years", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_002101_Desc}Native: 3. Must be less than Become Child Age."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002100}Age Tweaks" + "*")]
        public int BecomeInfantAge { get; set; } = 3;

        [SettingPropertyInteger("{=BT_Settings_002102}Become Child Age", 0, 125, "0 Years", RequireRestart = false, Order = 3, HintText = "{=BT_Settings_002102_Desc}Native: 6. Must be less than Become Teenager Age."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002100}Age Tweaks" + "*")]
        public int BecomeChildAge { get; set; } = 6;

        [SettingPropertyInteger("{=BT_Settings_002103}Become Teenager Age", 0, 125, "0 Years", RequireRestart = false, Order = 4, HintText = "{=BT_Settings_002103_Desc}Native: 14. Must be less than Hero Comes Of Age."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002100}Age Tweaks" + "*")]
        public int BecomeTeenagerAge { get; set; } = 14;

        [SettingPropertyInteger("{=BT_Settings_002104}Hero Comes Of Age", 0, 125, "0 Years", RequireRestart = false, Order = 5, HintText = "{=BT_Settings_002104_Desc}Native: 18. Must be less than Become Old Age."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002100}Age Tweaks" + "*")]
        public int HeroComesOfAge { get; set; } = 18;

        [SettingPropertyInteger("{=BT_Settings_002105}Become Old Age", 0, 125, "0 Years", RequireRestart = false, Order = 6, HintText = "{=BT_Settings_002105_Desc}Native: 47. Must be less than Max Age."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002100}Age Tweaks" + "*")]
        public int BecomeOldAge { get; set; } = 47;

        [SettingPropertyInteger("{=BT_Settings_002106}Max Age", 0, 125, "0 Years", RequireRestart = false, Order = 7, HintText = "{=BT_Settings_002106_Desc}Native: 125."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002100}Age Tweaks" + "*")]
        public int MaxAge { get; set; } = 125;

        #endregion

        #region Character Tweaks - Attribute Focus Point Tweaks

        [SettingPropertyBool("{=BT_Settings_002200}Attribute-Focus Points Tweaks" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_002200_Desc}Changes the values used to calculate how many Attribute and Focus points Heroes gain."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002200}Attribute-Focus Points Tweaks"+"*", GroupOrder =2)]
        public bool AttributeFocusPointTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_002201}Levels per Attribute Point", 1, 5, "0 Level", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_002201_Desc}Native value is 4. How many levels you need to gain to receive an attribute point."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002200}Attribute-Focus Points Tweaks" + "*")]
        public int AttributePointRequiredLevel { get; set; } = 4;

        [SettingPropertyInteger("{=BT_Settings_002202}Focus Point Per Level", 1, 5, "0 Points", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_002202_Desc}Native value is 1. This is the amount of focus points earned per level."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002200}Attribute-Focus Points Tweaks" + "*")]
        public int FocusPointsPerLevel { get; set; } = 1;

        #endregion

        #region Character Tweaks - Hero Skill Multiplier Tweaks

        [SettingPropertyBool("{=BT_Settings_002300}Hero Skill Experience"+"*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "{=BT_Settings_002300_Desc}Enable bonuses to the skill experience your hero and companions members gain."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience"+"*", GroupOrder =3)]
        public bool SkillExperienceMultipliersEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_002301}Player Skill Experience", Order = 2, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_002301_Desc}Applies a modifier to the amount of experience recieved for skills. Affects the player only. 100% = No Bonus."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002301}Player Skill Experience", GroupOrder =1)]
        public bool HeroSkillExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_002302}Player Skill Experience Amount", 1f, 5f,"0%", RequireRestart = false, HintText = "{=BT_Settings_002302_Desc}Applies a modifier to the amount of experience recieved for skills. Affects the player only. 100% = No Bonus."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002301}Player Skill Experience")]
        public float HeroSkillExperienceMultiplier { get; set; } = 1f;

        [SettingPropertyBool("{=BT_Settings_002303}Companion Skill Experience", Order = 3, RequireRestart = false, IsToggle=true, HintText = "{=BT_Settings_002303_Desc}Applies a modifier to the amount of experience recieved for skills. Affects Compaions only. 100% = No Bonus."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002303}Companion Skill Experience", GroupOrder = 2)]
        public bool CompanionSkillExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_002304}Companion Skill Experience Amount", 1f, 20f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002304_Desc}Applies a modifier to the amount of experience recieved for skills. Affects the Companion only. 100% = No Bonus."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002303}Companion Skill Experience")]
        public float CompanionSkillExperienceMultiplier { get; set; } = 1f;


        #region Character Tweaks - Hero Skill Multiplier Tweaks - Enable Per-Skill Bonuses

        [SettingPropertyBool("{=BT_Settings_002305}Per Skill Bonuses", Order = 4, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_002305_Desc}Modifies the amount of experience recieved for specific skills before applying global experience modifier. Affects the player and companions only. 1.0 = No Bonus. 1.1 = 10%, etc."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses", GroupOrder = 3)]
        public bool PerSkillBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_002306}Per-Skill Experience Amount: Engineering", 1f, 10f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002306_Desc}Modifies the amount of Engineering experience recieved."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses")]
        public float SkillBonusEngineering { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_002307}Per-Skill Experience Amount: Leadership", 1f, 10f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002307_Desc}Modifies the amount of Leadership experience recieved."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses")]
        public float SkillBonusLeadership { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_002308}Per-Skill Experience Amount: Medicine", 1f, 10f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002308_Desc}Modifies the amount of Medicine experience recieved."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses")]
        public float SkillBonusMedicine { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_002309}Per-Skill Experience Amount: Riding", 1f, 10f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002309_Desc}Modifies the amount of Riding experience recieved."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses")]
        public float SkillBonusRiding { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_002310}Per-Skill Experience Amount: Roguery", 1f, 10f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002310_Desc}Modifies the amount of Roguery experience recieved."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses")]
        public float SkillBonusRoguery { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_002311}Per-Skill Experience Amount: Scouting", 1f, 10f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002311_Desc}Modifies the amount of Scouting experience recieved."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses")]
        public float SkillBonusScouting { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_002312}Per-Skill Experience Amount: Trade", 1f, 10f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002312_Desc}Modifies the amount of Trade experience recieved."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses")]
        public float SkillBonusTrade { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_002313}Per-Skill Experience Amount: Smithing", 1f, 10f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002313_Desc}Modifies the amount of Smithing experience recieved."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002300}Hero Skill Experience" + "*/" + "{=BT_Settings_002305}Per-Skill Bonuses")]
        public float SkillBonusSmithing { get; set; } = 1f;

        #endregion

        #endregion

        #region Character Tweaks - Pregnancy Tweaks

        [SettingPropertyBool("{=BT_Settings_002400}Pregnancy Tweaks"+"*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "{=BT_Settings_002400_Desc}Enables several tweaks related to pregnancy behavior."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks"+"/"+"{=BT_Settings_002400}Pregnancy Tweaks" + "*", GroupOrder =4)]
        public bool PregnancyTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_002401}Disable Stillbirths", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_002401_Desc}Disables the chance of children dying when born."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*")]
        public bool NoStillbirthsTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_002402}Disable Maternal Mortality", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_002402_Desc}Disables the chance of mothers dying when giving birth."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*")]
        public bool NoMaternalMortalityTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_002403}Pregnancy Duration Tweak", Order = 4, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_002403_Desc}Allows for adjusting the duration for a pregnancy."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/"+ "{=BT_Settings_002403}Pregnancy Duration Tweak", GroupOrder =1)]
        public bool PregnancyDurationTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_002404}Pregnancy Duration", 1, 96, "0 Days", RequireRestart = false, HintText = "{=BT_Settings_002404_Desc}Native value is 36 days."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002403}Pregnancy Duration Tweak")]
        public int PregnancyDuration { get; set; } = 36;

        [SettingPropertyBool("{=BT_Settings_002405}Gender Ratio Tweak", Order = 5, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_002405_Desc}Allows for adjusting the gender ratio of births."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002405}Gender Ratio Tweak", GroupOrder =2)]
        public bool FemaleOffspringProbabilityTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_002406}Probability for female children", 0.0f, 1.0f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002406_Desc}Native value is 51%. Set to 0% to disable female births."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002405}Gender Ratio Tweak")]
        public float FemaleOffspringProbability { get; set; } = 0.51f;

        [SettingPropertyBool("{=BT_Settings_002407}Twins Probability Tweak", Order = 6, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_002407_Desc}Allows for adjusting the chance of giving birth to twins."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002407}Twins Probability Tweak", GroupOrder =3)]
        public bool TwinsProbabilityTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_002408}Probability to deliver twins", 0.0f, 1.0f, "0%", RequireRestart = false, HintText = "{=BT_Settings_002408_Desc}Native value is 3%. Determines the chance of giving birth to twins."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002407}Twins Probability Tweak")]
        public float TwinsProbability { get; set; } = 0.03f;

        [SettingPropertyBool("{=BT_Settings_002409}Pregnancy Chance Tweaks", Order = 7, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_002409_Desc}Enabling this will completely override the daily pregnancy check. All settings below will be applied!"), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002409}Pregnancy Chance Tweaks", GroupOrder =4)]
        public bool DailyChancePregnancyTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_002410}Player is Infertile", Order = 1, RequireRestart = false, HintText = "{=BT_Settings_002410_Desc}Native: disabled. If enabled, the player will not be able to have children."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002409}Pregnancy Chance Tweaks")]
        public bool PlayerCharacterInfertileEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_002411}Min Pregnancy Age", 0, 125, "0 Years", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_002411_Desc}Native: 18. Minimum age that someone can get pregnant."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002409}Pregnancy Chance Tweaks")]
        public int MinPregnancyAge { get; set; } = 18;

        [SettingPropertyInteger("{=BT_Settings_002412}Max Pregnancy Age", 0, 125, "0 Years",  Order = 3,  RequireRestart = false, HintText = "{=BT_Settings_002412_Desc}Native: 45. Maximum age that someone can get pregnant."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002409}Pregnancy Chance Tweaks")]
        public int MaxPregnancyAge { get; set; } = 45;

        [SettingPropertyFloatingInteger("{=BT_Settings_002413}Clan Fertility Bonus", 1f, 10f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_002413_Desc}Adds modifier to your clan members to become pregnant. 100% = No Bonus, 200% = 2x chance. Note: May not do much after ~6-8 kids due to the base pregnancy calculations."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002409}Pregnancy Chance Tweaks")]
        public float ClanFertilityBonus { get; set; } = 1f;

        [SettingPropertyInteger("{=BT_Settings_002414}Max Children", 0, 100, "0 Children", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_002414_Desc}Default: 5. Maximum number of children that someone can have."), SettingPropertyGroup("{=BT_Settings_002000}Character Tweaks" + "/" + "{=BT_Settings_002400}Pregnancy Tweaks" + "*/" + "{=BT_Settings_002409}Pregnancy Chance Tweaks")]
        public int MaxChildren { get; set; } = 5;

        #endregion

        #endregion

        #region Clan Tweaks #5

        #region Clan Tweaks - Companion Limit Tweak

        [SettingPropertyBool("{=BT_Settings_003100}Companion Limit Tweak"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_003100_Desc}Sets the base companion limit and the bonus gained per clan tier."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks"+"/"+ "{=BT_Settings_003100}Companion Limit"+"*", GroupOrder =1)]
        public bool CompanionLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_003101}Base Companion Limit", 1, 20, "0 Companions", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_003101_Desc}Native value is 3. Sets the base companion limit."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003100}Companion Limit" + "*")]
        public int CompanionBaseLimit { get; set; } = 3;

        [SettingPropertyInteger("{=BT_Settings_003102}Companion Bonus Per Clan Tier", 0, 10, Order = 3, RequireRestart = false, HintText = "{=BT_Settings_003102_Desc}Native value is 1. Sets the bonus to companion limit per clan tier. This value is multiplied by your clan tier. Note that Leadership 'We Pledge Our Swords' perk will also increse this number by 1."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003100}Companion Limit" + "*")]
        public int CompanionLimitBonusPerClanTier { get; set; } = 1;

        [SettingPropertyBool("{=BT_Settings_003103}Enable Unlimited Wanderers Patch"+"*", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_003103_Desc}Removes the soft cap on the maximum number of potential companions who can spawn. Native limits the # of wanderers to ~25. This will remove that limit. Note: Requires a new campaign to take effect, as the cap is set when a new game is generated. Credit to Bleinz for his UnlimitedWanderers mod."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003100}Companion Limit" + "*")]
        public bool UnlimitedWanderersPatch { get; set; } = false;

        #endregion

        #region Clan Tweaks - Party Limits - Player Parties Limit

        [SettingPropertyBool("{=BT_Settings_003200}Party Limits"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_003200_Desc}Changes the number of parties you and ai lords can field and the bonus gained per clan tier."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits"+"*", GroupOrder =2)]
        public bool PartiesLimitTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_003201}Player Parties Limit", Order = 1, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_003201_Desc}Changes the base number of parties you can field and the bonus gained per clan tier."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits"+"*/"+ "{=BT_Settings_003201}Player Parties Limit", GroupOrder = 1)]
        public bool ClanPartiesLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_003202}Base Clan Parties Limit", 1, 10, "0 Parties", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_003202_Desc}Native value is 1. This is the number of parties you can field at the start."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits"+"*/"+ "{=BT_Settings_003201}Player Parties Limit")]
        public int BaseClanPartiesLimit { get; set; } = 1;

        [SettingPropertyFloatingInteger("{=BT_Settings_003203}Clan Parties Bonus Per Clan Tier", 0.0f, 6f, "0.0 Parties/Clan Tier", RequireRestart = false, Order = 3, HintText = "{=BT_Settings_003203_Desc}Native has a calculation for this: 1 party for under tier 3, 2 parties for under tier 5, 3 parties for over tier 5. This setting is multiplied by your clan tier. A value of 0.5 will equate to 1 extra party per 2 clan tiers, which eqautes to the same as native."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits" + "*/" + "{=BT_Settings_003201}Player Parties Limit")]
        public float ClanPartiesBonusPerClanTier { get; set; } = 0.5f;

        #endregion

        #region Clan Tweaks - AI Lord Parties Limmit

        [SettingPropertyBool("{=BT_Settings_003204}AI Lord Parties Limit", Order = 1, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_003204_Desc}Changes the base number of parties AI Lords can field."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits" + "*/" + "{=BT_Settings_003204}AI Lord Parties Limit", GroupOrder = 2)]
        public bool AIClanPartiesLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_003205}Add to AI Lord Parties Limit", 1, 10, "0 Extra Parties", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_003205_Desc}This adds to the the base number of parties AI Lords can field. [Native is 1 for Tier 3 and below, 2 at T4, 3 at T5 and up.] Minor Factions are not included unless the option below is also enabled."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits" + "*/" + "{=BT_Settings_003204}AI Lord Parties Limit")]
        public int BaseAIClanPartiesLimit { get; set; } = 0;

        [SettingPropertyBool("{=BT_Settings_003206}Also Adjust Minor Factions", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_003206_Desc}Changes the base number of parties AI Minor Faction Lords can field. [Native is 1-4, depending on Clan tier.]"), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits" + "*/" + "{=BT_Settings_003204}AI Lord Parties Limit")]
        public bool AIMinorClanPartiesLimitTweakEnabled { get; set; } = false;

        #endregion

        #region Clan Tweaks - Custom Spawns Parties Tweak

        [SettingPropertyBool("{=BT_Settings_003207}Custom Spawn Parties Limit", Order = 1, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_003207_Desc}Changes the base number of parties Custom Spawn lords can field."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits" + "*/" + "{=BT_Settings_003207}Custom Spawns Parties Limit", GroupOrder = 3)]
        public bool AICustomSpawnPartiesLimitTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_003208}Add to Custom Spawn Parties Limit", 1, 10, "0 Extra Parties", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_003208_Desc}This adds to the the base number of parties Custom Lords can field. [Native is 1 for Tier 3 and below, 2 at T4, 3 at T5 and up.]."), SettingPropertyGroup("{=BT_Settings_003000}Clan Tweaks" + "/" + "{=BT_Settings_003200}Party Limits" + "*/" + "{=BT_Settings_003207}Custom Spawns Parties Limit")]
        public int BaseAICustomSpawnPartiesLimit { get; set; } = 0;

        #endregion

        #endregion

        #region Crafting Tweaks #6

        #region Crafting Tweaks - Crafting Stamina Tweaks
        [SettingPropertyBool("{=BT_Settings_004100}Crafting Stamina"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_004100_Desc}Enables tweaks which affect crafting stamina."), SettingPropertyGroup("{=BT_Settings_004000}Crafting Tweaks"+"/"+ "{=BT_Settings_004100}Crafting Stamina"+"*", GroupOrder =1)]
        public bool CraftingStaminaTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_004101}Max Crafting Stamina", 100, 1000, "0 Stamina", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_004101_Desc}Native value is 400. Sets the maximum crafting stamina value."), SettingPropertyGroup("{=BT_Settings_004000}Crafting Tweaks" + "/" + "{=BT_Settings_004100}Crafting Stamina" + "*")]
        public int MaxCraftingStamina { get; set; } = 400;

        [SettingPropertyInteger("{=BT_Settings_004102}Crafting Stamina Gain", 0, 100, "0 Stamina/h", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_004102_Desc}Native value is 5. You gain this amount of crafting stamina per hour."), SettingPropertyGroup("{=BT_Settings_004000}Crafting Tweaks" + "/" + "{=BT_Settings_004100}Crafting Stamina" + "*")]
        public int CraftingStaminaGainAmount { get; set; } = 5;

        [SettingPropertyFloatingInteger("{=BT_Settings_004103}Crafting Stamina Gain Outside Settlement", 0f, 1f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_004103_Desc}Native value is 0%. In % of Crafting Stamina Gain. In native, you do not gain crafting stamina if you are not resting inside a settlement."), SettingPropertyGroup("{=BT_Settings_004000}Crafting Tweaks" + "/" + "{=BT_Settings_004100}Crafting Stamina" + "*")]
        public float CraftingStaminaGainOutsideSettlementMultiplier { get; set; } = 0f;

        [SettingPropertyBool("{=BT_Settings_004104}Ignore Crafting Stamina", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_004104_Desc}Native value is false. This disables crafting stamina completely. You will still lose crafting stamina when you craft, but you will still be able to craft when you hit zero."), SettingPropertyGroup("{=BT_Settings_004000}Crafting Tweaks" + "/" + "{=BT_Settings_004100}Crafting Stamina" + "*")]
        public bool IgnoreCraftingStamina { get; set; } = false;


        #endregion

        #region Crafting Tweaks - Smelting

        [SettingPropertyBool("{=BT_Settings_004200}Smelting"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_004200_Desc}Enables tweaks which affect smelting of weapons."), SettingPropertyGroup("{=BT_Settings_004000}Crafting Tweaks" + "/" + "{=BT_Settings_004200}Smelting"+"*", GroupOrder =2)]
        public bool SmeltingTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_004201}Hide Locked Weapons in Smelting Menu", Order = 1, RequireRestart = false, HintText = "{=BT_Settings_004201_Desc}Native value is false. Prevent weapons that you have locked in your inventory from showing up in the smelting list to prevent accidental smelting."), SettingPropertyGroup("{=BT_Settings_004000}Crafting Tweaks" + "/" + "{=BT_Settings_004200}Smelting" + "*")]
        public bool PreventSmeltingLockedItems { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_004202}Enable Unlocking Parts From Smelted Weapons", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_004202_Desc}Native value is false. Unlock the parts that a weapon is made of when you smelt it."), SettingPropertyGroup("{=BT_Settings_004000}Crafting Tweaks" + "/" + "{=BT_Settings_004200}Smelting" + "*")]
        public bool AutoLearnSmeltedParts { get; set; } = false;

        #endregion

        #endregion

        #region Kingdom Tweaks #7

        #region Kingdom Tweaks - Lord Bartering

        [SettingPropertyBool("{=BT_Settings_005100}Lord Bartering"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_005100_Desc}Enables tweaks which affect bartering (Marriage, Factions Joining You, etc.)"), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks"+"/"+ "{=BT_Settings_005100}Lord Bartering"+"*", GroupOrder =1)]
        public bool BarterablesTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_005101}Faction Joining Barter Adjustment", 0.01f, 2f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_005101_Desc}Adjust the % cost of swaying a faction to join your kingdom. Native value is 100% (no change)."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005100}Lord Bartering" + "*")]
        public float BarterablesJoinKingdomAsClanAdjustment { get; set; } = 1;

        [SettingPropertyBool("{=BT_Settings_005102}Relationship favored Faction Joining Barter", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_005102_Desc}An alternate formula for calculating cost of swaying a faction to join your kingdom, with more emphasis on relationsip. [The higher your relationship to the lord, the cheaper the barter]."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005100}Lord Bartering" + "*")]
        public bool BarterablesJoinKingdomAsClanAltFormulaEnabled { get; set; } = false;

        #endregion

        #region Kingdom Tweaks - Balancing Tweaks

        [SettingPropertyBool("{=BT_Settings_005200}Faction Balancing"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_005200_Desc}Enables tweaks which affect the balancing of kingdoms."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing"+"*", GroupOrder =2)]
        public bool KingdomBalanceStrengthEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms", Order = 2, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_005201_Desc}Enables tweaks which affect the balancing of kingdoms in vanilla game."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms", GroupOrder = 1)]
        public bool KingdomBalanceStrengthVanEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_005202}Vlandia Balancing Strength", -0.5f, 0.5f, "0%", Order = 9, RequireRestart = false, HintText = "{=BT_Settings_005202_Desc}Balancing strength for vlandia. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float VlandiaBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005203}Sturgia Balancing Strength", -0.5f, 0.5f, "0%", Order = 8, RequireRestart = false, HintText = "{=BT_Settings_005203_Desc}Balancing strength for sturgia. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float SturgiaBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005204}Battania Balancing Strength", -0.5f, 0.5f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_005204_Desc}Balancing strength for battania. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float BattaniaBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005205}Northern Empire Balancing Strength", -0.5f, 0.5f, "0%", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_005205_Desc}Balancing strength for northern empire. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float Empire_N_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005206}Southern Empire Balancing Strength", -0.5f, 0.5f, "0%", Order = 6, RequireRestart = false, HintText = "{=BT_Settings_005206_Desc}Balancing strength for southern empire. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float Empire_S_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005207}Western Empire Balancing Strength", -0.5f, 0.5f, "0%", Order = 7, RequireRestart = false, HintText = "{=BT_Settings_005207_Desc}Balancing strength for western empire. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float Empire_W_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005208}Aserai Balancing Strength", -0.5f, 0.5f, "0%", Order = 1, RequireRestart = false, HintText = "{=BT_Settings_005208_Desc}Balancing strength for aserai. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float AseraiBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005209}Khuzait Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005209_Desc}Balancing strength for khuzait. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float KhuzaitBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005210}Player Kingdom Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005210_Desc}Balancing strength for player kingdom. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005201}Balancing Modifiers For Vanilla Kingdoms")]
        public float PlayerBoost { get; set; } = 0.00f;



        [SettingPropertyBool("{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms", Order = 3, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_005211_Desc}Enables tweaks which affect the balancing of kingdoms in the mod Calradia Expanded Kingdoms."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms", GroupOrder = 2)]
        public bool KingdomBalanceStrengthCEKEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_005212}Nordlings Balancing Strength", -0.5f, 0.5f, "0%", Order = 9, RequireRestart = false, HintText = "{=BT_Settings_005212_Desc}Balancing strength for nordlings. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float NordlingsBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005213}Vagir Balancing Strength", -0.5f, 0.5f, "0%", Order = 8, RequireRestart = false, HintText = "{=BT_Settings_005213_Desc}Balancing strength for vagir. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float VagirBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005214}Royalist Vlandia Balancing Strength", -0.5f, 0.5f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_005214_Desc}Balancing strength for royalist vlandia. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float RoyalistVlandiaBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005215}Apolssaly Balancing Strength", -0.5f, 0.5f, "0%", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_005215_Desc}Balancing strength for apolssaly. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float ApolssalyBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005216}Lyrion Balancing Strength", -0.5f, 0.5f, "0%", Order = 6, RequireRestart = false, HintText = "{=BT_Settings_005216_Desc}Balancing strength for lyrion. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float LyrionBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005217}Khergit Balancing Strength", -0.5f, 0.5f, "0%", Order = 7, RequireRestart = false, HintText = "{=BT_Settings_005217_Desc}Balancing strength for khergit. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float RebelKhuzaitBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005218}Paleician Balancing Strength", -0.5f, 0.5f, "0%", Order = 1, RequireRestart = false, HintText = "{=BT_Settings_005218_Desc}Balancing strength for paleician. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float PaleicianBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005219}Ariorum Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005219_Desc}Balancing strength for ariorum. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float AriorumBoost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005220}Calradian Empire Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005220_Desc}Balancing strength for calradian empire. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Empire_S_CEK_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005221}Dryatican Republic Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005221_Desc}Balancing strength for dryatican republic. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Empire_CEK_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005222}Battania Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005222_Desc}Balancing strength for battania. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Battania_CEK_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005223}Cortanian Vlandia Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005223_Desc}Balancing strength for cortanian vlandia. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Vlandia_CEK_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005224}Sturgia Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005224_Desc}Balancing strength for sturgia. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Sturgia_CEK_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005225}Khuzait Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005225_Desc}Balancing strength for khuzait. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Khuzait_CEK_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005226}Aserai Balancing Strength", -0.5f, 0.5f, "0%", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005226_Desc}Balancing strength for aserai. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Aserai_CEK_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005227}Western Empire Balancing Strength", -0.5f, 0.5f, "0%", Order = 7, RequireRestart = false, HintText = "{=BT_Settings_005227_Desc}Balancing strength for western empire. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Empire_W_CEK_Boost { get; set; } = 0.00f;

        [SettingPropertyFloatingInteger("{=BT_Settings_005228}Player Kingdom Balancing Strength", -0.5f, 0.5f, "0%", Order = 7, RequireRestart = false, HintText = "{=BT_Settings_005228_Desc}Balancing strength for player kingdom. Boosts or reduces the enabled balancing tweaks."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*/" + "{=BT_Settings_005211}Balancing Modifiers For Calradia Expanded Kingdoms")]
        public float Player_CEK_Boost { get; set; } = 0.00f;




        [SettingPropertyBool("{=BT_Settings_005229}Party Sizes Balancing", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_005229_Desc}Modifier for max party sizes (1.0 x Balancing Strength)."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*")]
        public bool BalancingPartySizeTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_005230}Party Count Limit Balancing", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_005230_Desc}Modifier for max party limit (1.0 x Balancing Strength)."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*")]
        public bool BalancingPartyLimitTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_005231}Village Food Production Balancing", Order = 6, RequireRestart = false, HintText = "{=BT_Settings_005231_Desc}Modifier for daily production of food goods in villages (1.0 x Balancing Strength)."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*")]
        public bool BalancingFoodTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_005232}Faster Recruitment Balancing", Order = 7, RequireRestart = false, HintText = "{=BT_Settings_005232_Desc}Flat % bonus chance of new recruits to spawn in settlements (0.75 x Balancing Strength)."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*")]
        public bool BalancingTimeRecruitsTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_005233}Taxation Efficiency Balancing", Order = 8, RequireRestart = false, HintText = "{=BT_Settings_005233_Desc}Modifier for tax income from prosperity in towns and castles and trade tax income in villages (1.25 x Balancing Strength)."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*")]
        public bool BalancingTaxTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_005234}Wage costs Balancing", Order = 9, RequireRestart = false, HintText = "{=BT_Settings_005234_Desc}Modifier for troop and garrison wages (1.0 x Balancing Strength)."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*")]
        public bool BalancingWagesTweaksEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_005235}Quality of Recruitment Balancing", Order = 10, RequireRestart = false, HintText = "{=BT_Settings_005235_Desc}Increases the chance for upgraded recruits (1.0 x Balancing Strength). No effect if balancing strength is lower than 0% (no decrease in chance for upgrades)."), SettingPropertyGroup("{=BT_Settings_005000}Kingdom Tweaks" + "/" + "{=BT_Settings_005200}Faction Balancing" + "*")]
        public bool BalancingUpgradeTroopsTweaksEnabled { get; set; } = false;

        #endregion

        #endregion

        #region Party Tweaks #8

        #region Party Tweaks - Cohesion Tweaks

        [SettingPropertyBool("{=BT_Settings_006100}Cohesion Tweaks"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_006100_Desc}Enables tweaks affecting cohesion."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks"+"/"+ "{=BT_Settings_006100}Cohesion Tweaks"+"*", GroupOrder =1)]
        public bool BTCohesionTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_006101}Cohesion Degradation Factor", 0f, 1f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_006101_Desc}Modifier to how much cohesion should degrade over time. Vanilla is 100%, 0% is disabled."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006100}Cohesion Tweaks" + "*")]
        public float BTCohesionTweakv2 { get; set; } = 1f;

        [SettingPropertyBool("{=BT_Settings_006102}All-Clan Armies Lose No Cohesion", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_006102_Desc}Armies composed of only clan parties lose no cohesion."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006100}Cohesion Tweaks" + "*")]
        public bool ClanArmyLosesNoCohesionEnabled { get; set; } = false;

        #endregion

        #region Party Tweaks - Caravan Tweaks

        [SettingPropertyBool("{=BT_Settings_006200}Player Caravan Party Size"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_006200_Desc}Applies a configured value to your caravan party size."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006200}Player Caravan Party Size"+"*", GroupOrder =2)]
        public bool PlayerCaravanPartySizeTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_006201}Player Caravan Party Size Amount", 30, 100, "0 Troops", Order = 2, HintText = "{=BT_Settings_006201_Desc}Native: 30. Be aware that bigger parties are also slower parties."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006200}Player Caravan Party Size" + "*")]
        public int PlayerCaravanPartySize { get; set; } = 30;

        #endregion

        #region Party Tweaks - Party Size Tweaks

        [SettingPropertyBool("{=BT_Settings_006300}Party Size"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_006300_Desc}Applies a bonues to you and AI lord's party size based on leadership and steward skills."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006300}Party Size"+"*", GroupOrder =3)]
        public bool PartySizeTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_006301}Leadership Bonus", Order = 2, IsToggle = true, RequireRestart = false, HintText = "{=BT_Settings_006301_Desc}Applies a bonus equal to the set percentage of your leadership skill to your party size."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006300}Party Size" + "*/" + "{=BT_Settings_006301}Leadership Bonus", GroupOrder =1)]
        public bool LeadershipPartySizeBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_006302}Leadership Bonus Player", 0f, 2f, "0%", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_006302_Desc}Applies a bonus equal to the set percentage of your leadership skill to your party size."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006300}Party Size" + "*/" + "{=BT_Settings_006301}Leadership Bonus")]
        public float LeadershipPartySizeBonus { get; set; } = 0.0f;

        [SettingPropertyBool("{=BT_Settings_006303}Steward Bonus", Order = 4, IsToggle = true, RequireRestart = false, HintText = "{=BT_Settings_006303_Desc}Applies a bonus equal to the set percentage of your steward skill to your party size."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006300}Party Size" + "*/" + "{=BT_Settings_006303}Steward Bonus", GroupOrder =2)]
        public bool StewardPartySizeBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_006304}Steward Bonus Player", 0f, 2f, "0%", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_006304_Desc}Applies a bonus equal to the set percentage of your steward skill to your party size."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006300}Party Size" + "*/" + "{=BT_Settings_006303}Steward Bonus")]
        public float StewardPartySizeBonus { get; set; } = 0f;

        [SettingPropertyFloatingInteger("{=BT_Settings_006305}Party Size Relation Player-AI", 0f, 2f, "0%", Order = 6, RequireRestart = false, HintText = "{=BT_Settings_006305_Desc}The percentage of the party size bonus set for the player to also apply for ai lords. 0% results in no bonus for ai. You may also want to increase food production amounts (Village Production, bigger demand)."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006300}Party Size" + "*")]
        public float PartySizeTweakAIFactor { get; set; } = 0f;

        #endregion

        #region Party Tweaks - Party Wage Tweaks

        [SettingPropertyBool("{=BT_Settings_006400}Wages"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_006400_Desc}Allows you to reduce/increase wages for various groups."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006400}Wages"+"*", GroupOrder =4)]
        public bool PartyWageTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_006401}Party Wage Adjustment", .05f, 5f, "0%",  Order = 2, RequireRestart = false, HintText = "{=BT_Settings_006401_Desc}Adjusts party wages to a % of native value. Native is 100%."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006400}Wages" + "*")]
        public float PartyWagePercent { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=BT_Settings_006402}Garrison Wage Adjustment", .05f, 5f, "0%",  Order = 3, RequireRestart = false, HintText = "{=BT_Settings_006402_Desc}Adjusts garrison wages to a % of native value. Native is 100%."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006400}Wages" + "*")]
        public float GarrisonWagePercent { get; set; } = 1.0f;

        [SettingPropertyBool("{=BT_Settings_006403}Also Apply Wage Tweaks to Your Faction", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_006403_Desc}Applies the wage modifiers to your clan/faction parties as well."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006400}Wages" + "*")]
        public bool ApplyWageTweakToFaction { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_006404}Also Apply Wage Tweaks to AI Lords", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_006404_Desc}Applies the wage modifiers to ai lord parties as well."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006400}Wages" + "*")]
        public bool ApplyWageTweakToAI { get; set; } = false;

        #endregion

        #region Party Tweaks - Troop Daily Experience Tweak

        [SettingPropertyBool("{=BT_Settings_006500}Daily Troop Experience"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_006500_Desc}Gives each troop roster (stack) in a party an amount of experience each day based upon the leader's Leadership skill. By default only applies to the player."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006500}Daily Troop Experience" + "*", GroupOrder =5)]
        public bool DailyTroopExperienceTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_006501}Percentage of Leadership", 0.0f, 50f, "0%",  Order = 2, RequireRestart = false, HintText = "{=BT_Settings_006501_Desc}The percentage of the leader's Leadership skill to be given as experience to each of their troop rosters. With 100 leadership and a setting of 1000% each troop type stack will get 1.000 xp daily."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006500}Daily Troop Experience" + "*")]
        public float LeadershipPercentageForDailyExperienceGain { get; set; } = 0f;

        [SettingPropertyInteger("{=BT_Settings_006502}Starting from Level Of Leadership", 1, 200, Order = 3, RequireRestart = false, HintText = "{=BT_Settings_006502_Desc}The Leadership level required to start giving experience to troop rosters. With this setting at 20, daily training of your troop stacks will start from leadership 20 onwards (but be calculated with the full 20 skillpoints)."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006500}Daily Troop Experience" + "*")]
        public int DailyTroopExperienceRequiredLeadershipLevel { get; set; } = 30;

        [SettingPropertyBool("{=BT_Settings_006503}Apply to Player's Clan Members", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_006503_Desc}Applies the daily troop experience gain to members of the player's clan also."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006500}Daily Troop Experience" + "*")]
        public bool DailyTroopExperienceApplyToPlayerClanMembers { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_006504}Apply to all NPC Lords", Order = 5, RequireRestart = false, HintText = "{=BT_Settings_006504_Desc}Applies the daily troop experience gain to all NPC lords."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006500}Daily Troop Experience" + "*")]
        public bool DailyTroopExperienceApplyToAllNPC { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_006505}Display Message", Order = 6, RequireRestart = false, HintText = "{=BT_Settings_006505_Desc}Displays a message showing the amount of experience granted."), SettingPropertyGroup("{=BT_Settings_006000}Party Tweaks" + "/" + "{=BT_Settings_006500}Daily Troop Experience" + "*")]
        public bool DisplayMessageDailyExperienceGain { get; set; } = false;

        #endregion

        #endregion

        #region Prisoner Tweaks #9

        #region Imprisonmewnt Time Tweaks

        [SettingPropertyBool("{=BT_Settings_007100}Imprisonment Time"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_007100_Desc}Adds a minimum amount of time before lords can attempt to escape imprisonment."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007100}Imprisonment Time"+"*", GroupOrder =1)]
        public bool PrisonerImprisonmentTweakEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_007101}Player Prisoners Only", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_007101_Desc}Whether the tweak should be applied only to prisoners held by the player."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007100}Imprisonment Time" + "*")]
        public bool PrisonerImprisonmentPlayerOnly { get; set; } = true;

        [SettingPropertyInteger("{=BT_Settings_007102}Minimum Days of Imprisonment", 0, 180, "0 Days",  Order = 3, RequireRestart = false, HintText = "{=BT_Settings_007102_Desc}The minimum number of days a lord will remain imprisoned before they can attempt to escape."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007100}Imprisonment Time" + "*")]
        public int MinimumDaysOfImprisonment { get; set; } = 0;

        [SettingPropertyBool("{=BT_Settings_007103}Enable Missing Prisoner Hero Fix"+"*", Order = 4, RequireRestart = true, HintText = "{=BT_Settings_007103_Desc}Will attempt to detect and release prisoner Heroes who may be bugged and do not respawn. Will trigger 3 days after the Minimum Days of Imprisonment setting."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007100}Imprisonment Time" + "*")]
        public bool EnableMissingHeroFix { get; set; } = false;

        #endregion

        #region Prisoner Size Tweak

        [SettingPropertyBool("{=BT_Settings_007200}Prisoner Size Bonus" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_007200_Desc}Enables a % bonus to your party's maximum prisoner size."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007200}Prisoner Size Bonus"+"*", GroupOrder =2)]
        public bool PrisonerSizeTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_007201}Prisoner Size Bonus", 0f, 5f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_007201_Desc}Adds a % bonues to your party's maximum prisoner size. Native is 0%."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007200}Prisoner Size Bonus" + "*")]
        public float PrisonerSizeTweakPercent { get; set; } = 0;

        [SettingPropertyBool("{=BT_Settings_007202}Also apply to AI", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_007202_Desc}Wether the prisoner size bonus should apply to AI Lords."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007200}Prisoner Size Bonus" + "*")]
        public bool PrisonerSizeTweakAI { get; set; } = false;

        #endregion

        #region Prisoner Confirmity Tweaks

        [SettingPropertyBool("{=BT_Settings_007300}Prisoner Confirmity" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_007300_Desc}Modifies the conformity rate of the base game, speeding the rate at which prisoners can be recruited."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007300}Prisoner Confirmity"+"*", GroupOrder =3)]
        public bool PrisonerConformityTweaksEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_007301}Prisoner Confirmity Bonus", 0f, 10f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_007301_Desc}Adds a % bonues to the conformity generated each hour. Native is 0%."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007300}Prisoner Confirmity"+"*")]
        public float PrisonerConformityTweakBonus { get; set; } = 0;

        [SettingPropertyBool("{=BT_Settings_007302}Apply Prisoner Confirmity Tweaks to Clan", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_007302_Desc}Applies Prisoner Conformity Tweaks to all clan parties as well."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007300}Prisoner Confirmity" + "*")]
        public bool PrisonerConformityTweaksApplyToClan { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_007303}Apply Prisoner Confirmity Tweaks to AI", Order = 4, RequireRestart = false, HintText = "{=BT_Settings_007303_Desc}Applies Prisoner Conformity Tweaks to all parties, including AI lords as well."), SettingPropertyGroup("{=BT_Settings_007000}Prisoner Tweaks" + "/" + "{=BT_Settings_007300}Prisoner Confirmity" + "*")]
        public bool PrisonerConformityTweaksApplyToAi { get; set; } = false;

        #endregion

        #endregion

        #region Settlement Tweaks #10

        #region Settlement Tweaks - Settlement culture

        [SettingPropertyBool("{=BT_Settings_008100}Settlement Culture Transformation"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008100_Desc}Changes the culture of settlement in relation to the owner clan. On deactivation cultures revert back. The last town of a culture will not be changed!"), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks"+"/"+ "{=BT_Settings_008100}Settlement Culture Transformation"+"*", GroupOrder =1)]
        public bool EnableCultureChanger { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_008101}Change To Culture Of Kingdom Faction Instead"+"*", Order = 1, RequireRestart = true, IsToggle = false, HintText = "{=BT_Settings_008101_Desc}Instead of changing the culture to its owner-clan culture, change to its kingdom culture."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008100}Settlement Culture Transformation" + "*")]
        public bool ChangeToKingdomCulture { get; set; } = false;

        [SettingPropertyDropdown("{=BT_Settings_008102}Override Culture For Player Clan"+"*", Order = 3, RequireRestart = true, HintText = "{=BT_Settings_008102_Desc}Overrides the culture to change to for player clan owned settlements."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008100}Settlement Culture Transformation" + "*")]
        public DropdownDefault<string> PlayerCultureOverride { get; } = new(new string[]
        {
            "No Override",
            "battania",
            "vlandia",
            "empire",
            "sturgia",
            "aserai",
            "khuzait",
            "CALRADIA EXPANDED KINGDOMS ONLY:",
            "nordling",
            "vagir",
            "rhodok",
            "apolssalian",
            "lyrion",
            "khergit",
            "paleician",
            "republic",
            "ariorum"

        }, 0);

        [SettingPropertyInteger("{=BT_Settings_008103}Days for Settlement Culture Change", 1,365, "0 Days", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_008103_Desc}After how many days the culture of a settlement changes to its owner's culture (and produces recruits of the new culturegroup)."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008100}Settlement Culture Transformation" + "*")]
        public int TimeToChanceCulture { get; set; } = 30;

        #endregion


        #region Settlement Tweaks - Disable Troop Donations

        [SettingPropertyBool("{=BT_Settings_008200}Disable Troop Donations"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008200_Desc}Disables your clan parties from donating troops to clan owned settlements."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008200}Disable Troop Donations"+"*", GroupOrder =2)]
        public bool DisableTroopDonationPatchEnabled { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_008201}Disable Troop Donations - Any Settlement", Order = 1, RequireRestart = false, HintText = "{=BT_Settings_008201_Desc}Additionally disables your clan parties from donating troops to ANY settlement."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008200}Disable Troop Donations" + "*")]
        public bool DisableTroopDonationAnyEnabled { get; set; } = false;

        #endregion

        #region Settlement Tweaks - Production Tweaks

        [SettingPropertyBool("{=BT_Settings_008300}Village Productivity"+"*", Order = 1, IsToggle = true, RequireRestart = true, HintText = "{=BT_Settings_008300_Desc}Enables Tweaks for increased productivity in villages."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008300}Village Productivity"+"*", GroupOrder =3)]
        public bool ProductionTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_008301}Village Production: Food", 1f, 3f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_008301_Desc}Modifies the daily production of food goods in villages."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008300}Village Productivity"+"*")]
        public float ProductionFoodTweakEnabled { get; set; } = 1f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008302}Village Production: Other goods", 1f, 3f, "0%", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_008302_Desc}Modifies the daily production of other goods in villages."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008300}Village Productivity" + "*")]
        public float ProductionOtherTweakEnabled { get; set; } = 1f;

        #endregion Settlement Tweaks - Disable Troop Donations

        #region Settlement Tweaks - Buildings

        #region Settlement Tweaks - Buildings - Castle

        #region Settlement Tweaks - Buildings - Castle - Training Fields

        [SettingPropertyBool("{=BT_Settings_008402}Castle Training Field"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008402_Desc}Changes the amount of experience the training fields provides for each level."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings"+"/"+ "{=BT_Settings_008401}Castle"+"/"+ "{=BT_Settings_008402}Castle Training Field"+"*", GroupOrder =1)]
        public bool CastleTrainingFieldsBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008403}Castle Training Fields Experience Level 1"+"*", 1, 100, RequireRestart = true, Order = 2, HintText = "{=BT_Settings_008403_Desc}Native value is 1. Changes the amount of experience the training fields provides at level 1."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008402}Castle Training Field" + "*")]
        public int CastleTrainingFieldsXpAmountLevel1 { get; set; } = 1;

        [SettingPropertyInteger("{=BT_Settings_008404}Castle Training Fields Experience Level 2"+"*", 2, 200, RequireRestart = true, Order = 3, HintText = "{=BT_Settings_008404_Desc}Native value is 2. Changes the amount of experience the training fields provides at level 2."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008402}Castle Training Field" + "*")]
        public int CastleTrainingFieldsXpAmountLevel2 { get; set; } = 2;

        [SettingPropertyInteger("{=BT_Settings_008405}Castle Training Fields Experience Level 3"+"*", 3, 300, RequireRestart = true, Order = 4, HintText = "{=BT_Settings_008405_Desc}Native value is 3. Changes the amount of experience the training fields provides at level 3."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008402}Castle Training Field" + "*")]
        public int CastleTrainingFieldsXpAmountLevel3 { get; set; } = 3;

        #endregion

        #region Settlement Tweaks - Buildings - Castle - Granary 

        [SettingPropertyBool("{=BT_Settings_008406}Castle Granary"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008406_Desc}Changes the amount of food storage the castle granary provides per level."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008406}Castle Granary"+"*", GroupOrder =2)]
        public bool CastleGranaryBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008407}Castle Granary Food Storage Level 1"+"*", 100, 1000, RequireRestart = true, Order = 2, HintText = "{=BT_Settings_008407_Desc}Native value is 100. Changes the amount of food storage the castle granary provides at level 1."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008406}Castle Granary" + "*")]
        public int CastleGranaryStorageAmountLevel1 { get; set; } = 100;

        [SettingPropertyInteger("{=BT_Settings_008408}Castle Granary Food Storage Level 2"+"*", 200, 2000, RequireRestart = true, Order = 3, HintText = "{=BT_Settings_008408_Desc}Native value is 200. Changes the amount of food storage the castle granary provides at level 2."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008406}Castle Granary" + "*")]
        public int CastleGranaryStorageAmountLevel2 { get; set; } = 200;

        [SettingPropertyInteger("{=BT_Settings_008409}Castle Granary Food Storage Level 3"+"*", 300, 3000, RequireRestart = true, Order = 4, HintText = "{=BT_Settings_008409_Desc}Native value is 300. Changes the amount of food storage the castle granary provides at level 3."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008406}Castle Granary" + "*")]
        public int CastleGranaryStorageAmountLevel3 { get; set; } = 300;

        #endregion

        #region Settlement Tweaks - Buildings - Castle - Gardens

        [SettingPropertyBool("{=BT_Settings_008410}Castle Gardens"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008410_Desc}Changes the amount of food the castle gardens produce per level."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008410}Castle Gardens"+"*", GroupOrder =3)]
        public bool CastleGardensBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008411}Castle Garden Food Production Level 1"+"*", 5, 50, RequireRestart = true, Order = 2, HintText = "{=BT_Settings_008411_Desc}Native value is 5. Changes the amount of food the castle gardens produce at level 1."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008410}Castle Gardens" + "*")]
        public int CastleGardensFoodProductionAmountLevel1 { get; set; } = 5;

        [SettingPropertyInteger("{=BT_Settings_008412}Castle Garden Food Production Level 2"+"*", 10, 100, RequireRestart = true, Order = 3, HintText = "{=BT_Settings_008412_Desc}Native value is 10. Changes the amount of food the castle gardens produce at level 2."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008410}Castle Gardens" + "*")]
        public int CastleGardensFoodProductionAmountLevel2 { get; set; } = 10;

        [SettingPropertyInteger("{=BT_Settings_008413}Castle Garden Food Production Level 3"+"*", 15, 150, RequireRestart = true, Order = 4, HintText = "{=BT_Settings_008413_Desc}Native value is 15. Changes the amount of food the castle gardens produce at level 3."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008410}Castle Gardens" + "*")]
        public int CastleGardensFoodProductionAmountLevel3 { get; set; } = 15;

        #endregion

        #region Settlement Tweaks - Buildings - Castle - Militia Barracks

        [SettingPropertyBool("{=BT_Settings_008414}Castle Militia Barracks"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008414_Desc}Changes the militia production that the castle militia barracks provides per level."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008414}Castle Militia Barracks"+"*", GroupOrder =4)]
        public bool CastleMilitiaBarracksBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008415}Castle Militia Barracks Production Level 1"+"*", 1, 10, RequireRestart = true, Order = 2, HintText = "{=BT_Settings_008415_Desc}Native value is 1. Changes the militia production that the castle militia barracks provides at level 1."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008414}Castle Militia Barracks" + "*")]
        public int CastleMilitiaBarracksAmountLevel1 { get; set; } = 1;

        [SettingPropertyInteger("{=BT_Settings_008416}Castle Militia Barracks Production Level 2"+"*", 2, 20, RequireRestart = true, Order = 3, HintText = "{=BT_Settings_008416_Desc}Native value is 2. Changes the militia production that the castle militia barracks provides at level 2."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008414}Castle Militia Barracks" + "*")]
        public int CastleMilitiaBarracksAmountLevel2 { get; set; } = 2;

        [SettingPropertyInteger("{=BT_Settings_008417}Castle Militia Barracks Production Level 3"+"*", 3, 30, RequireRestart = true, Order = 4, HintText = "{=BT_Settings_008417_Desc}Native value is 3. Changes the militia production that the castle militia barracks provides at level 3."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008401}Castle" + "/" + "{=BT_Settings_008414}Castle Militia Barracks" + "*")]
        public int CastleMilitiaBarracksAmountLevel3 { get; set; } = 3;

        #endregion

        #endregion

        #region Settlement Tweaks - Buildings - Town 

        #region Settlement Tweaks - Buildings - Town - Training Fields

        [SettingPropertyBool("{=BT_Settings_008419}Town Training Fields"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008419_Desc}Changes the amount of experience the training fields provides for each level."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town"+"/"+ "{=BT_Settings_008419}Town Training Fields"+"*", GroupOrder =1)]
        public bool TownTrainingFieldsBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008420}Town Training Fields Experience Level 1"+"*", 30, 300, RequireRestart = true, Order = 2, HintText = "{=BT_Settings_008420_Desc}Native value is 30. Changes the amount of experience the training fields provides at level 1."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008419}Town Training Fields" + "*")]
        public int TownTrainingFieldsXpAmountLevel1 { get; set; } = 30;

        [SettingPropertyInteger("{=BT_Settings_008421}Town Training Fields Experience Level 2"+"*", 60, 600, RequireRestart = true, Order = 3, HintText = "{=BT_Settings_008421_Desc}Native value is 60. Changes the amount of experience the training fields provides at level 2."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008419}Town Training Fields" + "*")]
        public int TownTrainingFieldsXpAmountLevel2 { get; set; } = 60;

        [SettingPropertyInteger("{=BT_Settings_008422}Town Training Fields Experience Level 3"+"*", 100, 1000, RequireRestart = true, Order = 4, HintText = "{=BT_Settings_008422_Desc}Native value is 100. Changes the amount of experience the training fields provides at level 3."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008419}Town Training Fields" + "*")]
        public int TownTrainingFieldsXpAmountLevel3 { get; set; } = 100;

        #endregion

        #region Settlement Tweaks - Buildings - Town - Granary

        [SettingPropertyBool("{=BT_Settings_008423}Town Granary"+"*", RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008423_Desc}Changes the amount of food storage the town granary provides per level."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008423}Town Granary"+"*", GroupOrder =2)]
        public bool TownGranaryBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008424}Town Granary Food Storage Level 1"+"*", 200, 2000, RequireRestart = true, Order = 1, HintText = "{=BT_Settings_008424_Desc}Native value is 200. Changes the amount of food storage the town granary provides at level 1."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008423}Town Granary" + "*")]
        public int TownGranaryStorageAmountLevel1 { get; set; } = 200;

        [SettingPropertyInteger("{=BT_Settings_008425}Town Granary Food Storage Level 2"+"*", 400, 4000, RequireRestart = true, Order = 2, HintText = "{=BT_Settings_008425_Desc}Native value is 400. Changes the amount of food storage the town granary provides at level 2."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008423}Town Granary" + "*")]
        public int TownGranaryStorageAmountLevel2 { get; set; } = 400;

        [SettingPropertyInteger("{=BT_Settings_008426}Town Granary Food Storage Level 3"+"*", 600, 6000, RequireRestart = true, Order = 3, HintText = "{=BT_Settings_008426_Desc}Native value is 600. Changes the amount of food storage the town granary provides at level 3."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008423}Town Granary" + "*")]
        public int TownGranaryStorageAmountLevel3 { get; set; } = 600;

        #endregion

        #region Settlement Tweaks - Settlement Buildings Tweaks - Town Buildings Tweaks - Orchards Tweak

        [SettingPropertyBool("{=BT_Settings_008427}Town Orchards"+"*", Order = 1, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_008427_Desc}Changes the amount of food the town orchards produce per level."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008427}Town Orchards"+"*", GroupOrder =3)]
        public bool TownOrchardsBonusEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008428}Town Orchard Food Production Level 1"+"*", 10, 100, RequireRestart = true, Order = 2, HintText = "{=BT_Settings_008428_Desc}Native value is 10. Changes the amount of food the town orchards produce at level 1."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008427}Town Orchards" + "*")]
        public int TownOrchardsFoodProductionAmountLevel1 { get; set; } = 10;

        [SettingPropertyInteger("{=BT_Settings_008429}Town Orchard Food Production Level 2"+"*", 20, 200, RequireRestart = true, Order = 3, HintText = "{=BT_Settings_008429_Desc}Native value is 20. Changes the amount of food the town orchards produce at level 2."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008427}Town Orchards" + "*")]
        public int TownOrchardsFoodProductionAmountLevel2 { get; set; } = 20;

        [SettingPropertyInteger("{=BT_Settings_008430}Town Orchard Food Production Level 3"+"*", 30, 300, RequireRestart = true, Order = 4, HintText = "{=BT_Settings_008430_Desc}Native value is 30. Changes the amount of food the town orchards produce at level 3."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008427}Town Orchards" + "*")]
        public int TownOrchardsFoodProductionAmountLevel3 { get; set; } = 30;

        #endregion

        #region Settlement Tweaks - Settlement Buildings Tweaks - Town Buildings Tweaks - Militia Barracks Tweak

        [SettingPropertyBool("{=BT_Settings_008431}Town Militia Barracks"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008431_Desc}Changes the militia production that the town militia barracks provides per level."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008431}Town Militia Barracks"+"*", GroupOrder =4)]
        public bool TownMilitiaBarracksBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_008432}Town Militia Barracks Production Level 1"+"*", .5f, 15, RequireRestart = true, Order = 2, HintText = "{=BT_Settings_008432_Desc}Native value is .5. Changes the militia production that the town militia barracks provides at level 1."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008431}Town Militia Barracks" + "*")]
        public float TownMilitiaBarracksAmountLevel1 { get; set; } = 0.5f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008433}Town Militia Barracks Production Level 2"+"*", 1f, 20f, RequireRestart = true, Order = 3, HintText = "{=BT_Settings_008433_Desc}Native value is 1. Changes the militia production that the town militia barracks provides at level 2."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008431}Town Militia Barracks" + "*")]
        public float TownMilitiaBarracksAmountLevel2 { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008434}Town Militia Barracks Production Level 3"+"*", 1.5f, 30f, RequireRestart = true, Order = 4, HintText = "{=BT_Settings_008434_Desc}Native value is 1.5. Changes the militia production that the town militia barracks provides at level 3."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008400}Buildings" + "/" + "{=BT_Settings_008418}Town" + "/" + "{=BT_Settings_008431}Town Militia Barracks" + "*")]
        public float TownMilitiaBarracksAmountLevel3 { get; set; } = 1.5f;

        #endregion

        #endregion

        #endregion

        #region Settlement Tweaks - Settlement Food

        [SettingPropertyBool("{=BT_Settings_008500}Settlement Food" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008500_Desc}Enables tweaks which provide bonuses to food production in towns and castles."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008500}Settlement Food"+"*", GroupOrder =4)]
        public bool SettlementFoodBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_008501}Castle Food Modifier", 1f, 10f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_008501_Desc}Native value is 100%. Adds a modifier to food production in castles."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008500}Settlement Food" + "*")]
        public float CastleFoodBonus { get; set; } = 0f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008502}Town Food Modifier", 1f, 10f, "0%", Order = 3, RequireRestart = false, HintText = "{=BT_Settings_008502_Desc}Native value is 100%. Adds a modifier to food production in towns."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008500}Settlement Food" + "*")]
        public float TownFoodBonus { get; set; } = 0f;

        #region Settlement Tweaks - Settlement Food Bonus - Food Loss from Prosperity Tweak

        [SettingPropertyBool("{=BT_Settings_008503}Food Loss From Prosperity", Order = 1, RequireRestart = false, IsToggle = true, HintText = "{=BT_Settings_008503_Desc}Allows you to adjust the loss to food production received from settlement prosperity."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008500}Settlement Food" + "*/"+ "{=BT_Settings_008503}Food Loss from Prosperity", GroupOrder =1)]
        public bool SettlementProsperityFoodMalusTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008504}Prosperity Food Loss Divisor", 50, 400, RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008504_Desc}Native value is 50. The prosperity of the settlement is divided by this value to calculate the loss. Increasing this value will decrease the amount of food lost."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008500}Settlement Food" + "*/" + "{=BT_Settings_008503}Food Loss from Prosperity")]
        public int SettlementProsperityFoodMalusDivisor { get; set; } = 50;

        #endregion

        #endregion

        #region Settlement Tweaks - Militia

        [SettingPropertyBool("{=BT_Settings_008600}Militia" + "*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008600_Desc}Grants a flat bonus to militia growth and rate of retirement in towns and castles."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008600}Militia"+"*", GroupOrder =5)]
        public bool SettlementMilitiaBonusEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_008601}Castle Militia Growth Bonus", 0f, 50f, "0.0 Militia/Day",  RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008601_Desc}Native value is 0. Adds a flat bonus on how many militia gets recruited each day in castles."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008600}Militia" + "*")]
        public float CastleMilitiaBonusFlat { get; set; } = 0f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008602}Town Militia Growth Bonus", 0f, 50f, "0.0 Militia/Day",  RequireRestart = false, Order = 3, HintText = "{=BT_Settings_008602_Desc}Native value is 0. Adds a flat bonus on how many militia gets recruited each day in towns."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008600}Militia" + "*")]
        public float TownMilitiaBonusFlat { get; set; } = 0f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008603}Castle Militia Retirement Modifier", 0f, 0.25f, "0.0%/Day", RequireRestart = false, Order = 3, HintText = "{=BT_Settings_008603_Desc}Native value is 2.5%. Modifies the percentage of your militia retiring each dayin castles."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008600}Militia" + "*")]
        public float CastleMilitiaRetirementModifier { get; set; } = 0.025f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008604}Town Militia Retirement Modifier", 0f, 0.25f, "0.0%/Day", RequireRestart = false, Order = 3, HintText = "{=BT_Settings_008604_Desc}Native value is 2.5%. Modifies the percentage of your militia retiring each dayin town."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008600}Militia" + "*")]
        public float TownMilitiaRetirementModifier { get; set; } = 0.025f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008605}Melee Militia Spawn Ratio", 0.01f, 1f, "0%", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008605_Desc}Native value is 50%. Sets the chance that the militia spawning in towns and castles are of melee type. Remaining difference to 100% determines ranged spawn ratio."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008600}Militia" + "*")]
        public float SettlementMeleeSpawnRate { get; set; } = 0.5f;

        [SettingPropertyFloatingInteger("{=BT_Settings_008606}Bonus Elite Militia Chance", 0.01f, 1f, "0%", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008606_Desc}Native value is 0%. Sets the bonus chance that the militia spawning in towns and castles are of elite type."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008600}Militia" + "*")]
        public float SettlementEliteSpawnChanceBonus { get; set; } = 0.0f;

        #endregion

        #region Settlement Tweaks - Tournaments

        #region Settlement Tweaks - Tournaments - Renown Reward

        [SettingPropertyBool("{=BT_Settings_008801}Renown Reward"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008801_Desc}Sets the amount of renown awarded when you win a tournament."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments"+"/"+ "{=BT_Settings_008801}Renown Reward"+"*", GroupOrder =1)]
        public bool TournamentRenownIncreaseEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008802}Tournament Renown Reward", 1, 50, "0 Renown", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008802_Desc}Native value is 3. Increases the amount of renown awarded when you win a tournament."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008801}Renown Reward" + "*")]
        public int TournamentRenownAmount { get; set; } = 3;

        #endregion

        #region Settlement Tweaks - Tournaments - Gold Reward

        [SettingPropertyBool("{=BT_Settings_008803}Gold Reward"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008803_Desc}Adds the set amount of gold to the rewards when you win a tournament."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008803}Gold Reward"+"*", GroupOrder =2)]
        public bool TournamentGoldRewardEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008804}Tournament Gold Reward", 0, 5000, "0 Denar", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008804_Desc}Native value is 0. Adds the set amount of gold to the rewards when you win a tournament."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008803}Gold Reward" + "*")]
        public int TournamentGoldRewardAmount { get; set; } = 0;

        #endregion

        #region Settlement Tweaks - Tournaments - Maximum Bet

        [SettingPropertyBool("{=BT_Settings_008805}Maximum Bet"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008805_Desc}Sets the maximum amount of gold that you can bet per round in tournaments."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008805}Maximum Bet"+"*", GroupOrder =3)]
        public bool TournamentMaxBetAmountTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008806}Maximum Bet Amount", 0, 4000, "0 Denar", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008806_Desc}Native value is 150. Sets the maximum amount of gold that you can bet per round in tournaments."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008805}Maximum Bet" + "*")]
        public int TournamentMaxBetAmount { get; set; } = 150;

        #endregion

        #region Settlement Tweaks - Tournaments - Hero Experience

        [SettingPropertyBool("{=BT_Settings_008807}Hero Experience Modifier"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008807_Desc}Overrides the native multiplier value for experience gain in tournaments for hero characters."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008807}Hero Experience Modifier"+"*", GroupOrder =4)]
        public bool TournamentHeroExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_008808}Tournament Hero Experience Modifier", 0.33f, 10f, "0%", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008808_Desc}Native value is 33%. Sets the modifier applied to experience gained in tournaments by hero characters. 100% = full real-world experience."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008807}Hero Experience Modifier" + "*")]
        public float TournamentHeroExperienceMultiplier { get; set; } = 0.33f;

        #endregion

        #region Settlement Tweaks - Tournaments - Arena Hero Experience

        [SettingPropertyBool("{=BT_Settings_008809}Arena Hero Experience Modifier"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008809_Desc}Overrides the native multiplier value for experience gain in arena fights for hero characters."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008809}Arena Experience Modifier"+"*", GroupOrder =5)]
        public bool ArenaHeroExperienceMultiplierEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_008810}Arena Hero Experience Modifier", 0.06f, 5f, "0%", Order = 2, RequireRestart = false, HintText = "{=BT_Settings_008810_Desc}Native value is 6%. Sets the modifier applied to experience gain in arena fights for hero characters. 100% = full real-world experience."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008809}Arena Experience Modifier" + "*")]
        public float ArenaHeroExperienceMultiplier { get; set; } = 0.06f;

        #endregion

        #region Settlement Tweaks - Tournament Tweaks - Minimum Betting Odds

        [SettingPropertyBool("{=BT_Settings_008811}Minimum Betting Odds"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008811_Desc}Allows you to set the minimum betting odds in tournaments."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008811}Minimum Betting Odds"+"*", GroupOrder =6)]
        public bool MinimumBettingOddsTweakEnabled { get; set; } = false;

        [SettingPropertyFloatingInteger("{=BT_Settings_008812}Minimum Betting Odds", 1.1f, 10f, RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008812_Desc}Native: 1.1. The minimum odds for tournament bets, higher means more yield for your bets, if won."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008800}Tournaments" + "/" + "{=BT_Settings_008811}Minimum Betting Odds" + "*")]
        public float MinimumBettingOdds { get; set; } = 1.1f;

        #endregion

        #endregion

        #region Settlement Tweaks - Workshops

        #region Settlement Tweaks - Workshops - Workshop Limit

        [SettingPropertyBool("{=BT_Settings_008901}Workshop Count Limit"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008901_Desc}Sets the base maximum number of workshops you can have and the limit increase gained per clan tier."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops"+"/"+ "{=BT_Settings_008901}Workshop Count Limit"+"*", GroupOrder =1)]
        public bool MaxWorkshopCountTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008902}Base Workshop Count Limit", 0, 20, "0 Workshops", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008902_Desc}Native value is 1. Sets the base maximum number of workshops you can have."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008901}Workshop Count Limit" + "*")]
        public int BaseWorkshopCount { get; set; } = 1;

        [SettingPropertyInteger("{=BT_Settings_008903}Bonus Workshops Per Clan Tier", 0, 5, "0 Shops/Tier", RequireRestart = false, Order = 3, HintText = "{=BT_Settings_008903_Desc}Native value is 1. Sets the base maximum number of workshops you can have and the limit increase gained per clan tier."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008901}Workshop Count Limit" + "*")]
        public int BonusWorkshopsPerClanTier { get; set; } = 1;

        #endregion

        #region Settlement Tweaks - Workshops - Workshop Cost Tweak

        [SettingPropertyBool("{=BT_Settings_008904}Workshop Buy Cost"+"*", Order = 1, RequireRestart = true, IsToggle = true, HintText = "{=BT_Settings_008904_Desc}Sets the base value used to calculate the cost of workshops. Reduce to reduce cost of workshops."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008904}Workshop Buy Cost"+"*", GroupOrder =2)]
        public bool WorkshopBuyingCostTweakEnabled { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_008905}Workshop Base Cost", 0, 15000, "0 Denar", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008905_Desc}Native value is 10,000. Sets the base value used to calculate the cost of workshops (+ workshop type base cost + 0.5 x town prosperity). Reduce to reduce cost of workshops."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008904}Workshop Buy Cost" + "*")]
        public int WorkshopBaseCost { get; set; } = 10000;

        #endregion

        #region Settlement Tweaks - Workshops - Workshop Effectivness

        [SettingPropertyBool("{=BT_Settings_008906}Workshop Effectivness"+"*", RequireRestart = true, IsToggle=true, Order = 2, HintText = "{=BT_Settings_008906_Desc}Increases effectivness of workshops by decreasing its daily expenses."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008906}Workshop Effectivness"+"*", GroupOrder =3)]
        public bool WorkshopEffectivnessEnabled { get; set; } = false;
        [SettingPropertyFloatingInteger("{=BT_Settings_008907}Workshop Daily Cost Modifier", 0f, 1f, "0%", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008907_Desc}Native value is 100%. Increases effectivness of workshops by decreasing its daily expenses."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008906}Workshop Effectivness" + "*")]
        public float WorkshopEffectivnessv2Factor { get; set; } = 1f;

        #endregion

        #region Settlement Tweaks - Workshops - Workshop SellPrices

        [SettingPropertyBool("{=BT_Settings_008908}Workshop Products Sell Prices" + "*", RequireRestart = true, IsToggle = true, Order = 2, HintText = "{=BT_Settings_008908_Desc}Alters the selling prices for products of workshops."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008908}Workshop Products Sell Prices" + "*", GroupOrder = 4)]
        public bool EnableWorkshopSellTweak { get; set; } = false;
        [SettingPropertyFloatingInteger("{=BT_Settings_008909}Workshop Products Sell Prices", 0.01f, 5f, "0%", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008909_Desc}Native value is 100%. Alters the selling prices for products of workshops. Increase for better profits."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008908}Workshop Products Sell Prices" + "*")]
        public float WorkshopSellTweak { get; set; } = 1f;

        #endregion

        #region Settlement Tweaks - Workshops - Workshop Buy Prices

        [SettingPropertyBool("{=BT_Settings_008910}Workshop Products Buy Prices" + "*", RequireRestart = true, IsToggle = true, Order = 2, HintText = "{=BT_Settings_008910_Desc}Alters the buying prices for input items of workshops."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008910}Workshop Products Buy Prices" + "*", GroupOrder = 5)]
        public bool EnableWorkshopBuyTweak { get; set; } = false;
        [SettingPropertyFloatingInteger("{=BT_Settings_008911}Workshop Products Buy Prices", 0.01f, 5f, "0%", RequireRestart = false, Order = 2, HintText = "{=BT_Settings_008911_Desc}Native value is 100%. Alters the buying prices for input items of workshops. Decrease for better profits."), SettingPropertyGroup("{=BT_Settings_008000}Settlement Tweaks" + "/" + "{=BT_Settings_008900}Workshops" + "/" + "{=BT_Settings_008910}Workshop Products Buy Prices" + "*")]
        public float WorkshopBuyTweak { get; set; } = 1f;

        #endregion

        #endregion

        #endregion

        #region Miscellaneous #11

        [SettingPropertyBool("{=BT_Settings_009001}Disable Quest Troops Affecting Morale"+"*", Order = 1, RequireRestart = true, HintText = "{=BT_Settings_009001_Desc}When enabled, quest troops such as Borrowed Troop in your party are ignored when party morale is calculated."), SettingPropertyGroup("{=BT_Settings_009000}Misc", GroupOrder =99)]
        public bool QuestCharactersIgnorePartySize { get; set; } = false;

        [SettingPropertyBool("{=BT_Settings_009002}Show Number of Days of Food"+"*", Order = 2, RequireRestart = true, HintText = "{=BT_Settings_009002_Desc}Changes the number showing how much food you have to instead show how many days' worth of food you have. (Bottom right of campaign map UI)."), SettingPropertyGroup("{=BT_Settings_009000}Misc")]
        public bool ShowFoodDaysRemaining { get; set; } = false;

        [SettingPropertyInteger("{=BT_Settings_009003}Campaign Speed Fast Forward", 2, 32, Order = 3, RequireRestart = false, HintText = "{=BT_Settings_009003_Desc}Sets the campaign speed in fast forward mode. Vanilla is 4."), SettingPropertyGroup("{=BT_Settings_009000}Misc")]
        public int CampaignSpeed { get; set; } = 4;

        /* Disable in 1.5.7.2 until we understand changes to the main quest.
        [SettingPropertyBool("Enable Auto-Extension of the 'Stop the Conspiracy' Quest", RequireRestart = false, HintText = "Automatically extends the timer of the 'Stop the Conspiracy' quest as TW hasn't finished it yet.")]
        public bool TweakedConspiracyQuestTimerEnabled { get; set; } = true;
        */
        #endregion

        public override IDictionary<string, Func<BaseSettings>> GetAvailablePresets()
        {
            var basePresets = base.GetAvailablePresets();
            basePresets.Add("Restore defaults from 1.5.7.2", () => new BannerlordTweaksSettings()
            {
                #region Preset Restore defaults from 1.5.7.2
                QuestCharactersIgnorePartySize = false,
                ShowFoodDaysRemaining= false,
                MinimumDaysOfImprisonment= 10,
                PrisonerImprisonmentTweakEnabled= false,
                PrisonerImprisonmentPlayerOnly= true,
                EnableMissingHeroFix= true,
                PrisonerSizeTweakEnabled= false,
                PrisonerSizeTweakPercent= 0f,
                PrisonerConformityTweaksApplyToAi= false,
                PrisonerConformityTweaksApplyToClan= false,
                PrisonerConformityTweaksEnabled= false,
                PrisonerConformityTweakBonus= 0f,
                CastleMilitiaBonusFlat= 1.25f,
                TownMilitiaBonusFlat= 2.5f,
                SettlementMilitiaBonusEnabled= false,
                CastleFoodBonus= 2.0f,
                TownFoodBonus= 4.0f,
                SettlementFoodBonusEnabled= true,
                SettlementProsperityFoodMalusDivisor= 100,
                SettlementProsperityFoodMalusTweakEnabled= true,
                DisableTroopDonationPatchEnabled= false,
                DisableTroopDonationAnyEnabled = false,
                BaseWorkshopCount= 2,
                BonusWorkshopsPerClanTier= 1,
                MaxWorkshopCountTweakEnabled= true,
                WorkshopBaseCost= 10000,
                WorkshopBuyingCostTweakEnabled= false,
                TournamentHeroExperienceMultiplier= 0.25f,
                TournamentHeroExperienceMultiplierEnabled= false,
                TournamentRenownAmount= 3,
                TournamentRenownIncreaseEnabled= true,
                MinimumBettingOdds= 1.1f,
                MinimumBettingOddsTweakEnabled= false,
                TournamentMaxBetAmount= 500,
                TournamentMaxBetAmountTweakEnabled= true,
                TournamentGoldRewardAmount= 500,
                TournamentGoldRewardEnabled= true,
                ArenaHeroExperienceMultiplier= 0.06f,
                ArenaHeroExperienceMultiplierEnabled= false,
                TownTrainingFieldsXpAmountLevel1= 30,
                TownTrainingFieldsXpAmountLevel2= 60,
                TownTrainingFieldsXpAmountLevel3= 100,
                TownTrainingFieldsBonusEnabled= true,
                TownOrchardsFoodProductionAmountLevel1= 10,
                TownOrchardsFoodProductionAmountLevel2= 20,
                TownOrchardsFoodProductionAmountLevel3= 30,
                TownOrchardsBonusEnabled= true,
                TownMilitiaBarracksAmountLevel1= 0.5f,
                TownMilitiaBarracksAmountLevel2= 1.0f,
                TownMilitiaBarracksAmountLevel3= 1.5f,
                TownMilitiaBarracksBonusEnabled= true,
                TownGranaryStorageAmountLevel1= 200,
                TownGranaryStorageAmountLevel2= 400,
                TownGranaryStorageAmountLevel3= 600,
                TownGranaryBonusEnabled= true,
                CastleTrainingFieldsXpAmountLevel1= 1,
                CastleTrainingFieldsXpAmountLevel2= 2,
                CastleTrainingFieldsXpAmountLevel3= 3,
                CastleTrainingFieldsBonusEnabled= true,
                CastleMilitiaBarracksAmountLevel1= 1,
                CastleMilitiaBarracksAmountLevel2= 2,
                CastleMilitiaBarracksAmountLevel3= 3,
                CastleMilitiaBarracksBonusEnabled= true,
                CastleGranaryStorageAmountLevel1= 100,
                CastleGranaryStorageAmountLevel2= 200,
                CastleGranaryStorageAmountLevel3= 300,
                CastleGranaryBonusEnabled= true,
                CastleGardensFoodProductionAmountLevel1= 5,
                CastleGardensFoodProductionAmountLevel2= 10,
                CastleGardensFoodProductionAmountLevel3= 15,
                CastleGardensBonusEnabled= true,
                ApplyWageTweakToFaction= false,
                PartyWageTweaksEnabled= false,
                PartyWagePercent= 1.0f,
                GarrisonWagePercent= 1.0f,
                LeadershipPercentageForDailyExperienceGain= 0.5f,
                DailyTroopExperienceRequiredLeadershipLevel= 30,
                DailyTroopExperienceApplyToPlayerClanMembers= false,
                DailyTroopExperienceApplyToAllNPC= false,
                DisplayMessageDailyExperienceGain= false,
                DailyTroopExperienceTweakEnabled= false,
                LeadershipPartySizeBonus= 0.3f,
                StewardPartySizeBonus= 0.3f,
                LeadershipPartySizeBonusEnabled= true,
                PartySizeTweakEnabled= true,
                StewardPartySizeBonusEnabled= true,
                PlayerCaravanPartySize= 30,
                PlayerCaravanPartySizeTweakEnabled= false,
                ClanArmyLosesNoCohesionEnabled= false,
                BarterablesTweaksEnabled= true,
                BarterablesJoinKingdomAsClanAdjustment= 100,
                BarterablesJoinKingdomAsClanAltFormulaEnabled= false,
                AutoLearnSmeltedParts= true,
                PreventSmeltingLockedItems= false,
                CraftingStaminaGainAmount= 10,
                CraftingStaminaGainOutsideSettlementMultiplier= 1.0f,
                MaxCraftingStamina= 400,
                CraftingStaminaTweakEnabled= true,
                IgnoreCraftingStamina= false,
                CompanionBaseLimit= 3,
                CompanionLimitBonusPerClanTier= 3,
                CompanionLimitTweakEnabled= false,
                UnlimitedWanderersPatch= false,
                BaseClanPartiesLimit= 1,
                ClanPartiesBonusPerClanTier= 0.5f,
                ClanPartiesLimitTweakEnabled= false,
                BaseAICustomSpawnPartiesLimit= 1,
                AICustomSpawnPartiesLimitTweakEnabled= false,
                BaseAIClanPartiesLimit= 1,
                AIMinorClanPartiesLimitTweakEnabled= false,
                AIClanPartiesLimitTweakEnabled= false,
                NoMaternalMortalityTweakEnabled= false,
                NoStillbirthsTweakEnabled= false,
                TwinsProbability= 0.03f,
                TwinsProbabilityTweakEnabled= false,
                PregnancyDuration= 36,
                PregnancyDurationTweakEnabled= false,
                MaxPregnancyAge= 45,
                MinPregnancyAge= 18,
                DailyChancePregnancyTweakEnabled= false,
                PlayerCharacterInfertileEnabled= false,
                MaxChildren= 5,
                ClanFertilityBonus= 1.1f,
                FemaleOffspringProbability= 0.51f,
                FemaleOffspringProbabilityTweakEnabled= false,
                CompanionSkillExperienceMultiplier= 1.0f,
                HeroSkillExperienceMultiplier= 1.0f,
                CompanionSkillExperienceMultiplierEnabled= false,
                HeroSkillExperienceMultiplierEnabled= false,
                SkillExperienceMultipliersEnabled= false,
                SkillBonusEngineering= 1.0f,
                SkillBonusLeadership= 1.0f,
                SkillBonusMedicine= 1.0f,
                SkillBonusRiding= 1.0f,
                SkillBonusRoguery= 1.0f,
                SkillBonusScouting= 1.0f,
                SkillBonusTrade= 1.0f,
                PerSkillBonusEnabled= false,
                FocusPointsPerLevel= 1,
                AttributePointRequiredLevel= 4,
                AttributeFocusPointTweakEnabled= false,
                AgeTweaksEnabled= false,
                BecomeChildAge= 6,
                BecomeInfantAge= 3,
                BecomeTeenagerAge= 14,
                HeroComesOfAge= 18,
                BecomeOldAge= 47,
                MaxAge= 125,
                DifficultyTweakEnabled= false,
                PlayerMapMovementSpeedBonusMultiplier= 0.0f,
                PlayerMapMovementSpeedBonusTweakEnabled= false,
                DamageToTroopsMultiplier= 1.0f,
                DamageToTroopsTweakEnabled= false,
                DamageToPlayerMultiplier= 1.0f,
                DamageToPlayerTweakEnabled= false,
                CombatAIDifficultyMultiplier= 0.96f,
                CombatAIDifficultyTweakEnabled= false,
                BattleSize= 1000,
                BattleSizeTweakEnabled= false,
                SingleHandedWeaponsSliceThroughEnabled= false,
                TwoHandedWeaponsSliceThroughEnabled= false,
                TroopBattleExperienceMultiplier= 1.0f,
                TroopBattleExperienceMultiplierEnabled= false,
                TroopBattleSimulationExperienceMultiplier= 1.0f,
                TroopBattleSimulationExperienceMultiplierEnabled= false,
                SiegeTweaksEnabled= false,
                SiegeConstructionProgressPerDayMultiplier= 0.8f,
                SiegeCollateralDamageCasualties= 1,
                SiegeDestructionCasualties= 0,
                HideoutBattleTroopLimit= 90,
                ContinueHideoutBattleOnPlayerLoseDuel= true,
                ContinueHideoutBattleOnPlayerDeath= false,
                HideoutBattleTroopLimitTweakEnabled= true,
                BattleInfluenceMultiplier= 1.0f,
                BattleRenownMultiplier= 2.0f,
                BattleRewardApplyToAI= true,
                BattleRewardTweaksEnabled= true
                #endregion
            });
            basePresets.Add("Everything enabled with vanilla values", () => new BannerlordTweaksSettings()
            {
                  #region Preset Everything enabled with vanilla values
                  QuestCharactersIgnorePartySize= true,
                  ShowFoodDaysRemaining= true,
                  CampaignSpeed= 4,
                  SettlementMeleeSpawnRate= 0.5f,
                  SettlementEliteSpawnChanceBonus= 0.0f,
                  SettlementMilitiaBonusEnabled= true,
                  CastleMilitiaBonusFlat= 0.0f,
                  CastleMilitiaRetirementModifier= 0.025f,
                  TownMilitiaBonusFlat= 0.0f,
                  TownMilitiaRetirementModifier= 0.025f,
                  SettlementFoodBonusEnabled= true,
                  CastleFoodBonus= 1.0f,
                  TownFoodBonus= 1.0f,
                  SettlementProsperityFoodMalusTweakEnabled= true,
                  SettlementProsperityFoodMalusDivisor= 50,
                  ProductionTweakEnabled= true,
                  ProductionFoodTweakEnabled= 1.0f,
                  ProductionOtherTweakEnabled= 1.0f,
                  DisableTroopDonationAnyEnabled= true,
                  DisableTroopDonationPatchEnabled= true,
                  ChangeToKingdomCulture= true,
                  EnableCultureChanger= true,
                  TimeToChanceCulture= 30,
                  PlayerCultureOverride = {"No Override"},
                  WorkshopBuyTweak= 1.0f,
                  EnableWorkshopBuyTweak= true,
                  WorkshopSellTweak= 1.0f,
                  EnableWorkshopSellTweak= true,
                  WorkshopEffectivnessv2Factor= 1.0f,
                  WorkshopEffectivnessEnabled= true,
                  WorkshopBuyingCostTweakEnabled= true,
                  WorkshopBaseCost= 10000,
                  MaxWorkshopCountTweakEnabled= true,
                  BaseWorkshopCount= 1,
                  BonusWorkshopsPerClanTier= 1,
                  MinimumBettingOddsTweakEnabled= true,
                  MinimumBettingOdds= 1.1f,
                  ArenaHeroExperienceMultiplierEnabled= true,
                  ArenaHeroExperienceMultiplier= 0.06f,
                  TournamentHeroExperienceMultiplierEnabled= true,
                  TournamentHeroExperienceMultiplier= 0.33f,
                  TournamentMaxBetAmountTweakEnabled= true,
                  TournamentMaxBetAmount= 150,
                  TournamentGoldRewardEnabled= true,
                  TournamentGoldRewardAmount= 0,
                  TournamentRenownIncreaseEnabled= true,
                  TournamentRenownAmount= 3,
                  TownMilitiaBarracksBonusEnabled= true,
                  TownMilitiaBarracksAmountLevel1= 0.5f,
                  TownMilitiaBarracksAmountLevel2= 1.0f,
                  TownMilitiaBarracksAmountLevel3= 1.5f,
                  TownOrchardsBonusEnabled= true,
                  TownOrchardsFoodProductionAmountLevel1= 10,
                  TownOrchardsFoodProductionAmountLevel2= 20,
                  TownOrchardsFoodProductionAmountLevel3= 30,
                  TownGranaryBonusEnabled= true,
                  TownGranaryStorageAmountLevel1= 200,
                  TownGranaryStorageAmountLevel2= 400,
                  TownGranaryStorageAmountLevel3= 600,
                  TownTrainingFieldsBonusEnabled= true,
                  TownTrainingFieldsXpAmountLevel1= 30,
                  TownTrainingFieldsXpAmountLevel2= 60,
                  TownTrainingFieldsXpAmountLevel3= 100,
                  CastleMilitiaBarracksBonusEnabled= true,
                  CastleMilitiaBarracksAmountLevel1= 1,
                  CastleMilitiaBarracksAmountLevel2= 2,
                  CastleMilitiaBarracksAmountLevel3= 3,
                  CastleGardensBonusEnabled= true,
                  CastleGardensFoodProductionAmountLevel1= 5,
                  CastleGardensFoodProductionAmountLevel2= 10,
                  CastleGardensFoodProductionAmountLevel3= 15,
                  CastleGranaryBonusEnabled= true,
                  CastleGranaryStorageAmountLevel1= 100,
                  CastleGranaryStorageAmountLevel2= 200,
                  CastleGranaryStorageAmountLevel3= 300,
                  CastleTrainingFieldsBonusEnabled= true,
                  CastleTrainingFieldsXpAmountLevel1= 1,
                  CastleTrainingFieldsXpAmountLevel2= 2,
                  CastleTrainingFieldsXpAmountLevel3= 3,
                  PrisonerConformityTweaksEnabled= true,
                  PrisonerConformityTweakBonus= 0.0f,
                  PrisonerConformityTweaksApplyToClan= true,
                  PrisonerConformityTweaksApplyToAi= true,
                  PrisonerSizeTweakEnabled= true,
                  PrisonerSizeTweakAI= true,
                  PrisonerSizeTweakPercent= 0.0f,
                  PrisonerImprisonmentTweakEnabled= true,
                  PrisonerImprisonmentPlayerOnly= false,
                  MinimumDaysOfImprisonment= 0,
                  EnableMissingHeroFix= true,
                  DailyTroopExperienceTweakEnabled= true,
                  LeadershipPercentageForDailyExperienceGain= 0.01f,
                  DailyTroopExperienceRequiredLeadershipLevel= 30,
                  DailyTroopExperienceApplyToPlayerClanMembers= true,
                  DailyTroopExperienceApplyToAllNPC= true,
                  DisplayMessageDailyExperienceGain= true,
                  PartyWageTweaksEnabled= true,
                  PartyWagePercent= 1.0f,
                  GarrisonWagePercent= 1.0f,
                  ApplyWageTweakToFaction= true,
                  ApplyWageTweakToAI= true,
                  PartySizeTweakEnabled= true,
                  PartySizeTweakAIFactor= 0.0f,
                  StewardPartySizeBonusEnabled= true,
                  StewardPartySizeBonus= 0.0f,
                  LeadershipPartySizeBonusEnabled= true,
                  LeadershipPartySizeBonus= 0.0f,
                  PlayerCaravanPartySizeTweakEnabled= true,
                  PlayerCaravanPartySize= 30,
                  BTCohesionTweakEnabled= true,
                  BTCohesionTweakv2= 1.0f,
                  ClanArmyLosesNoCohesionEnabled= true,
                  KingdomBalanceStrengthEnabled= true,
                  BalancingPartySizeTweaksEnabled= true,
                  BalancingPartyLimitTweaksEnabled= true,
                  BalancingFoodTweakEnabled= true,
                  BalancingTimeRecruitsTweaksEnabled= true,
                  BalancingTaxTweaksEnabled= true,
                  BalancingWagesTweaksEnabled= true,
                  BalancingUpgradeTroopsTweaksEnabled= true,
                  PaleicianBoost= 0.0f,
                  RoyalistVlandiaBoost= 0.0f,
                  KingdomBalanceStrengthCEKEnabled= false,
                  AriorumBoost= 0.0f,
                  Aserai_CEK_Boost= 0.0f,
                  Battania_CEK_Boost= 0.0f,
                  Empire_S_CEK_Boost= 0.0f,
                  Vlandia_CEK_Boost= 0.0f,
                  Empire_CEK_Boost= 0.0f,
                  Khuzait_CEK_Boost= 0.0f,
                  Sturgia_CEK_Boost= 0.0f,
                  ApolssalyBoost= 0.0f,
                  LyrionBoost= 0.0f,
                  RebelKhuzaitBoost= 0.0f,
                  Player_CEK_Boost= 0.0f,
                  Empire_W_CEK_Boost= 0.0f,
                  VagirBoost= 0.0f,
                  NordlingsBoost= 0.0f,
                  AseraiBoost= 0.0f,
                  KingdomBalanceStrengthVanEnabled= true,
                  BattaniaBoost= 0.0f,
                  KhuzaitBoost= 0.0f,
                  PlayerBoost= 0.0f,
                  Empire_N_Boost= 0.0f,
                  Empire_S_Boost= 0.0f,
                  Empire_W_Boost= 0.0f,
                  SturgiaBoost= 0.0f,
                  VlandiaBoost= 0.0f,
                  BarterablesTweaksEnabled= true,
                  BarterablesJoinKingdomAsClanAdjustment= 1.0f,
                  BarterablesJoinKingdomAsClanAltFormulaEnabled= true,
                  PreventSmeltingLockedItems= true,
                  SmeltingTweakEnabled= true,
                  AutoLearnSmeltedParts= true,
                  CraftingStaminaTweakEnabled= true,
                  MaxCraftingStamina= 400,
                  CraftingStaminaGainAmount= 5,
                  CraftingStaminaGainOutsideSettlementMultiplier= 0.0f,
                  IgnoreCraftingStamina= true,
                  PartiesLimitTweakEnabled= true,
                  AICustomSpawnPartiesLimitTweakEnabled= true,
                  BaseAICustomSpawnPartiesLimit= 1,
                  AIClanPartiesLimitTweakEnabled= true,
                  BaseAIClanPartiesLimit= 1,
                  AIMinorClanPartiesLimitTweakEnabled= true,
                  ClanPartiesLimitTweakEnabled= true,
                  BaseClanPartiesLimit= 1,
                  ClanPartiesBonusPerClanTier= 0.5f,
                  CompanionLimitTweakEnabled= true,
                  CompanionBaseLimit= 3,
                  CompanionLimitBonusPerClanTier= 1,
                  UnlimitedWanderersPatch= true,
                  PregnancyTweaksEnabled= true,
                  NoStillbirthsTweakEnabled= true,
                  NoMaternalMortalityTweakEnabled= true,
                  PlayerCharacterInfertileEnabled= false,
                  MinPregnancyAge= 18,
                  MaxPregnancyAge= 45,
                  ClanFertilityBonus= 1.0f,
                  MaxChildren= 5,
                  DailyChancePregnancyTweakEnabled= true,
                  TwinsProbability= 0.03f,
                  TwinsProbabilityTweakEnabled= true,
                  FemaleOffspringProbability= 0.51f,
                  FemaleOffspringProbabilityTweakEnabled= true,
                  PregnancyDuration= 36,
                  PregnancyDurationTweakEnabled= true,
                  SkillExperienceMultipliersEnabled= true,
                  SkillBonusEngineering= 1.0f,
                  SkillBonusLeadership= 1.0f,
                  SkillBonusMedicine= 1.0f,
                  SkillBonusRiding= 1.0f,
                  SkillBonusRoguery= 1.0f,
                  SkillBonusScouting= 1.0f,
                  SkillBonusSmithing= 1.0f,
                  SkillBonusTrade= 1.0f,
                  PerSkillBonusEnabled= true,
                  CompanionSkillExperienceMultiplier= 1.0f,
                  CompanionSkillExperienceMultiplierEnabled= true,
                  HeroSkillExperienceMultiplier= 1.0f,
                  HeroSkillExperienceMultiplierEnabled= true,
                  AttributeFocusPointTweakEnabled= true,
                  AttributePointRequiredLevel= 4,
                  FocusPointsPerLevel= 1,
                  AgeTweaksEnabled= true,
                  BecomeInfantAge= 3,
                  BecomeChildAge= 6,
                  BecomeTeenagerAge= 14,
                  HeroComesOfAge= 18,
                  BecomeOldAge= 47,
                  MaxAge= 125,
                  DifficultyTweakEnabled= true,
                  PlayerMapMovementSpeedBonusTweakEnabled= true,
                  PlayerMapMovementSpeedBonusMultiplier= 0.0f,
                  CombatAIDifficultyTweakEnabled= true,
                  CombatAIDifficultyMultiplier= 0.96f,
                  DamageToTroopsTweakEnabled= true,
                  DamageToTroopsMultiplier= 1.0f,
                  DamageToPlayerTweakEnabled= true,
                  DamageToPlayerMultiplier= 1.0f,
                  BattleSizeTweakEnabled= true,
                  BattleSize= 1000,
                  SliceThroughEnabled= true,
                  TwoHandedWeaponsSliceThroughEnabled= true,
                  SingleHandedWeaponsSliceThroughEnabled= true,
                  TroopExperienceTweakEnabled= true,
                  TroopBattleSimulationExperienceMultiplierEnabled= true,
                  TroopBattleSimulationExperienceMultiplier= 0.9f,
                  TroopBattleExperienceMultiplierEnabled= true,
                  TroopBattleExperienceMultiplier= 1.0f,
                  SiegeTweaksEnabled= true,
                  SiegeConstructionProgressPerDayMultiplier= 1.0f,
                  SiegeCollateralDamageCasualties= 0,
                  SiegeDestructionCasualties= 0,
                  HideoutBattleTroopLimitTweakEnabled= true,
                  HideoutBattleTroopLimit= 10,
                  ContinueHideoutBattleOnPlayerDeath= true,
                  ContinueHideoutBattleOnPlayerLoseDuel= true,
                  BattleRewardTweaksEnabled= true,
                  BattleRenownMultiplier= 1.0f,
                  BattleInfluenceMultiplier= 1.0f,
                  BattleMoraleMultiplier= 1.0f,
                  BattleRewardApplyToAI= true,
                  BattleRewardShowDebug= true
                #endregion
            });
            return basePresets;
        }
    }
  
}
