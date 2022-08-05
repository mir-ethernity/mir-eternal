using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 12, 长度 = 171, 注释 = "同步CharacterData(地图.坐标.职业.性别.等级...)")]
	public sealed class 同步CharacterData : GamePacket
	{
		
		public 同步CharacterData()
		{
			
			this.经验上限 = 2000000000;
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int CurrentMap;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 当前线路;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(SubScript = 15, Length = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(SubScript = 62, Length = 4)]
		public Point 对象坐标;

		
		[WrappingFieldAttribute(SubScript = 66, Length = 2)]
		public ushort 对象高度;

		
		[WrappingFieldAttribute(SubScript = 68, Length = 2)]
		public ushort 对象朝向;

		
		[WrappingFieldAttribute(SubScript = 71, Length = 4)]
		public int 所需经验;

		
		[WrappingFieldAttribute(SubScript = 83, Length = 4)]
		public int 经验上限;

		
		[WrappingFieldAttribute(SubScript = 87, Length = 4)]
		public int DoubleExp;

		
		[WrappingFieldAttribute(SubScript = 95, Length = 4)]
		public int PK值惩罚;

		
		[WrappingFieldAttribute(SubScript = 99, Length = 1)]
		public byte AttackMode;

		
		[WrappingFieldAttribute(SubScript = 116, Length = 4)]
		public int 当前时间;

		
		[WrappingFieldAttribute(SubScript = 134, Length = 2)]
		public ushort OpenLevelCommand;

		
		[WrappingFieldAttribute(SubScript = 144, Length = 4)]
		public int CurrentExp;

		
		[WrappingFieldAttribute(SubScript = 169, Length = 2)]
		public ushort 特修折扣;
	}
}
