using System;

namespace GameServer.Templates
{
	public class EquipmentItem : GameItems
	{
		public bool DestroyOnDeath;
		public bool DisableDismount;
		public bool CanRepair;
		public int RepairCost;
		public int SpecialRepairCost;
		public int NeedAttack;
		public int NeedMagic;
		public int NeedTaoism;
		public int NeedAcupuncture;
		public int NeedArchery;
		public int BasicPowerCombat;
		public int MinDC;
		public int MaxDC;
		public int MinMC;
		public int MaxMC;
		public int MinSC;
		public int MaxSC;
		public int MinNeedle;
		public int MaxNeedle;
		public int MinBow;
		public int MaxBow;
		public int MinDef;
		public int MaxDef;
		public int MinMCDef;
		public int MaxMCDef;
		public int MaxHP;
		public int MaxMP;
		public int PhysicallyAccurate;
		public int PhysicalAgility;
		public int AttackSpeed;
		public int MagicDodge;
		public int PunchUpperLimit;
		public int CostPerHole;
		public int TwoHoleCost;
		public int ReforgedSpiritStone;
		public int NumberSpiritStones;
		public int NumberGoldCoins;
		public GameEquipmentSet EquipSet;

		public byte Location
		{
			get
			{
				switch (Type)
				{
					case ItemType.武器:
						return 0;
					case ItemType.衣服:
						return 1;

				}
				return byte.MaxValue;
			}
		}

	}
}
