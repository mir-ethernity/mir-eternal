using System;

namespace GameServer.Templates
{
	public enum SkillTriggerMethod
	{
		OriginAbsolutePosition,
		AnchorAbsolutePosition,
		AssassinationAbsolutePosition,
		TargetHitDefinitely,
		MonsterDeathDefinitely,
		MonsterDeathTransposition,
		MonsterHitDefinitely,
		MonsterHitProbability,
		NoTargetPosition,
		TargetPositionAbsolute,
		ForehandAndBackhandRandom,
		TargetDeathDefinitely,
		TargetMissDefinitely
	}
}
