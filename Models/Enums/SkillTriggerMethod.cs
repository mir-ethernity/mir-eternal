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
		MonsterHitProbability, //怪物命中概率
		NoTargetPosition,
		TargetPositionAbsolute,
		ForehandAndBackhandRandom,
		TargetDeathDefinitely,
		TargetMissDefinitely
	}
}
