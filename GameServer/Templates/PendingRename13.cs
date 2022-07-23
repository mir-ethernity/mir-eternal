using System;

namespace GameServer.Templates
{
	
	public sealed class A_00_触发子类技能 : 技能任务
	{
		
		public A_00_触发子类技能()
		{
			
			
		}

		
		public 技能触发方式 技能触发方式;

		
		public string 触发技能名字;

		
		public string 反手技能名字;

		
		public bool 计算触发概率;

		
		public bool 计算幸运概率;

		
		public float 技能触发概率;

		
		public ushort 增加概率Buff;

		
		public float Buff增加系数;

		
		public bool 验证自身Buff;

		
		public ushort 自身Buff编号;

		
		public bool 触发成功移除;

		
		public bool 验证铭文技能;

		
		public ushort 所需铭文编号;

		
		public bool 同组铭文无效;
	}
}
