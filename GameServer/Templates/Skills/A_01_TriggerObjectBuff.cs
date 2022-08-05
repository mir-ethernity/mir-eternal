using System;

namespace GameServer.Templates
{
	
	public sealed class A_01_TriggerObjectBuff : SkillTask
	{
		
		public A_01_TriggerObjectBuff()
		{
			
			
		}

		
		public bool 角色ItSelf添加;

		
		public ushort 触发Id;

		
		public ushort 伴生Id;

		
		public float Buff触发概率;

		
		public bool 验证铭文技能;

		
		public ushort 所需Id;

		
		public bool 同组铭文无效;

		
		public bool 验证ItSelfBuff;

		
		public ushort Id;

		
		public bool 触发成功移除;

		
		public bool 移除伴生Buff;

		
		public ushort 移除伴生编号;

		
		public bool 验证分组Buff;

		
		public ushort BuffGroupId;

		
		public bool VerifyTargetBuff;

		
		public ushort 目标Id;

		
		public byte 所需Buff层数;

		
		public bool VerifyTargetType;

		
		public SpecifyTargetType 所需目标类型;

		
		public bool 增加技能经验;

		
		public ushort 经验SkillId;
	}
}
