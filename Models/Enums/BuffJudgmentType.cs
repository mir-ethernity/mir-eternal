using System;

namespace GameServer.Templates
{
	public enum BuffJudgmentType
	{
		AllSkillDamage,
		AllPhysicalDamage,
		AllMagicDamage,
		AllSpecificInjuries = 4,
		SourceSkillDamage = 8,
		SourcePhysicalDamage = 16,
		SourceMagicDamage = 32,
		SourceSpecificDamage = 64
	}
}
