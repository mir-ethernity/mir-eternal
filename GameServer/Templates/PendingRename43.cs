using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x020002C5 RID: 709
	public class 游戏物品
	{
		// Token: 0x060006E6 RID: 1766 RVA: 0x00035940 File Offset: 0x00033B40
		public static 游戏物品 获取数据(int 索引)
		{
			游戏物品 result;
			if (!游戏物品.DataSheet.TryGetValue(索引, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00035960 File Offset: 0x00033B60
		public static 游戏物品 获取数据(string 名字)
		{
			游戏物品 result;
			if (!游戏物品.检索表.TryGetValue(名字, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00035980 File Offset: 0x00033B80
		public static void LoadData()
		{
			游戏物品.DataSheet = new Dictionary<int, 游戏物品>();
			游戏物品.检索表 = new Dictionary<string, 游戏物品>();
			string text = CustomClass.GameData目录 + "\\System\\Items\\CommonItems\\";
			if (Directory.Exists(text))
			{
				object[] array = 序列化类.反序列化(text, typeof(游戏物品));
				for (int i = 0; i < array.Length; i++)
				{
					游戏物品 游戏物品 = array[i] as 游戏物品;
					游戏物品.DataSheet.Add(游戏物品.物品编号, 游戏物品);
					游戏物品.检索表.Add(游戏物品.物品名字, 游戏物品);
				}
			}
			text = CustomClass.GameData目录 + "\\System\\Items\\EquipmentItems\\";
			if (Directory.Exists(text))
			{
				object[] array = 序列化类.反序列化(text, typeof(游戏装备));
				for (int i = 0; i < array.Length; i++)
				{
					游戏装备 游戏装备 = array[i] as 游戏装备;
					游戏物品.DataSheet.Add(游戏装备.物品编号, 游戏装备);
					游戏物品.检索表.Add(游戏装备.物品名字, 游戏装备);
				}
			}
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x000027D8 File Offset: 0x000009D8
		public 游戏物品()
		{
			
			
		}

		// Token: 0x04000BE5 RID: 3045
		public static Dictionary<int, 游戏物品> DataSheet;

		// Token: 0x04000BE6 RID: 3046
		public static Dictionary<string, 游戏物品> 检索表;

		// Token: 0x04000BE7 RID: 3047
		public string 物品名字;

		// Token: 0x04000BE8 RID: 3048
		public int 物品编号;

		// Token: 0x04000BE9 RID: 3049
		public int 物品持久;

		// Token: 0x04000BEA RID: 3050
		public int 物品重量;

		// Token: 0x04000BEB RID: 3051
		public int 物品等级;

		// Token: 0x04000BEC RID: 3052
		public int 需要等级;

		// Token: 0x04000BED RID: 3053
		public int 冷却时间;

		// Token: 0x04000BEE RID: 3054
		public byte 物品分组;

		// Token: 0x04000BEF RID: 3055
		public int 分组冷却;

		// Token: 0x04000BF0 RID: 3056
		public int 出售价格;

		// Token: 0x04000BF1 RID: 3057
		public ushort 附加技能;

		// Token: 0x04000BF2 RID: 3058
		public bool 是否绑定;

		// Token: 0x04000BF3 RID: 3059
		public bool 能否分解;

		// Token: 0x04000BF4 RID: 3060
		public bool 能否掉落;

		// Token: 0x04000BF5 RID: 3061
		public bool 能否出售;

		// Token: 0x04000BF6 RID: 3062
		public bool 贵重物品;

		// Token: 0x04000BF7 RID: 3063
		public bool 资源物品;

		// Token: 0x04000BF8 RID: 3064
		public ItemUsageType 物品分类;

		// Token: 0x04000BF9 RID: 3065
		public GameObjectProfession 需要职业;

		// Token: 0x04000BFA RID: 3066
		public GameObjectGender 需要性别;

		// Token: 0x04000BFB RID: 3067
		public PersistentItemType 持久类型;

		// Token: 0x04000BFC RID: 3068
		public ItemsForSale 商店类型;
	}
}
