using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 游戏Buff
	{
		
		public static void LoadData()
		{
			游戏Buff.DataSheet = new Dictionary<ushort, 游戏Buff>();
			string text = CustomClass.GameDataPath + "\\System\\Skills\\Buffs\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(游戏Buff)))
				{
					游戏Buff.DataSheet.Add(((游戏Buff)obj).Buff编号, (游戏Buff)obj);
				}
			}
		}

		
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00030B98 File Offset: 0x0002ED98
		public Dictionary<GameObjectProperties, int>[] 基础属性增减
		{
			get
			{
				if (this._基础属性增减 != null)
				{
					return this._基础属性增减;
				}
				this._基础属性增减 = new Dictionary<GameObjectProperties, int>[]
				{
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>()
				};
				if (this.属性增减 != null)
				{
					foreach (铭文属性 铭文属性 in this.属性增减)
					{
						this._基础属性增减[0][铭文属性.属性] = 铭文属性.零级;
						this._基础属性增减[1][铭文属性.属性] = 铭文属性.一级;
						this._基础属性增减[2][铭文属性.属性] = 铭文属性.二级;
						this._基础属性增减[3][铭文属性.属性] = 铭文属性.三级;
					}
				}
				return this._基础属性增减;
			}
		}

		
		public 游戏Buff()
		{
			
			
		}

		
		public static Dictionary<ushort, 游戏Buff> DataSheet;

		
		public string Buff名字;

		
		public ushort Buff编号;

		
		public ushort 分组编号;

		
		public Buff作用类型 作用类型;

		
		public Buff叠加类型 叠加类型;

		
		public Buff效果类型 Buff效果;

		
		public bool 同步至客户端;

		
		public bool 到期主动消失;

		
		public bool 切换地图消失;

		
		public bool 切换武器消失;

		
		public bool 角色死亡消失;

		
		public bool 角色下线消失;

		
		public ushort 绑定技能等级;

		
		public bool 移除添加冷却;

		
		public ushort 技能Cooldown;

		
		public byte Buff初始层数;

		
		public byte Buff最大层数;

		
		public bool Buff允许合成;

		
		public byte Buff合成层数;

		
		public ushort Buff合成编号;

		
		public int Buff处理间隔;

		
		public int Buff处理延迟;

		
		public int Buff持续时间;

		
		public bool 持续时间延长;

		
		public ushort 后接Buff编号;

		
		public ushort 连带Buff编号;

		
		public ushort[] 依存Buff列表;

		
		public bool 技能等级延时;

		
		public int 每级延长时间;

		
		public bool 角色属性延时;

		
		public GameObjectProperties 绑定角色属性;

		
		public float 属性延时系数;

		
		public bool 特定铭文延时;

		
		public int 特定铭文技能;

		
		public int 铭文延长时间;

		
		public 游戏对象状态 角色所处状态;

		
		public 铭文属性[] 属性增减;

		
		private Dictionary<GameObjectProperties, int>[] _基础属性增减;

		
		public 技能伤害类型 Buff伤害类型;

		
		public int[] Buff伤害基数;

		
		public float[] Buff伤害系数;

		
		public int 强化铭文编号;

		
		public int 铭文强化基数;

		
		public float 铭文强化系数;

		
		public bool 效果生效移除;

		
		public ushort 生效后接编号;

		
		public bool 后接技能来源;

		
		public Buff判定方式 效果判定方式;

		
		public bool 限定伤害上限;

		
		public int 限定伤害数值;

		
		public Buff判定类型 效果判定类型;

		
		public HashSet<ushort> 特定技能编号;

		
		public int[] 伤害增减基数;

		
		public float[] 伤害增减系数;

		
		public string 触发陷阱技能;

		
		public 技能范围类型 触发陷阱数量;

		
		public byte[] 体力回复基数;

		
		public int 诱惑时长增加;

		
		public float 诱惑概率增加;

		
		public byte 诱惑等级增加;
	}
}
