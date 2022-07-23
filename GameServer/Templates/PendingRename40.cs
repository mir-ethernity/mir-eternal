using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	
	public sealed class 游戏技能
	{
		
		public static void LoadData()
		{
			游戏技能.DataSheet = new Dictionary<string, 游戏技能>();
			string text = CustomClass.GameDataPath + "\\System\\Skills\\Skills\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in Serializer.Deserialize(text, typeof(游戏技能)))
				{
					游戏技能.DataSheet.Add(((游戏技能)obj).技能名字, (游戏技能)obj);
				}
			}
		}

		
		public 游戏技能()
		{
			
			this.角色Buff层数 = 1;
			this.目标Buff层数 = 1;
			this.节点列表 = new SortedDictionary<int, 技能任务>();
			
		}

		
		public static Dictionary<string, 游戏技能> DataSheet;

		
		public string 技能名字;

		
		public GameObjectRace 技能职业;

		
		public 技能对应类型 技能类型;

		
		public ushort 自身技能编号;

		
		public byte 自身铭文编号;

		
		public byte 技能分组编号;

		
		public ushort 绑定等级编号;

		
		public bool 需要正向走位;

		
		public byte 技能最远距离;

		
		public bool 计算幸运概率;

		
		public float 计算触发概率;

		
		public GameObjectStats 属性提升概率;

		
		public float 属性提升系数;

		
		public bool 检查忙绿状态;

		
		public bool 检查硬直状态;

		
		public bool 检查职业武器;

		
		public bool 检查被动标记;

		
		public bool 检查技能标记;

		
		public bool 检查技能计数;

		
		public ushort 技能标记编号;

		
		public int[] 需要消耗魔法;

		
		public HashSet<int> 需要消耗物品;

		
		public int 消耗物品数量;

		
		public int 战具扣除点数;

		
		public ushort 验证已学技能;

		
		public byte 验证技能铭文;

		
		public ushort 验证角色Buff;

		
		public int 角色Buff层数;

		
		public 指定目标类型 验证目标类型;

		
		public ushort 验证目标Buff;

		
		public int 目标Buff层数;

		
		public SortedDictionary<int, 技能任务> 节点列表;
	}
}
