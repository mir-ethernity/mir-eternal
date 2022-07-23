using System;

namespace GameServer.Templates
{
	
	public sealed class A_01_触发对象Buff : 技能任务
	{
		
		public A_01_触发对象Buff()
		{
			
			
		}

		
		public bool 角色自身添加;

		
		public ushort 触发Buff编号;

		
		public ushort 伴生Buff编号;

		
		public float Buff触发概率;

		
		public bool 验证铭文技能;

		
		public ushort 所需铭文编号;

		
		public bool 同组铭文无效;

		
		public bool 验证自身Buff;

		
		public ushort 自身Buff编号;

		
		public bool 触发成功移除;

		
		public bool 移除伴生Buff;

		
		public ushort 移除伴生编号;

		
		public bool 验证分组Buff;

		
		public ushort Buff分组编号;

		
		public bool 验证目标Buff;

		
		public ushort 目标Buff编号;

		
		public byte 所需Buff层数;

		
		public bool 验证目标类型;

		
		public 指定目标类型 所需目标类型;

		
		public bool 增加技能经验;

		
		public ushort 经验技能编号;
	}
}
