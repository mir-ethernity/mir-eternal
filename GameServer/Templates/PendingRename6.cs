using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 铭文技能
	{
		
		public static 铭文技能 随机洗练(byte 洗练职业)
		{
			List<铭文技能> list;
			if (铭文技能.概率表.TryGetValue(洗练职业, out list) && list.Count > 0)
			{
				return list[MainProcess.RandomNumber.Next(list.Count)];
			}
			return null;
		}

		
		public static void LoadData()
		{
			铭文技能.DataSheet = new Dictionary<ushort, 铭文技能>();
			string text = CustomClass.GameData目录 + "\\System\\Skills\\Inscriptions\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(铭文技能)))
				{
					铭文技能.DataSheet.Add(((铭文技能)obj).铭文索引, (铭文技能)obj);
				}
			}
			Dictionary<byte, List<铭文技能>> dictionary = new Dictionary<byte, List<铭文技能>>();
			dictionary[0] = new List<铭文技能>();
			dictionary[1] = new List<铭文技能>();
			dictionary[2] = new List<铭文技能>();
			dictionary[3] = new List<铭文技能>();
			dictionary[4] = new List<铭文技能>();
			dictionary[5] = new List<铭文技能>();
			铭文技能.概率表 = dictionary;
			foreach (铭文技能 铭文技能 in 铭文技能.DataSheet.Values)
			{
				if (铭文技能.铭文编号 != 0)
				{
					for (int j = 0; j < 铭文技能.洗练概率; j++)
					{
						铭文技能.概率表[(byte)铭文技能.技能职业].Add(铭文技能);
					}
				}
			}
			foreach (List<铭文技能> list in 铭文技能.概率表.Values)
			{
				for (int k = 0; k < list.Count; k++)
				{
					铭文技能 value = list[k];
					int index = MainProcess.RandomNumber.Next(list.Count);
					list[k] = list[index];
					list[index] = value;
				}
			}
		}

		
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x00006013 File Offset: 0x00004213
		public ushort 铭文索引
		{
			get
			{
				return (ushort)(this.技能编号 * 10 + (ushort)this.铭文编号);
			}
		}

		
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x00034FF8 File Offset: 0x000331F8
		public Dictionary<GameObjectProperties, int>[] 属性加成
		{
			get
			{
				if (this._属性加成 != null)
				{
					return this._属性加成;
				}
				this._属性加成 = new Dictionary<GameObjectProperties, int>[]
				{
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>(),
					new Dictionary<GameObjectProperties, int>()
				};
				if (this.铭文属性加成 != null)
				{
					foreach (铭文属性 铭文属性 in this.铭文属性加成)
					{
						this._属性加成[0][铭文属性.属性] = 铭文属性.零级;
						this._属性加成[1][铭文属性.属性] = 铭文属性.一级;
						this._属性加成[2][铭文属性.属性] = 铭文属性.二级;
						this._属性加成[3][铭文属性.属性] = 铭文属性.三级;
					}
				}
				return this._属性加成;
			}
		}

		
		public 铭文技能()
		{
			
			
		}

		
		public static Dictionary<ushort, 铭文技能> DataSheet;

		
		private static Dictionary<byte, List<铭文技能>> 概率表;

		
		public string 技能名字;

		
		public GameObjectProfession 技能职业;

		
		public ushort 技能编号;

		
		public byte 铭文编号;

		
		public byte 技能计数;

		
		public ushort 计数周期;

		
		public bool 被动技能;

		
		public byte 铭文品质;

		
		public int 洗练概率;

		
		public bool 广播通知;

		
		public string 铭文描述;

		
		public byte[] 需要角色等级;

		
		public ushort[] 需要技能经验;

		
		public int[] 技能战力加成;

		
		public 铭文属性[] 铭文属性加成;

		
		public List<ushort> 铭文附带Buff;

		
		public List<ushort> 被动技能列表;

		
		public List<string> 主体技能列表;

		
		public List<string> 开关技能列表;

		
		private Dictionary<GameObjectProperties, int>[] _属性加成;
	}
}
