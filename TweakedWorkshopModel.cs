﻿using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordTweaks
{
    public class TweakedWorkshopModel : DefaultWorkshopModel
    {
        public override int GetMaxWorkshopCountForPlayer()
        {
            if (!Settings.Instance.MaxWorkshopCountTweakEnabled)
                return base.GetMaxWorkshopCountForPlayer();
            else
                return Settings.Instance.BaseWorkshopCount + Clan.PlayerClan.Tier * Settings.Instance.BonusWorkshopsPerClanTier;
        }

        public override int GetBuyingCostForPlayer(Workshop workshop)
        {
            if (workshop == null) throw new ArgumentNullException(nameof(workshop));
            if (Settings.Instance.WorkshopBuyingCostTweakEnabled)
                return workshop.WorkshopType.EquipmentCost + (int)workshop.Settlement.Prosperity / 2 + Settings.Instance.WorkshopBaseCost;
            else
                return base.GetBuyingCostForPlayer(workshop);
        }
    }
}
