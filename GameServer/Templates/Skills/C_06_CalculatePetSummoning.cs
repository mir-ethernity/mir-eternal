using System;

namespace GameServer.Templates
{
	
	public sealed class C_06_CalculatePetSummoning : SkillTask
	{
		
		public C_06_CalculatePetSummoning()
		{
			
			
		}

		
		public string PetName;

		
		public bool Companion;

		
		public byte[] SpawnCount;

		
		public byte[] LevelCap;

		
		public bool GainSkillExp;

		
		public ushort ExpSkillId;

		
		public bool PetBoundWeapons;

		
		public bool CheckSkillInscriptions;
	}
}
