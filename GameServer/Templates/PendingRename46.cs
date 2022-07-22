using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x020002BD RID: 701
	public sealed class 游戏怪物
	{
		// Token: 0x060006D1 RID: 1745 RVA: 0x000351A0 File Offset: 0x000333A0
		public static void LoadData()
		{
			游戏怪物.DataSheet = new Dictionary<string, 游戏怪物>();
			string text = CustomClass.GameData目录 + "\\System\\Npc\\Monsters\\";
			if (Directory.Exists(text))
			{
				object[] array = 序列化类.反序列化(text, typeof(游戏怪物));
				for (int i = 0; i < array.Length; i++)
				{
					游戏怪物 游戏怪物 = array[i] as 游戏怪物;
					if (游戏怪物 != null)
					{
						游戏怪物.DataSheet.Add(游戏怪物.怪物名字, 游戏怪物);
					}
				}
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x0003520C File Offset: 0x0003340C
		public Dictionary<GameObjectProperties, int> 基础属性
		{
			get
			{
				if (this._基础属性 != null)
				{
					return this._基础属性;
				}
				this._基础属性 = new Dictionary<GameObjectProperties, int>();
				if (this.怪物基础 != null)
				{
					foreach (基础属性 基础属性 in this.怪物基础)
					{
						this._基础属性[基础属性.属性] = 基础属性.数值;
					}
				}
				return this._基础属性;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x00035278 File Offset: 0x00033478
		public Dictionary<GameObjectProperties, int>[] 成长属性
		{
			get
			{
				if (this._成长属性 != null)
				{
					return this._成长属性;
				}
				this._成长属性 = new Dictionary<GameObjectProperties, int>[]
				{
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>()
				};
				if (this.怪物成长 != null)
				{
					foreach (成长属性 成长属性 in this.怪物成长)
					{
						this._成长属性[0][成长属性.属性] = 成长属性.零级;
						this._成长属性[1][成长属性.属性] = 成长属性.一级;
						this._成长属性[2][成长属性.属性] = 成长属性.二级;
						this._成长属性[3][成长属性.属性] = 成长属性.三级;
						this._成长属性[4][成长属性.属性] = 成长属性.四级;
						this._成长属性[5][成长属性.属性] = 成长属性.五级;
						this._成长属性[6][成长属性.属性] = 成长属性.六级;
						this._成长属性[7][成长属性.属性] = 成长属性.七级;
					}
				}
				return this._成长属性;
			}
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00006026 File Offset: 0x00004226
		public 游戏怪物()
		{
			
			this.掉落统计 = new Dictionary<游戏物品, long>();
			
		}

		// Token: 0x04000B96 RID: 2966
		public static Dictionary<string, 游戏怪物> DataSheet;

		// Token: 0x04000B97 RID: 2967
		public string 怪物名字;

		// Token: 0x04000B98 RID: 2968
		public ushort 怪物编号;

		// Token: 0x04000B99 RID: 2969
		public byte 怪物等级;

		// Token: 0x04000B9A RID: 2970
		public 技能范围类型 怪物体型;

		// Token: 0x04000B9B RID: 2971
		public MonsterRaceType 怪物分类;

		// Token: 0x04000B9C RID: 2972
		public MonsterLevelType 怪物级别;

		// Token: 0x04000B9D RID: 2973
		public bool 怪物禁止移动;

		// Token: 0x04000B9E RID: 2974
		public bool 脱战自动石化;

		// Token: 0x04000B9F RID: 2975
		public ushort 石化状态编号;

		// Token: 0x04000BA0 RID: 2976
		public bool 可见隐身目标;

		// Token: 0x04000BA1 RID: 2977
		public bool 可被技能推动;

		// Token: 0x04000BA2 RID: 2978
		public bool 可被技能控制;

		// Token: 0x04000BA3 RID: 2979
		public bool 可被技能诱惑;

		// Token: 0x04000BA4 RID: 2980
		public float 基础诱惑概率;

		// Token: 0x04000BA5 RID: 2981
		public ushort 怪物移动间隔;

		// Token: 0x04000BA6 RID: 2982
		public ushort 怪物漫游间隔;

		// Token: 0x04000BA7 RID: 2983
		public ushort 尸体保留时长;

		// Token: 0x04000BA8 RID: 2984
		public bool 主动攻击目标;

		// Token: 0x04000BA9 RID: 2985
		public byte 怪物仇恨范围;

		// Token: 0x04000BAA RID: 2986
		public ushort 怪物仇恨时间;

		// Token: 0x04000BAB RID: 2987
		public string 普通攻击技能;

		// Token: 0x04000BAC RID: 2988
		public string 概率触发技能;

		// Token: 0x04000BAD RID: 2989
		public string 进入战斗技能;

		// Token: 0x04000BAE RID: 2990
		public string 退出战斗技能;

		// Token: 0x04000BAF RID: 2991
		public string 移动释放技能;

		// Token: 0x04000BB0 RID: 2992
		public string 出生释放技能;

		// Token: 0x04000BB1 RID: 2993
		public string 死亡释放技能;

		// Token: 0x04000BB2 RID: 2994
		public 基础属性[] 怪物基础;

		// Token: 0x04000BB3 RID: 2995
		public 成长属性[] 怪物成长;

		// Token: 0x04000BB4 RID: 2996
		public 属性继承[] 继承属性;

		// Token: 0x04000BB5 RID: 2997
		public ushort 怪物提供经验;

		// Token: 0x04000BB6 RID: 2998
		public List<怪物掉落> 怪物掉落物品;

		// Token: 0x04000BB7 RID: 2999
		public Dictionary<游戏物品, long> 掉落统计;

		// Token: 0x04000BB8 RID: 3000
		private Dictionary<GameObjectProperties, int> _基础属性;

		// Token: 0x04000BB9 RID: 3001
		private Dictionary<GameObjectProperties, int>[] _成长属性;
	}
}
