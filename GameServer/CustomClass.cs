using System;

namespace GameServer
{
	// Token: 0x02000022 RID: 34
	public static class CustomClass
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00002AC3 File Offset: 0x00000CC3
		static CustomClass()
		{
			
			CustomClass.武斗场时间一 = 13;
			CustomClass.武斗场时间二 = 21;
		}

		// Token: 0x04000035 RID: 53
		public static string 软件注册代码;

		// Token: 0x04000036 RID: 54
		public static string GameData目录;

		// Token: 0x04000037 RID: 55
		public static string 数据备份目录;

		// Token: 0x04000038 RID: 56
		public static ushort 客户连接端口;

		// Token: 0x04000039 RID: 57
		public static ushort 门票接收端口;

		// Token: 0x0400003A RID: 58
		public static ushort 封包限定数量;

		// Token: 0x0400003B RID: 59
		public static ushort 异常屏蔽时间;

		// Token: 0x0400003C RID: 60
		public static ushort 掉线判定时间;

		// Token: 0x0400003D RID: 61
		public static byte 游戏OpenLevelCommand;

		// Token: 0x0400003E RID: 62
		public static byte NoobSupportCommand等级;

		// Token: 0x0400003F RID: 63
		public static decimal 装备特修折扣;

		// Token: 0x04000040 RID: 64
		public static decimal 怪物额外爆率;

		// Token: 0x04000041 RID: 65
		public static decimal 怪物经验倍率;

		// Token: 0x04000042 RID: 66
		public static ushort 减收益等级差;

		// Token: 0x04000043 RID: 67
		public static decimal 收益减少比率;

		// Token: 0x04000044 RID: 68
		public static ushort 怪物诱惑时长;

		// Token: 0x04000045 RID: 69
		public static ushort 物品归属时间;

		// Token: 0x04000046 RID: 70
		public static ushort 物品清理时间;

		// Token: 0x04000047 RID: 71
		public static byte 武斗场时间一;

		// Token: 0x04000048 RID: 72
		public static byte 武斗场时间二;
	}
}
