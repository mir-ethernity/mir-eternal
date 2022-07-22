using System;
using System.Collections.Generic;

namespace GameServer.Maps
{
	// Token: 0x020002DA RID: 730
	public sealed class HateObject
	{
		// Token: 0x060007D2 RID: 2002 RVA: 0x000067E9 File Offset: 0x000049E9
		public HateObject()
		{
			
			
			this.仇恨列表 = new Dictionary<MapObject, HateObject.仇恨详情>();
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x00006801 File Offset: 0x00004A01
		public bool 移除仇恨(MapObject 对象)
		{
			if (this.当前目标 == 对象)
			{
				this.当前目标 = null;
			}
			return this.仇恨列表.Remove(对象);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0003F3E0 File Offset: 0x0003D5E0
		public void 添加仇恨(MapObject 对象, DateTime 时间, int 仇恨数值)
		{
			if (对象.对象死亡)
			{
				return;
			}
			HateObject.仇恨详情 仇恨详情;
			if (this.仇恨列表.TryGetValue(对象, out 仇恨详情))
			{
				仇恨详情.仇恨时间 = ((仇恨详情.仇恨时间 < 时间) ? 时间 : 仇恨详情.仇恨时间);
				仇恨详情.仇恨数值 += 仇恨数值;
				return;
			}
			this.仇恨列表[对象] = new HateObject.仇恨详情(时间, 仇恨数值);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0003F448 File Offset: 0x0003D648
		public bool 切换仇恨(MapObject 主人)
		{
			int num = int.MinValue;
			List<MapObject> list = new List<MapObject>();
			foreach (KeyValuePair<MapObject, HateObject.仇恨详情> keyValuePair in this.仇恨列表)
			{
				if (keyValuePair.Value.仇恨数值 > num)
				{
					num = keyValuePair.Value.仇恨数值;
					list = new List<MapObject>
					{
						keyValuePair.Key
					};
				}
				else if (keyValuePair.Value.仇恨数值 == num)
				{
					list.Add(keyValuePair.Key);
				}
			}
			if (num == 0 && this.当前目标 != null)
			{
				return true;
			}
			int num2 = int.MaxValue;
			MapObject MapObject = null;
			foreach (MapObject MapObject2 in list)
			{
				int num3 = 主人.网格距离(MapObject2);
				if (num3 < num2)
				{
					num2 = num3;
					MapObject = MapObject2;
				}
			}
			PlayerObject PlayerObject = MapObject as PlayerObject;
			if (PlayerObject != null)
			{
				PlayerObject.玩家获得仇恨(主人);
			}
			return (this.当前目标 = MapObject) != null;
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0003F578 File Offset: 0x0003D778
		public bool 最近仇恨(MapObject 主人)
		{
			int num = int.MaxValue;
			List<KeyValuePair<MapObject, HateObject.仇恨详情>> list = new List<KeyValuePair<MapObject, HateObject.仇恨详情>>();
			foreach (KeyValuePair<MapObject, HateObject.仇恨详情> item in this.仇恨列表)
			{
				int num2 = 主人.网格距离(item.Key);
				if (num2 < num)
				{
					num = num2;
					list = new List<KeyValuePair<MapObject, HateObject.仇恨详情>>
					{
						item
					};
				}
				else if (num2 == num)
				{
					list.Add(item);
				}
			}
			int num3 = int.MinValue;
			MapObject MapObject = null;
			foreach (KeyValuePair<MapObject, HateObject.仇恨详情> keyValuePair in list)
			{
				if (keyValuePair.Value.仇恨数值 > num3)
				{
					num3 = keyValuePair.Value.仇恨数值;
					MapObject = keyValuePair.Key;
				}
			}
			PlayerObject PlayerObject = MapObject as PlayerObject;
			if (PlayerObject != null)
			{
				PlayerObject.玩家获得仇恨(主人);
			}
			return (this.当前目标 = MapObject) != null;
		}

		// Token: 0x04000CD7 RID: 3287
		public MapObject 当前目标;

		// Token: 0x04000CD8 RID: 3288
		public DateTime 切换时间;

		// Token: 0x04000CD9 RID: 3289
		public readonly Dictionary<MapObject, HateObject.仇恨详情> 仇恨列表;

		// Token: 0x020002DB RID: 731
		public sealed class 仇恨详情
		{
			// Token: 0x060007D7 RID: 2007 RVA: 0x0000681F File Offset: 0x00004A1F
			public 仇恨详情(DateTime 仇恨时间, int 仇恨数值)
			{
				
				
				this.仇恨数值 = 仇恨数值;
				this.仇恨时间 = 仇恨时间;
			}

			// Token: 0x04000CDA RID: 3290
			public int 仇恨数值;

			// Token: 0x04000CDB RID: 3291
			public DateTime 仇恨时间;
		}
	}
}
