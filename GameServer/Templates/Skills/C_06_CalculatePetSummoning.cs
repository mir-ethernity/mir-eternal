using System;

namespace GameServer.Templates
{
	
	public sealed class C_06_CalculatePetSummoning : SkillTask
	{
		
		public C_06_CalculatePetSummoning()
		{
			
			
		}

		
		public string 召唤PetName;

		
		public bool 怪物召唤同伴;

		
		public byte[] 召唤宠物数量;

		
		public byte[] 宠物GradeCap;

		
		public bool 增加SkillExp;

		
		public ushort 经验SkillId;

		
		public bool 宠物BoundWeapons;

		
		public bool 检查技能铭文;
	}
}
