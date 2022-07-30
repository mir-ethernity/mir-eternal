using System;

namespace GameServer.Templates
{
	
	public sealed class A_00_TriggerSubSkills : SkillTask
	{
		
		public A_00_TriggerSubSkills()
		{
			
			
		}

		
		public SkillTriggerMethod 技能触发方式;

		
		public string 触发SkillName;

		
		public string 反手SkillName;

		
		public bool CalculateTriggerProbability;

		
		public bool CalculateLuckyProbability;

		
		public float 技能触发概率;

		
		public ushort 增加概率Buff;

		
		public float Buff增加系数;

		
		public bool 验证ItSelfBuff;

		
		public ushort Id;

		
		public bool 触发成功移除;

		
		public bool 验证铭文技能;

		
		public ushort 所需Id;

		
		public bool 同组铭文无效;
	}
}
