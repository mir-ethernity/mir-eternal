using System;
using System.Collections.Generic;

namespace GameServer.Templates
{
	
	public sealed class C_01_CalculateHitTarget : SkillTask
	{
		
		public C_01_CalculateHitTarget()
		{
			
			
		}

		
		public bool 清空命中列表;

		
		public bool 技能能否穿墙;

		
		public bool 技能能否招架;

		
		public 技能锁定类型 技能锁定方式;

		
		public SkillEvasionType SkillEvasion;

		
		public SkillHitFeedback SkillHitFeedback;

		
		public MonsterSize 技能范围类型;

		
		public bool 放空结束技能;

		
		public bool 发送中断通知;

		
		public bool 补发释放通知;

		
		public bool 技能命中通知;

		
		public bool 技能扩展通知;

		
		public bool 计算飞行耗时;

		
		public int 单格飞行耗时;

		
		public int HitsLimit;

		
		public GameObjectType LimitedTargetType;

		
		public GameObjectRelationship LimitedTargetRelationship;

		
		public SpecifyTargetType QualifySpecificType;

		
		public SpecifyTargetType 攻速提升类型;

		
		public int 攻速提升幅度;

		
		public bool 触发PassiveSkill;

		
		public float 触发被动概率;

		
		public bool 增加SkillExp;

		
		public ushort 经验SkillId;

		
		public bool 清除目标状态;

		
		public HashSet<ushort> 清除状态列表;
	}
}
