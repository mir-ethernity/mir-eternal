using System;

namespace GameServer.Templates
{
	
	[Flags]
	public enum Buff效果类型
	{
		
		技能标志 = 0,
		
		状态标志 = 1,
		
		造成伤害 = 2,
		
		Stat增减 = 4,
		
		伤害增减 = 8,
		
		创建陷阱 = 16,
		
		生命回复 = 32,
		
		诱惑提升 = 64
	}
}
