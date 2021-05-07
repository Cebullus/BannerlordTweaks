using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordTweaks
{    
    public class TweakedSettlementMilitiaModel : DefaultSettlementMilitiaModel
    {
        public override void CalculateMilitiaSpawnRate(Settlement settlement, out float meleeTroopRate, out float rangedTroopRate)
        {
            base.CalculateMilitiaSpawnRate(settlement, out meleeTroopRate, out rangedTroopRate);

            if (BannerlordTweaksSettings.Instance is { } settings)
            {
                meleeTroopRate = settings.SettlementMeleeSpawnRate;
                rangedTroopRate = 1f-settings.SettlementMeleeSpawnRate;
            }
        }
		public override float CalculateEliteMilitiaSpawnChance(Settlement settlement)
		{
			if (BannerlordTweaksSettings.Instance is { } settings)
			{
				float num = 0f;
				Hero? hero = null;
				if (settlement.IsFortification && settlement.Town.Governor != null)
				{
					hero = settlement.Town.Governor;
				}
				else if (settlement.IsVillage && settlement.Village.TradeBound.Town.Governor != null)
				{
					hero = settlement.Village.TradeBound.Town.Governor;
				}
				if (hero != null && hero.GetPerkValue(DefaultPerks.Leadership.CitizenMilitia))
				{
					num += DefaultPerks.Leadership.CitizenMilitia.PrimaryBonus * 0.01f;
				}
				num += settings.SettlementEliteSpawnChanceBonus;
				return num;
			}
			else
			{
				return base.CalculateEliteMilitiaSpawnChance(settlement);
			}
		}
	}
}
