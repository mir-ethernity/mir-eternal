using System;

namespace GameServer.Templates
{
	
	public enum 技能锁定类型
	{
		
		锁定ItSelf,
		
		锁定目标,

		锁定ItSelf坐标, //锁定自身坐标
		
		锁定目标坐标,
		
		锁定锚点坐标,
		
		放空锁定ItSelf
	}
}
