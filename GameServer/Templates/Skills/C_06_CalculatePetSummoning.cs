using System;

namespace GameServer.Templates
{
	
	public sealed class C_06_CalculatePetSummoning : SkillTask
	{
		
		public C_06_CalculatePetSummoning()
		{
			
			
		}

		
		public string 召唤宠物名字;

		
		public bool 怪物召唤同伴;

		
		public byte[] 召唤宠物数量;

		
		public byte[] 宠物等级上限;

		
		public bool 增加技能经验;

		
		public ushort 经验SkillId;

		
		public bool 宠物绑定武器;

		
		public bool 检查技能铭文;
	}
}
