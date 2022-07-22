using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x020002B5 RID: 693
	public sealed class 游戏技能
	{
		// Token: 0x060006C6 RID: 1734 RVA: 0x00034D74 File Offset: 0x00032F74
		public static void LoadData()
		{
			游戏技能.DataSheet = new Dictionary<string, 游戏技能>();
			string text = CustomClass.GameData目录 + "\\System\\Skills\\Skills\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(游戏技能)))
				{
					游戏技能.DataSheet.Add(((游戏技能)obj).技能名字, (游戏技能)obj);
				}
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00005FED File Offset: 0x000041ED
		public 游戏技能()
		{
			
			this.角色Buff层数 = 1;
			this.目标Buff层数 = 1;
			this.节点列表 = new SortedDictionary<int, 技能任务>();
			
		}

		// Token: 0x04000B27 RID: 2855
		public static Dictionary<string, 游戏技能> DataSheet;

		// Token: 0x04000B28 RID: 2856
		public string 技能名字;

		// Token: 0x04000B29 RID: 2857
		public GameObjectProfession 技能职业;

		// Token: 0x04000B2A RID: 2858
		public 技能对应类型 技能类型;

		// Token: 0x04000B2B RID: 2859
		public ushort 自身技能编号;

		// Token: 0x04000B2C RID: 2860
		public byte 自身铭文编号;

		// Token: 0x04000B2D RID: 2861
		public byte 技能分组编号;

		// Token: 0x04000B2E RID: 2862
		public ushort 绑定等级编号;

		// Token: 0x04000B2F RID: 2863
		public bool 需要正向走位;

		// Token: 0x04000B30 RID: 2864
		public byte 技能最远距离;

		// Token: 0x04000B31 RID: 2865
		public bool 计算幸运概率;

		// Token: 0x04000B32 RID: 2866
		public float 计算触发概率;

		// Token: 0x04000B33 RID: 2867
		public GameObjectProperties 属性提升概率;

		// Token: 0x04000B34 RID: 2868
		public float 属性提升系数;

		// Token: 0x04000B35 RID: 2869
		public bool 检查忙绿状态;

		// Token: 0x04000B36 RID: 2870
		public bool 检查硬直状态;

		// Token: 0x04000B37 RID: 2871
		public bool 检查职业武器;

		// Token: 0x04000B38 RID: 2872
		public bool 检查被动标记;

		// Token: 0x04000B39 RID: 2873
		public bool 检查技能标记;

		// Token: 0x04000B3A RID: 2874
		public bool 检查技能计数;

		// Token: 0x04000B3B RID: 2875
		public ushort 技能标记编号;

		// Token: 0x04000B3C RID: 2876
		public int[] 需要消耗魔法;

		// Token: 0x04000B3D RID: 2877
		public HashSet<int> 需要消耗物品;

		// Token: 0x04000B3E RID: 2878
		public int 消耗物品数量;

		// Token: 0x04000B3F RID: 2879
		public int 战具扣除点数;

		// Token: 0x04000B40 RID: 2880
		public ushort 验证已学技能;

		// Token: 0x04000B41 RID: 2881
		public byte 验证技能铭文;

		// Token: 0x04000B42 RID: 2882
		public ushort 验证角色Buff;

		// Token: 0x04000B43 RID: 2883
		public int 角色Buff层数;

		// Token: 0x04000B44 RID: 2884
		public 指定目标类型 验证目标类型;

		// Token: 0x04000B45 RID: 2885
		public ushort 验证目标Buff;

		// Token: 0x04000B46 RID: 2886
		public int 目标Buff层数;

		// Token: 0x04000B47 RID: 2887
		public SortedDictionary<int, 技能任务> 节点列表;
	}
}
