using System;
using System.Collections.Generic;

namespace GameServer.Templates
{
	
	public sealed class C_01_计算命中目标 : 技能任务
	{
		
		public C_01_计算命中目标()
		{
			
			
		}

		
		public bool 清空命中列表;

		
		public bool 技能能否穿墙;

		
		public bool 技能能否招架;

		
		public 技能锁定类型 技能锁定方式;

		
		public 技能闪避类型 技能闪避方式;

		
		public 技能命中反馈 技能命中反馈;

		
		public 技能范围类型 技能范围类型;

		
		public bool 放空结束技能;

		
		public bool 发送中断通知;

		
		public bool 补发释放通知;

		
		public bool 技能命中通知;

		
		public bool 技能扩展通知;

		
		public bool 计算飞行耗时;

		
		public int 单格飞行耗时;

		
		public int 限定命中数量;

		
		public GameObjectType 限定目标类型;

		
		public 游戏对象关系 限定目标关系;

		
		public 指定目标类型 限定特定类型;

		
		public 指定目标类型 攻速提升类型;

		
		public int 攻速提升幅度;

		
		public bool 触发被动技能;

		
		public float 触发被动概率;

		
		public bool 增加技能经验;

		
		public ushort 经验技能编号;

		
		public bool 清除目标状态;

		
		public HashSet<ushort> 清除状态列表;
	}
}
