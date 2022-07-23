using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
	
	public sealed class 珍宝商品
	{
		
		public static void LoadData()
		{
			珍宝商品.DataSheet = new Dictionary<int, 珍宝商品>();
			string text = CustomClass.GameData目录 + "\\System\\Items\\Treasures\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(珍宝商品)))
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

		
		public 珍宝商品()
		{
			
			
		}

		
		public static byte[] 珍宝商店数据;

		
		public static int 珍宝商店效验;

		
		public static int 珍宝商店数量;

		
		public static Dictionary<int, 珍宝商品> DataSheet;

		
		public int 物品编号;

		
		public int 单位数量;

		
		public byte 商品分类;

		
		public byte 商品标签;

		
		public byte 补充参数;

		
		public int 商品原价;

		
		public int 商品现价;

		
		public byte 买入绑定;
	}
}
