using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 522, 长度 = 51, 注释 = "同步队员信息")]
	public sealed class 同步队员信息 : GamePacket
	{
		
		public 同步队员信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 对象等级;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public int MaxPhysicalStrength;

		
		[WrappingFieldAttribute(下标 = 18, 长度 = 4)]
		public int MaxMagic2;

		
		[WrappingFieldAttribute(下标 = 22, 长度 = 4)]
		public int 当前体力;

		
		[WrappingFieldAttribute(下标 = 26, 长度 = 4)]
		public int 当前魔力;

		
		[WrappingFieldAttribute(下标 = 30, 长度 = 4)]
		public int 当前地图;

		
		[WrappingFieldAttribute(下标 = 34, 长度 = 4)]
		public int 当前线路;

		
		[WrappingFieldAttribute(下标 = 38, 长度 = 4)]
		public int 横向坐标;

		
		[WrappingFieldAttribute(下标 = 42, 长度 = 4)]
		public int 纵向坐标;

		
		[WrappingFieldAttribute(下标 = 46, 长度 = 4)]
		public int 坐标高度;

		
		[WrappingFieldAttribute(下标 = 50, 长度 = 4)]
		public byte AttackMode;
	}
}
