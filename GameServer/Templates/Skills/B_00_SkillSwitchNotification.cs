using System;

namespace GameServer.Templates
{
	
	public sealed class B_00_SkillSwitchNotification : SkillTask
	{
		
		public B_00_SkillSwitchNotification()
		{
			
			
		}

		
		public ushort SkillTagId;

		
		public bool 允许移除标记;

		public int 角色忙绿时间;
	}
}
