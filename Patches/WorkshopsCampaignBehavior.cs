﻿using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;

namespace BannerlordTweaks.Patches
{

    [HarmonyPatch(typeof(WorkshopsCampaignBehavior), "ProduceOutput")]
    public class ProductionOutputPatch
    {

        private static bool Prefix(ItemObject outputItem, Town town, Workshop workshop, int count, bool doNotEffectCapital, out int __state)
        {
            if (Campaign.Current.GameStarted && !doNotEffectCapital)
            {
                __state = town.GetItemPrice(outputItem, null, false);
                return true;
            }
            else
            {
                __state = 0;
                return true;
            }
        }
        private static void Postfix(ItemObject outputItem, Town town, Workshop workshop, int count, bool doNotEffectCapital, int __state)
        {
            if (Campaign.Current.GameStarted && !doNotEffectCapital && BannerlordTweaksSettings.Instance is { } settings && settings.EnableWorkshopSellTweak)
            {
                float num = Math.Min(1000, __state) * count * (settings.WorkshopSellTweak - 1f);
                workshop.ChangeGold((int)num);
                town.ChangeGold((int)-num);
            }
        }
        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.EnableWorkshopSellTweak;
    }


    [HarmonyPatch(typeof(WorkshopsCampaignBehavior), "ConsumeInput")]
    public class ConsumeInputPatch
    {
        private static bool Prefix(ItemCategory productionInput, Town town, Workshop workshop, bool doNotEffectCapital, out int __state)
        {
            if (Campaign.Current.GameStarted && !doNotEffectCapital )
            {
                ItemRoster itemRoster = town.Owner.ItemRoster;
                int num2 = itemRoster.FindIndex((ItemObject x) => x.ItemCategory == productionInput);
                if (num2 >= 0)
                {
                    ItemObject itemAtIndex = itemRoster.GetItemAtIndex(num2);
                    __state = town.GetItemPrice(itemAtIndex, null, false);
                    return true;
                }
                else
                {
                    __state = 0;
                    return true;
                }
            }
            else
            {
                __state = 0;
                return true;
            }
        }
        private static void Postfix(ItemCategory productionInput, Town town, Workshop workshop, bool doNotEffectCapital, int __state)
        {

            if (Campaign.Current.GameStarted && !doNotEffectCapital && BannerlordTweaksSettings.Instance is { } settings && settings.EnableWorkshopBuyTweak)
            {
                float num = __state * (settings.WorkshopBuyTweak - 1f);
                workshop.ChangeGold((int)-num);
                town.ChangeGold((int)num);
            }
        }
        static bool Prepare() => BannerlordTweaksSettings.Instance is { } settings && settings.EnableWorkshopBuyTweak;
    }
}