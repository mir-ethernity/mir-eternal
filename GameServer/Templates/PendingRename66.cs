using System;

namespace GameServer.Templates
{
	
	[Flags]
	public enum 游戏对象关系
	{
		
		自身 = 1,
		
		友方 = 2,
		
		敌对 = 4
	}
}
