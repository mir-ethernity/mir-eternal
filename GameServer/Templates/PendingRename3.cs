using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	// Token: 0x020002B8 RID: 696
	public sealed class 技能陷阱
	{
		// Token: 0x060006CD RID: 1741 RVA: 0x000350D4 File Offset: 0x000332D4
		public static void LoadData()
		{
			技能陷阱.DataSheet = new Dictionary<string, 技能陷阱>();
			string text = CustomClass.GameData目录 + "\\System\\Skills\\Trap\\";
			if (Directory.Exists(text))
			{
				foreach (object obj in 序列化类.反序列化(text, typeof(技能陷阱)))
				{
					技能陷阱.DataSheet.Add(((技能陷阱)obj).陷阱名字, (技能陷阱)obj);
				}
			}
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x000027D8 File Offset: 0x000009D8
		public 技能陷阱()
		{
			
			
		}

		// Token: 0x04000B63 RID: 2915
		public static Dictionary<string, 技能陷阱> DataSheet;

		// Token: 0x04000B64 RID: 2916
		public string 陷阱名字;

		// Token: 0x04000B65 RID: 2917
		public ushort 陷阱编号;

		// Token: 0x04000B66 RID: 2918
		public ushort 分组编号;

		// Token: 0x04000B67 RID: 2919
		public 技能范围类型 陷阱体型;

		// Token: 0x04000B68 RID: 2920
		public ushort 绑定等级;

		// Token: 0x04000B69 RID: 2921
		public bool 陷阱允许叠加;

		// Token: 0x04000B6A RID: 2922
		public int 陷阱持续时间;

		// Token: 0x04000B6B RID: 2923
		public bool 持续时间延长;

		// Token: 0x04000B6C RID: 2924
		public bool 技能等级延时;

		// Token: 0x04000B6D RID: 2925
		public int 每级延长时间;

		// Token: 0x04000B6E RID: 2926
		public bool 角色属性延时;

		// Token: 0x04000B6F RID: 2927
		public GameObjectProperties 绑定角色属性;

		// Token: 0x04000B70 RID: 2928
		public float 属性延时系数;

		// Token: 0x04000B71 RID: 2929
		public bool 特定铭文延时;

		// Token: 0x04000B72 RID: 2930
		public 铭文技能 绑定铭文技能;

		// Token: 0x04000B73 RID: 2931
		public int 特定铭文技能;

		// Token: 0x04000B74 RID: 2932
		public int 铭文延长时间;

		// Token: 0x04000B75 RID: 2933
		public bool 陷阱能否移动;

		// Token: 0x04000B76 RID: 2934
		public ushort 陷阱移动速度;

		// Token: 0x04000B77 RID: 2935
		public byte 限制移动次数;

		// Token: 0x04000B78 RID: 2936
		public bool 当前方向移动;

		// Token: 0x04000B79 RID: 2937
		public bool 主动追击敌人;

		// Token: 0x04000B7A RID: 2938
		public byte 陷阱追击范围;

		// Token: 0x04000B7B RID: 2939
		public string 被动触发技能;

		// Token: 0x04000B7C RID: 2940
		public bool 禁止重复触发;

		// Token: 0x04000B7D RID: 2941
		public 指定目标类型 被动指定类型;

		// Token: 0x04000B7E RID: 2942
		public GameObjectType 被动限定类型;

		// Token: 0x04000B7F RID: 2943
		public 游戏对象关系 被动限定关系;

		// Token: 0x04000B80 RID: 2944
		public string 主动触发技能;

		// Token: 0x04000B81 RID: 2945
		public ushort 主动触发间隔;

		// Token: 0x04000B82 RID: 2946
		public ushort 主动触发延迟;
	}
}
