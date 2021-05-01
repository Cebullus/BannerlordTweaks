﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace BannerlordTweaks
{
	public class ChangeSettlementCulture : CampaignBehaviorBase
	{
		public override void RegisterEvents()
		{
			CampaignEvents.ClanChangedKingdom.AddNonSerializedListener(this, new Action<Clan, Kingdom, Kingdom, bool, bool>(this.OnClanChangedKingdom));
			CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, new Action<CampaignGameStarter>(this.OnGameLoaded));
			CampaignEvents.WeeklyTickSettlementEvent.AddNonSerializedListener(this, new Action<Settlement>(this.OnWeeklyTickSettlement));
			CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, new Action<CampaignGameStarter>(this.OnGameLoaded));
			CampaignEvents.OnSiegeAftermathAppliedEvent.AddNonSerializedListener(this, new Action<MobileParty, Settlement, SiegeAftermathCampaignBehavior.SiegeAftermath, Clan, Dictionary<MobileParty, float>>(this.OnSiegeAftermathApplied));
			CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener(this, new Action<Settlement, bool, Hero, Hero, Hero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail>(this.OnSettlementOwnerChanged));
		}

		private void OnGameLoaded(CampaignGameStarter obj)
		{
			Dictionary<Settlement, CultureObject> startingCultures = new();

			if (BannerlordTweaksSettings.Instance is { } settings)
			{
				OverrideCulture = null;
				foreach (CultureObject Culture in from kingdom in Campaign.Current.Kingdoms where settings.PlayerCultureOverride.SelectedValue == kingdom.Culture.StringId || (settings.PlayerCultureOverride.SelectedValue == "khergit" && kingdom.Culture.StringId == "rebkhu") select kingdom.Culture)
				{
					OverrideCulture = Culture;
					break;
				}
				if (OverrideCulture == null && settings.ChangeToKingdomCulture && Clan.PlayerClan.Kingdom != null)
				{
					OverrideCulture = Clan.PlayerClan.Kingdom.Culture;
				}
				else if (OverrideCulture == null)
				{
					OverrideCulture = Clan.PlayerClan.Culture;
				}
			}

			foreach (Settlement settlement in from settlement in Campaign.Current.Settlements where settlement.IsTown || settlement.IsCastle || settlement.IsVillage select settlement)
			{
				startingCultures.Add(settlement, settlement.Culture);
				if (BannerlordTweaksSettings.Instance is { } settings2)
				{
					bool PlayerOverride = settlement.OwnerClan == Clan.PlayerClan && OverrideCulture != settlement.Culture;
					bool KingdomOverride = settlement.OwnerClan != Clan.PlayerClan && settings2.ChangeToKingdomCulture && settlement.OwnerClan.Kingdom != null && settlement.OwnerClan.Kingdom.Culture != settlement.Culture;
					bool ClanCulture = settlement.OwnerClan != Clan.PlayerClan && (!settings2.ChangeToKingdomCulture || settlement.OwnerClan.Kingdom == null) && settlement.OwnerClan.Culture != settlement.Culture;

					if ((PlayerOverride || KingdomOverride || ClanCulture) && !WeekCounter.ContainsKey(settlement))
					{
						this.AddCounter(settlement);
					}
					else if ((PlayerOverride || KingdomOverride || ClanCulture) && this.IsSettlementDue(settlement))
					{
						this.Transform(settlement, false);
					}
				}
			}
			ChangeSettlementCulture.initialCultureDictionary = startingCultures;

				obj.AddGameMenuOption("village", "village_culture_changer", "Culture Transformation", new GameMenuOption.OnConditionDelegate(ChangeSettlementCulture.Game_menu_village_change_culture_on_condition), new GameMenuOption.OnConsequenceDelegate(ChangeSettlementCulture.Game_menu_change_culture_on_consequence), false, 5, false);
				obj.AddGameMenuOption("town", "town_culture_changer", "Culture Transformation", new GameMenuOption.OnConditionDelegate(ChangeSettlementCulture.Game_menu_town_change_culture_on_condition), new GameMenuOption.OnConsequenceDelegate(ChangeSettlementCulture.Game_menu_change_culture_on_consequence), false, 5, false);
				obj.AddGameMenuOption("castle", "castle_culture_changer", "Culture Transformation", new GameMenuOption.OnConditionDelegate(ChangeSettlementCulture.Game_menu_castle_change_culture_on_condition), new GameMenuOption.OnConsequenceDelegate(ChangeSettlementCulture.Game_menu_change_culture_on_consequence), false, 5, false);
		}

		private void OnSiegeAftermathApplied(MobileParty arg1, Settlement settlement, SiegeAftermathCampaignBehavior.SiegeAftermath arg3, Clan arg4, Dictionary<MobileParty, float> arg5)
		{
			this.AddCounter(settlement);
		}

		private void OnSettlementOwnerChanged(Settlement settlement, bool arg2, Hero arg3, Hero arg4, Hero arg5, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
		{

			if (detail != ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail.BySiege)
			{
				this.AddCounter(settlement);
			}
			else
			{
				settlement.Culture = ChangeSettlementCulture.initialCultureDictionary[settlement];
			}
		}

		private void OnClanChangedKingdom(Clan clan, Kingdom arg2, Kingdom arg3, bool arg4, bool arg5)
		{
			if (BannerlordTweaksSettings.Instance is { } settings && settings.ChangeToKingdomCulture)
			{
				if (clan == Clan.PlayerClan)
				{
					OverrideCulture = null;
					foreach (CultureObject Culture in from kingdom in Campaign.Current.Kingdoms where settings.PlayerCultureOverride.SelectedValue == kingdom.Culture.StringId || (settings.PlayerCultureOverride.SelectedValue == "khergit" && kingdom.Culture.StringId == "rebkhu") select kingdom.Culture)
					{
						OverrideCulture = Culture;
						break;
					}
					if (OverrideCulture == null && settings.ChangeToKingdomCulture && Clan.PlayerClan.Kingdom != null)
					{
						OverrideCulture = Clan.PlayerClan.Kingdom.Culture;
					}
					else if (OverrideCulture == null)
					{
						OverrideCulture = Clan.PlayerClan.Culture;
					}
					foreach (Settlement settlement in from settlement in clan.Settlements where settlement.IsTown || settlement.IsCastle || settlement.IsVillage select settlement)
					{
						if (settlement.Culture != OverrideCulture)
						{
							this.AddCounter(settlement);
						}
					}
				}

				if (clan != Clan.PlayerClan && clan.Kingdom == null || clan.Kingdom.Culture != clan.Culture)
				{
					foreach (Settlement settlement in from settlement in clan.Settlements where settlement.IsTown || settlement.IsCastle || settlement.IsVillage select settlement)
					{
						this.AddCounter(settlement);
					}
				}
			}
		}

		public void Transform(Settlement settlement, bool removeTroops)
		{

			if (BannerlordTweaksSettings.Instance is { } settings && settlement.OwnerClan == Clan.PlayerClan)
			{
				OverrideCulture = null;
				foreach (CultureObject Culture in from kingdom in Campaign.Current.Kingdoms where settings.PlayerCultureOverride.SelectedValue == kingdom.Culture.StringId || (settings.PlayerCultureOverride.SelectedValue == "khergit" && kingdom.Culture.StringId == "rebkhu") select kingdom.Culture)
				{
					OverrideCulture = Culture;
					break;
				}
				if (OverrideCulture == null && settings.ChangeToKingdomCulture && Clan.PlayerClan.Kingdom != null)
				{
					OverrideCulture = Clan.PlayerClan.Kingdom.Culture;
				}
				else if (OverrideCulture == null)
				{
					OverrideCulture = Clan.PlayerClan.Culture;
				}
			}
			if (settlement.IsVillage || settlement.IsCastle || settlement.IsTown)
			{
				if (BannerlordTweaksSettings.Instance is { } settings2)
				{
					bool PlayerOverride = settlement.OwnerClan == Clan.PlayerClan && OverrideCulture != settlement.Culture;
					bool KingdomOverride = settlement.OwnerClan != Clan.PlayerClan && settings2.ChangeToKingdomCulture && settlement.OwnerClan.Kingdom != null && settlement.OwnerClan.Kingdom.Culture != settlement.Culture;
					bool ClanCulture = settlement.OwnerClan != Clan.PlayerClan && (!settings2.ChangeToKingdomCulture || settlement.OwnerClan.Kingdom == null) && settlement.OwnerClan.Culture != settlement.Culture;

					if (PlayerOverride || KingdomOverride || ClanCulture)
					{
						CultureObject? newculture = (settlement.OwnerClan == Clan.PlayerClan) ? OverrideCulture : (settings2.ChangeToKingdomCulture && settlement.OwnerClan.Kingdom != null) ? settlement.OwnerClan.Kingdom.Culture : settlement.OwnerClan.Culture;
						if (newculture != null)
						{
							//dont switch last town of a culture to prevent bugs in vanilla
							int count = 0;
							if (settlement.IsTown)
							{
								foreach (Settlement Town in Campaign.Current.Settlements )
								{
									if (Town.IsTown && Town.Culture == settlement.Culture)
									{
										count++;
									}
								}
							}
							if (count != 1)
							{
								settlement.Culture = newculture;
								if (removeTroops)
								{
									ChangeSettlementCulture.RemoveTroopsfromNotable(settlement);
								}
								foreach (Village boundVillage in settlement.BoundVillages)
								{
									if (removeTroops)
									{
										Transform(boundVillage.Settlement, true);
									}
									else
									{
										Transform(boundVillage.Settlement, false);
									}
								}
							}
						}
					}
				}
			}
		}

		public static void RemoveTroopsfromNotable(Settlement settlement)
		{
			if ((settlement.IsTown || settlement.IsVillage) && settlement.Notables != null)
			{
				foreach (Hero notable in settlement.Notables)
				{
					if (notable.CanHaveRecruits)
					{
						for (int index = 0; index < 6; index++)
						{
							notable.VolunteerTypes[index] = null;
						}
					}
				}
			}
		}

		public void OnWeeklyTickSettlement(Settlement settlement)
		{
			if (WeekCounter.ContainsKey(settlement))
			{
				Dictionary<Settlement, int> dictionary = WeekCounter;
				dictionary[settlement]++;

				if (this.IsSettlementDue(settlement))
				{
					Transform(settlement, true);
				}
			}
		}

		public bool IsSettlementDue(Settlement settlement)
		{
			if (BannerlordTweaksSettings.Instance is { } settings && settings.TimeToChanceCulture > 0)
			{
				return WeekCounter[settlement] >= settings.TimeToChanceCulture;
			}
			else
			{
				return false;
			}
		}

		public void AddCounter(Settlement settlement)
		{
			if (settlement.IsVillage || settlement.IsCastle || settlement.IsTown)
			{
				if (WeekCounter.ContainsKey(settlement))
				{
					WeekCounter[settlement] = 0;
				}
				else
				{
					WeekCounter.Add(settlement, 0);
				}
			}
		}

		public override void SyncData(IDataStore dataStore)
		{
				dataStore.SyncData<Dictionary<Settlement, int>>("SettlementCultureTransformation", ref WeekCounter);
		}

		public static bool Game_menu_castle_change_culture_on_condition(MenuCallbackArgs args)
		{
			args.optionLeaveType = GameMenuOption.LeaveType.Manage;
			return Settlement.CurrentSettlement.IsCastle;
		}
		public static bool Game_menu_town_change_culture_on_condition(MenuCallbackArgs args)
		{
			args.optionLeaveType = GameMenuOption.LeaveType.Manage;
			return Settlement.CurrentSettlement.IsTown;
		}
		public static bool Game_menu_village_change_culture_on_condition(MenuCallbackArgs args)
		{
			args.optionLeaveType = GameMenuOption.LeaveType.Manage;
			return Settlement.CurrentSettlement.IsVillage;
		}

		public static void Game_menu_change_culture_on_consequence(MenuCallbackArgs args)
		{
			if (BannerlordTweaksSettings.Instance is { } settings)
			{
				bool PlayerOverride = Settlement.CurrentSettlement.OwnerClan == Clan.PlayerClan && OverrideCulture != Settlement.CurrentSettlement.Culture;
				bool KingdomOverride = Settlement.CurrentSettlement.OwnerClan != Clan.PlayerClan && settings.ChangeToKingdomCulture && Settlement.CurrentSettlement.OwnerClan.Kingdom != null && Settlement.CurrentSettlement.OwnerClan.Kingdom.Culture != Settlement.CurrentSettlement.Culture;
				bool ClanCulture = Settlement.CurrentSettlement.OwnerClan != Clan.PlayerClan && (!settings.ChangeToKingdomCulture || Settlement.CurrentSettlement.OwnerClan.Kingdom == null) && Settlement.CurrentSettlement.OwnerClan.Culture != Settlement.CurrentSettlement.Culture;

				if (!WeekCounter.ContainsKey(Settlement.CurrentSettlement))
				{
					InformationManager.DisplayMessage(new InformationMessage("The people in " + Settlement.CurrentSettlement.Name + " already appraise their owners culture."));
				}
				else if (PlayerOverride || KingdomOverride || ClanCulture)
				{
					InformationManager.DisplayMessage(new InformationMessage("The people in " + Settlement.CurrentSettlement.Name + " seem to adopt their owners culture in " + (settings.TimeToChanceCulture - (WeekCounter.ContainsKey(Settlement.CurrentSettlement) ? WeekCounter[Settlement.CurrentSettlement] : 0)) + " weeks."));
				}
				else
				{
					InformationManager.DisplayMessage(new InformationMessage("The people in " + Settlement.CurrentSettlement.Name + " already appraise their owners culture."));
				}
			}
		}


		private static Dictionary<Settlement, CultureObject> initialCultureDictionary = new ();
		public static Dictionary<Settlement, int> WeekCounter = new ();
		private static CultureObject? OverrideCulture = new();

	}
}


