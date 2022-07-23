using System;
using System.Collections.Generic;
using GameServer.Data;

namespace GameServer.Templates
{
	
	public sealed class 回购排序 : IComparer<ItemData>
	{
		
		public int Compare(ItemData a, ItemData b)
		{
			return b.回购编号.CompareTo(a.回购编号);
		}

		
		public 回购排序()
		{
			
			
		}
	}
}
