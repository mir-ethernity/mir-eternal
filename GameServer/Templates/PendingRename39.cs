using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameServer.Templates
{
	// Token: 0x0200028C RID: 652
	public sealed class 对话数据
	{
		// Token: 0x06000696 RID: 1686 RVA: 0x00031080 File Offset: 0x0002F280
		public static byte[] 字节数据(int 对话编号)
		{
			byte[] result;
			if (对话数据.字节表.TryGetValue(对话编号, out result))
			{
				return result;
			}
			string str;
			if (对话数据.DataSheet.TryGetValue(对话编号, out str))
			{
				return 对话数据.字节表[对话编号] = Encoding.UTF8.GetBytes(str + "\0");
			}
			return new byte[0];
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x000310D8 File Offset: 0x0002F2D8
		public static byte[] 合并数据(int 对话编号, string 内容)
		{
			byte[] second;
			if (对话数据.字节表.TryGetValue(对话编号, out second))
			{
				return Encoding.UTF8.GetBytes(内容).Concat(second).ToArray<byte>();
			}
			string str;
			if (对话数据.DataSheet.TryGetValue(对话编号, out str))
			{
				return Encoding.UTF8.GetBytes(内容).Concat(对话数据.字节表[对话编号] = Encoding.UTF8.GetBytes(str + "\0")).ToArray<byte>();
			}
			return new byte[0];
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0003115C File Offset: 0x0002F35C
		public static void LoadData()
		{
			对话数据.DataSheet = new Dictionary<int, string>();
			对话数据.字节表 = new Dictionary<int, byte[]>();
			string text = CustomClass.GameData目录 + "\\System\\Npc\\Dialogs\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(对话数据)))
				{
					对话数据.DataSheet.Add(((对话数据)obj).对话编号, ((对话数据)obj).对话内容);
				}
			}
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x000027D8 File Offset: 0x000009D8
		public 对话数据()
		{
			
			
		}

		// Token: 0x040009B0 RID: 2480
		public static Dictionary<int, string> DataSheet;

		// Token: 0x040009B1 RID: 2481
		public static Dictionary<int, byte[]> 字节表;

		// Token: 0x040009B2 RID: 2482
		public int 对话编号;

		// Token: 0x040009B3 RID: 2483
		public string 对话内容;
	}
}
