using System;

namespace GameServer.Templates
{
	
	public sealed class B_01_技能释放通知 : 技能任务
	{
		
		public B_01_技能释放通知()
		{
			
			
		}

		
		public bool 发送释放通知;

		
		public bool 移除技能标记;

		
		public bool 调整角色朝向;

		
		public int 自身冷却时间;

		
		public bool Buff增加冷却;

		
		public ushort 增加冷却Buff;

		
		public int 冷却增加时间;

		
		public int 分组冷却时间;

		
		public int 角色忙绿时间;
	}
}
