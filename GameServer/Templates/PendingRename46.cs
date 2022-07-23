using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 游戏怪物
	{
		
		public static void LoadData()
		{
			游戏怪物.DataSheet = new Dictionary<string, 游戏怪物>();
			string text = CustomClass.GameDataPath + "\\System\\Npc\\Monsters\\";
			if (Directory.Exists(text))
			{
				object[] array = Serializer.Deserialize(text, typeof(游戏怪物));
				for (int i = 0; i < array.Length; i++)
				{
					游戏怪物 游戏怪物 = array[i] as 游戏怪物;
					if (游戏怪物 != null)
					{
						游戏怪物.DataSheet.Add(游戏怪物.MonsterName, 游戏怪物);
					}
				}
			}
		}

		
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

		
		public 游戏怪物()
		{
			
			this.掉落统计 = new Dictionary<GameItems, long>();
			
		}

		
		public static Dictionary<string, 游戏怪物> DataSheet;

		
		public string MonsterName;

		
		public ushort 怪物编号;

		
		public byte 怪物等级;

		
		public 技能范围类型 怪物体型;

		
		public MonsterRaceType 怪物分类;

		
		public MonsterLevelType 怪物级别;

		
		public bool 怪物禁止移动;

		
		public bool 脱战自动石化;

		
		public ushort 石化状态编号;

		
		public bool 可见隐身目标;

		
		public bool 可被技能推动;

		
		public bool 可被技能控制;

		
		public bool 可被技能诱惑;

		
		public float 基础诱惑概率;

		
		public ushort 怪物移动间隔;

		
		public ushort 怪物漫游间隔;

		
		public ushort 尸体保留时长;

		
		public bool 主动攻击目标;

		
		public byte 怪物仇恨范围;

		
		public ushort 怪物仇恨时间;

		
		public string 普通攻击技能;

		
		public string 概率触发技能;

		
		public string 进入战斗技能;

		
		public string 退出战斗技能;

		
		public string 移动释放技能;

		
		public string 出生释放技能;

		
		public string 死亡释放技能;

		
		public 基础属性[] 怪物基础;

		
		public 成长属性[] 怪物成长;

		
		public 属性继承[] 继承属性;

		
		public ushort 怪物提供经验;

		
		public List<怪物掉落> 怪物掉落物品;

		
		public Dictionary<GameItems, long> 掉落统计;

		
		private Dictionary<GameObjectProperties, int> _基础属性;

		
		private Dictionary<GameObjectProperties, int>[] _成长属性;
	}
}
