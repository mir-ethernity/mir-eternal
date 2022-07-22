using System;
using System.Collections.Generic;
using GameServer.Data;

namespace GameServer.Templates
{
	// Token: 0x020002BE RID: 702
	public sealed class 回购排序 : IComparer<ItemData>
	{
		// Token: 0x060006D5 RID: 1749 RVA: 0x0000603E File Offset: 0x0000423E
		public int Compare(ItemData a, ItemData b)
		{
			return b.回购编号.CompareTo(a.回购编号);
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x000027D8 File Offset: 0x000009D8
		public 回购排序()
		{
			
			
		}
	}
}
