using System;
using System.Collections.Generic;
using GameServer.Data;

namespace GameServer.Templates
{
	
	public sealed class 回购排序 : IComparer<ItemData>
	{
		
		public int Compare(ItemData a, ItemData b)
		{
			return b.PurchaseId.CompareTo(a.PurchaseId);
		}

		
		public 回购排序()
		{
			
			
		}
	}
}
