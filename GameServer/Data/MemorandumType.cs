using System;

namespace GameServer.Data
{
	// Token: 0x0200026D RID: 621
	public enum MemorandumType
	{
		// Token: 0x0400086A RID: 2154
		创建公会 = 1,
		// Token: 0x0400086B RID: 2155
		加入公会,
		// Token: 0x0400086C RID: 2156
		离开公会,
		// Token: 0x0400086D RID: 2157
		逐出公会,
		// Token: 0x0400086E RID: 2158
		变更职位,
		// Token: 0x0400086F RID: 2159
		建筑升级,
		// Token: 0x04000870 RID: 2160
		会长传位 = 8,
		// Token: 0x04000871 RID: 2161
		行会结盟,
		// Token: 0x04000872 RID: 2162
		行会敌对,
		// Token: 0x04000873 RID: 2163
		建造建筑 = 12,
		// Token: 0x04000874 RID: 2164
		建筑被毁,
		// Token: 0x04000875 RID: 2165
		建筑拆除,
		// Token: 0x04000876 RID: 2166
		Boss刷新,
		// Token: 0x04000877 RID: 2167
		战争获胜,
		// Token: 0x04000878 RID: 2168
		战争失败,
		// Token: 0x04000879 RID: 2169
		防守胜利,
		// Token: 0x0400087A RID: 2170
		防守失败,
		// Token: 0x0400087B RID: 2171
		取消结盟 = 21,
		// Token: 0x0400087C RID: 2172
		取消敌对
	}
}
