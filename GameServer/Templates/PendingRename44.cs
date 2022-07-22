using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x02000283 RID: 643
	public sealed class 游戏Buff
	{
		// Token: 0x06000680 RID: 1664 RVA: 0x00030B28 File Offset: 0x0002ED28
		public static void LoadData()
		{
			游戏Buff.DataSheet = new Dictionary<ushort, 游戏Buff>();
			string text = CustomClass.GameData目录 + "\\System\\Skills\\Buffs\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(游戏Buff)))
				{
					游戏Buff.DataSheet.Add(((游戏Buff)obj).Buff编号, (游戏Buff)obj);
				}
			}
		}

		// Token: 0x170000BB RID: 187
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

		// Token: 0x06000682 RID: 1666 RVA: 0x000027D8 File Offset: 0x000009D8
		public 游戏Buff()
		{
			
			
		}

		// Token: 0x0400093C RID: 2364
		public static Dictionary<ushort, 游戏Buff> DataSheet;

		// Token: 0x0400093D RID: 2365
		public string Buff名字;

		// Token: 0x0400093E RID: 2366
		public ushort Buff编号;

		// Token: 0x0400093F RID: 2367
		public ushort 分组编号;

		// Token: 0x04000940 RID: 2368
		public Buff作用类型 作用类型;

		// Token: 0x04000941 RID: 2369
		public Buff叠加类型 叠加类型;

		// Token: 0x04000942 RID: 2370
		public Buff效果类型 Buff效果;

		// Token: 0x04000943 RID: 2371
		public bool 同步至客户端;

		// Token: 0x04000944 RID: 2372
		public bool 到期主动消失;

		// Token: 0x04000945 RID: 2373
		public bool 切换地图消失;

		// Token: 0x04000946 RID: 2374
		public bool 切换武器消失;

		// Token: 0x04000947 RID: 2375
		public bool 角色死亡消失;

		// Token: 0x04000948 RID: 2376
		public bool 角色下线消失;

		// Token: 0x04000949 RID: 2377
		public ushort 绑定技能等级;

		// Token: 0x0400094A RID: 2378
		public bool 移除添加冷却;

		// Token: 0x0400094B RID: 2379
		public ushort 技能冷却时间;

		// Token: 0x0400094C RID: 2380
		public byte Buff初始层数;

		// Token: 0x0400094D RID: 2381
		public byte Buff最大层数;

		// Token: 0x0400094E RID: 2382
		public bool Buff允许合成;

		// Token: 0x0400094F RID: 2383
		public byte Buff合成层数;

		// Token: 0x04000950 RID: 2384
		public ushort Buff合成编号;

		// Token: 0x04000951 RID: 2385
		public int Buff处理间隔;

		// Token: 0x04000952 RID: 2386
		public int Buff处理延迟;

		// Token: 0x04000953 RID: 2387
		public int Buff持续时间;

		// Token: 0x04000954 RID: 2388
		public bool 持续时间延长;

		// Token: 0x04000955 RID: 2389
		public ushort 后接Buff编号;

		// Token: 0x04000956 RID: 2390
		public ushort 连带Buff编号;

		// Token: 0x04000957 RID: 2391
		public ushort[] 依存Buff列表;

		// Token: 0x04000958 RID: 2392
		public bool 技能等级延时;

		// Token: 0x04000959 RID: 2393
		public int 每级延长时间;

		// Token: 0x0400095A RID: 2394
		public bool 角色属性延时;

		// Token: 0x0400095B RID: 2395
		public GameObjectProperties 绑定角色属性;

		// Token: 0x0400095C RID: 2396
		public float 属性延时系数;

		// Token: 0x0400095D RID: 2397
		public bool 特定铭文延时;

		// Token: 0x0400095E RID: 2398
		public int 特定铭文技能;

		// Token: 0x0400095F RID: 2399
		public int 铭文延长时间;

		// Token: 0x04000960 RID: 2400
		public 游戏对象状态 角色所处状态;

		// Token: 0x04000961 RID: 2401
		public 铭文属性[] 属性增减;

		// Token: 0x04000962 RID: 2402
		private Dictionary<GameObjectProperties, int>[] _基础属性增减;

		// Token: 0x04000963 RID: 2403
		public 技能伤害类型 Buff伤害类型;

		// Token: 0x04000964 RID: 2404
		public int[] Buff伤害基数;

		// Token: 0x04000965 RID: 2405
		public float[] Buff伤害系数;

		// Token: 0x04000966 RID: 2406
		public int 强化铭文编号;

		// Token: 0x04000967 RID: 2407
		public int 铭文强化基数;

		// Token: 0x04000968 RID: 2408
		public float 铭文强化系数;

		// Token: 0x04000969 RID: 2409
		public bool 效果生效移除;

		// Token: 0x0400096A RID: 2410
		public ushort 生效后接编号;

		// Token: 0x0400096B RID: 2411
		public bool 后接技能来源;

		// Token: 0x0400096C RID: 2412
		public Buff判定方式 效果判定方式;

		// Token: 0x0400096D RID: 2413
		public bool 限定伤害上限;

		// Token: 0x0400096E RID: 2414
		public int 限定伤害数值;

		// Token: 0x0400096F RID: 2415
		public Buff判定类型 效果判定类型;

		// Token: 0x04000970 RID: 2416
		public HashSet<ushort> 特定技能编号;

		// Token: 0x04000971 RID: 2417
		public int[] 伤害增减基数;

		// Token: 0x04000972 RID: 2418
		public float[] 伤害增减系数;

		// Token: 0x04000973 RID: 2419
		public string 触发陷阱技能;

		// Token: 0x04000974 RID: 2420
		public 技能范围类型 触发陷阱数量;

		// Token: 0x04000975 RID: 2421
		public byte[] 体力回复基数;

		// Token: 0x04000976 RID: 2422
		public int 诱惑时长增加;

		// Token: 0x04000977 RID: 2423
		public float 诱惑概率增加;

		// Token: 0x04000978 RID: 2424
		public byte 诱惑等级增加;
	}
}
