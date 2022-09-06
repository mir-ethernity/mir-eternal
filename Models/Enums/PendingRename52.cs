using System;

namespace GameServer.Templates
{
	
	public enum SkillEvasionType  //技能闪避类型
	{
		
		SkillCannotBeEvaded,  //技能无法闪避
		
		CanBePhsyicallyEvaded,  //可被物理闪避
		
		CanBeMagicEvaded,  // 可被魔法闪避
		
		CanBePoisonEvaded,  //可被中毒闪避
		
		NonMonstersCanEvaded  //非怪物可闪避
	}
}
