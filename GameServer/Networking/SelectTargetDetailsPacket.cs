using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 122, 长度 = 0, 注释 = "SelectTargetDetailsPacket")]
	public sealed class SelectTargetDetailsPacket : GamePacket
	{
		
		public SelectTargetDetailsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 当前体力;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int 当前魔力;

		
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public int 最大体力;

		
		[WrappingFieldAttribute(下标 = 20, 长度 = 4)]
		public int 最大魔力;

		
		[WrappingFieldAttribute(下标 = 24, 长度 = 1)]
		public byte[] Buff描述;
	}
}
