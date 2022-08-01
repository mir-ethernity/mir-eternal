using System;

namespace GameServer
{
	
	public enum ExecutionWay
	{
		
		前台立即执行,
		
		优先后台执行,
		
		只能后台执行,
		
		只能空闲执行
	}
}
