using System;

namespace GameServer.Templates
{
	
	public sealed class A_00_TriggerSubSkills : SkillTask //A_01_触发对象Buff : 技能任务
	{
		
		public A_00_TriggerSubSkills()
		{
			
			
		}

		
		public SkillTriggerMethod 技能触发方式;

		
		public string 触发SkillName;   

		
		public string 反手SkillName;

		
		public bool CalculateTriggerProbability;  //Buff触发概率

		
		public bool CalculateLuckyProbability;  //计算幸运概率

		
		public float 技能触发概率;

		
		public ushort 增加概率Buff;

		
		public float Buff增加系数;

		
		public bool 验证ItSelfBuff;  //验证自身Buff

		
		public ushort Id;  //触发Buff编号

		
		public bool 触发成功移除;

		
		public bool 验证铭文技能;

		
		public ushort 所需Id; //所需铭文编号

		
		public bool 同组铭文无效;
	}
}
