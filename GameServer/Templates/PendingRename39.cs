using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameServer.Templates
{
	
	public sealed class 对话数据
	{
		
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

		
		public 对话数据()
		{
			
			
		}

		
		public static Dictionary<int, string> DataSheet;

		
		public static Dictionary<int, byte[]> 字节表;

		
		public int 对话编号;

		
		public string 对话内容;
	}
}
