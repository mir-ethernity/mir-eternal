using System;

namespace GameServer
{
	// Token: 0x02000004 RID: 4
	public enum ExecutionWay
	{
		// Token: 0x04000003 RID: 3
		前台立即执行,
		// Token: 0x04000004 RID: 4
		优先后台执行,
		// Token: 0x04000005 RID: 5
		只能后台执行,
		// Token: 0x04000006 RID: 6
		只能空闲执行
	}
}
