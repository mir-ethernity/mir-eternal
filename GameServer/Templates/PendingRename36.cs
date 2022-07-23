using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 地图守卫
	{
		
		public static void LoadData()
		{
			地图守卫.DataSheet = new Dictionary<ushort, 地图守卫>();
			string text = CustomClass.GameDataPath + "\\System\\Npc\\Guards\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(地图守卫)))
				{
					地图守卫.DataSheet.Add(((地图守卫)obj).GuardNumber, (地图守卫)obj);
				}
			}
		}

		
		public 地图守卫()
		{
			
			
		}

		
		public static Dictionary<ushort, 地图守卫> DataSheet;

		
		public string 守卫名字;

		
		public ushort GuardNumber;

		
		public byte 守卫等级;

		
		public bool 虚无状态;

		
		public bool 能否受伤;

		
		public int 尸体保留;

		
		public int RevivalInterval;

		
		public bool 主动攻击;

		
		public byte 仇恨范围;

		
		public string 普攻技能;

		
		public int 商店编号;

		
		public string 界面代码;
	}
}
