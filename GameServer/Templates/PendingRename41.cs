using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameServer.Data;

namespace GameServer.Templates
{
	// Token: 0x020002BF RID: 703
	public sealed class 游戏商店
	{
		// Token: 0x060006D7 RID: 1751 RVA: 0x000353DC File Offset: 0x000335DC
		public static void LoadData()
		{
			游戏商店.DataSheet = new Dictionary<int, 游戏商店>();
			string text = CustomClass.GameData目录 + "\\System\\Items\\GameStore\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(游戏商店)))
				{
					游戏商店.DataSheet.Add(((游戏商店)obj).商店编号, (游戏商店)obj);
				}
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					foreach (游戏商店 游戏商店 in from X in 游戏商店.DataSheet.Values.ToList<游戏商店>()
					orderby X.商店编号
					select X)
					{
						foreach (游戏商品 游戏商品 in 游戏商店.商品列表)
						{
							binaryWriter.Write(游戏商店.商店编号);
							binaryWriter.Write(new byte[64]);
							binaryWriter.Write(游戏商品.商品编号);
							binaryWriter.Write(游戏商品.单位数量);
							binaryWriter.Write(游戏商品.货币类型);
							binaryWriter.Write(游戏商品.商品价格);
							binaryWriter.Write(-1);
							binaryWriter.Write(0);
							binaryWriter.Write(-1);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write((int)游戏商店.回收类型);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							binaryWriter.Write(0);
							游戏商店.商店物品数量++;
						}
					}
					游戏商店.商店文件数据 = 序列化类.压缩字节(memoryStream.ToArray());
					游戏商店.商店文件效验 = 0;
					foreach (byte b in 游戏商店.商店文件数据)
					{
						游戏商店.商店文件效验 += (int)b;
					}
				}
			}
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00006051 File Offset: 0x00004251
		public bool 回购物品(ItemData 物品)
		{
			return this.回购列表.Remove(物品);
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00035670 File Offset: 0x00033870
		public void 出售物品(ItemData 物品)
		{
			物品.回购编号 = ++游戏商店.商店回购排序;
			if (this.回购列表.Add(物品) && this.回购列表.Count > 50)
			{
				ItemData ItemData = this.回购列表.Last<ItemData>();
				this.回购列表.Remove(ItemData);
				ItemData.删除数据();
			}
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0000605F File Offset: 0x0000425F
		public 游戏商店()
		{
			
			this.回购列表 = new SortedSet<ItemData>(new 回购排序());
			
		}

		// Token: 0x04000BBA RID: 3002
		public static byte[] 商店文件数据;

		// Token: 0x04000BBB RID: 3003
		public static int 商店文件效验;

		// Token: 0x04000BBC RID: 3004
		public static int 商店物品数量;

		// Token: 0x04000BBD RID: 3005
		public static int 商店回购排序;

		// Token: 0x04000BBE RID: 3006
		public static Dictionary<int, 游戏商店> DataSheet;

		// Token: 0x04000BBF RID: 3007
		public int 商店编号;

		// Token: 0x04000BC0 RID: 3008
		public string 商店名字;

		// Token: 0x04000BC1 RID: 3009
		public ItemsForSale 回收类型;

		// Token: 0x04000BC2 RID: 3010
		public List<游戏商品> 商品列表;

		// Token: 0x04000BC3 RID: 3011
		public SortedSet<ItemData> 回购列表;
	}
}
