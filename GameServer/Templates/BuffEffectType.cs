using System;

namespace GameServer.Templates
{
	[Flags]
	public enum BuffEffectType
	{
		SkillSign = 0,
		StatusFlag = 1,
		CausesSomeDamages = 2,
		StatsIncOrDec = 4,
		DamageIncOrDec = 8,
		CreateTrap = 16,
		LifeRecovery = 32,
		TemptationBoost = 64
	}
}
