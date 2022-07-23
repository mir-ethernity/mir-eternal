using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x020002B7 RID: 695
	public sealed class 铭文技能
	{
		// Token: 0x060006C8 RID: 1736 RVA: 0x00034DE4 File Offset: 0x00032FE4
		public static 铭文技能 随机洗练(byte 洗练职业)
		{
			List<铭文技能> list;
			if (铭文技能.概率表.TryGetValue(洗练职业, out list) && list.Count > 0)
			{
				return list[MainProcess.RandomNumber.Next(list.Count)];
			}
			return null;
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00034E24 File Offset: 0x00033024
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

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x00006013 File Offset: 0x00004213
		public ushort 铭文索引
		{
			get
			{
				return (ushort)(this.技能编号 * 10 + (ushort)this.铭文编号);
			}
		}

		// Token: 0x170000C6 RID: 198
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

		// Token: 0x060006CC RID: 1740 RVA: 0x000027D8 File Offset: 0x000009D8
		public 铭文技能()
		{
			
			
		}

		// Token: 0x04000B4D RID: 2893
		public static Dictionary<ushort, 铭文技能> DataSheet;

		// Token: 0x04000B4E RID: 2894
		private static Dictionary<byte, List<铭文技能>> 概率表;

		// Token: 0x04000B4F RID: 2895
		public string 技能名字;

		// Token: 0x04000B50 RID: 2896
		public GameObjectProfession 技能职业;

		// Token: 0x04000B51 RID: 2897
		public ushort 技能编号;

		// Token: 0x04000B52 RID: 2898
		public byte 铭文编号;

		// Token: 0x04000B53 RID: 2899
		public byte 技能计数;

		// Token: 0x04000B54 RID: 2900
		public ushort 计数周期;

		// Token: 0x04000B55 RID: 2901
		public bool 被动技能;

		// Token: 0x04000B56 RID: 2902
		public byte 铭文品质;

		// Token: 0x04000B57 RID: 2903
		public int 洗练概率;

		// Token: 0x04000B58 RID: 2904
		public bool 广播通知;

		// Token: 0x04000B59 RID: 2905
		public string 铭文描述;

		// Token: 0x04000B5A RID: 2906
		public byte[] 需要角色等级;

		// Token: 0x04000B5B RID: 2907
		public ushort[] 需要技能经验;

		// Token: 0x04000B5C RID: 2908
		public int[] 技能战力加成;

		// Token: 0x04000B5D RID: 2909
		public 铭文属性[] 铭文属性加成;

		// Token: 0x04000B5E RID: 2910
		public List<ushort> 铭文附带Buff;

		// Token: 0x04000B5F RID: 2911
		public List<ushort> 被动技能列表;

		// Token: 0x04000B60 RID: 2912
		public List<string> 主体技能列表;

		// Token: 0x04000B61 RID: 2913
		public List<string> 开关技能列表;

		// Token: 0x04000B62 RID: 2914
		private Dictionary<GameObjectProperties, int>[] _属性加成;
	}
}
