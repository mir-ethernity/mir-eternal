using System;
using System.Collections.Generic;

namespace GameServer.Maps
{
	
	public sealed class HateObject
	{
		
		public HateObject()
		{
			
			
			this.仇恨列表 = new Dictionary<MapObject, HateObject.仇恨详情>();
		}

		
		public bool 移除仇恨(MapObject 对象)
		{
			if (this.当前目标 == 对象)
			{
				this.当前目标 = null;
			}
			return this.仇恨列表.Remove(对象);
		}

		
		public void 添加仇恨(MapObject 对象, DateTime 时间, int 仇恨Value)
		{
			if (对象.Died)
			{
				return;
			}
			HateObject.仇恨详情 仇恨详情;
			if (this.仇恨列表.TryGetValue(对象, out 仇恨详情))
			{
				仇恨详情.仇恨时间 = ((仇恨详情.仇恨时间 < 时间) ? 时间 : 仇恨详情.仇恨时间);
				仇恨详情.仇恨Value += 仇恨Value;
				return;
			}
			this.仇恨列表[对象] = new HateObject.仇恨详情(时间, 仇恨Value);
		}

		
		public bool 切换仇恨(MapObject 主人)
		{
			int num = int.MinValue;
			List<MapObject> list = new List<MapObject>();
			foreach (KeyValuePair<MapObject, HateObject.仇恨详情> keyValuePair in this.仇恨列表)
			{
				if (keyValuePair.Value.仇恨Value > num)
				{
					num = keyValuePair.Value.仇恨Value;
					list = new List<MapObject>
					{
						keyValuePair.Key
					};
				}
				else if (keyValuePair.Value.仇恨Value == num)
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
				int num3 = 主人.GetDistance(MapObject2);
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

		
		public bool 最近仇恨(MapObject 主人)
		{
			int num = int.MaxValue;
			List<KeyValuePair<MapObject, HateObject.仇恨详情>> list = new List<KeyValuePair<MapObject, HateObject.仇恨详情>>();
			foreach (KeyValuePair<MapObject, HateObject.仇恨详情> item in this.仇恨列表)
			{
				int num2 = 主人.GetDistance(item.Key);
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
				if (keyValuePair.Value.仇恨Value > num3)
				{
					num3 = keyValuePair.Value.仇恨Value;
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

		
		public MapObject 当前目标;

		
		public DateTime 切换时间;

		
		public readonly Dictionary<MapObject, HateObject.仇恨详情> 仇恨列表;

		
		public sealed class 仇恨详情
		{
			
			public 仇恨详情(DateTime 仇恨时间, int 仇恨Value)
			{
				
				
				this.仇恨Value = 仇恨Value;
				this.仇恨时间 = 仇恨时间;
			}

			
			public int 仇恨Value;

			
			public DateTime 仇恨时间;
		}
	}
}
