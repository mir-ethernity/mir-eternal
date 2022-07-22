using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
	// Token: 0x020002C1 RID: 705
	public sealed class 珍宝商品
	{
		// Token: 0x060006DE RID: 1758 RVA: 0x000356CC File Offset: 0x000338CC
		public static void LoadData()
		{
			珍宝商品.DataSheet = new Dictionary<int, 珍宝商品>();
			string text = CustomClass.GameData目录 + "\\System\\Items\\Treasures\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(珍宝商品)))
				{
					珍宝商品.DataSheet.Add(((珍宝商品)obj).物品编号, (珍宝商品)obj);
				}
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					foreach (珍宝商品 珍宝商品 in (from X in 珍宝商品.DataSheet.Values.ToList<珍宝商品>()
					orderby X.物品编号
					select X).ToList<珍宝商品>())
					{
						binaryWriter.Write(珍宝商品.物品编号);
						binaryWriter.Write(珍宝商品.单位数量);
						binaryWriter.Write(珍宝商品.商品分类);
						binaryWriter.Write(珍宝商品.商品标签);
						binaryWriter.Write(珍宝商品.补充参数);
						binaryWriter.Write(珍宝商品.商品原价);
						binaryWriter.Write(珍宝商品.商品现价);
						binaryWriter.Write(new byte[48]);
					}
					珍宝商品.珍宝商店数量 = 珍宝商品.DataSheet.Count;
					珍宝商品.珍宝商店数据 = memoryStream.ToArray();
					珍宝商品.珍宝商店效验 = 0;
					foreach (byte b in 珍宝商品.珍宝商店数据)
					{
						珍宝商品.珍宝商店效验 += (int)b;
					}
				}
			}
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x000027D8 File Offset: 0x000009D8
		public 珍宝商品()
		{
			
			
		}

		// Token: 0x04000BC6 RID: 3014
		public static byte[] 珍宝商店数据;

		// Token: 0x04000BC7 RID: 3015
		public static int 珍宝商店效验;

		// Token: 0x04000BC8 RID: 3016
		public static int 珍宝商店数量;

		// Token: 0x04000BC9 RID: 3017
		public static Dictionary<int, 珍宝商品> DataSheet;

		// Token: 0x04000BCA RID: 3018
		public int 物品编号;

		// Token: 0x04000BCB RID: 3019
		public int 单位数量;

		// Token: 0x04000BCC RID: 3020
		public byte 商品分类;

		// Token: 0x04000BCD RID: 3021
		public byte 商品标签;

		// Token: 0x04000BCE RID: 3022
		public byte 补充参数;

		// Token: 0x04000BCF RID: 3023
		public int 商品原价;

		// Token: 0x04000BD0 RID: 3024
		public int 商品现价;

		// Token: 0x04000BD1 RID: 3025
		public byte 买入绑定;
	}
}
