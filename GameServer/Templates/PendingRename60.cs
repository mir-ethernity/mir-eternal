using System;

namespace GameServer.Templates
{
	
	public enum Buff判定类型
	{
		
		所有技能伤害,
		
		所有物理伤害,
		
		所有魔法伤害,
		
		所有特定伤害 = 4,
		
		来源技能伤害 = 8,
		
		来源物理伤害 = 16,
		
		来源魔法伤害 = 32,
		
		来源特定伤害 = 64
	}
}
