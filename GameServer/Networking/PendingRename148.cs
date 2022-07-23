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

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 当前地图;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 当前线路;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(下标 = 15, 长度 = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(下标 = 16, 长度 = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(下标 = 62, 长度 = 4)]
		public Point 对象坐标;

		
		[WrappingFieldAttribute(下标 = 66, 长度 = 2)]
		public ushort 对象高度;

		
		[WrappingFieldAttribute(下标 = 68, 长度 = 2)]
		public ushort 对象朝向;

		
		[WrappingFieldAttribute(下标 = 71, 长度 = 4)]
		public int 所需经验;

		
		[WrappingFieldAttribute(下标 = 83, 长度 = 4)]
		public int 经验上限;

		
		[WrappingFieldAttribute(下标 = 87, 长度 = 4)]
		public int 双倍经验;

		
		[WrappingFieldAttribute(下标 = 95, 长度 = 4)]
		public int PK值惩罚;

		
		[WrappingFieldAttribute(下标 = 99, 长度 = 1)]
		public byte AttackMode;

		
		[WrappingFieldAttribute(下标 = 116, 长度 = 4)]
		public int 当前时间;

		
		[WrappingFieldAttribute(下标 = 134, 长度 = 2)]
		public ushort OpenLevelCommand;

		
		[WrappingFieldAttribute(下标 = 144, 长度 = 4)]
		public int 当前经验;

		
		[WrappingFieldAttribute(下标 = 169, 长度 = 2)]
		public ushort 特修折扣;
	}
}
