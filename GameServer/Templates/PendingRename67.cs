using System;

namespace GameServer.Templates
{
	
	[Flags]
	public enum 游戏对象状态
	{
		
		正常状态 = 0,
		
		硬直状态 = 1,
		
		忙绿状态 = 2,
		
		中毒状态 = 4,
		
		残废状态 = 8,
		
		定身状态 = 16,
		
		麻痹状态 = 32,
		
		霸体状态 = 64,
		
		无敌状态 = 128,
		
		隐身状态 = 256,
		
		潜行状态 = 512,
		
		失神状态 = 1024,
		
		暴露状态 = 2048
	}
}
